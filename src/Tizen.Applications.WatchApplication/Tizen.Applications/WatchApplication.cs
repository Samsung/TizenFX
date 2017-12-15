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
    /// The class that represents the Tizen watch application.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class WatchApplication : CoreApplication
    {
        /// <summary>
        /// Initializes the WatchApplication class.
        /// </summary>
        /// <remarks>
        /// Default backend for the watch application will be used.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        public WatchApplication() : base(new WatchCoreBackend())
        {
        }

        /// <summary>
        /// Initializes the WatchApplication class.
        /// </summary>
        /// <remarks>
        /// If you want to change the backend, use this constructor.
        /// </remarks>
        /// <param name="backend">The backend instance implementing the ICoreBackend interface.</param>
        /// <since_tizen> 4 </since_tizen>
        public WatchApplication(ICoreBackend backend) : base(backend)
        {
        }

        /// <summary>
        /// Instances for the window.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected Window Window;

        /// <summary>
        /// Occurs whenever the application is resumed.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler Resumed;

        /// <summary>
        /// Occurs whenever the application is paused.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler Paused;

        /// <summary>
        /// Occurs whenever the time tick comes.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<TimeEventArgs> TimeTick;

        /// <summary>
        /// Occurs whenever the time tick comes in the ambient mode.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<TimeEventArgs> AmbientTick;

        /// <summary>
        /// Occurs when the ambient mode is changed.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<AmbientEventArgs> AmbientChanged;

        /// <summary>
        /// Runs the UI applications' main loop.
        /// </summary>
        /// <param name="args">Arguments from the commandline.</param>
        /// <since_tizen> 4 </since_tizen>
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
        /// Overrides this method to handle the behavior when the application is launched.
        /// If base.OnCreate() is not called, the event 'Created' will not be emitted.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected override void OnCreate()
        {
            base.OnCreate();
            IntPtr win;

            Interop.Watch.GetWin(out win);
            Window = new WatchWindow(win);
            Window.Show();
        }

        /// <summary>
        /// Overrides this method to handle the behavior when the application is resumed.
        /// If base.OnResume() is not called, the event 'Resumed' will not be emitted.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void OnResume()
        {
            Resumed?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Overrides this method to handle the behavior when the application is paused.
        /// If base.OnPause() is not called, the event 'Paused' will not be emitted.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void OnPause()
        {
            Paused?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Overrides this method to handle the behavior when the time tick event comes.
        /// If base.OnTick() is not called, the event 'TimeTick' will not be emitted.
        /// </summary>
        /// <param name="time">The received TimeEventArgs to get the time information.</param>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void OnTick(TimeEventArgs time)
        {
            TimeTick?.Invoke(this, time);
        }

        /// <summary>
        /// Overrides this method to handle the behavior when the time tick event comes in ambient mode.
        /// If base.OnAmbientTick() is not called, the event 'AmbientTick' will not be emitted.
        /// </summary>
        /// <param name="time">The received TimeEventArgs to get time information.</param>
        /// <privilege>http://tizen.org/privilege/alarm.set</privilege>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void OnAmbientTick(TimeEventArgs time)
        {
            AmbientTick?.Invoke(this, time);
        }

        /// <summary>
        /// Overrides this method to handle the behavior when the ambient mode is changed.
        /// If base.OnAmbientChanged() is not called, the event 'AmbientChanged' will not be emitted.
        /// </summary>
        /// <param name="mode">The received AmbientEventArgs.</param>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void OnAmbientChanged(AmbientEventArgs mode)
        {
            AmbientChanged?.Invoke(this, mode);
        }

        /// <summary>
        /// Gets the current time.
        /// </summary>
        /// <returns>WatchTime</returns>
        /// <feature>http://tizen.org/feature/watch_app</feature>
        /// <exception cref="InvalidOperationException">Thrown when failed to get the current time because of an invalid parameter.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed to get the current time because the memory is not enough.</exception>
        /// <exception cref="NotSupportedException">Thrown when the method is not supported.</exception>
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
        /// <since_tizen> 4 </since_tizen>
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
                else if (err == Interop.Watch.ErrorCode.NotSupported)
                    throw new NotSupportedException("Failed to get current time. err : " + err);
            }
            return new WatchTime(handle);
        }

        /// <summary>
        /// Gets the type of the periodic ambient tick.
        /// </summary>
        /// <returns>AmbientTickType</returns>
        /// <feature>http://tizen.org/feature/watch_app</feature>
        /// <exception cref="InvalidOperationException">Thrown when failed to get the ambient tick type.</exception>
        /// <exception cref="NotSupportedException">Thrown when the method is not supported.</exception>
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
        /// <since_tizen> 4 </since_tizen>
        protected AmbientTickType GetAmbientTickType()
        {
            AmbientTickType ambientTickType;

            Interop.Watch.ErrorCode err = Interop.Watch.GetAmbientTickType(out ambientTickType);

            if(err != Interop.Watch.ErrorCode.None)
            {
                if (err == Interop.Watch.ErrorCode.NotSupported)
                    throw new NotSupportedException("Failed to get ambient tick type. err : " + err);
                else
                    throw new InvalidOperationException("Failed to get ambient tick type. err : " + err);
            }

            return ambientTickType;
        }

        /// <summary>
        /// Sets the type of the periodic ambient tick.
        /// OnAmbientTick will be called for the following settings.
        /// If the SetAmbientTickType is not called, the OnAmbientTick will be called every minute.
        /// </summary>
        /// <param name="ambientTickType">The type of the ambient tick.</param>
        /// <feature>http://tizen.org/feature/watch_app</feature>
        /// <exception cref="InvalidOperationException">Thrown when failed to set the ambient tick type.</exception>
        /// <exception cref="NotSupportedException">Thrown when the method is not supported.</exception>
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
        /// <since_tizen> 4 </since_tizen>
        protected void SetAmbientTickType(AmbientTickType ambientTickType)
        {
            Interop.Watch.ErrorCode err = Interop.Watch.SetAmbientTickType(ambientTickType);

            if(err != Interop.Watch.ErrorCode.None)
            {
                if (err == Interop.Watch.ErrorCode.NotSupported)
                    throw new NotSupportedException("Failed to set ambient tick type. err : " + err);
                else
                    throw new InvalidOperationException("Failed to set ambient tick type. err : " + err);
            }
        }

        /// <summary>
        /// Sets the frequency of the time tick.
        /// OnTick will be called for the following settings.
        /// If SetTimeTickFrequency is not called, OnTick will be called every second.
        /// </summary>
        /// <param name="ticks">Ticks the number of ticks per given resolution type.</param>
        /// <param name="type">Type of the resolution type.</param>
        /// <feature>http://tizen.org/feature/watch_app</feature>
        /// <exception cref="InvalidOperationException">Thrown when failed to set the time tick frequency.</exception>
        /// <exception cref="NotSupportedException">Thrown when the method is not supported.</exception>
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
        /// <since_tizen> 4 </since_tizen>
        protected void SetTimeTickFrequency(int ticks, TimeTickResolution type)
        {
            Interop.Watch.ErrorCode err = Interop.Watch.SetTimeTickFrequency(ticks, type);

            if (err != Interop.Watch.ErrorCode.None)
            {
                if (err == Interop.Watch.ErrorCode.NotSupported)
                    throw new NotSupportedException("Failed to set time tick frequency. err : " + err);
                else
                    throw new InvalidOperationException("Failed to set time tick frequency. err : " + err);
            }
        }

        /// <summary>
        /// Gets the frequency of the time tick.
        /// </summary>
        /// <param name="ticks">Ticks the number of ticks per given resolution type.</param>
        /// <param name="type">Type of the resolution type.</param>
        /// <feature>http://tizen.org/feature/watch_app</feature>
        /// <exception cref="InvalidOperationException">Thrown when failed to get the time tick frequency.</exception>
        /// <exception cref="NotSupportedException">Thrown when the method is not supported.</exception>
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
        /// <since_tizen> 4 </since_tizen>
        protected void GetTimeTickFrequency(out int ticks, out TimeTickResolution type)
        {
            Interop.Watch.ErrorCode err = Interop.Watch.GetTimeTickFrequency(out ticks, out type);

            if (err != Interop.Watch.ErrorCode.None)
            {
                if (err == Interop.Watch.ErrorCode.NotSupported)
                    throw new NotSupportedException("Failed to get time tick frequency. err : " + err);
                else
                    throw new InvalidOperationException("Failed to get time tick frequency. err : " + err);
            }
        }
    }
}
