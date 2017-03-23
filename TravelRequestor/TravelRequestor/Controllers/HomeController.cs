using DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace TravelRequestor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("UserHome");
        }

        public ActionResult ViewRequest()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult UserRequests()
        {
            var id = Session["empId"].ToString();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:63134/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(string.Format("User/UserRequests?empId=" + id)).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            List<ReqDto> dtos = JsonConvert.DeserializeObject<List<ReqDto>>(stringData);
            return View("UserRequests", dtos);
        }
        public ActionResult AddUser()
        {
           

            return View("AddUser");
        }
        public ActionResult ChangePin()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
     
    }
}