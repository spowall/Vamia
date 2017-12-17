using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vamia.Domain.Interface.Utility
{
    public interface IEncryption
    {
        string Encrypt(string password);
    }
}
