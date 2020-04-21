using NhocGiftShop.Models;
using NhocGiftShop.Models.EntitiesModel;
using NhocGiftShop.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace NhocGiftShop.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }
        #region Sign In
        public ActionResult LayoutSignIn()
        {
            return View();
        }
        public ActionResult CheckPerson(InformationPerson ip)
        {
            if (Repositories.CheckAD(ip) == true)
            {
                NhocGiftShopEntities ngse = new NhocGiftShopEntities();
                InformationPerson ad = ngse.InformationPersons.Where(w => w.phone == ip.phone && w.pwd == ip.pwd && w.idR == 1).SingleOrDefault();
                if (ad != null)
                {
                    Session["UserID"] = ad.idIP.ToString();
                    Session["UserName"] = ad.nameIP;
                    return RedirectToAction("Index", "Admin");
                }
            } else if (Repositories.CheckMember(ip) == true)
            {
                NhocGiftShopEntities ngse = new NhocGiftShopEntities();
                InformationPerson mem = ngse.InformationPersons.Where(w => w.phone == ip.phone && w.pwd == ip.pwd && w.idR == 2).SingleOrDefault();
                if (mem != null)
                {
                    Session["MemberID"] = mem.idIP.ToString();
                    Session["MemberName"] = mem.nameIP;
                    Session["MemberPhone"] = mem.phone;
                    return RedirectToAction("Index", "Client");
                }
            }
            return Content("<script language='javascript' type='text/javascript'>alert('Số điện thoại hoặc mật khẩu đăng nhập không đúng!');</script>");
        }
        public ActionResult LogOutMem()
        {
            Session.Remove("MemberID");
            Session.Remove("MemberName");
            Session.Remove("MemberPhone");
            return Redirect(Request.UrlReferrer.ToString());
        }
        #endregion
        #region Sign Up
        public ActionResult LayoutSignUp()
        {
            return View();
        }
        public ActionResult CreateIP(InformationPerson ip)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            InformationPerson phone = ngse.InformationPersons.SingleOrDefault(s => s.phone == ip.phone && s.idR == 2);
            ip.idR = 2;
            if (phone != null)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Phone has been signed up!');</script>");
            }
            else if (DateTime.Now.Year - ip.DOB.Value.Year < 15)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Date of Birth invalid!');</script>");
            }
            else if (Repositories.CreateIP(ip) > 0)
            {
                InformationPerson member = ngse.InformationPersons.SingleOrDefault(s => s.phone == ip.phone);
                Session["MemberID"] = member.idIP;
                Session["MemberName"] = member.nameIP;
                Session["MemberPhone"] = member.phone;
                return RedirectToAction("Index");
            }

            return RedirectToAction("LayoutSignUp");
        }
        #endregion
        #region Product
        public ActionResult LayoutProduct(int idSC)
        {
            SubCategoryView selectedSC = Repositories.SelectSubCateByID(idSC);
            SubCategoryView sc = new SubCategoryView { idSC = selectedSC.idSC, nameSC = selectedSC.nameSC, idCate = selectedSC.idCate, nameCate = selectedSC.nameCate };
            TempData["sc"] = sc;
            return View();
        }
        #endregion
        #region Product Detail
        public ActionResult LayoutProductDetail(int idPro)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            Product selectedPro = ngse.Products.SingleOrDefault(s => s.idPro == idPro);
            TempData["pro"] = selectedPro;
            List<ProductFormat> color = Repositories.DistinctColor(idPro);
            TempData["color"] = color;
            ViewBag.ImgMain = Repositories.GetImgMainByIDPro(idPro);
            ViewBag.PriceDisplay = Repositories.GetPriceDisplay(idPro);
            TempData["size"] = Repositories.DistinctSize(idPro);
            return View();
        }

        public JsonResult SelectSizeByColor(string color, int idPro)
        {
            List<ProductFormatView> sizes = Repositories.SelectSizeByColor(color, idPro);
            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(sizes), JsonRequestBehavior.AllowGet);
        }
        public JsonResult SelectPriceBySize(string size, int idPF)
        {
            int price = Repositories.SelectPriceBySize(size, idPF);
            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(price), JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region Cart
        public ActionResult LayoutCart()
        {
            List<CartView> ls = new List<CartView>();
            ls = Session["cart"] as List<CartView>;
            if (Session["cart"] != null)
            {
                var total = ls.Sum(s => s.amount);
                Session["total"] = total;
                Session["count"] = ls.Sum(s => s.quantity);
            }

            return View();
        }
        public JsonResult AddToCart(CartView cv)
        {
            Debug.WriteLine("huhu");
            List<CartView> ls = new List<CartView>();
            if (Session["cart"] != null)
            {
                ls = Session["cart"] as List<CartView>;
                CartView newPro = ls.SingleOrDefault(w => w.idPF == cv.idPF);
                if (newPro != null)
                {
                    newPro.quantity = newPro.quantity + cv.quantity;
                    newPro.amount = newPro.amount + (cv.quantity * cv.price);
                }
                else
                {
                    cv.amount = cv.price * cv.quantity;
                    ls.Add(cv);
                }
                Session["cart"] = ls;
            }
            else
            {
                cv.amount = cv.price * cv.quantity;
                ls.Add(cv);
                Session["cart"] = ls;
            }
            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(Session["cart"]), JsonRequestBehavior.AllowGet);
        }
        public ActionResult RemovePro(int idPF)
        {
            List<CartView> ls = new List<CartView>();
            ls = Session["cart"] as List<CartView>;
            if (Session["cart"] != null)
            {
                var id = ls.SingleOrDefault(s => s.idPF == idPF);
                ls.Remove(id);
            }
            return RedirectToAction("LayoutCart");
        }
        public ActionResult CreateOrd(InformationPerson ip)
        {
            List<CartView> ls = new List<CartView>();
            ls = Session["cart"] as List<CartView>;
            if (ls == null)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Bạn chưa có sản phẩm nào để đặt!');</script>");
            }
            if ((string)Session["MemberName"] != ip.nameIP || (string)Session["MemberPhone"] != ip.phone)
            {
                ip.idR = 3;
                int idIP = Repositories.CreateIP(ip);
                if (idIP > 0)
                {
                    OrderProduct op = new OrderProduct();
                    op.idIP = idIP;
                    op.total = Convert.ToInt32(Session["total"].ToString());
                    int idOPro = Repositories.CreateOrd(op);
                    if (idOPro > 0)
                    {

                        foreach (var item in ls)
                        {
                            OrderDetail od = new OrderDetail();
                            od.idPF = item.idPF;
                            od.idOP = idOPro;
                            od.priceOD = item.price;
                            od.quantity = item.quantity;
                            od.amount = item.amount;
                            Repositories.CreateOD(od);
                        }
                    }
                }
            }
            else
            {
                OrderProduct op = new OrderProduct();
                op.idIP = Convert.ToInt32(Session["MemberID"].ToString());
                op.total = Convert.ToInt32(Session["total"].ToString());
                int idOPro = Repositories.CreateOrd(op);
                if (idOPro > 0)
                {
                    foreach (var item in ls)
                    {
                        OrderDetail od = new OrderDetail();
                        od.idPF = item.idPF;
                        od.idOP = idOPro;
                        od.priceOD = item.price;
                        od.quantity = item.quantity;
                        od.amount = item.amount;
                        Repositories.CreateOD(od);
                    }
                }
            }
            Session.Remove("cart");
            Session.Remove("count");
            Session.Remove("total");
            return Content("<script language='javascript' type='text/javascript'>alert('Đặt hàng thành công!');</script>");
        }

        #endregion
        #region Info Person
        public ActionResult LayoutInfoPerson()
        {
            var id = Convert.ToInt32(Session["MemberID"]);
            var selectPerson = Repositories.GetPersonByID(id);
            var person = new InfoPersonView { idIP = selectPerson.idIP, address = selectPerson.address, DOB = selectPerson.DOB, email = selectPerson.email, gender = selectPerson.gender, idR = selectPerson.idR, nameIP = selectPerson.nameIP, phone = selectPerson.phone, pwd = selectPerson.pwd };
            TempData["person"] = person;
            TempData["op"] = Repositories.GetOPByID(id);
            return View();
        }
        public ActionResult EditPerson()
        {
            var id = Convert.ToInt32(Session["MemberID"]);
            var selectPerson = Repositories.EditPersonByIP(id);
            var person = new InformationPerson { idIP = selectPerson.idIP, address = selectPerson.address, DOB = selectPerson.DOB, email = selectPerson.email, gender = selectPerson.gender, idR = selectPerson.idR, nameIP = selectPerson.nameIP, phone = selectPerson.phone, pwd = selectPerson.pwd };
            TempData["person"] = person;
            return View();
        }
        public ActionResult UpdatePerson(InformationPerson ip)
        {
            var id = Convert.ToInt32(Session["MemberID"]);
            ip.idIP = id;
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            InformationPerson phone = ngse.InformationPersons.SingleOrDefault(s => s.phone == ip.phone && s.idR == 2 && s.idIP != id);
            if (phone != null)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Phone has been signed up!');</script>");
            }
            else if (DateTime.Now.Year - ip.DOB.Value.Year < 15)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Date of Birth invalid!');</script>");
            }
            else if (Repositories.UpdatePerson(ip) == true)
            {
                return RedirectToAction("LayoutInfoPerson");
            }
            return View();
        }
        public ActionResult ChangePwd(string pwdOld, string pwdNew)
        {
            var id = Convert.ToInt32(Session["MemberID"]);
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            InformationPerson pwd = ngse.InformationPersons.SingleOrDefault(s => s.pwd == pwdOld && s.idR == 2 && s.idIP == id);
            if (pwd == null)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Password incorrect!');</script>");
            }
            else if (Repositories.ChangePwd(pwdNew, id) == true)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Cập nhật mật khẩu thành công!');</script>");
            }
            return Content("<script language='javascript' type='text/javascript'>alert('Cập nhật mật khẩu không thành công');</script>");
        }
        public ActionResult LayoutGetPwd()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult GetEmail(string email)
        //{

        //}
        #endregion

    
    }
}