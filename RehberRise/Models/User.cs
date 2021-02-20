using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RehberRise.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(50)]
        public string? Surname { get; set; }

        [MaxLength(50)]
        public string? Company { get; set; }
        public ICollection<Location> Locations { get; set; }
        public ICollection<Mail> Mails { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
