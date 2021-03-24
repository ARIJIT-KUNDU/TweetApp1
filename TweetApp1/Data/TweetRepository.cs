using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetApp1.DTOs;
using TweetApp1.Entities;
using TweetApp1.Interfaces;

namespace TweetApp1.Data
{
    public class TweetRepository : ITweetRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TweetRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TweetDto>> GetTweetsAsync(int memberId)
        {
            return await _context.Tweets.Where(x => x.AppUserId == memberId).ProjectTo<TweetDto>(_mapper.ConfigurationProvider).ToListAsync();

        }
        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
