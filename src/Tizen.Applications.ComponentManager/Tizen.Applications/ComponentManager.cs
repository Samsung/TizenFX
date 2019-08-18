/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Tizen.Applications
{
    /// <summary>
    /// This class has the methods and events of the ComponentManager.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public static class ComponentManager
    {
        private const string LogTag = "Tizen.Applications";
        
        /// <summary>
        /// Gets the information of the installed components asynchronously.
        /// </summary>
        /// <returns>The installed component info list.</returns>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of the "component not exist" error or the system error.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed because of out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when failed because of permission denied.</exception>
        /// <privilege>http://tizen.org/privilege/packagemanager.info</privilege>
        /// <since_tizen> 6 </since_tizen>
        public static async Task<IEnumerable<ComponentInfo>> GetInstalledComponentsAsync()
        {
            return await Task.Run(() =>
            {
                Interop.ComponentManager.ErrorCode err = Interop.ComponentManager.ErrorCode.None;
                List<ComponentInfo> result = new List<ComponentInfo>();

                Interop.ComponentManager.ComponentManagerComponentInfoCallback cb = (IntPtr infoHandle, IntPtr userData) =>
                {
                    if (infoHandle != IntPtr.Zero)
                    {
                        IntPtr clonedHandle = IntPtr.Zero;
                        err = Interop.ComponentManager.ComponentInfoClone(out clonedHandle, infoHandle);
                        if (err != Interop.ComponentManager.ErrorCode.None)
                        {
                            Log.Warn(LogTag, "Failed to clone the ComponentInfo. err = " + err);
                            return false;
                        }
                        ComponentInfo info = new ComponentInfo(clonedHandle);
                        result.Add(info);
                        return true;
                    }
                    return false;
                };
                err = Interop.ComponentManager.ComponentManagerForeachComponentInfo(cb, IntPtr.Zero);
                if (err != Interop.ComponentManager.ErrorCode.None)
                {
                    throw ComponentManagerErrorFactory.GetException(err, "Failed to retrieve the component info.");
                }
                return result;
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the information of the running components asynchronously.
        /// </summary>
        /// <returns>The component running context list.</returns>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of the "component not exist" error or the system error.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed because of out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when failed because of permission denied.</exception>
        /// <privilege>http://tizen.org/privilege/packagemanager.info</privilege>
        /// <since_tizen> 6 </since_tizen>
        public static async Task<IEnumerable<ComponentRunningContext>> GetRunningComponentsAsync()
        {
            return await Task.Run(() =>
            {
                Interop.ComponentManager.ErrorCode err = Interop.ComponentManager.ErrorCode.None;
                List<ComponentRunningContext> result = new List<ComponentRunningContext>();

                Interop.ComponentManager.ComponentManagerComponentContextCallback cb = (IntPtr contextHandle, IntPtr userData) =>
                {
                    if (contextHandle != IntPtr.Zero)
                    {
                        IntPtr clonedHandle = IntPtr.Zero;
                        err = Interop.ComponentManager.ComponentContextClone(out clonedHandle, contextHandle);
                        if (err != Interop.ComponentManager.ErrorCode.None)
                        {
                            Log.Warn(LogTag, "Failed to clone the ComponentInfo. err = " + err);
                            return false;
                        }
                        ComponentRunningContext context = new ComponentRunningContext(clonedHandle);
                        result.Add(context);
                        return true;
                    }
                    return false;
                };
                err = Interop.ComponentManager.ComponentManagerForeachComponentContext(cb, IntPtr.Zero);
                if (err != Interop.ComponentManager.ErrorCode.None)
                {
                    throw ComponentManagerErrorFactory.GetException(err, "Failed to retrieve the running component context.");
                }
                return result;
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks whether the component is running or not.
        /// </summary>
        /// <param name="componentId">Component ID.</param>
        /// <returns>Returns true if the component is running, otherwise false.</returns>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of the "component not exist" error or the system error.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed because of out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when failed because of permission denied.</exception>
        /// <privilege>http://tizen.org/privilege/packagemanager.info</privilege>
        /// <since_tizen> 6 </since_tizen>
        public static bool IsRunning(string componentId)
        {
            bool isRunning = false;
            Interop.ComponentManager.ErrorCode err = Interop.ComponentManager.ComponentManagerIsRunning(componentId, out isRunning);
            if (err != Interop.ComponentManager.ErrorCode.None)
            {
                throw ComponentManagerErrorFactory.GetException(err, "Failed to check the IsRunning of " + componentId + ".");
            }
            return isRunning;
        }

        /// <summary>
        /// Terminates the component if it is running in the background.
        /// </summary>
        /// <param name="context">Component ID</param>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid argument.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of the "component not exist" error or the system error.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed because of out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when failed because of permission denied.</exception>
        /// <privilege>http://tizen.org/privilege/appmanager.kill.bgapp</privilege>
        /// <remarks>
        /// This function returns after it just sends a request for terminating a background component.
        /// Platform will decide if the target component could be terminated or not according to the state of the target component.
        /// </remarks>
        /// <since_tizen> 6 </since_tizen>
        public static void TerminateBackgroundComponent(ComponentRunningContext context)
        {
            Interop.ComponentManager.ErrorCode err = Interop.ComponentManager.ComponentManagerTerminateBgComponent(context._contextHandle);
            if (err != Interop.ComponentManager.ErrorCode.None)
            {
                throw ComponentManagerErrorFactory.GetException(err, "Failed to send the terminate request.");
            }
        }

        internal static class ComponentManagerErrorFactory
        {
            internal static Exception GetException(Interop.ComponentManager.ErrorCode err, string message)
            {
                string errMessage = string.Format("{0} err = {1}", message, err);
                switch (err)
                {
                    case Interop.ComponentManager.ErrorCode.InvalidParameter:
                    case Interop.ComponentManager.ErrorCode.NoSuchComponent:
                        return new ArgumentException(errMessage);
                    case Interop.ComponentManager.ErrorCode.PermissionDenied:
                        return new UnauthorizedAccessException(errMessage);
                    case Interop.ComponentManager.ErrorCode.IoError:
                        return new global::System.IO.IOException(errMessage);
                    case Interop.ComponentManager.ErrorCode.OutOfMemory:
                        return new OutOfMemoryException(errMessage);
                    default:
                        return new InvalidOperationException(errMessage);
                }
            }
        }
    }
}
