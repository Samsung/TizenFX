using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.ComponentBased.Common
{
    /// <summary>
    /// The class for showing service module
    /// </summary>
    public abstract class ServiceComponent : BaseComponent
    {
        /// <summary>
        /// Overrides this method if want to handle behavior when the component is created.
        /// </summary>
        /// <returns></returns>
        public virtual bool OnCreate()
        {
            return true;
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the component receives the start command message.
        /// </summary>
        /// <param name="appControl">appcontrol object</param>
        /// <param name="restarted">True if it was restarted</param>
        public virtual void OnStartCommand(AppControl appControl, bool restarted)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the component receives the action.
        /// </summary>
        /// <param name="action">Action name</param>
        /// <param name="appControl">appcontrol object</param>
        public virtual void OnAction(string action, AppControl appControl)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the component is destroyed.
        /// </summary>
        public virtual void OnDestroy()
        {
        }
    }
}
