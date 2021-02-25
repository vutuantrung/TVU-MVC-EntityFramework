namespace OnlineShop.Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table( "Product" )]
    public partial class Product
    {
        [DatabaseGenerated( DatabaseGeneratedOption.None )]
        public int ID { get; set; }

        [StringLength( 50 )]
        public string Name { get; set; }

        public int? CategoryID { get; set; }

        [StringLength( 250 )]
        public string Image { get; set; }

        public DateTime? CreatedDate { get; set; }

        public decimal? Price { get; set; }

        [Column( TypeName = "ntext" )]
        public string Detail { get; set; }

        public bool? Status { get; set; }
    }
}
