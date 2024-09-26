/*
 * Copyright (c) 2024 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Core
{
    /// <summary>
    /// The class which provides functions related to the Tizen Core.
    /// </summary>
    public static class TizenCore
    {
        /// <summary>
        /// Initializes Tizen Core.
        /// This method should be called once per application before creating any Tasks.
        /// Calling this method more than one time will increase internal reference counts which need to be matched by calling Shutdown().
        /// Failing to call Shutdown() in corresponding number of calls may cause resource leakages.
        /// </summary>
        /// <example>
        /// <code>
        /// 
        /// TizenCore.Initialize();
        /// var task = TizenCore.Spawn("Worker");
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        static public void Initialize()
        {
            Interop.LibTizenCore.TizenCore.Init();
        }

        /// <summary>
        /// Shuts down Tizen Core.
        /// </summary>
        /// <example>
        /// <code>
        /// 
        /// TizenCore.Shutdown();
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        static public void Shutdown()
        {
            Interop.LibTizenCore.TizenCore.Shutdown();
        }

        /// <summary>
        /// Finds the task instance.
        /// </summary>
        /// <param name="id">The ID of the task.</param>
        /// <example>
        /// <code>
        /// 
        /// TizenCore.Initialize();
        /// var task = TizenCore.Find("Test") ?? TizenCore.Spawn("Test");
        /// 
        /// </code>
        /// </example>
        /// <returns>On success the task instance, othwerwise null.</returns>
        public static Task Find(string id)
        {
            return Task.Find(id);
        }

        /// <summary>
        /// Finds the task instance running in the thread of the caller or the "main" task.
        /// </summary>
        /// <returns>On success the task instance, othwerwise null.</returns>
        /// <example>
        /// <code>
        /// 
        /// TizenCore.Initialize();
        /// var coreTask = TizenCore.FindFromThisThread();
        /// if (coreTask != null)
        /// {
        ///   coreTask.Post(() => {
        ///     Console.WriteLine("Idler invoked");
        ///   });
        /// }
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public static Task FindFromCurrentThread()
        {
            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCore.FindFromThisThread(out IntPtr handle);
            if (error == Interop.LibTizenCore.ErrorCode.None)
            {
                return new Task(handle);
            }

            return null;
        }

        /// <summary>
        /// Creates and runs the task.
        /// </summary>
        /// <param name="id">The ID of the task.</param>
        /// <returns>On succes the created task instance, othwerwise null.</returns>
        /// <example>
        /// <code>
        /// 
        /// TizenCore.Initialize();
        /// var task = TizenCore.Spawn("Worker");
        /// if (task != null)
        /// {
        ///   task.AddTimer(5000, () => {
        ///     Console.WriteLine("Timer expired");
        ///     return true;
        ///   });
        /// }
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public static Task Spawn(string id)
        {
           return Task.Spawn(id);
        }
    }

    internal static class TCoreErrorFactory
    {
        internal enum TCoreError
        {
            None = Interop.LibTizenCore.ErrorCode.None,
            InvalidParameter = Interop.LibTizenCore.ErrorCode.InvalidParameter,
            OutOfMemory = Interop.LibTizenCore.ErrorCode.OutOfMemory,
            InvalidContext = Interop.LibTizenCore.ErrorCode.InvalidContext,
        }

        static internal void CheckAndThrownException(Interop.LibTizenCore.ErrorCode error, string message)
        {
            if ((TCoreError)error == TCoreError.None)
            {
                return;
            }

            if ((TCoreError)error == TCoreError.InvalidParameter)
            {
                throw new ArgumentException(message);
            }
            else if ((TCoreError)error == TCoreError.OutOfMemory)
            {
                throw new OutOfMemoryException(message);
            }
            else if ((TCoreError)error == TCoreError.InvalidContext)
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}
