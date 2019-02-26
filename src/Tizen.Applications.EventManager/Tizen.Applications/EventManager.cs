/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications.EventManager
{
    /// <summary>
    /// The EventManager Class provides functions to broadcast user-defined event.
    /// </summary>
    /// <example>
    /// <code>
    /// public class EventManagerSample
    /// {
    ///     /// ...
    ///     Bundle bundle = new Bundle();
    ///     bundle.AddItem("key", "value");
    ///     EventManager.PublishAppEvent("event.org.example.helloworld.event, bundle);
    /// }
    /// </code>
    /// </example>
    /// <since_tizen> 6 </since_tizen>
    public static class EventManager
    {
        /// <summary>
        /// Sends the User-Event to receiver applications.
        /// </summary>
        /// <param name="eventName">The event's name to send.</param>
        /// <param name="eventData"> The event's data to send.</param>
        /// <remarks>The format of User-Event's name MUST be "event.{sender's appid}.{user-defined name}", refer to 'The name-format of User-Event' section,
        /// If the event_name is invalid, throw InvalidOperationException</remarks>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <since_tizen> 6 </since_tizen>
        public static void PublishAppEvent(string eventName, Bundle eventData)
        {
            Interop.AppEvent.ErrorCode err = Interop.AppEvent.EventPublishAppEvent(eventName, eventData.SafeBundleHandle);
            if (err != Interop.AppEvent.ErrorCode.None)
            {
                ErrorFactory.ThrowException(err, "Publish event");
            }
        }

        /// <summary>
        /// Sends the User-Event to trusted receiver-applications.
        /// </summary>
        /// <param name="eventName">The event's name to send.</param>
        /// <param name="eventData"> The event's data to send.</param>
        /// <remarks>The application which has same certification with sender can receive the event.
        /// The format of User-Event's name MUST be "event.{sender's appid}.{user-defined name}", refer to 'The name-format of User-Event' section,
        /// If the event_name is invalid, throw InvalidOperationException</remarks>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <since_tizen> 6 </since_tizen>
        public static void PublishTrustedAppEvent(string eventName, Bundle eventData)
        {
            Interop.AppEvent.ErrorCode err = Interop.AppEvent.EventPublishTrustedAppEvent(eventName, eventData.SafeBundleHandle);
            if (err != Interop.AppEvent.ErrorCode.None)
            {
                ErrorFactory.ThrowException(err, "Publish trusted event");
            }
        }

        /// <summary>
        /// Keeps last User-Event data for receiver applications.
        /// </summary>
        /// <param name="eventName">The event's name to send.</param>
        /// <remarks>The receiver applications will receive this last event data after adding their new handlers via ApplicationEventReceiver since the sender application called this method.
        /// If a sender application sends same event via trusted method and non-trusted method, then a trusted receiver will get latest data regardless of trusted or non-trusted,
        /// but non-trusted receiver will get the last data only from non-trusted method. The effect of this API continues during runtime.
        /// That means when the sender application process restarts, the sender application needs to call this api again to make the event to keep the last event.</remarks>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <since_tizen> 6 </since_tizen>
        public static bool KeepLastEventData(string eventName)
        {
            Interop.AppEvent.ErrorCode err = Interop.AppEvent.EventKeepLastEventData(eventName);
            if (err != Interop.AppEvent.ErrorCode.None)
            {
                ErrorFactory.ThrowException(err, "Keep last event");
                return false;
            }

            return true;
        }
    }
}
