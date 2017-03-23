using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DTOs;
using System.Threading.Tasks;
namespace TravelRequestor.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }
        public ActionResult AdminHome()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:63134/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(string.Format("Admin/ViewRequests")).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            List<ReqDto> dtos = JsonConvert.DeserializeObject<List<ReqDto>>(stringData);
            return View("AdminHome",dtos);
        }
        public ActionResult ViewRequest()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:63134/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(string.Format("Admin/ViewAllRequests")).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            List<ReqDto> dtos = JsonConvert.DeserializeObject<List<ReqDto>>(stringData);
            return View("ViewRequest", dtos);
        }
        public JsonResult GetProject()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:63134/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(string.Format("User/GetProject")).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            List<ProjectDto> dtos = JsonConvert.DeserializeObject<List<ProjectDto>>(stringData);
            return Json(new { status = dtos });
        }
        public ActionResult UserHome()
        {
            return View("UserHome");
        }
        [HttpPost]
        public ActionResult Login1(UserDto dto)
        {
            HttpClient client = new HttpClient();
            var param = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("http://localhost:63134/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PostAsync(string.Format("Login/Login"), contentPost).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            var myObject = JsonConvert.DeserializeObject<string>(stringData);
            if (myObject == "User" || myObject == "Admin")
            {
                Session["empId"] = dto.empId;
                return Json(new { status = 200, message = "Login Success", role = myObject });
            }
            else
            {
                return Json(new { status = 403, message = "Login Failed", role = " " });
            }
        }
    }
}