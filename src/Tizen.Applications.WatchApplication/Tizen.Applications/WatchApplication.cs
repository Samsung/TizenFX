/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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
using ElmSharp;

namespace Tizen.Applications
{
    /// <summary>
    /// The class that represents a Tizen watch application.
    /// </summary>
    public class WatchApplication : CoreApplication
    {
        /// <summary>
        /// Initialize the WatchApplication class
        /// </summary>
        /// <remarks>
        /// Default backend for Watch application will be used.
        /// </remarks>
        public WatchApplication() : base(new WatchCoreBackend())
        {
        }

        /// <summary>
        /// Initialize the WatchApplication class
        /// </summary>
        /// <remarks>
        /// If want to change the backend , use this constructor
        /// </remarks>
        /// <param name="backend">The backend instance implementing ICoreBackend interface.</param>
        public WatchApplication(ICoreBackend backend) : base(backend)
        {
        }

        /// <summary>
        /// Instance for the window
        /// </summary>
        protected Widget Window;

        /// <summary>
        /// Occurs whenever the application is resumed.
        /// </summary>
        public event EventHandler Resumed;

        /// <summary>
        /// Occurs whenever the application is paused.
        /// </summary>
        public event EventHandler Paused;

        /// <summary>
        /// Occurs whenever the time tick comes.
        /// </summary>
        public event EventHandler<TimeEventArgs> TimeTick;

        /// <summary>
        /// Occurs whenever the time tick comes in ambient mode.
        /// </summary>
        public event EventHandler<TimeEventArgs> AmbientTick;

        /// <summary>
        /// Occurs when the ambient mode is changed.
        /// </summary>
        public event EventHandler<AmbientEventArgs> AmbientChanged;

