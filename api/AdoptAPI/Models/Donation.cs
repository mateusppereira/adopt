using AdoptAPI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdoptAPI.Models
{
    public class Donation
    {
        [DatabaseMember(ColumnName = "id", SerialValue = true, IsRequired = true)]
        public int Id { get; set; }

        [DatabaseMember(ColumnName = "title", IsRequired = true)]
        public string Title { get; set; }

        [DatabaseMember(ColumnName = "description", IsRequired = true)]
        public string Description { get; set; }

        [DatabaseMember(ColumnName = "gender", IsRequired = true)]
        public string Gender { get; set; }

        [DatabaseMember(ColumnName = "specie", IsRequired = true)]
        public string Specie { get; set; }

        [DatabaseMember(ColumnName = "fk_user", IsRequired = true)]
        public int FkUser { get; set; }

        [DatabaseMember(ColumnName = "geom", IsRequired = true)]
        public string Geom { get; set; }
        public List<DonationPhoto> Photos { get; set; }
        public Donation()
        {
            Photos = new List<DonationPhoto>();
        }

    }
}