using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class NUIFrameComponent : FrameComponent
    {
        private bool defaultWindowSet = false;
        internal NUIWindowInfo NUIWindowInfo
        {
            get;
            set;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Window Window
        {
            get;
            set;
        }

        /// <summary>
        /// Overrides this method to create window. It will be called before OnCreate method.
        /// </summary>
        /// <returns>Window object to use</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override IWindowInfo CreateWindowInfo()
        {
            ComponentApplication instance = ComponentApplication.Instance as ComponentApplication;
            if (instance)
            {
                if (!defaultWindowSet)
                {
                    instance.GetWindow().WindowPositionSize = new Rectangle(0, 0, 1, 1);
                    instance.GetWindow().BackgroundColor = new Color(0, 0, 0, 0);
                    instance.GetWindow().Hide();
                    defaultWindowSet = true;
                }

                Window = new Window();
                Window.Show();
            }
            NUIWindowInfo = new NUIWindowInfo(Window);
            return NUIWindowInfo;
        }

        /// <summary>
        /// Overrides this method to handle behavior when the component is launched.
        /// </summary>
        /// <returns>True if a service component is successfully created</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool OnCreate()
        {
            return true;
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the component receives the appcontrol message.
        /// </summary>
        /// <param name="appControl">appcontrol object</param>
        /// <param name="restarted">True if it was restarted</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnStart(AppControl appControl, bool restarted)
        {
            base.OnStart(appControl, restarted);
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the component is resumed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnResume()
        {
            base.OnResume();
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the component is paused.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnPause()
        {
            base.OnPause();
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the component is stopped.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnStop()
        {
            base.OnStop();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the component is destroyed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}

