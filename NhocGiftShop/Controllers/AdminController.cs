using NhocGiftShop.Models;
using NhocGiftShop.Models.EntitiesModel;
using NhocGiftShop.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NhocGiftShop.Controllers
{
    public class AdminController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object o = filterContext.HttpContext.Session["UserID"];
            //var actionName = filterContext.RouteData.Values["action"];
            //var ControllerName = filterContext.RouteData.Values["controller"];
            if (o == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "Client" }, { "Action", "LayoutSignIn" } });
            }

        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        #region Category
        public ActionResult Category()
        {
            return View();
        }
        public ActionResult ListCategory()
        {
            return View();
        }
        public ActionResult CreateCate(Category c)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var checkName = ngse.Categories.SingleOrDefault(s => s.nameCate == c.nameCate);
            if (checkName != null)
            {
                TempData["rs"] = 0;
            }
            else if (string.IsNullOrWhiteSpace(c.nameCate))
            {
                TempData["rs"] = 2;
            }
            else if (Repositories.CreateCate(c) == true)
            {
                return RedirectToAction("ListCategory");
            }
            return RedirectToAction("Category");
        }
        public ActionResult EditCategory(int idCate)
        {
            var selectedCate = Repositories.SelectCateByID(idCate);
            var cate = new Category { idCate = selectedCate.idCate, nameCate = selectedCate.nameCate, specialCate = selectedCate.specialCate };
            TempData["c"] = cate;
            return View();
        }
        public ActionResult UpdateCate(Category c)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var checkName = ngse.Categories.SingleOrDefault(s => s.nameCate == c.nameCate && s.idCate != c.idCate);
            if (checkName != null)
            {
                TempData["rs"] = 0;
                return RedirectToAction("EditCategory", new { idCate = c.idCate });
            }
            else if (string.IsNullOrWhiteSpace(c.nameCate))
            {
                TempData["rs"] = 2;
                return RedirectToAction("EditCategory", new { idCate = c.idCate });
            }
            else if (Repositories.UpdateCate(c) == true)
            {
                return RedirectToAction("ListCategory");
            }
            return RedirectToAction("ListCategory");
        }
        public ActionResult DelCate(int idCate)
        {
            if (Repositories.DelCate(idCate) == true)
            {
                TempData["rs"] = 1;
            }
            else
            {
                TempData["rs"] = 0;
            }
            return RedirectToAction("ListCategory");
        }
        #endregion
        #region SubCategory
        public ActionResult SubCategory()
        {
            return View();
        }
        public ActionResult CreateSubCate(SubCategory sc)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var checkName = ngse.SubCategories.SingleOrDefault(s => s.nameSC == sc.nameSC);
            if (checkName != null)
            {
                TempData["rs"] = 0;
            }
            else if (string.IsNullOrWhiteSpace(sc.nameSC))
            {
                TempData["rs"] = 2;
            }
            else if (Repositories.CreateSubCate(sc) == true)
            {
                return RedirectToAction("ListSubCategory");
            }
            return RedirectToAction("SubCategory");
        }
        public ActionResult ListSubCategory()
        {
            return View();
        }
        public ActionResult EditSubCategory(int idSC)
        {
            var selectedSC = Repositories.SelectSubCateByID(idSC);
            var sc = new SubCategoryView { idSC = selectedSC.idSC, nameSC = selectedSC.nameSC, idCate = selectedSC.idCate, nameCate = selectedSC.nameCate };
            TempData["sc"] = sc;
            return View();
        }
        public ActionResult UpdateSubCate(SubCategory sc)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var checkName = ngse.SubCategories.SingleOrDefault(s => s.nameSC == sc.nameSC && s.idSC != sc.idSC);
            if (checkName != null)
            {
                TempData["rs"] = 0;
                return RedirectToAction("EditSubCategory", new { idSC = sc.idSC });
            }
            else if (string.IsNullOrWhiteSpace(sc.nameSC))
            {
                TempData["rs"] = 2;
                return RedirectToAction("EditSubCategory", new { idSC = sc.idSC });
            }
            else if (Repositories.UpdateSubCate(sc) == true)
            {
                return RedirectToAction("ListSubCategory");
            }
            return RedirectToAction("ListSubCategory");
        }
        public ActionResult DelSubCate(int idSC)
        {
            if (Repositories.DelSubCate(idSC) == true)
            {
                TempData["rs"] = 1;
            }
            else
            {
                TempData["rs"] = 0;
            }
            return RedirectToAction("ListSubCategory");
        }
        #endregion
        #region Product
        public ActionResult Product()
        {
            return View();
        }
        public ActionResult ListProduct()
        {
            return View();
        }
        public ActionResult CreateProduct(Product p)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var checkName = ngse.Products.SingleOrDefault(s => s.namePro == p.namePro);
            if (checkName != null)
            {
                TempData["rs"] = 0;
            }
            else if (string.IsNullOrWhiteSpace(p.namePro))
            {
                TempData["rs"] = 2;
            }
            else if (Repositories.CreateProduct(p) == true)
            {
                return RedirectToAction("ListProduct");
            }
            return RedirectToAction("Product");
        }
        public ActionResult EditProduct(int idPro)
        {
            var selectedPro = Repositories.SelectProductByID(idPro);
            var pro = new ProductView { idPro = selectedPro.idPro, idSC = selectedPro.idSC, namePro = selectedPro.namePro, material = selectedPro.material, description = selectedPro.description, nameSC = selectedPro.nameSC };
            TempData["p"] = pro;
            return View();
        }
        public ActionResult UpdatePro(Product p)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var checkName = ngse.Products.SingleOrDefault(s => s.namePro == p.namePro && s.idPro != p.idPro);
            if (checkName != null)
            {
                TempData["rs"] = 0;
                return RedirectToAction("EditProduct", new { idPro = p.idPro });
            }
            else if (string.IsNullOrWhiteSpace(p.namePro))
            {
                TempData["rs"] = 2;
                return RedirectToAction("EditProduct", new { idPro = p.idPro });
            }
            else if (Repositories.UpdateProduct(p) == true)
            {
                return RedirectToAction("ListProduct");
            }
            return RedirectToAction("ListProduct");
        }
        public ActionResult DelPro(int idPro)
        {
            if (Repositories.DelPro(idPro) == true)
            {
                TempData["rs"] = 1;
            }
            else
            {
                TempData["rs"] = 0;
            }
            return RedirectToAction("ListProduct");
        }
        #endregion
        #region ProductFormat
        public ActionResult ProductFormat(int idPro)
        {
            var selectedPro = Repositories.SelectProductByID(idPro);
            var pro = new ProductView { idPro = selectedPro.idPro, namePro = selectedPro.namePro };
            TempData["p"] = pro;
            return View();
        }
        public ActionResult ListPF(int idPro)
        {
            var selectedPro = Repositories.SelectProductByID(idPro);
            var pro = new ProductView { idPro = selectedPro.idPro, namePro = selectedPro.namePro };
            TempData["p"] = pro;
            return View();
        }
        public ActionResult CreatePF(ProductFormat pf)
        {
            if (Repositories.CreatePF(pf) == true)
            {
                return RedirectToAction("ListPF", new { idPro = pf.idPro });
            }
            return RedirectToAction("ProductFormat", new { idPro = pf.idPro });
        }
        public ActionResult EditPF(int idPF)
        {
            var selectedPF = Repositories.SelectPFByID(idPF);
            var pf = new ProductFormatView { idPF = selectedPF.idPF, idPro = selectedPF.idPro, namePro = selectedPF.namePro, price = selectedPF.price, size = selectedPF.size,colorCSS=selectedPF.colorCSS,colorName=selectedPF.colorName };
            TempData["pf"] = pf;
            return View();
        }
        public ActionResult UpdatePF(ProductFormat pf)
        {
            if (Repositories.UpdatePF(pf) == true)
            {
                return RedirectToAction("ListPF", new { idPro = pf.idPro });
            }
            return RedirectToAction("EditPF", new { idPF = pf.idPF });
        }
        public ActionResult DelPF(int idPF, int idProduct)
        {
            if (Repositories.DelPF(idPF) == true)
            {
                TempData["rs"] = 1;
            }
            else
            {
                TempData["rs"] = 0;
            }
            return RedirectToAction("ListPF", new { idPro = idProduct });
        }
        #endregion
        #region ProductImage
        public ActionResult ProductImage(int idPro)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var selectedPro = Repositories.SelectProductByID(idPro);
            var pro = new ProductView { idPro = selectedPro.idPro, namePro = selectedPro.namePro };
            TempData["p"] = pro;
            return View();
        }
        public ActionResult ListPI(int idPro)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var selectedPro = Repositories.SelectProductByID(idPro);
            var pro = new ProductView { idPro = selectedPro.idPro, namePro = selectedPro.namePro };
            TempData["p"] = pro;
            return View();
        }
        public ActionResult CreatePI(HttpPostedFileBase imgPro,ProductImage pi)
        {
            if (imgPro==null)
            {
                TempData["rs"] = 0;
            }
            else
            {
                string FileName = DateTime.Now.Ticks + Path.GetFileName(imgPro.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/Images"), FileName);
                imgPro.SaveAs(path);
                pi.imgPro = FileName;
                if (Repositories.CreatePI(pi)==true)
                {
                    return RedirectToAction("ListPI", new { idPro = pi.idPro });
                }
            }
            return RedirectToAction("ProductImage", new { idPro = pi.idPro });
        }
        public ActionResult DelImgPro(int idPI,int idPro)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var selectedPI = ngse.ProductImages.Where(w => w.idPI == idPI).ToList().SingleOrDefault();
            string path = Server.MapPath("~/Content/Images/");
            if (System.IO.File.Exists(Path.Combine(path, selectedPI.imgPro)))
            {
                System.IO.File.Delete(Path.Combine(path, selectedPI.imgPro));
                if (Repositories.DelImgPro(idPI)==true)
                {
                    TempData["rs"] = 1;
                }
                else
                {
                    TempData["rs"] = 0;
                }
            }
            else
            {
                TempData["rs"] = 0;
            }
            return RedirectToAction("ListPI", new { idPro = idPro });
        }
        #endregion
        #region Information Person
        public ActionResult MemberList()
        {
            return View();
        }
        public ActionResult GuestList()
        {
            return View();
        }
        #endregion
        #region Order Product
        public ActionResult OrderProduct()
        {
            return View();
        }
        public ActionResult OrdDetail(int idOP)
        {
            var selectedOP = Repositories.SelectOPByID(idOP);
            OrderProView op = new OrderProView { idIP=selectedOP.idIP,idOP=selectedOP.idOP,total=selectedOP.total,nameIP=selectedOP.nameIP};
            TempData["op"] = op;
            return View();
        }
        #endregion
        #region Log out
        public ActionResult Logout()
        {
            Session.Remove("UserID");
            Session.Remove("UserName");
            return RedirectToAction("Index", "CLient");
        }
        #endregion
    }
}