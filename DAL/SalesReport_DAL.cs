using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Data;
using System.Linq;
using System.Web;

namespace IMPLDashboard.DAL
{
    public class SalesReport_DAL: BaseDataAccessLayer
    {
        public DataTable GetDailySalesReport(string p_as_on_date)
        {

            DataTable dt = new DataTable("DailySalesReport");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_GET_DAILY_SALES_REPORT");
                com.Parameters.Add("P_AS_ON_DATE", OracleType.VarChar).Value = p_as_on_date;
                com.Parameters.Add("PCURSOR", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter oraData = new OracleDataAdapter(com);
                oraData.Fill(dt);

            }
            catch
            {

            }
            finally
            {
                Dispose();
            }

            return dt;
        }


        public DataTable GetMtdSalesReport(string p_as_on_date)
        {

            DataTable dt = new DataTable("MtdSalesReport");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_GET_MTD_SALES_REPORT");
                com.Parameters.Add("P_AS_ON_DATE", OracleType.VarChar).Value = p_as_on_date;
                com.Parameters.Add("PCURSOR", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter oraData = new OracleDataAdapter(com);
                oraData.Fill(dt);

            }
            catch
            {

            }
            finally
            {
                Dispose();
            }

            return dt;
        }





    }
}