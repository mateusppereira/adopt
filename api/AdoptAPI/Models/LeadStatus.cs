using AdoptAPI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdoptAPI.Models
{
    public class LeadStatus
    {
        [DatabaseMember(ColumnName = "id", SerialValue = true, IsRequired = true)]
        public int Id { get; set; }

        [DatabaseMember(ColumnName = "status", IsRequired = true)]
        public string Status { get; set; }
    }
}