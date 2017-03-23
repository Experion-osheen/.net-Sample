using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelApi.Data;
using DTOs;
using System.Net.Mail;
using System.Net;
using TravelApi.Controllers;

namespace TravelApi.DataServices
{
   
    public class UserService : IUserService
    {
        TravelEntities1 entities = new TravelEntities1();
        public string Login(UserDto obj)
        {
            var user = entities.UserTables.Where(a => (a.empId == obj.empId && a.Password == obj.Password)).FirstOrDefault();
            int count = entities.UserTables.Where(a => (a.empId == obj.empId && a.Password == obj.Password)).Count();
            if (count > 0)
            {
                return user.Status;
            }

            else
                return "false";

        }

        public List<ReqDto> show(string empId)
        {
            List<Request> request = entities.Requests.Where(x => (x.empid.Equals(empId) && x.mode.Equals("Pending"))).ToList();
            var users = EntityDtoMapping.Mapping.requestDtos(request);
            return users;
        }


        public void sendMail(string Email, string subject, string body)
        {
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("rubyrestaurant17@gmail.com", "wwwwwwww");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("rubyrestaurant17@gmail.com");
            mail.To.Add(Email);
            mail.IsBodyHtml = true;
            string htmlBody;
            htmlBody = "<body><h4>" + body + "</h4></body>";
            mail.Body = htmlBody;
            mail.Subject = subject;
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }



        public List<ReqDto> AddRequest(ReqDto dto)
        {
            var obj = EntityDtoMapping.Mapping.requestEntity(dto);
            entities.Requests.Add(obj);
            entities.SaveChanges();
            UserTable obj2 = entities.UserTables.Where(a => a.empId == dto.empid).FirstOrDefault();
            string body = "A new Request from " + obj2.Name + " has been added to travel desk.\n please verify  it \n \n Yours HR";
            string subject = "Request Added";
            sendMail(obj2.UserName, subject, body);
            List<Request> user = entities.Requests.Where(x => (x.empid.Equals(dto.empid) && x.mode.Equals("Pending"))).ToList();
            var users = EntityDtoMapping.Mapping.requestDtos(user);
            return users;
        }
        public List<ProjectDto> GetProject()
        {
            List<Project> obj2 = entities.Projects.ToList();
            var obj = EntityDtoMapping.Mapping.ToProjDto(obj2);
            return obj;
        }
        public List<ReqDto> DeleteRequest(int Id)
        {
            var obj2 = entities.Requests.Where(a => a.Rid == Id).FirstOrDefault();
            var id1 = obj2.empid;
            entities.Requests.Remove(obj2);
            entities.SaveChanges();
            List<Request> user = entities.Requests.Where(x => (x.empid.Equals(id1) && x.mode.Equals("Pending"))).ToList();
            var users = EntityDtoMapping.Mapping.requestDtos(user);
            return users;

        }
        public ReqDto UploadRequest(int id)
        {
            var obj2 = entities.Requests.Where(a => a.Rid == id).FirstOrDefault();
            return EntityDtoMapping.Mapping.requestDto(obj2);
        }
        public List<ReqDto> EditUpdate(ReqDto dto)
        {
            var obj2 = entities.Requests.Where(a => a.Rid == dto.Rid).FirstOrDefault();
            obj2.cause = dto.cause;
            obj2.pid = dto.pid;
            obj2.source = dto.source;
            obj2.Destination = dto.Destination;
            obj2.Fromdate = dto.Fromdate;
            obj2.Todate = dto.Todate;
            obj2.noDays = dto.noDays;
            entities.SaveChanges();
            List<Request> user = entities.Requests.Where(x => (x.empid.Equals(dto.empid) && x.mode.Equals("Pending"))).ToList();
            var users = EntityDtoMapping.Mapping.requestDtos(user);
            return users;

        }

        public string ChangePin(string password,string empid)
        {
            var obj2 = entities.UserTables.Where(a => a.empId == empid).FirstOrDefault();
            obj2.Password = password;
            entities.SaveChanges();
            return "success";

        }
        public List<ReqDto> UserRequests(string empId)
        {
            List<Request> request = entities.Requests.Where(x => (x.empid.Equals(empId))).ToList();
            var users = EntityDtoMapping.Mapping.requestDtos(request);
            return users;
        }

    }
}