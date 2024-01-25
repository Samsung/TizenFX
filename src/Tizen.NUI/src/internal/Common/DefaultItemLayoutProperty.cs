/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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

using System.ComponentModel;

namespace Tizen.NUI
{
    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum DefaultItemLayoutProperty
    {
        /// <summary>
        /// The type of the Layout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        TYPE = 0,

        /// <summary>
        /// The size of each item in the Layout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        ITEM_SIZE,

        /// <summary>
        /// The internal orientation of the Layout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        ORIENTATION,

        /// <summary>
        /// The number of columns in the GridLayout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        GRID_COLUMN_NUMBER,

        /// <summary>
        /// The spacing between rows in the GridLayout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        GRID_ROW_SPACING,

        /// <summary>
        /// The spacing between columns in the GridLayout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        GRID_COLUMN_SPACING,

        /// <summary>
        /// The margin in the top of the GridLayout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        GRID_TOP_MARGIN,

        /// <summary>
        /// The margin in the bottom of the GridLayout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        GRID_BOTTOM_MARGIN,

        /// <summary>
        /// The margin in the left and right of the GridLayout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        GRID_SIDE_MARGIN,

        /// <summary>
        /// The factor used to customise the scroll speed while dragging and swiping the GridLayout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        GRID_SCROLL_SPEED_FACTOR,

        /// <summary>
        /// The maximum swipe speed in pixels per second of GridLayout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        GRID_MAXIMUM_SWIPE_SPEED,

        /// <summary>
        /// The duration of the flick animation in seconds of GridLayout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        GRID_ITEM_FLICK_ANIMATION_DURATION,

        /// <summary>
        /// The number of columns in the DepthLayout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        DEPTH_COLUMN_NUMBER,

        /// <summary>
        /// The number of rows in the DepthLayout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        DEPTH_ROW_NUMBER,

        /// <summary>
        /// The spacing between rows in the DepthLayout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        DEPTH_ROW_SPACING,

        /// <summary>
        /// The factor used to customise the scroll speed while dragging and swiping the  DepthLayout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        DEPTH_SCROLL_SPEED_FACTOR,

        /// <summary>
        /// The maximumSwipSpeed of the DepthLayout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        DEPTH_MAXIMUM_SWIPE_SPEED,

        /// <summary>
        /// The duration of the flick animation in seconds of DepthLayout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        DEPTH_ITEM_FLICK_ANIMATION_DURATION,

        /// <summary>
        /// The tilt angle of DepthLayout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        DEPTH_TILT_ANGLE,

        /// <summary>
        /// The tilt angle of the individual items in the DepthLayout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        DEPTH_ITEM_TILT_ANGLE,

        /// <summary>
        /// The spacing angle between items in the SpiralLayout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        SPIRAL_ITEM_SPACING,

        /// <summary>
        /// The factor used to customise the scroll speed while dragging and swiping the SpiralLayout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        SPIRAL_SCROLL_SPEED_FACTOR,

        /// <summary>
        /// The maximum swipe speed in pixels per second of the SpiralLayout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        SPIRAL_MAXIMUM_SWIPE_SPEED,

        /// <summary>
        /// The duration of the flick animation in seconds of the SpiralLayout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        SPIRAL_ITEM_FLICK_ANIMATION_DURATION,

        /// <summary>
        /// The vertical distance for one revolution of the SpiralLayout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        SPIRAL_REVOLUTION_DISTANCE,

        /// <summary>
        /// The alignment of the top-item, when at the beginning of the SpiralLayout.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        SPIRAL_TOP_ITEM_ALIGNMENT
    }
}
