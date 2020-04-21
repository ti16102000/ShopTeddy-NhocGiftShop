using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhocGiftShop.Models.ViewModel
{
    public class InfoPersonView
    {
        public int idIP { get; set; }
        public string nameIP { get; set; }
        public string pwd { get; set; }
        public string email { get; set; }
        public Nullable<bool> gender { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string DOB { get; set; }
        public int idR { get; set; }
    }
}