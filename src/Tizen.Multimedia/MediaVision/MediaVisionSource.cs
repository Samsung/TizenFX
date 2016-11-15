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
using static Interop.MediaVision;

namespace Tizen.Multimedia
{
    /// <summary>
    /// This class represents media vision source. An instance of this class has to be created \n
    /// to keep information on image or video frame data as raw buffer. It can be created based on \n
    /// the media data stored in memory or using the BaseMediaPacket class. \n
    /// It provides a set of getters which allow to retrieve such image parameters as its size or colorspace (see Colorspace enumeration).
    /// </summary>
    public class MediaVisionSource : IDisposable
    {
        internal IntPtr _sourceHandle = IntPtr.Zero;
        private bool _disposed = false;

        /// <summary>
        /// The media vision source constructor
        /// </summary>
        /// <code>
        /// MediaVisionSource source = new MediaVisionSource();
        /// </code>
        public MediaVisionSource()
        {
            int ret = Interop.MediaVision.MediaSource.Create(out _sourceHandle);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to create media vision source.");
        }

        /// <summary>
        /// Destructor of the MediaVisionSource class.
        /// </summary>
        ~MediaVisionSource()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets buffer of the media source.
        /// </summary>
        /// <code>
        /// 
        /// </code>
        public byte[] Buffer
        {
            get
            {
                IntPtr byteStrPtr;
                int byteStrSize;
                MediaVisionError ret = (MediaVisionError)Interop.MediaVision.MediaSource.GetBuffer(_sourceHandle, out byteStrPtr, out byteStrSize);
                if (ret != MediaVisionError.None)
                {
                    Log.Error(MediaVisionLog.Tag, "[{0}] : Failed to get buffer data", ret.ToString());
                    return null;
                }

                byte[] byteStr = new byte[byteStrSize];
                if (byteStrSize > 0)
                {
                    Marshal.Copy(byteStrPtr, byteStr, 0, byteStrSize);
                }

                return byteStr;
            }
        }

        /// <summary>
        /// Gets height of the media source.
        /// </summary>
        /// <code>
        /// 
        /// </code>
        public uint Height
        {
            get
            {
                uint height = 0;
                MediaVisionError ret = (MediaVisionError)Interop.MediaVision.MediaSource.GetHeight(_sourceHandle, out height);
                if (ret != MediaVisionError.None)
                {
                    Log.Error(MediaVisionLog.Tag, "[{0}] : Failed to get height", ret.ToString());
                }

                return height;
            }
        }

        /// <summary>
        /// Gets width of the media source.
        /// </summary>
        /// <code>
        /// 
        /// </code>
        public uint Width
        {
            get
            {
                uint width = 0;
                MediaVisionError ret = (MediaVisionError)Interop.MediaVision.MediaSource.GetWidth(_sourceHandle, out width);
                if (ret != MediaVisionError.None)
                {
                    Log.Error(MediaVisionLog.Tag, "[{0}] : Failed to get width", ret.ToString());
                }

                return width;
            }
        }

        /// <summary>
        /// Gets colorspace of the media source.
        /// </summary>
        /// <code>
        /// 
        /// </code>
        public Colorspace Colorspace
        {
            get
            {
                Colorspace colorspace = Colorspace.Invalid;
                MediaVisionError ret = (MediaVisionError)Interop.MediaVision.MediaSource.GetColorspace(_sourceHandle, out colorspace);
                if (ret != MediaVisionError.None)
                {
                    Log.Error(MediaVisionLog.Tag, "[{0}] : Failed to get colorspace", ret.ToString());
                }

                return colorspace;
            }
        }

        /// <summary>
        /// Fills the media source based on the media packet.
        /// </summary>
        /// <param name="mediaPacket">The media packet from which the source will be filled</param>
        /// <code>
        /// 
        /// </code>
        /*public void FillMediaPacket(BaseMediaPacket mediaPacket)
        {
            int ret = Interop.MediaVision.MediaSource.FillBuffer(out _sourceHandle, mediaPacket._mediaPacketHandle);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to fill media packet");
        }*/

        /// <summary>
        /// Fills the media source based on the buffer and metadata.
        /// </summary>
        /// <param name="buffer">The buffer of image data</param>
        /// <param name="width">The width of image data</param>
        /// <param name="height">The height of image data</param>
        /// <param name="colorspace">The image colorspace</param>
        /// <seealso cref="Clear()"/>
        /// <code>
        /// 
        /// </code>
        public void FillBuffer(byte[] buffer, uint width, uint height, Colorspace colorspace)
        {
            int ret = Interop.MediaVision.MediaSource.FillBuffer(_sourceHandle, buffer, buffer.Length, width, height, colorspace);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to fill buffer");
        }

        /// <summary>
        /// Clears the buffer of the media source.
        /// </summary>
        /// <seealso cref="FillBuffer()"/>
        /// <code>
        /// 
        /// </code>
        public void Clear()
        {
            int ret = Interop.MediaVision.MediaSource.Clear(_sourceHandle);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to clear media source buffer");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // Free managed objects
            }

            Interop.MediaVision.MediaSource.Destroy(_sourceHandle);
            _disposed = true;
        }
    }
}
