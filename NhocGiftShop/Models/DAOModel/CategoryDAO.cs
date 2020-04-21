using NhocGiftShop.Models.EntitiesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhocGiftShop.Models.DAOModel
{
    public class CategoryDAO
    {
        public static bool CreateCate(Category c)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            ngse.Categories.Add(c);
            if (ngse.SaveChanges()>0)
            {
                return true;
            }
            return false;
        }
        public static List<Category> GetAllCate()
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var list = ngse.Categories.ToList();
            return list;
        }
        public static Category SelectCateByID(int idCate)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var list = ngse.Categories.Where(w=>w.idCate==idCate).ToList().SingleOrDefault();
            return list;
        }
        public static bool UpdateCate(Category c)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var q = ngse.Categories.Where(w => w.idCate == c.idCate).SingleOrDefault();
            q.nameCate = c.nameCate;
            q.specialCate = c.specialCate;
            if (ngse.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public static bool DelCate(int idCate)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var item = ngse.Categories.Where(w => w.idCate == idCate).SingleOrDefault();
            ngse.Categories.Remove(item);
            var sc = ngse.SubCategories.SingleOrDefault(s=>s.idCate==idCate);
            if (sc!=null)
            {
                return false;
            }
            if (ngse.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public static List<Category> GetCateHot()
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var list = ngse.Categories.Where(w => w.specialCate == true).ToList();
            return list;
        }
        public static List<SubCategory> GetSubCateByIDCate(int id)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var list = ngse.SubCategories.Where(w => w.idCate == id).ToList();
            return list;
        }
        public static List<Category> GetCateNormal()
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var list = ngse.Categories.Where(w => w.specialCate ==false).ToList();
            return list;
        }

    }
}