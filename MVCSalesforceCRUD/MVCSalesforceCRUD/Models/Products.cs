using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSalesforceCRUD.Models
{
    /// <summary>
    /// For holding all products
    /// </summary>
    public class Products
    {
        public List<Product> AllProducts { get; set; }
        public Products()
        {
            AllProducts = new List<Product>();
        }
    }
}