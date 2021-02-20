using RehberRise.DataBase;
using RehberRise.Models;
using RehberRise.Repository.Abstract;
using RehberRise.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace RehberRise.Repository.Concrete
{
    public class RehberRepository : IRehberRepository
    {
        private DatabaseContext dc = new DatabaseContext();

        public User AddLocation(Location location, int userId)
        {
            location.UserId = userId;
            dc.Locations.Add(location);
            dc.SaveChanges();
            return GetUserById(userId);
        }

        public User AddMail(Mail mail, int userId)
        {
            mail.UserId = userId;
            dc.Mails.Add(mail);
            dc.SaveChanges();
            return GetUserById(userId);
        }

        public User AddPhone(PhoneNumber phone, int userId)
        {
            phone.UserId = userId;
            dc.PhoneNumbers.Add(phone);
            dc.SaveChanges();
            return GetUserById(userId);
        }

        public User CreateUser(UserWithOutId user)
        {
            User person = new User()
            {
                Name = user.Name,
                Surname = user.Surname,
                Company = user.Company,

            };
            dc.Add(person);
            dc.SaveChanges();
            return person;
        }


        public void DeleteUser(int id)
        {

            var deletedUser = GetUserById(id);
            if (deletedUser == null)
            {
                return;
            }
            dc.Remove(deletedUser);
            dc.SaveChanges();

        }
        public List<UserWithOutContact> GetUsers()
        {
            var users = (from u in dc.Users
                         select new UserWithOutContact()
                         {
                             Id = u.Id,
                             Name = u.Name,
                             Surname = u.Surname,
                             Company = u.Company,

                         }
             ).ToList();
            return users;
        }
        public List<User> GetAllUsersDetail()
        {
            var users = (from u in dc.Users
                         select new User()
                         {
                             Id = u.Id,
                             Name = u.Name,
                             Surname = u.Surname,
                             Company = u.Company,

                         }
                         ).ToList();
            foreach (var user in users)
            {
                user.Mails = (from m in dc.Mails
                              where m.UserId == user.Id
                              select new Mail()
                              {
                                  MailId = m.MailId,
                                  MailAdress = m.MailAdress,
                                  UserId = m.UserId
                              }).ToList();
                user.Locations = (from l in dc.Locations
                                  where l.UserId == user.Id
                                  select new Location()
                                  {
                                      LocationId = l.LocationId,
                                      LocationName = l.LocationName,
                                      UserId = l.UserId

                                  }).ToList();
                user.PhoneNumbers = (from p in dc.PhoneNumbers
                                     where p.UserId == user.Id
                                     select new PhoneNumber()
                                     {
                                         PhoneNumberId = p.PhoneNumberId,
                                         Phone = p.Phone,
                                         UserId = p.UserId

                                     }).ToList();

            }
            try
            {
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public User GetUserById(int id)
        {

            var user = (from u in dc.Users
                        where u.Id == id
                        select new User()
                        {
                            Id = u.Id,
                            Name = u.Name,
                            Surname = u.Surname,
                            Company = u.Company,
                        }
                          ).FirstOrDefault();
            if (user == null)
                return null;

            user.Mails = (from m in dc.Mails
                          where m.UserId == user.Id
                          select new Mail()
                          {
                              MailId = m.MailId,
                              MailAdress = m.MailAdress,
                              UserId = m.UserId
                          }).ToList();
            user.Locations = (from l in dc.Locations
                              where l.UserId == user.Id
                              select new Location()
                              {
                                  LocationId = l.LocationId,
                                  LocationName = l.LocationName,
                                  UserId = l.UserId

                              }).ToList();
            user.PhoneNumbers = (from p in dc.PhoneNumbers
                                 where p.UserId == user.Id
                                 select new PhoneNumber()
                                 {
                                     PhoneNumberId = p.PhoneNumberId,
                                     Phone = p.Phone,
                                     UserId = p.UserId

                                 }).ToList();
            try
            {
                return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public User UpdateUser(UserWithOutContact user)
        {

            var person = GetUserById(user.Id);
            person.Name = user.Name;
            person.Surname = user.Surname;
            person.Company = user.Company;
            dc.Users.Update(person);
            dc.SaveChanges();
            return person;
        }
        public void DeleteMail(int mailId)
        {

            var mail = dc.Mails.FirstOrDefault(x => x.MailId == mailId);
            if (mail == null)
            {
                return;
            }
            dc.Mails.Remove(mail);
            dc.SaveChanges();
        }

        public void DeleteLocation(int locationId)
        {
            var location = dc.Locations.FirstOrDefault(x => x.LocationId == locationId);
            dc.Locations.Remove(location);
            dc.SaveChanges();
        }

        public void DeletePhone(int phoneId)
        {
            var phone = dc.PhoneNumbers.FirstOrDefault(x => x.PhoneNumberId == phoneId);
            dc.PhoneNumbers.Remove(phone);
            dc.SaveChanges();
        }
    }
}
