using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace OnlineShop.Models.Framework
{
    public partial class OnlineShopContextDB : DbContext
    {
        public OnlineShopContextDB()
            : base( "name=OnlineShopDbContext" )
        {
            // Make sure that Entity instance copied
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Account>()
                .Property( e => e.UserName )
                .IsUnicode( false );

            modelBuilder.Entity<Account>()
                .Property( e => e.Password )
                .IsUnicode( false );

            modelBuilder.Entity<Product>()
                .Property( e => e.Price )
                .HasPrecision( 18, 0 );
        }
    }
}