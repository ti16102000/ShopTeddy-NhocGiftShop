using NhocGiftShop.Models.DAOModel;
using NhocGiftShop.Models.EntitiesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhocGiftShop.Models.BusinessModel
{
    public class CategoryBUS
    {
        public static bool CreateCate(Category c)
        {
            if (CategoryDAO.CreateCate(c)==true)
            {
                return true;
            }
            return false;
        }
        public static List<Category> GetAllCate()
        {
            List<Category> list = CategoryDAO.GetAllCate();
            return list;
        }
        public static Category SelectCateByID(int idCate)
        {
            var list = CategoryDAO.SelectCateByID(idCate);
            return list;
        }
        public static bool UpdateCate(Category c)
        {
            if (CategoryDAO.UpdateCate(c) == true)
            {
                return true;
            }
            return false;
        }
        public static bool DelCate(int idCate)
        {
            if (CategoryDAO.DelCate(idCate) == true)
            {
                return true;
            }
            return false;
        }
        public static List<Category> GetCateHot()
        {
            var list = CategoryDAO.GetCateHot();
            return list;
        }
        public static List<Category> GetCateNormal()
        {
            var list = CategoryDAO.GetCateNormal();
            return list;
        }
        public static List<SubCategory> GetSubCateByIDCate(int id)
        {
            var list = CategoryDAO.GetSubCateByIDCate(id);
            return list;
        }
    }
}