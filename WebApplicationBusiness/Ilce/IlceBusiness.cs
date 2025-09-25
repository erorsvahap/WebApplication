using dbConnectionTest;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationBusiness.Il;

namespace WebApplicationBusiness.Ilce
{
    public class IlceBusiness
    {
        public IlceBusiness() { }

        ConnectionTest cnn= new ConnectionTest();
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
        public void AddIlce(Ilce ılce) 
        {
            try
            {
                cnn.Open();
                string sql = "INSERT INTO Ilce (IlceAd,IlId) VALUES (@IlId,@IlId)";
                var cmd = cnn.CreateCommand(sql, CommandType.Text);
                Params(cmd, new Dictionary<string, object>
            {
                {"@IlceAd",ılce.IlceAd} ,
                {"IlId", ılce.IlId}
            });
                cnn.Execute(cmd);
                cnn.Commit();

            }
            catch (Exception ex)
            {
                cnn.Rollback();
                throw new Exception("İlçe ekleme işlemi başarısız oldu:",ex);
            }           
        }
        
        public void UpdateIlce(Ilce ılce)
        {
            try
            {
                cnn.Open();

                string sql = "UPDATE Ilce SET IlceAd = @IlceAd  WHERE IlceId = @IlceId";
                var cmd = cnn.CreateCommand(sql, CommandType.Text);

                Params(cmd, new Dictionary<string, object>
                    {
                     {"@IlceAd", ılce.IlceAd},
                        {"@IlceId", ılce.IlceId},

                    });
                cnn.Execute(cmd);
                cnn.Commit();
            }
            catch (Exception ex)
            {
                cnn.Rollback();
                throw new Exception("İlçe güncelleme işlemi başarısız oldu", ex);
            }

        }
        public void Deleteılce(int ilceid)
        {
           
            try
            {
                cnn.Open();

                string sql = "DELETE FROM Ilce WHERE IlceId = @IlceId";
                var cmd = cnn.CreateCommand(sql, CommandType.Text);

                Params(cmd, new Dictionary<string, object>
                    {
                        {"@IlceId",ilceid}
                    });

                cnn.Execute(cmd);
                cnn.Commit();

            }
            catch (Exception ex)
            {
                cnn.Rollback();
                throw new Exception("İlçe silme işlemi başarısız oldu", ex);
            }
        }


    }
}
