using NhocGiftShop.Models.EntitiesModel;
using NhocGiftShop.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhocGiftShop.Models.DAOModel
{
    public class ProductDAO
    {
        public static bool CreateProduct(Product p)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            ngse.Products.Add(p);
            if (ngse.SaveChanges()>0)
            {
                return true;
            }
            return false;
        }
        public static List<ProductView> GetAllProduct()
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var list =ngse.Products.Select(s => new ProductView { idPro = s.idPro, idSC = s.idSC, namePro = s.namePro, material = s.material, description = s.description, nameSC = s.SubCategory.nameSC }).ToList();
            return list;
        }
        public static List<SubCategory> EditCbbSubCate(int idSC)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var list = ngse.SubCategories.Where(w => w.idSC != idSC).ToList();
            return list;
        }
        public static ProductView SelectProductByID(int idPro)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var list = ngse.Products.Where(w=>w.idPro==idPro).Select(s => new ProductView { idPro = s.idPro, idSC = s.idSC, namePro = s.namePro, material = s.material, description = s.description, nameSC = s.SubCategory.nameSC }).ToList().SingleOrDefault();
            return list;
        }
        public static bool UpdateProduct(Product p)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var q = ngse.Products.SingleOrDefault(s => s.idPro == p.idPro);
            q.namePro = p.namePro;
            q.material = p.material;
            q.description = p.description;
            q.idSC = p.idSC;
            if (ngse.SaveChanges()>0)
            {
                return true;
            }
            return false;
        }
        public static bool DelPro(int idPro)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var id = ngse.Products.SingleOrDefault(s => s.idPro == idPro);
            ngse.Products.Remove(id);
            if (ngse.SaveChanges()>0)
            {
                return true;
            }
            return false;
        }
        public static List<Product> GetProductByIDSC(int idSC)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var ls = ngse.Products.Where(w => w.idSC == idSC).ToList();
            return ls;
        }
    }
}