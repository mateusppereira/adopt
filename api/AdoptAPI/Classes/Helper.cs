using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using AdoptAPI.Classes;
using AdoptAPI.Classes;
using AdoptAPI.Models;

namespace AdoptAPI.Classes
{
    public class Helper
    {
        public static Response CreateResponse(bool error, string message, object objectResult)
        {
            Response response = new Response();
            response.HasErrors = error;
            response.Message = message;
            response.ObjectResult = objectResult;
            return response;
        }
        public static bool DataSetHasResult(DataSet dataSet)
        {
            if ((dataSet.Tables != null) && (dataSet.Tables.Count > 0))
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static Dictionary<string, string> GetColumnType(Postgres connection, string tableSchema, string tableName, string tableColumn)
        {
            try
            {
                var sql = "SELECT data_type FROM information_schema.columns WHERE table_schema = '" + tableSchema + "' AND table_name = '" + tableName + "' AND column_name = '" + tableColumn + "'";
                var dataSet = connection.Execute(sql);
                var hasResult = DataSetHasResult(dataSet);
                if (!hasResult)
                    return null;
                return GenerateListDictionary(dataSet).ToList().FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public static List<Dictionary<string, string>> GenerateListDictionary(System.Data.DataSet dataSet)
        {
            List<Dictionary<string, string>> listRows = new List<Dictionary<string, string>>();

            if (DataSetHasResult(dataSet))
            {
                try
                {
                    for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                    {
                        List<string> columns = dataSet.Tables[0].Columns.Cast<System.Data.DataColumn>().Select(c => c.ColumnName).ToList();
                        Dictionary<string, string> dicRow = new Dictionary<string, string>();
                        for (int j = 0; j < columns.Count; j++)
                            dicRow.Add(columns[j].ToLower(), dataSet.Tables[0].Rows[i][columns[j]].ToString());
                        listRows.Add(dicRow);
                    }
                }
                catch
                {
                }
            }
            return listRows;
        }

        public static Dictionary<string, string> GenerateDictionary(System.Data.DataSet dataSet)
        {
            if (DataSetHasResult(dataSet))
            {
                try
                {
                    List<string> columns = dataSet.Tables[0].Columns.Cast<System.Data.DataColumn>().Select(c => c.ColumnName).ToList();
                    Dictionary<string, string> dicRow = new Dictionary<string, string>();
                    for (int j = 0; j < columns.Count; j++)
                        dicRow.Add(columns[j].ToLower(), dataSet.Tables[0].Rows[0][columns[j]].ToString());
                    return dicRow;
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

        public static string GenerateJson(System.Data.DataSet dataSet)
        {
            StringBuilder sbJson = new StringBuilder();
            string tempJson = string.Empty;
            sbJson.Append("[");

            if ((dataSet.Tables != null) && (dataSet.Tables.Count > 0))
            {
                try
                {
                    foreach (System.Data.DataRow row in dataSet.Tables[0].Rows)
                    {
                        sbJson.Append("{");
                        List<string> columns = dataSet.Tables[0].Columns.Cast<System.Data.DataColumn>().Select(i => i.ColumnName).ToList();

                        foreach (string columnName in columns)
                        {
                            string value = row[columnName].ToString().Replace("\n", "").Replace("\"", "''");
                            sbJson.Append("\"" + columnName.ToLower() + "\": \"" + value + "\",");
                        }
                        tempJson = sbJson.ToString();
                        sbJson = new StringBuilder();
                        sbJson.Append(tempJson.Substring(0, tempJson.Length - 1) + "},");
                    }
                }
                catch
                {
                }
            }
            tempJson = sbJson.ToString();
            sbJson = new StringBuilder();
            sbJson.Append(tempJson.Substring(0, tempJson.Length - 1) + "]");

            return sbJson.ToString();
        }

        public static DbType GetDbType(string typeName)
        {
            if (typeName.Equals("System.String", StringComparison.InvariantCultureIgnoreCase))
            {
                return DbType.String;
            }
            else if (typeName.Equals("System.Int16", StringComparison.InvariantCultureIgnoreCase))
            {
                return DbType.Int16;
            }
            else if (typeName.Equals("System.Int32", StringComparison.InvariantCultureIgnoreCase))
            {
                return DbType.Int32;
            }
            else if (typeName.Equals("System.Int64", StringComparison.InvariantCultureIgnoreCase))
            {
                return DbType.Int64;
            }
            else if (typeName.Equals("System.DateTime", StringComparison.InvariantCultureIgnoreCase))
            {
                return DbType.DateTime;
            }
            else if (typeName.Equals("System.Boolean", StringComparison.InvariantCultureIgnoreCase))
            {
                return DbType.Boolean;
            }
            else
            {
                return DbType.Object;
            }
        }

        public static String RemoveAccents(String value)
        {
            Char[] acentos = { 'Ç', 'Á', 'À', 'Ã', 'Â', 'Ä', 'É', 'È', 'Ê', 'Ë', 'Í', 'Ì', 'Î', 'Ï', 'Ó', 'Ò', 'Õ', 'Ô', 'Ö', 'Ú', 'Ù', 'Û', 'Ü', 'ç', 'á', 'à', 'ã', 'â', 'ä', 'é', 'è', 'ê', 'ë', 'í', 'ì', 'î', 'ï', 'ó', 'ò', 'õ', 'ô', 'ö', 'ú', 'ù', 'û', 'ü' };
            Char[] correspondente = { 'C', 'A', 'A', 'A', 'A', 'A', 'E', 'E', 'E', 'E', 'I', 'I', 'I', 'I', 'O', 'O', 'O', 'O', 'O', 'U', 'U', 'U', 'U', 'c', 'a', 'a', 'a', 'a', 'a', 'e', 'e', 'e', 'e', 'i', 'i', 'i', 'i', 'o', 'o', 'o', 'o', 'o', 'u', 'u', 'u', 'u' };

            foreach (Char caracter in value.ToCharArray())
            {
                for (int increment = 0; increment < acentos.Length; increment++)
                {
                    if (value.ToUpper().Contains(acentos[increment].ToString().ToUpper()))
                    {
                        value = value.Replace(acentos[increment], correspondente[increment]);
                    }
                }
            }
            return value.ToLower();
        }

        public static string RemoveDocumentMask(string value)
        {
            value = value.Replace(".", "");
            value = value.Replace("-", "");
            value = value.Replace("/", "");
            return value;
        }

        public static string ValidateValue(String defaultValue, System.Data.DataRow row, String fieldName)
        {
            try
            {
                if (row.IsNull(fieldName))
                {
                    return defaultValue;
                }
                else
                {
                    return (String)row[fieldName];
                }
            }
            catch
            {
                return defaultValue;
            }
        }

        public static string ValidateValue(String defaultValue, string row, String fieldName)
        {
            try
            {
                if (row == null)
                {
                    return defaultValue;
                }
                else
                {
                    return row;
                }
            }
            catch
            {
                return defaultValue;
            }
        }

        public static int ValidateValue(int defaultValue, System.Data.DataRow row, String fieldName)
        {
            try
            {
                if (row.IsNull(fieldName))
                {
                    return defaultValue;
                }
                else
                {
                    return Convert.ToInt32(row[fieldName]);
                }
            }
            catch
            {
                return defaultValue;
            }
        }

        public static int ValidateValue(int defaultValue, string row, String fieldName)
        {
            try
            {
                if (row == null)
                {
                    return defaultValue;
                }
                else
                {
                    return Convert.ToInt32(row);
                }
            }
            catch
            {
                return defaultValue;
            }
        }

        public static decimal ValidateValue(decimal defaultValue, System.Data.DataRow row, String fieldName)
        {
            try
            {
                if (row.IsNull(fieldName))
                {
                    return defaultValue;
                }
                else
                {
                    return Convert.ToDecimal(row[fieldName]);
                }
            }
            catch
            {
                return defaultValue;
            }
        }

        public static double ValidateValue(double defaultValue, System.Data.DataRow row, String fieldName)
        {
            try
            {
                if (row.IsNull(fieldName))
                {
                    return defaultValue;
                }
                else
                {
                    NumberFormatInfo provider = new NumberFormatInfo();
                    provider.NumberDecimalSeparator = ",";
                    return Convert.ToDouble(row[fieldName].ToString().Replace(".", ","), provider);
                }
            }
            catch
            {
                return defaultValue;
            }
        }

        public static Int64 ValidateValue(Int64 defaultValue, System.Data.DataRow row, String fieldName)
        {
            try
            {
                if (row.IsNull(fieldName))
                {
                    return defaultValue;
                }
                else
                {
                    return Convert.ToInt64(row[fieldName]);
                }
            }
            catch
            {
                return defaultValue;
            }
        }

        public static decimal ValidateValue(decimal defaultValue, string row, String fieldName)
        {
            try
            {
                if (row == null)
                {
                    return defaultValue;
                }
                else
                {
                    return Convert.ToDecimal(row);
                }
            }
            catch
            {
                return defaultValue;
            }
        }

        public static string ValidateValue(DateTime defaultValue, DataRow row, String fieldName, String dateFormat)
        {
            try
            {
                if (row.IsNull(fieldName))
                {
                    return defaultValue.ToString(dateFormat);
                }
                else
                {
                    return Convert.ToDateTime(row[fieldName]).ToString(dateFormat);
                }
            }
            catch
            {
                return defaultValue.ToString(dateFormat);
            }
        }

        public static string ValidateValue(DateTime defaultValue, string row, String fieldName, String dateFormat)
        {
            try
            {
                if (row == null)
                {
                    return defaultValue.ToString(dateFormat);
                }
                else
                {
                    return Convert.ToDateTime(row).ToString(dateFormat);
                }
            }
            catch
            {
                return defaultValue.ToString(dateFormat);
            }
        }

        public static string ReplaceSpecialCharacters(string value)
        {
            return value.Replace("'", "''");
        }

        public static byte[] ValidateValue(byte[] defaultValue, DataRow row, string fieldName)
        {
            try
            {
                if (row.IsNull(fieldName))
                {
                    return defaultValue;
                }
                else
                {
                    return (byte[])row[fieldName];
                }
            }
            catch
            {
                return defaultValue;
            }
        }

        public static bool ValidateValue(bool defaultValue, DataRow row, String fieldName)
        {
            try
            {
                if (row.IsNull(fieldName))
                {
                    return defaultValue;
                }
                else
                {
                    return Convert.ToBoolean(row[fieldName]);
                }
            }
            catch
            {
                return defaultValue;
            }
        }

        public static bool ValidateValue(bool defaultValue, string row, String fieldName)
        {
            try
            {
                if (row == null)
                {
                    return defaultValue;
                }
                else
                {
                    return Convert.ToBoolean(row);
                }
            }
            catch
            {
                return defaultValue;
            }
        }

        public static object GetInstance(Type type, decimal id)
        {
            object item = null;
            try
            {
                item = Activator.CreateInstance(type, id);
            }
            catch (Exception exception)
            {
            }

            return item;
        }

        public static string SHA1Hash(string input)
        {
            System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = sha.ComputeHash(data);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static int BooleanToInt(bool value)
        {
            if (value)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static string FormatText(string text)
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                {
                    return string.Empty;
                }

                Char[] acentos = { 'Ç', 'Á', 'À', 'Ã', 'Â', 'Ä', 'É', 'È', 'Ê', 'Ë', 'Í', 'Ì', 'Î', 'Ï', 'Ó', 'Ò', 'Õ', 'Ô', 'Ö', 'Ú', 'Ù', 'Û', 'Ü', 'ç', 'á', 'à', 'ã', 'â', 'ä', 'é', 'è', 'ê', 'ë', 'í', 'ì', 'î', 'ï', 'ó', 'ò', 'õ', 'ô', 'ö', 'ú', 'ù', 'û', 'ü', 'Š', '“', '“', '´', '`', '”', '\'' };
                Char[] correspondente = { 'C', 'A', 'A', 'A', 'A', 'A', 'E', 'E', 'E', 'E', 'I', 'I', 'I', 'I', 'O', 'O', 'O', 'O', 'O', 'U', 'U', 'U', 'U', 'c', 'a', 'a', 'a', 'a', 'a', 'e', 'e', 'e', 'e', 'i', 'i', 'i', 'i', 'o', 'o', 'o', 'o', 'o', 'u', 'u', 'u', 'u', 'S', ' ', ' ', ' ', ' ', ' ', ' ' };

                foreach (Char caracter in text.ToCharArray())
                {
                    try
                    {
                        for (int increment = 0; increment < acentos.Length; increment++)
                        {
                            try
                            {
                                if (text.Contains(acentos[increment].ToString()))
                                {
                                    text = text.Replace(acentos[increment], correspondente[increment]);
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
            }

            text = text.Replace("/", " ");
            text = text.Replace("\\", " ");
            text = text.Replace("(", " ");
            text = text.Replace(")", " ");
            text = text.Replace(".", "");
            text = text.Replace("-", "");
            text = text.Replace(",", "");
            text = text.Replace("  ", " ");
            text = text.Replace("  ", " ");
            text = text.TrimStart().TrimEnd();

            return text.ToUpper();
        }

        public static bool validaDocumento(string num)
        {
            bool ret = false;
            if (num.Length <= 11)
                ret = validaCPF(num);
            else
                ret = validaCNPJ(num);

            return ret;
        }

        private static bool validaCNPJ(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        private static bool validaCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
        public static string FormatDouble(double value)
        {
            return value.ToString().Replace(",", ".");
        }
    }
}