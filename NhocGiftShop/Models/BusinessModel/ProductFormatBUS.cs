using NhocGiftShop.Models.DAOModel;
using NhocGiftShop.Models.EntitiesModel;
using NhocGiftShop.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhocGiftShop.Models.BusinessModel
{
    public class ProductFormatBUS
    {
        public static bool CreatePF(ProductFormat pf)
        {            
            if (ProductFormatDAO.CreatePF(pf)==true)
            {
                return true;
            }
            return false;
        }
        public static List<ProductFormat> GetPF(int idPro)
        {
            var list = ProductFormatDAO.GetPF(idPro);
            return list;
        }
        public static ProductFormatView SelectPFByID(int idPF)
        {
            var ls = ProductFormatDAO.SelectPFByID(idPF);
            return ls;
        }
        public static bool UpdatePF(ProductFormat pf)
        {
            if (ProductFormatDAO.UpdatePF(pf)==true)
            {
                return true;
            }
            return false;
        }
        public static bool DelPF(int idPF)
        {
            if (ProductFormatDAO.DelPF(idPF)==true)
            {
                return true;
            }
            return false;
        }
        public static int GetPriceDisplay(int idPro)
        {
            var price = ProductFormatDAO.GetPriceDisplay(idPro);
            return price;
        }
        public static List<ProductFormat> DistinctColor(int idPro)
        {
            var ls = ProductFormatDAO.DistinctColor(idPro);
            return ls;
        }
        public static List<ProductFormat> DistinctSize(int idPro)
        {
            var ls = ProductFormatDAO.DistinctSize(idPro);
            return ls;
        }
        public static List<ProductFormatView> SelectSizeByColor(string color, int idPro)
        {
            var ls = ProductFormatDAO.SelectSizeByColor(color, idPro);
            return ls;
        }
        public static int SelectPriceBySize(string size, int idPF)
        {
            var ls = ProductFormatDAO.SelectPriceBySize(size, idPF);
            return ls;
        }

    }
}