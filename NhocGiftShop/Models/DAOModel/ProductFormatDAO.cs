using NhocGiftShop.Models.EntitiesModel;
using NhocGiftShop.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace NhocGiftShop.Models.DAOModel
{
    public class ProductFormatDAO
    {
        public static bool CreatePF(ProductFormat pf)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            ngse.ProductFormats.Add(pf);
            if (ngse.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public static List<ProductFormat> GetPF(int idPro)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            List<ProductFormat> list = ngse.ProductFormats.Where(w => w.idPro == idPro).ToList();
            return list;
        }
        public static ProductFormatView SelectPFByID(int idPF)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var ls = ngse.ProductFormats.Where(w => w.idPF == idPF).Select(s => new ProductFormatView { idPF = s.idPF, idPro = s.idPro, namePro = s.Product.namePro, price = s.price??0, size = s.size, colorCSS = s.colorCSS, colorName = s.colorName }).SingleOrDefault();
            return ls;
        }
        public static bool UpdatePF(ProductFormat pf)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            ProductFormat q = ngse.ProductFormats.SingleOrDefault(w => w.idPF == pf.idPF);
            q.price = pf.price;
            q.size = pf.size;
            q.colorCSS = pf.colorCSS;
            q.colorName = pf.colorName;
            if (ngse.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public static bool DelPF(int idPF)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            ProductFormat id = ngse.ProductFormats.SingleOrDefault(s => s.idPF == idPF);
            ngse.ProductFormats.Remove(id);
            if (ngse.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public static int GetPriceDisplay(int idPro)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            int? price = ngse.ProductFormats.Where(w => w.idPro == idPro).Min(m => m.price);
            return price ?? 0;
        }
        public static List<ProductFormat> DistinctColor(int idPro)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            List<ProductFormat> ls = ngse.ProductFormats.Where(w => w.idPro == idPro).GroupBy(g => g.colorCSS).Select(s => s.FirstOrDefault()).ToList();
            return ls;
        }
        public static List<ProductFormat> DistinctSize(int idPro)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            List<ProductFormat> ls = ngse.ProductFormats.Where(w => w.idPro == idPro).GroupBy(g => g.size).Select(s => s.FirstOrDefault()).ToList();
            return ls;
        }
        public static List<ProductFormatView> SelectSizeByColor(string color, int idPro)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            List<ProductFormatView> ls = ngse.ProductFormats.Where(w => w.colorCSS == color && w.idPro == idPro).Select(d => new ProductFormatView { idPF = d.idPF, idPro = d.idPro, colorCSS = d.colorCSS, colorName = d.colorName, namePro = d.Product.namePro, price = d.price ?? 0, size = d.size }).ToList();
            return ls;
        }
        public static int SelectPriceBySize(string size, int idPF)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var q = ngse.ProductFormats.Where(w => w.size == size && w.idPF == idPF).SingleOrDefault();
            return q.price??0;
        }
    }
}