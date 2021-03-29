using POSTable.ObjectStructures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POSTable.WaiterApp.Controllers
{
    public class WaiterLoginController
    {
        #region Properties
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// the waiterProperty for the Controller
        /// </summary>
        protected Waiter waiter { get; set; } = new();
        /// <summary>
        /// the check for the Validity of the waiter
        /// </summary>
        protected Boolean? isWaiterValid { get; set; } = true;
#pragma warning restore IDE1006 // Naming Styles
        #endregion

        readonly HttpClient httpClient = new();

        #region Callers
        public Waiter Waiter
        {
            get => waiter;
            private set => waiter = value;
        }

        public String WaiterCode
        {
            get => waiter.WaiterCode;
            set => _ = SetWaiter(value);
        }

        [Range(typeof(Boolean), "true", "true", ErrorMessage = "Nu exista un ospatar atribuit acestui cod")]
        public Boolean IsWaiterValid
        {
            get => isWaiterValid ?? false;
            protected set => isWaiterValid = value;
        }

        public event Action ValidateController;
        #endregion

        #region Constructors
        public WaiterLoginController(ref Waiter waiter) 
        {
            Waiter = waiter;
        }
        #endregion


        #region Functionality
        /// <summary>
        /// this function will set the waiter on the valid of the text box
        /// </summary>
        /// <param name="waiterCode"></param>
        private async Task<String> SetWaiter(String waiterCode)
        {

            Boolean answer = await CheckWaiter(waiterCode);
            if (answer)
            {
                Waiter = await GetWaiter(waiterCode);
            }
            isWaiterValid = answer;
            ValidateController?.Invoke();
            return waiterCode;
        }

        /// <summary>
        /// this function will retrieve the waiter from the webservice
        /// </summary>
        /// <param name="waiterCode"></param>
        /// <returns></returns>
        protected async Task<Waiter> GetWaiter(String waiterCode)
        {
            String xmlDocument = await httpClient.GetStringAsync(WebMethods.GetWaiter + waiterCode.PadLeft(10, '0'));
            //we initialize a new answe object
            XmlClasses.Waiter waiter;
            //and a new serializer over the answer object
            XmlSerializer xmlSerializer = new(typeof(XmlClasses.Waiter));
            //then using a text reader
            using TextReader reader = new StringReader(xmlDocument);
            //we deserialize the object
            waiter = (XmlClasses.Waiter)xmlSerializer.Deserialize(reader);
            return new Waiter(waiterCode: waiter.WaiterCode, waiterName: waiter.WaiterName, id: waiter.ID);
        }

        /// <summary>
        /// this function will chekc if the waiter is valid or not by deserializing the xmlDocument
        /// </summary>
        /// <param name="xmlDocument">the xmlDocument</param>
        /// <returns>the validity of the waiter</returns>
        protected async Task<Boolean> CheckWaiter(String waiterCode)
        {
            String xmlDocument = await httpClient.GetStringAsync(WebMethods.CheckWaiter + waiterCode.PadLeft(10, '0'));
            //we initialize a new answe object
            XmlClasses.Answer answer = new();
            //and a new serializer over the answer object
            XmlSerializer xmlSerializer = new(typeof(XmlClasses.Answer));
            //then using a text reader
            using (TextReader reader = new StringReader(xmlDocument))
            {
                //we deserialize the object
                answer = (XmlClasses.Answer)xmlSerializer.Deserialize(reader);
            }
            //and return the answer value
            return answer.Valoare;
        }
        #endregion

    }
}
