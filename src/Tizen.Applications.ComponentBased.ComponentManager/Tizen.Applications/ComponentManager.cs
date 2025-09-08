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

namespace Tizen.Applications.ComponentBased
{
    /// <summary>
    /// This class has the methods and events of the ComponentManager.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public static class ComponentManager
    {
        private const string LogTag = "Tizen.Applications";

        /// <summary>
        /// Asynchronously retrieves a list of installed components.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains an <see cref="IEnumerable{ComponentInfo}"/> of the installed component information.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is provided.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the component does not exist or if a system error occurs.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException"> Thrown when permission is denied to access the component information.</exception>
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
        /// Asynchronously retrieves a list of currently running components.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains an <see cref="IEnumerable{ComponentRunningContext}"/> of the running components.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is provided.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the component does not exist or if a system error occurs.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when permission is denied to access the running components.</exception>
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
        /// Checks if a specified component is currently running.
        /// </summary>
        /// <param name="componentId">The unique identifier of the component.</param>
        /// <returns>
        /// True if the component is running; otherwise, false.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is provided.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the component does not exist or if a system error occurs.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when permission is denied to access the component status.</exception>
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
        /// Requests to terminate a specified component that is running in the background.
        /// </summary>
        /// <param name="context">The context of the running component to terminate.</param>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is provided.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the component does not exist or if a system error occurs.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when permission is denied to terminate the component.</exception>
        /// <privilege>http://tizen.org/privilege/appmanager.kill.bgapp</privilege>
        /// <remarks>
        /// This method sends a request to terminate a background component.
        /// The platform determines if the target component can be terminated based on its current state.
        /// </remarks>
        /// <since_tizen> 6 </since_tizen>
        public static void TerminateBackgroundComponent(ComponentRunningContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("Invalid argument");
            }

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
