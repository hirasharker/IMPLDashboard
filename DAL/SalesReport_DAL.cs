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

        public DataTable GetMOMSalesReport(string p_as_on_date)
        {

            DataTable dt = new DataTable("MOMSalesReport");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_GET_MOM_SALES_REPORT");
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


        public DataTable GetBestSellingProducts(string p_as_on_date)
        {

            DataTable dt = new DataTable("MOMSalesReport");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_GET_SELLING_PRODUCTS");
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



        internal DataTable get_best_selling_products(string p_date_from, string p_date_to)
        {

            DataTable dt = new DataTable("best_selling_products");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_BEST_SELLING_PRODUCTS");
                com.Parameters.Add("p_date_from", OracleType.VarChar).Value = p_date_from;
                com.Parameters.Add("p_date_to", OracleType.VarChar).Value = p_date_to;
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

        internal DataTable get_top_sellers(string p_date_from, string p_date_to)
        {

            DataTable dt = new DataTable("top_sellers");

            try
            {
                OracleCommand com = GetSPCommand("PROC_IMPL_TOP_SELLERS");
                com.Parameters.Add("p_date_from", OracleType.VarChar).Value = p_date_from;
                com.Parameters.Add("p_date_to", OracleType.VarChar).Value = p_date_to;
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