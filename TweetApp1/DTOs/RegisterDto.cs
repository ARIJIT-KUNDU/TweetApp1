using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TweetApp1.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [Required]
        public string Gender { get; set; }
        public DateTime Dob { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
