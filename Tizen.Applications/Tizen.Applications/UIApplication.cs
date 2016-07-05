// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using Tizen.UI;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents an application that have UI screen. The UIApplication class has a default main window.
    /// </summary>
    public class UIApplication : CoreUIApplication
    {
        /// <summary>
        /// The main window instance of the UIApplication.
        /// </summary>
        /// <remarks>
        /// This window is created before OnCreate() or created event. And the UIApplication will be terminated when this window is closed.
        /// </remarks>
        public Window Window { get; private set; }

        /// <summary>
        /// Overrides this method if want to handle behavior before calling OnCreate().
        /// Window property is initialized in this overrided method.
        /// </summary>
        protected override void OnPreCreate()
        {
            Window = new Window("C# UI Application");
            Window.Closed += (s, e) =>
            {
                Exit();
            };
        }
    }
}
