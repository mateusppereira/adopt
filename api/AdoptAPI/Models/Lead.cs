using AdoptAPI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdoptAPI.Models
{
    public class Lead
    {
        [DatabaseMember(ColumnName = "id", SerialValue = true, IsRequired = true)]
        public int Id { get; set; }

        [DatabaseMember(ColumnName = "fk_donation", IsRequired = true)]
        public int FkDonation { get; set; }

        [DatabaseMember(ColumnName = "fk_user", IsRequired = true)]
        public int FkUser { get; set; }

        [DatabaseMember(ColumnName = "fk_status", IsRequired = true)]
        public int FkStatus { get; set; }

        [DatabaseMember(ColumnName = "dt_creation", IsRequired = true)]
        public DateTime DtCreation { get; set; }
        public List<LeadMessage> Messages { get; set; }
        public Lead()
        {
            Messages = new List<LeadMessage>();
        }
    }
}