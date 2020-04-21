using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NhocGiftShop.Models.ViewModel
{
    public class ProductView
    {
        public int idPro { get; set; }
        public string namePro { get; set; }
        public string material { get; set; }
        [AllowHtml]
        public string description { get; set; }
        public int idSC { get; set; }
        public string nameSC { get; set; }
    }
}