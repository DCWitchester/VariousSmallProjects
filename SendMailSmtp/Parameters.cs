using System;
using System.Collections.Generic;
using System.Text;

namespace SendMailSmtp
{
    class Parameters
    {
        /// <summary>
        /// the alternative sender address property
        /// </summary>
        public String AlternativeSender { get; set; }
        /// <summary>
        /// the display name property
        /// </summary>
        public String DisplayName { get; set; }
        /// <summary>
        /// the receiver of this email
        /// </summary>
        public String To { get; set; }
        /// <summary>
        /// the subject of the current email
        /// </summary>
        public String Subject { get; set; }
        /// <summary>
        /// the body of the email
        /// </summary>
        public String Body { get; set; }
        /// <summary>
        /// the element body formatting:  true for html, false for string
        /// </summary>
        public Boolean HtmlBody { get; set; }
        /// <summary>
        /// the header formatting for the email substructure
        /// </summary>
        public Boolean RequestResponse { get; set; }
        /// <summary>
        /// the email attachements
        /// </summary>
        public List<String> Attachements { get; set; }
        /// <summary>
        /// for use with the htmlValues
        /// </summary>
        public List<Tuple<String,String>> ParameterValues { get; set; }
        /// <summary>
        /// for use with the email list
        /// </summary>
        public List<String> CC { get; set; }
        /// <summary>
        /// for use with the email list
        /// </summary>
        public List<String> BCC { get; set; }
    }
}
