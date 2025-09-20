using dbConnectionTest;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationBusiness.Semt
{
    public class SemtBusiness
    {
        public SemtBusiness() { }
        ConnectionTest cnn = new ConnectionTest();
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
        public void AddSemt(Semt semt)
        {
            ConnectionTest cnn = new ConnectionTest();
            try
            {
                cnn.Open();
                string sql = "INSERT INTO Semt (SemtAd,IlceId) VALUES (@SemtAd,@IlceId)";
                var cmd = cnn.CreateCommand(sql, CommandType.Text);
                Params(cmd, new Dictionary<string, object>
            {
                {"@SemtAd",semt.SemtAd} ,
                {"@IlceId", semt.IlceId}
            });
                cnn.Execute(cmd);
                cnn.Commit();

            }
            catch (Exception ex)
            {
                cnn.Rollback();
                throw new Exception("Smet ekleme işlemi başarısız oldu:", ex);
            }
        }
        public void UpdateSemt(Semt semt)
        {
            ConnectionTest cnn = new ConnectionTest();
            try
            {
                cnn.Open();

                string sql = "UPDATE Semt SET SemtAd = @SemtAd  WHERE SemtId = @SemtId";
                var cmd = cnn.CreateCommand(sql, CommandType.Text);

                Params(cmd, new Dictionary<string, object>
                    {
                     {"@SemtAd", semt.SemtAd},
                        {"@SemtId", semt.SemtId},

                    });
                cnn.Execute(cmd);
                cnn.Commit();
            }
            catch (Exception ex)
            {
                cnn.Rollback();
                throw new Exception("Semt güncelleme işlemi başarısız oldu", ex);
            }

        }
        public void DeleteSemt(int semtid)
        {
            ConnectionTest cnn = new ConnectionTest();
            try
            {
                cnn.Open();

                string sql = "DELETE FROM Semt WHERE SemtId = @SemtId";
                var cmd = cnn.CreateCommand(sql, CommandType.Text);

                Params(cmd, new Dictionary<string, object>
                    {
                        {"@SemtId",semtid}
                    });

                cnn.Execute(cmd);
                cnn.Commit();

            }
            catch (Exception ex)
            {
                cnn.Rollback();
                throw new Exception("Semt silme işlemi başarısız oldu", ex);
            }
        }


    }
}
