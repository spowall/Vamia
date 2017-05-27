using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vamia.Data.Entities;
using Vamia.Models;

namespace Vamia.Utils
{
    public static class Extensions
    {
        public static UserModel AsUser(this AppUser user)
        {
            if (user == null) return null;
            return new UserModel
            {
                UserId = user.Id,
                Email = user.Email,
            };
        }

        public static AppUser AsAppUser(this UserModel user)
        {
            return new AppUser
            {
                Id = user.UserId,
                Email = user.Email
            };
        }
    }
}