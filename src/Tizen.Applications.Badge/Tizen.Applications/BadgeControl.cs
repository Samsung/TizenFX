// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Collections.Generic;

namespace Tizen.Applications
{
    /// <summary>
    /// Class for badge operaion.
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
                        s_callback = new Interop.Badge.ChangedCallback(OnChangedEvent);
                    Interop.Badge.ErrorCode err = Interop.Badge.SetChangedCallback(s_callback, IntPtr.Zero);

                    switch (err)
                    {
                        case Interop.Badge.ErrorCode.InvalidParameter:
                            throw new InvalidOperationException("Invalid parameter at unmanaged code");

                        case Interop.Badge.ErrorCode.PermissionDenied:
                            throw new UnauthorizedAccessException();

                        case Interop.Badge.ErrorCode.OutOfMemory:
                            throw new InvalidOperationException("Out-of-memory at unmanaged code");
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
                    Interop.Badge.ErrorCode err = Interop.Badge.UnsetChangedCallback(s_callback);

                    switch (err)
                    {
                        case Interop.Badge.ErrorCode.InvalidParameter:
                            throw new InvalidOperationException("Invalid parameter at unmanaged code");

                        case Interop.Badge.ErrorCode.PermissionDenied:
                            throw new UnauthorizedAccessException();

                        case Interop.Badge.ErrorCode.NotExist:
                            throw new InvalidOperationException("Not exist");
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

            Interop.Badge.ErrorCode err = Interop.Badge.GetCount(appId, out count);

            switch (err)
            {
                case Interop.Badge.ErrorCode.InvalidParameter:
                    throw new ArgumentException("Invalid parameter");

                case Interop.Badge.ErrorCode.PermissionDenied:
                    throw new UnauthorizedAccessException();

                case Interop.Badge.ErrorCode.FromDb:
                    throw new InvalidOperationException("Error from DB");

                case Interop.Badge.ErrorCode.OutOfMemory:
                    throw new InvalidOperationException("Out-of-memory at unmanaged code");
            }

            err = Interop.Badge.GetDisplay(appId, out display);

            switch (err)
            {
                case Interop.Badge.ErrorCode.InvalidParameter:
                    throw new ArgumentException("Invalid parameter");

                case Interop.Badge.ErrorCode.PermissionDenied:
                    throw new UnauthorizedAccessException();

                case Interop.Badge.ErrorCode.FromDb:
                    throw new InvalidOperationException("Error from DB");

                case Interop.Badge.ErrorCode.OutOfMemory:
                    throw new InvalidOperationException("Out-of-memory at unmanaged code");

                case Interop.Badge.ErrorCode.NotExist:
                    throw new InvalidOperationException("Not exist");
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
            Interop.Badge.ErrorCode err = Interop.Badge.Remove(appId);

            switch (err)
            {
                case Interop.Badge.ErrorCode.InvalidParameter:
                    throw new ArgumentException("Invalid parameter");

                case Interop.Badge.ErrorCode.PermissionDenied:
                    throw new UnauthorizedAccessException();

                case Interop.Badge.ErrorCode.IoError:
                    throw new InvalidOperationException("Error from I/O");

                case Interop.Badge.ErrorCode.ServiceNotReady:
                    throw new InvalidOperationException("Service is not ready");

                case Interop.Badge.ErrorCode.NotExist:
                    throw new InvalidOperationException("Not exist");
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
            Interop.Badge.ErrorCode err = Interop.Badge.Add(appId);

            switch (err)
            {
                case Interop.Badge.ErrorCode.InvalidParameter:
                    throw new ArgumentException("Invalid parameter");

                case Interop.Badge.ErrorCode.PermissionDenied:
                    throw new UnauthorizedAccessException();

                case Interop.Badge.ErrorCode.IoError:
                    throw new InvalidOperationException("Error from I/O");

                case Interop.Badge.ErrorCode.ServiceNotReady:
                    throw new InvalidOperationException("Service is not ready");

                case Interop.Badge.ErrorCode.InvalidPackage:
                    throw new InvalidOperationException("The caller application is not signed with the certificate of badge application ID");
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
            Interop.Badge.ErrorCode err = Interop.Badge.SetCount(appId, (uint)count);

            switch (err)
            {
                case Interop.Badge.ErrorCode.InvalidParameter:
                    throw new ArgumentException("Invalid parameter");

                case Interop.Badge.ErrorCode.PermissionDenied:
                    throw new UnauthorizedAccessException();

                case Interop.Badge.ErrorCode.IoError:
                    throw new InvalidOperationException("Error from I/O");

                case Interop.Badge.ErrorCode.ServiceNotReady:
                    throw new InvalidOperationException("Service is not ready");
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
            Interop.Badge.ErrorCode err = Interop.Badge.SetDisplay(appId, isDisplay ? 1U : 0U);

            switch (err)
            {
                case Interop.Badge.ErrorCode.InvalidParameter:
                    throw new ArgumentException("Invalid parameter");

                case Interop.Badge.ErrorCode.PermissionDenied:
                    throw new UnauthorizedAccessException();

                case Interop.Badge.ErrorCode.IoError:
                    throw new InvalidOperationException("Error from I/O");

                case Interop.Badge.ErrorCode.ServiceNotReady:
                    throw new InvalidOperationException("Service is not ready");
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

            Interop.Badge.ErrorCode err = Interop.Badge.Foreach((appId, count, userData) =>
            {
                uint display = 0;
                Interop.Badge.ErrorCode e = Interop.Badge.GetDisplay(appId, out display);
                switch (e)
                {
                    case Interop.Badge.ErrorCode.InvalidParameter:
                        throw new InvalidOperationException("Invalid parameter at unmanaged code");

                    case Interop.Badge.ErrorCode.PermissionDenied:
                        throw new UnauthorizedAccessException();

                    case Interop.Badge.ErrorCode.FromDb:
                        throw new InvalidOperationException("Error from DB");

                    case Interop.Badge.ErrorCode.OutOfMemory:
                        throw new InvalidOperationException("Out-of-memory at unmanaged code");

                    case Interop.Badge.ErrorCode.NotExist:
                        throw new InvalidOperationException("Not exist");

                    case Interop.Badge.ErrorCode.ServiceNotReady:
                        throw new InvalidOperationException("Service is not ready");
                }

                list.Add(new Badge(appId, (int)count, display == 0 ? false : true));
            }, IntPtr.Zero);

            switch (err)
            {
                case Interop.Badge.ErrorCode.InvalidParameter:
                    throw new InvalidOperationException("Invalid parameter at unmanaged code");

                case Interop.Badge.ErrorCode.PermissionDenied:
                    throw new UnauthorizedAccessException();

                case Interop.Badge.ErrorCode.FromDb:
                    throw new InvalidOperationException("Error from DB");

                case Interop.Badge.ErrorCode.OutOfMemory:
                    throw new InvalidOperationException("Out-of-memory at unmanaged code");

                case Interop.Badge.ErrorCode.NotExist:
                    throw new InvalidOperationException("Not exist");
            }

            return list;
        }

        private static void OnChangedEvent(Interop.Badge.Action action, string appId, uint count, IntPtr userData)
        {
            uint display = 0;

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
                case Interop.Badge.Action.ChangedDisplay:
                    Interop.Badge.GetDisplay(appId, out display);
                    s_changed?.Invoke(null, new BadgeEventArgs()
                    {
                        Reason = BadgeEventArgs.Action.Update,
                        Badge = new Badge(appId, (int)count, display == 0 ? false : true)
                    });
                    break;

                case Interop.Badge.Action.ServiceReady:
                    // Ignore
                    break;
            }
        }
    }
}
