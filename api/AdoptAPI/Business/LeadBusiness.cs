using AdoptAPI.Classes;
using AdoptAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AdoptAPI.Business
{
    public class LeadBusiness
    {
        public int Add(Postgres connection, Lead lead)
        {
            var queryConstructor = new QueryConstructor<Lead>();
            var sql = queryConstructor.BuildeInsertQuery(lead, "public", "lead", false);
            return connection.ExecuteReturnIdIntTransaction(sql, "id");
        }

        public List<Lead> GetAll(Postgres connection)
        {
            var sql = GetAllQuery();
            var dataSet = connection.Execute(sql);
            if (!Helper.DataSetHasResult(dataSet))
                return new List<Lead>();
            var leads = Fill(dataSet);

            var donationMessage = new LeadMessageBusiness();
            var message = donationMessage.GetByFkLeads(connection, leads.Select(c => c.Id).ToList();

            leads.Select(item =>
            {
                item.Messages = message.Where(a => a.FkLead == item.Id).ToList();
                return item;
            }).ToList();

            return leads;
        }
        private List<Lead> Fill(DataSet dataSet)
        {
            return (from DataRow row in dataSet.Tables[0].Rows
                    select new Lead()
                    {
                        Id = Utils.ValidateValue(0, row, "id"),
                        FkUser = Utils.ValidateValue(0, row, "fk_user"),
                        DtCreation = Utils.ValidateValue(DateTime.MinValue, row, "dt_creation"),
                        FkDonation = Utils.ValidateValue(0, row, "fk_donation"),
                        FkStatus = Utils.ValidateValue(0, row, "fk_status")
                    }
                    ).ToList();
        }

        private string GetAllQuery()
        {
            return "SELECT id, fk_donation, fk_user, fk_status, dt_creation FROM public.lead";
        }
    }
}