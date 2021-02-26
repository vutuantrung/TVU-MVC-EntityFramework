using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace OnlineShop.Models.EF
{
    public partial class OnlineShopDbContext : DbContext
    {
        public OnlineShopDbContext()
            : base( "name=OnlineShopDbContext" )
        {
            // Make sure that Entity instance copied
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public virtual DbSet<Abount> Abounts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<ContentTag> ContentTags { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Abount>()
                .Property( e => e.MetaTitle )
                .IsUnicode( false );

            modelBuilder.Entity<Abount>()
                .Property( e => e.CreatedBy )
                .IsUnicode( false );

            modelBuilder.Entity<Abount>()
                .Property( e => e.ModifiedBy )
                .IsUnicode( false );

            modelBuilder.Entity<Abount>()
                .Property( e => e.MetaDescriptions )
                .IsUnicode( false );

            modelBuilder.Entity<Category>()
                .Property( e => e.CreatedBy )
                .IsUnicode( false );

            modelBuilder.Entity<Category>()
                .Property( e => e.ModifiedBy )
                .IsUnicode( false );

            modelBuilder.Entity<Category>()
                .Property( e => e.MetaDescriptions )
                .IsUnicode( false );

            modelBuilder.Entity<Contact>()
                .Property( e => e.Status )
                .IsFixedLength();

            modelBuilder.Entity<Content>()
                .Property( e => e.MetaTitle )
                .IsUnicode( false );

            modelBuilder.Entity<Content>()
                .Property( e => e.CreatedBy )
                .IsUnicode( false );

            modelBuilder.Entity<Content>()
                .Property( e => e.ModifiedBy )
                .IsUnicode( false );

            modelBuilder.Entity<Content>()
                .Property( e => e.MetaDescriptions )
                .IsUnicode( false );

            modelBuilder.Entity<ContentTag>()
                .Property( e => e.TagID )
                .IsUnicode( false );

            modelBuilder.Entity<Footer>()
                .Property( e => e.ID )
                .IsUnicode( false );

            modelBuilder.Entity<Product>()
                .Property( e => e.Code )
                .IsUnicode( false );

            modelBuilder.Entity<Product>()
                .Property( e => e.MetaTitle )
                .IsUnicode( false );

            modelBuilder.Entity<Product>()
                .Property( e => e.Price )
                .HasPrecision( 18, 0 );

            modelBuilder.Entity<Product>()
                .Property( e => e.Promotion )
                .HasPrecision( 18, 0 );

            modelBuilder.Entity<Product>()
                .Property( e => e.CreatedBy )
                .IsUnicode( false );

            modelBuilder.Entity<Product>()
                .Property( e => e.ModifiedBy )
                .IsUnicode( false );

            modelBuilder.Entity<Product>()
                .Property( e => e.MetaDescriptions )
                .IsUnicode( false );

            modelBuilder.Entity<ProductCategory>()
                .Property( e => e.CreatedBy )
                .IsUnicode( false );

            modelBuilder.Entity<ProductCategory>()
                .Property( e => e.ModifiedBy )
                .IsUnicode( false );

            modelBuilder.Entity<ProductCategory>()
                .Property( e => e.MetaDescriptions )
                .IsUnicode( false );

            modelBuilder.Entity<Slide>()
                .Property( e => e.CreatedBy )
                .IsUnicode( false );

            modelBuilder.Entity<Slide>()
                .Property( e => e.ModifiedBy )
                .IsUnicode( false );

            modelBuilder.Entity<Tag>()
                .Property( e => e.ID )
                .IsUnicode( false );

            modelBuilder.Entity<User>()
                .Property( e => e.UserName )
                .IsUnicode( false );

            modelBuilder.Entity<User>()
                .Property( e => e.Password )
                .IsUnicode( false );

            modelBuilder.Entity<User>()
                .Property( e => e.CreatedBy )
                .IsUnicode( false );

            modelBuilder.Entity<User>()
                .Property( e => e.ModifiedBy )
                .IsUnicode( false );
        }
    }
}
