using NavigationExample.Contracts.Services;
using NavigationExample.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Navigation;

namespace NavigationExample.Services
{
    public class NavigationViewService : INavigationViewService
    {
        #region Private fields
        private bool _disposed;
        private ListBox? _navigationBox;
        private readonly INavigationService _navigationService;
        private readonly IPageService _pageService;
        #endregion Private fields

        #region Constructors
        public NavigationViewService(INavigationService navigationService, IPageService pageService)
        {
            _navigationService = navigationService;
            _pageService = pageService;
        }
        #endregion Constructors

        #region Public methods
        public void Dispose() => Dispose(true);

        public void Initialize(ListBox navigationBox)
        {
            _navigationBox = navigationBox;
            _navigationBox.SelectionChanged += OnSelectionChanged;
        }
        #endregion Public methods

        #region Private methods
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_navigationBox != null)
                {
                    _navigationBox.SelectionChanged -= OnSelectionChanged;
                }
            }
            _disposed = true;
        }
        #endregion Private methods

        #region Event handlers
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListBox navigationBox &&
                navigationBox.SelectedItem is ListBoxItem selectedItem &&
                selectedItem?.GetValue(NavigationHelper.NavigateToProperty) is string pageKey)
            {
                _navigationService.NavigateTo(pageKey);
            }
        }
        #endregion Event handlers
    }
}
