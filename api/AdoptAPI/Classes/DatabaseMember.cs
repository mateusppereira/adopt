using System;

namespace AdoptAPI.Classes
{
    [AttributeUsage(AttributeTargets.All)]
    public class DatabaseMember : Attribute
    {
        private bool isRequired;
        private bool serialValue;
        private string columnName;
        private int stringLength;

        public DatabaseMember()
        {

        }

        public DatabaseMember(bool isRequired, bool serialValue, string columnName, int stringLength)
        {
            this.isRequired = isRequired;
            this.serialValue = serialValue;
            this.columnName = columnName;
            this.stringLength = stringLength;
        }

        public virtual bool IsRequired
        {
            get { return isRequired; }
            set { isRequired = value; }
        }

        public virtual bool SerialValue
        {
            get { return serialValue; }
            set { serialValue = value; }
        }

        public virtual string ColumnName
        {
            get { return columnName; }
            set { columnName = value; }
        }


        public virtual int StringLength
        {
            get { return stringLength; }
            set { stringLength = value; }
        }
    }
}