using IMLDashboard.Controllers;
using IMPLDashboard.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMPLDashboard.Controllers
{
    public class DashboardController : BaseController
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public string DashboardHeaderJson(String dt)
        {
            String date;
            if (dt == null)
            {
                DateTime dateTime = DateTime.Now;
                date = dateTime.ToString("yyyy-MM-dd");
            }
            else
            {
                date = dt;
            }

            DataTable tableData = new Dashboard_DAL().GetDashboardHeader(date);

            tableData.AsEnumerable();

            string x = RenderPartialViewToString("DashboardHeaderPartial", tableData);

            return x;
        }

        [HttpGet]
        public string NationWiseSkuKpiJson(String dt)
        {
            String date;
            if (dt == null)
            {
                DateTime dateTime = DateTime.Now;
                date = dateTime.ToString("yyyy-MM-dd");
            }
            else
            {
                date = dt;
            }

            DataTable tableData = new Dashboard_DAL().GetNationalKpiWiseImsValue(date);

            DataTable tableData2 = new Dashboard_DAL().GetNationalKpiWiseTotalMemo(date);

            DataTable tableData3 = new Dashboard_DAL().GetNationalFocusCtnKpi(date);

            DataTable tableData4 = new Dashboard_DAL().GetNationalFocusMemoKpi(date);

            DataTable tableData5 = new Dashboard_DAL().GetNationalFocusKpiBounceRatio(date);

            tableData.AsEnumerable();

            string x = RenderPartialViewToStringQuadrapoleData("NationalWiseSkuKpiPartial", tableData, tableData2, tableData3, tableData4, tableData5);

            return x;
        }

        [HttpGet]
        public string OwnDbWiseSkuKpiJson(String dt)
        {
            String date;
            if (dt == null)
            {
                DateTime dateTime = DateTime.Now;
                date = dateTime.ToString("yyyy-MM-dd");
            }
            else
            {
                date = dt;
            }

            DataTable tableData = new Dashboard_DAL().GetNationalKpiWiseImsValue(date);

            DataTable tableData2 = new Dashboard_DAL().GetNationalKpiWiseTotalMemo(date);

            DataTable tableData3 = new Dashboard_DAL().GetNationalFocusCtnKpi(date);

            DataTable tableData4 = new Dashboard_DAL().GetNationalFocusMemoKpi(date);

            DataTable tableData5 = new Dashboard_DAL().GetNationalFocusKpiBounceRatio(date);

            tableData.AsEnumerable();

            string x = RenderPartialViewToStringQuadrapoleData("NationalWiseSkuKpiPartial", tableData, tableData2, tableData3, tableData4, tableData5);

            return x;
        }









    }
}