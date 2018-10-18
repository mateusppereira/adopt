using AdoptAPI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdoptAPI.Models
{
    public class LeadMessage
    {
        [DatabaseMember(ColumnName = "id", SerialValue = true, IsRequired = true)]
        public int Id { get; set; }

        [DatabaseMember(ColumnName = "fk_lead", IsRequired = true)]
        public int FkLead { get; set; }

        [DatabaseMember(ColumnName = "fk_user", IsRequired = true)]
        public int FkUser { get; set; }

        [DatabaseMember(ColumnName = "message", IsRequired = true)]
        public string Message { get; set; }

        [DatabaseMember(ColumnName = "dt_creation", IsRequired = true)]
        public DateTime DtCreation { get; set; }
    }
}