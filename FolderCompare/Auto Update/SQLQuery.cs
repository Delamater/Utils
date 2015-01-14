using System;
using System.Data.SqlClient;

namespace Sage.US.SBS.ERP.Sage500
{
    class SQLQuery
    {

        //
        /// <summary>
        /// It is really important when structuring your select statment 
        /// for the sqlquery parameter that it only return a single record
        /// and that it contain all of the information it needs to get to 
        /// the correct database for data retrieval.
        /// </summary>
        /// <param name="server"></param>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        /// <param name="sqlquery"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public static String ReadValue(String server, String user, String pwd, String sqlquery, String field)
        {
            String strRetVal = String.Empty;
            // validate our input parameters
            String strMessage = string.Empty;
            if (String.IsNullOrEmpty(server))
                strMessage += String.Format("QuerySQL.ReadValue [server] is empty.\n");
            if (String.IsNullOrEmpty(user))
                strMessage += String.Format("QuerySQL.ReadValue [user] is empty.\n");
            if (String.IsNullOrEmpty(pwd))
                strMessage += String.Format("QuerySQL.ReadValue [pwd] is empty.\n");
            if (String.IsNullOrEmpty(sqlquery))
                strMessage += String.Format("QuerySQL.ReadValue [sqlquery] is empty.\n");
            if (String.IsNullOrEmpty(field))
                strMessage += String.Format("QuerySQL.ReadValue [field] is empty.\n");

            if (!String.IsNullOrEmpty(strMessage))
                throw new Exception(strMessage);
            try
            {
                String sqlConnectionString = String.Format("server={0};user id={1};password={2};database=master;", server, user, pwd);
                SqlConnection sqlconnection = new SqlConnection(sqlConnectionString);
                sqlconnection.Open();

                SqlCommand sqlcommand = new SqlCommand(sqlquery, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    strRetVal = sqldatareader[field].ToString().Trim();
                }
                sqldatareader.Close();
                sqlconnection.Close();
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message, se);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }

            return strRetVal;
        }

        /// <summary>
        /// It is really important when structuring your select statment 
        /// for the sqlquery parameter that it only return a single record
        /// and that it contain all of the information it needs to get to 
        /// the correct database for data retrieval.
        /// </summary>
        /// <param name="server"></param>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        /// <param name="sqlquery"></param>
        /// <param name="field1"></param>
        /// <param name="field2"></param>
        /// <param name="out valfield1"></param>
        /// <param name="out valfield2"></param>
        /// <returns></returns>
        public static void Read2Value(String server, String user, String pwd, String sqlquery, String field1, out String valfield1, String field2, out String valfield2)
        {
            valfield1 = valfield2 = String.Empty;
            // validate our input parameters
            String strMessage = string.Empty;
            if (String.IsNullOrEmpty(server))
                strMessage += String.Format("QuerySQL.ReadValue [server] is empty.\n");
            if (String.IsNullOrEmpty(user))
                strMessage += String.Format("QuerySQL.ReadValue [user] is empty.\n");
            if (String.IsNullOrEmpty(pwd))
                strMessage += String.Format("QuerySQL.ReadValue [pwd] is empty.\n");
            if (String.IsNullOrEmpty(sqlquery))
                strMessage += String.Format("QuerySQL.ReadValue [sqlquery] is empty.\n");
            if (String.IsNullOrEmpty(field1))
                strMessage += String.Format("QuerySQL.ReadValue [field1] is empty.\n");
            if (String.IsNullOrEmpty(field2))
                strMessage += String.Format("QuerySQL.ReadValue [field2] is empty.\n");

            if (!String.IsNullOrEmpty(strMessage))
                throw new Exception(strMessage);
            try
            {
                String sqlConnectionString = String.Format("server={0};user id={1};password={2};database=master;", server, user, pwd);
                SqlConnection sqlconnection = new SqlConnection(sqlConnectionString);
                sqlconnection.Open();

                SqlCommand sqlcommand = new SqlCommand(sqlquery, sqlconnection);
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    valfield1 = sqldatareader[field1].ToString().Trim();
                    valfield2 = sqldatareader[field2].ToString().Trim();
                }
                sqldatareader.Close();
                sqlconnection.Close();
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message, se);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
