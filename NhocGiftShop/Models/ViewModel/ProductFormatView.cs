using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhocGiftShop.Models.ViewModel
{
    public class ProductFormatView
    {
        public int idPF { get; set; }
        public int idPro { get; set; }
        public string size { get; set; }
        public int price { get; set; }
        public string colorCSS { get; set; }
        public string colorName { get; set; }
        public string namePro { get; set; }
    }
}