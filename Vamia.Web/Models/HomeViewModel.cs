using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vamia.Domain.Models;

namespace Vamia.Web.Models
{
    public class HomeViewModel
    {
        public ProductModel[] Inventory { get; set; } = new ProductModel[] { };
        public List<ItemModel> Cart { get; set; } = new List<ItemModel> { };
    }
}