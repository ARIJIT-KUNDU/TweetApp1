using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetApp1.Data;
using TweetApp1.DTOs;
using TweetApp1.Entities;
using TweetApp1.Interfaces;

namespace TweetApp1.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;

        public AccountController(DataContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Email)) return BadRequest("Username is taken");
            //using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                FirstName = registerDto.Firstname,
                LastName = registerDto.Lastname,
                Gender = registerDto.Gender,
                Dob = registerDto.Dob,
                Email = registerDto.Email.ToLower(),
                Password = registerDto.Password
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return new UserDto
            {
                Username = user.Email,
                Token = _tokenService.CreateToken(user)
            };
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == loginDto.Username);
            if (user == null) return Unauthorized("Invalid username");
            if (loginDto.Password != user.Password) return Unauthorized("Invalid password");
            return new UserDto
            {
                Username = user.Email,
                Token = _tokenService.CreateToken(user)
            };
        }
        private async Task<bool> UserExists(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email == email.ToLower());
        }
    }
}
