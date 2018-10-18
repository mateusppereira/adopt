using AdoptAPI.Classes;
using AdoptAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AdoptAPI.Business
{
    public class DonationPhotoBusiness
    {
        public List<DonationPhoto> GetByFkDonations(Postgres connection, List<int> fkDonations)
        {
            var sql = GetQueryByFkDonations(fkDonations);
            var dataSet = connection.Execute(sql);
            if (!Helper.DataSetHasResult(dataSet))
                return null;
            return Fill(dataSet);
        }
        private List<DonationPhoto> Fill(DataSet dataSet)
        {
            return (from DataRow row in dataSet.Tables[0].Rows
                    select new DonationPhoto()
                    {
                        Id = Utils.ValidateValue(0, row, "id"),
                        FkDonation = Utils.ValidateValue(0, row, "fk_donation"),
                        Photo = Utils.ValidateValue("", row, "photo")
                    }
                    ).ToList();
        }
        private string GetQueryByFkDonations(List<int> fkDonations)
        {
            return "SELECT * FROM public.donation_photo WHERE fk_donation = IN(" + string.Join(",", fkDonations) + ")";
        }
    }
}