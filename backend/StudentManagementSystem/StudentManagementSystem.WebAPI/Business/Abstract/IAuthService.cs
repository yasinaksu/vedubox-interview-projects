using StudentManagementSystem.WebAPI.Core.Utilities.Results;
using StudentManagementSystem.WebAPI.Core.Utilities.Security.JWT;
using StudentManagementSystem.WebAPI.Entities;
using StudentManagementSystem.WebAPI.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.WebAPI.Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<User>> RegisterAsync(User user, string password);
        Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLoginDto);
        Task<IDataResult<AccessToken>> CreateAccessTokenAsync(User user);
        Task<IResult> UserExists(string email);
    }
}
