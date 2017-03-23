using ApiTest.Data;
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
    public class EmployeeController : ApiController
    {

        Itest itest;
        [HttpGet]
        public List<EmployeeDto> Show()
        {
            itest = new Test();
            return itest.Display();
        }
        [HttpPost]
        public List<EmployeeDto> Add(EmployeeDto dto)
        {
            itest = new Test();
            return itest.Add(dto);
        }
        [HttpDelete]
        public List<EmployeeDto> DeleteUser(int Id)
        {
            itest = new Test();
            return itest.DeleteUser(Id);
        }
        [HttpPut]
        public List<EmployeeDto> EditUser(EmployeeDto dto)
        {
            itest = new Test();
            return itest.EditUser(dto);
        }
        

    }
}
