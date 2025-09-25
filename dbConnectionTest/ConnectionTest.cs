using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace dbConnectionTest
{
    public class ConnectionTest : IDisposable
    {
        string _connectionstring;
        IDbConnection _connection;
        IDbTransaction _transaction;
        public ConnectionTest()
        {
            this._connectionstring = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString.ToString();
                //"Data Source=DESKTOP-1DT9AO1\\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True;";
            this._connection = new SqlConnection(this._connectionstring);
            this._connection.Open();
            this._transaction = this._connection.BeginTransaction();

        }

        public IDbTransaction IDbTransaction { get { return _transaction; } }
        public IDbConnection IDbConnection { get { return _connection; } }
        public void Open()
        {
            if (_connection.State != ConnectionState.Open && _connection != null)
            {

                _connection.Open();
            }
        }

        public void Close()
        {
            if (_connection.State != ConnectionState.Closed && _connection != null)
            {

                _connection.Close();
            }
        }
        public IDbCommand CreateCommand(string sql, CommandType type)
        {
            IDbCommand cmd = _connection.CreateCommand();
            cmd.Transaction = _transaction;
            cmd.CommandType = type;
            
            cmd.CommandText = sql;
            if (_transaction != null)
            {
                cmd.Transaction = _transaction;
            }
            return cmd;

        }
        public void Rollback()
        {
            if (_transaction != null)
            { _transaction.Rollback(); }
        }
        public void Commit()
        {
            if (_transaction != null)
            {
                _transaction.Commit();

            }
          
        }
        public DataTable Execute(IDbCommand cmd)
        {
            DataTable datatable = new DataTable();
            datatable.Load(cmd.ExecuteReader());

            return datatable;
        }
        public int ExecuteNonQuery(IDbCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }
        public object ExecuteScalar(IDbCommand cmd)
        {
            var result = cmd.ExecuteScalar().ToString();

            return result;
        }
        public void Dispose()
        {
            _connection.Dispose();
            _transaction.Dispose();
            _connection = null;
            _transaction = null;
        }
    }
}
