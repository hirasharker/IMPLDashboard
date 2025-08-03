using IMLDashboard.Controllers;
using IMPLDashboard.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using IMPLDashboard.Models;
using Newtonsoft.Json;
/*using System.Drawing;*/

namespace IMPLDashboard.Controllers
{
    [Filters.AuthorizedUser]
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


        public ActionResult RegionWiseSkuKpi(String dt, string region_id, string area_id, string focus_category_id)
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

            DataSet ds = new Dashboard_DAL().GetRegionFocusKpi(date, region_id, area_id, focus_category_id);


            DataTable tableData = ds.Tables[0];
            DataTable tableData2 = ds.Tables[1];
            DataTable tableData3 = ds.Tables[2];
            DataTable tableData4 = ds.Tables[3];

            DataTable tableData5 = new Dashboard_DAL().GetNationalFocusKpiBounceRatio(date);

            DataTable region = new Dashboard_DAL().GetRegion(region_id);

            ViewBag.region = region;

            ViewBag.dataTable = tableData;
            ViewBag.dataTable2 = tableData2;
            ViewBag.dataTable3 = tableData3;
            ViewBag.dataTable4 = tableData4;
            ViewBag.dataTable5 = tableData5;

            return View();
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

            DataSet ds = new Dashboard_DAL().GetNationalFocusKpi(date, region_id, area_id);


            DataTable tableData = ds.Tables[0];
            DataTable tableData2 = ds.Tables[1];
            DataTable tableData3 = ds.Tables[2];
            DataTable tableData4 = ds.Tables[3];
            /*DataTable tableData5 = ds.Tables[4];*/

            /*DataTable tableData = new Dashboard_DAL().GetNationalKpiWiseImsValue(date, region_id, area_id);

            DataTable tableData2 = new Dashboard_DAL().GetNationalKpiWiseTotalMemo(date, region_id, area_id);

            DataTable tableData3 = new Dashboard_DAL().GetNationalFocusCtnKpi(date, region_id, area_id);

            DataTable tableData4 = new Dashboard_DAL().GetNationalFocusMemoKpi(date, region_id, area_id);*/

            /*tableData.AsEnumerable();*/

            DataTable tableData5 = new Dashboard_DAL().GetNationalFocusKpiBounceRatio(date);

            string x = RenderPartialViewToStringQuadrapoleData("NationalWiseSkuKpiPartial", tableData, tableData2, tableData3, tableData4, tableData5);

