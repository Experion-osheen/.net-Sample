using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelApi.Data;
using DTOs;

namespace TravelApi.EntityDtoMapping
{
    public class Mapping
    {
       public static ReqDto requestDto(Request req)
        {
            ReqDto dto = new ReqDto();
            dto.cause = req.cause;
            dto.empid = req.empid;
            dto.Rid = req.Rid;
            dto.Fromdate = req.Fromdate;
            dto.Todate = req.Todate;
            dto.noDays = req.noDays;
            dto.pid = req.pid;
            dto.source = req.source;
            dto.Destination = req.Destination;
            dto.mode = req.mode;
            return dto;
        }
        public static List<ReqDto> requestDtos(List<Request> reqs)
        {
            List<ReqDto> dtos = new List<ReqDto>();
            foreach (var req in reqs)
            {
                ReqDto dto = new ReqDto();
                dto.cause = req.cause;
                dto.empid = req.empid;
                dto.Rid = req.Rid;
                dto.Fromdate = req.Fromdate;
                dto.Todate = req.Todate;
                dto.noDays = req.noDays;
                dto.pid = req.pid;
                dto.source = req.source;
                dto.Destination = req.Destination;
                dto.mode = req.mode;
                dtos.Add(dto);
            }
            return dtos;
        }
        public static Request requestEntity (ReqDto req)
        {
            Request dto = new Request();
            dto.cause = req.cause;
            dto.empid = req.empid;
            dto.Rid = req.Rid;
            dto.Fromdate = req.Fromdate;
            dto.Todate = req.Todate;
            dto.noDays = req.noDays;
            dto.pid = req.pid;
            dto.source = req.source;
            dto.Destination = req.Destination;
            dto.mode = req.mode;
            return dto;

        }
        public static UserTable ToEntity(UserDto dto)
        {
            UserTable obj = new UserTable();
            if (dto != null)
            {
                obj.empId = dto.empId;
                obj.Name = dto.Name;
                obj.Password = dto.Password;
                obj.Status = dto.Status;
                obj.UserName = dto.UserName;
                obj.Password = dto.Password;
            }
            return obj;
        }

        public static List<UserTable> ToEntities(List<UserDto> dtos)
        {
            List<UserTable> entities = new List<UserTable>();
            foreach (var dto in dtos)
            {
                if (dto != null)
                {
                    UserTable obj = new UserTable();
                    obj.empId = dto.empId;
                    obj.Name = dto.Name;
                    obj.Password = dto.Password;
                    obj.Status = dto.Status;
                    obj.UserName = dto.UserName;
                    obj.Password = dto.Password;
                    entities.Add(obj);
                }

            }
            return entities;
        }
        public static UserDto ToDto(UserTable obj)
        {
            UserDto dto = new UserDto();
            dto.Name = obj.Name;
            dto.empId = obj.empId;
            dto.Password = obj.Password;
            dto.Status = obj.Status;
            dto.UserName = obj.UserName;
            return dto;

        }
        public static List<UserDto> ToDtos(List<UserTable> dtos)
        {
            List<UserDto> entities = new List<UserDto>();
            foreach (var dto in dtos)
            {
                if (dto != null)
                {
                    UserDto obj = new UserDto();
                    obj.empId = dto.empId;
                    obj.Name = dto.Name;
                    obj.Password = dto.Password;
                    obj.Status = dto.Status;
                    obj.UserName = dto.UserName;
                    obj.Password = dto.Password;
                    entities.Add(obj);
                }

            }
            return entities;
        }
        public static List<ProjectDto> ToProjDto(List<Project> pro)
        {
            List<ProjectDto> pdtos = new List<ProjectDto>();
            foreach(var p in pro)
            {
                ProjectDto pdto = new ProjectDto();
                pdto.Pid = p.Pid;
                pdto.Pname = p.Pname;
                pdtos.Add(pdto);
            }
            
            return pdtos;
        } 

    }
}


