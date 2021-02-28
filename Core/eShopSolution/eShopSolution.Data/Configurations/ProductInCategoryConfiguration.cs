using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopSolution.Data.Configurations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        // This is an example of table relation n --- n
        // Configure relation ship between table Product and Category
        public void Configure( EntityTypeBuilder<ProductInCategory> builder )
        {
            builder.HasKey( x => new { x.CategoryId, x.ProductId } );

            builder.ToTable( "ProductInCategories" );

            // Relation between 2 tables
            builder.HasOne( x => x.Product ).WithMany( pc => pc.ProductInCategories ).HasForeignKey( pc => pc.ProductId );
            builder.HasOne( x => x.Category ).WithMany( pc => pc.ProductInCategories ).HasForeignKey( pc => pc.CategoryId );
        }
    }
}