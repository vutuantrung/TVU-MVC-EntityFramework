using eShopSolution.Data.EF;
using eShopSolution.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalogies.Products
{
    public class ProductServices : IProductService
    {
        private readonly EShopDbContext _context;

        public ProductServices( EShopDbContext context )
        {
            _context = context;
        }

        public async Task<int> Create( ProductCreateRequest request )
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete( int id )
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update( ProductUpdateRequest request )
        {
            throw new NotImplementedException();
        }
    }
}
