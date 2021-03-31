using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using POSTable.WaiterApp.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static POSTable.ObjectStructures.Enumerators.Enumerators;

namespace POSTable.WaiterApp.Pages
{
    public partial class WaiterMenu
    {
        #region Properties
        [CascadingParameter]
        public WaiterController WaiterController { get; set; }
        #endregion

        #region Functionality
        /// <summary>
        /// this function will be called by the initialization of the async function
        /// </summary>
        /// <returns>the initialization of the task</returns>
        protected override async Task OnInitializedAsync()
        {
            await InitializeMenu();
        }

        /// <summary>
        /// this function will display the category sub-elements
        /// </summary>
        /// <param name="categoryCode">the category code passed from the category code</param>
        protected void DisplayCategory(Int32 categoryCode)
        {
            //the menu categories retrieved from the complete categories list
            ObjectStructures.MenuCategory menuCategory = WaiterController.WaiterMenu.MenuCategories.Where(x => x.CategoryCode == categoryCode).FirstOrDefault();
            //we open the menu category
            menuCategory.IsOpened = !menuCategory.IsOpened;
        }

        /// <summary>
        /// the main function for the initial select of an item
        /// </summary>
        /// <param name="codp">the current items product code</param>
        protected void SelectItem(Int32 codp)
        {
            //we retrieve the object from the list
            ObjectStructures.MenuItem item = WaiterController.WaiterMenu.MenuItems.FirstOrDefault(x => x.ProductCode == codp);
            //if no object was selected
            //chances for this to happen are slim to none but we will still check
            if (!item.Equals(null))
            {
                //if the item wasn't selected prior
                if (!item.IsSelected)
                {
                    //we select it
                    item.IsSelected = true;
                    //and set the quantity to one
                    item.ProductQuantity = 1;
                }
                else if (item.ProductQuantity == 1)
                {
                    //if it was selected and the quantity is one
                    //we deselect the item
                    item.IsSelected = false;
                    //and set the quantity to 0
                    item.ProductQuantity = 0;
                }
            }
        }

        /// <summary>
        /// the new function for altering the quantity
        /// replaces AddQunatity and SubstractQuantity
        /// </summary>
        /// <param name="codp">the Product Code</param>
        /// <param name="events">the quantity event</param>
        protected void AlterQuantity(Int32 codp, QuantityEvents events)
        {
            //we will retrieve the needed product
            ObjectStructures.MenuItem item = WaiterController.WaiterMenu.MenuItems.FirstOrDefault(x => x.ProductCode == codp);
            //we check the event and either increase or decrease the item
            if (events == QuantityEvents.add) item.ProductQuantity++;
            else if (events == QuantityEvents.substract && item.ProductQuantity > 0) item.ProductQuantity--;
            //and if the product quantity is 0 we deselect the product
            if (item.ProductQuantity == 0) item.IsSelected = false;
        }

        /// <summary>
        /// this function will reset the selection for all the items
        /// </summary>
        protected void ResetSelection()
        {
            WaiterController.WaiterMenu.MenuItems.ForEach(element => 
            {
                element.IsSelected = false;
                element.ProductQuantity = 0;
            });
        }

        /// <summary>
        /// the main function for the validation of the command
        /// </summary>
        protected void ValidateSelection()
        {
            WaiterController.PageState = PageState.validateCommand;
        }

        /// <summary>
        /// the main function for the return to the table selection
        /// </summary>
        protected void ReturnToTableSelection()
        {
            ResetSelection();
            WaiterController.PageState = PageState.tableMenu;
        }

        #region Auxilliary Functionality
        protected async Task InitializeMenu()
        {
            //we initialize a string for containing the retrieved xmlDocuments
            String xmlDocument = String.Empty;
            //first we check if the table is open so we call the WebMethod with the table code
            xmlDocument = await http.GetStringAsync(WebMethods.GetIsTableOpen + WaiterController.SelectedTable.ID.ToString());
            //we deserialize the object and read the answe
            Boolean answer = await Task.Run(() => CheckTable(xmlDocument));
            //if the tableCheck has not been made prior and the table has an active sale we display a message that the table is open
            String xmlDocumentAdministrations = await http.GetStringAsync(WebMethods.GetAdministrations);
            String xmlDocumentCategories = await http.GetStringAsync(WebMethods.GetCategories);
            String xmlDocumentSale = await http.GetStringAsync(WebMethods.GetSaleOfTable + WaiterController.SelectedTable.ID.ToString());
            //we retrieve the votable List from the webService
            xmlDocument = await http.GetStringAsync(WebMethods.GetMenu);
            //and deserialize the object to the needed structure
            await Task.Run(() => DeserializeDocument(xmlDocument))
                        .ContinueWith((t) => DeserializeCategories(xmlDocumentAdministrations, xmlDocumentCategories))
                        .ContinueWith((t)=>DeserializeSale(xmlDocumentSale));
        }

        /// <summary>
        /// the function will deserialize the answer xmlDocument to check if the table is Open
        /// </summary>
        /// <param name="xmlDocument">the XmlDocument retrieve from the WebService</param>
        /// <returns>the answer value</returns>
        protected Boolean CheckTable(String xmlDocument)
        {
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

        /// <summary>
        /// this function will deserialize the base categories retrieved from the webService
        /// </summary>
        /// <param name="xmlDocumentAdministrations"></param>
        /// <param name="xmlDocumentCategories"></param>
        protected void DeserializeCategories(String xmlDocumentAdministrations, String xmlDocumentCategories)
        {
            XmlSerializer administrationsSerializer = new(typeof(XmlClasses.Administrations));
            XmlSerializer categorySerializer = new(typeof(XmlClasses.Categories));
            XmlClasses.Administrations administrations = new();
            XmlClasses.Categories categories = new();
            using (TextReader reader = new StringReader(xmlDocumentAdministrations))
            {
                administrations = (XmlClasses.Administrations)administrationsSerializer.Deserialize(reader);
            }
            using (TextReader reader1 = new StringReader(xmlDocumentCategories))
            {
                categories = (XmlClasses.Categories)categorySerializer.Deserialize(reader1);
            }
            WaiterController.WaiterMenu.InitializeMenuCategoriesFromServer(categories, administrations);
        }

        /// <summary>
        /// this function will deserialize the xml Menu Document
        /// </summary>
        /// <param name="xmlDocument">the retrieved XmlDocument</param>
        protected void DeserializeDocument(String xmlDocument)
        {
            //we initialize a serializer over the menu object
            XmlSerializer serializer = new(typeof(XmlClasses.Meniu));
            //initialize a new Meniu class
            XmlClasses.Meniu meniu = new();
            //then using a text reader
            using (TextReader reader = new StringReader(xmlDocument))
            {
                //we deserialize the meniu to a class
                meniu = (XmlClasses.Meniu)serializer.Deserialize(reader);
            }
            //and initialize the global menu from the deserialized object
            WaiterController.WaiterMenu.InitializeMenuFromServer(meniu);
        }

        protected void DeserializeSale(String xmlDocument)
        {
            XmlSerializer serializer = new(typeof(List<XmlClasses.OpenSale>));
            List<XmlClasses.OpenSale> saleItems = new();
            using TextReader reader = new StringReader(xmlDocument);
            saleItems = (List<XmlClasses.OpenSale>)serializer.Deserialize(reader);
            WaiterController.WaiterMenu.MenuItems
                .ForEach(element => element.ProductQuantity = saleItems
                                        .Where(item => item.ProductCode == element.ProductCode)
                                            .FirstOrDefault()?.ProductQuantity ?? 0);
        }
        #endregion
        #endregion
    }
}
