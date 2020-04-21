using NhocGiftShop.Models.DAOModel;
using NhocGiftShop.Models.EntitiesModel;
using NhocGiftShop.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhocGiftShop.Models.BusinessModel
{
    public class ProductBUS
    {
        public static bool CreateProduct(Product p)
        {
            if (ProductDAO.CreateProduct(p)==true )
            {
                return true;
            }
            return false;
        }
        public static List<ProductView> GetAllProduct()
        {
            var list = ProductDAO.GetAllProduct();
            return list;
        }
        public static List<SubCategory> EditCbbSubCate(int idSC)
        {
            var list = ProductDAO.EditCbbSubCate(idSC);
            return list;
        }
        public static ProductView SelectProductByID(int idPro)
        {
            var ls = ProductDAO.SelectProductByID(idPro);
            return ls;
        }
        public static bool UpdateProduct(Product p)
        {
            if (ProductDAO.UpdateProduct(p)==true)
            {
                return true;
            }
            return false;
        }
        public static bool DelPro(int idPro)
        {
            if (ProductDAO.DelPro(idPro) == true)
            {
                return true;
            }
            return false;
        }
        public static List<Product> GetProductByIDSC(int idSC)
        {
            var ls = ProductDAO.GetProductByIDSC(idSC);
            return ls;
        }
    }
}