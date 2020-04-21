using NhocGiftShop.Models.DAOModel;
using NhocGiftShop.Models.EntitiesModel;
using NhocGiftShop.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhocGiftShop.Models.BusinessModel
{
    public class SubCategoryBUS
    {
        public static bool CreateSubCate(SubCategory sc)
        {
            if (SubCategoryDAO.CreateSubCate(sc)==true)
            {
                return true;
            }
            return false;
        }
        public static List<ViewModel.SubCategoryView> GetAllSubCate()
        {
            var list = SubCategoryDAO.GetAllSubCate();
            return list;
        }
        public static List<Category> EditCbbCate(int idCate)
        {
            var list = SubCategoryDAO.EditCbbCate(idCate);
            return list;
        }
        public static SubCategoryView SelectSubCateByID(int idSC)
        {
            var list = SubCategoryDAO.SelectSubCateByID(idSC);
            return list;
        }
        public static bool UpdateSubCate(SubCategory sc)
        {
            if (SubCategoryDAO.UpdateSubCate(sc) == true)
            {
                return true;
            }
            return false;
        }
        public static bool DelSubCate(int idSC)
        {
            if (SubCategoryDAO.DelSubCate(idSC)==true)
            {
                return true;
            }
            return false;
        }
    }
}