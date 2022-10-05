using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IAdminRoleService
    {
        List<Admin> GetList();
        void AdminRoleAdd(Admin admin);

        Admin GetByID(int id);
        void AdminRoleDelete(Admin admin);
        void AdminRoleUpdate(Admin admin);
    }
}
