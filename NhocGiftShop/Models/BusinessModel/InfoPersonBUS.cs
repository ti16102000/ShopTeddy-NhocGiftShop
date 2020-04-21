using NhocGiftShop.Models.DAOModel;
using NhocGiftShop.Models.EntitiesModel;
using NhocGiftShop.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhocGiftShop.Models.BusinessModel
{
    public class InfoPersonBUS
    {
        public static bool CheckAD(InformationPerson ip)
        {            
            if (InfoPersonDAO.CheckAD(ip)==true)
            {
                return true;
            }
            return false;
        }
        public static int CreateIP(InformationPerson ip)
        {
            return InfoPersonDAO.CreateIP(ip);
        }
        public static bool CheckMember(InformationPerson ip)
        {
            if (InfoPersonDAO.CheckMember(ip) == true)
            {
                return true;
            }
            return false;
        }
        public static List<InfoPersonView> GetMember()
        {
            var ls = InfoPersonDAO.GetMember();
            return ls;
        }
        public static List<InfoPersonView> GetGuest()
        {
            var ls = InfoPersonDAO.GetGuest();
            return ls;
        }
        public static InfoPersonView GetPersonByID(int idIP)
        {
            var ls = InfoPersonDAO.GetPersonByID(idIP);
            return ls;
        }
        public static InformationPerson EditPersonByIP(int idIP)
        {
            var person = InfoPersonDAO.EditPersonByIP(idIP);
            return person;
        }
        public static bool UpdatePerson(InformationPerson ip)
        {
            if (InfoPersonDAO.UpdatePerson(ip)==true)
            {
                return true;
            }
            return false;
        }
        public static bool ChangePwd(string pwdNew, int idIP)
        {
            if (InfoPersonDAO.ChangePwd(pwdNew,idIP)==true)
            {
                return true;
            }
            return false;
        }
    }
}