using NhocGiftShop.Models.DAOModel;
using NhocGiftShop.Models.EntitiesModel;
using NhocGiftShop.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhocGiftShop.Models.BusinessModel
{
    public class OrderProductBUS
    {
        public static int CreateOrd(OrderProduct op)
        {
            return OrderProductDAO.CreateOrd(op);
        }
        public static List<OrderProView> GetOP()
        {
            var ls = OrderProductDAO.GetOP();
            return ls;
        }
        public static OrderProView SelectOPByID(int idOP)
        {
            var op = OrderProductDAO.SelectOPByID(idOP);
            return op;
        }
        public static List<OrderProduct> GetOPByID(int idIP)
        {
            var ls = OrderProductDAO.GetOPByID(idIP);
            return ls;
        }
    }
}