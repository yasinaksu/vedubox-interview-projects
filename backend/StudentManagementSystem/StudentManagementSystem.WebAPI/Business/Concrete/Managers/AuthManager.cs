using StudentManagementSystem.WebAPI.Business.Abstract;
using StudentManagementSystem.WebAPI.Core.Utilities.Results;
using StudentManagementSystem.WebAPI.Core.Utilities.Security.Hashing;
using StudentManagementSystem.WebAPI.Core.Utilities.Security.JWT;
using StudentManagementSystem.WebAPI.DataAccess.Abstract;
using StudentManagementSystem.WebAPI.Entities;
using StudentManagementSystem.WebAPI.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.WebAPI.Business.Concrete.Managers
{
    public class AuthManager : IAuthService
    {
        private readonly IUserDal _userDal;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserDal userDal, ITokenHelper tokenHelper)
        {
            _userDal = userDal;
            _tokenHelper = tokenHelper;
        }

        public async Task<IDataResult<User>> RegisterAsync(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            
            await _userDal.AddAsync(user);
            return new SuccessDataResult<User>(user, "Kayıt oldu");
        }

        public async Task<IDataResult<AccessToken>> CreateAccessTokenAsync(User user)
        {
            var operationClaims = await _userDal.GetOperationClaimsAsync(user);
            var accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return new SuccessDataResult<AccessToken>(accessToken, "Token oluşturuldu");
        }

        public async Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLoginDto)
        {
            var user = await _userDal.GetAsync(x => x.Email == userForLoginDto.Email);
            if (user == null)
            {
                return new ErrorDataResult<Admin>("Kullanıcı bulunamadı.");
            }

            var verifyPasswordHashResult = HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt);
            if (verifyPasswordHashResult == false)
            {
                return new ErrorDataResult<Admin>("Kullanıcı bulunamadı.");
            }

            return new SuccessDataResult<User>(user, "Giriş başarılı");
        }

        public async Task<IResult> UserExists(string email)
        {
            if (await _userDal.GetAsync(x => x.Email == email) != null)
            {
                return new ErrorResult("Kullanıcı mevcut");
            }
            return new SuccessResult();
        }
    }
}
