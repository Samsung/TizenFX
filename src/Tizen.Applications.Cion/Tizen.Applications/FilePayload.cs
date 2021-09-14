/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications
{
    /// <summary>
    /// A class to represent file type payload.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class FilePayload : Payload
    {
        private readonly string LogTag = "Tizen.Cion";

        internal FilePayload(PayloadSafeHandle handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// The constructor of FilePayload class.
        /// </summary>
        /// <param name="path">The path of file for the FilePayload.</param>
        /// <remarks>
        /// http://tizen.org/privilege/mediastorage is needed if the file path is relevant to media storage.
        /// http://tizen.org/privilege/externalstorage is needed if the file path is relevant to external storage.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when the input file path is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <since_tizen> 9 </since_tizen>
        public FilePayload(string path)
        {
            Interop.CionPayload.CionPayloadCreate(out _handle, Interop.CionPayload.PayloadType.File);
            Interop.CionPayload.CionPayloadSetFilePath(_handle, path);
        }

        /// <summary>
        /// Gets the name of received file.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string ReceivedFileName
        {
            get
            {
                Interop.Cion.ErrorCode ret = Interop.CionPayload.CionPayloadGetReceivedFileName(_handle, out string path);
                if (ret != Interop.Cion.ErrorCode.None)
                {
                    // property should not throw exception.
                    return "";
                }
                return path;
            }
        }

        /// <summary>
        /// Gets size of received file.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public UInt64 ReceivedBytes
        { 
            get
            {
                Interop.Cion.ErrorCode ret = Interop.CionPayload.CionPayloadGetReceivedBytes(_handle, out UInt64 bytes);
                if (ret != Interop.Cion.ErrorCode.None)
                {
                    Log.Error(LogTag, "Failed to get received bytes.");
                    return Byte.MinValue;
                }
                return bytes;
            }
        }

        /// <summary>
        /// Gets total size of the file.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public UInt64 TotalBytes 
        {
            get
            {
                Interop.Cion.ErrorCode ret = Interop.CionPayload.CionPayloadGetTotalBytes(_handle, out UInt64 bytes);
                if (ret != Interop.Cion.ErrorCode.None)
                {
                    Log.Error(LogTag, "Failed to get total bytes.");
                    return Byte.MinValue;
                }
                return bytes;
            }
        }

        /// <summary>
        /// Gets type of the payload.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public override PayloadType PayloadType
        {
            get
            {
                return PayloadType.FilePayload;
            }
        }

        /// <summary>
        /// Saves file of payload to speicific path.
        /// </summary>
        /// <param name="path">The path of file to save.</param>
        /// <remarks>
        /// http://tizen.org/privilege/mediastorage is needed if the file path is relevant to media storage.
        /// http://tizen.org/privilege/externalstorage is needed if the file path is relevant to external storage.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when the input file path is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void SaveAsFile(string path)
        {
            Interop.Cion.ErrorCode ret = Interop.CionPayload.CionPayloadSaveAsFile(_handle, path);
            if (ret != Interop.Cion.ErrorCode.None)
            {
                throw CionErrorFactory.GetException(ret, "Failed to save as file.");
            }
        }
    }
}
