/*
 * Copyright (c) 2026 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen.Applications.CoreBackend;
using Tizen.NUI;

namespace Tizen.Applications
{
    public class TeamCoreUiApplication : TeamCoreApplication
    {
        public TeamCoreUiApplication() : base(new TeamUICoreBackend())
        {
        }

        public Window GetDefaultWindow()
        {
            return ((TeamUICoreBackend)Backend).GetDefaultWindow();
        }

        public event EventHandler Resumed;
        public event EventHandler Paused;
        public override void Run(string[] args)
        {
            Backend.AddEventHandler(EventType.Resumed, OnResume);
            Backend.AddEventHandler(EventType.Paused, OnPause);

            base.Run(args);
        }

        protected override void OnCreate()
        {
          base.OnCreate();
        }
        protected virtual void OnResume()
        {
            Resumed?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnPause()
        {
            Paused?.Invoke(this, EventArgs.Empty);
        }
    }
}