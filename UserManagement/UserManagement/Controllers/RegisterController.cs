using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Web.Mvc;
using UserManagement.Models;
namespace UserManagement.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        List<UserDetails> emp = new List<UserDetails>();
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Display(UserDetails obj)
        {
                List<UserDetails> loginForStore = new List<UserDetails>();
                if (Session["LoginDetailList"] != null)
                {
                    loginForStore = (List<UserDetails>)Session["LoginDetailList"];
                    loginForStore.Add(obj);
                    Session["LoginDetailList"] = loginForStore;
                    return PartialView("_DisplayPartial", loginForStore);

                }
                else
                {
                    loginForStore.Add(obj);
                    Session["LoginDetailList"] = loginForStore;
                    return PartialView("_DisplayPartial", loginForStore);
                }
        }
        [HttpPost]
        public ActionResult DeleteUser(string id)
        {
            List<UserDetails> employees = new List<UserDetails>();
            employees =(List<UserDetails>) Session["LoginDetailList"];
            UserDetails employee = new UserDetails();
            employee = (UserDetails)employees.FirstOrDefault(x => x.Id == id);
            employees.Remove(employee);
            Session["LoginDetailsList"] = employees;
            return PartialView("_DisplayPartial", employees);
        }
        public ActionResult EditUser(string id)
        {
            List<UserDetails> employees = new List<UserDetails>();
            employees = (List<UserDetails>)Session["LoginDetailList"];
            UserDetails employee = new UserDetails();
            employee = (UserDetails)employees.FirstOrDefault(x => x.Id == id);
            Session["EditData"] = employee;
            return PartialView("_EditPartial",employee);
        }
        public ActionResult editUpdate(UserDetails obj)
        {
            List<UserDetails> employees = new List<UserDetails>();
            employees = (List<UserDetails>)Session["LoginDetailList"];
            UserDetails employee = new UserDetails();
            employee = (UserDetails)employees.FirstOrDefault(x => x.Id == obj.Id);
            employees.Remove(employee);
            employees.Add(obj);
            Session["LoginDetailsList"] = employees;
            return PartialView("_DisplayPartial", employees);
        }
        [HttpGet]
        public ActionResult Views()
        {
            HttpClient client = new HttpClient();
            //HttpCookie cookie = CreateCookie();
            client.BaseAddress = new Uri("http://localhost:58368/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(string.Format("User/ViewDetails")).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            List<UserDetails> loginForStore = JsonConvert.DeserializeObject<List<UserDetails>>(stringData);
                Session["LoginDetailList"] = loginForStore;
                return PartialView("_DisplayPartial", loginForStore);
            

        }
    }
}


