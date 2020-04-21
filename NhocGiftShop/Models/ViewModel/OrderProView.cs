using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhocGiftShop.Models.ViewModel
{
    public class OrderProView
    {
        public int idOP { get; set; }
        public int idIP { get; set; }
        public int total { get; set; }
        public string nameIP { get; set; }
    }
}