using RehberRise.Business.Abstract;
using RehberRise.Models;
using RehberRise.Repository.Abstract;
using RehberRise.Repository.Concrete;
using RehberRise.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehberRise.Business.Concrete
{
    public class RehberManager : IRehberServices
    {
        private IRehberRepository _rehberRepository;

        public RehberManager(IRehberRepository rehberRepository)
        {
            _rehberRepository = rehberRepository;
        }
        public User CreateUser(UserWithOutId user)
        {
            return _rehberRepository.CreateUser(user);
        }


        public void DeleteUser(int id)
        {
            _rehberRepository.DeleteUser(id);
        }

        public List<User> GetAllUsersDetail()
        {
            return _rehberRepository.GetAllUsersDetail();
        }


        public User GetUserById(int id)
        {
            return _rehberRepository.GetUserById(id);
        }

        public User UpdateUser(UserWithOutContact user)
        {
            return _rehberRepository.UpdateUser(user);
        }
        public User AddMail(Mail mail, int userId)
        {
            return _rehberRepository.AddMail(mail, userId);
        }

        public User AddPhone(PhoneNumber phone, int userId)
        {
            return _rehberRepository.AddPhone(phone, userId);
        }

        public User AddLocation(Location location, int userId)
        {
            return _rehberRepository.AddLocation(location, userId);
        }

        public void DeleteMail(int mailId)
        {
            _rehberRepository.DeleteMail(mailId);
        }

        public void DeleteLocation(int locationId)
        {
            _rehberRepository.DeleteLocation(locationId);
            }

        public void DeletePhone(int phoneId)
        {
            _rehberRepository.DeletePhone(phoneId);
        }

        public List<UserWithOutContact> GetUsers()
        {
           return _rehberRepository.GetUsers();
        }
    }
}
