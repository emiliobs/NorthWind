namespace NorthWind.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    public class Category
    {
        public int CategoryId { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
