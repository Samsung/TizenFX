/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// It is a class for hit test result of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebHitTestResult : Disposable
    {
        internal WebHitTestResult(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will not be public opened.
        /// <param name="swigCPtr"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.WebHitTest.DeleteWebHitTest(swigCPtr);
        }

        /// <summary>
        /// Enumeration for context of hit test result.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ResultContext
        {
            /// <summary>
            /// Anywhere in the document.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Document = 1 << 1,

            /// <summary>
            /// A hyperlink element.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Link = 1 << 2,

            /// <summary>
            /// An image element.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Image = 1 << 3,

            /// <summary>
            /// a video or audio element.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Media = 1 << 4,

            /// <summary>
            /// The area which is selected.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Selection = 1 << 5,

            /// <summary>
            /// The area which is editable
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Editable = 1 << 6,

            /// <summary>
            /// the area which is text
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Text = 1 << 7,
        }

        /// <summary>
        /// Gets the context of the hit test.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResultContext TestResultContext
        {
            get
            {
                return (ResultContext)Interop.WebHitTest.GetResultContext(SwigCPtr);
            }
        }

        /// <summary>
        /// Gets the link url of the hit test.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string LinkUrl
        {
            get
            {
                return Interop.WebHitTest.GetLinkUri(SwigCPtr);
            }
        }

        /// <summary>
        /// Gets the link title of the hit test.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string LinkTitle
        {
            get
            {
                return Interop.WebHitTest.GetLinkTitle(SwigCPtr);
            }
        }

        /// <summary>
        /// Gets the link label of the hit test.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string LinkLabel
        {
            get
            {
                return Interop.WebHitTest.GetLinkLabel(SwigCPtr);
            }
        }

        /// <summary>
        /// Gets the image url of the hit test.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ImageUrl
        {
            get
            {
                return Interop.WebHitTest.GetImageUri(SwigCPtr);
            }
        }

        /// <summary>
        /// Gets the media url of the hit test.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MediaUrl
        {
            get
            {
                return Interop.WebHitTest.GetMediaUri(SwigCPtr);
            }
        }

        /// <summary>
        /// Gets the tag name of hit element of the hit test.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string TagName
        {
            get
            {
                return Interop.WebHitTest.GetTagName(SwigCPtr);
            }
        }

        /// <summary>
        /// Gets the node value of hit element of the hit test.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string NodeValue
        {
            get
            {
                return Interop.WebHitTest.GetNodeValue(SwigCPtr);
            }
        }

        /// <summary>
        /// Gets the attributes of hit element of the hit test.
        /// The attributes include the standard W3C HTML attributes.
        /// For example, if <img src="img_girl.jpg" /> is hit,
        /// key 'src', value 'img_girl.jpg' would be stored in the map.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap Attributes
        {
            get
            {
                IntPtr arributesIntPtr = Interop.WebHitTest.GetAttributes(SwigCPtr);
                return new PropertyMap(arributesIntPtr, true);
            }
        }

        /// <summary>
        /// Gets the image file name extension of hit element of the hit test.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ImageFileNameExtension
        {
            get
            {
                return Interop.WebHitTest.GetImageFileNameExtension(SwigCPtr);
            }
        }

        /// <summary>
        /// Gets the image of hit element of the hit test.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageView Image
        {
            get
            {
                IntPtr bufferIntPtr = Interop.WebHitTest.GetImageBuffer(SwigCPtr);
                PixelData pixelData = new PixelData(bufferIntPtr, true);
                ImageView image = new ImageView(pixelData.Url);
                image.Size = new Size(pixelData.GetWidth(), pixelData.GetHeight());
                pixelData.Dispose();
                return image;
            }
        }
    }
}
