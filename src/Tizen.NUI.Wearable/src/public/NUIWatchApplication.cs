/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using Tizen.Applications;
using Tizen.Applications.CoreBackend;

namespace Tizen.NUI
{

    /// <summary>
    /// Represents an application that can make watch-face.
    /// </summary>
    public class NUIWatchApplication : CoreApplication
    {
        /// <summary>
        /// Occurs whenever the application is resumed.
        /// </summary>
        public event EventHandler Resumed;

        /// <summary>
        /// Occurs whenever the application is paused.
        /// </summary>
        public event EventHandler Paused;

        /// <summary>
        /// Occurs at every second.
        /// </summary>
        public event EventHandler TimeTick;

        /// <summary>
        /// Event arguments that passed via time tick event signal.
        /// </summary>
        public class TimeTickEventArgs : EventArgs
        {
            private WatchTime _watchTime;
            /// <summary>
            /// Default Constructor.
            /// </summary>
            public TimeTickEventArgs( WatchTime watchTime )
            {
                _watchTime = watchTime;
            }

            /// <summary>
            /// WatchTime.
            /// </summary>
            public WatchTime WatchTime
            {
                get
                {
                    return _watchTime;
                }
            }
        }

        /// <summary>
        /// Occurs at each minute in ambient mode.
        /// http://tizen.org/privilege/alarm.set privilege is needed to receive ambient ticks at each minute.
        /// </summary>
        public event EventHandler AmbientTick;

        /// <summary>
        /// Event arguments that passed via ambient tick event signal.
        /// </summary>
        public class AmbientTickEventArgs : EventArgs
        {
            private WatchTime _watchTime;
            /// <summary>
            /// Default Constructor.
            /// </summary>
            public AmbientTickEventArgs(WatchTime watchTime)
            {
                _watchTime = watchTime;
            }

            /// <summary>
            /// WatchTime.
            /// </summary>
            public WatchTime WatchTime
            {
                get
                {
                    return _watchTime;
                }
            }
        }

        /// <summary>
        /// Occurs when the device enters or exits ambient mode
        /// </summary>
        public event EventHandler AmbientChanged;

        /// <summary>
        /// Event arguments that passed via ambient tick event signal.
        /// </summary>
        public class AmbientChangedEventArgs : EventArgs
        {
            private bool _changed;
            /// <summary>
            /// Default Constructor.
            /// </summary>
            public AmbientChangedEventArgs(bool changed)
            {
                _changed = changed;
            }

            /// <summary>
            /// Changed.
            /// </summary>
            public bool Changed
            {
                get
                {
                    return _changed;
                }
            }
        }

        /// <summary>
        /// The default constructor.
        /// </summary>
        public NUIWatchApplication() : base(new NUIWatchCoreBackend())
        {
        }

        /// <summary>
        /// The constructor with stylesheet.
        /// </summary>
        public NUIWatchApplication(string stylesheet) : base(new NUIWatchCoreBackend(stylesheet))
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnLocaleChanged(LocaleChangedEventArgs e)
        {
            Log.Debug("NUI", "OnLocaleChanged() is called!");
            base.OnLocaleChanged(e);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnLowBattery(LowBatteryEventArgs e)
        {
            Log.Debug("NUI", "OnLowBattery() is called!");
            base.OnLowBattery(e);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnLowMemory(LowMemoryEventArgs e)
        {
            Log.Debug("NUI", "OnLowMemory() is called!");
            base.OnLowMemory(e);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnRegionFormatChanged(RegionFormatChangedEventArgs e)
        {
            Log.Debug("NUI", "OnRegionFormatChanged() is called!");
            base.OnRegionFormatChanged(e);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnCreate()
        {
            // This is also required to create DisposeQueue on main thread.
            DisposeQueue disposeQ = DisposeQueue.Instance;
            disposeQ.Initialize();
            Log.Debug("NUI","OnCreate() is called!");
            base.OnCreate();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected virtual void OnPreCreate()
        {
            Log.Debug("NUI", "OnPreCreate() is called!");
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnTerminate()
        {
            Log.Debug("NUI", "OnTerminate() is called!");
            base.OnTerminate();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
            Log.Debug("NUI", "OnAppControlReceived() is called!");
            if (e != null)
            {
                Log.Debug("NUI", "OnAppControlReceived() is called! ApplicationId=" + e.ReceivedAppControl.ApplicationId);
                Log.Debug("NUI", "CallerApplicationId=" + e.ReceivedAppControl.CallerApplicationId + "   IsReplyRequest=" + e.ReceivedAppControl.IsReplyRequest);
            }
            base.OnAppControlReceived(e);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected virtual void OnPause()
        {
            Log.Debug("NUI", "OnPause() is called!");
            Paused?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected virtual void OnResume()
        {
            Log.Debug("NUI", "OnResume() is called!");
            Resumed?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected virtual void OnTimeTick(TimeTickEventArgs e)
        {
            Log.Debug("NUI", "OnTimeTick() is called!");
            TimeTick?.Invoke(this, e);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/alarm.set</privilege>
        protected virtual void OnAmbientTick(AmbientTickEventArgs e)
        {
            Log.Debug("NUI", "OnAmbientTick() is called!");
            AmbientTick?.Invoke(this, e);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior.
        /// </summary>
        protected virtual void OnAmbientChanged(AmbientChangedEventArgs e)
        {
            Log.Debug("NUI", "OnAmbientChanged() is called!");
            AmbientChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Run NUIWidgetApplication.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        public override void Run(string[] args)
        {
            Backend.AddEventHandler(EventType.PreCreated, OnPreCreate);
            Backend.AddEventHandler(EventType.Resumed, OnResume);
            Backend.AddEventHandler(EventType.Paused, OnPause);

            Backend.AddEventHandler<TimeTickEventArgs>(NUIEventType.TimeTick, OnTimeTick);
            Backend.AddEventHandler<AmbientTickEventArgs>(NUIEventType.AmbientTick, OnAmbientTick);
            Backend.AddEventHandler<AmbientChangedEventArgs>(NUIEventType.AmbientChanged, OnAmbientChanged);

            base.Run(args);
        }

        /// <summary>
        /// Exit NUIWidgetApplication.
        /// </summary>
        public override void Exit()
        {
            Backend.Exit();
        }

        internal WatchApplication ApplicationHandle
        {
            get
            {
                return ((NUIWatchCoreBackend)this.Backend).WatchApplicationHandle;
            }
        }

        /// <summary>
        /// Get the window instance.
        /// </summary>
        public Window Window
        {
            get
            {
                //return Window.Instance;
                return ApplicationHandle.GetWindow();
            }
        }

    }
}
