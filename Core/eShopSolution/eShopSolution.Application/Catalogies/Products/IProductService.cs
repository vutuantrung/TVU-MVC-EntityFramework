using eShopSolution.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Catalogies.Products
{
    interface IProductService
    {
        int Create( ProductCreateRequest request );

        int Update( ProductUpdateRequest request );

        int Delete( int id );

        List<ProductViewModel> GetAll();
    }
}
