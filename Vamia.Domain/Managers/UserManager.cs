using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Domain.Interface.Repositories;
using Vamia.Domain.Interface.Utility;
using Vamia.Domain.Models;

namespace Vamia.Domain.Managers
{
    public class UserManager
    {
        private IUserRepository _userRepo;
        private IEncryption _encryption;

        public UserManager(IUserRepository userRepo, IEncryption encryption)
        {
            _userRepo = userRepo;
            _encryption = encryption;
        }

        public UserModel Login(string email, string password)
        {
            //Check to see if User Exists
            var passwordHash = _encryption.Encrypt(password);
            return _userRepo.ValidateUser(email, passwordHash);
        }

        public UserModel RegisterUser(UserModel model, string password)
        {
            model.Validate();

            //Check if User Exists
            var user = _userRepo.GetUser(model.Email);
            if (user != null) throw new Exception($"Email ({model.Email}) already exists");

            //Create User (We are sure user == null here)
            user = _userRepo.Create(model);

            //Encrypt Password
            var passwordHash = _encryption.Encrypt(password);

            //Store Encrypted Password
            _userRepo.SetPasswordHash(user.UserId, passwordHash);

            return model;
        }
    }
}
