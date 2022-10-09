using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace BusinessLayer.Concrete
{
    
    public class AdminManager : IAdminService
    {
        
        IAdminDal _adminDal;
        
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminLogin(Admin admin)
        {
            _adminDal.List(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword).FirstOrDefault();

        }

        public Admin AdminLoginHata(string AdminUserName,string AdminPassword)
        {
            return _adminDal.Get(x => x.AdminUserName == AdminUserName && x.AdminPassword == AdminPassword);
            
            //_adminDal.List(x=>x.AdminUserName!=admin.AdminUserName && x.AdminPassword!=admin.AdminPassword).FirstOrDefault();
          
        }
        public Admin AdminHata(string AdminUserName, string AdminPassword)
        {

            var a = _adminDal.Get(x => x.AdminUserName != AdminUserName && x.AdminPassword != AdminPassword);
            //var b = _adminDal.Get(x => x.AdminUserName != AdminUserName);
            //if (b!=null)
            //{
            //    return b;
            //}
            //else
            return a;
        }
        //public Admin AdminGiris(string AdminUserName, string AdminPassword)
        //{
        //    try
        //    {
        //        var giris = _adminDal.Get(AdminUserName, AdminPassword);
        //        if (giris==null)
        //        {
        //            throw new Exception("Kullanıcı Veya Parola Uyuşmuyor");
        //        }
        //        else
        //        {
        //            return giris;
        //        }

        //    }
        //    catch (Exception errors)
        //    {

        //        throw new Exception("Giriş hata:"+errors.Message);

        //    }


        //}

        public Admin GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetList()
        {
            throw new NotImplementedException();
        }

       
    }
}
