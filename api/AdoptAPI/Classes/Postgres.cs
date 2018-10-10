using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AdoptAPI.Classes
{
    public class Postgres
    {
        private NpgsqlConnection Connection;
        private NpgsqlTransaction Transaction;
        public string ErrorMessage { get; set; }

        public Postgres(string connectionString)
        {
            this.Connection = new NpgsqlConnection(connectionString);
        }

        public bool BeginTransaction()
        {
            try
            {
                this.OpenConnection();
                this.Transaction = Connection.BeginTransaction();
                return true;
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return false;
            }
        }

        public void OpenConnection()
        {
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (this.Connection.State == ConnectionState.Open)
                    this.Connection.Close();
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }

        public void Commit()
        {
            this.Transaction.Commit();
            this.Transaction.Dispose();
            this.Connection.Close();
        }

        public void Rollback()
        {
            this.Transaction.Rollback();
            this.Transaction.Dispose();
            this.Connection.Close();
        }

        //for Insert Update and Delete
        public int ExecuteNonQuery(string query)
        {
            OpenConnection();
            var result = 0;
            try
            {
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = this.Connection;
                    cmd.CommandText = query;
                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return -1;
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        //for Insert Update and Delete with Transaction
        public int ExecuteNonQueryTransaction(string query)
        {
            var result = 0;
            try
            {
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = this.Connection;
                    cmd.Transaction = this.Transaction;
                    cmd.CommandText = query;
                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return -1;
            }
            return result;
        }

        public int ExecuteNonQueryTransactionReturnIdInt(string query, string identifier)
        {
            var result = 0;
            try
            {
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = this.Connection;
                    cmd.Transaction = this.Transaction;
                    cmd.CommandText = query + " returning " + identifier;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        result = reader.GetInt32(0);
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return -1;
            }
            return result;
        }

        public DataSet Execute(string query)
        {
            OpenConnection();
            var dataSet = new DataSet();
            try
            {
                using (var cmd = new NpgsqlCommand())
                {
                    var npgsqlDataAdapter = new NpgsqlDataAdapter();
                    cmd.Connection = this.Connection;
                    cmd.CommandText = query;
                    npgsqlDataAdapter.SelectCommand = cmd;
                    npgsqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return new DataSet();
            }
            finally
            {
                CloseConnection();
            }
            return dataSet;
        }

        public DataSet ExecuteTransaction(string query)
        {
            var dataSet = new DataSet();
            try
            {
                using (var cmd = new NpgsqlCommand())
                {
                    var npgsqlDataAdapter = new NpgsqlDataAdapter();
                    cmd.Connection = this.Connection;
                    cmd.Transaction = this.Transaction;
                    cmd.CommandText = query;
                    npgsqlDataAdapter.SelectCommand = cmd;
                    npgsqlDataAdapter.Fill(dataSet);
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return new DataSet();
            }
            return dataSet;
        }

        public int ExecuteReturnIdInt(string query, string identifier)
        {
            OpenConnection();
            var result = -1;
            try
            {
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = this.Connection;
                    cmd.CommandText = query + " returning " + identifier;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        result = reader.GetInt32(0);
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return -1;
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        public int ExecuteReturnIdIntTransaction(string query, string identifier)
        {
            var result = -1;
            try
            {
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = this.Connection;
                    cmd.Transaction = this.Transaction;
                    cmd.CommandText = query + " returning " + identifier;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        result = reader.GetInt32(0);
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return -1;
            }
            return result;
        }

        public long ExecuteReturnIdInt64(string query, string identifier)
        {
            OpenConnection();
            long result = -1;
            try
            {
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = this.Connection;
                    cmd.CommandText = query + " returning " + identifier;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        result = reader.GetInt64(0);
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return -1;
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        public long ExecuteReturnIdInt64Transaction(string query, string identifier)
        {
            long result = -1;
            try
            {
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = this.Connection;
                    cmd.Transaction = this.Transaction;
                    cmd.CommandText = query + " returning " + identifier;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        result = reader.GetInt64(0);
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return -1;
            }
            return result;
        }

        public int ExecuteReturnIdIntTransaction(string query)
        {
            //GenerateLog log = new GenerateLog("");
            int result = -1;
            try
            {
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = this.Connection;
                    cmd.Transaction = this.Transaction;
                    cmd.CommandText = query;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        result = reader.GetInt32(0);
                }
            }
            catch (Exception e)
            {
                //log.WriteOnLogFile(true, "\n MESSAGE: " + e.Message + " \n ORDER: " + e.InnerException + " \n StackTrace: " + e.StackTrace, query);
                ErrorMessage = e.Message;
                return -1;
            }
            finally
            {
            }
            return result;
        }

        public long ExecuteReturnIdInt64Transaction(string query)
        {
            //GenerateLog log = new GenerateLog("");

            Int64 result = -1;
            try
            {
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = this.Connection;
                    cmd.Transaction = this.Transaction;
                    cmd.CommandText = query;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        result = reader.GetInt64(0);
                }
            }
            catch (Exception e)
            {
                //log.WriteOnLogFile(true, "\n MESSAGE: " + e.Message + " \n ORDER: " + e.InnerException + " \n StackTrace: " + e.StackTrace, query);
                ErrorMessage = e.Message;
                return -1;
            }
            finally
            {
            }
            return result;
        }
    }
}