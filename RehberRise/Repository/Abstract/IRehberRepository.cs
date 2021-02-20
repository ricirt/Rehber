using RehberRise.Models;
using RehberRise.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehberRise.Repository.Abstract
{
    public interface IRehberRepository
    {
        List<User> GetAllUsersDetail();
        List<UserWithOutContact> GetUsers();
        User GetUserById(int id);
        User CreateUser(UserWithOutId user);
        User AddMail(Mail mail,int userId);
        User AddPhone(PhoneNumber phone,int userId);
        User AddLocation(Location location,int userId);
        User UpdateUser(UserWithOutContact user);
        void DeleteUser(int id);
        void DeleteMail(int mailId);
        void DeleteLocation(int locationId);
        void DeletePhone(int phoneId);
       
    }
}
