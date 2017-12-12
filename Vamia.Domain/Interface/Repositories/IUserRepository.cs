using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Domain.Models;

namespace Vamia.Domain.Interface.Repositories
{
    public interface IUserRepository
    {
        UserModel ValidateUser(string email, string password);
    }
}
