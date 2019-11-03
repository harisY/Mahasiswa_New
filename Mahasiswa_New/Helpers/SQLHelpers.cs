using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Mahasiswa_New.Helpers
{
    public class SQLHelpers
    {
        public static TransactionHelper gh_Trans;
        public static string strConn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static DataTable GetDataTable(string pQuery, int pTimeOut = 3000)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter da = null;
            
            try
            {
                if (gh_Trans != null && gh_Trans.Command != null)
                {
                    gh_Trans.Command.CommandType = CommandType.Text;
                    gh_Trans.Command.CommandText = pQuery;
                    gh_Trans.Command.CommandTimeout = pTimeOut;
                    da = new SqlDataAdapter(gh_Trans.Command);
                    //da.Fill(dta);
                    da.Fill(dta);
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection())
                    {
                        conn.ConnectionString = strConn;
                        conn.Open();
                        da = new SqlDataAdapter(pQuery, conn);
                        da.Fill(dta);
                    }
                }
                da = null;
                return dta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ExecQuery(string pQuery, int pTimeOut = 30)
        {
            int pRowAff = -1;
            try
            {
                if (gh_Trans != null && gh_Trans.Command != null)
                {
                    gh_Trans.Command.CommandType = CommandType.Text;
                    gh_Trans.Command.CommandText = pQuery;
                    gh_Trans.Command.CommandTimeout = pTimeOut;
                    pRowAff = gh_Trans.Command.ExecuteNonQuery();
                }
                else
                {
                    using (SqlConnection Conn1 = new SqlConnection())
                    {
                        Conn1.ConnectionString = strConn;
                        SqlCommand cmd = new SqlCommand(pQuery, Conn1);
                        cmd.CommandTimeout = pTimeOut;
                        Conn1.Open();
                        pRowAff = cmd.ExecuteNonQuery();
                    }
                }
                return pRowAff;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }



    public class TransactionHelper
    {
        private SqlCommand _Cmd = new SqlCommand();
        public SqlCommand Command
        {
            get
            {
                return _Cmd;
            }
            set
            {
                _Cmd = value;
            }
        }
    }

    public class StandartComboBox
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
}