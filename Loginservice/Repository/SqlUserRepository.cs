using Adminservice.DBContext;
using Adminservice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adminservice.Repository
{
    public class SqlUserRepository : IUser
    {
        private readonly AppDBContext _context;
        public SqlUserRepository(AppDBContext Context)
        {
            _context = Context;
        }

        //Add new user
        public bool adduser(User user)
        {
            bool result;
            try
            {
                _context.users.Add(user);
                _context.SaveChanges();

                result = true;
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        //Finding Exsist User
        public bool FindUser(string username)
        {
            
            var res = _context.users.FirstOrDefault(t=>t.Username==username);
            return res==null ? true: false;
            
        }

        public User login(string user)
        {
            return _context.users.FirstOrDefault(u => u.Username == user);
        }
    }
}
