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
        TYPE = 0,
        ITEM_SIZE,
        ORIENTATION,
        GRID_COLUMN_NUMBER,
        GRID_ROW_SPACING,
        GRID_COLUMN_SPACING,
        GRID_TOP_MARGIN,
        GRID_BOTTOM_MARGIN,
        GRID_SIDE_MARGIN,
        GRID_SCROLL_SPEED_FACTOR,
        GRID_MAXIMUM_SWIPE_SPEED,
        GRID_ITEM_FLICK_ANIMATION_DURATION,
        DEPTH_COLUMN_NUMBER,
        DEPTH_ROW_NUMBER,
        DEPTH_ROW_SPACING,
        DEPTH_SCROLL_SPEED_FACTOR,
        DEPTH_MAXIMUM_SWIPE_SPEED,
        DEPTH_ITEM_FLICK_ANIMATION_DURATION,
        DEPTH_TILT_ANGLE,
        DEPTH_ITEM_TILT_ANGLE,
        SPIRAL_ITEM_SPACING,
        SPIRAL_SCROLL_SPEED_FACTOR,
        SPIRAL_MAXIMUM_SWIPE_SPEED,
        SPIRAL_ITEM_FLICK_ANIMATION_DURATION,
        SPIRAL_REVOLUTION_DISTANCE,
        SPIRAL_TOP_ITEM_ALIGNMENT
    }

}
