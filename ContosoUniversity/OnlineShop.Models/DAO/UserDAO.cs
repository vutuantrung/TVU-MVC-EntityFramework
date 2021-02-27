using OnlineShop.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models.DAO
{
    public class UserDAO
    {
        private readonly OnlineShopDbContext _context = null;

        public UserDAO()
        {
            _context = new OnlineShopDbContext();
        }

        public long Insert( User user )
        {
            _context.Users.Add( user );
            _context.SaveChanges();

            return user.ID;
        }

        public User GetUser( string userName, string password )
        {
            // Get user which matches with userName and password
            var user = _context.Users.FirstOrDefault( x => x.UserName == userName && x.Password == password );
            return user;
        }

        public User GetUser( string userName )
        {
            // Get user which matches with userName and password
            var user = _context.Users.FirstOrDefault( x => x.UserName == userName );
            return user;
        }

        public long CreateUser( User user )
        {
            _context.Users.Add( user );
            _context.SaveChanges();

            return user.ID;
        }

        public IEnumerable<User> GetAllUsersByPage( int page, int pageSize )
        {
            return _context.Users
                .OrderByDescending( x => x.CreatedDate )
                .ToPagedList( page, pageSize );
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }
    }
}
