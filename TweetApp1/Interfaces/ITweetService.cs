using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetApp1.DTOs;

namespace TweetApp1.Interfaces
{
    public interface ITweetService
    {
        Task<ICollection<TweetDto>> AddTweetAsync(int userid, TweetDto tweet);
    }
}
