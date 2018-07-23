/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using Tizen.Applications;

namespace OpenTK.Platform.Tizen
{
    /// <summary>
    /// Represents an application that have a GameWindow of OpenTK.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class TizenGameApplication : CoreUIApplication
    {
        private TizenGameWindow window;

        /// <summary>
        /// Gets the GameWindow instance that created in OnCreate() method.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public IGameWindow Window => window;

        /// <summary>
        /// Initializes the TizenGameApplication class.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public TizenGameApplication() : base(new TizenGameCoreBackend())
        {
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the application is resumed.
        /// If base.OnResume() is not called, the event 'Resumed' will not be emitted.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void OnResume()
        {
            window.Paused = false;
            base.OnResume();
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the application is paused.
        /// If base.OnPause() is not called, the event 'Paused' will not be emitted.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void OnPause()
        {
            window.Paused = true;
            base.OnPause();
        }

        /// <summary>
        /// Runs the UI application's main loop. The GameWindow uses the maximum update rate.
        /// </summary>
        /// <param name="args">Arguments from the commandline.</param>
        /// <since_tizen> 3 </since_tizen>
        public override void Run(string[] args)
        {
            Run(args, 0.0, 0.0);
        }


        /// <summary>
        /// Runs the UI application's main loop. The GameWindow uses the specified update rate.
        /// </summary>
        /// <param name="args">Arguments from the commandline.</param>
        /// <param name="updatesPerSecond">The frequency of UpdateFrame events.</param>
        /// <since_tizen> 5 </since_tizen>
        public void Run(string[] args, double updatesPerSecond)
        {
            Run(args, updatesPerSecond, 0.0);
        }

        /// <summary>
        /// Runs the UI application's main loop. The GameWindow updates and renders at the specified frequency.
        /// </summary>
        /// <param name="args">Arguments from the commandline.</param>
        /// <param name="updatesPerSecond">The frequency of UpdateFrame events.</param>
        /// <param name="framesPerSecond">The frequency of RenderFrame events.</param>
        /// <since_tizen> 5 </since_tizen>
        public void Run(string[] args, double updatesPerSecond, double framesPerSecond)
        {
            // Initialize SDL2
            SDL2.SDL.TizenAppInit(args.Length, args);
            SDL2.SDL.SetMainReady();
            Toolkit.Init();

            // Set Create Window
            Backend.AddEventHandler(TizenGameCoreBackend.WindowCreationEventType, () => {
                window = new TizenGameWindow();
            });

            // Configure callbacks for application events
            base.Run(args);

            // Run mainloop
            window.RunInternal(updatesPerSecond, framesPerSecond);
        }

        /// <summary>
        /// Exits the main loop of the application.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public override void Exit()
        {
            window.Exit();
        }
    }
}
