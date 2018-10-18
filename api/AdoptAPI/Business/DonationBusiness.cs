using AdoptAPI.Classes;
using AdoptAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AdoptAPI.Business
{
    public class DonationBusiness
    {
        public int Add(Postgres connection, Donation donation)
        {
            donation.Geom = "ST_GEOMFROMTEXT('" + donation.Geom + "', 4326)";

            var queryConstructor = new QueryConstructor<Donation>();
            var sql = queryConstructor.BuildeInsertQuery(donation, "public", "donation", false);
            return connection.ExecuteReturnIdIntTransaction(sql, "id");
        }
        public List<Donation> GetAll(Postgres connection)
        {
            var sql = GetAllQuery();
            var dataSet = connection.Execute(sql);
            if (!Helper.DataSetHasResult(dataSet))
                return new List<Donation>();
            var donations = Fill(dataSet);

            var donationPhoto = new DonationPhotoBusiness();
            var photos = donationPhoto.GetByFkDonations(connection, donations.Select(c => c.Id).ToList());

            donations.Select(item =>
            {
                item.Photos = photos.Where(a => a.FkDonation == item.Id).ToList();
                return item;
            }).ToList();

            return donations;
        }
        private List<Donation> Fill(DataSet dataSet)
        {
            return (from DataRow row in dataSet.Tables[0].Rows
                    select new Donation()
                    {
                        Id = Utils.ValidateValue(0, row, "id"),
                        Description = Utils.ValidateValue("", row, "description"),
                        FkUser = Utils.ValidateValue(0, row, "fk_user"),
                        Gender = Utils.ValidateValue("", row, "gender"),
                        Specie = Utils.ValidateValue("", row, "specie"),
                        Title = Utils.ValidateValue("", row, "title"),
                        Geom = Utils.ValidateValue("", row, "geom"),
                    }
                    ).ToList();
        }
        private string GetAllQuery()
        {
            return "SELECT id, title, description, gender, specie, fk_user, ST_ASTEXT(geom) as geom FROM public.donation";
        }
    }
}