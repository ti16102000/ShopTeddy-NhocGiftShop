using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhocGiftShop.Models.ViewModel
{
    public class ListProductClient
    {
        public int idPro { get; set; }
        public string namePro { get; set; }
        public string imgPro { get; set; }
        public int price { get; set; }
    }
}