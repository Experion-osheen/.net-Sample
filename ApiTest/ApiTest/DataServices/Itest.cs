using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiTest.Data;
using DTOS;

namespace ApiTest.DataServices
{
    interface Itest
    {
        List<EmployeeDto> Display();
        List<EmployeeDto> Add(EmployeeDto dto);
        List<EmployeeDto> DeleteUser(int Id);
        List<EmployeeDto> EditUser(EmployeeDto dto);
        EmployeeDto UploadUser(int id);
    }
}
