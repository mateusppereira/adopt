using AdoptAPI.Classes;
using AdoptAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AdoptAPI.Business
{
    public class LeadMessageBusiness
    {
        public int Add(Postgres connection, LeadMessage leadMessage)
        {
            var queryConstructor = new QueryConstructor<LeadMessage>();
            var sql = queryConstructor.BuildeInsertQuery(leadMessage, "public", "lead_message", false);
            return connection.ExecuteReturnIdIntTransaction(sql, "id");
        }
        public List<LeadMessage> GetByFkLeads(Postgres connection, List<int> fkLeads)
        {
            var sql = GetQueryByFkLead(fkLeads);
            var dataSet = connection.Execute(sql);
            if (!Helper.DataSetHasResult(dataSet))
                return null;
            return Fill(dataSet);
        }
        private List<LeadMessage> Fill(DataSet dataSet)
        {
            return (from DataRow row in dataSet.Tables[0].Rows
                    select new LeadMessage()
                    {
                        Id = Utils.ValidateValue(0, row, "id"),
                        FkLead = Utils.ValidateValue(0, row, "fk_lead"),
                        Message = Utils.ValidateValue("", row, "message"),
                        FkUser = Utils.ValidateValue(0, row, "fk_user"),
                        DtCreation = Utils.ValidateValue(DateTime.MinValue, row, "fk_donation"),
                    }
                    ).ToList();
        }
        private string GetQueryByFkLead(List<int> fkLeads)
        {
            return "SELECT * FROM public.lead_message WHERE fk_lead = IN(" + string.Join(",", fkLeads) + ")";
        }
    }
}