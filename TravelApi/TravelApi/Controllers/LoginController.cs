using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TravelApi.DataServices;
using DTOs;

namespace TravelApi.Controllers
{
    public class LoginController : ApiController
    {
        IUserService ser;        
        [HttpPost]
        public string Login(UserDto obj)
        {
            ser = new UserService();
            return ser.Login(obj);
        }
       
       

    }
}
