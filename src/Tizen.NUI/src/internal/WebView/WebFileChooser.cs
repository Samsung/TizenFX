/*
 * Copyright (c) 2025 Samsung Electronics Co., Ltd.
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
 *
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// It is a class for file chooser of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebFileChooser : Disposable
    {
        internal WebFileChooser(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will not be public opened.
        /// <param name="swigCPtr"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.WebFileChooser.DeleteWebFileChooserRequest(swigCPtr);
        }

        /// <summary>
        /// Check if it is allowed to select multiple files or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool MultipleFilesAllowed
        {
            get
            {
                return Interop.WebFileChooser.MultipleFilesAllowed(SwigCPtr);
            }
        }

        /// <summary>
        /// Queries the list of accepted MIME types.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<string> AcceptedMimetypes
        {
            get
            {
                List<string> mimetypes = new List<string>();
                IntPtr listIntPtr = Interop.WebFileChooser.AcceptedMimetypes(SwigCPtr);
                System.Runtime.InteropServices.HandleRef listHandleRef = new System.Runtime.InteropServices.HandleRef(listIntPtr == IntPtr.Zero ? null : this, listIntPtr);
                uint count = Interop.WebFileChooser.AcceptedMimetypesCount(listHandleRef);
                for (uint i = 0; i < count; i++)
                {
                    string mimetype = Interop.WebFileChooser.AcceptedMimetypesGetItem(listHandleRef, i);
                    mimetypes.Add(mimetype);
                }
                Interop.WebFileChooser.DeleteAcceptedMimetypes(listHandleRef);
                return mimetypes;
            }
        }

        /// <summary>
        /// Cancels the file chooser.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Cancel()
        {
            return Interop.WebFileChooser.Cancel(SwigCPtr);
        }

        /// <summary>
        /// Chooses the files list.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ChooseFiles(string[] files)
        {
            if (files == null)
                throw new ArgumentNullException(nameof(files), "File list is null.");
            return Interop.WebFileChooser.ChooseFiles(SwigCPtr, files, (uint)files.Length);
        }

        /// <summary>
        /// Chooses a file.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ChooseFile(string file)
        {
            return Interop.WebFileChooser.ChooseFile(SwigCPtr, file);
        }
    }
}
