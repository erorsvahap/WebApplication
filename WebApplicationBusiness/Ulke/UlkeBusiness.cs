using dbConnectionTest;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationBusiness.Ulke
{
    public class UlkeBusiness
    {
        public UlkeBusiness() { }

        public void Params(IDbCommand cmd, Dictionary<string, object> parameters)
        {
            foreach (var p in parameters)
            {
                var param = cmd.CreateParameter();
                param.ParameterName = p.Key;
                param.Value = p.Value;
                cmd.Parameters.Add(param);
            }
        }


        public void AddUlke( Ulke ulke)
        {
            ConnectionTest cnn = new ConnectionTest();
            
            try
            {
                cnn.Open();
                string sql = "INSERT INTO ULKE (UlkeAd) VALUES (@UlkeAd)";
                var cmd = cnn.CreateCommand(sql, CommandType.Text);

                Params(cmd, new Dictionary<string, object>
            {
                { "@UlkeAd" , ulke.UlkeAd}
            });
                cnn.Execute(cmd);
                cnn.Commit();

            }
            catch (Exception ex )
            {
                cnn.Rollback();
                throw new Exception("Ülke ekleme işlemi başarısız oldu:", ex);
            }
        }

        public void UpdateUlke(Ulke ulke) { 
            ConnectionTest cnn = new ConnectionTest();
            try
            {
                cnn.Open();
                string sql = "UPDATE ULKE SET UlkeAd = @UlkeAd WHERE UlkeId = @UlkeId";
                var cmd = cnn.CreateCommand(sql, CommandType.Text);
                Params(cmd, new Dictionary<string, object>
                {
                    {"@UlkeId", ulke.UlkeId},
                    {"@UlkeAd", ulke.UlkeAd}
                });
                cnn.Execute(cmd);
                cnn.Commit();

            }
            catch (Exception ex)
            {
                cnn.Rollback();
                throw new Exception("Ülke güncelleme işlemi başarısız oldu:", ex);
            }
        
        }
        public void DeleteUlke(int UlkeId) 
        {  

            ConnectionTest cnn = new ConnectionTest();
            try
            {
                cnn.Open();
                string sql = "DELETE FROM ULKE WHERE UlkeID = @UlkeId";
                var cmd = cnn.CreateCommand(sql, CommandType.Text);
                Params(cmd, new Dictionary<string, object> 
                {
                    {"@UlkeId", UlkeId}
                });
                cnn.Execute(cmd);
                cnn.Commit();

            }
            catch (Exception ex)
            {
                cnn.Rollback();
                throw new Exception("Ülke güncelleme işlemi başarısız oldu:", ex);
            }
        }



    }
}
