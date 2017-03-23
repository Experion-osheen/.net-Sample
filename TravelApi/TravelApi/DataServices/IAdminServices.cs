using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApi.DataServices
{
    interface IAdminServices
    {
        List<UserDto> Display();
        List<UserDto> Add(UserDto dto);
        List<UserDto> DeleteUser(string Id);
        List<UserDto> EditUser(UserDto dto);
        UserDto UploadUser(string id);
        string ActionUpdate(ReqDto dto);
        List<ReqDto> ViewRequests();
        List<ReqDto> ViewAllRequests();
    }
}
