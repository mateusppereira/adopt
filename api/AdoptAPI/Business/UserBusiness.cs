using AdoptAPI.Classes;
using AdoptAPI.Models;
using Commons;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AdoptAPI.Business
{
    public class UserBusiness
    {
        public User Login(Postgres connection, User user)
        {
            Encryption encrypty = new Encryption();
            user.Password = encrypty.EncryptToWebParameter(user.Password);

            var sql = GetQueryLogin(user);
            var dataSet = connection.Execute(sql);
            if (!Helper.DataSetHasResult(dataSet))
                return null;
            return Fill(dataSet)[0];
        }
        public int Add(Postgres connection, User user)
        {
            Encryption encrypty = new Encryption();
            user.Password = encrypty.EncryptToWebParameter(user.Password);

            var queryConstructor = new QueryConstructor<User>();
            var sql = queryConstructor.BuildeInsertQuery(user, "public", "user", false);
            return connection.ExecuteReturnIdIntTransaction(sql, "id");
        }
        private string GetQueryLogin(User user)
        {
            return @"SELECT id, name, username, password, email, document, phone FROM public.user 
                    WHERE (username = '" + user.Username + "' OR email = '" + user.Email + "') AND password = '" + user.Password + "'";
        }
        private List<User> Fill(DataSet dataSet)
        {
            var users = new List<User>();
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                var user = new User();
                var item = dataSet.Tables[0].Rows[i];
                user.Id = Utils.ValidateValue(0, item, "id");
                user.Document = Utils.ValidateValue("", item, "document");
                user.Email = Utils.ValidateValue("", item, "email");
                user.Name = Utils.ValidateValue("", item, "name");
                user.Password = Utils.ValidateValue("", item, "password");
                user.Phone = Utils.ValidateValue("", item, "phone");
                user.Username = Utils.ValidateValue("", item, "username");
                users.Add(user);
            }

            return users;
        }
    }
}