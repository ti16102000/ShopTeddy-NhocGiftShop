using NhocGiftShop.Models.EntitiesModel;
using NhocGiftShop.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhocGiftShop.Models.DAOModel
{
    public class OrderDetailDAO
    {
        public static bool CreateOD(OrderDetail od)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            ngse.OrderDetails.Add(od);
            if (ngse.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public static List<OrdDetailView> GetOD(int idOP)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var ls = ngse.OrderDetails.Where(w => w.idOP == idOP).Select(s => new OrdDetailView
            {
                idOD = s.idOD,
                idOP = s.idOP,
                amount = s.amount,
                idPF = s.idPF,
                colorName = s.ProductFormat.colorName,
                namePro = s.ProductFormat.Product.namePro,
                priceOD = s.priceOD,
                quantity = s.quantity,
                size = s.ProductFormat.size
            }).ToList();
            return ls;
        }
    }
}