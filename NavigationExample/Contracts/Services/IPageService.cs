using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NavigationExample.Contracts.Services
{
    public interface IPageService
    {
        #region Methods
        Type GetPageType(string key);
        void Configure<ViewModel, View>() 
        where ViewModel : ObservableObject
        where View : Page;
        Page GetPage(string key);
        #endregion Methods
    }
}
