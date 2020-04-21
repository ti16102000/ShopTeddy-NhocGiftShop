using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhocGiftShop.Models.ViewModel
{
    public class CartView
    {
        public int idPF { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public int amount { get; set; }
        public string colorName { get; set; }
        public string size { get; set; }
        public string  namePro { get; set; }
    }
}