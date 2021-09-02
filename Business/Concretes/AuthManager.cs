using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstracts;
using Business.Messages;
using Core.Entities.Concretes;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entity.Concretes.Dtos;

namespace Business.Concretes
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            var result = _userService.Add(user);
            if (result.Success)
            {
                return new SuccessDataResult<User>(result.Message, user);

            }

            return new ErrorDataResult<User>(result.Message, null);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(UserMessages.UserLoginErrorMessage, null);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(UserMessages.UserLoginErrorMessage, null);
            }

            return new SuccessDataResult<User>(userToCheck.Data);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByEmail(email).Success)
            {
                return new ErrorResult(UserMessages.UserExistsMessage);
            }

            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            accessToken.user = user;
            accessToken.user.PasswordHash = null;
            accessToken.user.PasswordSalt = null;
       
            return new SuccessDataResult<AccessToken>(accessToken);
        }
    }
}
