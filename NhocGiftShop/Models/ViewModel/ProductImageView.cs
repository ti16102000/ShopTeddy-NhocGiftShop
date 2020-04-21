using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhocGiftShop.Models.ViewModel
{
    public class ProductImageView
    {
        public int idPI { get; set; }
        public int idPro { get; set; }
        public string imgPro { get; set; }
        public string namePro { get; set; }
        public Nullable<bool> imgMain { get; set; }
    }
}