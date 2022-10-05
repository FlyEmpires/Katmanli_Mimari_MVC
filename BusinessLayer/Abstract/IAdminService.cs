using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IAdminService
    {
        List<Admin> GetList();

        void AdminLogin(Admin admin);
        //void AdminLoginHata(Admin admin);
        Admin GetByID(int id);

    }
}
