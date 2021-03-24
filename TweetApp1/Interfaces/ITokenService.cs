﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetApp1.Entities;

namespace TweetApp1.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