        /// <summary>
        /// Runs the UI applications' main loop.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        public override void Run(string[] args)
        {
            Backend.AddEventHandler(EventType.Resumed, OnResume);
            Backend.AddEventHandler(EventType.Paused, OnPause);

            Backend.AddEventHandler<TimeEventArgs>(WatchEventType.TimeTick, OnTick);
            Backend.AddEventHandler<TimeEventArgs>(WatchEventType.AmbientTick, OnAmbientTick);
            Backend.AddEventHandler<AmbientEventArgs>(WatchEventType.AmbientChanged, OnAmbientChanged);

            base.Run(args);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the application is launched.
        /// If base.OnCreate() is not called, the event 'Created' will not be emitted.
        /// </summary>
        protected override void OnCreate()
        {
            base.OnCreate();
            IntPtr win;

            Interop.Watch.GetWin(out win);
            Window = new WatchWindow(win);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the application is resumed.
        /// If base.OnResume() is not called, the event 'Resumed' will not be emitted.
        /// </summary>
        protected virtual void OnResume()
        {
            Resumed?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the application is paused.
        /// If base.OnPause() is not called, the event 'Paused' will not be emitted.
        /// </summary>
        protected virtual void OnPause()
        {
            Paused?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the time tick event comes.
        /// If base.OnTick() is not called, the event 'TimeTick' will not be emitted.
        /// </summary>
        /// <param name="time">The received TimeEventArgs to get time information.</param>
        protected virtual void OnTick(TimeEventArgs time)
        {
            TimeTick?.Invoke(this, time);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the time tick event comes in ambient mode.
        /// If base.OnAmbientTick() is not called, the event 'AmbientTick' will not be emitted.
        /// </summary>
        /// <param name="time">The received TimeEventArgs to get time information.</param>
        /// <privilege>http://tizen.org/privilege/alarm.set</privilege>
        protected virtual void OnAmbientTick(TimeEventArgs time)
        {
            AmbientTick?.Invoke(this, time);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the ambient mode is changed.
        /// If base.OnAmbientChanged() is not called, the event 'AmbientChanged' will not be emitted.
        /// </summary>
        /// <param name="mode">The received AmbientEventArgs</param>
        protected virtual void OnAmbientChanged(AmbientEventArgs mode)
        {
            AmbientChanged?.Invoke(this, mode);
        }

        /// <summary>
        /// Gets the current time
        /// </summary>
        /// <returns>WatchTime</returns>
        /// <exception cref="InvalidOperationException">Thrown when failed to get current time because of invalid parameter.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed to get current time because memory is not enough.</exception>
        /// <example>
        /// <code>
        /// class MyApp : WatchApplication
        /// {
        ///     ...
        ///     public void TestMethod()
        ///     {
        ///         WatchTime wt;
        ///         try
        ///         {
        ///             wt = GetCurrentTime();
        ///         }
        ///         catch
        ///         {
        ///         }
        ///     }
        /// }
        /// </code>
        /// </example>
        protected WatchTime GetCurrentTime()
        {
            SafeWatchTimeHandle handle;

            Interop.Watch.ErrorCode err = Interop.Watch.WatchTimeGetCurrentTime(out handle);
            if (err != Interop.Watch.ErrorCode.None)
            {
                if (err == Interop.Watch.ErrorCode.InvalidParameter)
                    throw new InvalidOperationException("Failed to get current time. err : " + err);
                else if (err == Interop.Watch.ErrorCode.OutOfMemory)
                    throw new OutOfMemoryException("Failed to get current time. err : " + err);
            }
            return new WatchTime(handle);
        }

        /// <summary>
        /// Gets the type of periodic ambient tick.
        /// </summary>
        /// <returns>AmbientTickType</returns>
        /// <exception cref="InvalidOperationException">Thrown when failed to get ambient tick type.</exception>
        /// <example>
        /// <code>
        /// class MyApp : WatchApplication
        /// {
        ///     ...
        ///     public void TestMethod()
        ///     {
        ///         AmbientTickType atType;
        ///         try
        ///         {
        ///             atType = GetAmbientTickType();
        ///         }
        ///         catch
        ///         {
        ///         }
        ///     }
        /// }
        /// </code>
        /// </example>
        protected AmbientTickType GetAmbientTickType()
        {
            AmbientTickType ambientTickType;

            Interop.Watch.ErrorCode err = Interop.Watch.GetAmbientTickType(out ambientTickType);

            if(err != Interop.Watch.ErrorCode.None)
            {
                throw new InvalidOperationException("Failed to get ambient tick type. err : " + err);
            }

            return ambientTickType;
        }

        /// <summary>
        /// Sets the type of periodic ambient tick.
        /// OnAmbientTick will be called following settings.
        /// If SetAmbientTickType is not called, OnAmbientTick will be called every minute.
        /// </summary>
        /// <param name="ambientTickType">the type of ambient tick</param>
        /// <exception cref="InvalidOperationException">Thrown when failed to set ambient tick type.</exception>
        /// <example>
        /// <code>
        /// class MyApp : WatchApplication
        /// {
        ///     ...
        ///     public void TestMethod()
        ///     {
        ///         try
        ///         {
        ///             SetAmbientTickType(AmbientTickType.EveryMinute);
        ///         }
        ///         catch
        ///         {
        ///         }
        ///     }
        /// }
        /// </code>
        /// </example>
        protected void SetAmbientTickType(AmbientTickType ambientTickType)
        {
            Interop.Watch.ErrorCode err = Interop.Watch.SetAmbientTickType(ambientTickType);

            if(err != Interop.Watch.ErrorCode.None)
            {
                throw new InvalidOperationException("Failed to set ambient tick type. err : " + err);
            }
        }

        /// <summary>
        /// Sets the frequency of time tick.
        /// OnTick will be called following settings.
        /// If SetTimeTickFrequency is not called, OnTick will be called every second.
        /// </summary>
        /// <param name="ticks">Ticks the number of ticks per given resolution type</param>
        /// <param name="type">Type of the resolution type</param>
        /// <exception cref="InvalidOperationException">Thrown when failed to set time tick frequency.</exception>
        /// <example>
        /// <code>
        /// class MyApp : WatchApplication
        /// {
        ///     ...
        ///     public void TestMethod()
        ///     {
        ///         try
        ///         {
        ///             SetTimeTickFrequency(1, TimeTickResolution.TimeTicksPerMinute);
        ///         }
        ///         catch
        ///         {
        ///         }
        ///     }
        /// }
        /// </code>
        /// </example>
        protected void SetTimeTickFrequency(int ticks, TimeTickResolution type)
        {
            Interop.Watch.ErrorCode err = Interop.Watch.SetTimeTickFrequency(ticks, type);

            if (err != Interop.Watch.ErrorCode.None)
            {
                throw new InvalidOperationException("Failed to set time tick frequency. err : " + err);
            }
        }

        /// <summary>
        /// Gets the frequency fo time tick.
        /// </summary>
        /// <param name="ticks">Ticks the number of ticks per given resolution type</param>
        /// <param name="type">Type of the resolution type</param>
        /// <exception cref="InvalidOperationException">Thrown when failed to get time tick frequency.</exception>
        /// <example>
        /// <code>
        /// class MyApp : WatchApplication
        /// {
        ///     ...
        ///     public void TestMethod()
        ///     {
        ///         int tick;
        ///         TimeTickResolution tType;
        ///         try
        ///         {
        ///             GetTimeTickFrequency(out tick, out tType);
        ///         }
        ///         catch
        ///         {
        ///         }
        ///     }
        /// }
        /// </code>
        /// </example>
        protected void GetTimeTickFrequency(out int ticks, out TimeTickResolution type)
        {
            Interop.Watch.ErrorCode err = Interop.Watch.GetTimeTickFrequency(out ticks, out type);

            if (err != Interop.Watch.ErrorCode.None)
            {
                throw new InvalidOperationException("Failed to get time tick frequency. err : " + err);
            }
        }
    }
}
