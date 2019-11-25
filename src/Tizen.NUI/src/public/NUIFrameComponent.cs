using System;
using System.Collections.Generic;
using System.Text;
using Tizen.Applications;
using Tizen.Applications.ComponentBased.Common;
using Tizen.NUI;

namespace Tizen.NUI
{
    /// <summary>
    /// The class for showing UI module
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class NUIFrameComponent : FrameComponent
    {
        public Window Window
        {
            get;
            set;
        }
		
        public NUIWindowInfo NUIWindowInfo
        {
            get;
            set;
        }

        /// <summary>
        /// Overrides this method to handle behavior when the component is launched.
        /// </summary>
        /// <returns>True if a service component is successfully created</returns>
        /// <since_tizen> 6 </since_tizen>
        public override bool OnCreate()
        {
            return true;
        }

        /// <summary>
        /// Overrides this method to create window. It will be called before OnCreate method.
        /// </summary>
        /// <returns>Window object to use</returns>
        /// <since_tizen> 6 </since_tizen>
        public override IWindowInfo CreateWindowInfo()
        {
            Window = ComponentApplication.Instance.GetWindow();
			NUIWindowInfo = new NUIWindowInfo(Window);

			return NUIWindowInfo;
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the component receives the appcontrol message.
        /// </summary>
        /// <param name="appControl">appcontrol object</param>
        /// <param name="restarted">True if it was restarted</param>
        /// <since_tizen> 6 </since_tizen>
        public override void OnStart(AppControl appControl, bool restarted)
        {
            base.OnStart(appControl, restarted);
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the component is resumed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public override void OnResume()
        {
            base.OnResume();
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the component is paused.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public override void OnPause()
        {
            base.OnPause();
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the component is stopped.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public override void OnStop()
        {
            base.OnStop();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the component is destroyed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}

