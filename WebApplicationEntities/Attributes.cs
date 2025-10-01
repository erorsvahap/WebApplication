using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationEntities
{

    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class DbIdentityAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class DbColumnNameAttribute : Attribute // kolon aadı farklı ise gerveiğni tut
    {
        public string ColumnName { get; }

        public DbColumnNameAttribute(string columnName)
        {
            ColumnName = columnName;
        }
    }


}
