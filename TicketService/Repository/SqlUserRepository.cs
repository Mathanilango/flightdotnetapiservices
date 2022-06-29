using TicketService.DBContext;
using TicketService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketService.Repository
{
    public class SqlUserRepository : IUser
    {
        private readonly AppDBContext _context;
        public SqlUserRepository(AppDBContext Context)
        {
            _context = Context;
        }

        //Add new user
        //public bool adduser(User user)
        //{
        //    bool result;
        //    try
        //    {
        //        _context.users.Add(user);
        //        _context.SaveChanges();

        //        result = true;
        //    }
        //    catch (Exception e)
        //    {
        //        result = false;
        //    }
        //    return result;
        //}

        //Finding Exsist User
        //public bool FindUser(string username)
        //{
            
        //    var res = _context.users.Where(t=>t.Username==username);
        //    return res.Count()>0 ? true: false;
            
        //}
    }
}
