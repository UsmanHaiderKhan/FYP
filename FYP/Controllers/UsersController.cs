using FYP.Models;
using FYPManagementLibrary.UsersManagement;
using System;
using System.Web;
using System.Web.Mvc;

namespace FYP.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            HttpCookie hcs = Request.Cookies["logsec"];
            if (hcs != null)
            {
                User u = new UserHandler().GetUser(hcs.Values["logid"], hcs.Values["psd"]);
                if (u != null)

                {
                    hcs.Expires = DateTime.Today.AddDays(7);
                    Session.Add(WebUtils.Current_User, u);
                    if (u.IsInRole(WebUtils.Admin))
                    {
                        return RedirectToAction("Index", "Admin");
                    }

                    return RedirectToAction("Index", "Home");
                }
            }

            //here we get the the Countries Because we Render The signup at Login Page
            ViewBag.GenderList = ModelHelper.ToSelectItemList(new UserHandler().GetGender());
            ViewBag.department = ModelHelper.ToSelectItemList(new UserHandler().GetDepartments());
            ViewBag.Controller = Request.QueryString["ctl"];
            ViewBag.Action = Request.QueryString["act"];

            return View();
        }

        //first Step
        [HttpPost]
        public ActionResult Login(LoginViewModel data)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            User u = new UserHandler().GetUser(data.RegisterId, data.Password);

            if (u != null)
            {
                if (data.RememberMe)
                {
                    HttpCookie hc = new HttpCookie("logsec");
                    hc.Expires = DateTime.Today.AddDays(7);
                    //name of file Where we Want to Store the Name Of Email and Login
                    hc.Values.Add("reg", Convert.ToString(u.RegisterId));
                    hc.Values.Add("psd", u.Password);
                    Response.SetCookie(hc);

                }

                Session.Add(WebUtils.Current_User, u);
                string ctl = Request.QueryString["c"];
                string act = Request.QueryString["a"];
                if (!string.IsNullOrEmpty(ctl) && string.IsNullOrEmpty(act))
                {
                    return RedirectToAction(act, ctl);
                }

                return RedirectToAction("index", "Home");
            }
            else
            {

                ViewBag.ErrorMessage = "Your Login Id and Password is Incorrect";
            }

            ViewBag.department = ModelHelper.ToSelectItemList(new UserHandler().GetDepartments());
            ViewBag.GenderList = ModelHelper.ToSelectItemList(new UserHandler().GetGender());
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            HttpCookie hc = Request.Cookies["logsec"];
            if (hc != null)
            {
                hc.Expires = DateTime.Now;
                Response.SetCookie(hc);
            }

            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Register()
        {

            ViewBag.GenderList = ModelHelper.ToSelectItemList(new UserHandler().GetGender());
            ViewBag.department = ModelHelper.ToSelectItemList(new UserHandler().GetDepartments());
            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection formdata)
        {
            //if (User != null && User.IsInRole(WebUtils.Current_User))) return RedirectToAction("Login", "Users", new { ctl = "Products", act = "Create" });\
            User u = new User();
            if (u != null)
            {
                try
                {
                    u.FullName = Convert.ToString(formdata["FullName"]);
                    u.Email = Convert.ToString(formdata["Email"]);
                    u.RegisterId = Convert.ToInt32(formdata["RegisterId"]);
                    u.MobileNo = Convert.ToInt64(formdata["MobileNo"]);
                    long uno = DateTime.Now.Ticks;
                    int counter = 0;
                    foreach (string fileName in Request.Files)
                    {
                        HttpPostedFileBase file = Request.Files[fileName];
                        if (!string.IsNullOrEmpty(file.FileName))
                        {
                            string abc = uno + "_" + ++counter +
                                         file.FileName.Substring(file.FileName.LastIndexOf("."));
                            //dont save the url of the Images Save the 
                            string url = "~/Content/UserImage/" + abc;
                            string path = Request.MapPath(url);
                            u.ImageUrl = abc;
                            file.SaveAs(path);
                        }
                    }

                    u.Gender = new Gender { Id = Convert.ToInt32(formdata["gender.Name"]) }; //this thing

                    u.Password = Convert.ToString(formdata["Password"]);
                    u.ConfirmPassword = Convert.ToString(formdata["ConfirmPassword"]);

                    u.Role = new Role() { Id = 2 };


                    User user = new UserHandler().AddUser(u);

                    return View("~/Views/Users/Message.cshtml", user);
                }

                catch (Exception exception)
                {
                    Console.Write(exception);
                    return View();
                }

            }
            else
            {
                return View();
            }
        }
        public ActionResult Messages()
        {

            return View();
        }
    }
}
