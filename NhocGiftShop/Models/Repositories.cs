using NhocGiftShop.Models.BusinessModel;
using NhocGiftShop.Models.EntitiesModel;
using NhocGiftShop.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhocGiftShop.Models
{
    public class Repositories
    {
        #region Admin
        #region Category
        public static bool CreateCate(Category c)
        {
            if (CategoryBUS.CreateCate(c) == true)
            {
                return true;
            }
            return false;
        }
        public static List<Category> GetAllCate()
        {
            List<Category> list = CategoryBUS.GetAllCate();
            return list;
        }
        public static Category SelectCateByID(int idCate)
        {
            var item = CategoryBUS.SelectCateByID(idCate);
            return item;
        }
        public static bool UpdateCate(Category c)
        {
            if (CategoryBUS.UpdateCate(c) == true)
            {
                return true;
            }
            return false;
        }
        public static bool DelCate(int idCate)
        {
            if (CategoryBUS.DelCate(idCate) == true)
            {
                return true;
            }
            return false;
        }
        #endregion
        #region SubCategory
        public static bool CreateSubCate(SubCategory sc)
        {
            if (SubCategoryBUS.CreateSubCate(sc) == true)
            {
                return true;
            }
            return false;
        }
        public static List<Category> EditCbbCate(int idCate)
        {
            var list = SubCategoryBUS.EditCbbCate(idCate);
            return list;
        }
        public static List<SubCategoryView> GetAllSubCate()
        {
            List<SubCategoryView> list = SubCategoryBUS.GetAllSubCate();
            return list;
        }
        public static ViewModel.SubCategoryView SelectSubCateByID(int idSC)
        {
            var list = SubCategoryBUS.SelectSubCateByID(idSC);
            return list;
        }
        public static bool UpdateSubCate(SubCategory sc)
        {
            if (SubCategoryBUS.UpdateSubCate(sc) == true)
            {
                return true;
            }
            return false;
        }
        public static bool DelSubCate(int idSC)
        {
            if (SubCategoryBUS.DelSubCate(idSC) == true)
            {
                return true;
            }
            return false;
        }
        #endregion
        #region Product
        public static bool CreateProduct(Product p)
        {
            if (ProductBUS.CreateProduct(p) == true)
            {
                return true;
            }
            return false;
        }
        public static List<ProductView> GetAllProduct()
        {
            var list = ProductBUS.GetAllProduct();
            return list;
        }
        public static List<SubCategory> EditCbbSubCate(int idSC)
        {
            var list = ProductBUS.EditCbbSubCate(idSC);
            return list;
        }
        public static ProductView SelectProductByID(int idPro)
        {
            var ls = ProductBUS.SelectProductByID(idPro);
            return ls;
        }
        public static bool UpdateProduct(Product p)
        {
            if (ProductBUS.UpdateProduct(p) == true)
            {
                return true;
            }
            return false;
        }
        public static bool DelPro(int idPro)
        {
            if (ProductBUS.DelPro(idPro) == true)
            {
                return true;
            }
            return false;
        }
        #endregion
        #region ProductFormat
        public static bool CreatePF(ProductFormat pf)
        {
            if (ProductFormatBUS.CreatePF(pf) == true)
            {
                return true;
            }
            return false;
        }
        public static List<ProductFormat> GetPF(int idPro)
        {
            var list = ProductFormatBUS.GetPF(idPro);
            return list;
        }
        public static ProductFormatView SelectPFByID(int idPF)
        {
            var ls = ProductFormatBUS.SelectPFByID(idPF);
            return ls;
        }
        public static bool UpdatePF(ProductFormat pf)
        {
            if (ProductFormatBUS.UpdatePF(pf) == true)
            {
                return true;
            }
            return false;
        }
        public static bool DelPF(int idPF)
        {
            if (ProductFormatBUS.DelPF(idPF) == true)
            {
                return true;
            }
            return false;
        }
        #endregion
        #region ProductImage
        public static bool CreatePI(ProductImage pi)
        {
            if (ProductImageBUS.CreatePI(pi) == true)
            {
                return true;
            }
            return false;
        }
        public static List<ProductImageView> GetImagePro(int idPro)
        {
            var pi = ProductImageBUS.GetImagePro(idPro);
            return pi;
        }
        public static bool DelImgPro(int idPI)
        {
            if (ProductImageBUS.DelImgPro(idPI) == true)
            {
                return true;
            }
            return false;
        }
        #endregion
        #region IP
        public static List<InfoPersonView> GetMember()
        {
            var ls = InfoPersonBUS.GetMember();
            return ls;
        }
        public static List<InfoPersonView> GetGuest()
        {
            var ls = InfoPersonBUS.GetGuest();
            return ls;
        }
        public static string CheckSignUp(string phone)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var signUp = ngse.InformationPersons.SingleOrDefault(s => s.phone == phone && s.idR == 2);
            if (signUp != null)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }
        public static bool ChangePwd(string pwdNew, int idIP)
        {
            if (InfoPersonBUS.ChangePwd(pwdNew, idIP) == true)
            {
                return true;
            }
            return false;
        }
        #endregion
        #region Order Product
        public static List<OrderProView> GetOP()
        {
            var ls = OrderProductBUS.GetOP();
            return ls;
        }
        public static List<OrdDetailView> GetOD(int idOP)
        {
            var ls = OrderDetailBUS.GetOD(idOP);
            return ls;
        }
        public static OrderProView SelectOPByID(int idOP)
        {
            var op = OrderProductBUS.SelectOPByID(idOP);
            return op;
        }
        #endregion
        #endregion

        #region Client
        #region Layout Main
        public static List<Category> GetCateHot()
        {
            var list = CategoryBUS.GetCateHot();
            return list;
        }
        public static List<Category> GetCateNormal()
        {
            var list = CategoryBUS.GetCateNormal();
            return list;
        }
        public static List<SubCategory> GetSubCateByIDCate(int id)
        {
            var list = CategoryBUS.GetSubCateByIDCate(id);
            return list;
        }
        #endregion
        #region Sign In
        public static bool CheckAD(InformationPerson ip)
        {
            if (InfoPersonBUS.CheckAD(ip) == true)
            {
                return true;
            }
            return false;
        }
        public static bool CheckMember(InformationPerson ip)
        {
            if (InfoPersonBUS.CheckMember(ip) == true)
            {
                return true;
            }
            return false;
        }
        #endregion
        #region Sign Up
        public static int CreateIP(InformationPerson ip)
        {
            return InfoPersonBUS.CreateIP(ip);
        }
        #endregion
        #region Product
        public static List<Product> GetProductByIDSC(int idSC)
        {
            var ls = ProductBUS.GetProductByIDSC(idSC);
            return ls;
        }
        public static string GetImgMainByIDPro(int idPro)
        {
            var imgName = ProductImageBUS.GetImgMainByIDPro(idPro);
            return imgName;
        }
        public static List<ProductImage> GetImgByIDPro(int idPro)
        {
            var imgPro = ProductImageBUS.GetImgByIDPro(idPro);
            return imgPro;
        }
        public static int GetPriceDisplay(int idPro)
        {
            var price = ProductFormatBUS.GetPriceDisplay(idPro);
            return price;
        }
        public static List<ProductFormat> DistinctColor(int idPro)
        {
            var ls = ProductFormatBUS.DistinctColor(idPro);
            return ls;
        }
        public static List<ProductFormat> DistinctSize(int idPro)
        {
            var ls = ProductFormatBUS.DistinctSize(idPro);
            return ls;
        }
        public static List<ProductFormatView> SelectSizeByColor(string color, int idPro)
        {
            var ls = ProductFormatBUS.SelectSizeByColor(color, idPro);
            return ls;
        }
        public static int SelectPriceBySize(string size, int idPF)
        {
            var ls = ProductFormatBUS.SelectPriceBySize(size, idPF);
            return ls;
        }
        #endregion
        #region Cart
        public static int CreateOrd(OrderProduct op)
        {
            return OrderProductBUS.CreateOrd(op);
        }
        public static bool CreateOD(OrderDetail od)
        {
            if (OrderDetailBUS.CreateOD(od) == true)
            {
                return true;
            }
            return false;
        }
        #endregion
        #region Info Person
        public static InfoPersonView GetPersonByID(int idIP)
        {
            var ls = InfoPersonBUS.GetPersonByID(idIP);
            return ls;
        }
        public static InformationPerson EditPersonByIP(int idIP)
        {
            var person = InfoPersonBUS.EditPersonByIP(idIP);
            return person;
        }
        public static bool UpdatePerson(InformationPerson ip)
        {
            if (InfoPersonBUS.UpdatePerson(ip) == true)
            {
                return true;
            }
            return false;
        }
        public static List<OrderProduct> GetOPByID(int idIP)
        {
            var ls = OrderProductBUS.GetOPByID(idIP);
            return ls;
        }
        #endregion
        #endregion

    }
}