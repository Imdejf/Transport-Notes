using System;
using Transport.Notes.WPF.State.Navigators;

namespace Transport.Notes.WPF.ViewModel.Factories
{
    class TransportNotesViewModelFacotry : ITransportNotesViewModelFacotry
    {
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
        private readonly CreateViewModel<RegisterViewModel> _createRegisterViewModel;

        public TransportNotesViewModelFacotry(CreateViewModel<LoginViewModel> createLoginViewModel,CreateViewModel<RegisterViewModel> createRegisterViewModel)
        {
            _createLoginViewModel = createLoginViewModel;
            _createRegisterViewModel = createRegisterViewModel;
        }
        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch(viewType)
            {
                case ViewType.Login:
                    return _createLoginViewModel();
                case ViewType.Register:
                    return _createRegisterViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel", "ViewType");            }
        }
    }
}
