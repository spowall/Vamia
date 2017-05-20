using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Models;

namespace Vamia.Domain.Interface.Repositories
{
    public interface IInventoryRepository
    {
        ProductModel[] GetProducts();
        ProductModel FindProduct(int id);
        ProductModel[] FindProduct(string search);
    }
}
