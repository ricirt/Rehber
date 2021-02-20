using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RehberRise.Models
{
    public class PhoneNumber
    {
        [ScaffoldColumn(false)]
        public int PhoneNumberId { get; set; }
        public string Phone { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
    }
}
