using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetApp1.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }

        public ICollection<TweetDto> Tweets { get; set; }
    }
}
