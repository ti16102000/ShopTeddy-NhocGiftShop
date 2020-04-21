using NhocGiftShop.Models.EntitiesModel;
using NhocGiftShop.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhocGiftShop.Models.DAOModel
{
    public class OrderProductDAO
    {
        public static int CreateOrd(OrderProduct op)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            ngse.OrderProducts.Add(op);
            ngse.SaveChanges();
            return op.idOP;
        }
        public static List<OrderProView> GetOP()
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var ls = ngse.OrderProducts.Select(s => new OrderProView { idIP = s.idIP, idOP = s.idOP, nameIP = s.InformationPerson.nameIP, total = s.total }).ToList();
            return ls;
        }
        public static OrderProView SelectOPByID(int idOP)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var op = ngse.OrderProducts.Where(s => s.idOP == idOP).Select(s => new OrderProView { idIP = s.idIP, idOP = s.idOP, nameIP = s.InformationPerson.nameIP, total = s.total }).SingleOrDefault();
            return op;
        }
        public static List<OrderProduct> GetOPByID(int idIP)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var ls = ngse.OrderProducts.Where(w => w.idIP == idIP).ToList();
            return ls;
        }
    }
}