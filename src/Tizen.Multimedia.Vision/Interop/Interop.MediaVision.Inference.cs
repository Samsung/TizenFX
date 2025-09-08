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
                IntPtr userData = default(IntPtr)); // Deprecated in API 12

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void FacialLandmarkDetectedCallback(IntPtr source, int numberOfLandmarks,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] Point[] locations,
                IntPtr userData = default(IntPtr)); // Deprecated in API 12

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void ImageClassifedCallback(IntPtr source, int numberOfClasses,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] indices,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] string[] names,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] confidences,
                IntPtr userData = default(IntPtr)); // Deprecated in API 12

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void ObjectDetectedCallback(IntPtr source, int numberOfObjects,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] indices,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] string[] names,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] confidences,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] Rectangle[] location,
                IntPtr userData = default(IntPtr)); // Deprecated in API 12

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate bool SupportedBackendCallback(string backend, bool isSupported,
                IntPtr userData = default(IntPtr)); // Deprecated in API 12

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void PoseLandmarkDetectedCallback(IntPtr source, IntPtr poses,
                IntPtr userData = default(IntPtr)); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_create")]
            internal static extern MediaVisionError Create(out IntPtr handle); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_destroy")]
            internal static extern MediaVisionError Destroy(IntPtr handle); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_configure")]
            internal static extern MediaVisionError Configure(IntPtr handle, IntPtr engineConfig); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_prepare")]
            internal static extern MediaVisionError Load(IntPtr handle); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_foreach_supported_engine")]
            internal static extern MediaVisionError ForeachSupportedBackend(IntPtr handle,
                SupportedBackendCallback callback, IntPtr userData = default(IntPtr)); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_image_classify")]
            internal static extern MediaVisionError ClassifyImage(IntPtr source, IntPtr inference,
                IntPtr roi, ImageClassifedCallback callback, IntPtr userData = default(IntPtr)); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_object_detect")]
            internal static extern MediaVisionError DetectObject(IntPtr source, IntPtr inference,
                ObjectDetectedCallback callback, IntPtr userData = default(IntPtr)); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_face_detect")]
            internal static extern MediaVisionError DetectFace(IntPtr source, IntPtr inference,
                FaceDetectedCallback callback, IntPtr userData = default(IntPtr)); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_facial_landmark_detect")]
            internal static extern MediaVisionError DetectFacialLandmark(IntPtr source, IntPtr inference,
                IntPtr roi, FacialLandmarkDetectedCallback callback, IntPtr userData = default(IntPtr)); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_pose_get_number_of_poses")]
            internal static extern MediaVisionError GetPoseNum(IntPtr result, out int numPose); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_pose_get_number_of_landmarks")]
            internal static extern MediaVisionError GetLandmarkNum(IntPtr result, out int numLandmark); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_pose_get_landmark")]
            internal static extern MediaVisionError GetLandmark(IntPtr result, int index, int part, out Point location, out float score); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionInference, EntryPoint = "mv_inference_pose_landmark_detect")]
            internal static extern MediaVisionError DetectPoseLandmark(IntPtr source, IntPtr inference,
                IntPtr roi, PoseLandmarkDetectedCallback callback, IntPtr userData = default(IntPtr)); // Deprecated in API 12
        }

        internal static partial class InferenceImageClassification
        {
            // Newly added inferernce APIs
            [DllImport(Libraries.MediaVisionInferenceImageClassification, EntryPoint = "mv_image_classification_create")]
            internal static extern MediaVisionError Create(out IntPtr handle);

            [DllImport(Libraries.MediaVisionInferenceImageClassification, EntryPoint = "mv_image_classification_destroy")]
            internal static extern MediaVisionError Destroy(IntPtr handle);

            [DllImport(Libraries.MediaVisionInferenceImageClassification, EntryPoint = "mv_image_classification_configure")]
            internal static extern MediaVisionError Configure(IntPtr handle);

            [DllImport(Libraries.MediaVisionInferenceImageClassification, EntryPoint = "mv_image_classification_prepare")]
            internal static extern MediaVisionError Prepare(IntPtr handle);

            [DllImport(Libraries.MediaVisionInferenceImageClassification, EntryPoint = "mv_image_classification_inference")]
            internal static extern MediaVisionError Inference(IntPtr handle, IntPtr source);

            [DllImport(Libraries.MediaVisionInferenceImageClassification, EntryPoint = "mv_image_classification_inference_async")]
            internal static extern MediaVisionError InferenceAsync(IntPtr handle, IntPtr source);

            [DllImport(Libraries.MediaVisionInferenceImageClassification, EntryPoint = "mv_image_classification_get_result_count")]
            internal static extern MediaVisionError GetResultCount(IntPtr handle, out ulong requestOrder, out uint count);

            [DllImport(Libraries.MediaVisionInferenceImageClassification, EntryPoint = "mv_image_classification_get_label")]
            internal static extern MediaVisionError GetLabels(IntPtr handle, uint index, out IntPtr label);
        }

        internal static partial class InferenceFaceDetection
        {
            // Newly added inferernce APIs
            [DllImport(Libraries.MediaVisionInferenceFaceDetection, EntryPoint = "mv_face_detection_create")]
            internal static extern MediaVisionError Create(out IntPtr handle);

            [DllImport(Libraries.MediaVisionInferenceFaceDetection, EntryPoint = "mv_face_detection_destroy")]
            internal static extern MediaVisionError Destroy(IntPtr handle);

            [DllImport(Libraries.MediaVisionInferenceFaceDetection, EntryPoint = "mv_face_detection_configure")]
            internal static extern MediaVisionError Configure(IntPtr handle);

            [DllImport(Libraries.MediaVisionInferenceFaceDetection, EntryPoint = "mv_face_detection_prepare")]
            internal static extern MediaVisionError Prepare(IntPtr handle);

            [DllImport(Libraries.MediaVisionInferenceFaceDetection, EntryPoint = "mv_face_detection_inference")]
            internal static extern MediaVisionError Inference(IntPtr handle, IntPtr source);

            [DllImport(Libraries.MediaVisionInferenceFaceDetection, EntryPoint = "mv_face_detection_inference_async")]
            internal static extern MediaVisionError InferenceAsync(IntPtr handle, IntPtr source);

            [DllImport(Libraries.MediaVisionInferenceFaceDetection, EntryPoint = "mv_face_detection_get_result_count")]
            internal static extern MediaVisionError GetResultCount(IntPtr handle, out ulong requestId, out uint count);

            [DllImport(Libraries.MediaVisionInferenceFaceDetection, EntryPoint = "mv_face_detection_get_bound_box")]
            internal static extern MediaVisionError GetBoundingBoxes(IntPtr handle, uint index, out int left, out int top, out int right, out int bottom);
        }

        internal static partial class InferenceObjectDetection
        {
            // Newly added inferernce APIs
            [DllImport(Libraries.MediaVisionInferenceObjectDetection, EntryPoint = "mv_object_detection_create")]
            internal static extern MediaVisionError Create(out IntPtr handle);

            [DllImport(Libraries.MediaVisionInferenceObjectDetection, EntryPoint = "mv_object_detection_destroy")]
            internal static extern MediaVisionError Destroy(IntPtr handle);

            [DllImport(Libraries.MediaVisionInferenceObjectDetection, EntryPoint = "mv_object_detection_configure")]
            internal static extern MediaVisionError Configure(IntPtr handle);

            [DllImport(Libraries.MediaVisionInferenceObjectDetection, EntryPoint = "mv_object_detection_prepare")]
            internal static extern MediaVisionError Prepare(IntPtr handle);

            [DllImport(Libraries.MediaVisionInferenceObjectDetection, EntryPoint = "mv_object_detection_inference")]
            internal static extern MediaVisionError Inference(IntPtr handle, IntPtr source);

            [DllImport(Libraries.MediaVisionInferenceObjectDetection, EntryPoint = "mv_object_detection_inference_async")]
            internal static extern MediaVisionError InferenceAsync(IntPtr handle, IntPtr source);

            [DllImport(Libraries.MediaVisionInferenceObjectDetection, EntryPoint = "mv_object_detection_get_result_count")]
            internal static extern MediaVisionError GetResultCount(IntPtr handle, out ulong requestId, out uint count);

            [DllImport(Libraries.MediaVisionInferenceObjectDetection, EntryPoint = "mv_object_detection_get_bound_box")]
            internal static extern MediaVisionError GetBoundingBoxes(IntPtr handle, uint index, out int left, out int top, out int right, out int bottom);
        }

        internal static partial class InferenceFacialLandmarkDetection
        {
            // Newly added inferernce APIs
            [DllImport(Libraries.MediaVisionInferenceFacialLandmarkDetection, EntryPoint = "mv_facial_landmark_create")]
            internal static extern MediaVisionError Create(out IntPtr handle);

            [DllImport(Libraries.MediaVisionInferenceFacialLandmarkDetection, EntryPoint = "mv_facial_landmark_destroy")]
            internal static extern MediaVisionError Destroy(IntPtr handle);

            [DllImport(Libraries.MediaVisionInferenceFacialLandmarkDetection, EntryPoint = "mv_facial_landmark_configure")]
            internal static extern MediaVisionError Configure(IntPtr handle);

            [DllImport(Libraries.MediaVisionInferenceFacialLandmarkDetection, EntryPoint = "mv_facial_landmark_prepare")]
            internal static extern MediaVisionError Prepare(IntPtr handle);

            [DllImport(Libraries.MediaVisionInferenceFacialLandmarkDetection, EntryPoint = "mv_facial_landmark_inference")]
            internal static extern MediaVisionError Inference(IntPtr handle, IntPtr source);

            [DllImport(Libraries.MediaVisionInferenceFacialLandmarkDetection, EntryPoint = "mv_facial_landmark_inference_async")]
            internal static extern MediaVisionError InferenceAsync(IntPtr handle, IntPtr source);

            [DllImport(Libraries.MediaVisionInferenceFacialLandmarkDetection, EntryPoint = "mv_facial_landmark_get_result_count")]
            internal static extern MediaVisionError GetResultCount(IntPtr handle, out ulong requestId, out uint count);

            [DllImport(Libraries.MediaVisionInferenceFacialLandmarkDetection, EntryPoint = "mv_facial_landmark_get_position")]
            internal static extern MediaVisionError GetPoints(IntPtr handle, uint index, out uint posX, out uint posY);
        }

        internal static partial class InferencePoseLandmarkDetection
        {
            // Newly added inferernce APIs
            [DllImport(Libraries.MediaVisionInferencePoseLandmarkDetection, EntryPoint = "mv_pose_landmark_create")]
            internal static extern MediaVisionError Create(out IntPtr handle);

            [DllImport(Libraries.MediaVisionInferencePoseLandmarkDetection, EntryPoint = "mv_pose_landmark_destroy")]
            internal static extern MediaVisionError Destroy(IntPtr handle);

            [DllImport(Libraries.MediaVisionInferencePoseLandmarkDetection, EntryPoint = "mv_pose_landmark_configure")]
            internal static extern MediaVisionError Configure(IntPtr handle);

            [DllImport(Libraries.MediaVisionInferencePoseLandmarkDetection, EntryPoint = "mv_pose_landmark_prepare")]
            internal static extern MediaVisionError Prepare(IntPtr handle);

            [DllImport(Libraries.MediaVisionInferencePoseLandmarkDetection, EntryPoint = "mv_pose_landmark_inference")]
            internal static extern MediaVisionError Inference(IntPtr handle, IntPtr source);

            [DllImport(Libraries.MediaVisionInferencePoseLandmarkDetection, EntryPoint = "mv_pose_landmark_inference_async")]
            internal static extern MediaVisionError InferenceAsync(IntPtr handle, IntPtr source);

            [DllImport(Libraries.MediaVisionInferencePoseLandmarkDetection, EntryPoint = "mv_pose_landmark_get_result_count")]
            internal static extern MediaVisionError GetResultCount(IntPtr handle, out ulong requestId, out uint count);

            [DllImport(Libraries.MediaVisionInferencePoseLandmarkDetection, EntryPoint = "mv_pose_landmark_get_position")]
            internal static extern MediaVisionError GetPoints(IntPtr handle, uint index, out uint posX, out uint posY);
        }
    }
}
