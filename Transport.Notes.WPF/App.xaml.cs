using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Transport.Notes.Domain.Services;
using Transport.Notes.Domain.Services.AuthenticationService;
using Transport.Notes.EntityFramework.Services;
using Transport.Notes.WPF.State.Accounts;
using Transport.Notes.WPF.State.Authenticators;
using Transport.Notes.WPF.State.Navigators;
using Transport.Notes.WPF.ViewModel;
using Transport.Notes.WPF.ViewModel.Factories;
using Transport.Notes.WPF.Views;

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

            services.AddSingleton<IAccountService, AccountDataService>();

            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<IAccountStore, AccountStore>();
            services.AddSingleton<HomeViewModel>(services => new HomeViewModel(
            ));

            #region Views

            services.AddSingleton<CreateViewModel<HomeViewModel>>(services =>
            {
                return () => services.GetRequiredService<HomeViewModel>();
            });

            services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
            services.AddSingleton<CreateViewModel<RegisterViewModel>>(services =>
            {
                return () => new RegisterViewModel(
                    services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>()
                    ) ;
            });

            services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
            services.AddSingleton<ViewModelDelegateRenavigator<RegisterViewModel>>();
            services.AddSingleton<CreateViewModel<LoginViewModel>>(services =>
            {
                return () => new LoginViewModel(
                    services.GetRequiredService<IAuthenticator>(),
                    services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>(),
                    services.GetRequiredService<ViewModelDelegateRenavigator<RegisterViewModel>>()
                    ); 
            });

            #endregion

            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<ITransportNotesViewModelFacotry, TransportNotesViewModelFacotry>();
            services.AddSingleton<INavigator, Navigator>();

            services.AddScoped<MainViewModel>();
            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
           
        }
    }
}