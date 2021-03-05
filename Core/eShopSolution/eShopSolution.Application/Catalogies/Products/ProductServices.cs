using eShopSolution.Data.EF;
using eShopSolution.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Catalogies.Products
{
    public class ProductServices : IProductService
    {
        private readonly EShopDbContext _context;

        public ProductServices( EShopDbContext context )
        {
            _context = context;
        }

        public int Create( ProductCreateRequest request )
        {
            throw new NotImplementedException();
        }

        public int Delete( int id )
        {
            throw new NotImplementedException();
        }

        public List<ProductViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Update( ProductUpdateRequest request )
        {
            throw new NotImplementedException();
        }
    }
}
