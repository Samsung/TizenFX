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
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Tizen.Network.Mtp
{
    /// <summary>
    /// A class for Mtp Object information. It allows applications to handle object information.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class MtpObject : IDisposable
    {
        private int _deviceHandle = -1;
        private int _objectHandle = -1;
        private bool disposed = false;

        /// <summary>
        /// Gets the filename of the object information.
        /// </summary>
        /// <value>File name of object.</value>
        /// <since_tizen> 4 </since_tizen>
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
        /// Gets the keywords of the object information.
        /// </summary>
        /// <value>Keywords of object.</value>
        /// <since_tizen> 4 </since_tizen>
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
        /// Gets the association description of the object information.
        /// </summary>
        /// <value>Association description of object.</value>
        /// <since_tizen> 4 </since_tizen>
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
        /// Gets the association type of the object information.
        /// </summary>
        /// <value>Association type of object.</value>
        /// <since_tizen> 4 </since_tizen>
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
        /// Gets the size of the object information.
        /// </summary>
        /// <value>Size of object.</value>
        /// <since_tizen> 4 </since_tizen>
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
        /// Gets the parent object handle of the object information.
        /// </summary>
        /// <value>Handle of Parent object.</value>
        /// <since_tizen> 4 </since_tizen>
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
        ///  Gets the mtp storage of the object information.
        /// </summary>
        /// <value>Storage of object.</value>
        /// <since_tizen> 4 </since_tizen>
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
        /// Gets the object created time of the object information.
        /// </summary>
        /// <value>Date created of object.</value>
        /// <since_tizen> 4 </since_tizen>
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
        /// Gets the object modified time of the object information.
        /// </summary>
        /// <value>Date modified of object.</value>
        /// <since_tizen> 4 </since_tizen>
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
        /// Gets the file type of the object information.
        /// </summary>
        /// <value>File type of object.</value>
        /// <since_tizen> 4 </since_tizen>
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
        /// Gets the image bit depth of the object information.
        /// </summary>
        /// <value>Bit depth of image.</value>
        /// <since_tizen> 4 </since_tizen>
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
        /// Gets the image pixel width of the object information.
        /// </summary>
        /// <value>Pixel width of image.</value>
        /// <since_tizen> 4 </since_tizen>
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
        /// Gets the image pixel height of the object information.
        /// </summary>
        /// <value>Pixel height of image.</value>
        /// <since_tizen> 4 </since_tizen>
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
        /// Gets the thumbnail size of the object information.
        /// </summary>
        /// <value>Size of thumbnail.</value>
        /// <since_tizen> 4 </since_tizen>
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
        /// Gets the thumbnail file type of the object information.
        /// </summary>
        /// <value>File type of thumbnail.</value>
        /// <since_tizen> 4 </since_tizen>
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
        /// Gets the thumbnail pixel width of the object information.
        /// </summary>
        /// <value>Pixel width of thumbnail.</value>
        /// <since_tizen> 4 </since_tizen>
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
        /// Gets the thumbnail pixel height of the object information.
        /// </summary>
        /// <value>Pixel height of thumbnail.</value>
        /// <since_tizen> 4 </since_tizen>
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

        /// <summary>
        /// MtpObject destructor.
        /// </summary>
        ~MtpObject()
        {
            Dispose(false);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
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

        internal int GetHandle()
        {
            return _objectHandle;
        }
    }
}
