namespace NorthWind.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Product
    {
        public int ProductId { get; set; }

        [Display(Name ="Product Name" )]
        public string ProductName { get; set; }

        [Display(Name = "Unit Price")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString ="{0:C2}", ApplyFormatInEditMode =false)]
        public decimal? UnitPrice { get; set; }

        [Display(Name = "Unit In Stock")]
        public int? UnitInStock { get; set; }
        public Category Category { get; set; }
    }
}
