using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Text.Json;
using System.IO;
using Microsoft.Extensions.FileProviders;
using System.ComponentModel.DataAnnotations;

namespace SendMailSmtp
{
    class Program
    {
        static void Main(string[] args)
        {
            //we check if we have received the parameter
            //the only program parameter is the path to the json file
            if (args == null || args.Count() < 1) 
            {
                //if we don't receive a parameter we display error and return
                Console.WriteLine("Lipsa fisier parametri");
                return; 
            }

            //we take the configuration from the JSONSettings
            IConfiguration configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddEnvironmentVariables()
              .AddCommandLine(args)
              .Build();

            //we initialize the new mail smtp with the sender and password
            //this will be taken from the appsettings.json file
            SendMailSmtp sendMailSmtp = new SendMailSmtp
            (
                configuration["PublicSettings:MailAdress"],
                configuration["PublicSettings:Password"]
            );

            //once that is done we initialize a parameter structure and deserialize the object
            Parameters parameters;
            try
            {
                parameters = JsonSerializer.Deserialize<Parameters>(File.ReadAllText(args[0]));
            }
            catch (Exception e) 
            {
                //on error we dispaly the console
                Console.WriteLine(e.Message);
                return;
            }

            //we check the necesary parameters and if they aren't there we call error and display the error on the console
            if (parameters.To == null || String.IsNullOrWhiteSpace(parameters.To)) {
                Console.WriteLine("Parametru necesar lipsa: Adresa Destinatar");
                return;
            }
            else sendMailSmtp.SetMailReceiver = parameters.To;

            if (parameters.Subject == null || String.IsNullOrWhiteSpace(parameters.Subject))
            {
                Console.WriteLine("Parametru necesar lipsa: Subiect");
                return;
            }
            else sendMailSmtp.SetMailSubject = parameters.Subject;

            //this will configure the use of the mail address on send rather than the email
            if (!String.IsNullOrWhiteSpace(parameters.DisplayName) || !String.IsNullOrWhiteSpace(parameters.AlternativeSender))
                sendMailSmtp.UseMailAddresses = true;
            else
                sendMailSmtp.UseMailAddresses = false;

            //we check if there are BCC email addresses to be used
            if (parameters.BCC.Count > 0)
            {
                sendMailSmtp.UseBCCEmails = true;
                sendMailSmtp.EmailList.AddRange(parameters.BCC);
            }

            //we check if there are CC email addresses to be used
            if(parameters.CC.Count > 0)
            {
                sendMailSmtp.UseCCEmails = true;
                sendMailSmtp.EmailList.AddRange(parameters.CC);
            }

            //we will also set the mail display name
            sendMailSmtp.SetMailDisplayName = parameters.DisplayName;
            //and the alternative email address
            sendMailSmtp.SetMailSenderAlternative = parameters.AlternativeSender;

            //then dependent on if the body has a html format or not
            sendMailSmtp.FormatMailBody = parameters.HtmlBody;
            //we also set the header control
            sendMailSmtp.RequestResponse = parameters.RequestResponse;
            //we set the main body
            if (parameters.Body != null) 
            {
                //if the mail body is a html we read the html file
                if (parameters.HtmlBody)
                {
                    if (parameters.ParameterValues.Count > 0)
                    {
                        String tempValue = File.ReadAllText(parameters.Body);
                        foreach (var value in parameters.ParameterValues) tempValue = tempValue.Replace(value.Item1, value.Item2);
                        sendMailSmtp.SetMailBody = tempValue;
                    }
                    else sendMailSmtp.SetMailBody = File.ReadAllText(parameters.Body);
                }
                //else we set it to the parameter string.
                else sendMailSmtp.SetMailBody = parameters.Body;
            }

            //then one by one we send the parameters
            if(parameters.Attachements.Count > 0)
            {
                sendMailSmtp.AddAtachement(parameters.Attachements);
            }

            //and finally send the email
            sendMailSmtp.SendMail();
            //before logging the success
            Console.WriteLine("E-Mail trimis cu succes");
        }
    }
}
