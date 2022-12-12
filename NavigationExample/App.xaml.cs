using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NavigationExample.Activation;
using NavigationExample.Contracts.Services;
using NavigationExample.Services;
using NavigationExample.ViewModels;
using NavigationExample.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NavigationExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Constructors
        public App()
        {
            Host = Microsoft.Extensions.Hosting.Host.
       CreateDefaultBuilder().
       UseContentRoot(AppContext.BaseDirectory).
       ConfigureServices((context, services) =>
       {
           // Navigation Activation Handler
           services.AddTransient<ActivationHandler<RoutedEventArgs>, NavigationActivationHandler>();

           // Services
           services.AddTransient<INavigationViewService, NavigationViewService>();

           services.AddSingleton<IActivationService, ActivationService>();
           services.AddSingleton<IPageService, PageService>();
           services.AddSingleton<INavigationService, NavigationService>();

           // Views and ViewModels
           services.AddTransient<ShellView>();
           services.AddTransient<ShellViewModel>();
           services.AddTransient<HomePage>();
           services.AddTransient<HomeViewModel>();
           services.AddTransient<DataPage>();
           services.AddTransient<DataViewModel>();

           // Configuration
       }).
       Build();
        }
        #endregion Constructors

        #region Public properties
        public IHost Host { get; }
        #endregion Public properties

        #region Public methods
        public static T GetService<T>() where T : class
        {
            if ((App.Current as App)!.Host.Services.GetService(typeof(T)) is not T service)
            {
                throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.");
            }

            return service;
        }
        #endregion Public methods

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            IPageService pageService = GetService<IPageService>();
            pageService.Configure<HomeViewModel, HomePage>();
            pageService.Configure<DataViewModel, DataPage>();
        }
    }
}
