/*
 * Copyright (c) 2022 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tizen.Multimedia.Vision;

/// <summary>
/// Interop APIs.
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// Interop for Media Vision APIs.
    /// </summary>
    internal static partial class MediaVision
    {
        /// <summary>
        /// Interop for ROI tracker APIs.
        /// </summary>
        internal static partial class RoiTracker
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void RoiTrackedCallback(IntPtr source, Rectangle roi, IntPtr userData = default);

            [LibraryImport(Libraries.MediaVisionRoiTracker, EntryPoint = "mv_roi_tracker_create")]
            internal static partial MediaVisionError Create(out IntPtr handle);

            [LibraryImport(Libraries.MediaVisionRoiTracker, EntryPoint = "mv_roi_tracker_destroy")]
            internal static partial MediaVisionError Destroy(IntPtr handle);

            [LibraryImport(Libraries.MediaVisionRoiTracker, EntryPoint = "mv_roi_tracker_configure")]
            internal static partial MediaVisionError Configure(IntPtr handle, IntPtr engineConfig);

            [LibraryImport(Libraries.MediaVisionRoiTracker, EntryPoint = "mv_roi_tracker_prepare")]
            internal static partial MediaVisionError Prepare(IntPtr handle, int x, int y, int width, int height);

            [LibraryImport(Libraries.MediaVisionRoiTracker, EntryPoint = "mv_roi_tracker_perform")]
            internal static partial MediaVisionError TrackRoi(IntPtr handle, IntPtr source, RoiTrackedCallback callback,
                IntPtr userData = default);
        }
    }
}

