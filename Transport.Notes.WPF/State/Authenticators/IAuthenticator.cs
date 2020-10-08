using System;
using System.Threading.Tasks;
using Transport.Notes.Domain.Models;

namespace Transport.Notes.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        Account CurrentAccount { get; }
        bool IsLoggedIn { get; }
        event Action StateChanged;
        Task Login(string username, string password);
        void Logout();
    }
}
