using System;
using System.Threading.Tasks;
using Transport.Notes.Domain.Models;
using Transport.Notes.Domain.Services.AuthenticationService;

namespace Transport.Notes.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        Account CurrentAccount { get; }
        bool IsLoggedIn { get; }
        event Action StateChanged;
        Task Login(string username, string password);
        Task<RegisterResult> Register(string username, string email, string password, string confirmPassword);
        void Logout();
    }
}
