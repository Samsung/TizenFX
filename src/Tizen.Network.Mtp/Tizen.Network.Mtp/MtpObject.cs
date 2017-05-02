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
using System.Collections.Generic;

namespace Tizen.Network.Mtp
{
    /// <summary>
    /// A class for Mtp Object informations. It allows applications to handle object informations.
    /// </summary>
    public class MtpObject : IDisposable
    {
        private int _deviceHandle = -1;
        private int _objectHandle = -1;
        private bool disposed = false;

        /// <summary>
        /// The file name.
        /// </summary>
        public string FileName
        {
            get
            {
                IntPtr strPtr;
                int ret = Interop.Mtp.ObjectInformation.GetFileName(_deviceHandle, _objectHandle, out strPtr);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get file name, Error - " + (MtpError)ret);
                    return "";
                }
                return Marshal.PtrToStringAnsi(strPtr);
            }
        }

        /// <summary>
        /// The keywords.
        /// </summary>
        public string Keywords
        {
            get
            {
                IntPtr strPtr;
                int ret = Interop.Mtp.ObjectInformation.GetKeywords(_deviceHandle, _objectHandle, out strPtr);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get keywords, Error - " + (MtpError)ret);
                    return "";
                }
                return Marshal.PtrToStringAnsi(strPtr);
            }
        }

        /// <summary>
        /// The association description.
        /// </summary>
        public int AssociationDescription
        {
            get
            {
                int value;
                int ret = Interop.Mtp.ObjectInformation.GetAssociationDescription(_deviceHandle, _objectHandle, out value);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get association decription, Error - " + (MtpError)ret);
                }
                return value;
            }
        }

        /// <summary>
        /// The association type.
        /// </summary>
        public int AssociationType
        {
            get
            {
                int value;
                int ret = Interop.Mtp.ObjectInformation.GetAssociationType(_deviceHandle, _objectHandle, out value);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get association type, Error - " + (MtpError)ret);
                }
                return value;
            }
        }

        /// <summary>
        /// The size.
        /// </summary>
        public int Size
        {
            get
            {
                int value;
                int ret = Interop.Mtp.ObjectInformation.GetSize(_deviceHandle, _objectHandle, out value);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get size, Error - " + (MtpError)ret);
                }
                return value;
            }
        }

        /// <summary>
        //TODO /// The parent object handle.
        /// </summary>
        public int ParentObjectHandle
        {
            get
            {
                int value;
                int ret = Interop.Mtp.ObjectInformation.GetParentObjectHandle(_deviceHandle, _objectHandle, out value);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get parent object handle, Error - " + (MtpError)ret);
                }
                return value;
            }
        }

        /// <summary>
        //TODO /// The storage.
        /// </summary>
        public int Storage
        {
            get
            {
                int value;
                int ret = Interop.Mtp.ObjectInformation.GetStorage(_deviceHandle, _objectHandle, out value);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get storage, Error - " + (MtpError)ret);
                }
                return value;
            }
        }

        /// <summary>
        /// The date created
        /// </summary>
        public int DateCreated
        {
            get
            {
                int value;
                int ret = Interop.Mtp.ObjectInformation.GetDateCreated(_deviceHandle, _objectHandle, out value);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get date created, Error - " + (MtpError)ret);
                }
                return value;
            }
        }

        /// <summary>
        /// The date modified.
        /// </summary>
        public int DateModified
        {
            get
            {
                int value;
                int ret = Interop.Mtp.ObjectInformation.GetDateModified(_deviceHandle, _objectHandle, out value);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get date modified, Error - " + (MtpError)ret);
                }
                return value;
            }
        }

        /// <summary>
        /// The file type.
        /// </summary>
        public MtpFileType FileType
        {
            get
            {
                int value;
                int ret = Interop.Mtp.ObjectInformation.GetStorage(_deviceHandle, _objectHandle, out value);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get file type, Error - " + (MtpError)ret);
                }
                return (MtpFileType)value;
            }
        }

        /// <summary>
        /// The image bit depth.
        /// </summary>
        public int ImageBitDepth
        {
            get
            {
                int value;
                int ret = Interop.Mtp.ObjectInformation.GetImageBitDepth(_deviceHandle, _objectHandle, out value);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get image bit depth, Error - " + (MtpError)ret);
                }
                return value;
            }
        }

        /// <summary>
        /// The image pixel width.
        /// </summary>
        public int ImagePixelWidth
        {
            get
            {
                int value;
                int ret = Interop.Mtp.ObjectInformation.GetImagePixWidth(_deviceHandle, _objectHandle, out value);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get image pixel width, Error - " + (MtpError)ret);
                }
                return value;
            }
        }

        /// <summary>
        /// The image pixel height.
        /// </summary>
        public int ImagePixelHeight
        {
            get
            {
                int value;
                int ret = Interop.Mtp.ObjectInformation.GetImagePixHeight(_deviceHandle, _objectHandle, out value);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get image pixel height, Error - " + (MtpError)ret);
                }
                return value;
            }
        }

        /// <summary>
        /// The thumbnail size.
        /// </summary>
        public int ThumbnailSize
        {
            get
            {
                int value;
                int ret = Interop.Mtp.ObjectInformation.GetThumbnailSize(_deviceHandle, _objectHandle, out value);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get thumbnail size, Error - " + (MtpError)ret);
                }
                return value;
            }
        }

        /// <summary>
        /// The thumbnail file type.
        /// </summary>
        public int ThumbnailFileType
        {
            get
            {
                int value;
                int ret = Interop.Mtp.ObjectInformation.GetThumbnailFileType(_deviceHandle, _objectHandle, out value);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get thumbnail file type, Error - " + (MtpError)ret);
                }
                return value;
            }
        }

        /// <summary>
        /// The thumbnail pixel width.
        /// </summary>
        public int ThumbnailPixelWidth
        {
            get
            {
                int value;
                int ret = Interop.Mtp.ObjectInformation.GetThumbnailPixWidth(_deviceHandle, _objectHandle, out value);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get thumbnail pixel width, Error - " + (MtpError)ret);
                }
                return value;
            }
        }

        /// <summary>
        /// The thumbnail pixel height.
        /// </summary>
        public int ThumbnailPixelHeight
        {
            get
            {
                int value;
                int ret = Interop.Mtp.ObjectInformation.GetThumbnailPixHeight(_deviceHandle, _objectHandle, out value);
                if (ret != (int)MtpError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get thumbnail pixel height, Error - " + (MtpError)ret);
                }
                return value;
            }
        }

        internal MtpObject(int deviceHandle, int objectHandle)
        {
            _deviceHandle = deviceHandle;
            _objectHandle = objectHandle;
        }

        ~MtpObject()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free managed objects.
            }
            //Free unmanaged objects
            disposed = true;
        }

    }
}
