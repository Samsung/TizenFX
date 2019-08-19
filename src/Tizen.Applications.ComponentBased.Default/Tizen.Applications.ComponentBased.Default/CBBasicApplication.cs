using ElmSharp;
using System;
using System.Collections.Generic;
using Tizen.Applications.ComponentBased.Common;

namespace Tizen.Applications.ComponentBased.Default
{
    /// <summary>
    /// Basic type application which will support ElmWindow for FrameComponent
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class CBBasicApplication : CBApplicationBase
    {
        private const string LogTag = "Tizen.Applications.CBBasicApplication";

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
        /// <since_tizen> 6 </since_tizen>
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
        /// <since_tizen> 6 </since_tizen>
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
        /// <since_tizen> 6 </since_tizen>
        protected override void OnRun()
        {
            Interop.Elementary.ElmRun();
        }

        /// <summary>
        /// This method will be called to exit main-loop
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected override void OnExit()
        {
            Interop.Elementary.ElmExit();
        }
    }
}
