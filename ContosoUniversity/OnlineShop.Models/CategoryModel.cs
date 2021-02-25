using OnlineShop.Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class CategoryModel
    {
        private readonly OnlineShopDbContext _context = null;

        public CategoryModel()
        {
            _context = new OnlineShopDbContext();
        }

        public List<Category> ListAll()
        {
            return _context.Database.SqlQuery<Category>( "Sp_Category_ListAll" ).ToList();
        }
    }
}
