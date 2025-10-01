using System;
using System.Collections.Generic;
using System.Data;
using WebApplicationEntities;
using dbConnectionTest;

namespace DataAccess
{
    public class DataRepository
    {
        public DataRepository() { }

        //public void Add<T>(T model) where T : BaseEntity
        //{
        //    if (model == null)
        //        throw new ArgumentNullException(nameof(model));

        //    using (var cnn = new ConnectionTest())
        //    {
        //        try
        //        {
        //            cnn.Open();
        //            string sql = "";
        //            var parameters = new Dictionary<string, object>();

        //            switch (model)
        //            {
        //                case Country country:
        //                    sql = "INSERT INTO Ulke(UlkeAd) VALUES(@UlkeAd)";
        //                    parameters.Add("@UlkeAd", country.Name);
        //                    break;

        //                case City city:
        //                    sql = "INSERT INTO Il(IlAd, UlkeId) VALUES(@IlAd, @UlkeId)";
        //                    parameters.Add("@IlAd", city.Name);
        //                    parameters.Add("@UlkeId", city.CountryId);
        //                    break;

        //                case District district:
        //                    sql = "INSERT INTO Ilce(IlceAd, IlId) VALUES(@IlceAd, @IlId)";
        //                    parameters.Add("@IlceAd", district.Name);
        //                    parameters.Add("@IlId", district.CityId);
        //                    break;

        //                case Neighborhood neighborhood:
        //                    sql = "INSERT INTO Semt(SemtAd, IlceId) VALUES(@SemtAd, @IlceId)";
        //                    parameters.Add("@SemtAd", neighborhood.Name);
        //                    parameters.Add("@IlceId", neighborhood.DistrictId);
        //                    break;

        //                default:
        //                    throw new NotSupportedException("Desteklenmeyen tip: " + model.GetType().Name);
        //            }

        //            var cmd = cnn.CreateCommand(sql, CommandType.Text);
        //            foreach (var p in parameters)
        //            {
        //                var param = cmd.CreateParameter();
        //                param.ParameterName = p.Key;
        //                param.Value = p.Value;
        //                cmd.Parameters.Add(param);
        //            }

        //            cnn.ExecuteNonQuery(cmd);
        //            cnn.Commit();
        //        }
        //        catch (Exception ex)
        //        {
        //            cnn.Rollback();
        //            throw new Exception("Ekleme işlemi başarısız oldu.", ex);
        //        }
        //        finally
        //        {
        //            cnn.Close();
        //        }
        //    }
        //}

        


       /*
         master dalataler için insert update delete işlemlerini yapan ortak bir sınıf oluştur 
        ortal oluşan sınıfta genate olması sağlanacak 

        
        */

    }
}
