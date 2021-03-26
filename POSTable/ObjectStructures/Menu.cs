using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSTable.ObjectStructures
{
    /// <summary>
    /// the Menu Structure used for displaying a message
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// the default Sale Client
        /// </summary>
        public String SaleClient = String.Concat(Enumerable.Repeat("X", 10));
        /// <summary>
        /// the used Table
        /// </summary>
        public Int32 Table { get; set; }
        /// <summary>
        /// the initial SaleTime
        /// </summary>
        public DateTime SaleTime { get; set; }
        /// <summary>
        /// the itemList
        /// </summary>
        public List<MenuItem> itemList = new();
        /// <summary>
        /// the possible categories for the menu
        /// </summary>
        public List<MenuCategory> menuCategories = new();

        /// <summary>
        /// the Main Function for Initializing the Menu from the WebService XML
        /// </summary>
        /// <param name="menu"></param>
        public void InitializeMenuFromServer(XmlClasses.Meniu menu)
        {
            //we iterate the elements in the XmlDeserialized Object
            foreach (var element in menu.Menu)
            {
                //and add a new item to the list
                itemList.Add(
                    new MenuItem
                    {
                        ProductCode = element.ProductCode,
                        ProductName = element.ProductName,
                        ProductPrice = element.ProductPrice,
                        ProductCategory = element.ProductCategory,
                        DisplayOrder = element.DisplayOrder
                    });
            }
        }

        /// <summary>
        /// this function will initialize the menu categories from the server
        /// </summary>
        /// <param name="categories"></param>
        /// <param name="administrations"></param>
        public void InitializeMenuCategoriesFromServer(XmlClasses.Categories categories, XmlClasses.Administrations administrations)
        {
            foreach (var element in categories.categories)
            {
                menuCategories.Add(new MenuCategory
                {
                    CategoryCode = element.CategoryCode,
                    CategoryName = element.CategoryName,
                    CategoryOrder = element.DisplayOrder,
                    AdministrationOrder = administrations.administrations
                                                .Where(x => x.AdminitrationCode == element.CategoryAdministration)
                                                .FirstOrDefault()?.DisplayOrder
                });
            }
        }

        /// <summary>
        /// this function creates an JSON String from the Sale
        /// </summary>
        /// <returns>the JSON Object</returns>
        public String CreateSale()
        {
            //we initialize a new XmlSale
            XmlClasses.Sale sale = new();
            //then foreach element in the current object
            foreach (var element in itemList)
            {
                //we add a new item to the sale item
                sale.Vanzare.Add(new XmlClasses.SaleItem
                {
                    ProductCode = element.ProductCode,
                    ProductName = element.ProductName,
                    ProductPrice = element.ProductPrice,
                    ProductQuantity = element.ProductQuantity,
                    Table = Table,
                    SaleClient = SaleClient
                    //SaleTime = SaleTime
                });
            }
            //then we serialize the object to the json
            String json = JsonConvert.SerializeObject(sale);
            return json;
        }

        /// <summary>
        /// this function will set a new sale time
        /// </summary>
        public void SetSaleTime()
        {
            SaleTime = DateTime.Now;
        }
    }
}
