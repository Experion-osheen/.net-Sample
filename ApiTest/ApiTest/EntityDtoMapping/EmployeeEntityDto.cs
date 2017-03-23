using DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiTest.Data;
namespace ApiTest.EntityDtoMapping
{
    public class EmployeeEntityDto
    {
        public static Detail ToEntity(EmployeeDto dto)
        {
            Detail obj = new Detail();
            if (dto != null)
            {
                obj.Id = dto.Id;
                obj.Name = dto.Name;
                obj.Band = dto.Band;
                obj.Department = dto.Department;
                obj.Age = dto.Age;
             
            }
            return obj;
        }
        public static EmployeeDto ToDto(Detail obj)
        {
            EmployeeDto dto = new EmployeeDto();
            if (obj != null)
            {
                dto.Id = obj.Id;
                dto.Age = obj.Age;
                dto.Band = obj.Band;
                dto.Name = obj.Name;
                dto.Department = obj.Department;
            }
            return dto;
        }
        public static List<EmployeeDto> ToDtos(List<Detail> objs)
        {
            List<EmployeeDto> dtos = new List<EmployeeDto>();
            if (objs != null)
            {
                foreach(var obj in objs)
                {
                    dtos.Add(ToDto(obj));
                }
            }
            return dtos;
        }
    }
}