using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TravelApi.Data;
using TravelApi.DataServices;

namespace TravelApi.Controllers
{
    public class UserController : ApiController
    {
        IUserService itest;
        [HttpGet]
        [Route("api/User/Show")]
        public List<ReqDto> Show(string empId)
        {
            itest = new UserService();
            return itest.show(empId);
        }
        [HttpGet]
        [Route("api/User/UserRequests")]
        public List<ReqDto> UserRequests(string empId)
        {
           itest = new UserService();
            return itest.UserRequests(empId);
        }
        [HttpPost]
        [Route("api/User/AddRequest")]
        public List<ReqDto> AddRequest(ReqDto dto)
        {
            itest = new UserService();
            return itest.AddRequest(dto);
        }
        [HttpDelete]
        public List<ReqDto> DeleteRequest(int Id)
        {
            itest = new UserService();
            return itest.DeleteRequest(Id);
        }
        [HttpPost]
        [Route("api/User/UploadRequest")]
        public ReqDto UploadUser(int id)
        {
            itest = new UserService();
            return itest.UploadRequest(id);
        }
        [HttpPut]
        [Route("api/User/EditUpdate")]
        public List<ReqDto> EditUpdate(ReqDto dto)
        {
            itest = new UserService();
            return itest.EditUpdate(dto);
        }
        [HttpGet]
        [Route("api/User/GetProject")]
        public List<ProjectDto> GetProject()
        {
            itest = new UserService();
            return itest.GetProject();
        }
        [HttpPut]
        [Route("api/User/ChangePin")]
        public string ChangePin(string password,string empid)
        {
            itest = new UserService();
            return itest.ChangePin(password,empid);
        }
    }
}
