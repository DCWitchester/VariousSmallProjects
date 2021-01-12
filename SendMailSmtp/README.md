#SendMailSMTP
This project is an active email solution used to send either HTML based or Text based Emails via the GMAIL SMTP. <br/>
The program receive a configuration JSON as a parameter. <br/>
Configuration JSON Example: <br/>
```{
  "AlternativeSender": "",
  "DisplayName": "Echipa Mentor",
  "To": "mentor.constanta@gmail.com",
  "Subject": "Mentenanta MentorHR",
  "Body": "D:\\MailSMTP\\mailTest\\mentor2.html",
  "HtmlBody": true,
  "RequestResponse":false, 
  "Attachements": [],
  "ParameterValues": [],
  "CC": [],
  "BCC":[""]
}
```