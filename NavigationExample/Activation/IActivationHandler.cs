using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationExample.Activation
{
    public interface IActivationHandler
    {
        #region Methods
        bool CanHandle(object args);

        Task HandleAsync(object args);
        #endregion Methods
    }
}
