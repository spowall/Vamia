using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamia.Data.Entities;
using Vamia.Domain.Interface.Repositories;
using Vamia.Models;

namespace Vamia.Data.Repositories
{
    public class InMemoryCartRepository: ICartRepository
    {
        private List<ItemModel> _items = new List<ItemModel>();

        public List<ItemModel> GetCartItems()
        {
            return _items;
        }

        public void SaveCartItems(List<ItemModel> items)
        {
            _items = items;
        }
    }
}

