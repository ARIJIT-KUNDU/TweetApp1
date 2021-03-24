using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetApp1.Data;
using TweetApp1.DTOs;
using TweetApp1.Entities;

namespace TweetApp1.Services
{
    public class TweetService
    {
        private readonly TweetDto _tweetDto;
        private readonly IMapper _mapper;
        private readonly MemberDto _memberDto;
        private readonly TweetRepository _tweetRepository;
        private readonly Tweet _tweet;

        public TweetService(TweetDto tweetDto, IMapper mapper, MemberDto memberDto, TweetRepository tweetRepository, Tweet tweet)
        {
            _tweetDto = tweetDto;
            _mapper = mapper;
            _memberDto = memberDto;
            _tweetRepository = tweetRepository;
            _tweet = tweet;
        }

        //public Task<ICollection<TweetDto>> AddTweetAsync(int userid,TweetDto tweet)
        //{
        //    if (_memberDto.Id == userid)
        //    {
        //        _mapper.Map<ICollection<Tweet>>(tweet);
        //    }
        //    _tweetRepository.u
        //}
    }
}
