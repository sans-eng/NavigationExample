using NavigationExample.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace NavigationExample.Services
{
    public class NavigationService : INavigationService
    {
        #region Private fields
        private readonly IPageService _pageService;
        private Frame? _frame;
        #endregion Private fields

        #region Constructors
        public NavigationService(IPageService pageService)
        {
            _pageService = pageService;
        }
        #endregion Constructors

        #region Public properties
        public bool HasContent => _frame?.Content != null;
        #endregion Public properties

        #region Public methods
        public bool GoBack()
        {
            return _frame != null && _frame.CanGoBack;
        }

        public bool NavigateTo(string pageKey)
        {
            var pageType = _pageService.GetPage(pageKey);

            if (_frame != null && _frame.Content != pageType)
            {
                return _frame.Navigate(pageType);
            }

            return false;
        }
        public void SetFrame(Frame frame)
        {
            _frame = frame;
        }
        #endregion Public methods

        #region Events
        public event NavigatedEventHandler? Navigated;
        #endregion Events
    }
}
