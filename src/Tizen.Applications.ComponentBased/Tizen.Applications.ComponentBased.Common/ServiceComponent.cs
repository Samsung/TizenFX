using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.ComponentBased.Common
{
    /// <summary>
    /// The class for showing service module
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public abstract class ServiceComponent : BaseComponent
    {
        /// <summary>
        /// Overrides this method if want to handle behavior when the component is created.
        /// </summary>
        /// <returns>True if a service component is successfully created</returns>
        public virtual bool OnCreate()
        {
            return true;
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the component receives the start command message.
        /// </summary>
        /// <param name="appControl">appcontrol object</param>
        /// <param name="restarted">True if it was restarted</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void OnStartCommand(AppControl appControl, bool restarted)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the component is destroyed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void OnDestroy()
        {
        }
    }
}
