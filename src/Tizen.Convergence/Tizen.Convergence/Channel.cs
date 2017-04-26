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

using System;
using System.Runtime.InteropServices;

namespace Tizen.Convergence
{
    /// <summary>
    /// The Channel class provies a logical session for communicating with AppCommunicationService.
    /// </summary>
    public class Channel : IDisposable
    {
        internal Interop.ConvChannelHandle _channelHandle;
        internal const string ChannelUriKey = "uri";
        internal const string ChannelIdKey = "channel_id";

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="uri">Uri of the server side app</param>
        /// <param name="id">Unique identifier</param>
        /// <feature>http://tizen.org/feature/convergence.d2d</feature>
        /// <exception cref="NotSupportedException">Thrown if the required feature is not supported.</exception>
        /// <exception cref="ArgumentNullException">Throws when the arguments passed are null</exception>
        public Channel(string uri, string id)
        {
            if (uri == null || id == null)
            {
                throw new ArgumentNullException();
            }

            int ret = Interop.ConvChannel.Create(out _channelHandle);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to create channel");
                throw ErrorFactory.GetException(ret);
            }

            ret = Interop.ConvChannel.SetString(_channelHandle, ChannelUriKey, uri);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to create channel");
                throw ErrorFactory.GetException(ret);
            }

            ret = Interop.ConvChannel.SetString(_channelHandle, ChannelIdKey, id);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to create channel");
                throw ErrorFactory.GetException(ret);
            }

            Uri = uri;
            Id = id;
        }

        internal Channel(IntPtr channelHandle)
        {
            _channelHandle = new Interop.ConvChannelHandle(channelHandle, false);

            IntPtr stringPtr = IntPtr.Zero;
            int ret = Interop.ConvChannel.GetString(_channelHandle, ChannelUriKey, out stringPtr);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to create channel");
                throw ErrorFactory.GetException(ret);
            }
            Uri = Marshal.PtrToStringAnsi(stringPtr);
            Interop.Libc.Free(stringPtr);

            ret = Interop.ConvChannel.GetString(_channelHandle, ChannelIdKey, out stringPtr);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to create channel");
                throw ErrorFactory.GetException(ret);
            }

            Id = Marshal.PtrToStringAnsi(stringPtr);
            Interop.Libc.Free(stringPtr);
        }

        /// <summary>
        /// Uri of the server side app
        /// </summary>
        public string Uri { get; }

        /// <summary>
        /// Unique identifier
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The dispose method
        /// </summary>
        public void Dispose()
        {
            _channelHandle.Dispose();
        }
    }
}
