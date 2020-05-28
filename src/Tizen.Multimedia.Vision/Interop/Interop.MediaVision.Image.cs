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
using System.Runtime.InteropServices;
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
        /// Interop for Image APIs.
        /// </summary>
        internal static partial class Image
        {
            [DllImport(Libraries.MediaVisionImage, EntryPoint = "mv_image_recognize")]
            internal static extern MediaVisionError Recognize(IntPtr source, IntPtr[] imageObjects,
                int numberOfObjects, IntPtr engineCfg, RecognizedCallback recognizedCb, IntPtr userData = default(IntPtr));

            [DllImport(Libraries.MediaVisionImage, EntryPoint = "mv_image_track")]
            internal static extern MediaVisionError Track(IntPtr source, IntPtr imageTrackingModel,
                IntPtr engineCfg, TrackedCallback trackedCb, IntPtr userData = default(IntPtr));

            [DllImport(Libraries.MediaVisionImage, EntryPoint = "mv_image_object_create")]
            internal static extern MediaVisionError Create(out IntPtr handle);

            [DllImport(Libraries.MediaVisionImage, EntryPoint = "mv_image_object_destroy")]
            internal static extern int Destroy(IntPtr handle);

            [DllImport(Libraries.MediaVisionImage, EntryPoint = "mv_image_object_fill")]
            internal static extern MediaVisionError Fill(IntPtr handle, IntPtr engineCfg, IntPtr source, ref Rectangle location);

            [DllImport(Libraries.MediaVisionImage, EntryPoint = "mv_image_object_fill")]
            internal static extern MediaVisionError Fill(IntPtr handle, IntPtr engineCfg, IntPtr source, IntPtr location);

            [DllImport(Libraries.MediaVisionImage, EntryPoint = "mv_image_object_get_recognition_rate")]
            internal static extern MediaVisionError GetRecognitionRate(IntPtr handle, out double recognitionRate);

            [DllImport(Libraries.MediaVisionImage, EntryPoint = "mv_image_object_set_label")]
            internal static extern MediaVisionError SetLabel(IntPtr handle, int label);

            [DllImport(Libraries.MediaVisionImage, EntryPoint = "mv_image_object_get_label")]
            internal static extern MediaVisionError GetLabel(IntPtr handle, out int label);

            [DllImport(Libraries.MediaVisionImage, EntryPoint = "mv_image_object_clone")]
            internal static extern int Clone(IntPtr src, out IntPtr dst);

            [DllImport(Libraries.MediaVisionImage, EntryPoint = "mv_image_object_save")]
            internal static extern MediaVisionError Save(string fileName, IntPtr handle);

            [DllImport(Libraries.MediaVisionImage, EntryPoint = "mv_image_object_load")]
            internal static extern MediaVisionError Load(string fileName, out IntPtr handle);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void RecognizedCallback(IntPtr source, IntPtr engineCfg, IntPtr imageObjects,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)]
                IntPtr[] locations, uint numberOfObjects, IntPtr userData);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void TrackedCallback(IntPtr source, IntPtr imageTrackingModel,
                IntPtr engineCfg, IntPtr location, IntPtr userData);
        }

        /// <summary>
        /// Interop for ImageTrackingModel APIs.
        /// </summary>
        internal static partial class ImageTrackingModel
        {
            [DllImport(Libraries.MediaVisionImage, EntryPoint = "mv_image_tracking_model_create")]
            internal static extern MediaVisionError Create(out IntPtr imageTrackingModel);

            [DllImport(Libraries.MediaVisionImage, EntryPoint = "mv_image_tracking_model_set_target")]
            internal static extern MediaVisionError SetTarget(IntPtr handle, IntPtr imageTrackingModel);

            [DllImport(Libraries.MediaVisionImage, EntryPoint = "mv_image_tracking_model_destroy")]
            internal static extern int Destroy(IntPtr imageTrackingModel);

            [DllImport(Libraries.MediaVisionImage, EntryPoint = "mv_image_tracking_model_refresh")]
            internal static extern MediaVisionError Refresh(IntPtr imageTrackingModel, IntPtr engineCfg);

            [DllImport(Libraries.MediaVisionImage, EntryPoint = "mv_image_tracking_model_clone")]
            internal static extern int Clone(IntPtr src, out IntPtr dest);

            [DllImport(Libraries.MediaVisionImage, EntryPoint = "mv_image_tracking_model_save")]
            internal static extern MediaVisionError Save(string fileName, IntPtr imageTrackingModel);

            [DllImport(Libraries.MediaVisionImage, EntryPoint = "mv_image_tracking_model_load")]
            internal static extern MediaVisionError Load(string fileName, out IntPtr imageTrackingModel);
        }
    }
}
