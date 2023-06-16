﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models
{
    public class Currency
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public string Description { get; set; }
    }
}
