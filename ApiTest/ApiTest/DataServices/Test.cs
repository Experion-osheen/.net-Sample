using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiTest.Data;
using ApiTest.DataServices;
using DTOS;
using ApiTest.EntityDtoMapping;

namespace ApiTest.DataServices
{
    public class Test : Itest
    {
        UserDetailsEntities entities = new UserDetailsEntities();
        public List<EmployeeDto> Display()
        {
            List<Detail> user = entities.Details.ToList();
            var users = EmployeeEntityDto.ToDtos(user);
            return users;
        }

        public List<EmployeeDto> Add(EmployeeDto dto)
        {
            if (dto != null || String.IsNullOrEmpty(dto.Band) || String.IsNullOrEmpty(dto.Name) || String.IsNullOrEmpty(dto.Department))
            {
                var obj = EmployeeEntityDto.ToEntity(dto);
                entities.Details.Add(obj);
                entities.SaveChanges();
            }
            List<Detail> user = entities.Details.ToList();
            var users = EmployeeEntityDto.ToDtos(user);
            return users;
        }
        public List<EmployeeDto> DeleteUser(int Id)
        {
            var obj2 = entities.Details.Where(a => a.Id == Id).FirstOrDefault();
            entities.Details.Remove(obj2);
            entities.SaveChanges();
            List<Detail> user = entities.Details.ToList();
            var users = EmployeeEntityDto.ToDtos(user);
            return users;

        }
        public List<EmployeeDto> EditUser(EmployeeDto dto)
        {
            var id = dto.Id;
            var obj2 = entities.Details.Where(a => a.Id == id).FirstOrDefault();
            obj2.Name = dto.Name;
            obj2.Band = dto.Band;
            obj2.Department = dto.Department;
            obj2.Age = dto.Age;
            entities.SaveChanges();
            List<Detail> user = entities.Details.ToList();
            var users = EmployeeEntityDto.ToDtos(user);
            return users;

        }
        public EmployeeDto UploadUser(int id)
        {
            Detail obj2 = entities.Details.Where(a => a.Id == id).FirstOrDefault();
            return EmployeeEntityDto.ToDto(obj2);
        }
    }

}