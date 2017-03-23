using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using TravelApi.Data;

namespace TravelApi.DataServices
{
    interface IUserService
    {
        string Login(UserDto obj);
        List<ReqDto> show(string empID);
        List<ReqDto> AddRequest(ReqDto dto);
        List<ReqDto> DeleteRequest(int Id);
        ReqDto UploadRequest(int id);
        List<ReqDto> EditUpdate(ReqDto dto);
        List<ReqDto> UserRequests(string empId);
        string ChangePin(string password, string empid);
        List<ProjectDto> GetProject();
    }
}
