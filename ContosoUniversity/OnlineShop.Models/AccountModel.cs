using OnlineShop.Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class AccountModel
    {
        private readonly OnlineShopDbContext _context = null;

        public AccountModel()
        {
            _context = new OnlineShopDbContext();
        }

        public bool Login( string userName, string password )
        {
            object[] sqlParams =
            {
                new SqlParameter("@UserName", userName),
                new SqlParameter("@Password", password)
            };

            var res = _context.Database.SqlQuery<bool>( "Sp_Account_Login @UserName,@Password", sqlParams ).SingleOrDefault();

            return res;
        }
    }
}
