using AdoptAPI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdoptAPI.Models
{
    public class DonationPhoto
    {
        [DatabaseMember(ColumnName = "id", SerialValue = true, IsRequired = true)]
        public int Id { get; set; }

        [DatabaseMember(ColumnName = "fk_donation", IsRequired = true)]
        public int FkDonation { get; set; }

        [DatabaseMember(ColumnName = "photo", IsRequired = true)]
        public string Photo { get; set; }
    }
}