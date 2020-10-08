using System;
using Transport.Notes.Domain.Models;

namespace Transport.Notes.WPF.State.Accounts
{
    public interface IAccountStore
    {
        Account CurrentAccount { get; set; }
        event Action StateChanged;
    }
}
