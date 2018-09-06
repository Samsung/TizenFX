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
using System.Diagnostics;
using static Interop;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Represents properties for the relative ROI area based on video size
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public struct ScaleRectangle
    {
        /// <summary>
        /// Initializes a new instance of the struct with the specified field of view for the spherical video.
        /// </summary>
        /// <param name="scaleX">The ratio expressed as a decimal of x coordinate to the video width. (x/video width)
        /// x coordinate means the base point located lower-left corner of the video area.
        /// valid range is [0, 1]. Default value is 0.</param>
        /// <param name="scaleY">The ratio expressed as a decimal of y coordinate to the video height. (y/video height)
        /// y coordinate means the base point located lower-left corner of the video area.
        /// valid range is [0, 1]. Default value is 0.</param>
        /// <param name="scaleWidth">The ratio expressed as a decimal of ROI width to the video width. (ROI width/video width)
        /// valid range is (0, 1]. Default value is 1.</param>
        /// <param name="scaleHeight">The ratio expressed as a decimal of ROI height to the video height. (ROI height/video height)
        /// valid range is (0, 1]. Default value is 1.</param>
        /// <since_tizen> 5 </since_tizen>
        public ScaleRectangle(double scaleX, double scaleY, double scaleWidth, double scaleHeight)
        {
            ScaleX = scaleX;
            ScaleY = scaleY;
            ScaleWidth = scaleWidth;
            ScaleHeight = scaleHeight;

            Log.Debug(PlayerLog.Tag, $"scaleX={scaleX}, scaleY={scaleY}, scaleWidth={scaleWidth}, scaleHeight={scaleHeight}");
        }

        /// <summary>
        /// Gets or sets the ScaleX.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public double ScaleX
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ScaleY.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public double ScaleY
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ScaleWidth.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public double ScaleWidth
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ScaleHeight.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public double ScaleHeight
        {
            get;
            set;
        }
    }
}
