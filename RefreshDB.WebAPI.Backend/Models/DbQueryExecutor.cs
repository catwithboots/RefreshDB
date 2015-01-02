using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using RefreshDB.Database.Framework;
using RefreshDB.WebAPI.Backend.Controllers;
using NLog;


namespace RefreshDB.WebAPI.Backend.Models
{
    public class DbQueryExecutor
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public List<string> MsSqlExecQuery(string instance, string database, string query)
        {
            string constring = "Server = " + instance + "; Database = " + database + "; Integrated Security = true; Application Name = .NET SQLClient Data Provider - RefreshDB Deployment";

            logger.Info("Using connection string {0}", constring);

            List<string> dbresults = new List<string>();

            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = query;

                    logger.Info("Connect and run {0}", query);

                    try
                    {
                        con.Open();

                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            dbresults.Add(Convert.ToString(reader[0]));
                        }

                        return dbresults;
                    }
                    catch (Exception e)
                    {

                        throw (e);
                    }
                }
            }
        }
    }
}