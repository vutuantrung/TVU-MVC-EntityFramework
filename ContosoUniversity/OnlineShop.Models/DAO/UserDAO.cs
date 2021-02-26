﻿using OnlineShop.Models.EF;
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

        public long GetUserID( string userName, string password )
        {
            // Get user whitch match with userName and password
            var user = _context.Users.FirstOrDefault( x => x.UserName == userName && x.Password == password );
            return user == null ? user.ID : -1;
        }

        public User GetUser( string userName, string password )
        {
            // Get user whitch match with userName and password
            var user = _context.Users.FirstOrDefault( x => x.UserName == userName && x.Password == password );
            return user;
        }
    }
}
