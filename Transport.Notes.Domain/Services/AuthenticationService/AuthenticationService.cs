using Microsoft.AspNet.Identity;
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
                throw new UserNotFounException(username);
            }

            PasswordVerificationResult passwordVerification = _passwordHasher.VerifyHashedPassword(storedAccount.AccountHolder.PasswordHash, password);
            if(passwordVerification != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(username, password);
            }
            return storedAccount;
        }
    }
}
