using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetApp1.DTOs;
using TweetApp1.Extensions;
using TweetApp1.Interfaces;

namespace TweetApp1.Controllers
{
    [ApiController]
    
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITweetService _tweetService;

        public UsersController(IUserRepository userRepository, IMapper mapper, ITweetService tweetService)
        {

            _userRepository = userRepository;
            _mapper = mapper;
            _tweetService = tweetService;
        }
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await _userRepository.GetMembersAsync();
            return Ok(users);


        }
        [HttpGet("{username}")]

        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            return await _userRepository.GetMemberAsync(username);


        }
        [HttpPut]
        public async Task<ActionResult> ResetPaswword(PasswordResetDto passwordResetDto)
        {

            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());
            if (user.Password == passwordResetDto.OldPassword)
                user.Password = passwordResetDto.NewPassword;
            _userRepository.Update(user);
            if (await _userRepository.SaveAllAsync()) return NoContent();
            return BadRequest("Failed to reset password");
        }
        //[HttpPost("add-tweet")]
        //public async Task<TweetDto> AddTweet(TweetDto tweet)
        //{
        //    var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());
        //    var result = await _tweetService.AddTweetAsync(tweet);
        //}
    }
}
