using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Domain.Interface.Repositories;
using Vamia.Domain.Models;
using Vamia.Infrastructure.Entities;

namespace Vamia.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DbContext _context;

        public UserRepository(DbContext context)
        {
            _context = context;
        }

        public UserModel Create(UserModel model)
        {
            var user = new User
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Image = model.Image,
            };

            _context.Set<User>().Add(user);

            _context.SaveChanges();

            model.UserId = user.UserId;
            return model;
        }

        public UserModel GetUser(string email)
        {
            //Generate Query
            var query = from user in _context.Set<User>()
                        where user.Email == email

                        let roles = from userRole in user.UserRoles
                                    select userRole.Role.Name

                        select new
                        {
                            user,
                            roles
                        };

            //Pull Records from Database
            var records = query.ToArray();

            //Transform the data
            var transform = from record in records
                            select new UserModel
                            {
                                UserId = record.user.UserId,
                                Email = record.user.Email,
                                FirstName = record.user.FirstName,
                                LastName = record.user.LastName,
                                Image = record.user.Image,
                                Roles = record.roles.ToArray()
                            };

            //Return first UserModel record
            return transform.FirstOrDefault();
        }

        public void SetPasswordHash(int userId, string passwordHash)
        {
            var user = _context.Set<User>().Find(userId);
            if (user == null) throw new Exception("User not found");
            user.PasswordHash = passwordHash;
            _context.SaveChanges();
        }

        public UserModel ValidateUser(string email, string passwordHash)
        {
            var query = from user in _context.Set<User>()
                        where user.Email == email
                        where user.PasswordHash == passwordHash

                        let roles = from userRole in user.UserRoles
                                    select userRole.Role.Name

                        select new
                        {
                            user,
                            roles
                        };

            var record = query.FirstOrDefault();

            if(record != null)
            {
                return new UserModel
                {
                    UserId = record.user.UserId,
                    Email = record.user.Email,
                    FirstName = record.user.FirstName,
                    LastName = record.user.LastName,
                    Roles = record.roles.ToArray()
                };
            }

            return null;
        }
    }
}
