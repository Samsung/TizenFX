/*
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
using System.Linq;

namespace Tizen.Applications.RPCPort
{
    /// <summary>
    /// The class that proxy and stub can use to communicate with each other.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class Port
    {
        /// <summary>
        /// Enumeration for RPC port types.
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// Main channel to communicate.
            /// </summary>
            Main,

            /// <summary>
            /// Sub channel for callbacks.
            /// </summary>
            Callback
        }

        internal IntPtr Handle { get; set; }
        internal Port() { }

        /// <summary>
        /// Shares private files with other applications.
        /// </summary>
        /// <remarks>
        /// If all added paths are under the caller application's data path which can be obtained, those will be shared to the target application.
        /// Platform will grant a temporary permission to the target application for those files and revoke it when the target application is terminated or UnshareFile() is called.
        /// Paths should be regular files. The target application can just read them.
        /// Note that the target application doesn't have read permission of the directory that is obtained by caller's data path. You should open the file path with read only mode directly.
        /// </remarks>
        /// <param name="paths">The file paths to be shared.</param>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurrs.</exception>
        /// <since_tizen> 8 </since_tizen>
        public void ShareFile(IEnumerable<string> paths)
        {
            if (paths == null)
                throw new InvalidIOException();

            string[] pathArray = paths.ToArray<string>();
            Interop.LibRPCPort.ErrorCode err = Interop.LibRPCPort.Port.SetPrivateSharingArray(Handle, pathArray, (uint)pathArray.Length);
            if (err != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
        }

        /// <summary>
        /// Shares the private file with other applications.
        /// </summary>
        /// <seealso cref="ShareFile(IEnumerable{string})"/>
        /// <param name="path">The file path to be shared.</param>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurrs.</exception>
        /// <since_tizen> 8 </since_tizen>
        public void ShareFile(string path)
        {
            if (path == null)
                throw new InvalidIOException();

            Interop.LibRPCPort.ErrorCode err = Interop.LibRPCPort.Port.SetPrivateSharing(Handle, path);
            if (err != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
        }

        /// <summary>
        /// Unshares the private file.
        /// </summary>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurrs.</exception>
        /// <since_tizen> 8 </since_tizen>
        public void UnshareFile()
        {
            Interop.LibRPCPort.ErrorCode err = Interop.LibRPCPort.Port.UnsetPrivateSharing(Handle);
            if (err != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
        }
    }
}
