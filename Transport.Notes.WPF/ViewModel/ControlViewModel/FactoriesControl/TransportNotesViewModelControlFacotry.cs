using System;
using Transport.Notes.WPF.State.NavigatorControls;

namespace Transport.Notes.WPF.ViewModel.ControlViewModel.FactoriesControl
{
    public class TransportNotesViewModelControlFacotry : ITransportNotesViewModelControlFacotry
    {
        private readonly CreateViewModel<InventoryControlViewModel> _createInventoryViewModel;

        public TransportNotesViewModelControlFacotry(CreateViewModel<InventoryControlViewModel> createInventoryViewModel)
        {
            _createInventoryViewModel = createInventoryViewModel;

        }
        public ViewModelBase CreateViewModel(ViewTypeControl viewType)
        {
            switch (viewType)
            {
                case ViewTypeControl.Inventory:
                    return _createInventoryViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel", "ViewType");
            }
        }
    }
}
