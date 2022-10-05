using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace BusinessLayer.Concrete
{
    public class AdminRoleManager : RoleProvider
    {

        //IAdminRoleDal _adminroledal;
      

        //public AdminRoleManager(IAdminRoleDal adminroledal, string applicationName)
        //{
        //    _adminroledal = adminroledal;
        //    ApplicationName = applicationName;
        //}
        //public AdminRoleManager()
        //{

        //}

        //public AdminRoleManager(IAdminRoleDal adminroledal, string applicationName)
        //{
        //    _adminroledal = adminroledal;
        //    ApplicationName = applicationName;
        //}

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
    
        public override string[] GetRolesForUser(string username)
        {

            Context ctx = new Context();
            var a = ctx.Admins.FirstOrDefault(x => x.AdminUserName == username);
            //var a = _adminroledal.Get(x => x.AdminUserName == username);
            return new string[] { a.AdminRole };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
