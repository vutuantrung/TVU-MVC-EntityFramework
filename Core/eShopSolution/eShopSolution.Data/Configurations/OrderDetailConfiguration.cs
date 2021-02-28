using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopSolution.Data.Configurations
{
    //
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        // This is an example of table relation 1 --- n
        // Configure relation ship between table Order and OrderDetail
        public void Configure( EntityTypeBuilder<OrderDetail> builder )
        {
            builder.ToTable( "OrderDetails" );

            builder.HasKey( x => new { x.OrderId, x.ProductId } );
            builder.HasOne( x => x.Order ).WithMany( x => x.OrderDetails ).HasForeignKey( x => x.OrderId );
            builder.HasOne( x => x.Product ).WithMany( x => x.OrderDetails ).HasForeignKey( x => x.ProductId );
        }
    }
}