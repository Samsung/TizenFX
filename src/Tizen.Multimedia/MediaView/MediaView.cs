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
using ElmSharp;

namespace Tizen.Multimedia
{
    /// <summary>
    /// The MediaView class allows application developers to display the video output on the screen.
    /// </summary>
    /// <remarks>
    /// This view should not be instantiated directly.\n
    /// Use <see cref="T:Tizen.Xamarin.Forms.Extension.MediaView"/> to create the view.
    /// </remarks>
    /// <example>
    /// <code>
    /// Tizen.Xamarin.Forms.Extension.MediaView mediaView = ...
    /// ...
    /// var display = new Display((Tizen.Multimedia.MediaView)mediaView.NativeView);
    /// </code>
    /// </example>
    public class MediaView : EvasObject
    {
        /// <summary>
        /// This constructor is used by the infrastructure and is not intended to be used directly from application code.
        /// </summary>
        public MediaView(EvasObject parent) : base(parent)
        {
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr evas = Interop.EvasObject.evas_object_evas_get(parent);
            return Interop.EvasObject.evas_object_image_add(evas);
        }
    }
}

