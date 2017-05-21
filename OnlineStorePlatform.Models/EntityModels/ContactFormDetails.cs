using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorePlatform.Models.EntityModels
{
    public class ContactFormDetails
    {
        [Required(ErrorMessage = "Please enter your first name")]
        public string FirsName { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        public string PhoneNumber { get; set; }

        public string Subject { get; set; }

        [Required(ErrorMessage = "Please write message")]
        public string Message { get; set; }
    }
}
