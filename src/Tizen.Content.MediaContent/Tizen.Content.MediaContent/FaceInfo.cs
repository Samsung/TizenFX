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

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// Represents the face information for the media.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    //[Obsolete("Deprecated since API11. Will be removed in API13.")]
    //public class FaceInfo
    //{
    //    internal FaceInfo(IntPtr handle)
    //    {
    //        Id = InteropHelper.GetString(handle, Interop.Face.GetId);
    //        MediaInfoId = InteropHelper.GetString(handle, Interop.Face.GetMediaId);

    //        Tag = InteropHelper.GetString(handle, Interop.Face.GetTag);
    //        Orientation = InteropHelper.GetValue<IntPtr, Orientation>(handle, Interop.Face.GetOrientation);

    //        Rect = GetRect(handle);
    //    }

        //private static Rectangle GetRect(IntPtr faceHandle)
        //{
        //    Interop.Face.GetFaceRect(faceHandle, out var x, out var y, out var width, out var height).
        //        ThrowIfError("Failed to get rect for the face info");

        //    return new Rectangle(x, y, width, height);
        //}

        /// <summary>
        /// Gets the region.
        /// </summary>
        /// <value>The region of face in the media.</value>
        /// <remarks>
        /// The coordinates of the rectangle are orientation-applied values.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        //[Obsolete("Deprecated since API11. Will be removed in API13.")]
        //public Rectangle Rect { get; }

        /// <summary>
        /// Gets the ID of face information.
        /// </summary>
        /// <value>The unique ID of face information.</value>
        /// <since_tizen> 4 </since_tizen>
        //[Obsolete("Deprecated since API11. Will be removed in API13.")]
        //public string Id { get; }

        /// <summary>
        /// Gets the media ID that the face information is added.
        /// </summary>
        /// <value>The media ID that the face information is added.</value>
        /// <since_tizen> 4 </since_tizen>
        //[Obsolete("Deprecated since API11. Will be removed in API13.")]
        //public string MediaInfoId { get; }

        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <value>The tag of face information.</value>
        /// <since_tizen> 4 </since_tizen>
        //[Obsolete("Deprecated since API11. Will be removed in API13.")]
        //public string Tag { get; }

        /// <summary>
        /// Gets the orientation of face information.
        /// </summary>
        /// <value>The orientation of face information.</value>
        /// <since_tizen> 4 </since_tizen>
        //[Obsolete("Deprecated since API11. Will be removed in API13.")]
        //public Orientation Orientation { get; }

        //internal static FaceInfo FromHandle(IntPtr handle)
        //{
        //    return new FaceInfo(handle);
        //}

        /// <summary>
        /// Returns a string representation of the face information.
        /// </summary>
        /// <returns>A string representation of the current face info.</returns>
        /// <since_tizen> 4 </since_tizen>
        //[Obsolete("Deprecated since API11. Will be removed in API13.")]
        //public override string ToString() =>
        //    $"Id={Id}, MediaInfoId={MediaInfoId}, Rect=({Rect}), Tag={Tag}";
    //}
}
