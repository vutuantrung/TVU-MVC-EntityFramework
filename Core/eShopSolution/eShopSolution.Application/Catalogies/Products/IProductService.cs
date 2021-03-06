using eShopSolution.ViewModels.Catalog.ProductImage;
using eShopSolution.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalogies.Products
{
    interface IProductService
    {
        Task<int> Create( ProductCreateRequest request );

        Task<int> Update( ProductUpdateRequest request );

        Task<int> Delete( int id );

        Task<List<ProductViewModel>> GetAll();


        Task<int> AddImage( int productId, ProductImageCreateRequest request );

        Task<int> RemoveImage( int imageId );

        Task<int> UpdateImage( int imageId, ProductImageUpdateRequest request );
    }
}
