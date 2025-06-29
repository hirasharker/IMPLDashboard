using DocumentFormat.OpenXml.Spreadsheet;
using IMPLDashboard.DAL;
using IMPLDashboard.Models;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace IMPLDashboard.Controllers
{
    public class UserController : Controller
    {

        public ActionResult UserControllser()
        {
            if (Session["isLogedin"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "User");

        }
        // GET: User
        public ActionResult Index()
        {

            return View();
        }
        [Filters.AuthorizedUser]
        public ActionResult UpdateProfilePicture() => View();


        [HttpPost]
        public ActionResult ProfilePictureSubmit(HttpPostedFileBase file)
        {
            string user_id = Session["user_id"].ToString();
            if (file != null)
            {
                var directoryPath = Server.MapPath("~/Content/images");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                var fileGuid = Guid.NewGuid();
                var filename = string.Concat(user_id, Path.GetExtension(file.FileName)).ToLower();
                var savePath = Path.Combine(directoryPath, filename);
                file.SaveAs(savePath);
            }

            return RedirectToAction("Index", "Home");

        }

        public ActionResult Login()
        {
            if (Session["isLogedin"] != null)
            {
                string ctrl = "Dashboard";
                string func = "Home";

                string[] routes = Session["default_route"].ToString().Split('/');

                if (routes.Length > 0)
                {
                    ctrl = routes[0];
                }
                else
                {
                    ctrl = "Home";
                }

                if (routes.Length > 1)
                {
                    func = routes[1];
                }
                else
                {
                    func = "Index";
                }


                return RedirectToAction(func, ctrl);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Verify(User user)
        {
            DataTable dt = new User_DAL().VerifyUser(user);

            //DataTable dt = new db().getUserInfo(user);

            if (dt.Rows.Count > 0)
            {

                DataRow dr = dt.Rows[0];

                if (dr["PASSWORD_UPDATE_DATE"] == DBNull.Value || Convert.ToDateTime(dr["PASSWORD_UPDATE_DATE"]) < DateTime.Now.AddMonths(-1))
                {
                    // Send OTP to user mobile number
                    TempData["user_id"] = dr["USER_ID"].ToString();
                    TempData["mobile"] = dr["USER_MOBILE"].ToString();
                    return RedirectToAction("ForceChangePassword", "User");
                }

                Session["user_id"] = Convert.ToString(dr["USER_ID"]);
                Session["person_id"] = Convert.ToString(dr["PERSON_ID"]);
                Session["svd_code"] = Convert.ToString(dr["SVD_CODE"]);
                Session["user_name"] = Convert.ToString(dr["USER_NAME"]);
                Session["role"] = Convert.ToString(dr["ROLE"]);

                var user_area = Convert.ToString(dr["USER_AREA"]);
                Session["user_area"] = user_area;
                Session["default_route"] = Convert.ToString(dr["DEFAULT_ROUTE"]);
                Session["isLogedin"] = true;

                DataTable dtroles = new User_DAL().GetRoles(user.user_id);

                String[] roles = { };

                if (dtroles.Rows.Count > 0)
                {
                    foreach (DataRow r in dtroles.Rows)
                    {
                        Array.Resize(ref roles, roles.Length + 1);
                        roles[roles.GetUpperBound(0)] = Convert.ToString(r["ROLE_ID"]);
                    }
                }

                Session["roles"] = roles;

                Session["contract"] = user_area;



                if (user_area == "")
                {
                    Session["contract"] = "IAL";
                }


                DataTable menuAccess = new User_DAL().UserMenuAccess(Convert.ToString(dr["USER_ID"]));
                Session["menuAccess"] = menuAccess;

                string ctrl = "Dashboard";
                string func = "Home";

                string[] routes = Convert.ToString(dr["DEFAULT_ROUTE"]).Split('/');

                if (routes.Length > 0)
                {
                    ctrl = routes[0];
                }

                if (routes.Length > 1)
                {
                    func = routes[1];
                }


                return RedirectToAction(func, ctrl, new { action = "Index" });
            }
            else
            {
                ViewBag.error = "User ID or Password is not correct";
                return View("Login");
            }

        }

        public ActionResult ForceChangePassword()
        {
            ViewBag.UserId = TempData["user_id"];
            ViewBag.Mobile = TempData["mobile"];
            return View();
        }

        [HttpPost]
        public ActionResult SubmitForcedPasswordChange(string user_id, string new_password, string otp_input)
        {
            string actualOtp = Session["otp_code"]?.ToString();
            if (otp_input != actualOtp)
            {
                ViewBag.Error = "Incorrect OTP.";
                return View("ForceChangePassword");
            }

            int result = new User_DAL().password_update(user_id, new_password, true); // pass true to update date
            if (result == -1)
            {
                Session["otp_code"] = null;
                TempData["success"] = "Password changed successfully. Please login again.";
                return RedirectToAction("Login");
            }

            ViewBag.Error = "Failed to update password.";
            return View("ForceChangePassword");
        }

        public ActionResult SendOtp(string mobile)
        {
            string otp = new Random().Next(100000, 999999).ToString();
            Session["otp_code"] = otp;

            string cleanedNumber = CleanNumber(mobile);
            string message = $"Your OTP is {otp}";
            string apiToken = "xwimldbw-uzzd1dg9-fmguaiug-gqraosui-kzqfggrm";
            string sid = "IFADAUTOSBULK";
            string csmsId = "111";

            string apiUrl = $"https://smsplus.sslwireless.com/api/v3/send-sms?api_token={apiToken}&sid={sid}&sms={HttpUtility.UrlEncode(message)}&msisdn={cleanedNumber}&csms_id={csmsId}";

            try
            {
                using (var client = new System.Net.WebClient())
                {
                    client.DownloadString(apiUrl);
                }
                return Content("OTP sent successfully.");
            }
            catch
            {
                return Content("Failed to send OTP.");
            }
        }

        private string CleanNumber(string number)
        {
            number = System.Text.RegularExpressions.Regex.Replace(number, @"\D", "");
            if (number.StartsWith("880"))
                number = "0" + number.Substring(3);
            else if (!number.StartsWith("0"))
                number = "0" + number;
            return number;
        }



        public ActionResult Logout()
        {

            Session["isLogedin"] = null;
            return RedirectToAction("Login", "User");
        }


        [HttpGet]
        public string user_info(string user_id)
        {
            DataTable dt = new User_DAL().UserInfo(user_id);
            //DataTable dt = new db().getUserInfo(user);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            return json;

        }


        [Filters.AuthorizedUser]
        public ActionResult Create()
        {
            DataTable menu = new User_DAL().getMenu("");
            ViewBag.usermenu = menu;
            return View();
        }


        [Filters.AuthorizedUser]
        public ActionResult ChangePassword()
        {

            return View();
        }


        [Filters.AuthorizedUser]
        [HttpPost]
        public ActionResult PasswordChange()
        {

            string current_password = Request["current_password"];
            string new_password = Request["new_password"];
            string user_id = Session["user_id"].ToString();

            User user = new User();
            user.user_id = user_id;
            user.password = current_password;

            DataTable dt = new User_DAL().VerifyUser(user);
            if (dt.Rows.Count > 0)
            {
                int result = new User_DAL().password_update(user_id, new_password);
            }
            else
            {

                ViewBag.message = "Current Password does not match.";
                return View("ChangePassword");

            }

            return RedirectToAction("logout");
        }
        [Filters.AuthorizedUser]
        public ActionResult Save(FormCollection f)
        {

            string user_id = f["USER_ID"];
            string USER_NAME = f["USER_NAME"];
            string USER_EMAIL = f["USER_EMAIL"];
            string USER_PASS = f["USER_PASS"];
            string USER_AREA = f["USER_AREA"];
            string PERSON_ID = f["PERSON_ID"];

            int result = new User_DAL().user_save(user_id, USER_NAME, USER_PASS, USER_EMAIL, USER_AREA, PERSON_ID);
            if (result != 0)
            {
                if (f["MENU_ID"] != "")
                {
                    string[] MENUS = f["MENU_ID"].Split(',');
                    foreach (string item in MENUS)
                    {
                        int MENU_ID = int.Parse(item);
                        new User_DAL().menu_access_save(user_id, MENU_ID);
                    }
                }
                ViewBag.save_message = "User id " + user_id + " created successfully";
            }
            else
            {
                ViewBag.save_message = "User id " + user_id + " has not created. Please try again.";
            }
            DataTable menu = new User_DAL().getMenu("");
            ViewBag.usermenu = menu;

            return View("Create");
        }


        [Filters.AuthorizedUser]
        public ActionResult UserList()
        {
            DataTable dt = new User_DAL().UserInfo("");
            ViewBag.userlist = dt;
            return View();
        }



        [Filters.AuthorizedUser]
        public ActionResult EditUser(string user_id)
        {

            DataTable dt = new User_DAL().UserInfo(user_id);
            ViewBag.userinfo = dt;

            DataTable menu = new User_DAL().getMenu(user_id);
            ViewBag.usermenu = menu;

            return View();
        }


        [Filters.AuthorizedUser]
        public ActionResult UserUpdate(FormCollection f)
        {

            string user_id = f["USER_ID"];
            string USER_NAME = f["USER_NAME"];
            string USER_EMAIL = f["USER_EMAIL"];
            string USER_AREA = f["USER_AREA"];

            int result = new User_DAL().user_update(user_id, USER_NAME, USER_EMAIL, USER_AREA);
            if (result != 0)
            {
                new User_DAL().menu_access_delete(user_id);

                if (f["MENU_ID"] != "")
                {
                    string[] MENUS = f["MENU_ID"].Split(',');
                    foreach (string item in MENUS)
                    {
                        int MENU_ID = int.Parse(item);
                        new User_DAL().menu_access_save(user_id, MENU_ID);
                    }
                }
                ViewBag.save_message = "User id " + user_id + " Update successfully";
            }
            else
            {
                ViewBag.save_message = "User id " + user_id + " has not updated. Please try again.";
            }
            DataTable menu = new User_DAL().getMenu("");
            ViewBag.usermenu = menu;

            return View("Create");
        }
    }
}