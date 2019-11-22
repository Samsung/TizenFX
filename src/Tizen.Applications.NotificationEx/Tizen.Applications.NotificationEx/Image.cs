/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        /// <summary>
        /// The Image class.
        /// Using this class, developers are able to create notification items which display an image.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public class Image : AbstractItem
        {
            /// <summary>
            /// Initializes Image class.
            /// </summary>
            /// <param name="id"> An ID of the Image item. </param>
            /// <param name="imagePath"> An image path of the Image item. </param>
            /// <since_tizen> 7 </since_tizen>
            public Image(string id, string imagePath) : base(((Func<IntPtr>)(delegate ()
            {
                IntPtr handle;
                ErrorCode err = Interop.NotificationEx.ImageCreate(out handle, id, imagePath);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return handle;
            }))())
            {
            }

            internal Image(IntPtr ptr) : base(ptr)
            {
            }

            /// <summary>
            /// An image path.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public string Path
            {
                get
                {
                    string imagePath;
                    Interop.NotificationEx.ImageGetImagePath(NativeHandle, out imagePath);
                    return imagePath;
                }
            }
        }
    }
}
