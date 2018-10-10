using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;

namespace AdoptAPI.Classes
{
    public static class Utils
    {
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
                    //return (String)row[fieldName];
                    return row[fieldName].ToString();
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

        public static long ValidateValue(long defaultValue, System.Data.DataRow row, String fieldName)
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

        public static long ValidateValue(long defaultValue, string row, String fieldName)
        {
            try
            {
                if (row == null)
                {
                    return defaultValue;
                }
                else
                {
                    return Convert.ToInt64(row);
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

        public static double ValidateValue(double defaultValue, System.Data.DataRow row, String fieldName)
        {
            try
            {
                NumberFormatInfo provider = new NumberFormatInfo();
                provider.NumberDecimalSeparator = ".";

                if (row.IsNull(fieldName))
                {
                    return defaultValue;
                }
                else
                {
                    return Convert.ToDouble(row[fieldName].ToString().Replace(",", "."), provider);
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

        public static DateTime ValidateValue(DateTime defaultValue, DataRow row, String fieldName)
        {
            try
            {
                if (row.IsNull(fieldName))
                {
                    return defaultValue;
                }
                else
                {
                    return Convert.ToDateTime(row[fieldName]);
                }
            }
            catch
            {
                return defaultValue;
            }
        }

        public static string ValidateValue(DateTime defaultValue, string row, string fieldName, string dateFormat)
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
                    return new byte[0];
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


    }
}
