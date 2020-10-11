using System.Threading.Tasks;
using Transport.Notes.Domain.Models;

namespace Transport.Notes.Domain.Services.AuthenticationService
{
    public enum RegisterResult
    {
        Succes,
        PasswordDoNotMatch,
        EmailAlreadyExists,
        UsernameAlreadyExists
    }
    public interface IAuthenticationService
    {
        Task<Account> Login(string username, string password);
        Task<RegisterResult> Register(string username,string email, string password, string confirmPassword);
    }
}
