using AdoptAPI.Classes;
using AdoptAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdoptAPI.Business
{
    public class UserBusiness
    {
        public User Login(Postgres connection, User user)
        {
            var sql = GetQueryLogin(user);
        }
        public int Add(Postgres connection, User user)
        {
            var queryConstructor = new QueryConstructor<User>();
            var sql = queryConstructor.BuildeInsertQuery(user, "public", "user", false);
            return connection.ExecuteReturnIdIntTransaction(sql, "id");
        }
        private string GetQueryLogin(User user)
        {
            return @"SELECT id, name, username, password, email, document, phone FROM user 
                    WHERE (username = '" + user.Username + "' OR email = '" + user.Email + "') AND password = '" + user.Password + "'";
        }
    }
}