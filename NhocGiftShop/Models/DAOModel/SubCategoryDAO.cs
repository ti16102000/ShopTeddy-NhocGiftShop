using NhocGiftShop.Models.EntitiesModel;
using NhocGiftShop.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhocGiftShop.Models.DAOModel
{
    public class SubCategoryDAO
    {
        public static bool CreateSubCate(SubCategory sc)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            ngse.SubCategories.Add(sc);
            if (ngse.SaveChanges()>0)
            {
                return true;
            }
            return false;
        }
        public static List<Category> EditCbbCate(int idCate)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var list = ngse.Categories.Where(w => w.idCate != idCate).ToList();
            return list;
        }
        public static List<ViewModel.SubCategoryView> GetAllSubCate()
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var list = ngse.SubCategories.Select(s => new ViewModel.SubCategoryView { idSC = s.idSC, nameSC = s.nameSC, idCate = s.idCate, nameCate = s.Category.nameCate }).ToList();
            return list;
        }
        public static SubCategoryView SelectSubCateByID(int idSC)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var list = ngse.SubCategories.Where(w=>w.idSC==idSC).Select(s => new ViewModel.SubCategoryView { idSC = s.idSC, nameSC = s.nameSC, idCate = s.idCate, nameCate = s.Category.nameCate }).ToList().SingleOrDefault();
            return list;
        }
        public static bool UpdateSubCate(SubCategory sc)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var q = ngse.SubCategories.SingleOrDefault(s=>s.idSC==sc.idSC);
            q.nameSC = sc.nameSC;
            q.idCate = sc.idCate;
            if (ngse.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public static bool DelSubCate(int idSC)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var id = ngse.SubCategories.SingleOrDefault(s => s.idSC == idSC);
            ngse.SubCategories.Remove(id);
            var pro = ngse.Products.SingleOrDefault(s => s.idSC == idSC);
            if (pro != null)
            {
                return false;
            }
            else if (ngse.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}