using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.ComponentBased.Common
{
    /// <summary>
    /// The class for showing UI module
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public abstract class FrameComponent : BaseComponent
    {
        /// <summary>
        /// Gets the display status of a component.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when component type is already added to the component.</exception>
        /// <since_tizen> 6 </since_tizen>
        public DisplayStatus DisplayStatus
        {
            get
            {
                Interop.CBApplication.NativeDisplayStatus status;
                Interop.CBApplication.ErrorCode err = Interop.CBApplication.BaseFrameGetDisplayStatus(Handle, out status);
                if (err != Interop.CBApplication.ErrorCode.None)
                    throw new InvalidOperationException("Fail to get display status : err(" + err + ")");

                return (DisplayStatus)status;
            }
        }

        /// <summary>
        /// Gets the frame component's window information.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public IWindowInfo WindowInfo { get; internal set; }

        /// <summary>
        /// Overrides this method if want to handle behavior when the component is launched.
        /// </summary>
        /// <returns>Window object to use</returns>
        /// <since_tizen> 6 </since_tizen>
        public abstract IWindowInfo OnCreate();

        /// <summary>
        /// Overrides this method if want to handle behavior when the component receives the appcontrol message.
        /// </summary>
        /// <param name="appControl">appcontrol object</param>
        /// <param name="restarted">True if it was restarted</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void OnStart(AppControl appControl, bool restarted)
        {
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the component is resumed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void OnResume()
        {
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the component is paused.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void OnPause()
        {
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the component is stopped.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void OnStop()
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the component is destroyed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void OnDestroy()
        {
        }

        /// <summary>
        /// Gets the component type.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public override ComponentType ComponentType
        {
            get
            {
                return ComponentType.Frame;
            }
        }
    }
}
