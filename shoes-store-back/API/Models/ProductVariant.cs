﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("ProductVariant")]
    public class ProductVariant
    {
        [Key]
        public int VariantID { get; set; }
        public int ProductID { get; set; }
        public String VariantImg { get; set; }
        [MaxLength(3)]
        public String VariantSize { get; set; }
        [MaxLength(20)]
        public String VariantColor { get; set; }

        public int VariantQuantity { get; set; }

        public virtual Product Product { get; set; }    
    }
}