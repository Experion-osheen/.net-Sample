using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMvc.Models;

namespace SampleMvc.Controllers
{
    public class EmployeeController : BaseController
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Submit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                return View("Index");
            }
            return View("Index");
        }

        public ActionResult SubmitAjax(Employee employee)
        {
            if (employee != null)
            {
                List<Employee> employeeList = new List<Employee>();
                if (Session["EmployeeList"] != null)
                {
                    employeeList = (List<Employee>)Session["EmployeeList"];
                    employeeList.Add(employee);
                    Session["EmployeeList"] = employeeList;
                    return Json(new { Data = RenderRazorViewToString("_Partial", employeeList) });
                }
                else
                {
                    employeeList.Add(employee);
                    Session["EmployeeList"] = employeeList;
                    return Json(new { Data = RenderRazorViewToString("_Partial", employeeList) });
                    //return PartialView("_Partial", employeeList);
                }
            }
            return Json(new { Msg = "" });
        }

    }
}