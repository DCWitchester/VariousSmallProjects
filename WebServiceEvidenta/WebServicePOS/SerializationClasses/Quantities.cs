using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceEvidenta.SerializationClasses
{
    public class Quantities
    {
        public String UserBundle { get; set; } = String.Empty;
        public String ManagementUnit { get; set; } = String.Empty;
        public String PartnerCode { get; set; } = String.Empty;
        public Int32 DocumentNumber { get; set; } = new Int32();
        public Boolean IsAviz { get; set; } = new Boolean();
        public String DocumentDate { get; set; } = String.Empty;
        /// <summary>
        /// the main list of productQuantities for serialization/deserialization
        /// </summary>
        public List<ProductQuantity> ProductQuantities { get; set; } = new List<ProductQuantity>();
    }
}