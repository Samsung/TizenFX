using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.ComponentBased.Common
{
    /// <summary>
    /// The class for showing UI module
    /// </summary>
    public abstract class FrameComponent : ComponentBase
    {
        public enum LcdStatus
        {
            On,
            Off
        }

        /// <summary>
        /// Current LCD status
        /// </summary>
        public LcdStatus CurrentLcdStatus { get; }

        /// <summary>
        /// Overrides this method if want to handle behavior when the component is launched.
        /// </summary>
        /// <returns>Window object to use</returns>
        protected abstract IWindow OnCreate();

        /// <summary>
        /// Overrides this method if want to handle behavior when the component receives the appcontrol message.
        /// </summary>
        /// <param name="appControl">appcontrol object</param>
        /// <param name="restarted">True if it was restarted</param>
        protected virtual void OnStart(CBAppControl appControl, bool restarted)
        {
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the component is resumed.
        /// </summary>
        protected virtual void OnResume()
        {
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the component is paused.
        /// </summary>
        protected virtual void OnPause()
        {
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the component is stopped.
        /// </summary>
        protected virtual void OnStop()
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
