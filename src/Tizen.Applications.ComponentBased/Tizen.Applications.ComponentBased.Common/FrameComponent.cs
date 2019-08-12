using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.ComponentBased.Common
{
    /// <summary>
    /// The class for showing UI module
    /// </summary>
    public abstract class FrameComponent : BaseComponent
    {
        /// <summary>
        /// Overrides this method if want to handle behavior when the component is launched.
        /// </summary>
        /// <returns>Window object to use</returns>
        public virtual IWindow OnCreate()
        {
            return null;
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the component receives the appcontrol message.
        /// </summary>
        /// <param name="appControl">appcontrol object</param>
        /// <param name="restarted">True if it was restarted</param>
        public virtual void OnStart(AppControl appControl, bool restarted)
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
        /// Overrides this method if you want to handle the behavior when the component is resumed.
        /// </summary>
        public virtual void OnResume()
        {
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the component is paused.
        /// </summary>
        public virtual void OnPause()
        {
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the component is stopped.
        /// </summary>
        public virtual void OnStop()
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the component is terminated.
        /// </summary>
        public virtual void OnDestroy()
        {
        }

        /// <summary>
        /// Overrides this method if you want to specify a type of this component.
        /// Default component type is Service type.
        /// </summary>
        public override ComponentType GetComponentType()
        {
            return BaseComponent.ComponentType.Frame;
        }
    }
}
