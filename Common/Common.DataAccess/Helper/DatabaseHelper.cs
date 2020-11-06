﻿using Common.DataAccess.Helper.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Common.DataAccess.Helper
{
    public class DatabaseHelper : IDatabaseHelper
    {
        public string StrConnection { get; set; }
        public SqlConnection sqlConnection { get; set; }

        public DatabaseHelper(IConfiguration configuration)
        {
            StrConnection = configuration["ConnectionStrings:DefaultConnection"];
        }

        public void CloseConnection()
        {
            try
            {
                if (sqlConnection == null)
                    sqlConnection = new SqlConnection(StrConnection);

                if (sqlConnection.State != ConnectionState.Closed)
                    sqlConnection.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public DataTable ExecuteSProcedure(string nameProc, params object[] paramObjects)
        {
            DataTable tb = new DataTable();
            SqlConnection connection;
            try
            {
                OpenConnection();

                SqlCommand cmd = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = nameProc };

                connection = new SqlConnection(StrConnection);
                cmd.Connection = connection;

                int parameterInput = (paramObjects.Length) / 2;

                int j = 0;
                for (int i = 0; i < parameterInput; i++)
                {
                    string paramName = Convert.ToString(paramObjects[j++]).Trim();
                    object value = paramObjects[j++];
                    cmd.Parameters.Add(new SqlParameter(paramName, value ?? DBNull.Value));
                }

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(tb);
                cmd.Dispose();
                ad.Dispose();
                connection.Dispose();
            }
            catch (Exception exception)
            {
                tb = null;
                throw exception;
            }
            finally
            {
                CloseConnection();
            }
            return tb;
        }

        public void OpenConnection()
        {
            try
            {
                if (sqlConnection == null)
                    sqlConnection = new SqlConnection(StrConnection);

                if (sqlConnection.State != ConnectionState.Open)
                    sqlConnection.Open();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
