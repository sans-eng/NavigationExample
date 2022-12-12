using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationExample.Activation
{
    public abstract class ActivationHandler<T> : IActivationHandler
    where T : class
    {
        #region Public methods
        public bool CanHandle(object args) => args is T && CanHandleInternal((args as T)!);

        public async Task HandleAsync(object args) => await HandleInternalAsync((args as T)!);
        #endregion Public methods

        #region Protected methods
        protected virtual bool CanHandleInternal(T args) => true;
        protected abstract Task HandleInternalAsync(T args);
        #endregion Protected methods
    }
}
