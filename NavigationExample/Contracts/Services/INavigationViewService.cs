using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace NavigationExample.Contracts.Services
{
    public interface INavigationViewService : IDisposable
    {
        #region Methods
        void Initialize(ListBox navigationBox);
        #endregion Methods
    }
}
