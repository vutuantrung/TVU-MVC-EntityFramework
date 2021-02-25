using OnlineShop.Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public int Create(string name, string alias, int? parentID, int? order, bool? status )
        {
            object[] param =
            {
                new SqlParameter("@Name", name),
                new SqlParameter("@Alias", alias),
                new SqlParameter("@ParentID", parentID),
                new SqlParameter("@Order", order),
                new SqlParameter("@Status", status)
            };

            return _context.Database.ExecuteSqlCommand( "Sp_Category_Insert @Name, @Alias, @ParentID, @Order, @Status", param );
        }
    }
}
