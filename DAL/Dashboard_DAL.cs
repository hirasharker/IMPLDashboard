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

        public DataSet GetNationalFocusKpi(string p_as_on_date, string region_id, string area_id)
        {

            DataSet ds = new DataSet();

            try
            {
                // IMPLDB.PROC_IMPL_NATIONAL_FOCUS_KPI ( P_AS_ON_DATE, P_REGION_ID, P_AREA_ID, PCURSOR_TOTAL_IMS_VALUE, PCURSOR_TOTAL_MEMO, PCURSOR_CTN_KPI, PCURSOR_MEMO_KPI, PCURSOR_BOUNCE_RATIO );
                OracleCommand com = GetSPCommand("PROC_IMPL_NATIONAL_FOCUS_KPI");
                com.Parameters.Add("p_as_on_date", OracleType.VarChar).Value = p_as_on_date;
                com.Parameters.Add("p_region_id", OracleType.VarChar).Value = region_id;
                com.Parameters.Add("p_area_id", OracleType.VarChar).Value = area_id;
                com.Parameters.Add("PCURSOR_TOTAL_IMS_VALUE", OracleType.Cursor).Direction = ParameterDirection.Output;
                com.Parameters.Add("PCURSOR_TOTAL_MEMO", OracleType.Cursor).Direction = ParameterDirection.Output;
                com.Parameters.Add("PCURSOR_CTN_KPI", OracleType.Cursor).Direction = ParameterDirection.Output;
                com.Parameters.Add("PCURSOR_MEMO_KPI", OracleType.Cursor).Direction = ParameterDirection.Output;
                com.Parameters.Add("PCURSOR_BOUNCE_RATIO", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter oraData = new OracleDataAdapter(com);

                oraData.Fill(ds);
            }
            catch
            {

            }
            finally
            {
                Dispose();
            }

            return ds;
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

        public DataTable GetNationWisePrimaryVsSecondaryData(string date, string channel, string area_id)
        {

            DataTable dt = new DataTable("totalMemo");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_PRIMARY_SECONDARY_SALES_TARGET");
                com.Parameters.Add("p_as_on_date", OracleType.VarChar).Value = date;
                com.Parameters.Add("p_division", OracleType.VarChar).Value = "";
                com.Parameters.Add("p_channel", OracleType.VarChar).Value = channel;
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


        public DataTable GetOutletInfo(string p_region_id = "", string p_area_id = "", string p_teritorry_id = "'", string p_dealer_id = "", string p_town_id = "", string p_route_id = "")
        {
            p_region_id = p_region_id == "null" ? null : p_region_id;
            p_area_id = p_area_id == "null" ? null : p_area_id;
            p_teritorry_id = p_teritorry_id == "null" ? null : p_teritorry_id;
            p_dealer_id = p_dealer_id == "null" ? null : p_dealer_id;
            p_town_id = p_town_id == "null" ? null : p_town_id;
            p_route_id = p_route_id == "null" ? null : p_route_id;

            DataTable dt = new DataTable("outletInfo");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_OUTLET_INFO");
                com.Parameters.Add("P_REGION_ID", OracleType.Number).Value = Convert.ToInt16(p_region_id);
                com.Parameters.Add("P_AREA_ID", OracleType.Number).Value = Convert.ToInt16(p_area_id);
                com.Parameters.Add("P_TERITORRY_ID", OracleType.Number).Value = Convert.ToInt16(p_teritorry_id);
                com.Parameters.Add("P_DEALER_ID", OracleType.Number).Value = Convert.ToInt16(p_dealer_id);
                com.Parameters.Add("P_TOWN_ID", OracleType.Number).Value = Convert.ToInt16(p_town_id);
                com.Parameters.Add("P_ROUTE_ID", OracleType.Number).Value = Convert.ToInt16(p_route_id);
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


        public DataTable GetProductSalesM2MComparison(string as_on_date, string region_id, string area_id, string territory_id, string dealer_id, string outlet_id, string category_id, string focus_category_id)
        {

            DataTable dt = new DataTable("ProductSalesM2MComparison");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_PRODUCT_SALES_M2M_COMPARISON");
                com.Parameters.Add("p_as_on_date", OracleType.VarChar).Value = as_on_date;
                com.Parameters.Add("p_region_id", OracleType.VarChar).Value = region_id;
                com.Parameters.Add("p_area_id", OracleType.VarChar).Value = area_id;
                com.Parameters.Add("p_territory_id", OracleType.VarChar).Value = territory_id;
                com.Parameters.Add("p_dealer_id", OracleType.VarChar).Value = dealer_id;
                com.Parameters.Add("p_outlet_id", OracleType.VarChar).Value = outlet_id;
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



        internal DataTable GetFieldStructureSalesInTP(string p_date_to, string region_id, string area_id)
        {
            DataTable dt = new DataTable("FieldStructureSalesInTP");

            p_date_to = p_date_to == null ? DateTime.Now.ToString("yyyy--dd") : p_date_to.ToString();
            try
            {

                OracleCommand com = GetSPCommand("proc_region_to_dealer_tp_sales");
                com.Parameters.Add("p_as_on_date", OracleType.VarChar).Value = p_date_to;
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



        internal DataTable getMoMBusinessProgress(string p_date_to, string mom_channel, string p_no_months, string p_cd = "")
        {
            DataTable dt = new DataTable("MoMBusinessProgressInTP");

            try
            {

                OracleCommand com = GetSPCommand("PROC_MOM_BUSINESS_PROGRESS");
                com.Parameters.Add("P_DATE_TO", OracleType.VarChar).Value = p_date_to;
                com.Parameters.Add("P_CHANNEL", OracleType.VarChar).Value = mom_channel;
                com.Parameters.Add("P_NO_MONTHS", OracleType.VarChar).Value = p_no_months;
                com.Parameters.Add("P_CD", OracleType.VarChar).Value = p_cd;
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


        internal DataTable getMoMFocusCatBusinessProgress(string p_date_to, string mom_channel, string p_no_months)
        {
            DataTable dt = new DataTable("MoMBusinessProgressInTP");

            try
            {

                OracleCommand com = GetSPCommand("PROC_MOM_FOCUS_CAT_BUSINESS_PROGRESS");
                com.Parameters.Add("P_DATE_TO", OracleType.VarChar).Value = p_date_to;
                com.Parameters.Add("P_CHANNEL", OracleType.VarChar).Value = mom_channel;
                com.Parameters.Add("P_NO_MONTHS", OracleType.VarChar).Value = p_no_months;
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


        internal DataTable getMoMEcoMemoBusinessProgress(string p_date_to, string mom_channel, string p_no_months)
        {
            DataTable dt = new DataTable("MoMEcoMemoBusinessProgressInTP");

            try
            {

                OracleCommand com = GetSPCommand("PROC_MOM_ECO_MEMO_BUSINESS_PROGRESS");
                com.Parameters.Add("P_DATE_TO", OracleType.VarChar).Value = p_date_to;
                com.Parameters.Add("P_CHANNEL", OracleType.VarChar).Value = mom_channel;
                com.Parameters.Add("P_NO_MONTHS", OracleType.VarChar).Value = p_no_months;
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


        internal DataTable getMoMRegionEcoMemoBusinessProgress(string p_date_to, string mom_channel, string p_no_months)
        {
            DataTable dt = new DataTable("MoMRegionEcoMemoBusinessProgressInTP");

            try
            {

                OracleCommand com = GetSPCommand("PROC_MOM_REGION_ECO_MEMO_BUSINESS_PROGRESS");
                com.Parameters.Add("P_DATE_TO", OracleType.VarChar).Value = p_date_to;
                com.Parameters.Add("P_CHANNEL", OracleType.VarChar).Value = mom_channel;
                com.Parameters.Add("P_NO_MONTHS", OracleType.VarChar).Value = p_no_months;
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


        internal DataTable getQuarterlyBusinessTrend(string p_date_to, string mom_channel, string p_no_months)
        {
            DataTable dt = new DataTable("QuarterlyBusinessTrend");

            try
            {

                OracleCommand com = GetSPCommand("PROC_QUARTERLY_BUSINESS_TREND");
                com.Parameters.Add("P_DATE_TO", OracleType.VarChar).Value = p_date_to;
                com.Parameters.Add("P_CHANNEL", OracleType.VarChar).Value = mom_channel;
                com.Parameters.Add("P_NO_MONTHS", OracleType.VarChar).Value = p_no_months;
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

        internal DataTable getSalesStatusRouteWise(string p_date_to, string mom_channel, string p_no_months, string dealer_id, string p_limit = "0")
        {
            DataTable dt = new DataTable("SalesStatusRouteWise");

            try
            {

                OracleCommand com = GetSPCommand("PROC_SALES_STATUS_ROUTE_WISE");
                com.Parameters.Add("P_DATE_TO", OracleType.VarChar).Value = p_date_to;
                com.Parameters.Add("P_CHANNEL", OracleType.VarChar).Value = mom_channel;
                com.Parameters.Add("P_NO_MONTHS", OracleType.VarChar).Value = p_no_months;
                com.Parameters.Add("P_DEALER_ID", OracleType.VarChar).Value = dealer_id;
                com.Parameters.Add("P_LIMIT", OracleType.VarChar).Value = p_limit;
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

        internal DataTable getRegionSalesTargetAchieve(string p_date_to)
        {
            DataTable dt = new DataTable("RegionSalesTargetAchieve");

            try
            {

                OracleCommand com = GetSPCommand("PROC_REGION_SALES_TARGET_ACHIEVE");
                com.Parameters.Add("p_as_on_date", OracleType.VarChar).Value = p_date_to;
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