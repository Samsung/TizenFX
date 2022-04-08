/*
 * Copyright (c) 2022 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Threading;
using static Tizen.Applications.TizenSynchronizationContext;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents the CoreTask interface.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CoreTask : ICoreTask
    {
        /// <summary>
        /// Initializes the CoreTask class. 
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public CoreTask()
        {
        }

        /// <summary>
        /// This method is to handle behavior when the task of the application is created.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public virtual void OnCreate()
        {
        }

        /// <summary>
        /// This method is to handle behavior when the task of the application is terminated.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public virtual void OnTerminate()
        {
        }

        /// <summary>
        /// This method is to handle behavior when the task of the application receives the appcontrol message.
        /// </summary>
        /// <param name="e"></param>
        /// <since_tizen> 10 </since_tizen>
        public virtual void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
        }

        /// <summary>
        /// This method is to handle behavior when the system memory is low.
        /// </summary>
        /// <param name="e">The low memory event argument</param>
        /// <since_tizen> 10 </since_tizen>
        public virtual void OnLowMemory(LowMemoryEventArgs e)
        {
        }

        /// <summary>
        /// This method is to handle behavior when the system battery is low.
        /// </summary>
        /// <param name="e">The low battery event argument</param>
        /// <since_tizen> 10 </since_tizen>
        public virtual void OnLowBattery(LowBatteryEventArgs e)
        {
        }

        /// <summary>
        /// This method is to handle behavior when the system language is changed.
        /// </summary>
        /// <param name="e">The locale changed event argument</param>
        /// <since_tizen> 10 </since_tizen>
        public virtual void OnLocaleChanged(LocaleChangedEventArgs e)
        {
        }

        /// <summary>
        /// This method is to handle behavior when the region format is changed.
        /// </summary>
        /// <param name="e">The region format changed event argument</param>
        /// <since_tizen> 10 </since_tizen>
        public virtual void OnRegionFormatChanged(RegionFormatChangedEventArgs e)
        {
        }

        /// <summary>
        /// This method is to handle behavior when the device orientation is changed.
        /// </summary>
        /// <param name="e">The device orientation changed event argument</param>
        /// <since_tizen> 10 </since_tizen>
        public virtual void OnDeviceOrientationChanged(DeviceOrientationEventArgs e)
        {
        }

        /// <summary>
        /// This method is to handle behavior when the application is resumed or paused.
        /// </summary>
        /// <param name="e">The UI event argument.</param>
        /// <since_tizen> 10 </since_tizen>
        public virtual void OnUIEvent(UIEventArgs e)
        {
        }

        /// <summary>
        /// Runner callback for dispatching a message to the main loop of the CoreApplication.
        /// </summary>
        /// <typeparam name="T">The typename of the object.</typeparam>
        /// <param name="obj">The object argument.</param>
        /// <since_tizen> 10 </since_tizen>
        public delegate void Runner<T>(T obj);

        /// <summary>
        /// Dispatches an asynchronous message to the main loop of the CoreApplication.
        /// </summary>
        /// <typeparam name="T">The typename of the object.</typeparam>
        /// <param name="runner">The runner callback.</param>
        /// <param name="obj">The object argument.</param>
        /// <since_tizen> 10 </since_tizen>
        public void Post<T>(Runner<T> runner, T obj)
        {
            GSourceManager.Post(() => { runner(obj); });
        }

        private static class GSourceManager
        {
            private static Interop.Glib.GSourceFunc _wrapperHandler;
            private static Object _transactionLock;
            private static ConcurrentDictionary<int, Action> _handlerMap;
            private static int _transactionId;
            private static IntPtr _context;

            static GSourceManager()
            {
                _wrapperHandler = new Interop.Glib.GSourceFunc(Handler);
                _transactionLock = new Object();
                _handlerMap = new ConcurrentDictionary<int, Action>();
                _transactionId = 0;
                _context = Interop.AppCoreUI.GetTizenGlibContext();
            }

            public static void Post(Action action)
            {
                int id = 0;
                lock (_transactionLock)
                {
                    id = _transactionId++;
                }
                _handlerMap.TryAdd(id, action);
                IntPtr source = Interop.Glib.IdleSourceNew();
                Interop.Glib.SourceSetCallback(source, Handler, (IntPtr)id, IntPtr.Zero);
                Interop.Glib.SourceAttach(source, _context);
                Interop.Glib.SourceUnref(source);
            }

            private static bool Handler(IntPtr userData)
            {
                int key = (int)userData;
                if (_handlerMap.TryRemove(key, out Action action))
                {
                    action?.Invoke();
                }
                return false;
            }
        }
    }
}
