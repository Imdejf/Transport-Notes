using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using Transport.Notes.Domain.Models;
using Transport.Notes.Domain.Services;
using Transport.Notes.Domain.Services.AuthenticationService;
using Transport.Notes.Domain.Services.MenageFleetService;
using Transport.Notes.EntityFramework;
using Transport.Notes.EntityFramework.Services;
using Transport.Notes.WPF.State.Accounts;
using Transport.Notes.WPF.State.Authenticators;
using Transport.Notes.WPF.State.NavigatorControls;
using Transport.Notes.WPF.State.Navigators;
using Transport.Notes.WPF.ViewModel;
using Transport.Notes.WPF.ViewModel.ControlViewModel;
using Transport.Notes.WPF.ViewModel.ControlViewModel.FactoriesControl;
using Transport.Notes.WPF.ViewModel.Factories;
using Transport.Notes.WPF.ViewModel.InventoryViewModel;
using Transport.Notes.WPF.ViewModel.InventoryViewModel.MenageFleet;

namespace Transport.Notes.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();
            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<TransportNotesDbContextFacotry>();
            services.AddSingleton<IDataService<Account>, AccountDataService>();
            services.AddSingleton<IDataService<Vehicle>, VehicleDataService>();
            services.AddSingleton<IVehicleService, VehicleDataService>();
            services.AddSingleton<IAccountService, AccountDataService>();
            services.AddSingleton<IAccountStore, AccountStore>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            services.AddSingleton<ITransportNotesViewModelControlFacotry, TransportNotesViewModelControlFacotry>();
            services.AddSingleton<ITransportNotesViewModelFacotry, TransportNotesViewModelFacotry>();
            #region Views
            services.AddSingleton<StartViewModel>();
            services.AddSingleton<CreateViewModel<StartViewModel>>(services =>
            {
                return () => services.GetRequiredService<StartViewModel>();
            });

            services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
            services.AddSingleton<CreateViewModel<RegisterViewModel>>(services =>
            {
                return () => new RegisterViewModel(
                    services.GetRequiredService<IAuthenticator>(),
                    services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>(),
                    services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>()
                    );
            });

            services.AddSingleton<ViewModelDelegateRenavigator<StartViewModel>>();
            services.AddSingleton<ViewModelDelegateRenavigator<RegisterViewModel>>();
            services.AddSingleton<CreateViewModel<LoginViewModel>>(services =>
            {
                return () => new LoginViewModel(
                    services.GetRequiredService<IAuthenticator>(),
                    services.GetRequiredService<ViewModelDelegateRenavigator<StartViewModel>>(),
                    services.GetRequiredService<ViewModelDelegateRenavigator<RegisterViewModel>>()
                    ); ; 
            });

            #endregion

            #region ControlViews
            services.AddSingleton<InventoryControlViewModel>();
            services.AddSingleton<CreateViewModel<InventoryControlViewModel>>(services =>
            {
                return () => services.GetRequiredService<InventoryControlViewModel>();
            });
            #endregion

            #region InventoryViews
            services.AddSingleton<VehicleEquipmentViewModel>();
            services.AddSingleton<CreateViewModel<VehicleEquipmentViewModel>>(services =>
            {
                return () => services.GetRequiredService<VehicleEquipmentViewModel>();
            });
 
            services.AddSingleton<MenageFleetViewModel>();
            services.AddSingleton<CreateViewModel<MenageFleetViewModel>>(services =>
            {
                return () => services.GetRequiredService<MenageFleetViewModel>();
            });


            services.AddSingleton<DriversBaseViewModel>();
            services.AddSingleton<CreateViewModel<DriversBaseViewModel>>(services =>
            {
                return () => services.GetRequiredService<DriversBaseViewModel>();
            });

            services.AddSingleton<GeneralInformationViewModel>();
            services.AddSingleton<CreateViewModel<GeneralInformationViewModel>>(services =>
            {
                return () => services.GetRequiredService<GeneralInformationViewModel>();
            });
            #endregion
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<IMenageFleetService, MenageFleetService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<INavigatorControl, NavigatorControl>();
            services.AddSingleton<INavigator, Navigator>();

            services.AddScoped<MainViewModel>();
            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
           
        }
    }
}