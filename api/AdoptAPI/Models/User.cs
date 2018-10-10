using AdoptAPI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdoptAPI.Models
{
    public class User
    {
        [DatabaseMember(ColumnName = "id", SerialValue = true, IsRequired = true)]
        public int Id { get; set; }

        [DatabaseMember(ColumnName = "name", IsRequired = true)]
        public string Name { get; set; }

        [DatabaseMember(ColumnName = "username", IsRequired = true)]
        public string Username { get; set; }

        [DatabaseMember(ColumnName = "password", IsRequired = true)]
        public string Password { get; set; }

        [DatabaseMember(ColumnName = "email", IsRequired = true)]
        public string Email { get; set; }

        [DatabaseMember(ColumnName = "document", IsRequired = true)]
        public string Document { get; set; }

        [DatabaseMember(ColumnName = "phone", IsRequired = true)]
        public string Phone { get; set; }
    }
}