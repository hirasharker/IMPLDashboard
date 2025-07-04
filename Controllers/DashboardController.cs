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

            tableData.AsEnumerable();

            string x = RenderPartialViewToStringQuadrapoleData("NationalWiseSkuKpiPartial", tableData, tableData2, tableData3, tableData4);

            return x;
        }
    }
}