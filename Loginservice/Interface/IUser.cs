using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adminservice.Interface
{
   public interface IUser
    {
       bool  adduser(User user);
       bool  FindUser(string username);
        User login(string user);
    }
}
