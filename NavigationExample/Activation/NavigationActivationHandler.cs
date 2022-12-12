using NavigationExample.Contracts.Services;
using NavigationExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NavigationExample.Activation
{
    public class NavigationActivationHandler : ActivationHandler<RoutedEventArgs>
    {
        #region Private fields
        private readonly INavigationService _navigationService;
        #endregion Private fields

        #region Constructors
        public NavigationActivationHandler(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion Constructors

        #region Protected methods
        protected override bool CanHandleInternal(RoutedEventArgs args)
        {
            return !_navigationService.HasContent;
        }

        protected async override Task HandleInternalAsync(RoutedEventArgs args)
        {
            _navigationService.NavigateTo(typeof(HomeViewModel).FullName!);
            await Task.CompletedTask;
        }
        #endregion Protected methods
    }
}
