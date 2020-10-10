using System;
using Transport.Notes.WPF.State.Navigators;

namespace Transport.Notes.WPF.ViewModel.Factories
{
    class TransportNotesViewModelFacotry : ITransportNotesViewModelFacotry
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;

        public TransportNotesViewModelFacotry(CreateViewModel<HomeViewModel> createHomeViewModel,CreateViewModel<LoginViewModel> createLoginViewModel
                                              )
        {
            _createHomeViewModel = createHomeViewModel;
            _createLoginViewModel = createLoginViewModel;

        }
        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch(viewType)
            {
                case ViewType.Home:
                    return _createHomeViewModel();
                case ViewType.Login:
                    return _createLoginViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel", "ViewType");            }
        }
    }
}
