using ClosedXML.Excel;
using IMLDashboard.Controllers;
using IMPLDashboard.DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMPLDashboard.Controllers
{
    [Filters.AuthorizedUser]
    public class SalesReportController : BaseController
    {
        // GET: SalesReport
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SalesReport()
        {
            return View();
        }

        public FileResult ExportDailySalesReport(string p_as_on_date)
        {

            DataTable dt = new SalesReport_DAL().GetDailySalesReport(p_as_on_date);
            var rows = dt.Rows.Count;
            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add(dt);
                ws.SetAutoFilter(false);
                ws.Table(0).ShowAutoFilter = false;
                ws.Table(0).Theme = XLTableTheme.None;
                /*wb.Worksheets.Add(dt);*/

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "sales_" + p_as_on_date + ".xlsx");
                }
            }
        }


        public FileResult ExportMtdSalesReport(string p_as_on_date)
        {

            DataTable dt = new SalesReport_DAL().GetMtdSalesReport(p_as_on_date);
            var rows = dt.Rows.Count;
            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add(dt);
                ws.SetAutoFilter(false);
                ws.Table(0).ShowAutoFilter = false;
                ws.Table(0).Theme = XLTableTheme.None;
                /*wb.Worksheets.Add(dt);*/

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "sales_" + p_as_on_date + ".xlsx");
                }
            }
        }


        public ActionResult SalesReportMOM()
        {
            return View();
        }

        public FileResult ExportMOMSalesReport(string p_as_on_date)
        {

            DataTable dt = new SalesReport_DAL().GetMOMSalesReport(p_as_on_date);
            var rows = dt.Rows.Count;
            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add(dt);
                ws.SetAutoFilter(false);
                ws.Table(0).ShowAutoFilter = false;
                ws.Table(0).Theme = XLTableTheme.None;
                /*wb.Worksheets.Add(dt);*/

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "sales_mom_" + p_as_on_date + ".xlsx");
                }
            }
        }

        public ActionResult BestSellingProducts()
        {
            return View();
        }

        public FileResult ExportBestSellingProducts(string p_as_on_date)
        {

            DataTable dt = new SalesReport_DAL().GetBestSellingProducts(p_as_on_date);
            var rows = dt.Rows.Count;
            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add(dt);
                ws.SetAutoFilter(false);
                ws.Table(0).ShowAutoFilter = false;
                ws.Table(0).Theme = XLTableTheme.None;
                /*wb.Worksheets.Add(dt);*/

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "sales_" + p_as_on_date + ".xlsx");
                }
            }
        }






    }
}