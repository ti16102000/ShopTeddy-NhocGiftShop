using NhocGiftShop.Models.EntitiesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhocGiftShop.Models.ViewModel
{
    public class SubCategoryView
    {
        public int idSC { get; set; }
        public string nameSC { get; set; }
        public int idCate { get; set; }
        public string nameCate { get; set; }
    }
}