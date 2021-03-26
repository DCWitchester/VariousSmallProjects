using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSTable.ObjectStructures
{
    /// <summary>
    /// the MenuCategory for filtered Display
    /// </summary>
    public class MenuCategory
    {
        public Int32 CategoryCode { get; set; } = 0;
        public String CategoryName { get; set; } = String.Empty;
        public Int32 CategoryOrder { get; set; } = 0;
        public Int32? AdministrationOrder { get; set; } = 0;
        public Boolean IsOpened { get; set; } = false;

    }
}
