using NavigationExample.Activation;
using NavigationExample.Contracts.Services;
using NavigationExample.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NavigationExample.Services
{
    public class ActivationService : IActivationService
    {
        #region Private fields
        private readonly ActivationHandler<RoutedEventArgs> _navigationActivationHandler;
        private readonly IEnumerable<IActivationHandler> _activationHandlers;
        #endregion

        #region Constructors
        public ActivationService(ActivationHandler<RoutedEventArgs> navigationActivationHandler, IEnumerable<IActivationHandler> activationHandlers)
        {
            _navigationActivationHandler = navigationActivationHandler;
            _activationHandlers = activationHandlers;
        }
        #endregion Constructors

        #region Public methods
        public async Task ActivateAsync(object activationArgs)
        {
            await InitializeAsync();

            await HandleActivationAsync(activationArgs);

            await StartupAsync();
        }
        #endregion Public methods

        #region Private methods
        private async Task HandleActivationAsync(object activationArgs)
        {
            var activationHandler = _activationHandlers.FirstOrDefault(h => h.CanHandle(activationArgs));

            if (activationHandler != null)
            {
                await activationHandler.HandleAsync(activationArgs);
            }

            if (_navigationActivationHandler.CanHandle(activationArgs))
            {
                await _navigationActivationHandler.HandleAsync(activationArgs);
            }
        }
        private async Task InitializeAsync()
        {
            await Task.CompletedTask;
        }

        private async Task StartupAsync()
        {
            await Task.CompletedTask;
        }
        #endregion Private methods
    }
}
