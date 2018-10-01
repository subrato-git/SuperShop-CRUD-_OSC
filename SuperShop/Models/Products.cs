using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperShop.Models
{
    public class Products
    {
        [Key]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public int ProductQuantity { get; set; }
    }

    public enum SearchBy
    {
        Name,
        Category
    }
}