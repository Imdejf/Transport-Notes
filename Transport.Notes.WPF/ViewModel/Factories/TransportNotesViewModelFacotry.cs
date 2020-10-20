using System;
using Transport.Notes.WPF.State.Navigators;
using Transport.Notes.WPF.ViewModel.ControlViewModel;
using Transport.Notes.WPF.ViewModel.InventoryViewModel;

namespace Transport.Notes.WPF.ViewModel.Factories
{
    class TransportNotesViewModelFacotry : ITransportNotesViewModelFacotry
    {
        private readonly CreateViewModel<StartViewModel> _createStartViewModel;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
        private readonly CreateViewModel<DriversBaseViewModel> _createDriversBaseViewModel;
        private readonly CreateViewModel<MenageFleetViewModel> _createMenageFleetViewModel;
        private readonly CreateViewModel<VehicleEquipmentViewModel> _createVehicleEquipmentViewModel;
        private readonly CreateViewModel<GeneralInformationViewModel> _createGeneralInformationViewModel;

        public TransportNotesViewModelFacotry(CreateViewModel<LoginViewModel> createLoginViewModel, CreateViewModel<StartViewModel> createStartViewModel,
                                             CreateViewModel<DriversBaseViewModel> createDriversBaseViewModel, CreateViewModel<MenageFleetViewModel> createMenageFleetViewModel,
                                             CreateViewModel<VehicleEquipmentViewModel> createVehicleEquipmentViewModel,CreateViewModel<GeneralInformationViewModel> createGeneralInformationViewModel)
        {
            _createLoginViewModel = createLoginViewModel;
            _createStartViewModel = createStartViewModel;
            _createDriversBaseViewModel = createDriversBaseViewModel;
            _createMenageFleetViewModel = createMenageFleetViewModel;
            _createVehicleEquipmentViewModel = createVehicleEquipmentViewModel;
            _createGeneralInformationViewModel = createGeneralInformationViewModel;

        }
        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch(viewType)
            {
                case ViewType.Start:
                    return _createStartViewModel();
                case ViewType.Login:
                    return _createLoginViewModel();
                case ViewType.VehicleEquipment:
                    return _createVehicleEquipmentViewModel();
                case ViewType.MenageFleet:
                    return _createMenageFleetViewModel();
                case ViewType.DriversBase:
                    return _createDriversBaseViewModel();
                case ViewType.GeneralInformation:
                    return _createGeneralInformationViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel", "ViewType");        
            }
        }
    }
}
