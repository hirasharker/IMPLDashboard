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
            string region_id = "";

            DataTable region = new Dashboard_DAL().GetRegion(region_id);

            ViewBag.region = region;

            return View();
        }

        public JsonResult GetAreaByRegion(string region_id)
        {
            DataTable dt = new Dashboard_DAL().GetAreaByRegion(region_id);
            List<object> areaList = new List<object>();

            foreach (DataRow row in dt.Rows)
            {
                areaList.Add(new
                {
                    AREA_ID = row["AREA_ID"].ToString(),
                    AREA_NAME = row["AREA_NAME"].ToString()
                });
            }

            return Json(areaList, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public string DashboardHeaderJson(String dt)
        {
            String date;
            if (dt == "" || dt == null)
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
        public string NationWiseSkuKpiJson(String dt, string region_id, string area_id)
        {
            String date;
            if (dt == "" || dt == null)
            {
                DateTime dateTime = DateTime.Now;
                date = dateTime.ToString("yyyy-MM-dd");
            }
            else
            {
                date = dt;
            }

            if (region_id == "" || region_id == null)
            {
                region_id = "";
            }

            if (area_id == "" || area_id == null)
            {
                area_id = "";
            }


            DataTable tableData = new Dashboard_DAL().GetNationalKpiWiseImsValue(date, region_id, area_id);

            DataTable tableData2 = new Dashboard_DAL().GetNationalKpiWiseTotalMemo(date, region_id, area_id);

            DataTable tableData3 = new Dashboard_DAL().GetNationalFocusCtnKpi(date, region_id, area_id);

            DataTable tableData4 = new Dashboard_DAL().GetNationalFocusMemoKpi(date, region_id, area_id);

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

            DataTable tableData = new Dashboard_DAL().GetOwnDbKpiWiseImsValue(date);

            DataTable tableData2 = new Dashboard_DAL().GetOwnDbKpiWiseTotalMemo(date);

            DataTable tableData3 = new Dashboard_DAL().GetOwnDbFocusCtnKpi(date);

            DataTable tableData4 = new Dashboard_DAL().GetOwnDbFocusMemoKpi(date);

            DataTable tableData5 = new Dashboard_DAL().GetOwnDbFocusKpiBounceRatio(date);

            tableData.AsEnumerable();

            string x = RenderPartialViewToStringQuadrapoleData("OwnDbWiseSkuKpiPartial", tableData, tableData2, tableData3, tableData4, tableData5);

            return x;
        }









    }
}