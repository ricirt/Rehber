using RehberRise.Models;
using RehberRise.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehberRise.Business.Abstract
{
    public interface IRehberServices
    {
       
        User CreateUser(UserWithOutId user);
        List<UserWithOutContact> GetUsers();
        List<User> GetAllUsersDetail();
        User GetUserById(int id);
        User UpdateUser(UserWithOutContact user);
        void DeleteUser(int id);
        void DeleteMail(int mailId);
        void DeleteLocation(int locationId);
        void DeletePhone(int phoneId);
        User AddMail(Mail mail, int userId);
        User AddPhone(PhoneNumber phone, int userId);
        User AddLocation(Location location, int userId);
   
    }
}
