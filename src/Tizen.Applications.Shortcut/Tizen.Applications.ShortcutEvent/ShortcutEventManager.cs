/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd. All rights reserved.
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

namespace Tizen.Applications.Shortcut
{
    using System;
    using System.Collections.Generic;
    using Tizen.Internals.Errors;

    /// <summary>
    /// The callback function that is invoked when add request occurred
    /// </summary>
    /// <param name="args">Object that contain shortcut info to add.</param>
    /// <returns>The result of handling a shortcut add request</returns>
    /// <since_tizen> 4 </since_tizen>
    public delegate ShortcutError ShortcutAdded(ShortcutAddedInfo args);

    /// <summary>
    /// The callback function that is invoked when delete request occurred
    /// </summary>
    /// <param name="args">Object that contain shortcut info to delete.</param>
    /// <returns>The result of handling a shortcut delete request</returns>
    /// <since_tizen> 4 </since_tizen>
    public delegate ShortcutError ShortcutDeleted(ShortcutDeletedInfo args);

    /// <summary>
    /// This class provides a way to register callback function for shortcut add, delete events.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public static class ShortcutEventManager
    {
        private static Interop.Shortcut.AddCallback shortcutAddCallback;

        private static Interop.Shortcut.DeleteCallback shortcutDeleteCallback;

        private static IList<ShortcutTemplate> shortcutTemplates = new List<ShortcutTemplate>();

        private static ShortcutAdded shortcutAdded = null;

        private static ShortcutDeleted shortcutDeleted = null;

        /// <summary>
        /// Registers a callback function to listen requests from applications.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="addedEvent">The callback function pointer that is invoked when Add() is requested</param>
        /// <feature>http://tizen.org/feature/shortcut</feature>
        /// <privilege>http://tizen.org/privilege/shortcut</privilege>
        /// <remarks>
        /// Previous registered delegate function should be unregister.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when argument is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of permission denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when Shortcut is not supported.</exception>
        /// <exception cref="OutOfMemoryException">Thrown in case of out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        public static void RegisterEventHandler(ShortcutAdded addedEvent)
        {
            if (shortcutAddCallback == null)
            {
                shortcutAddCallback = new Interop.Shortcut.AddCallback(AddCallback);

                Interop.Shortcut.ErrorCode err = Interop.Shortcut.SetShortcutAddCallback(shortcutAddCallback, IntPtr.Zero);
                if (err != Interop.Shortcut.ErrorCode.None)
                {
                    shortcutAddCallback = null;
                    throw ShortcutErrorFactory.GetException(err, "unable to register callback");
                }

                shortcutAdded = addedEvent;
            }
            else
            {
                throw ShortcutErrorFactory.GetException(Interop.Shortcut.ErrorCode.InvalidParameter, null);
            }
        }

        /// <summary>
        /// Registers a callback function to listen requests from applications.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="deletedEvent">The callback function pointer that is invoked when Delete() is requested</param>
        /// <feature>http://tizen.org/feature/shortcut</feature>
        /// <privilege>http://tizen.org/privilege/shortcut</privilege>
        /// <remarks>
        /// Previous registered delegate function should be unregister.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when argument is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of permission denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when Shortcut is not supported.</exception>
        /// <exception cref="OutOfMemoryException">Thrown in case of out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        public static void RegisterEventHandler(ShortcutDeleted deletedEvent)
        {
            if (shortcutDeleteCallback == null)
            {
                shortcutDeleteCallback = new Interop.Shortcut.DeleteCallback(DeleteCallback);

                Interop.Shortcut.ErrorCode err = Interop.Shortcut.SetShortcutDeleteCallback(shortcutDeleteCallback, IntPtr.Zero);
                if (err != Interop.Shortcut.ErrorCode.None)
                {
                    shortcutDeleteCallback = null;
                    throw ShortcutErrorFactory.GetException(err, "unable to register callback");
                }

                shortcutDeleted = deletedEvent;
            }
            else
            {
                throw ShortcutErrorFactory.GetException(Interop.Shortcut.ErrorCode.InvalidParameter, null);
            }
        }

        /// <summary>
        /// Unregisters a callback for the shortcut request.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="addedEvent">The callback function pointer that used for RegisterCallback</param>
        /// <feature>http://tizen.org/feature/shortcut</feature>
        /// <privilege>http://tizen.org/privilege/shortcut</privilege>
        /// <exception cref="ArgumentException">Thrown when argument is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of permission denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when Shortcut is not supported.</exception>
        public static void UnregisterEventHandler(ShortcutAdded addedEvent)
        {
            if (shortcutAdded != null && shortcutAdded.Equals(addedEvent))
            {
                shortcutAdded = null;

                if (shortcutAddCallback != null)
                {
                    Interop.Shortcut.UnsetShortcutAddCallback();
                    shortcutAddCallback = null;

                    int err = ErrorFacts.GetLastResult();
                    if (err != (int)Interop.Shortcut.ErrorCode.None)
                    {
                        throw ShortcutErrorFactory.GetException((Interop.Shortcut.ErrorCode)err, "unable to unregister callback");
                    }
                }
            }
            else
            {
                throw ShortcutErrorFactory.GetException(Interop.Shortcut.ErrorCode.InvalidParameter, null);
            }
        }

        /// <summary>
        /// Unregisters a callback for the shortcut request.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="deletedEvent">The callback function pointer that used for RegisterCallback</param>
        /// <feature>http://tizen.org/feature/shortcut</feature>
        /// <privilege>http://tizen.org/privilege/shortcut</privilege>
        /// <exception cref="ArgumentException">Thrown when argument is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of permission denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when Shortcut is not supported.</exception>
        public static void UnregisterEventHandler(ShortcutDeleted deletedEvent)
        {
            if (shortcutDeleted != null && shortcutDeleted.Equals(deletedEvent))
            {
                shortcutDeleted = null;

                if (shortcutDeleteCallback != null)
                {
                    Interop.Shortcut.UnsetShortcutDeleteCallback();
                    shortcutDeleteCallback = null;

                    int err = ErrorFacts.GetLastResult();
                    if (err != (int)Interop.Shortcut.ErrorCode.None)
                    {
                        throw ShortcutErrorFactory.GetException((Interop.Shortcut.ErrorCode) err, "unable to unregister callback");
                    }
                }
            }
            else
            {
                throw ShortcutErrorFactory.GetException(Interop.Shortcut.ErrorCode.InvalidParameter, null);
            }
        }

        /// <summary>
        /// Gets the preset list of shortcut template from the installed package.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="appId">Application ID.</param>
        /// <returns>The List of ShortcutTemplate.</returns>
        /// <feature>http://tizen.org/feature/shortcut</feature>
        /// <privilege>http://tizen.org/privilege/shortcut</privilege>
        /// <exception cref="ArgumentException">Thrown when argument is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of permission denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when Shortcut is not supported.</exception>
        /// <exception cref="OutOfMemoryException">Thrown in case of out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        public static IEnumerable<ShortcutTemplate> GetTemplateList(string appId)
        {
            shortcutTemplates.Clear();

            if (string.IsNullOrEmpty(appId))
            {
                throw ShortcutErrorFactory.GetException(Interop.Shortcut.ErrorCode.InvalidParameter, null);
            }

            Interop.Shortcut.ListCallback callback = (appName, iconPath, shortcutName, extrakey, extraData, user_data) =>
            {
                ShortcutTemplate template = new ShortcutTemplate
                {
                    AppId = appName,
                    ShortcutName = shortcutName,
                    IconPath = iconPath,
                    ExtraKey = extrakey,
                    ExtraData = extraData,
                };

                shortcutTemplates.Add(template);

                return 0;
            };

            Interop.Shortcut.ErrorCode err = Interop.Shortcut.GetList(appId, callback, IntPtr.Zero);
            if (err < Interop.Shortcut.ErrorCode.None)
            {
                throw ShortcutErrorFactory.GetException(err, "unable to get ShortcutTemplate Lists");
            }

            return shortcutTemplates;
        }

        private static int AddCallback(string appId, string shortcutName, int type, string contentInfo, string iconPath, int processId, double period, bool isAllowDuplicate, IntPtr data)
        {
            ShortcutError err;

            if (type == (int)ShortcutType.LaunchByApp || type == (int)ShortcutType.LaunchByUri)
            {
                HomeShortcutAddedInfo shortcutInfo = new HomeShortcutAddedInfo
                {
                    ShortcutName = shortcutName,
                    IconPath = iconPath,
                    IsAllowDuplicate = isAllowDuplicate,
                    AppId = appId,
                };

                if (contentInfo != null && contentInfo != String.Empty)
                {
                    shortcutInfo.Uri = contentInfo;
                }

                if (shortcutAdded != null)
                {
                    err = shortcutAdded(shortcutInfo);
                }
                else
                {
                    err = ShortcutError.IoError;
                }
            }
            else
            {
                WidgetShortcutAddedInfo shortcutInfo = new WidgetShortcutAddedInfo
                {
                    ShortcutName = shortcutName,
                    IconPath = iconPath,
                    IsAllowDuplicate = isAllowDuplicate,
                    WidgetId = appId,
                    WidgetSize = (ShortcutWidgetSize)type,
                    Period = period,
                };

                if (shortcutAdded != null)
                {
                    err = shortcutAdded(shortcutInfo);
                }
                else
                {
                    err = ShortcutError.IoError;
                }
            }

            return (int)err;
        }

        private static int DeleteCallback(string appId, string shortcutName, int processId, IntPtr data)
        {
            ShortcutError err = ShortcutError.None;

            ShortcutDeletedInfo deletedInfo = new ShortcutDeletedInfo
            {
                AppId = appId,
                ShortcutName = shortcutName,
            };

            if (shortcutDeleted != null)
            {
                err = shortcutDeleted(deletedInfo);
            }
            else
            {
                err = ShortcutError.IoError;
            }

            return (int)err;
        }
    }
}
