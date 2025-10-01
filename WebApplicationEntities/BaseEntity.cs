using dbConnectionTest;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationEntities
{
    public abstract class BaseEntity 
    {
       

        public abstract string TableName { get; } // Her tablo kendi adını burada verir

        public void Insert()
        {
            var cols = new List<string>();
            var prms = new List<string>();
            var props = new List<PropertyInfo>();

            foreach (var p in this.GetType().GetProperties())
            {
                // Identity kolonları atla ve ve  table name isinide atla
                if (p.Name.Equals("TableName", StringComparison.OrdinalIgnoreCase) || p.IsDefined(typeof(DbIdentityAttribute), true)) continue;

                cols.Add(p.Name);           // property ismini kolon olarak al
                prms.Add("@" + p.Name);     // parametre adı
                props.Add(p);               // parametre eklemek için property listesine al
            }

            // SQL cümlesi oluştur
            string sql = $"INSERT INTO {TableName} ({string.Join(", ", cols)}) VALUES ({string.Join(", ", prms)})";

            using (var cnn = new ConnectionTest())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand(sql, CommandType.Text);

                // Parametreleri ekle
                foreach (var p in props)
                {
                    var prm = cmd.CreateParameter();
                    prm.ParameterName = "@" + p.Name;
                    prm.Value = p.GetValue(this) ?? DBNull.Value;
                    cmd.Parameters.Add(prm);
                }

                cnn.ExecuteNonQuery(cmd);
                cnn.Commit();
                cnn.Close();
            }
        }
        public int idprop;
        public void Delete()
        {
            string idName = ""; // identity kolon adı
            idprop = 0;

            foreach (var p in this.GetType().GetProperties())
            {
                if(p.IsDefined(typeof(DbIdentityAttribute), true ))
                {
                    var colAttr = (DbColumnNameAttribute)p.GetCustomAttribute(typeof(DbColumnNameAttribute)); //Bu property üzerinde [DbColumnName("...")] attributu var mı diye kontrol eder
                    idName = colAttr?.ColumnName ?? p.Name; // varsa eger isme  " " içindkini yaz yoksa eger syoksa sql de ki kolonu kullan
                    idprop = (int)p.GetValue(this);
                    break;
                }



            }
            string sql = $"DELETE FROM {TableName} WHERE {idName}= @{idName} ";

            using (var cnn = new ConnectionTest())
            {
                try
                {
                    cnn.Open();
                    var cmd = cnn.CreateCommand(sql, CommandType.Text);
                    var prm = cmd.CreateParameter();
                    prm.ParameterName = "@" + idName;
                    prm.Value = idprop;
                    cmd.Parameters.Add(prm);

                    cnn.ExecuteNonQuery(cmd);
                    cnn.Commit();
                }
                catch
                {
                    cnn.Rollback();
                    throw;
                }
                finally
                {
                    cnn.Close();
                }
            }




        }


     
        
        


        
    }

}
