using dbConnectionTest;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationBusiness.Il
{
    public class IlBusiness
    {

        public IlBusiness() { }
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
        public void AddıL( Il il )
        {
           
            try
            {
                cnn.Open();
                string sql = "INSERET INTO Il (IlAd,UlkeId) VALUES (@IlId,@UlkeId)";
                var cmd = cnn.CreateCommand(sql, CommandType.Text);
                Params(cmd, new Dictionary<string, object> 
                {
                    {"@IlAd",il.IlId} ,
                     {"@UlkeId" , il.UlkeId}
                });

            }
            catch (Exception ex)
            {
                cnn.Rollback();
                throw new Exception("İl ekleme işlemi başarısız oldu:",ex);
            }
        }
        public void UpdateIl(Il il)
        {
            try
            {
                cnn.Open();
                string sql = "UPDATE Il SET IlAd = @IlAd WHERE IlId = @IlId";
                var cmd = cnn.CreateCommand(sql, CommandType.Text);
                Params(cmd, new Dictionary<string, object>
                {
                    {"@IlAd",il.IlId} ,
                     {"@IlId",il.IlId}
                });
                cnn.Execute(cmd);
                cnn.Commit();  
            }
            catch (Exception ex)
            {
                cnn.Rollback();
                throw new Exception(" İl güncelleme işlemi başarısız oldu:",ex);
            }
        }
        public void DeleteIl( int IlId) 
        {
            try
            { 
                cnn.Open();
                string sql = "DELETE FROM Il WHERE IlId= @ IlId";
                var cmd = cnn.CreateCommand(sql, CommandType.Text);
                Params(cmd, new Dictionary<string, object> 
                {
                    {"@IlId",IlId} 
                });
                cnn.Execute(cmd);
                cnn.Commit();


            }
            catch (Exception ex)
            {
                cnn.Rollback();
                throw new Exception("İl silme işlemi başarısız olud:" ex);
            }

        }


    }
}
