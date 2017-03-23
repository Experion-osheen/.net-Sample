using DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TravelRequestor.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Views()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:63134/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            var id = Session["empId"].ToString();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(string.Format("User/Show?empId=" + id)).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            List<ReqDto> user = JsonConvert.DeserializeObject<List<ReqDto>>(stringData);
            return PartialView("_UserView", user);
        }
        public JsonResult GetProject()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:63134/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            var id = Session["empId"].ToString();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(string.Format("User/GetProject")).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            List<ProjectDto> user = JsonConvert.DeserializeObject<List<ProjectDto>>(stringData);
            //var MyListArray = user.Cast<ProjectDto>().ToArray();
            //var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            //var JSArray = serializer.Serialize(MyListArray);
            List<SelectListItem> List1 = new List<SelectListItem>();
            //foreach (var item in user)
            //{
            //    List1.Add(new SelectListItem { Text = item.Pname, Value = item.Pid.ToString() });
            //}
            Session["ListItem"] = user as List<ProjectDto>;
            return Json(new { Data = user}, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]

        public ActionResult id()
        {
            string id1 = Session["empId"].ToString();
            return Json(new { empid = id1});
        }
        [HttpPost]
        public ActionResult AddRequest(ReqDto dto)
        {
            HttpClient client = new HttpClient();
            var param = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("http://localhost:63134/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PostAsync(string.Format("User/AddRequest"), contentPost).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            List<ReqDto> user = JsonConvert.DeserializeObject<List<ReqDto>>(stringData);
            return PartialView("_UserView", user);
        }
        [HttpPost]
        public ActionResult DeleteRequest(int Id)
        {
            HttpClient client = new HttpClient();
            var param = Newtonsoft.Json.JsonConvert.SerializeObject(Id);
            client.BaseAddress = new Uri("http://localhost:63134/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.DeleteAsync(string.Format("User/DeleteRequest?Id=" + Id)).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            List<ReqDto> user = JsonConvert.DeserializeObject<List<ReqDto>>(stringData);
            return PartialView("_UserView", user);
        }
        [HttpPost]
        public ActionResult EditRequest(int Id)
        {
            HttpClient client = new HttpClient();
            var param = Newtonsoft.Json.JsonConvert.SerializeObject(Id);
            HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("http://localhost:63134/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PostAsync(string.Format("User/UploadRequest?id=" + Id), contentPost).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            ReqDto user = JsonConvert.DeserializeObject<ReqDto>(stringData);
            return PartialView("_EditRequest", user);
        }
        public ActionResult editUpdate(ReqDto dto)
        {
            HttpClient client = new HttpClient();
            var param = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("http://localhost:63134/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PutAsync(string.Format("User/EditUpdate"), contentPost).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            List<ReqDto> user = JsonConvert.DeserializeObject<List<ReqDto>>(stringData);
            return PartialView("_UserView", user);
        }
        public ActionResult ChangePin(String password)
        {
            string id1 = Session["empId"].ToString();
            HttpClient client = new HttpClient();
            var param = Newtonsoft.Json.JsonConvert.SerializeObject(password);
            HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("http://localhost:63134/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PutAsync(string.Format("User/ChangePin?password="+password+"&empid="+id1), contentPost).Result;
            return Json(new { status = "Success" });
        }
    }
}