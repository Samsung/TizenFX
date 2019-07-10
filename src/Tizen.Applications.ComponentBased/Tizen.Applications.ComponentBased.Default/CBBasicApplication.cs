using System;
using System.Collections.Generic;
using System.Text;
using Tizen.Applications.ComponentBased.Common;

namespace Tizen.Applications.ComponentBased.Default
{
    /// <summary>
    /// Basic type application which will support ElmWindow for FrameComponent
    /// </summary>
    public class CBBasicApplication : CBApplicationBase
    {
        protected override void OnInit(string[] args)
        {
        }

        protected override void OnFini()
        {
        }

        protected override void OnRun()
        {
        }

        protected override void OnExit()
        {
        }
    }

    /// <summary>
    /// Window class for basic application type
    /// </summary>
    public class ElmWindow : IWindow
    {
        public int GetResId()
        {
            return 0;
        }
    }

}
