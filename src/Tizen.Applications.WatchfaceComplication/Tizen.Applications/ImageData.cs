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
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.WatchfaceComplication.Tizen.Applications
{
    class ImageData : ComplicationData
    {
        /// <summary>
        /// Initializes the IconData class.
        /// </summary>
        /// <param name="imagePath">The image path.</param>
        /// <param name="extraData">The extra data.</param>
        /// <exception cref="ArgumentException">Thrown when parameter is invalid.</exception>
        /// <example>
        /// <code>
        ///     protected override ComplicationData OnDataUpdateRequested(string reqestAppId, ComplicationTypes type, Bundle contextData)
        ///     {
        ///         if (type == ComplicationTypes.Image)
        ///         {
        ///             return new ImageData("Image path", "extra");
        ///         }
        ///         else if (type == ComplicationTypes.LongText)
        ///         {
        ///             return new LongTextData("longlong", "icon path", "title", null);
        ///         }
        ///     }
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public ImageData(string imagePath, string extraData)
        {
            if (imagePath == null)
                ErrorFactory.ThrowException(ComplicationError.InvalidParam, "image path can not be null");
            base.ImagePath = imagePath;
            base.ExtraData = extraData;
        }

        /// <summary>
        /// The iamge path data.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when try to set invalid value.</exception>
        /// <since_tizen> 6 </since_tizen>
        public string ImagePath
        {
            get
            {
                return base.ImagePath;
            }
            set
            {
                if (value == null)
                    ErrorFactory.ThrowException(ComplicationError.InvalidParam, "image path can not be null");
                base.ImagePath = value;
            }
        }

        /// <summary>
        /// The extra data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public new string ExtraData
        {
            get
            {
                return base.ExtraData;
            }
            set
            {
                base.ExtraData = value;
            }
        }

        /// <summary>
        /// The information about the screen reader text of complication data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public new string ScreenReaderText
        {
            get
            {
                return base.ScreenReaderText;
            }
            set
            {
                base.ScreenReaderText = value;
            }
        }
    }
}
