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
                if (p.IsDefined(typeof(DbIdentityAttribute), true))
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

        public void Update()
        {
            string idName = "";
            int idValue = 0;
            var setList = new List<string>();


            foreach (var p in this.GetType().GetProperties())             // Identity kolonunu bul

            {
                if (p.Name.Equals("TableName", StringComparison.OrdinalIgnoreCase)) // tabbloname ismini atla
                    continue;
                if (p.IsDefined(typeof(DbIdentityAttribute), true))
                {
                    var colAttr = (DbColumnNameAttribute)p.GetCustomAttribute(typeof(DbColumnNameAttribute));
                    idName = colAttr?.ColumnName ?? p.Name; // eger attributee kolon adı verilmiş ise onu aldegılse sqlde ki ni al
                    idValue = (int)p.GetValue(this); // properti degeri al
                    break;
                }
            }

            foreach (var p in this.GetType().GetProperties())     // identity olmayan tüm kolonlar
            {
                if (p.IsDefined(typeof(DbIdentityAttribute), true)) continue; //ıdentty olanı alma atla
                if (p.Name.Equals("TableName", StringComparison.OrdinalIgnoreCase)) 
                    continue;

                var colAttr = (DbColumnNameAttribute)p.GetCustomAttribute(typeof(DbColumnNameAttribute));
                string colName = colAttr?.ColumnName ?? p.Name;
                setList.Add($"{colName} = @{colName}");
            }

            string setString = string.Join(", ", setList); // tek string haline gtir

            string sql = $"UPDATE {TableName} SET {setString} WHERE {idName} = @{idName}";
            using (var cnn = new ConnectionTest())
            {
                try
                {
                    cnn.Open();
                    var cmd = cnn.CreateCommand(sql, CommandType.Text);


                    foreach (var p in this.GetType().GetProperties())
                    {

                        if (p.IsDefined(typeof(DbIdentityAttribute), true)) continue; 
                        var colAttr = (DbColumnNameAttribute)p.GetCustomAttribute(typeof(DbColumnNameAttribute));
                        string colName = colAttr?.ColumnName ?? p.Name;

                        var prm = cmd.CreateParameter();
                        prm.ParameterName = "@" + colName;
                        prm.Value = p.GetValue(this) ?? DBNull.Value;
                        cmd.Parameters.Add(prm);
                    }

                    var idPrm = cmd.CreateParameter();
                    idPrm.ParameterName = "@" + idName;
                    idPrm.Value = idValue;
                    cmd.Parameters.Add(idPrm);

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

        public void SoftDelete()
        {
            string idName = "";
            int idValue = 0;

            foreach (var p in this.GetType().GetProperties())
            {
                if (p.IsDefined(typeof(DbIdentityAttribute), true))
                {
                    var colAttr = (DbColumnNameAttribute)p.GetCustomAttribute(typeof(DbColumnNameAttribute));
                    idName = colAttr?.ColumnName ?? p.Name;
                    idValue = (int)p.GetValue(this);
                    break;
                }
            }

            string sql = $"UPDATE {TableName} SET IsDeleted = 1 WHERE {idName} = @{idName}";

            using (var cnn = new ConnectionTest())
            {
                cnn.Open();
                var cmd = cnn.CreateCommand(sql, CommandType.Text);

                var prm = cmd.CreateParameter();
                prm.ParameterName = "@" + idName;
                prm.Value = idValue;
                cmd.Parameters.Add(prm);

                cnn.ExecuteNonQuery(cmd);
                cnn.Commit();
                cnn.Close();
            }
        }






    }

}
