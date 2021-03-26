using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeScanner.ObjectClasses
{
    public class Barcode
    {
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// the code value 
        /// </summary>
        String codeValue { get; set; } = String.Empty;

        /// <summary>
        /// the code type
        /// </summary>
        String codeType { get; set; } = String.Empty;
#pragma warning restore IDE1006 // Naming Styles

        /// <summary>
        /// the main access for the code Value
        /// </summary>
        public String BarcodeValue 
        {
            get => codeValue;
            set => codeValue = value;
        }

        /// <summary>
        /// the main access for the code Type
        /// </summary>
        public String BarcodeType
        {
            get => codeType;
            set => codeType = value;
        }
    }
}
