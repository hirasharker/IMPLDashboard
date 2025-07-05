using IMPLDashboard.DAL;
using System;
using System.Data;
using System.Data.OracleClient;

namespace IMPLDashboard.DAL
{
    public class Dashboard_DAL : BaseDataAccessLayer
    {


        public DataTable GetNationalKpiWiseImsValue(string p_as_on_date)
        {

            DataTable dt = new DataTable("insvalue");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_NATIONAL_FOCUS_KPI_TOTAL_IMS_VALUE");
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

        public DataTable GetNationalKpiWiseTotalMemo(string p_as_on_date)
        {

            DataTable dt = new DataTable("totalMemo");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_NATIONAL_FOCUS_KPI_TOTAL_MEMO");
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

        public DataTable GetNationalFocusCtnKpi(string p_as_on_date)
        {

            DataTable dt = new DataTable("totalMemo");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_NATIONAL_FOCUS_CTN_KPI");
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

        public DataTable GetNationalFocusMemoKpi(string p_as_on_date)
        {

            DataTable dt = new DataTable("totalMemo");

            try
            {

                OracleCommand com = GetSPCommand("PROC_IMPL_NATIONAL_FOCUS_MEMO_KPI");
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



    }
}