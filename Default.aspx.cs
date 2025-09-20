using dbConnectionTest;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationBusiness.Il;
using WebApplicationBusiness.Semt;
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

            //string sqlAlter ="ALTER TABLE ULKE  ADD kolonadı int  DEFAULT 1";
            //       //  ihtiyaca göre sekıllendir


            //var cmdAlter = cnn.CreateCommand(sql, CommandType.Text);
            //cnn.ExecuteNonQuery(cmdAlter);
            //cnn.Commit();  // yeni bir kolon eklmek istersem

            //UlkeBusiness ub = new UlkeBusiness();
            //Ulke u1 = new Ulke { UlkeAd = "YUNANİSTAN" };
            //ub.AddUlke(u1);
            //Ulke u2 = new Ulke { UlkeAd = "KOLOMBİYA", UlkeId = 1013 };
            //ub.UpdateUlke(u2);
            //ub.DeleteUlke(1010);
            //IlBusiness ib = new IlBusiness();
            //Il i1 = new Il { IlAd = "PAOK", UlkeId = 1015 };
            //ib.AddIl(i1);
            //Il i2 = new Il { IlAd = "ANKARA", IlId = 17 };
            //ib.UpdateIl(i2);
            //ib.DeleteIl(19);
            //cnn.Commit();


            //SemtBusiness sb = new SemtBusiness();
            //Semt s1 = new Semt { IlceId = 1, SemtAd = "LOLO" };
            //sb.AddSemt(s1);
            //Semt s2 = new Semt { SemtAd = "YENİMAHALLE", SemtId = 2 };
            //sb.UpdateSemt(s2);
            //sb.DeleteSemt(8);
            //cnn.Commit();




            //var spCmd = cnn.CreateCommand("GetAllUlke", CommandType.StoredProcedure); // ulkelerş getir procedur
            //DataTable spDt = cnn.Execute(spCmd);
            //GridView1.DataSource = spDt;
            //GridView1.DataBind();
            // cnn.Commit();

            //string[] ulkeler = { "ŞİLİ", "ARJANTİN", "KOSTA RİKA" }; // ekle procedur
            // foreach (var s in ulkeler)
            //{
            //    var Spcmd= cnn.CreateCommand("ParamAddUlke", CommandType.StoredProcedure);
            //    IDbDataParameter parameter = Spcmd.CreateParameter();
            //    parameter.ParameterName ="@UlkeAd";
            //    parameter.Value = s;
            //    Spcmd.Parameters.Add(parameter);
            //    cnn.Execute(Spcmd);

            //}

            //int[] Ulkeıd = { 9, 13, 15, 1019, 1020, 1021 }; // bu degerleri sıl procedur
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

            //string sql = "SELECT * FROM ULKE WHERE UlkeId BETWEEN 1010 AND 1020"; // arasından ki degrkeri cagırma
            //var cmd = cnn.CreateCommand(sql, CommandType.Text);
            //DataTable ddt = cnn.Execute(cmd);
            //GridView1.DataSource = ddt;
            //GridView1.DataBind(); // aralık sorgusu

            // int ulkeId = 1; // Örnek ülke ID
            // var cmd = cnn.CreateCommand("SELECT dbo.GetCityCountByCountry(@UlkeId)", CommandType.Text); // fonsksuyon cagırma
            // var param = cmd.CreateParameter();
            // param.ParameterName = "@UlkeId";
            // param.Value = ulkeId;
            // cmd.Parameters.Add(param);
            // int IlCount = Convert.ToInt32(cnn.ExecuteScalar(cmd));



            // int ulkeIdıl = 1; 
            // var cmdIl = cnn.CreateCommand("SELECT * FROM dbo.GetCitiesByCountry(@UlkeId)", CommandType.Text); // fonsksıyon cagırma
            // var prm = cmdIl.CreateParameter();
            //prm.ParameterName = "@UlkeId";
            // prm.Value = ulkeIdıl;
            // cmdIl.Parameters.Add(prm);

            // DataTable dtIl = cnn.Execute(cmdIl);
            // GridView1.DataSource = dtIl;
            // GridView1.DataBind(); 

            //var spCmd = cnn.CreateCommand("UpdateUlkeAdBuyuk", CommandType.StoredProcedure); // procedur cagırma

            //var param = spCmd.CreateParameter();
            //param.ParameterName = "@UlkeId";
            //param.Value = 1023;
            //spCmd.Parameters.Add(param);

            //cnn.Execute(spCmd);  
            //cnn.Commit();

            //DataTable dtu = cnn.Execute(spCmd);


            //        string sql = @"
            //    SELECT IL.IlId, IL.IlAd, ULKE.UlkeAd
            //    FROM IL
            //    INNER JOIN ULKE ON IL.UlkeId = ULKE.UlkeId
            //    WHERE IL.UlkeId = @UlkeId
            //";
            //        var cmd = cnn.CreateCommand(sql, CommandType.Text);
            //        var param = cmd.CreateParameter();
            //        param.ParameterName = "@UlkeId";
            //        param.Value = 1; 
            //        cmd.Parameters.Add(param);

            //        DataTable dtt = cnn.Execute(cmd);
            //        foreach (DataRow row in dt.Rows)
            //        {
            //            System.Diagnostics.Debug.WriteLine(row["IlAd"].ToString());
            //        }

            //        GridView1.DataSource = dtt;
            //         GridView1.DataBind(); 
            //var cmd = cnn.CreateCommand("GetTotalCityCount", CommandType.StoredProcedure);
            //DataTable dtsp = cnn.Execute(cmd);


            //var cmdt = cnn.CreateCommand("GetCityCountByCountry", CommandType.StoredProcedure);

            //var param = cmd.CreateParameter();
            //param.ParameterName = "@UlkeId";
            //param.Value = 1;
            //cmd.Parameters.Add(param);

            //DataTable dtp = cnn.Execute(cmd);
        }
        protected void btnGetirSehir_Click(object sender, EventArgs e)
        {
            string newulke = txtUlkeAdı.Text.Trim();
            var cnn = new ConnectionTest();

            string sql = "SELECT * FROM GetIllerByUlkeAdi(@UlkeAd)";
            var cmd = cnn.CreateCommand(sql, CommandType.Text);

            var param = cmd.CreateParameter();
            param.ParameterName = "@UlkeAd";
            param.Value = newulke;
            cmd.Parameters.Add(param);
            DataTable dt = new DataTable();
            using (var reader = cmd.ExecuteReader())
            {
                if (reader != null)
                {
                    dt.Load(reader);
                }
            }

            GridView3.DataSource = dt;
            GridView3.DataBind();

            cnn.Dispose();
        }

        protected void btnAddIl_Click(object sender, EventArgs e)
        {
            string newIl = txtIlAd.Text.Trim();
            int newulkeıd =  int.Parse(txtUlkeIdd.Text);
            var cnn = new ConnectionTest();
            var cmd = cnn.CreateCommand("ParamAddIl", CommandType.StoredProcedure);
            var param1 = cmd.CreateParameter();
            param1.ParameterName = "@IlAd";
            param1.Value = newIl;
            cmd.Parameters.Add(param1);
            var param2 = cmd.CreateParameter();
            param2.ParameterName = "@UlkeId";
            param2.Value = newulkeıd;
            cmd.Parameters.Add(param2);

            cnn.Execute(cmd);
            cnn.Commit();

            txtIlAd.Text = "";
            txtUlkeIdd.Text= "";

            LoadGridIl();

        }


        protected void btnAddUlke_Click(object sender, EventArgs e)
        {
            string newCountry = txtUlkeAd.Text.Trim();
         
            var cnn = new ConnectionTest();
            var cmd = cnn.CreateCommand("ParamAddUlke", CommandType.StoredProcedure);
            var param1 = cmd.CreateParameter();
            param1.ParameterName = "@UlkeAd";
            param1.Value = newCountry;
            cmd.Parameters.Add(param1);

            cnn.Execute(cmd);
            cnn.Commit();

            cnn.Dispose();

            txtUlkeAd.Text = "";
            LoadGrid();
        }
        protected void btnDeleteUlke_Click(object sender, EventArgs e)
        {
            int ulkeId = Convert.ToInt32(txtUlkeId.Text);

            var cnn = new ConnectionTest();

            var cmd = cnn.CreateCommand("ParamDeleteUlke", CommandType.StoredProcedure);
            var param = cmd.CreateParameter();
            param.ParameterName = "@UlkeId";
            param.Value = ulkeId;
            cmd.Parameters.Add(param);

            cnn.Execute(cmd);
            cnn.Commit();

            cnn.Dispose();

            txtUlkeId.Text = "";
            LoadGrid();
        }

        public void LoadGrid()
        {
            using (var cnn = new ConnectionTest())
            {
                var cmd = cnn.CreateCommand("SELECT * FROM ULKE", CommandType.Text);
                DataTable dt = cnn.Execute(cmd);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        public void LoadGridIl()
        {
            using (var cnn = new ConnectionTest())
            {
                var cmd = cnn.CreateCommand("SELECT * FROM Il", CommandType.Text);
                DataTable dt = cnn.Execute(cmd);
                GridView4.DataSource = dt;
                GridView4.DataBind();
            }
        }
    }

}