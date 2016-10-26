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

/// <summary>
/// Interop APIs
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// Interop for Media vision APIs
    /// </summary>
    internal static partial class MediaVision
    {
        /// <summary>
        /// Interop for Image APIs
        /// </summary>
        internal static partial class Image
        {
            [DllImport(Libraries.MediaVision, EntryPoint = "mv_image_recognize")]
            internal static extern int Recognize(IntPtr /* mv_source_h */ source, IntPtr /* mv_image_object_h */ imageObjects, int numberOfObjects, IntPtr /* mv_engine_config_h */ engineCfg, MvImageRecognizedCallback recognizedCb, IntPtr /* void */ userData);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_image_track")]
            internal static extern int Track(IntPtr /* mv_source_h */ source, IntPtr /* mv_image_tracking_model_h */ imageTrackingModel, IntPtr /* mv_engine_config_h */ engineCfg, MvImageTrackedCallback trackedCb, IntPtr /* void */ userData);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_image_object_create")]
            internal static extern int Create(out IntPtr /* mv_image_object_h */ imageObject);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_image_object_destroy")]
            internal static extern int Destroy(IntPtr /* mv_image_object_h */ imageObject);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_image_object_fill")]
            internal static extern int Fill(IntPtr /* mv_image_object_h */ imageObject, IntPtr /* mv_engine_config_h */ engineCfg, IntPtr /* mv_source_h */ source, IntPtr location);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_image_object_get_recognition_rate")]
            internal static extern int GetRecognitionRate(IntPtr /* mv_image_object_h */ imageObject, out double recognitionRate);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_image_object_set_label")]
            internal static extern int SetLabel(IntPtr /* mv_image_object_h */ imageObject, int label);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_image_object_get_label")]
            internal static extern int GetLabel(IntPtr /* mv_image_object_h */ imageObject, out int label);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_image_object_clone")]
            internal static extern int Clone(IntPtr /* mv_image_object_h */ src, out IntPtr /* mv_image_object_h */ dst);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_image_object_save")]
            internal static extern int Save(string fileName, IntPtr /* mv_image_object_h */ imageObject);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_image_object_load")]
            internal static extern int Load(string fileName, out IntPtr /* mv_image_object_h */ imageObject);

            [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
            internal delegate void MvImageRecognizedCallback(IntPtr /* mv_source_h */ source, IntPtr /* mv_engine_config_h */ engineCfg, IntPtr /* mv_image_object_h */ imageObjects, IntPtr locations, uint numberOfObjects, IntPtr /* void */ userData);

            [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
            internal delegate void MvImageTrackedCallback(IntPtr /* mv_source_h */ source, IntPtr /* mv_image_tracking_model_h */ imageTrackingModel, IntPtr /* mv_engine_config_h */ engineCfg, IntPtr location, IntPtr /* void */ userData);
        }

        /// <summary>
        /// Interop for ImageTrackingModel APIs
        /// </summary>
        internal static partial class ImageTrackingModel
        {
            [DllImport(Libraries.MediaVision, EntryPoint = "mv_image_tracking_model_create")]
            internal static extern int Create(out IntPtr /* mv_image_tracking_model_h */ imageTrackingModel);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_image_tracking_model_set_target")]
            internal static extern int SetTarget(IntPtr /* mv_image_object_h */ imageObject, IntPtr /* mv_image_tracking_model_h */ imageTrackingModel);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_image_tracking_model_destroy")]
            internal static extern int Destroy(IntPtr /* mv_image_tracking_model_h */ imageTrackingModel);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_image_tracking_model_refresh")]
            internal static extern int Refresh(IntPtr /* mv_image_tracking_model_h */ imageTrackingModel, IntPtr /* mv_engine_config_h */ engineCfg);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_image_tracking_model_clone")]
            internal static extern int Clone(IntPtr /* mv_image_tracking_model_h */ src, out IntPtr /* mv_image_tracking_model_h */ dest);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_image_tracking_model_save")]
            internal static extern int Save(string fileName, IntPtr /* mv_image_tracking_model_h */ imageTrackingModel);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_image_tracking_model_load")]
            internal static extern int Load(string fileName, out IntPtr /* mv_image_tracking_model_h */ imageTrackingModel);
        }
    }
}
