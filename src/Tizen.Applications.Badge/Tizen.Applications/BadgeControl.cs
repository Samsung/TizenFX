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

namespace Tizen.Applications
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// Class for badge operation.
    /// </summary>
    public static class BadgeControl
    {
        private static event EventHandler<BadgeEventArgs> s_changed;
        private static bool s_registered = false;
        private static Interop.Badge.ChangedCallback s_callback;

        /// <summary>
        /// Event handler for receiving badge events.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access</exception>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        public static event EventHandler<BadgeEventArgs> Changed
        {
            add
            {
                if (s_changed == null && !s_registered)
                {
                    if (s_callback == null)
                    {
                        s_callback = new Interop.Badge.ChangedCallback(OnChangedEvent);
                    }

                    BadgeError err = Interop.Badge.SetChangedCallback(s_callback, IntPtr.Zero);
                    if (err != BadgeError.None)
                    {
                        throw BadgeErrorFactory.GetException(err, "Failed to add event handler");
                    }

                    s_registered = true;
                }

                s_changed += value;
            }
            remove
            {
                s_changed -= value;
                if (s_changed == null && s_registered)
                {
                    BadgeError err = Interop.Badge.UnsetChangedCallback(s_callback);
                    if (err != BadgeError.None)
                    {
                        throw BadgeErrorFactory.GetException(err, "Failed to remove event handler");
                    }

                    s_callback = null;
                    s_registered = false;
                }
            }
        }

        /// <summary>
        /// Gets the badge information from application ID.
        /// </summary>
        /// <param name="appId">Application ID</param>
        /// <exception cref="ArgumentException">Thrown when failed because of invalid argument</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions</exception>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        public static Badge Find(string appId)
        {
            uint count;
            uint display;

            BadgeError err = Interop.Badge.GetCount(appId, out count);
            if (err != BadgeError.None)
            {
                throw BadgeErrorFactory.GetException(err, "Failed to find badge count of " + appId);
            }

            err = Interop.Badge.GetDisplay(appId, out display);
            if (err != BadgeError.None)
            {
                throw BadgeErrorFactory.GetException(err, "Failed to find badge display of " + appId);
            }

            return new Badge(appId, (int)count, display == 0 ? false : true);
        }

        /// <summary>
        /// Removes the badge information.
        /// </summary>
        /// <param name="appId">Application ID</param>
        /// <exception cref="ArgumentException">Thrown when failed because of invalid argument</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions</exception>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        public static void Remove(string appId)
        {
            BadgeError err = Interop.Badge.Remove(appId);
            if (err != BadgeError.None)
            {
                throw BadgeErrorFactory.GetException(err, "Failed to Remove badge of " + appId);
            }
        }

        /// <summary>
        /// Adds the badge information.
        /// </summary>
        /// <param name="appId">Application ID</param>
        /// <param name="count">Count value</param>
        /// <param name="isDisplay">True if it should be displayed</param>
        /// <exception cref="ArgumentException">Thrown when failed because of invalid argument</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions</exception>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        public static void Add(string appId, int count = 1, bool isDisplay = true)
        {
            BadgeError err = Interop.Badge.Add(appId);
            if (err != BadgeError.None)
            {
                throw BadgeErrorFactory.GetException(err, "Failed to add badge of " + appId);
            }

            try
            {
                Update(appId, count, isDisplay);
            }
            catch (Exception e)
            {
                Remove(appId);
                throw e;
            }
        }

        /// <summary>
        /// Updates the badge information.
        /// </summary>
        /// <param name="appId">Application ID</param>
        /// <param name="count">Count value</param>
        /// <exception cref="ArgumentException">Thrown when failed because of invalid argument</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions</exception>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        public static void Update(string appId, int count)
        {
            BadgeError err = Interop.Badge.SetCount(appId, (uint)count);
            if (err != BadgeError.None)
            {
                throw BadgeErrorFactory.GetException(err, "Failed to update badge of " + appId);
            }
        }

        /// <summary>
        /// Updates the badge information.
        /// </summary>
        /// <param name="appId">Application ID</param>
        /// <param name="isDisplay">True if it should be displayed</param>
        /// <exception cref="ArgumentException">Thrown when failed because of invalid argument</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions</exception>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        public static void Update(string appId, bool isDisplay)
        {
            BadgeError err = Interop.Badge.SetDisplay(appId, isDisplay ? 1U : 0U);
            if (err != BadgeError.None)
            {
                throw BadgeErrorFactory.GetException(err, "Failed to update badge of " + appId);
            }
        }

        /// <summary>
        /// Updates the badge information.
        /// </summary>
        /// <param name="appId">Application ID</param>
        /// <param name="count">Count value</param>
        /// <param name="isDisplay">True if it should be displayed</param>
        /// <exception cref="ArgumentException">Thrown when failed because of invalid argument</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions</exception>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        public static void Update(string appId, int count, bool isDisplay)
        {
            Update(appId, count);
            Update(appId, isDisplay);
        }

        /// <summary>
        /// Gets all badge information.
        /// </summary>
        /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions</exception>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        public static IEnumerable<Badge> GetBadges()
        {
            IList<Badge> list = new List<Badge>();

            BadgeError err = Interop.Badge.Foreach((appId, count, userData) =>
            {
                uint display = 0;
                BadgeError errGetDisplay = Interop.Badge.GetDisplay(appId, out display);
                if (errGetDisplay != BadgeError.None)
                {
                    throw BadgeErrorFactory.GetException(errGetDisplay, "Failed to get badges ");
                }

                list.Add(new Badge(appId, (int)count, display == 0 ? false : true));
            }, IntPtr.Zero);

            if (err != BadgeError.None)
            {
                throw BadgeErrorFactory.GetException(err, "Failed to get badges");
            }

            return list;
        }

        private static void OnChangedEvent(Interop.Badge.Action action, string appId, uint count, IntPtr userData)
        {
            uint display = 0;
            uint countLocal = 0;

            switch (action)
            {
                case Interop.Badge.Action.Create:
                    s_changed?.Invoke(null, new BadgeEventArgs()
                    {
                        Reason = BadgeEventArgs.Action.Add,
                        Badge = new Badge(appId, 0, false)
                    });
                    break;

                case Interop.Badge.Action.Remove:
                    s_changed?.Invoke(null, new BadgeEventArgs()
                    {
                        Reason = BadgeEventArgs.Action.Remove,
                        Badge = new Badge(appId, 0, false)
                    });
                    break;

                case Interop.Badge.Action.Update:
                    Interop.Badge.GetDisplay(appId, out display);
                    s_changed?.Invoke(null, new BadgeEventArgs()
                    {
                        Reason = BadgeEventArgs.Action.Update,
                        Badge = new Badge(appId, (int)count, display == 0 ? false : true)
                    });
                    break;

                case Interop.Badge.Action.ChangedDisplay:
                    Interop.Badge.GetCount(appId, out countLocal);
                    s_changed?.Invoke(null, new BadgeEventArgs()
                    {
                        Reason = BadgeEventArgs.Action.Update,
                        Badge = new Badge(appId, (int)countLocal, count == 0 ? false : true)
                    });
                    break;

                case Interop.Badge.Action.ServiceReady:
                    // Ignore
                    break;
            }
        }
    }
}
