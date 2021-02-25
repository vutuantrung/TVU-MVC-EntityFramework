namespace OnlineShop.Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table( "Category" )]
    public partial class Category
    {
        [DatabaseGenerated( DatabaseGeneratedOption.None )]
        public int ID { get; set; }

        [Required( ErrorMessage = "Please enter Category's name." )]
        [StringLength( 50, ErrorMessage = "Your name passes the maximum characters number." )]
        [DisplayName( "Category name" )]
        public string Name { get; set; }

        [StringLength( 50 )]
        [DisplayName( "SEO name" )]
        public string Alias { get; set; }

        [DisplayName( "Parent list" )]
        public int? ParentID { get; set; }

        [DisplayName( "Created date" )]
        public DateTime? CreatedDate { get; set; }

        [Range( 0, int.MaxValue, ErrorMessage = "Please enter order number." )]
        public int? Order { get; set; }

        public bool? Status { get; set; }
    }
}
