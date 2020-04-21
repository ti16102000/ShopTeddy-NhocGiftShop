using NhocGiftShop.Models.EntitiesModel;
using NhocGiftShop.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhocGiftShop.Models.DAOModel
{
    public class InfoPersonDAO
    {
        public static bool CheckAD(InformationPerson ip)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var check = ngse.InformationPersons.Where(w=>w.phone==ip.phone && w.pwd==ip.pwd && w.idR==1).SingleOrDefault();
            if (check!=null)
            {
                return true;
            }
            return false;
        }
        public static int CreateIP(InformationPerson ip)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            ngse.InformationPersons.Add(ip);
            ngse.SaveChanges();
            return ip.idIP;
        }
        public static bool CheckMember(InformationPerson ip)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var check = ngse.InformationPersons.Where(w => w.phone == ip.phone && w.pwd == ip.pwd && w.idR == 2).SingleOrDefault();
            if (check != null)
            {
                return true;
            }
            return false;
        }
        public static List<InfoPersonView> GetMember()
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var ls = ngse.InformationPersons.Where(w => w.idR == 2).Select(s => new InfoPersonView {
                idIP = s.idIP,
                idR = s.idR,
                address=s.address,
                DOB=s.DOB!=null? (s.DOB.Value.Day+"/"+s.DOB.Value.Month+"/"+s.DOB.Value.Year):null,
                email=s.email,
                gender=s.gender,
                nameIP=s.nameIP,
                phone=s.phone,
                pwd=s.pwd
            }).ToList();
            return ls;
        }
        public static List<InfoPersonView> GetGuest()
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var ls = ngse.InformationPersons.Where(w => w.idR == 3).Select(s => new InfoPersonView
            {
                idIP = s.idIP,
                idR = s.idR,
                address = s.address,
                DOB = s.DOB != null ? (s.DOB.Value.Day + "/" + s.DOB.Value.Month + "/" + s.DOB.Value.Year) : null,
                email = s.email,
                gender = s.gender,
                nameIP = s.nameIP,
                phone = s.phone,
                pwd = s.pwd
            }).ToList();
            return ls;
        }
        public static InfoPersonView GetPersonByID(int idIP)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var person=ngse.InformationPersons.Where(w=>w.idIP==idIP).Select(s => new InfoPersonView
            {
                idIP = s.idIP,
                idR = s.idR,
                address = s.address,
                DOB = s.DOB != null ? (s.DOB.Value.Day + "/" + s.DOB.Value.Month + "/" + s.DOB.Value.Year) : null,
                email = s.email,
                gender = s.gender,
                nameIP = s.nameIP,
                phone = s.phone,
                pwd = s.pwd
            }).SingleOrDefault();
            return person;
        }
        public static InformationPerson EditPersonByIP(int idIP)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var person = ngse.InformationPersons.Where(w => w.idIP == idIP).SingleOrDefault();
            return person;
        }
        public static bool UpdatePerson(InformationPerson ip)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var q = ngse.InformationPersons.SingleOrDefault(w => w.idIP == ip.idIP);
            q.nameIP = ip.nameIP;
            q.phone = ip.phone;
            q.gender = ip.gender;
            q.address = ip.address;
            q.DOB = ip.DOB;
            q.email = ip.email;
            if (ngse.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public static bool ChangePwd(string pwdNew, int idIP)
        {
            NhocGiftShopEntities ngse = new NhocGiftShopEntities();
            var q = ngse.InformationPersons.SingleOrDefault(s => s.idIP == idIP);
            q.pwd = pwdNew;
            if (ngse.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}