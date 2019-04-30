using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace waUser.Dal
{
      internal class DBFunctions
      {
            DataTable GetDataTable(SqlCommand cmd)
            {
              SqlDataAdapter adapter = new SqlDataAdapter();
              adapter.SelectCommand = cmd;
              DataTable dt = new DataTable();
              adapter.Fill(dt);
             
              return dt;
            }  

            #region Helper Methods

            public DataSet GetDataSet(SqlCommand cmd)
            {
              SqlDataAdapter adapter = new SqlDataAdapter();
              adapter.SelectCommand = cmd;
              DataSet ds = new DataSet();
              adapter.Fill(ds);

              return ds;
            }

            protected T VerifyAndGetScalar<T>(DataSet dataSet, T defaultVal)
            {
              if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                return (T)dataSet.Tables[0].Rows[0][0];
              else
                return defaultVal;
            }

            protected T VerifyAndGetScalar<T>(SqlDataReader reader, T defaultVal)
            {
              if (reader.Read())
                return reader[0] == DBNull.Value ? defaultVal : (T)reader[0];
              else
                return defaultVal;
            }

            protected SqlParameter Param(string name, object value, SqlDbType type)
            {
              SqlParameter param = new SqlParameter(name, value);
              param.SqlDbType = type;
              return param;
            }

            protected SqlCommand NewCommand(SqlConnection connection, string text, CommandType type, params SqlParameter[] parameters)
            {
              var command = new SqlCommand(text, connection);
              command.CommandType = type;
              command.Parameters.AddRange(parameters);
              return command;
            }

            protected SqlConnection NewConnection()
            {
              var connection = new SqlConnection(ConnectionString);

              return connection;
            }

            private protected string ConnectionString
            {
                get {
                        var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");

                        var configuration = builder.Build();

                        return configuration.GetConnectionString("SqlServer");

                    }
            }

           #endregion

        }
}