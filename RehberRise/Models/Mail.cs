using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RehberRise.Models
{
    public class Mail
    {
        [ScaffoldColumn(false)]
        public int MailId { get; set; }
        [EmailAddress]
        public string MailAdress{ get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
    }
}
