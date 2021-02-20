using Microsoft.AspNetCore.Mvc;
using RehberRise.Business.Abstract;
using RehberRise.Business.Concrete;
using RehberRise.Models;
using RehberRise.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RehberRise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RehberController : ControllerBase
    {
        private readonly IRehberServices _rehberServices;

        public RehberController(IRehberServices rehberManager)
        {
            _rehberServices = rehberManager;
        }
        [HttpGet("GetUsers")]
        public List<UserWithOutContact> GetUsers()
        {
            return _rehberServices.GetUsers();
        }
        [HttpGet("GetUsersDetail")]
        public List<User> GetUsersDetail()
        {
            return _rehberServices.GetAllUsersDetail();
        }
        [HttpGet("GetUser/{id}")]
        public User Get(int id)
        {
            return _rehberServices.GetUserById(id);
        }

        [HttpPost]
        public User Post([FromBody] UserWithOutId user)
        {
            return _rehberServices.CreateUser(user);
        }
        [HttpPost("AddMail/{userId}")]
        public User Post([FromBody] Mail mail, int userId)
        {
            return _rehberServices.AddMail(mail,userId);
        }
        [HttpPost("AddPhone/{userId}")]
        public User Post([FromBody] PhoneNumber phone, int userId)
        {
            return _rehberServices.AddPhone(phone, userId);
        }
        [HttpPost("AddLocation/{userId}")]
        public User Post([FromBody] Location location, int userId)
        {
            return _rehberServices.AddLocation(location, userId);
        }
        [HttpPut]
        public User Put([FromBody] UserWithOutContact user)
        {
            return _rehberServices.UpdateUser(user);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {

            if (_rehberServices.GetUserById(id) == null) {

                _rehberServices.DeleteUser(id);
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("DeleteMail/{mailId}")]
        public void DeleteMail(int mailId)
        {
            _rehberServices.DeleteMail(mailId);
        }
        [HttpDelete("DeleteLocation/{locationId}")]
        public void DeleteLocation(int locationId)
        {
            _rehberServices.DeleteLocation(locationId);
        }
        [HttpDelete("DeletePhone/{phoneId}")]
        public void DeletePhone(int phoneId)
        {
            _rehberServices.DeletePhone(phoneId);
        }

        


    }
}
