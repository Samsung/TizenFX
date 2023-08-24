/* 
* Copyright(c) 2021 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.BaseComponents.VectorGraphics
{
    /// <summary>
    /// A class representing an image read in one of the supported formats: raw, svg, png and etc.
    /// Besides the methods inherited from the Drawable, it provides methods to load and draw images on the canvas.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class Picture : Drawable
    {
        /// <summary>
        /// Creates an initialized Picture.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Picture() : this(Interop.Picture.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Picture(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Loads a picture data directly from a file.
        /// </summary>
        /// <param name="url">A path to the picture file.</param>
        /// <exception cref="ArgumentNullException"> Thrown when url is null. </exception>
        /// <exception cref="Exception"> Thrown when image load fail. </exception>
        /// <since_tizen> 9 </since_tizen>
        public void Load(string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }
            bool ret = Interop.Picture.Load(View.getCPtr(this), url);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            if (!ret)
            {
                throw new Exception("Image load fail : " + url);
            }
        }

        /// <summary>
        /// Resize the picture content with the given size.
        /// 
        /// Resize the picture content while keeping the default size aspect ratio.
        /// The scaling factor is established for each of dimensions and the smaller value is applied to both of them.
        /// </summary>
        /// <param name="size">A new size of the image in pixels</param>
        /// <exception cref="ArgumentNullException"> Thrown when size is null. </exception>
        /// <since_tizen> 9 </since_tizen>
        public void SetSize(Size2D size)
        {
            if (size == null)
            {
                throw new ArgumentNullException(nameof(size));
            }
            Interop.Picture.SetSize(View.getCPtr(this), Size2D.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the size of the image.
        /// </summary>
        /// <returns> The size of the image in pixels.</returns>
        /// <since_tizen> 9 </since_tizen>
        public Size2D GetSize()
        {
            global::System.IntPtr cPtr = Interop.Picture.GetSize(View.getCPtr(this));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return Size2D.GetSize2DFromPtr(cPtr);
        }
    }
}
