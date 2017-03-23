using Newtonsoft.Json;
using System;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using Test2.Models;
using DTOS;
using System.Linq;

namespace Test2.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TestView()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Views()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50650/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(string.Format("Employee/Show")).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            List<EmployeeDto> user = JsonConvert.DeserializeObject<List<EmployeeDto>>(stringData);
            return View("_View", user);
        }
        [HttpPost]
        public ActionResult Add(EmployeeDto dto)
        {
            HttpClient client = new HttpClient();
            var param = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("http://localhost:50650/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response =client.PostAsync(string.Format("Employee/Add"), contentPost).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            List<EmployeeDto> user = JsonConvert.DeserializeObject<List<EmployeeDto>>(stringData);
            return View("_View", user);

        }
        public ActionResult DeleteUser(int id)
        {
            HttpClient client = new HttpClient();
            var param = Newtonsoft.Json.JsonConvert.SerializeObject(id);
            client.BaseAddress = new Uri("http://localhost:50650/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.DeleteAsync(string.Format("Employee/DeleteUser?Id=" + id)).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            List<EmployeeDto> user = JsonConvert.DeserializeObject<List<EmployeeDto>>(stringData);
            return View("_View", user);
        }
        [HttpPost]
        public ActionResult EditUser(int Id)
        {
            HttpClient client = new HttpClient();
            var param = Newtonsoft.Json.JsonConvert.SerializeObject(Id);
            HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("http://localhost:50650/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PostAsync(string.Format("Employee2/UploadUser?id="+Id), contentPost).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            EmployeeDto user = JsonConvert.DeserializeObject<EmployeeDto>(stringData);
            return PartialView("_Edit", user);
        }
        public ActionResult editUpdate(EmployeeDto dto)
        {
            HttpClient client = new HttpClient();
            var param = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("http://localhost:50650/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PutAsync(string.Format("Employee/EditUser"), contentPost).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            List<EmployeeDto> user = JsonConvert.DeserializeObject<List<EmployeeDto>>(stringData);
            return View("_View", user);
        }
    }
}