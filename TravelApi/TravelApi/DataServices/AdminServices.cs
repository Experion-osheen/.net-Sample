using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTOs;
using TravelApi.Data;

namespace TravelApi.DataServices
{
    public class AdminServices : IAdminServices
    {
        TravelEntities1 entities = new TravelEntities1();
        public List<UserDto> Display()
        {
            List<UserTable> user = entities.UserTables.ToList();
            var users = EntityDtoMapping.Mapping.ToDtos(user);
            return users;
        }

        public List<UserDto> Add(UserDto dto)
        {
            if (dto.Name != null)
            {
                var obj = EntityDtoMapping.Mapping.ToEntity(dto);
                entities.UserTables.Add(obj);
                entities.SaveChanges();

            }
            List<UserTable> user = entities.UserTables.ToList();
            var users = EntityDtoMapping.Mapping.ToDtos(user);
            return users;
        }
        public List<UserDto> DeleteUser(string Id)
        {
            var obj2 = entities.UserTables.Where(a => a.empId == Id).FirstOrDefault();
            entities.UserTables.Remove(obj2);
            entities.SaveChanges();
            List<UserTable> user = entities.UserTables.ToList();
            var users = EntityDtoMapping.Mapping.ToDtos(user);
            return users;

        }
        public List<UserDto> EditUser(UserDto dto)
        {
            var id = dto.empId;
            var obj2 = entities.UserTables.Where(a => a.empId == id).FirstOrDefault();
            obj2.Name = dto.Name;
            obj2.UserName = dto.UserName;
            entities.SaveChanges();
            List<UserTable> user = entities.UserTables.ToList();
            var users = EntityDtoMapping.Mapping.ToDtos(user);
            return users;

        }
        public UserDto UploadUser(string id)
        {
            UserTable obj2 = entities.UserTables.Where(a => a.empId == id).FirstOrDefault();
            return EntityDtoMapping.Mapping.ToDto(obj2);
        }
        public string ActionUpdate(ReqDto dto)
        {
            var id = dto.Rid;
            var obj2 = entities.Requests.Where(a => a.Rid == id).FirstOrDefault();
            int count = entities.Requests.Where(a => a.Rid == id).Count();
            if (count > 0)
            {
                obj2.mode = dto.mode;
                entities.SaveChanges();
                return "Success";
            }
            else
            {
                return "failure";
            }
        }
        public List<ReqDto> ViewRequests()
        {
           List<Request> request = entities.Requests.Where(x => x.mode.Equals("pending")).ToList();
           var users = EntityDtoMapping.Mapping.requestDtos(request);
           return users;
        }
        public List<ReqDto> ViewAllRequests()
        {
            List<Request> request = entities.Requests.ToList();
            var users = EntityDtoMapping.Mapping.requestDtos(request);
            return users;
        }
    }
}

