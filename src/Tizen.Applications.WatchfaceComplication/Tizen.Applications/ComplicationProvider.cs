﻿/*
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
using System.Collections.Generic;
using System.Text;
using static Interop.WatchfaceComplication;

namespace Tizen.Applications.WatchfaceComplication
{
    /// <summary>
    /// Represents the complication provider for a service application.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public abstract class ComplicationProvider : IDisposable
    {
        private string _providerId;
        private bool _disposed = false;
        private const string LogTag = "WatchfaceComplication";
        private readonly UpdateRequestedCallback _updatedCallback;

        /// <summary>
        /// Initializes a new instance of the ComplicationProvider class.
        /// </summary>
        /// <param name="providerId">The id of the complication provider.</param>
        /// <privilege>http://tizen.org/privilege/datasharing</privilege>
        /// <exception cref="ArgumentException">Thrown when providerId is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have privilege to access this method.</exception>
        /// <example>
        /// <code>
        /// public class MyComplicationProvider : ComplicationProvider
        /// {
        ///     public MyComplicationProvider(string providerId)
        ///      : base(providerId)
        ///     {
        ///     }
        ///     protected override void OnDataUpdateRequested(string reqestAppId, ComplicationTypes type, Bundle contextData)
        ///     {
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        protected ComplicationProvider(string providerId)
        {
            _updatedCallback = new Interop.WatchfaceComplication.UpdateRequestedCallback(DataUpdateRequested);
            ComplicationError err = Interop.WatchfaceComplication.AddUpdateRequestedCallback(providerId, _updatedCallback, IntPtr.Zero);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to create provider");
            _providerId = providerId;
        }

        /// <summary>
        /// Destructor of the provider class.
        /// </summary>
        ~ComplicationProvider()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the provider ID.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Id
        {
            get
            {
                return _providerId;
            }
        }

        private void DataUpdateRequested(string providerId, string reqAppId, ComplicationTypes type,
            IntPtr context, IntPtr sharedData, IntPtr userData)
        {
            Bundle bContext = new Bundle(new SafeBundleHandle(context, false));
            ComplicationData data = OnDataUpdateRequested(reqAppId, type, bContext);
            if (data == null)
            {
                Log.Error(LogTag, "null complication data");
                return;
            }
            ComplicationError err = data.UpdateSharedData(sharedData);
            if (err != ComplicationError.None)
                Log.Error(LogTag, "Set complication data error : " + err);
        }

        /// <summary>
        /// Overrides this method to handle the behavior when the event for requesting the update of complication data comes from watchface complication.
        /// </summary>
        /// <param name="reqestAppId">The ID of application which sent update request.</param>
        /// <param name="type">The requested type.</param>
        /// <param name="contextData">The complication's context which is set by complication setup application.</param>
        /// <returns>The requested ComplicationData</returns>
        /// <since_tizen> 6 </since_tizen>
        protected abstract ComplicationData OnDataUpdateRequested(string reqestAppId, ComplicationTypes type, Bundle contextData);

        /// <summary>
        /// Emits the update event for complications.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/datasharing</privilege>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have privilege to access this method.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void NotifyUpdate()
        {
            ComplicationError err = Interop.WatchfaceComplication.NotifyUpdate(_providerId);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to notify");
        }

        /// <summary>
        /// Gets the received event type.
        /// </summary>
        /// <param name="recvAppCtrl">The received appcontrol.</param>
        /// <exception cref="ArgumentException">Thrown when the invalid parameter is passed.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <example>
        /// <code>
        /// protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        /// {
        ///     EventTypes type = ComplicationProvider.GetEventType(e.ReceivedAppControl);
        ///     if (type == EventTypes.EventDoubleTap)
        ///     {
        ///         // do something
        ///     }
        ///     base.OnAppControlReceived(e);
        /// }
        /// </code>
        /// </example>
        /// <returns>The type of received event</returns>
        /// <since_tizen> 6 </since_tizen>
        public static EventTypes GetEventType(ReceivedAppControl recvAppCtrl)
        {
            EventTypes type;
            ComplicationError err = Interop.WatchfaceComplication.GetEventType(recvAppCtrl.SafeAppControlHandle, out type);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get event");
            return type;
        }

        /// <summary>
        /// Gets the provider ID of appcontrol that raises the event.
        /// </summary>
        /// <param name="recvAppCtrl">The received appcontrol.</param>
        /// <exception cref="ArgumentException">Thrown when e is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <example>
        /// <code>
        /// protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        /// {
        ///     string providerId = ComplicationProvider.GetEventProviderId(e.ReceivedAppControl);
        ///     base.OnAppControlReceived(e);
        /// }
        /// </code>
        /// </example>
        /// <returns>The target provider ID of received event</returns>
        /// <since_tizen> 6 </since_tizen>
        public static string GetEventProviderId(ReceivedAppControl recvAppCtrl)
        {
            string providerId = string.Empty;
            ComplicationError err = Interop.WatchfaceComplication.GetEventProviderId(recvAppCtrl.SafeAppControlHandle, out providerId);
            if (err != ComplicationError.None && err != ComplicationError.NoData)
                ErrorFactory.ThrowException(err, "fail to get event");
            return providerId;
        }

        /// <summary>
        /// Gets the complication type of the received appcontrol.
        /// </summary>
        /// <param name="recvAppCtrl">The received appcontrol.</param>
        /// <exception cref="ArgumentException">Thrown when e is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <example>
        /// <code>
        /// protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        /// {
        ///     ComplicationTypes type = ComplicationProvider.GetEventComplicationType(e.ReceivedAppControl);
        ///     base.OnAppControlReceived(e);
        /// }
        /// </code>
        /// </example>
        /// <returns>The target complication type of received event</returns>
        /// <since_tizen> 6 </since_tizen>
        public static ComplicationTypes GetEventComplicationType(ReceivedAppControl recvAppCtrl)
        {
            ComplicationTypes type;
            ComplicationError err = Interop.WatchfaceComplication.GetEventComplicationType(recvAppCtrl.SafeAppControlHandle, out type);
            if (err != ComplicationError.None && err != ComplicationError.NoData)
                ErrorFactory.ThrowException(err, "fail to get complication type");
            return type;
        }

        /// <summary>
        /// Gets the complication context of appcontrol that raises the event.
        /// </summary>
        /// <param name="recvAppCtrl">The received appcontrol.</param>
        /// <exception cref="ArgumentException">Thrown when e is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <example>
        /// <code>
        /// protected override void OnAppControlReceived(AppControlReceivedEventArgs e)
        /// {
        ///     Bundle context = ComplicationProvider.GetEventContext(e.ReceivedAppControl);
        ///     base.OnAppControlReceived(e);
        /// }
        /// </code>
        /// </example>
        /// <returns>The context of received event</returns>
        /// <since_tizen> 6 </since_tizen>
        public static Bundle GetEventContext(ReceivedAppControl recvAppCtrl)
        {
            SafeBundleHandle bHandle;
            ComplicationError err = Interop.WatchfaceComplication.GetEventContext(recvAppCtrl.SafeAppControlHandle, out bHandle);
            if (err != ComplicationError.None)
            {
                if (err == ComplicationError.NoData)
                    return null;
                ErrorFactory.ThrowException(err, "fail to get complication context");
            }

            return new Bundle(bHandle);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the ComplicationProvider instance specifying whether to perform a normal dispose operation.
        /// </summary>
        /// <param name="disposing">true for a normal dispose operation; false to finalize the handle.</param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                Interop.WatchfaceComplication.RemoveUpdateRequestedCallback(_providerId, _updatedCallback);
                _disposed = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the ComplicationProvider class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}