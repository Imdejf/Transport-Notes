using System;
using Transport.Notes.WPF.State.Navigators;
using Transport.Notes.WPF.ViewModel.ControlViewModel;

namespace Transport.Notes.WPF.ViewModel.Factories
{
    class TransportNotesViewModelFacotry : ITransportNotesViewModelFacotry
    {
        private readonly CreateViewModel<StartViewModel> _createStartViewModel;
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;

        private readonly CreateViewModel<InventoryControlViewModel> _createInventoryControlViewModel;
        public TransportNotesViewModelFacotry(CreateViewModel<HomeViewModel> createHomeViewModel, CreateViewModel<LoginViewModel> createLoginViewModel,
                                              CreateViewModel<StartViewModel> createStartViewModel,CreateViewModel<InventoryControlViewModel> createInventoryControlViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createLoginViewModel = createLoginViewModel;
            _createStartViewModel = createStartViewModel;

            _createInventoryControlViewModel = createInventoryControlViewModel;

        }
        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch(viewType)
            {
                case ViewType.Start:
                    return _createStartViewModel();
                case ViewType.Home:
                    return _createHomeViewModel();
                case ViewType.Login:
                    return _createLoginViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel", "ViewType");        
            }
        }
    }
}
