using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSTable.ObjectStructures
{
    public class WaiterMenu
    {
        #region Properties
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// the waiter property
        /// </summary>
        protected Waiter waiter { get; set; } = new();
        /// <summary>
        /// the table property
        /// </summary>
        protected Table table { get; set; } = new();
        /// <summary>
        /// the menu categories property
        /// </summary>
        protected List<MenuCategory> menuCategories = new();
        /// <summary>
        /// the menu items property
        /// </summary>
        protected List<MenuItem> menuItems = new();
#pragma warning restore IDE1006 // Naming Styles
        #endregion

        #region Callers
        /// <summary>
        /// the waiter caller
        /// </summary>
        public Waiter Waiter
        {
            get => waiter;
            set => waiter = value;
        }

        /// <summary>
        /// the table caller
        /// </summary>
        public Table Table 
        { 
            get => table; 
            set => table = value; 
        }

        /// <summary>
        /// the caller for the menu categories
        /// </summary>
        public List<MenuCategory> MenuCategories
        {
            get => menuCategories;
            set => menuCategories = value;
        }

        /// <summary>
        /// the caller for the menu items
        /// </summary>
        public List<MenuItem> MenuItems
        {
            get => menuItems;
            set => menuItems = value;
        }

        /// <summary>
        /// the sale for the menu items
        /// </summary>
        public List<MenuItem> SaleItems
        {
            get => menuItems.Where(element => element.ProductQuantity > 0).ToList();
        }
        #endregion

        /// <summary>
        /// this function will initialize the menu items from the WebService XML
        /// </summary>
        /// <param name="menu">the deserialized xml</param>
        public void InitializeMenuFromServer(XmlClasses.Meniu menu)
        {
            menuItems = menu.Menu.Select(element => new MenuItem
            {
                ProductCode = element.ProductCode,
                ProductName = element.ProductName,
                ProductPrice = element.ProductPrice,
                ProductCategory = element.ProductCategory,
                DisplayOrder = element.DisplayOrder
            }).ToList();
        }

        /// <summary>
        /// this function will initialize the menu categories from the server XML
        /// </summary>
        /// <param name="categories">the deserialized xml</param>
        /// <param name="administrations">the deserialized xml</param>
        public void InitializeMenuCategoriesFromServer(XmlClasses.Categories categories, XmlClasses.Administrations administrations)
        {
            menuCategories = categories.categories.Select(element => new MenuCategory {
                CategoryCode = element.CategoryCode,
                CategoryName = element.CategoryName,
                CategoryOrder = element.DisplayOrder,
                AdministrationOrder = administrations.administrations
                                                .Where(x => x.AdminitrationCode == element.CategoryAdministration)
                                                .FirstOrDefault()?.DisplayOrder
            }).ToList();
        }

    }
}
