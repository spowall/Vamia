using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Domain.Interface.Repositories;
using Vamia.Domain.Models;

namespace Vamia.Tests.Mock.Repositories
{
    public class MockUserRepository : IUserRepository
    {
        List<UserModel> _users = new List<UserModel>();
        Dictionary<int, string> _hashes = new Dictionary<int, string>();
        public UserModel Create(UserModel model)
        {
            //Assign Id
            if (_users.Any())
            {
                var max = _users.Max(u => u.UserId);
                model.UserId = max + 1;
            }
            else
            {
                model.UserId = 1;
            }
            
            //Add User
            _users.Add(model);
            return model;
        }

        public UserModel GetUser(string email)
        {
            return _users.FirstOrDefault(u => u.Email == email);
        }

        public void SetPasswordHash(int userId, string passwordHash)
        {
            if (_hashes.ContainsKey(userId))
            {
                _hashes[userId] = passwordHash;
            }
            else
            {
                _hashes.Add(userId, passwordHash);
            }
        }

        public UserModel ValidateUser(string email, string passwordHash)
        {
            var user = _users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                var passHash = _hashes[user.UserId];
                if(passHash == passwordHash)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
