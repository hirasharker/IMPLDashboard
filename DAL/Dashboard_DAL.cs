using IMPLDashboard.DAL;
using System;
using System.Data;
using System.Data.OracleClient;
using System.Security.RightsManagement;

namespace IMPLDashboard.DAL
{
    public class Dashboard_DAL : BaseDataAccessLayer
    {

        public DataTable GetRegion(string region_id)
        {
            DataTable dt = new DataTable("region");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_GET_REGION");
                com.Parameters.Add("p_region_id", OracleType.VarChar).Value = region_id;
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

        public DataTable GetAreaByRegion(string region_id)
        {
            DataTable dt = new DataTable("region");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_GET_AREA_BY_REGION_ID");
                com.Parameters.Add("p_region_id", OracleType.VarChar).Value = region_id;
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

        public DataTable GetDashboardHeader(string p_as_on_date)
        {

            DataTable dt = new DataTable("dashboardHeader");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_DASHBOARD_HEADER");
                com.Parameters.Add("p_as_on_date", OracleType.VarChar).Value = p_as_on_date;
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


        public DataTable GetNationalKpiWiseImsValue(string p_as_on_date, string region_id, string area_id)
        {

            DataTable dt = new DataTable("insvalue");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_NATIONAL_FOCUS_KPI_TOTAL_IMS_VALUE");
                com.Parameters.Add("p_as_on_date", OracleType.VarChar).Value = p_as_on_date;
                com.Parameters.Add("p_region_id", OracleType.VarChar).Value = region_id;
                com.Parameters.Add("p_area_id", OracleType.VarChar).Value = area_id;
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

        public DataTable GetNationalKpiWiseTotalMemo(string p_as_on_date, string region_id, string area_id)
        {

            DataTable dt = new DataTable("totalMemo");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_NATIONAL_FOCUS_KPI_TOTAL_MEMO");
                com.Parameters.Add("p_as_on_date", OracleType.VarChar).Value = p_as_on_date;
                com.Parameters.Add("p_region_id", OracleType.VarChar).Value = region_id;
                com.Parameters.Add("p_area_id", OracleType.VarChar).Value = area_id;
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

        public DataTable GetNationalFocusCtnKpi(string p_as_on_date, string region_id, string area_id)
        {

            DataTable dt = new DataTable("totalMemo");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_NATIONAL_FOCUS_CTN_KPI");
                com.Parameters.Add("p_as_on_date", OracleType.VarChar).Value = p_as_on_date;
                com.Parameters.Add("p_region_id", OracleType.VarChar).Value = region_id;
                com.Parameters.Add("p_area_id", OracleType.VarChar).Value = area_id;
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

        public DataTable GetNationalFocusMemoKpi(string p_as_on_date, string region_id, string area_id)
        {

            DataTable dt = new DataTable("totalMemo");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_NATIONAL_FOCUS_MEMO_KPI");
                com.Parameters.Add("p_as_on_date", OracleType.VarChar).Value = p_as_on_date;
                com.Parameters.Add("p_region_id", OracleType.VarChar).Value = region_id;
                com.Parameters.Add("p_area_id", OracleType.VarChar).Value = area_id;
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

        public DataTable GetNationalFocusKpiBounceRatio(string p_as_on_date)
        {

            DataTable dt = new DataTable("totalMemo");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_NATIONAL_FOCUS_KPI_BOUNCE_RATIO");
                com.Parameters.Add("p_as_on_date", OracleType.VarChar).Value = p_as_on_date;
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


        public DataTable GetOwnDbKpiWiseImsValue(string p_as_on_date)
        {

            DataTable dt = new DataTable("insvalue");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_OWNDB_FOCUS_KPI_TOTAL_IMS_VALUE");
                com.Parameters.Add("p_as_on_date", OracleType.VarChar).Value = p_as_on_date;
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

        public DataTable GetOwnDbKpiWiseTotalMemo(string p_as_on_date, string region_id, string area_id)
        {

            DataTable dt = new DataTable("totalMemo");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_NATIONAL_FOCUS_KPI_TOTAL_MEMO");
                com.Parameters.Add("p_as_on_date", OracleType.VarChar).Value = p_as_on_date;
                com.Parameters.Add("p_region_id", OracleType.VarChar).Value = region_id;
                com.Parameters.Add("p_area_id", OracleType.VarChar).Value = area_id;
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

        public DataTable GetOwnDbFocusCtnKpi(string p_as_on_date)
        {

            DataTable dt = new DataTable("totalMemo");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_OWNDB_CTN_KPI");
                com.Parameters.Add("p_as_on_date", OracleType.VarChar).Value = p_as_on_date;
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

        public DataTable GetOwnDbFocusMemoKpi(string p_as_on_date)
        {

            DataTable dt = new DataTable("totalMemo");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_OWNDB_MEMO_KPI");
                com.Parameters.Add("p_as_on_date", OracleType.VarChar).Value = p_as_on_date;
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

        public DataTable GetOwnDbFocusKpiBounceRatio(string p_as_on_date)
        {

            DataTable dt = new DataTable("totalMemo");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_OWNDB_FOCUS_KPI_BOUNCE_RATIO");
                com.Parameters.Add("p_as_on_date", OracleType.VarChar).Value = p_as_on_date;
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

        public DataTable GetNationWisePrimaryVsSecondaryData(string date, string region_id, string area_id)
        {

            DataTable dt = new DataTable("totalMemo");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_PRIMARY_SECONDARY_SALES_TARGET");
                com.Parameters.Add("p_as_on_date", OracleType.VarChar).Value = date;
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


        public DataTable GetOutletInfo(string p_region_id = "", string p_area_id = "", string p_teritorry_id = "'", string p_dealer_id = "")
        {

            DataTable dt = new DataTable("outletInfo");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_OUTLET_INFO");
                com.Parameters.Add("P_REGION_ID", OracleType.Number).Value = Convert.ToInt16(p_region_id);
                com.Parameters.Add("P_AREA_ID", OracleType.Number).Value = Convert.ToInt16(p_area_id);
                com.Parameters.Add("P_TERITORRY_ID", OracleType.Number).Value = Convert.ToInt16(p_teritorry_id);
                com.Parameters.Add("P_DEALER_ID", OracleType.Number).Value = Convert.ToInt16(p_dealer_id);
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


        public DataTable GetOutletCount()
        {

            DataTable dt = new DataTable("outletCount");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_OUTLET_COUNT");
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


        public DataTable GetProductSalesM2MComparison(string as_on_date, string region_id, string area_id, string category_id, string focus_category_id)
        {

            DataTable dt = new DataTable("ProductSalesM2MComparison");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_PRODUCT_SALES_M2M_COMPARISON");
                com.Parameters.Add("p_as_on_date", OracleType.VarChar).Value = as_on_date;
                com.Parameters.Add("p_region_id", OracleType.VarChar).Value = region_id;
                com.Parameters.Add("p_area_id", OracleType.VarChar).Value = area_id;
                com.Parameters.Add("p_category_id", OracleType.VarChar).Value = category_id;
                com.Parameters.Add("p_focus_category_id", OracleType.VarChar).Value = focus_category_id;
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