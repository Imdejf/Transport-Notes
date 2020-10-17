using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using Transport.Notes.Domain.Exceptions;
using Transport.Notes.Domain.Expections;
using Transport.Notes.Domain.Models;

namespace Transport.Notes.Domain.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    { 
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IAccountService accountService, IPasswordHasher passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }

        public async Task<Account> Login(string username, string password)
        {
            Account storedAccount = await _accountService.GetByUsername(username);
            
            if(storedAccount == null)
            {
                throw new UserNotFoundException(username);
            }

            PasswordVerificationResult passwordVerification = _passwordHasher.VerifyHashedPassword(storedAccount.AccountHolder.PasswordHash, password);
            if(passwordVerification != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(username, password);
            }
            return storedAccount;
        }

        public async Task<RegisterResult> Register(string username, string email, string password, string confirmPassword)
        {
            RegisterResult result = RegisterResult.Succes;
            if(password != confirmPassword)
            {
                result = RegisterResult.PasswordDoNotMatch; 
            }

            Account emailAccount = await _accountService.GetByEmail(email);
            if(emailAccount != null)
            {
                result = RegisterResult.EmailAlreadyExists;
            }
            Account usernameAccount = await _accountService.GetByUsername(username);
            if(usernameAccount != null)
            {
                result = RegisterResult.UsernameAlreadyExists;
            }
            if(result == RegisterResult.Succes)
            {
                string hashedPassword = _passwordHasher.HashPassword(password);

                User user = new User()
                {
                    Username = username,
                    Email = email,
                    PasswordHash = hashedPassword,
                    DateJoined = DateTime.Now
                };
                Account account = new Account()
                { 
                    AccountHolder = user
                };
                await _accountService.Create(account);
            }
            return result;
        }
    }
}
