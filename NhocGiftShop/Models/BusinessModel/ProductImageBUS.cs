using NhocGiftShop.Models.DAOModel;
using NhocGiftShop.Models.EntitiesModel;
using NhocGiftShop.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhocGiftShop.Models.BusinessModel
{
    public class ProductImageBUS
    {
        public static bool CreatePI(ProductImage pi)
        {
            if (ProductImageDAO.CreatePI(pi) ==true)
            {
                return true;
            }
            return false;
        }
        public static List<ProductImageView> GetImagePro(int idPro)
        {
            var pi = ProductImageDAO.GetImagePro(idPro);
            return pi;
        }
        public static bool DelImgPro(int idPI)
        {
            if (ProductImageDAO.DelImgPro(idPI)==true)
            {
                return true;
            }
            return false;
        }
        public static string GetImgMainByIDPro(int idPro)
        {
            var imgName = ProductImageDAO.GetImgMainByIDPro(idPro);
            if (imgName==null)
            {
                return null;
            }
            return imgName;
        }
        public static List<ProductImage> GetImgByIDPro(int idPro)
        {
            var imgPro = ProductImageDAO.GetImgByIDPro(idPro);
            return imgPro;
        }
    }
}