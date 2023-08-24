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
        /// Interop for Face APIs.
        /// </summary>
        internal static partial class Inference
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void FaceDetectedCallback(IntPtr source, int numberOfFaces,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] confidences,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] Rectangle[] location,
                IntPtr userData = default(IntPtr));

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void FacialLandmarkDetectedCallback(IntPtr source, int numberOfLandmarks,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] Point[] locations,
                IntPtr userData = default(IntPtr));

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void ImageClassifedCallback(IntPtr source, int numberOfClasses,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] indices,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] string[] names,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] confidences,
                IntPtr userData = default(IntPtr));

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void ObjectDetectedCallback(IntPtr source, int numberOfObjects,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] indices,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] string[] names,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] confidences,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] Rectangle[] location,
                IntPtr userData = default(IntPtr));

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate bool SupportedBackendCallback(string backend, bool isSupported,
                IntPtr userData = default(IntPtr));

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void PoseLandmarkDetectedCallback(IntPtr source, IntPtr poses,
                IntPtr userData = default(IntPtr));

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_create")]
            internal static extern MediaVisionError Create(out IntPtr handle);

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_destroy")]
            internal static extern MediaVisionError Destroy(IntPtr handle);

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_configure")]
            internal static extern MediaVisionError Configure(IntPtr handle, IntPtr engineConfig);

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_prepare")]
            internal static extern MediaVisionError Load(IntPtr handle);

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_foreach_supported_engine")]
            internal static extern MediaVisionError ForeachSupportedBackend(IntPtr handle,
                SupportedBackendCallback callback, IntPtr userData = default(IntPtr));

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_image_classify")]
            internal static extern MediaVisionError ClassifyImage(IntPtr source, IntPtr inference,
                IntPtr roi, ImageClassifedCallback callback, IntPtr userData = default(IntPtr));

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_object_detect")]
            internal static extern MediaVisionError DetectObject(IntPtr source, IntPtr inference,
                ObjectDetectedCallback callback, IntPtr userData = default(IntPtr));

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_face_detect")]
            internal static extern MediaVisionError DetectFace(IntPtr source, IntPtr inference,
                FaceDetectedCallback callback, IntPtr userData = default(IntPtr));

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_facial_landmark_detect")]
            internal static extern MediaVisionError DetectFacialLandmark(IntPtr source, IntPtr inference,
                IntPtr roi, FacialLandmarkDetectedCallback callback, IntPtr userData = default(IntPtr));

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_pose_get_number_of_poses")]
            internal static extern MediaVisionError GetPoseNum(IntPtr result, out int numPose);

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_pose_get_number_of_landmarks")]
            internal static extern MediaVisionError GetLandmarkNum(IntPtr result, out int numLandmark);

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_pose_get_landmark")]
            internal static extern MediaVisionError GetLandmark(IntPtr result, int index, int part, out Point location, out float score);

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_pose_landmark_detect")]
            internal static extern MediaVisionError DetectPoseLandmark(IntPtr source, IntPtr inference,
                IntPtr roi, PoseLandmarkDetectedCallback callback, IntPtr userData = default(IntPtr));
        }
    }
}
