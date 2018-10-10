using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Web;

namespace AdoptAPI.Classes
{
    public class QueryConstructor<T>
    {
        private PropertyInfo[] Props { get; set; }
        public Type Type { get; set; }
        private string IntoValues { get; set; }
        private string Values { get; set; }
        NumberFormatInfo Provider = new NumberFormatInfo();

        public QueryConstructor()
        {
            this.Provider.NumberDecimalSeparator = ".";
        }

        public string BuildeInsertQuery(object item, string schema, string table, bool returnAllData)
        {
            string query = "INSERT INTO " + schema + "." + table;
            this.Type = item.GetType();
            this.Props = (from p in typeof(T).GetProperties()
                          let value = Type.GetProperty(p.Name).GetValue(item)
                          let columnName = p.GetCustomAttributes(typeof(DatabaseMember), true).FirstOrDefault() as DatabaseMember
                          where value != null && ValidatePrimitiveTypes(value) && ValidateDoubleIntValues(value) &&
                          columnName != null && !columnName.SerialValue && !string.IsNullOrEmpty(columnName.ColumnName)
                          select p).Distinct().ToArray();

            if (this.Props.GetLength(0) <= 0)
                return string.Empty;

            this.IntoValues = "(" + string.Join(",", (from p in Props let columnName = p.GetCustomAttributes(typeof(DatabaseMember), true).First() as DatabaseMember select columnName.ColumnName).ToList()) + ")";
            this.Values = "VALUES(" + string.Join(",", (from p in Props select FormatInsertValue(Type.GetProperty(p.Name).GetValue(item), p.Name)).ToList()) + ")";
            return query + " " + IntoValues.ToString() + " " + Values.ToString() + (returnAllData ? " returning *" : string.Empty);
        }

        private bool ValidatePrimitiveTypes(object item)
        {
            return
                item.GetType().Equals(typeof(double)) ||
                item.GetType().Equals(typeof(int)) ||
                item.GetType().Equals(typeof(string)) ||
                item.GetType().Equals(typeof(DateTime)) ||
                item.GetType().Equals(typeof(long)) ||
                item.GetType().Equals(typeof(bool));
        }

        private bool ValidateDoubleIntValues(object item)
        {
            if ((item.GetType().Equals(typeof(double)) && Math.Abs(Convert.ToDouble(item)) <= 0) ||
                (item.GetType().Equals(typeof(int)) && Convert.ToInt32(item) <= 0) ||
                (item.GetType().Equals(typeof(long)) && Convert.ToInt64(item) <= 0))
                return false;
            return true;
        }

        private object FormatInsertValue(object value, string propName)
        {
            if (value.GetType().Equals(typeof(string)) && !string.IsNullOrEmpty(propName) && propName == "Geom")
                return value;
            if (value.GetType().Equals(typeof(string)))
                return "'" + value + "'";
            if (value.GetType().Equals(typeof(DateTime)))
                return "'" + Convert.ToDateTime(value).ToString("yyyy-MM-dd HH:mm:ss") + "'";
            if (value.GetType().Equals(typeof(double)))
                return Convert.ToDouble(value, Provider).ToString().Replace(",", ".");
            if (value.GetType().Equals(typeof(byte[])))
                return "'" + value + "'";
            return value;
        }
    }
}