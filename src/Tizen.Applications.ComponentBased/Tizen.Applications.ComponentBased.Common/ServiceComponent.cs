using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.ComponentBased.Common
{
    /// <summary>
    /// The class for showing service module
    /// </summary>
    public abstract class ServiceComponent : ComponentBase
    {
        /// <summary>
        /// Overrides this method if want to handle behavior when the component is launched.
        /// </summary>
        /// <returns></returns>
        protected abstract bool OnCreate();

        /// <summary>
        /// Overrides this method if want to handle behavior when the component receives the appcontrol message.
        /// </summary>
        /// <param name="appControl">appcontrol object</param>
        /// <param name="restarted">True if it was restarted</param>
        protected virtual void OnStartCommand(CBAppControl appControl, bool restarted)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the component is terminated.
        /// </summary>
        protected virtual void OnDestroy()
        {
        }
    }
}
