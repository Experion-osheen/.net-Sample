using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTOs;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.IO;

namespace TravelRequestor.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        public string RenderRazorViewToString(string viewName, object model)
        {
            try
            {
                ViewData.Model = model;
                using (var sw = new StringWriter())
                {
                    var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                    var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                    viewResult.View.Render(viewContext, sw);
                    viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                    return sw.GetStringBuilder().ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(UserDto dto)
        {
            HttpClient client = new HttpClient();
            var param = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("http://localhost:63134/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PostAsync(string.Format("Admin/Add"), contentPost).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            List<UserDto> user = JsonConvert.DeserializeObject<List<UserDto>>(stringData);
            return PartialView("_Views",user);
        }
        [HttpPost]
        public ActionResult ActionUpdate(ReqDto dto)
        {
            HttpClient client = new HttpClient();
            var param = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("http://localhost:63134/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PutAsync(string.Format("Admin/ActionUpdate"), contentPost).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            var myObject = JsonConvert.DeserializeObject<string>(stringData);
            if (myObject=="Success")
            {
                return Json(new { status = 200, message = "Success"});
            }
            else
            {
                return Json(new { status = 403, message = "Failed"});
            }

        }
        public ActionResult DeleteUser(string id)
        {
            HttpClient client = new HttpClient();
            var param = Newtonsoft.Json.JsonConvert.SerializeObject(id);
            client.BaseAddress = new Uri("http://localhost:63134/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.DeleteAsync(string.Format("Admin/DeleteUser?Id="+id)).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            List<UserDto> user = JsonConvert.DeserializeObject<List<UserDto>>(stringData);
            return PartialView("_Views", user);
        }
        [HttpPost]
        public ActionResult EditUser(string Id)
        {
            HttpClient client = new HttpClient();
            var param = Newtonsoft.Json.JsonConvert.SerializeObject(Id);
            HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("http://localhost:63134/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PostAsync(string.Format("Admin/UploadUser?id="+Id), contentPost).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            UserDto user = JsonConvert.DeserializeObject<UserDto>(stringData);
            return PartialView("_Edit", user);
        }
       

        [HttpGet]
        public ActionResult Views()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:63134/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(string.Format("Admin/Show")).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            List<UserDto> user = JsonConvert.DeserializeObject<List<UserDto>>(stringData);
            return Json( new { Status = 1, Data = RenderRazorViewToString("_Views",user)},JsonRequestBehavior.AllowGet);
        }
        
    }
}