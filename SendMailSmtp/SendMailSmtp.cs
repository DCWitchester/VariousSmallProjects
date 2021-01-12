using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace SendMailSmtp
{
    public class SendMailSmtp
    {
        #region Properties
        /// <summary>
        /// the mail message to be sent
        /// </summary>
        MailMessage Mail { get; set; }
        /// <summary>
        /// the mail client that will make the connection
        /// </summary>
        SmtpClient Client { get; set; }
#pragma warning disable IDE1006
        /// <summary>
        /// the mail sender
        /// </summary>
        String mailSender { get; set; } = String.Empty;
        /// <summary>
        /// the mail password
        /// </summary>
        String mailPassword { get; set; } = String.Empty;
        /// <summary>
        /// the alternative mail property <= linked to the sender
        /// </summary>
        String mailSenderAlternative { get; set; } = String.Empty;
        /// <summary>
        /// the displayName mail property <= linked to the sender
        /// </summary>
        String mailSenderDisplayName { get; set; } = String.Empty;
        /// <summary>
        /// the mail adreess to receive the mail
        /// </summary>
        String mailReceiver { get; set; } = String.Empty;
        /// <summary>
        /// the mail subject 
        /// </summary>
        String mailSubject { get; set; } = String.Empty;
        /// <summary>
        /// the body of the mail
        /// </summary>
        String mailBody { get; set; } = String.Empty;
        /// <summary>
        /// the atachements list
        /// </summary>
        List<String> mailAtachements { get; set; } = new List<String>();
        /// <summary>
        /// the mail body formating
        /// </summary>
        Boolean IsMailHtml { get; set; } = false;
        /// <summary>
        /// the main header formating
        /// </summary>
        Boolean requestAnswer { get; set; } = false;
        /// <summary>
        /// the setting for the configuration of the sender and receiver as a MailAddress
        /// </summary>
        Boolean useMailAddresses { get; set; } = false;
        /// <summary>
        /// the setting for the configuration of the additional receivers for the email
        /// </summary>
        Boolean useCCEmails { get; set; } = false;
        /// <summary>
        /// the setting for the configuration of the additional receivers for the email
        /// </summary>
        Boolean useBCCEmails { get; set; } = false;
        /// <summary>
        /// the email list for the additional receivers
        /// </summary>
        List<String> emailList { get; set; } = new List<String>();
#pragma warning restore IDE1006

        #region Enumerators
        /// <summary>
        /// the additional recipient types
        /// </summary>
        public enum AdditionalRecipientsTypes
        {
            BCC,
            CC
        }
        #endregion 

        #endregion

        #region Setters
        /// <summary>
        /// the main setter for the emails sender
        /// </summary>
        public String SetSenderAddress
        {
            set => mailSender = CheckMail(value);
        }

        /// <summary>
        /// the main setter for the emails recepient
        /// </summary>
        public String SetMailReceiver
        {
            set => mailReceiver = CheckMail(value);
        }

        /// <summary>
        /// the main setter for the emails body
        /// </summary>
        public String SetMailBody
        {
            set => mailBody = value;
        }

        /// <summary>
        /// the main setter for the emails password
        /// </summary>
        public String SetMailPassword
        {
            set => mailPassword = value;
        }

        /// <summary>
        /// the main setter for the emails alternative sender
        /// </summary>
        public String SetMailSenderAlternative
        {
            set => mailSenderAlternative = value;
        }

        /// <summary>
        /// the main setter for the emails display name
        /// </summary>
        public String SetMailDisplayName
        {
            set => mailSenderDisplayName = value;
        }

        /// <summary>
        /// the main setter for the emails subject
        /// </summary>
        public String SetMailSubject
        {
            set => mailSubject = value;
        }
        /// <summary>
        /// this function will set the email body to html formatting
        /// </summary>
        public Boolean FormatMailBody
        {
            set => IsMailHtml = value;
        }
        /// <summary>
        /// this function will convert the email header to requested an answer
        /// </summary>
        public Boolean RequestResponse
        {
            set => requestAnswer = value;
        }
        /// <summary>
        /// this function will convert the sender and receiver to be used as email address Object
        /// </summary>
        public Boolean UseMailAddresses
        {
            set => useMailAddresses = value;
        }
        /// <summary>
        /// this function will set the additional receiver list to be a CC
        /// </summary>
        public Boolean UseCCEmails
        {
            set => useCCEmails = value;
        }
        /// <summary>
        /// this function will set the additional receiver list to be a BCC
        /// </summary>
        public Boolean UseBCCEmails
        {
            set => useBCCEmails = value;
        }
        /// <summary>
        /// the email list for the additional receivers
        /// </summary>
        public List<String> EmailList 
        {
            set => emailList = value;
            get => emailList;
        }
        #region Default Values
        /// <summary>
        /// this is the default email address for sending emails
        /// </summary>
        public String GetDefaultEmail => "helpdesk.mentorsoft@gmail.com";
        /// <summary>
        /// this is the default emai password
        /// </summary>
        public String GetAppPassword => "vpyuufezmukqmfav";
        /// <summary>
        /// this function will set the default sender and app password for the email
        /// </summary>
        public void SetDefaultSender()
        {
            mailSender = GetDefaultEmail;
            mailPassword = GetAppPassword;
        }
        #endregion Default Values
        /// <summary>
        /// this function will add an atachement to the email
        /// </summary>
        /// <param name="atachementPath"> the path towards the file that will be added as an atachement </param>
        public void AddAtachement(String atachementPath)
        {
            mailAtachements.Add(atachementPath);
        }

        /// <summary>
        /// this function will add an atachement to the email
        /// </summary>
        /// <param name="atachementPath"> the path towards the file that will be added as an atachement </param>
        public void AddAtachement(String[] atachementPath)
        {
            mailAtachements.AddRange(atachementPath);
        }

        /// <summary>
        /// this function will add an atachement to the email
        /// </summary>
        /// <param name="atachementPath"> the path towards the file that will be added as an atachement </param>
        public void AddAtachement(List<String> atachementPath)
        {
            mailAtachements.AddRange(atachementPath);
        }
        #endregion

        #region Callers
        /// <summary>
        /// the main caller for the class
        /// </summary>
        public SendMailSmtp() { }
        /// <summary>
        /// the caller for the class with a specific email
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        public SendMailSmtp(String username, String password)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        public SendMailSmtp(String username, String password, String recepient)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes, Boolean isBodyHtml)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body and request an answer on read
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header response request formating</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body and request an answer on read
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header response request formating</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes, Boolean isBodyHtml, Boolean requestAnswer)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body and specific attachement
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="attachement">the email attachement</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachement);
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body and specific attachement
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="attachement">the email attachement</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachement);
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body and specific attachement
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachement">the email attachement</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachement);
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body and specific attachement
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachement">the email attachement</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes, Boolean isBodyHtml, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachement);
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body and specific attachement and request an answer on read
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header response request formating</param>
        /// <param name="attachement">the email attachement</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachement);
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body and specific attachement and request an answer on read
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header response request formating</param>
        /// <param name="attachement">the email attachement</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes, Boolean isBodyHtml, Boolean requestAnswer, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachement);
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body amd multiple attachements
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="attachements">the email attachements array</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachements);
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body amd multiple attachements
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="attachements">the email attachements array</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachements);
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body amd multiple attachements
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachements">the email attachements array</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachements);
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body amd multiple attachements
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachements">the email attachements array</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes, Boolean isBodyHtml, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachements);
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body and specific attachement and request an answer on read
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header response request formating</param>
        /// <param name="attachements">the email attachement</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachements);
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body and specific attachement and request an answer on read
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header response request formating</param>
        /// <param name="attachements">the email attachement</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes, Boolean isBodyHtml, Boolean requestAnswer, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachements);
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body and multiple attachements
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="attachementList">the email attachements list</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, List<String> attachementList)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachementList);
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body and multiple attachements
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="attachementList">the email attachements list</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes, List<String> attachementList)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachementList);
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body and multiple attachements
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachementList">the email attachements list</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, List<String> attachementList)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachementList);
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body and multiple attachements
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachementList">the email attachements list</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes, Boolean isBodyHtml, List<String> attachementList)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachementList);
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body and specific attachement and request an answer on read
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header response request formating</param>
        /// <param name="attachements">the email attachement</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer, List<String> attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachements);
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body and specific attachement and request an answer on read
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header response request formating</param>
        /// <param name="attachements">the email attachement</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes, Boolean isBodyHtml, Boolean requestAnswer, List<String> attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachements);
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
        }
        #endregion

        #region Private Functions

        #region Main Functions
        /// <summary>
        /// this function will reinitialize the client
        /// </summary>
        void InitializaClient()
        {
            Client = new SmtpClient
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new NetworkCredential(mailSender, mailPassword),
                Host = "smtp.gmail.com"
            };
        }
        /// <summary>
        /// this function will initialize the mail giving it a sender and a receiver
        /// </summary>
        /// <param name="sender"> FROM</param>
        /// <param name="receiver">TO</param>
        void InitializeMail(String sender, String receiver)
        {
            Mail = new MailMessage(sender, receiver);
        }
        /// <summary>
        /// this function will initialize the mail giving it a sender and receiver based on address Objects
        /// </summary>
        /// <param name="sender">FROM</param>
        /// <param name="receiver">TO</param>
        void InitializeMail(MailAddress sender, MailAddress receiver)
        {
            Mail = new MailMessage(sender, receiver);
        }
        /// <summary>
        /// the mail checker 
        /// </summary>
        /// <param name="mail"></param>
        /// <returns>wether the mail is valid or not</returns>
        String CheckMail(String mail)
        {
            try
            {
                var addr = new MailAddress(mail);
                return mail;
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region AuxilliaryFunctions
        /// <summary>
        /// this function will generate a MailAddress based on a given string
        /// </summary>
        /// <param name="mailSender">the mail sender string <= will only be displayed if linked to the email account because of GDRP</param>
        /// <returns>a valid MailAddress</returns>
        MailAddress GenerateMailAddress(String mailSender)
        {
            return new MailAddress(mailSender);
        }

        /// <summary>
        /// this function will generate a MailAddress based on a given string with a specific dispaly name
        /// </summary>
        /// <param name="mailSender">the mail sender string <= will only be displayed if linked to the email account because of GDRP</param>
        /// <param name="displayName">the display name for the email sender</param>
        /// <returns>a valid MailAddress</returns>
        MailAddress GenerateMailAddress(String mailSender, String displayName)
        {
            return new MailAddress(mailSender, displayName);
        }

        /// <summary>
        /// this function will get the needed mailAddress for the receiver
        /// </summary>
        /// <returns>a valid MailAddress</returns>
        MailAddress GetReceiverMailAddress()
        {
            return GenerateMailAddress(mailReceiver);
        }

        /// <summary>
        /// this function will get the needed mail address for the sender
        /// </summary>
        /// <returns>a valid MailAddress</returns>
        MailAddress GetSenderMailAddress()
        {
            //there will be a multi value path for the sender address unlike the receiver
            if (String.IsNullOrWhiteSpace(mailSenderDisplayName))
            {
                //first we check if the second parameter has value
                //and in consequence if the mail sender has an alternative value
                if (String.IsNullOrWhiteSpace(mailSenderAlternative)) return GenerateMailAddress(mailSender);
                else return GenerateMailAddress(mailSenderAlternative);
            }
            else
            {
                //on the second path all we need to check is the alternative value on the second parameter
                if (String.IsNullOrWhiteSpace(mailSenderAlternative)) return GenerateMailAddress(mailSender, mailSenderDisplayName);
                else return GenerateMailAddress(mailSenderAlternative, mailSenderDisplayName);
            }
        }

        /// <summary>
        /// this function will return the secondary email adresses as a MailAddress Object List
        /// </summary>
        /// <returns>the MailAddress Object List</returns>
        List<MailAddress> GetMailAddresses()
        {
            //we initialize a new empty list
            List<MailAddress> mailAddresses = new List<MailAddress>();
            //then foreach string in the email List
            foreach(String element in emailList)
            {
                //we add a new element to the list
                mailAddresses.Add(GenerateMailAddress(element));
            }
            //and return the element list
            return mailAddresses;
        }
        #endregion

        #endregion

        #region Public Functions
        /// <summary>
        /// this function will send the email after making all needed setting
        /// </summary>
        public void SendMail()
        {
            InitializaClient();

            if (useMailAddresses)
                InitializeMail(GetSenderMailAddress(), GetReceiverMailAddress());
            else
                InitializeMail(mailSender, mailReceiver);

            if (useCCEmails)
            {
                foreach (MailAddress element in GetMailAddresses())
                    Mail.CC.Add(element);
            }

            if (useBCCEmails)
            {
                foreach (MailAddress element in GetMailAddresses())
                    Mail.Bcc.Add(element);
            }

            Mail.Body = mailBody;
            Mail.IsBodyHtml = IsMailHtml;
            Mail.Subject = mailSubject;
            if (requestAnswer) Mail.Headers.Add("Disposition-Notification-To", mailSender);
            foreach (String atachement in mailAtachements)
            {
                Mail.Attachments.Add(new Attachment(atachement));
            }
            Client.Send(Mail);
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        public void SendMail(String username, String password)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative email display value</param>
        /// <param name="useEmailAddresses">the use of the email addresses</param>
        public void SendMail(String username, String password, String alternativeEmail, Boolean useEmailAddresses)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            UseMailAddresses = useEmailAddresses;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative email display value</param>
        /// <param name="displayName">the display name for the email</param>
        /// <param name="useEmailAddresses">the use of the email addresses</param>
        public void SendMail(String username, String password, String alternativeEmail, String displayName, Boolean useEmailAddresses)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            UseMailAddresses = useEmailAddresses;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        public void SendMail(String username, String password, String recepient)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative email display value</param>
        /// <param name="useEmailAddresses">the use of the email addresses</param>
        /// <param name="recepient">the recepient of the curent email</param>
        public void SendMail(String username, String password, String alternativeEmail, Boolean useEmailAddresses, String recepient)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            UseMailAddresses = useEmailAddresses;
            SetMailReceiver = recepient;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative email display value</param>
        /// <param name="displayName">the display name for the email</param>
        /// <param name="useEmailAddresses">the use of the email addresses</param>
        /// <param name="recepient">the recepient of the curent email</param>
        public void SendMail(String username, String password, String alternativeEmail, String displayName, Boolean? useEmailAddresses, String recepient)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            UseMailAddresses = useEmailAddresses ?? false;
            SetMailReceiver = recepient;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        public void SendMail(String username, String password, String recepient, String mailSubject)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative email display value</param>
        /// <param name="useEmailAddresses">the use of the email addresses</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        public void SendMail(String username, String password, String alternativeEmail, Boolean useEmailAddresses, String recepient, String mailSubject)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            UseMailAddresses = useEmailAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative email display value</param>
        /// <param name="displayName">the display name for the email</param>
        /// <param name="useEmailAddresses">the use of the email addresses</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        public void SendMail(String username, String password, String alternativeEmail, String displayName, Boolean useEmailAddresses, String recepient, String mailSubject)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            UseMailAddresses = useEmailAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative email display value</param>
        /// <param name="useEmailAddresses">the use of the email addresses</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        public void SendMail(String username, String password, String alternativeEmail, Boolean useEmailAddresses, String recepient, String mailSubject, String mailBody)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            UseMailAddresses = useEmailAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative email display value</param>
        /// <param name="useEmailAddresses">the use of the email addresses</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public void SendMail(String username, String password, String alternativeEmail, Boolean useEmailAddresses, String recepient, String mailSubject, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            UseMailAddresses = useEmailAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative email display value</param>
        /// <param name="displayName">the display name for the email</param>
        /// <param name="useEmailAddresses">the use of the email addresses</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        public void SendMail(String username, String password, String alternativeEmail, String displayName, Boolean useEmailAddresses, String recepient, String mailSubject, String mailBody)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            UseMailAddresses = useEmailAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative email display value</param>
        /// <param name="displayName">the display name for the email</param>
        /// <param name="useEmailAddresses">the use of the email addresses</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public void SendMail(String username, String password, String alternativeEmail, String displayName, Boolean useEmailAddresses, String recepient, String mailSubject, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            UseMailAddresses = useEmailAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="mailBody">the current emails body</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, Boolean isBodyHtml, String mailBody)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, Boolean isBodyHtml, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and request a response from the recipient
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header formatting to request an answer from the recipient</param>
        /// <param name="mailBody">the current emails body</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, Boolean isBodyHtml, Boolean requestAnswer, String mailBody)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and request a response from the recipient
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header formatting to request an answer from the recipient</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, Boolean isBodyHtml, Boolean requestAnswer, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachement
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="attachement">the current emails attachement</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachement);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachement
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="attachement">the current emails attachement</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachement);
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachement
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachement">the current emails attachement</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachement);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachement
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachement">the current emails attachement</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes, Boolean isBodyHtml, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachement);
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachement and request an answer from the receiver
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header formatting to request an answer from the recipient</param>
        /// <param name="attachement">the current emails attachement</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachement);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachement and request an answer from the receiver
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header formatting to request an answer from the recipient</param>
        /// <param name="attachement">the current emails attachement</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes, Boolean isBodyHtml, Boolean requestAnswer, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachement);
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="attachements">the current emails attachements array</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachements);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="attachements">the current emails attachements array</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param> 
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachements);
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachements">the current emails attachements array</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachements);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachements">the current emails attachements array</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes, Boolean isBodyHtml, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachements);
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements and requests an answer from the recipient
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header formatting to request an answer from the recipient</param>
        /// <param name="attachements">the current emails attachements array</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachements);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements and requests an answer from the recipient
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header formatting to request an answer from the recipient</param>
        /// <param name="attachements">the current emails attachements array</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes, Boolean isBodyHtml, Boolean requestAnswer, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachements);
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="attachementList">the current emails attachements list</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, List<String> attachementList)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachementList);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="attachementList">the current emails attachements list</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes, List<String> attachementList)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachementList);
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachementList">the current emails attachements list</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, List<String> attachementList)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachementList);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachementList">the current emails attachements list</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes, Boolean isBodyHtml, List<String> attachementList)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachementList);
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements and requests an answer from the recipient
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header formatting to request an answer from the recipient</param>
        /// <param name="attachements">the current emails attachements array</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer, List<String> attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachements);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements and requests an answer from the recipient
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header formatting to request an answer from the recipient</param>
        /// <param name="attachements">the current emails attachements array</param>
        /// <param name="additionalRecipients">the list of additional recepients</param>
        /// <param name="additionalRecipientsTypes">the type of additional recepients: BCC | CC</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, List<String> additionalRecipients, AdditionalRecipientsTypes additionalRecipientsTypes, Boolean isBodyHtml, Boolean requestAnswer, List<String> attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachements);
            //additional recepients type elements
            useBCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.BCC;
            useCCEmails = additionalRecipientsTypes == AdditionalRecipientsTypes.CC;
            emailList = additionalRecipients;
            SendMail();
        }
        #endregion
    }
}