            return x;
        }

        [HttpGet]
        public string OwnDbWiseSkuKpiJson(String dt, string region_id, string area_id)
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

            DataTable tableData = new Dashboard_DAL().GetOwnDbKpiWiseImsValue(date);

            DataTable tableData2 = new Dashboard_DAL().GetOwnDbKpiWiseTotalMemo(date, region_id, area_id);

            DataTable tableData3 = new Dashboard_DAL().GetOwnDbFocusCtnKpi(date);

            DataTable tableData4 = new Dashboard_DAL().GetOwnDbFocusMemoKpi(date);

            DataTable tableData5 = new Dashboard_DAL().GetOwnDbFocusKpiBounceRatio(date);

            tableData.AsEnumerable();

            string x = RenderPartialViewToStringQuadrapoleData("OwnDbWiseSkuKpiPartial", tableData, tableData2, tableData3, tableData4, tableData5);

            return x;
        }


        [HttpGet]
        public string NationWisePrimaryVsSecondaryJson(String dt, string channel, string area_id)
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

            if (channel == "" || channel == null)
            {
                channel = "";
            }

            if (area_id == "" || area_id == null)
            {
                area_id = "";
            }


            DataTable tableData = new Dashboard_DAL().GetNationWisePrimaryVsSecondaryData(date, channel, area_id);

            DataTable tableData2 = new DataTable();

            tableData.AsEnumerable();

            string x = RenderPartialViewToStringMultipleData("NationalWisePriVsSecPartial", tableData, tableData2);

            return x;
        }


        public ActionResult OutletInMap()
        {
            // System.Data.DataTable tableData = new Dashboard_DAL().GetOutletInfo();
            System.Data.DataTable tableOutletCount = new Dashboard_DAL().GetOutletCount();

            string json = JsonConvert.SerializeObject(NestOutletData(tableOutletCount));

            ViewBag.tableOutletCount = json;
            ViewBag.data = ""; //OutletInfo();
            return View();
        }

        [HttpGet]
        public String OutletInfo(string region_id, string area_id, string territory_id, string dealer_id)
        {

            DataTable tableData = new Dashboard_DAL().GetOutletInfo(p_region_id: region_id, p_area_id: area_id, p_teritorry_id: territory_id, p_dealer_id: dealer_id);
            string json = JsonConvert.SerializeObject(tableData);
            return json;
        }

        [HttpGet]
        public String ProductSalesComparison(string p_date_to, string region_id, string area_id, string territory_id, string dealer_id, string outlet_id, string category_id, string focus_category_id)
        {
            DataTable tableData = new Dashboard_DAL().GetProductSalesM2MComparison(p_date_to, region_id, area_id, territory_id, dealer_id, outlet_id, category_id, focus_category_id);

            DataTable tableData2 = new DataTable();

            tableData.AsEnumerable();

            string x = RenderPartialViewToStringMultipleData("ProductSalesComparisonPartial", tableData, tableData2);
            return x;
        }


        public List<NationWiseKpiRegion> NestOutletData(System.Data.DataTable table)
        {
            var regionMap = new Dictionary<int, NationWiseKpiRegion>();

            foreach (DataRow row in table.Rows)
            {
                int regionId = Convert.ToInt32(row["REGION_ID"]);
                string regionName = row["REGION_NAME"].ToString();
                int areaId = Convert.ToInt32(row["AREA_ID"]);
                string areaName = row["AREA_NAME"].ToString();
                int terId = Convert.ToInt32(row["TERITORRY_ID"]);
                string terName = row["TERITORRY_NAME"].ToString();
                int townId = Convert.ToInt32(row["TOWN_ID"]);
                string townName = row["TOWN_NAME"].ToString();
                int dealerId = Convert.ToInt32(row["DEALER_ID"]);
                string dealerName = row["DEALER_NAME"].ToString();
                int routeId = Convert.ToInt32(row["ROUTE_ID"]);
                string routeName = row["ROUTE_NAME"].ToString();
                int outletCount = Convert.ToInt32(row["OUTLET_COUNT"]);

                // REGION
                if (!regionMap.TryGetValue(regionId, out var region))
                {
                    region = new NationWiseKpiRegion
                    {
                        REGION_ID = regionId,
                        REGION_NAME = regionName
                    };
                    regionMap[regionId] = region;
                }
                region.OUTLET_COUNT += outletCount;

                // AREA
                var area = region.AREAS.FirstOrDefault(a => a.AREA_ID == areaId);
                if (area == null)
                {
                    area = new Area
                    {
                        AREA_ID = areaId,
                        AREA_NAME = areaName
                    };
                    region.AREAS.Add(area);
                }
                area.OUTLET_COUNT += outletCount;

                // TERITORRY
                var ter = area.TERITORIES.FirstOrDefault(t => t.TERITORRY_ID == terId);
                if (ter == null)
                {
                    ter = new Teritorry
                    {
                        TERITORRY_ID = terId,
                        TERITORRY_NAME = terName
                    };
                    area.TERITORIES.Add(ter);
                }
                ter.OUTLET_COUNT += outletCount;
                // TOWN
                var town = ter.TOWNS.FirstOrDefault(t => t.TOWN_ID == townId);
                if (town == null)
                {
                    town = new Town
                    {
                        TOWN_ID = townId,
                        TOWN_NAME = townName
                    };
                    ter.TOWNS.Add(town);
                }
                town.OUTLET_COUNT += outletCount;

                // DEALER
                var dealer = town.DEALERS.FirstOrDefault(d => d.DEALER_ID == dealerId);
                if (dealer == null)
                {
                    dealer = new Dealer
                    {
                        DEALER_ID = dealerId,
                        DEALER_NAME = dealerName
                    };
                    town.DEALERS.Add(dealer);
                }
                dealer.OUTLET_COUNT += outletCount;

                // ROUTE (under dealer)
                var route = dealer.ROUTES.FirstOrDefault(r => r.ROUTE_ID == routeId);
                if (route == null)
                {
                    route = new Route
                    {
                        ROUTE_ID = routeId,
                        ROUTE_NAME = routeName
                    };
                    dealer.ROUTES.Add(route);
                }
                route.OUTLET_COUNT += outletCount;
            }

            return regionMap.Values.ToList();
        }


        

        [HttpGet]
        public String OutletInfo(string region_id, string area_id, string territory_id, string dealer_id, string town_id, string route_id)
        {

            DataTable tableData = new Dashboard_DAL().GetOutletInfo(p_region_id: region_id, p_area_id: area_id, p_teritorry_id: territory_id, p_dealer_id: dealer_id, p_town_id: town_id, p_route_id: route_id);
            string json = JsonConvert.SerializeObject(tableData);
            return json;
        }



        public ActionResult FieldStructureSalesInTP(string dt, string region_id, string area_id)
        {
            string date;
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
            DataTable tableOutletCount = new Dashboard_DAL().GetFieldStructureSalesInTP(p_date_to: date, region_id: region_id, area_id: area_id);

            string json = JsonConvert.SerializeObject(tableOutletCount);

            ViewBag.tableFieldStructureSalesInTP = json;
            ViewBag.data = ""; //OutletInfo();
            return View();
        }


        [HttpGet]
        public JsonResult getMoMBusinessProgress(string p_date_to, string mom_channel, string p_no_months, string p_cd = "")
        {
            string date;
            if (p_date_to == "" || p_date_to == null)
            {
                DateTime dateTime = DateTime.Now;
                date = dateTime.ToString("yyyy-MM-dd");
            }
            else
            {
                date = p_date_to + "-01";
            }

            string p_mom_channel;
            if (mom_channel == "" || mom_channel == null)
            {
                p_mom_channel = "";
            }
            else
            {
                p_mom_channel = mom_channel;
            }
            string no_months;
            if (p_no_months == "" || p_no_months == null)
            {
                no_months = "12";
            }
            else
            {
                no_months = p_no_months;
            }

            var dt = new Dashboard_DAL().getMoMBusinessProgress(date, p_mom_channel, no_months, p_cd);

            // convert DataTable to JSON object, example using Newtonsoft:
            var result = JsonConvert.SerializeObject(dt);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getMoMFocusCatBusinessProgress(string p_date_to, string mom_channel, string p_no_months)
        {
            string date;
            if (p_date_to == "" || p_date_to == null)
            {
                DateTime dateTime = DateTime.Now;
                date = dateTime.ToString("yyyy-MM-dd");
            }
            else
            {
                date = p_date_to + "-01";
            }

            string p_mom_channel;
            if (mom_channel == "" || mom_channel == null)
            {
                p_mom_channel = "";
            }
            else
            {
                p_mom_channel = mom_channel;
            }
            string no_months;
            if (p_no_months == "" || p_no_months == null)
            {
                no_months = "12";
            }
            else
            {
                no_months = p_no_months;
            }

            var dt = new Dashboard_DAL().getMoMFocusCatBusinessProgress(date, p_mom_channel, no_months);

            // convert DataTable to JSON object, example using Newtonsoft:
            var result = JsonConvert.SerializeObject(dt);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult getMoMEcoMemoBusinessProgress(string p_date_to, string mom_channel, string p_no_months)
        {
            string date;
            if (p_date_to == "" || p_date_to == null)
            {
                DateTime dateTime = DateTime.Now;
                date = dateTime.ToString("yyyy-MM-dd");
            }
            else
            {
                date = p_date_to + "-01";
            }

            string p_mom_channel;
            if (mom_channel == "" || mom_channel == null)
            {
                p_mom_channel = "";
            }
            else
            {
                p_mom_channel = mom_channel;
            }
            string no_months;
            if (p_no_months == "" || p_no_months == null)
            {
                no_months = "12";
            }
            else
            {
                no_months = p_no_months;
            }

            var dt = new Dashboard_DAL().getMoMEcoMemoBusinessProgress(date, p_mom_channel, no_months);

            // convert DataTable to JSON object, example using Newtonsoft:
            var result = JsonConvert.SerializeObject(dt);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult getMoMRegionEcoMemoBusinessProgress(string p_date_to, string mom_channel, string p_no_months)
        {
            string date;
            if (p_date_to == "" || p_date_to == null)
            {
                DateTime dateTime = DateTime.Now;
                date = dateTime.ToString("yyyy-MM-dd");
            }
            else
            {
                date = p_date_to + "-01";
            }

            string p_mom_channel;
            if (mom_channel == "" || mom_channel == null)
            {
                p_mom_channel = "";
            }
            else
            {
                p_mom_channel = mom_channel;
            }
            string no_months;
            if (p_no_months == "" || p_no_months == null)
            {
                no_months = "12";
            }
            else
            {
                no_months = p_no_months;
            }

            var dt = new Dashboard_DAL().getMoMRegionEcoMemoBusinessProgress(date, p_mom_channel, no_months);

            // convert DataTable to JSON object, example using Newtonsoft:
            var result = JsonConvert.SerializeObject(dt);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getQuarterlyBusinessTrend(string p_date_to, string mom_channel, string p_no_months)
        {
            string date;
            if (p_date_to == "" || p_date_to == null)
            {
                DateTime dateTime = DateTime.Now;
                date = dateTime.ToString("yyyy-MM-dd");
            }
            else
            {
                date = p_date_to + "-01";
            }

            string p_mom_channel;
            if (mom_channel == "" || mom_channel == null)
            {
                p_mom_channel = "";
            }
            else
            {
                p_mom_channel = mom_channel;
            }
            string no_months;
            if (p_no_months == "" || p_no_months == null)
            {
                no_months = "12";
            }
            else
            {
                no_months = p_no_months;
            }

            var dt = new Dashboard_DAL().getQuarterlyBusinessTrend(date, p_mom_channel, no_months);

            // convert DataTable to JSON object, example using Newtonsoft:
            var result = JsonConvert.SerializeObject(dt);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getFieldStructureSalesInTP(string dt, string region_id, string area_id)
        {
            string date;
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
            DataTable tableOutletCount = new Dashboard_DAL().GetFieldStructureSalesInTP(p_date_to: date, region_id: region_id, area_id: area_id);

            var result = JsonConvert.SerializeObject(tableOutletCount);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getSalesStatusRouteWise(string p_date_to, string mom_channel, string p_no_months, string dealer_id, string limit)
        {
            string date;
            if (p_date_to == "" || p_date_to == null)
            {
                DateTime dateTime = DateTime.Now;
                date = dateTime.ToString("yyyy-MM-dd");
            }
            else
            {
                date = p_date_to + "-01";
            }

            string p_mom_channel;
            if (mom_channel == "" || mom_channel == null)
            {
                p_mom_channel = "";
            }
            else
            {
                p_mom_channel = mom_channel;
            }
            string no_months;
            if (p_no_months == "" || p_no_months == null)
            {
                no_months = "12";
            }
            else
            {
                no_months = p_no_months;
            }

            string p_dealer_id;
            if (dealer_id == "" || dealer_id == null)
            {
                p_dealer_id = "0";
            }
            else
            {
                p_dealer_id = dealer_id;
            }

            string p_limit;
            if (limit == "" || limit == null)
            {
                p_limit = "0";
            }
            else
            {
                p_limit = limit;
            }

            var dt = new Dashboard_DAL().getSalesStatusRouteWise(date, p_mom_channel, no_months, p_dealer_id, limit);

            // convert DataTable to JSON object, example using Newtonsoft:
            var result = JsonConvert.SerializeObject(dt);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getRegionSalesTargetAchieve(string p_date_to)
        {
            string date;
            if (p_date_to == "" || p_date_to == null)
            {
                DateTime dateTime = DateTime.Now;
                date = dateTime.ToString("yyyy-MM-dd");
            }
            else
            {
                date = p_date_to + "-01";
            }



            var dt = new Dashboard_DAL().getRegionSalesTargetAchieve(date);

            var result = JsonConvert.SerializeObject(dt);
            return Json(result, JsonRequestBehavior.AllowGet);
        }




    }
}