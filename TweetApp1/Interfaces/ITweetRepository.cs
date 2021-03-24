using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetApp1.DTOs;

namespace TweetApp1.Interfaces
{
    public interface ITweetRepository
    {
        Task<IEnumerable<TweetDto>> GetTweetsAsync(int memberId);
    }
}
