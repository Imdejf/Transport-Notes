using System;
using System.Collections.Generic;
using System.Text;
using Transport.Notes.Domain.Models;

namespace Transport.Notes.WPF.State.Accounts
{
    public class AccountStore : IAccountStore
    {
        private Account _currentAccount;
        public Account CurrentAccount
        {
            get
            {
                return _currentAccount;
            }
            set
            {
                _currentAccount = value;
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;
    }
}
