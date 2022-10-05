using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;

namespace MvcProje.Roles
{
    public class AdminRoleProvider : RoleProvider
    {
        //IAdminDal _admindal;      

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public void Delete(Admin p)
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

        public Admin Get(Expression<Func<Admin, bool>> filter)
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
            var a = ctx.Admins.FirstOrDefault(x=>x.AdminUserName==username);
            //var a= _admindal.Get(x => x.AdminUserName == username);
            return new string[] { a.AdminRole };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public void Insert(Admin p)
        {
            throw new NotImplementedException();


        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public List<Admin> List()
        {
            throw new NotImplementedException();
        }

        public List<Admin> List(Expression<Func<Admin, bool>> filter)
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

        public void Update(Admin p)
        {
            throw new NotImplementedException();
        }
    }
}