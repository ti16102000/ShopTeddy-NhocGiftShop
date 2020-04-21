using NhocGiftShop.Models.EntitiesModel;
using NhocGiftShop.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhocGiftShop.Models.DAOModel
{
    public class ProductImageDAO
    {
        public static bool CreatePI(ProductImage pi)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            ngse.ProductImages.Add(pi);
            if (ngse.SaveChanges()>0)
            {
                return true;
            }
            return false;
        }
        public static List<ProductImageView> GetImagePro(int idPro)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var list = ngse.ProductImages.Where(w => w.idPro == idPro).Select(s => new ProductImageView { idPI = s.idPI, idPro = s.idPro, imgPro = s.imgPro, namePro = s.Product.namePro,imgMain=s.imgMain }).ToList();
            return list;
        }
        public static bool DelImgPro(int idPI)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var id = ngse.ProductImages.SingleOrDefault(w => w.idPI == idPI);
            ngse.ProductImages.Remove(id);
            if (ngse.SaveChanges()>0)
            {
                return true;
            }
            return false;
        }
        public static string GetImgMainByIDPro(int idPro)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var imgName = ngse.ProductImages.SingleOrDefault(s => s.idPro == idPro && s.imgMain == true);
            if (imgName == null)
            {
                return null;
            }
            return imgName.imgPro;
        }
        public static List<ProductImage> GetImgByIDPro(int idPro)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var imgPro= ngse.ProductImages.Where(w=>w.idPro==idPro).ToList();
            return imgPro;
        }
    }
}