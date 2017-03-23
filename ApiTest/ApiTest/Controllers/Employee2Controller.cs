using ApiTest.DataServices;
using DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiTest.Controllers
{
    public class Employee2Controller : ApiController
    {
        Itest itest;
        public EmployeeDto UploadUser(int id)
        {
            itest = new Test();
            return itest.UploadUser(id);
        }
    }
}
