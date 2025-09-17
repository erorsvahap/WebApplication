using dbConnectionTest;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationBusiness.Il;
using WebApplicationBusiness.Ulke;

namespace WebApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dbConnectionTest.ConnectionTest cnn = new dbConnectionTest.ConnectionTest();
            DataTable dt = new DataTable();


            //string sql = "select * from ULKE";
            //var cmd = cnn.CreateCommand(sql, CommandType.Text);
            //dt = cnn.Execute(cmd); // debung üzerinedn test edıldı

            //string sqlCount = "SELECT COUNT(*) FROM ULKE";
            //var cmdCount = cnn.CreateCommand(sqlCount, CommandType.Text);
            //cnn.ExecuteScalar(cmdCount); // debung üzerinedn test edıldı

            //string sqlAlter = @"ALTER TABLE ULKE 
            //          ADD kolonadı int  DEFAULT 1;
            //         ihtiyaca göre sekıllendir


            //var cmdAlter = cnn.CreateCommand(sql, CommandType.Text);
            //cnn.EXECUTE_NONQUERY(cmd);
            //cnn.Commit();  // yeni bir kolon eklmek istersem

            //UlkeBusiness ub = new UlkeBusiness();
            //Ulke u1 = new Ulke { UlkeAd = "YUNANİSTAN" };
            //ub.AddUlke(u1);
            //Ulke u2 = new Ulke { UlkeAd = "KOLOMBİYA", UlkeId = 1013 };
            //ub.UpdateUlke(u2);
            //ub.DeleteUlke(1010);
            //IlBusiness ib = new IlBusiness();
            //Il i1 = new Il { IlAd = "PAOK", UlkeId = 1015 };
            //ib.AddıL(i1);
            //Il i2 = new Il { IlAd = "SİVAS", IlId = 15 };
            //ib.UpdateIl(i2);
            //ib.DeleteIl(20);



            //var spCmd = cnn.CreateCommand("GetAllUlke", CommandType.StoredProcedure);
            //DataTable spDt = cnn.Execute(spCmd);
            //GridView1.DataSource = spDt;
            //GridView1.DataBind();
            // cnn.Commit();

            //string[] ulkeler = { "ŞİLİ", "ARJANTİN", "KOSTA RİKA" };
            // foreach (var s in ulkeler)
            //{
            //    var Spcmd= cnn.CreateCommand("ParamAddUlke", CommandType.StoredProcedure);
            //    IDbDataParameter parameter = Spcmd.CreateParameter();
            //    parameter.ParameterName ="@UlkeAd";
            //    parameter.Value = s;
            //    Spcmd.Parameters.Add(parameter);
            //    cnn.Execute(Spcmd);

            //}

            //int[] Ulkeıd = { 9, 13, 15, 1019, 1020, 1021 };
            //foreach (var v in Ulkeıd)
            //{

            //    var Spcmd = cnn.CreateCommand("ParamDeleteUlke", CommandType.StoredProcedure);
            //    IDbDataParameter parameter = Spcmd.CreateParameter();
            //    parameter.ParameterName = "@UlkeId";
            //    parameter.Value = v;
            //    Spcmd.Parameters.Add(parameter);
            //    cnn.Execute(Spcmd);    // sp deleteulke denemesi


            //}
            //cnn.Commit();

            //string sql = "SELECT * FROM ULKE WHERE UlkeId BETWEEN 1010 AND 1020";
            //var cmd = cnn.CreateCommand(sql, CommandType.Text);
            //DataTable ddt = cnn.Execute(cmd);
            //GridView1.DataSource = ddt;
            //GridView1.DataBind(); // aralık sorgusu






        }
    }
}