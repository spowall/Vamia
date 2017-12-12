using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Domain.Interface.Repositories;
using Vamia.Domain.Models;

namespace Vamia.Domain.Managers
{
    public class UserManager
    {
        private IUserRepository _userRepo;

        public UserManager(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public UserModel Login(string email, string password)
        {
            //Check to see if User Exists
            return _userRepo.ValidateUser(email, password);
        }
    }
}
