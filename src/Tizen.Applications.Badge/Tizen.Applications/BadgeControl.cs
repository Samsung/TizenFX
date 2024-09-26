/*
 * Copyright (c) 2016 - 2017 Samsung Electronics Co., Ltd. All rights reserved.
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
 */

namespace Tizen.Applications
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// The class for badge operation.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API12. Will be removed in API14.")]
    public static class BadgeControl
    {
        private static event EventHandler<BadgeEventArgs> s_changed;
        private static bool s_registered = false;
        private static Interop.Badge.ChangedCallback s_callback;

        /// <summary>
        /// Event handler for receiving badge events.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/badge</feature>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access.</exception>
        /// <exception cref="NotSupportedException">Thrown when Badge is not supported.</exception>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
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
        /// Gets the badge information from the application ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="appId">Application ID.</param>
        /// <returns>The Badge object with inputted application ID</returns>
        /// <feature>http://tizen.org/feature/badge</feature>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions.</exception>
        /// <exception cref="NotSupportedException">Thrown when Badge is not supported.</exception>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
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
        /// <since_tizen> 3 </since_tizen>
        /// <param name="appId">Application ID.</param>
        /// <feature>http://tizen.org/feature/badge</feature>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <exception cref="ArgumentException">Thrown when failed because of a an invalid argument.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions.</exception>
        /// <exception cref="NotSupportedException">Thrown when Badge is not supported.</exception>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
        public static void Remove(string appId)
        {
            BadgeError err = Interop.Badge.Remove(appId);
            if (err != BadgeError.None)
            {
                throw BadgeErrorFactory.GetException(err, "Failed to Remove badge of " + appId);
            }
        }

        /// <summary>
        /// Removes the badge information.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="badge">The Badge object.</param>
        /// <feature>http://tizen.org/feature/badge</feature>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions.</exception>
        /// <exception cref="NotSupportedException">Thrown when Badge is not supported.</exception>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
        public static void Remove(Badge badge)
        {
            if (badge == null)
            {
                throw BadgeErrorFactory.GetException(BadgeError.InvalidParameter, "Invalid Badge object");
            }

            Remove(badge.AppId);
        }

        /// <summary>
        /// Adds the badge information.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="badge">The Badge object.</param>
        /// <feature>http://tizen.org/feature/badge</feature>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions.</exception>
        /// <exception cref="NotSupportedException">Thrown when Badge is not supported.</exception>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
        public static void Add(Badge badge)
        {
            if (badge == null)
            {
                throw BadgeErrorFactory.GetException(BadgeError.InvalidParameter, "Invalid Badge object");
            }

            BadgeError err = Interop.Badge.Add(badge.AppId);
            if (err != BadgeError.None)
            {
                throw BadgeErrorFactory.GetException(err, "Failed to add badge of " + badge.AppId);
            }

            try
            {
                Update(badge);
            }
            catch (Exception e)
            {
                Remove(badge.AppId);
                throw e;
            }
        }

        /// <summary>
        /// Updates the badge information.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="badge">The Badge object.</param>
        /// <feature>http://tizen.org/feature/badge</feature>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions.</exception>
        /// <exception cref="NotSupportedException">Thrown when Badge is not supported.</exception>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
        public static void Update(Badge badge)
        {
            if (badge == null)
            {
                throw BadgeErrorFactory.GetException(BadgeError.InvalidParameter, "Invalid Badge object");
            }

            BadgeError err = Interop.Badge.SetCount(badge.AppId, (uint)badge.Count);
            if (err != BadgeError.None)
            {
                throw BadgeErrorFactory.GetException(err, "Failed to update badge of " + badge.AppId);
            }

            err = Interop.Badge.SetDisplay(badge.AppId, badge.Visible ? 1U : 0U);
            if (err != BadgeError.None)
            {
                throw BadgeErrorFactory.GetException(err, "Failed to update badge of " + badge.AppId);
            }
        }

        /// <summary>
        /// Gets all the badge information.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>List of all Badge instances.</returns>
        /// <feature>http://tizen.org/feature/badge</feature>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of failed conditions.</exception>
        /// <exception cref="NotSupportedException">Thrown when Badge is not supported.</exception>
        [Obsolete("Deprecated since API12. Will be removed in API14.")]
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

                return true;
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
