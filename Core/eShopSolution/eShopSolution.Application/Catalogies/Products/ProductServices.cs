using eShopSolution.Application.Common;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.Utilities.Exceptions;
using eShopSolution.ViewModels.Catalog.ProductImage;
using eShopSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalogies.Products
{
    public class ProductServices : IProductService
    {
        private readonly EShopDbContext _context;
        private readonly IFileStorageServices _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public ProductServices( EShopDbContext context, IFileStorageServices storageService )
        {
            _context = context;
            _storageService = storageService;
        }

        private async Task<string> SaveFile( IFormFile file )
        {
            var originalFileName = ContentDispositionHeaderValue.Parse( file.ContentDisposition ).FileName.Trim( '"' );
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension( originalFileName )}";
            await _storageService.SaveFileAsync( file.OpenReadStream(), fileName );
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

        public async Task<int> Create( ProductCreateRequest request )
        {
            var product = new Product()
            {
                Price = request.Price
            };

            var result = _context.Products.Add( product );
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete( int id )
        {
            var product = await _context.Products.FindAsync( id );
            if( product == null ) throw new EShopException( $"Cannot find a product: {id}" );

            var images = _context.ProductImages.Where( i => i.ProductId == id );
            foreach( var image in images )
            {
                await _storageService.DeleteFileAsync( image.ImagePath );
            }

            _context.Products.Remove( product );

            return await _context.SaveChangesAsync();
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update( ProductUpdateRequest request )
        {
            var product = await _context.Products.FindAsync( request.Id );
            var productTranslations = await _context.ProductTranslations
                .FirstOrDefaultAsync( x => x.ProductId == request.Id && x.LanguageId == request.LanguageId );

            // Product not found
            if( product == null || productTranslations == null ) throw new EShopException( $"Can not find product with ID: {request.Id}" );

            productTranslations.Name = request.Name;
            productTranslations.SeoAlias = request.SeoAlias;
            productTranslations.SeoDescription = request.SeoDescription;
            productTranslations.SeoTitle = request.SeoTitle;
            productTranslations.Description = request.Description;
            productTranslations.Details = request.Details;

            //Save image
            if( request.ThumbnailImage != null )
            {
                var thumbnailImage = await _context.ProductImages.FirstOrDefaultAsync( i => i.IsDefault == true && i.ProductId == request.Id );
                if( thumbnailImage != null )
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile( request.ThumbnailImage );
                    _context.ProductImages.Update( thumbnailImage );
                }
            }

            return await _context.SaveChangesAsync();
        }


        // Image
        public async Task<int> AddImage( int productId, ProductImageCreateRequest request )
        {
            var productImage = new ProductImage()
            {
                Caption = request.Caption,
                DateCreated = DateTime.Now,
                IsDefault = request.IsDefault,
                ProductId = productId,
                SortOrder = request.SortOrder
            };

            if( request.ImageFile != null )
            {
                productImage.ImagePath = await this.SaveFile( request.ImageFile );
                productImage.FileSize = request.ImageFile.Length;
            }
            _context.ProductImages.Add( productImage );
            await _context.SaveChangesAsync();
            return productImage.Id;
        }

        public async Task<int> RemoveImage( int imageId )
        {
            var productImage = await _context.ProductImages.FindAsync( imageId );
            if( productImage == null ) throw new EShopException( $"Cannot find an image with id {imageId}" );
            _context.ProductImages.Remove( productImage );
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateImage( int imageId, ProductImageUpdateRequest request )
        {
            var productImage = await _context.ProductImages.FindAsync( imageId );
            if( productImage == null )
                throw new EShopException( $"Cannot find an image with id {imageId}" );

            if( request.ImageFile != null )
            {
                productImage.ImagePath = await this.SaveFile( request.ImageFile );
                productImage.FileSize = request.ImageFile.Length;
            }
            _context.ProductImages.Update( productImage );
            return await _context.SaveChangesAsync();
        }
    }
}
