using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetApp1.DTOs;
using TweetApp1.Interfaces;

namespace TweetApp1.Controllers
{
    public class TweetsController : BaseApiController
    {
        private readonly ITweetRepository _tweetRepository;
        private readonly IMapper _mapper;

        public TweetsController(ITweetRepository tweetRepository, IMapper mapper)
        {
            _tweetRepository = tweetRepository;
            _mapper = mapper;
        }
        [HttpGet("{memberId}")]

        public async Task<ActionResult<IEnumerable<TweetDto>>> GetUsers(int memberId)
        {
            var tweets = await _tweetRepository.GetTweetsAsync(memberId);
            return Ok(tweets);


        }
    }
}
