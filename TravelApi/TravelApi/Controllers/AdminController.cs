using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TravelApi.DataServices;

namespace TravelApi.Controllers
{
    public class AdminController : ApiController
    {
        IAdminServices itest;
        [HttpPost]
        [Route("api/Admin/Add")]
        public List<UserDto> Add(UserDto dto)
         {
            itest = new AdminServices();
            return itest.Add(dto);
        }
        [HttpPost]
        [Route("api/Admin/UploadUser")]
        public UserDto UploadUser(string id)
        {
            itest = new AdminServices();
            return itest.UploadUser(id);
        }
        [HttpPut]
        [Route("api/Admin/ActionUpdate")]
        public string ActionUpdate(ReqDto dto)
        {
            itest = new AdminServices();
            return itest.ActionUpdate(dto);
        }
        [HttpDelete]
        public List<UserDto> DeleteUser(string Id)
        {
            itest = new AdminServices();
            return itest.DeleteUser(Id);
        }
        [HttpPut]
        [Route("api/Admin/EditUser")]
        public List<UserDto> EditUser(UserDto dto)
        {
            itest = new AdminServices();
            return itest.EditUser(dto);
        }
        [HttpGet]
        [Route("api/Admin/Show")]
        public List<UserDto> Show()
        {
            itest = new AdminServices();
            return itest.Display();
        }
        [HttpGet]
        [Route("api/Admin/ViewRequests")]
        public List<ReqDto> ViewRequests()
        {
            itest = new AdminServices();
            return itest.ViewRequests();

        }
        [HttpGet]
        [Route("api/Admin/ViewAllRequests")]
        public List<ReqDto> ViewAllRequests()
        {
            itest = new AdminServices();
            return itest.ViewAllRequests();

        }

    }
}
