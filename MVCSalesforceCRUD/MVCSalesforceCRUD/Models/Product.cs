using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCSalesforceCRUD.Models
{
    /// <summary>
    /// Model for holding Product details
    /// </summary>
    public class Product
    {
        [Description("Price Book Entry ID")]
        public string Id { get; set; }

        [Description("Name of the Product")]
        public string Name { get; set; }

        [Description("Price Book ID")]
        public string Pricebook2Id { get; set; }
        
        [Description("Product ID")]
        public string Product2Id { get; set; }

        [Description("This is the Sales Price of the Product")]
        public string UnitPrice { get; set; }

    }
}