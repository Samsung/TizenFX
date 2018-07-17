//
// TizenGameApplication.cs
//
// Author:
//       WonyoungChoi <wy80.choi@samsung.com>
//
// Copyright (c) 2018
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

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
        /// Overrides this method if want to handle behavior when the application is launched.
        /// If base.OnCreated() is not called, the event 'Created' will not be emitted.
        /// </summary>
        /// <remarks>
        /// The GameWindow instance is created in this method.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        protected override void OnCreate()
        {
            window = new TizenGameWindow();
            base.OnCreate();
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
