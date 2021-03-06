using eShopSolution.Application.Catalogies.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.BackendAPI.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productServices;

        public ProductController( IProductService productServices )
        {
            _productServices = productServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productServices.GetAll();

            return Ok( products );
        }
    }
}
