using Business.Abstract;
using Core.Entities.Concrete;
using Core.Security.Hashing;
using Core.Security.JWT;
using Core.Utilities.Helpers.EmailHelper;
using Core.Utilities.Logger;
using Core.Utilities.Results;
using Entities.DTOs;


namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IUserOperationClaimService _userOperationClaimService;
        private IEmailSenderService _emailSenderService;
        private ILoggerService _loggerService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimService userOperationClaimService,IEmailSenderService emailSenderService,ILoggerService loggerService)
        {
            _userService = userService;
            _userOperationClaimService = userOperationClaimService;
            _tokenHelper = tokenHelper;
            _emailSenderService = emailSenderService;
            _loggerService = loggerService;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                AccessFailedCount = 0
            };
            _userService.Add(user);
            var getUser = _userService.GetByMail(userForRegisterDto.Email);
            var claim = new UserOperationClaim
            {
                UserId = getUser.UserId,
                OperationClaimId = 1

            };
            _userOperationClaimService.Add(claim);
            _loggerService.LogInfo("POST Register");
            return new SuccessDataResult<User>(user, "Registered");
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            string message = "Your Account has been blocked";
            string subject = "Your Account Blocked";
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>("User not found");
            }
            if (userToCheck.Status==false)
            {
                return new ErrorDataResult<User>("Blocked Account");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
       
                _userService.UpdateAccessFailedCount(userToCheck.UserId,userToCheck.AccessFailedCount);
               
                if (userToCheck.AccessFailedCount >= 2)
                {
                    _userService.UpdateUserStatus(userToCheck.UserId, false);
                    _emailSenderService.SendEmail(userToCheck.Email,message,subject);
                    return new ErrorDataResult<User>("Account Blocked , Email Sended");
                }
                return new ErrorDataResult<User>("Wrong Password");
            }
            _loggerService.LogInfo("POST Login");
            return new SuccessDataResult<User>(userToCheck, "Success");
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult("User already exist");
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Token created");
        }

        public IResult SendWelcomeEmail(string email)
        {
            string message = "Welcome - Mehmet Akif Özdemir Primefor Staj";
            string subject = "Welcome";
            _emailSenderService.SendEmail(email,message,subject);
            _loggerService.LogInfo("POST EmailSended");
            return new SuccessResult("E-Mail Sended");
        }

    }
}
