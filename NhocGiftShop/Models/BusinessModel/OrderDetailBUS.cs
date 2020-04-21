using NhocGiftShop.Models.DAOModel;
using NhocGiftShop.Models.EntitiesModel;
using NhocGiftShop.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhocGiftShop.Models.BusinessModel
{
    public class OrderDetailBUS
    {
        public static bool CreateOD(OrderDetail od)
        {
            if (OrderDetailDAO.CreateOD(od) == true)
            {
                return true;
            }
            return false;
        }
        public static List<OrdDetailView> GetOD(int idOP)
        {
            var ls = OrderDetailDAO.GetOD(idOP);
            return ls;
        }

    }
}