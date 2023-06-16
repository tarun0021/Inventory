﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Inventory.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        [Display(Name = "Purchase Order")]
        public string Name { get; set; }
        [Display(Name = "Branch")]
        public int BrachId { get; set; }
        [Display(Name = "Vendor")]
        public int VendorId { get; set; }
        public DateTimeOffset DateOfOrder { get; set; }
        public DateTimeOffset DateOfDelivery { get; set; }
        [Display(Name = "Currency")]
        public int CurrencyId { get; set; }
        [Display(Name = "Purchse Type")]
        public int PurchaseTypeId { get; set; }
        public string Remarks { get; set; }
        public double Amount { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set;}
        public double Total { get; set; }
        public ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        = new HashSet<PurchaseOrderLine>();
    }
}
