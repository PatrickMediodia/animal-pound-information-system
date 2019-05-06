using Newtonsoft.Json;
using PODBProjectEmployee.Models;
using PODBProjectWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PODBProjectEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        ServiceClientWrapper client;
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            client = new ServiceClientWrapper();

            if (ModelState.IsValid)
            {
                var baseAddress = "http://localhost:57108/api/Employee/RegisterEmployee";

                var parameters = new Dictionary<string, string>
                {
                    {"accountId", emp.employeeId },
                    {"employeeId", emp.employeeId },
                    {"employeeName", emp.employeeName },
                    {"email", emp.email },
                    {"password", emp.password }
                };

                var result = client.Send(new ServiceRequest { BaseAddress = baseAddress, HttpProtocol = Protocols.HTTP_POST, RequestParameters = parameters });
                var success = JsonConvert.DeserializeObject<Boolean>(result.Response);

                if (success)
                    return Redirect("~/Employee/Create");
                else
                    TempData["errorMsg"] = "<script>alert('Invalid Data')</script>";
            }

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login log)
        {
            client = new ServiceClientWrapper();

            var baseAddress = "http://localhost:57108/api/Employee/Login";

            var parameters = new Dictionary<string, string>
                {
                    {"email", log.email },
                    {"password", log.password }
                };
            var result = client.Send(new ServiceRequest { BaseAddress = baseAddress, HttpProtocol = Protocols.HTTP_POST, RequestParameters = parameters });
            var success = JsonConvert.DeserializeObject<bool>(result.Response);
            if (success)
            {
                return Redirect("~/Home/Index");
            }
            else
                return Redirect("~/Employee/Create");
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePassword change)
        {
            client = new ServiceClientWrapper();

            var baseAddress = "http://localhost:57108/api/Employee/ChangePassword";

            var parameters = new Dictionary<string, string>
                {
                    {"email",change.email  },
                    {"pass", change.password },
                    {"newpass", change.newPassword }
                };
            var result = client.Send(new ServiceRequest { BaseAddress = baseAddress, HttpProtocol = Protocols.HTTP_POST, RequestParameters = parameters });
            bool success = JsonConvert.DeserializeObject<bool>(result.Response);
            if (success)
            {
                return Redirect("~/Home/Index");
            }
            else
                return Redirect("~/Employee/Create");
        }

    }
}

