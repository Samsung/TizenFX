using ElmSharp;
using System;
using System.Collections.Generic;
using Tizen.Applications.ComponentBased.Common;

namespace Tizen.Applications.ComponentBased.Default
{
    /// <summary>
    /// Basic type application which will support ElmWindow for FrameComponent
    /// </summary>
    public class CBBasicApplication : CBApplicationBase
    {
        internal static readonly string LogTag = typeof(CBBasicApplication).Namespace;

        /// <summary>
        /// Initializes the CBBasicApplication class.
        /// </summary>
        /// <param name="typeInfo">The compnent type information.</param>
        /// <since_tizen> 6 </since_tizen>
        public CBBasicApplication(IDictionary<Type, string> typeInfo) : base(typeInfo)
        {
        }

        /// <summary>
        /// This method will be called before running main-loop
        /// </summary>
        /// <param name="args"></param>
        protected override void OnInit(string[] args)
        {
            Interop.Elementary.ElmInit(args.Length, args);
            string hwacc = Environment.GetEnvironmentVariable("HWACC");

            if (hwacc == "USE")
            {
                Interop.Elementary.ElmConfigAccelPreferenceSet("hw");
                Log.Info(LogTag, "elm_config_accel_preference_set: hw");
            }
            else if (hwacc == "NOT_USE")
            {
                Interop.Elementary.ElmConfigAccelPreferenceSet("none");
                Log.Info(LogTag, "elm_config_accel_preference_set: none");
            }
            else
            {
                Log.Info(LogTag, "elm_config_accel_preference_set is not called");
            }
        }

        /// <summary>
        /// This method will be called after exiting main-loop
        /// </summary>
        protected override void OnFini()
        {
            Interop.Elementary.ElmShutdown();
            if (Environment.GetEnvironmentVariable("AUL_LOADER_INIT") == null)
                return;

            Environment.SetEnvironmentVariable("AUL_LOADER_INIT", null);
            Interop.Elementary.ElmShutdown();
        }

        /// <summary>
        /// This method will be called to start main-loop
        /// </summary>
        protected override void OnRun()
        {
            Interop.Elementary.ElmRun();
        }

        /// <summary>
        /// This method will be called to exit main-loop
        /// </summary>
        protected override void OnExit()
        {
            Interop.Elementary.ElmExit();
        }
    }

    /// <summary>
    /// Window class for basic application type
    /// </summary>
    public class ElmWindow : IWindow
    {
        internal static readonly string LogTag = typeof(ElmWindow).Namespace;
        private EvasObject _win;
        private int _resId;

        /// <summary>
        /// Initializes the CBBasicApplication class.
        /// </summary>
        /// <param name="win">The window object of component.</param>
        /// <since_tizen> 6 </since_tizen>
        public ElmWindow(EvasObject win)
        {
            _win = win;
        }

        /// <summary>
        /// Gets the raw handle of window
        /// </summary>
        /// <returns>The native handle of window</returns>
        /// <since_tizen> 6 </since_tizen>
        public IntPtr GetRaw()
        {
            return _win.RealHandle;
        }

        /// <summary>
        /// Gets the resource ID of window
        /// </summary>
        /// <returns>The native handle of window</returns>
        /// <since_tizen> 6 </since_tizen>
        public int GetResId()
        {
            if (_resId == 0)
            {
                int err = Interop.EflCBApplication.GetResourceId(GetRaw(), out _resId);
                if (err != 0)
                    Log.Info(LogTag, "elm_config_accel_preference_set is not called");
            }

            return _resId;
        }
    }

}
