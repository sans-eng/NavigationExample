using CommunityToolkit.Mvvm.ComponentModel;
using NavigationExample.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NavigationExample.Services
{
    public class PageService : IPageService
    {
        #region Private fields
        private readonly Dictionary<string, Type> _pages = new();
        private readonly IServiceProvider _serviceProvider;
        #endregion Private fields

        #region Constructors
        public PageService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        #endregion Constructors

        #region Public methods
        public void Configure<ViewModel, View>()
            where ViewModel : ObservableObject
            where View : Page
        {
            lock (_pages)
            {
                var key = typeof(ViewModel).FullName!;
                if (_pages.ContainsKey(key))
                {
                    throw new ArgumentException($"The key {key} is already configured in PageService");
                }

                var type = typeof(View);
                if (_pages.Any(p => p.Value == type))
                {
                    throw new ArgumentException($"This type is already configured with key {_pages.First(p => p.Value == type).Key}");
                }

                _pages.Add(key, type);
            }
        }

        public Type GetPageType(string key)
        {
            Type? pageType;
            lock (_pages)
            {
                if (!_pages.TryGetValue(key, out pageType))
                {
                    throw new ArgumentException($"Page not found: {key}.");
                }
            }

            return pageType;
        }
        public Page GetPage(string key)
        {
            Type pageType = GetPageType(key);
            return _serviceProvider.GetService(pageType) as Page;
        }
        #endregion Public methods
    }
}
