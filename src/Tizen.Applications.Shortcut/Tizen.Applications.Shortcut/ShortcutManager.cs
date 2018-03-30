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

    /// <summary>
    /// This class provides some functions to add or delete a shortcut.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public static class ShortcutManager
    {
        private const string LogTag = "Tizen.Applications.Shortcut";

        private static Interop.Shortcut.ResultCallback shortcutAddResult = null;

        private static Interop.Shortcut.ResultCallback widgetAddResult = null;

        private static Interop.Shortcut.ResultCallback shortcutDeleteResult = null;

        /// <summary>
        /// Adds a shortcut on the home-screen.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="shortcut">Object that contains the shortcut information.</param>
        /// <feature>http://tizen.org/feature/shortcut</feature>
        /// <privilege>http://tizen.org/privilege/shortcut</privilege>
        /// <exception cref="ArgumentException">Thrown when an argument is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case the permission is denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when the shortcut is not supported.</exception>
        /// <exception cref="OutOfMemoryException">Thrown in case of out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        public static void Add(HomeShortcutInfo shortcut)
        {
            Interop.Shortcut.ErrorCode err = Interop.Shortcut.ErrorCode.None;

            try
            {
                int type;

                if (string.IsNullOrEmpty(shortcut.Uri))
                {
                    type = 0;
                }
                else
                {
                    type = 1;
                }

                if (shortcutAddResult == null)
                {
                    shortcutAddResult = new Interop.Shortcut.ResultCallback(ShortcutAddResultCallback);
                }

                err = Interop.Shortcut.AddToHome(shortcut.ShortcutName, type, shortcut.Uri, shortcut.IconPath, Convert.ToInt32(shortcut.IsAllowDuplicate), shortcutAddResult, IntPtr.Zero);
                if (err != Interop.Shortcut.ErrorCode.None)
                {
                    throw ShortcutErrorFactory.GetException(err, "unable to add shortcut");
                }
            }
            catch (Exception e)
            {
                throw ShortcutErrorFactory.GetException(Interop.Shortcut.ErrorCode.IoError, e.Message);
            }
        }

        /// <summary>
        /// Adds a shortcut on the home-screen.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="shortcut">Object that contains the shortcut information.</param>
        /// <feature>http://tizen.org/feature/shortcut</feature>
        /// <privilege>http://tizen.org/privilege/shortcut</privilege>
        /// <exception cref="ArgumentException">Thrown when an argument is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case the permission is denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when the shortcut is not supported.</exception>
        /// <exception cref="OutOfMemoryException">Thrown in case of out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        public static void Add(WidgetShortcutInfo shortcut)
        {
            Interop.Shortcut.ErrorCode err = Interop.Shortcut.ErrorCode.None;

            if (shortcut.Period < 0.0)
            {
                throw ShortcutErrorFactory.GetException(Interop.Shortcut.ErrorCode.InvalidParameter, "Invalid parameter");
            }

            try
            {
                if (widgetAddResult == null)
                {
                    widgetAddResult = new Interop.Shortcut.ResultCallback(WidgetAddResultCallback);
                }

                err = Interop.Shortcut.AddToWidget(shortcut.ShortcutName, shortcut.WidgetSize, shortcut.WidgetId, shortcut.IconPath, shortcut.Period, Convert.ToInt32(shortcut.IsAllowDuplicate), widgetAddResult, IntPtr.Zero);
                if (err != Interop.Shortcut.ErrorCode.None)
                {
                    throw ShortcutErrorFactory.GetException(err, "unable to add widget");
                }
            }
            catch (Exception e)
            {
                throw ShortcutErrorFactory.GetException(Interop.Shortcut.ErrorCode.IoError, e.Message);
            }
        }

        /// <summary>
        /// Removes a shortcut from home by the ShortcutName.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="shortcutName">The shortcut name string.</param>
        /// <feature>http://tizen.org/feature/shortcut</feature>
        /// <privilege>http://tizen.org/privilege/shortcut</privilege>
        /// <exception cref="ArgumentException">Thrown when an argument is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case the permission is denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when the shortcut is not supported.</exception>
        /// <exception cref="OutOfMemoryException">Thrown in case of out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        public static void Delete(string shortcutName)
        {
            Interop.Shortcut.ErrorCode err = Interop.Shortcut.ErrorCode.None;

            if (shortcutName == null)
            {
                throw ShortcutErrorFactory.GetException(Interop.Shortcut.ErrorCode.InvalidParameter, "Invalid parameter");
            }

            try
            {
                if (shortcutDeleteResult == null)
                {
                    shortcutDeleteResult = new Interop.Shortcut.ResultCallback(DeleteResultCallback);
                }

                err = Interop.Shortcut.Delete(shortcutName, shortcutDeleteResult, IntPtr.Zero);
                if (err != Interop.Shortcut.ErrorCode.None)
                {
                    throw ShortcutErrorFactory.GetException(err, "unable to delete shortcut");
                }
            }
            catch (Exception e)
            {
                throw ShortcutErrorFactory.GetException(Interop.Shortcut.ErrorCode.IoError, e.Message);
            }
        }

        /// <summary>
        /// Removes a shortcut from home by the ShortcutInfo.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="shortcut">Object that contains the shortcut information.</param>
        /// <feature>http://tizen.org/feature/shortcut</feature>
        /// <privilege>http://tizen.org/privilege/shortcut</privilege>
        /// <exception cref="ArgumentException">Thrown when an argument is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case the permission is denied.</exception>
        /// <exception cref="NotSupportedException">Thrown when the shortcut is not supported.</exception>
        /// <exception cref="OutOfMemoryException">Thrown in case of out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        public static void Delete(ShortcutInfo shortcut)
        {
            if (shortcut == null)
            {
                throw ShortcutErrorFactory.GetException(Interop.Shortcut.ErrorCode.InvalidParameter, "Invalid parameter");
            }

            try
            {
                Delete(shortcut.ShortcutName);
            }
            catch (Exception e)
            {
                throw ShortcutErrorFactory.GetException(Interop.Shortcut.ErrorCode.IoError, e.Message);
            }
        }

        private static int ShortcutAddResultCallback(int ret, IntPtr data)
        {
            if (ret != (int)Interop.Shortcut.ErrorCode.None)
            {
                Log.Error(LogTag, "unable to add shortcut " + ret);
            }

            return 0;
        }

        private static int WidgetAddResultCallback(int ret, IntPtr data)
        {
            if (ret != (int)Interop.Shortcut.ErrorCode.None)
            {
                Log.Error(LogTag, "unable to add widget " + ret);
            }

            return 0;
        }

        private static int DeleteResultCallback(int ret, IntPtr data)
        {
            if (ret != (int)Interop.Shortcut.ErrorCode.None)
            {
                Log.Error(LogTag, "unable to delete shortcut " + ret);
            }

            return 0;
        }
    }
}
