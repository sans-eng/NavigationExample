using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NavigationExample.Contracts.Services
{
    public interface INavigationService
    {
        #region Properties
        bool HasContent { get; }
        #endregion Properties

        #region Methods
        bool NavigateTo(string pageKey);
        bool GoBack(); 
        void SetFrame(Frame frame);
        #endregion Methods
    }
}
