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

namespace Tizen.Maps
{
    /// <summary>
    /// Enumeration of user gestures over map view
    /// </summary>
    /// <since_tizen>3</since_tizen>
    public enum GestureType
    {
        /// <summary>
        /// Indicates empty gesture.
        /// </summary>
        None = Interop.ViewGesture.None,
        /// <summary>
        /// Indicates the move map user gesture.
        /// </summary>
        Scroll = Interop.ViewGesture.Scroll,
        /// <summary>
        /// Indicates the zoom user gesture.
        /// </summary>
        Zoom = Interop.ViewGesture.Zoom,
        /// <summary>
        /// Indicates the click user gesture
        /// </summary>
        Click = Interop.ViewGesture.Click,
        /// <summary>
        /// Indicates the double click user gesture
        /// </summary>
        DoubleClick = Interop.ViewGesture.DoubleClick,
        /// <summary>
        /// Indicates the two-finger click user gesture
        /// </summary>
        TwoFingerClick = Interop.ViewGesture.TwoFingerClick,
        /// <summary>
        ///  Indicates the rotation user gesture.
        /// </summary>
        Rotation = Interop.ViewGesture.Rotation,
        /// <summary>
        /// Indicates the long press user gesture.
        /// </summary>
        LongPress = Interop.ViewGesture.LongPress,
    }
}
