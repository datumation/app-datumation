using Datumation.Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datumation.Management.Models
{
    public static class UserRepository
    {
        public static List<AppUser> Users;

        static UserRepository()
        {
            Users = new List<AppUser>();
        }
    }
}
