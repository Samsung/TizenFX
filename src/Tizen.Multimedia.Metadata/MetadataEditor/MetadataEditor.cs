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

namespace Tizen.Multimedia
{
    static internal class MetadataEditorLog
    {
        internal const string LogTag = "Tizen.Multimedia.MetadataEditor";
    }

    /// <summary>
    /// The Metadata editor class provides a set of functions to edit the metadata of the media file
    /// </summary>
    /// <privilege>
    /// If you want to access only internal storage,
    /// you should add privilege http://tizen.org/privilege/mediastorage. \n
    /// Or if you want to access only external storage,
    /// you should add privilege http://tizen.org/privilege/externalstorage. \n
    /// </privilege>
    public class MetadataEditor : IDisposable
    {
        private bool _disposed = false;
        private IntPtr _handle = IntPtr.Zero;

        private IntPtr MetadataHandle
        {
            get
            {
                if (_handle == IntPtr.Zero)
                {
                    throw new ObjectDisposedException(nameof(MetadataEditor));
                }

                return _handle;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetadataEditor"/> class with the specified path.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="path"> The path of the media file to edit metadata </param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is null.</exception>
        /// <exception cref="NotSupportedException">The file is unsupported format.</exception>
        /// <exception cref="System.IO.FileNotFoundException">The file does not exist.</exception>
        public MetadataEditor(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            MetadataEditorError ret = Interop.MetadataEditor.Create(out _handle);
            MetadataEditorErrorFactory.ThrowIfError(ret, "Failed to create metadata");

            try
            {
                MetadataEditorErrorFactory.ThrowIfError(
                    Interop.MetadataEditor.SetPath(MetadataHandle, path), "Failed to set path");
            }
            catch (Exception)
            {
                Interop.MetadataEditor.Destroy(_handle);
                _handle = IntPtr.Zero;
                throw;
            }
        }

        private string GetParam(MetadataEditorAttr attr)
        {
            IntPtr val = IntPtr.Zero;

            try
            {
                MetadataEditorError e = Interop.MetadataEditor.GetMetadata(MetadataHandle, attr, out val);
                MetadataEditorErrorFactory.ThrowIfError(e, "Failed to get metadata");

                return Marshal.PtrToStringAnsi(val);
            }
            finally
            {
                Interop.Libc.Free(val);
            }
        }

        private void SetParam(MetadataEditorAttr attr, string value)
        {
            MetadataEditorErrorFactory.ThrowIfError(
                    Interop.MetadataEditor.SetMetadata(MetadataHandle, attr, value), "Fail to set value");
        }

        /// <summary>
        /// Artist of media
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Artist
        {
            get
            {
                return GetParam(MetadataEditorAttr.Artist);
            }

            set
            {
                SetParam(MetadataEditorAttr.Artist, value);
            }
        }

        /// <summary>
        /// Title of media
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Title
        {
            get
            {
                return GetParam(MetadataEditorAttr.Title);
            }

            set
            {
                SetParam(MetadataEditorAttr.Title, value);
            }
        }

        /// <summary>
        /// Album name of media
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Album
        {
            get
            {
                return GetParam(MetadataEditorAttr.Album);
            }

            set
            {
                SetParam(MetadataEditorAttr.Album, value);
            }
        }

        /// <summary>
        /// Genre of media
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Genre
        {
            get
            {
                return GetParam(MetadataEditorAttr.Genre);
            }

            set
            {
                SetParam(MetadataEditorAttr.Genre, value);
            }
        }

        /// <summary>
        /// Author of media
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Author
        {
            get
            {
                return GetParam(MetadataEditorAttr.Author);
            }

            set
            {
                SetParam(MetadataEditorAttr.Author, value);
            }
        }

        /// <summary>
        /// Copyright of media
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Copyright
        {
            get
            {
                return GetParam(MetadataEditorAttr.Copyright);
            }

            set
            {
                SetParam(MetadataEditorAttr.Copyright, value);
            }
        }

        /// <summary>
        /// Date of media
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// If the added media contains ID3 tag, This parameter refers to the recording time.
        /// If the added media is a mp4 format, This parameter refers to the year.
        /// </remarks>
        public string Date
        {
            get
            {
                return GetParam(MetadataEditorAttr.Date);
            }

            set
            {
                SetParam(MetadataEditorAttr.Date, value);
            }
        }

        /// <summary>
        /// Description of media
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Description
        {
            get
            {
                return GetParam(MetadataEditorAttr.Description);
            }

            set
            {
                SetParam(MetadataEditorAttr.Description, value);
            }
        }

        /// <summary>
        /// Comment of media
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Comment
        {
            get
            {
                return GetParam(MetadataEditorAttr.Comment);
            }

            set
            {
                SetParam(MetadataEditorAttr.Comment, value);
            }
        }

        /// <summary>
        /// Track number of media
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string TrackNumber
        {
            get
            {
                return GetParam(MetadataEditorAttr.TrackNumber);
            }

            set
            {
                SetParam(MetadataEditorAttr.TrackNumber, value);
            }
        }

        /// <summary>
        /// Album art count of media
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string PictureCount
        {
            get
            {
                return GetParam(MetadataEditorAttr.PictureCount);
            }
        }

        /// <summary>
        /// Conductor of media
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Conductor
        {
            get
            {
                return GetParam(MetadataEditorAttr.Conductor);
            }

            set
            {
                SetParam(MetadataEditorAttr.Conductor, value);
            }
        }

        /// <summary>
        /// Unsynchronized lyric of media
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string UnsyncLyrics
        {
            get
            {
                return GetParam(MetadataEditorAttr.UnsyncLyrics);
            }

            set
            {
                SetParam(MetadataEditorAttr.UnsyncLyrics, value);
            }
        }

        /// <summary>
        /// Writes the modified metadata to a media file
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException"> When internal process error is occured</exception>
        public void Commit()
        {
            MetadataEditorErrorFactory.ThrowIfError(
                Interop.MetadataEditor.UpdateMetadata(MetadataHandle), "Failed to update file");
        }

        /// <summary>
        /// Gets the artwork image in a media file
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="index"> Index of picture to import </param>
        /// <returns> Artwork included in the media file</returns>
        /// <exception cref="InvalidOperationException"> When internal process error is occured</exception>
        /// <exception cref="ArgumentOutOfRangeException"> Wrong index number </exception>
        public Artwork GetPicture(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Index should be larger than 0 [" + index + "]");
            }

            IntPtr data = IntPtr.Zero;
            int size;
            IntPtr mimeType = IntPtr.Zero;

            try
            {
                MetadataEditorErrorFactory.ThrowIfError(
                    Interop.MetadataEditor.GetPicture(MetadataHandle, index, out data, out size, out mimeType), "Failed to get the value");

                if (size > 0)
                {
                    byte[] tmpBuf = new byte[size];
                    Marshal.Copy(data, tmpBuf, 0, size);

                    return new Artwork(tmpBuf, Marshal.PtrToStringAnsi(mimeType));
                }

                return null;
            }
            finally
            {
                if (data != IntPtr.Zero)
                {
                    Interop.Libc.Free(data);
                }

                if (mimeType != IntPtr.Zero)
                {
                    Interop.Libc.Free(mimeType);
                }
            }
        }

        /// <summary>
        /// Appends the picture to the media file.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="path">The path of picture for adding to the metadata.</param>
        /// <exception cref="InvalidOperationException">Internal error occurs.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is null.</exception>
        public void AddPicture(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            MetadataEditorErrorFactory.ThrowIfError(
                Interop.MetadataEditor.AddPicture(MetadataHandle, path), "Failed to append picture");
        }

        /// <summary>
        /// Removes the picture from the media file.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="index"> Index of picture to remove </param>
        /// <exception cref="InvalidOperationException"> When internal process error is occured</exception>
        /// <exception cref="ArgumentOutOfRangeException"> Wrong index number </exception>
        public void RemovePicture(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Index should be larger than 0 [" + index + "]");
            }

            MetadataEditorErrorFactory.ThrowIfError(
                Interop.MetadataEditor.RemovePicture(MetadataHandle, index), "Failed to remove picture");
        }

        /// <summary>
        /// Metadata Editor destructor
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        ~MetadataEditor()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // To be used if there are any other disposable objects
                }

                if (_handle != IntPtr.Zero)
                {
                    Interop.MetadataEditor.Destroy(_handle);
                    _handle = IntPtr.Zero;
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
