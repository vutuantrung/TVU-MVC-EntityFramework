namespace OnlineShop.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table( "User" )]
    public partial class User
    {
        public long ID { get; set; }

        [StringLength( 50 )]
        [Display( Name = "Username" )]
        public string UserName { get; set; }

        [StringLength( 50 )]
        [Display( Name = "Password" )]
        public string Password { get; set; }

        [StringLength( 50 )]
        [Display( Name = "Full name" )]
        public string Name { get; set; }

        [StringLength( 50 )]
        [Display( Name = "Address" )]
        public string Address { get; set; }

        [StringLength( 50 )]
        [Display( Name = "Email" )]
        public string Email { get; set; }

        [StringLength( 50 )]
        [Display( Name = "Phone number" )]
        public string Phone { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength( 50 )]
        public string CreatedBy { get; set; }

        public DateTime? ModifedDate { get; set; }

        [StringLength( 50 )]
        public string ModifiedBy { get; set; }

        [Display( Name = "Status" )]
        public bool? Status { get; set; }
    }
}
