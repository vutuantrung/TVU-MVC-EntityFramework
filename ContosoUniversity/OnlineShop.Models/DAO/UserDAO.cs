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

        /// <summary>
        /// Find user by username and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User FindUser( string userName, string password )
        {
            // Get user which matches with userName and password
            var user = _context.Users.FirstOrDefault( x => x.UserName == userName && x.Password == password );
            return user;
        }

        /// <summary>
        /// Find user by username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User FindUser( string userName )
        {
            // Get user which matches with userName and password
            var user = _context.Users.FirstOrDefault( x => x.UserName == userName );
            return user;
        }

        /// <summary>
        /// Find user by ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public User FindUser( long userID )
        {
            // Get user which matches with userName and password
            var user = _context.Users.FirstOrDefault( x => x.ID == userID );
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

        public IEnumerable<User> GetAllOthersUser( string userName )
        {
            var users = _context.Users.Where( user => user.UserName != userName );
            return users;
        }

        public void UpdateUser( User user )
        {
            var existingUser = FindUser( user.ID );
            existingUser.UserName = user.UserName;
            existingUser.Name = user.Name;
            existingUser.Address = user.Address;
            existingUser.Email = user.Email;
            existingUser.Phone = user.Phone;
            existingUser.ModifiedBy = user.ModifiedBy;
            existingUser.ModifedDate = user.ModifedDate;
            _context.SaveChanges();
        }
    }
}
