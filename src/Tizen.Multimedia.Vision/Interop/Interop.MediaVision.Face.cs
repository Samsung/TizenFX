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
        /// Interop for Face APIs.
        /// </summary>
        internal static partial class Face
        {
            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_detect")]
            internal static extern MediaVisionError Detect(IntPtr source, IntPtr engineCfg,
                DetectedCallback detectedCb, IntPtr userData = default(IntPtr)); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognize")]
            internal static extern MediaVisionError Recognize(IntPtr source, IntPtr recognitionModel, IntPtr engineCfg,
                IntPtr faceLocation, RecognizedCallback recognizedCb, IntPtr userData = default(IntPtr)); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognize")]
            internal static extern MediaVisionError Recognize(IntPtr source, IntPtr recognitionModel, IntPtr engineCfg,
                ref Rectangle faceLocation, RecognizedCallback recognizedCb, IntPtr userData = default(IntPtr)); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_track")]
            internal static extern MediaVisionError Track(IntPtr source, IntPtr trackingModel, IntPtr engineCfg,
                TrackedCallback trackedCb, bool doLearn, IntPtr userData = default(IntPtr)); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_eye_condition_recognize")]
            internal static extern MediaVisionError RecognizeEyeCondition(IntPtr source, IntPtr engineCfg,
                Rectangle faceLocation, EyeConditionRecognizedCallback eyeConditionRecognizedCb, IntPtr userData = default(IntPtr)); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_facial_expression_recognize")]
            internal static extern MediaVisionError RecognizeFacialExpression(IntPtr source, IntPtr engineCfg,
                Rectangle faceLocation, MvFaceFacialExpressionRecognizedCallback expressionRecognizedCb, // Deprecated in API 12
                IntPtr userData = default(IntPtr));

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void DetectedCallback(IntPtr source, IntPtr engineCfg,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] Rectangle[] facesLocations,
                int numberOfFaces, IntPtr userData); // Deprecated in API 12

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void RecognizedCallback(IntPtr source, IntPtr recognitionModel,
                IntPtr engineCfg, IntPtr faceLocation, IntPtr faceLabel, double confidence, IntPtr userData); // Deprecated in API 12

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void TrackedCallback(IntPtr source, IntPtr trackingModel, IntPtr engineCfg,
                IntPtr location, double confidence, IntPtr userData); // Deprecated in API 12

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void EyeConditionRecognizedCallback(IntPtr source, IntPtr engineCfg,
                Rectangle faceLocation, EyeCondition eyeCondition, IntPtr userData); // Deprecated in API 12

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void MvFaceFacialExpressionRecognizedCallback(IntPtr source,
                IntPtr engineCfg, Rectangle faceLocation, FacialExpression facialExpression, IntPtr userData); // Deprecated in API 12
        }

        /// <summary>
        /// Interop for FaceRecognitionModel APIs.
        /// </summary>
        internal static partial class FaceRecognitionModel
        {
            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognition_model_create")]
            internal static extern MediaVisionError Create(out IntPtr handle); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognition_model_destroy")]
            internal static extern int Destroy(IntPtr handle); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognition_model_clone")]
            internal static extern int Clone(IntPtr src, out IntPtr dst); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognition_model_save")]
            internal static extern MediaVisionError Save(string fileName, IntPtr handle); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognition_model_load")]
            internal static extern MediaVisionError Load(string fileName, out IntPtr handle); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognition_model_add")]
            internal static extern MediaVisionError Add(IntPtr source, IntPtr recognitionModel,
                ref Rectangle exampleLocation, int faceLabel); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognition_model_add")]
            internal static extern MediaVisionError Add(IntPtr source, IntPtr recognitionModel,
                IntPtr exampleLocation, int faceLabel); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognition_model_reset")]
            internal static extern MediaVisionError Reset(IntPtr recognitionModel, IntPtr faceLabel = default(IntPtr)); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognition_model_reset")]
            internal static extern MediaVisionError Remove(IntPtr recognitionModel, ref int faceLabel); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognition_model_learn")]
            internal static extern MediaVisionError Learn(IntPtr engineCfg, IntPtr handle); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognition_model_query_labels")]
            internal static extern MediaVisionError QueryLabels(IntPtr handle, out IntPtr labels, out uint numberOfLabels); // Deprecated in API 12
        }

        /// <summary>
        /// Interop for FaceTrackingModel APIs.
        /// </summary>
        internal static partial class FaceTrackingModel
        {
            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_tracking_model_create")]
            internal static extern MediaVisionError Create(out IntPtr handle); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_tracking_model_destroy")]
            internal static extern int Destroy(IntPtr handle); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_tracking_model_prepare")]
            internal static extern MediaVisionError Prepare(IntPtr trackingModel, IntPtr engineCfg,
                IntPtr source, ref Quadrangle location); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_tracking_model_prepare")]
            internal static extern MediaVisionError Prepare(IntPtr trackingModel, IntPtr engineCfg,
                IntPtr source, IntPtr location); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_tracking_model_clone")]
            internal static extern int Clone(IntPtr src, out IntPtr dst); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_tracking_model_save")]
            internal static extern MediaVisionError Save(string fileName, IntPtr handle); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_tracking_model_load")]
            internal static extern MediaVisionError Load(string fileName, out IntPtr handle); // Deprecated in API 12
        }

        /// <summary>
        /// Interop for FaceRecognition APIs.
        /// </summary>
        internal static partial class FaceRecognition
        {
            [DllImport(Libraries.MediaVisionFaceRecognition, EntryPoint = "mv_face_recognition_create")]
            internal static extern MediaVisionError Create(out IntPtr handle);

            [DllImport(Libraries.MediaVisionFaceRecognition, EntryPoint = "mv_face_recognition_destroy")]
            internal static extern MediaVisionError Destroy(IntPtr handle);

            [DllImport(Libraries.MediaVisionFaceRecognition, EntryPoint = "mv_face_recognition_prepare")]
            internal static extern MediaVisionError Prepare(IntPtr handle);

            [DllImport(Libraries.MediaVisionFaceRecognition, EntryPoint = "mv_face_recognition_register")]
            internal static extern MediaVisionError Register(IntPtr handle, IntPtr source, string label);

            [DllImport(Libraries.MediaVisionFaceRecognition, EntryPoint = "mv_face_recognition_unregister")]
            internal static extern MediaVisionError Unregister(IntPtr handle, string label);

            [DllImport(Libraries.MediaVisionFaceRecognition, EntryPoint = "mv_face_recognition_inference")]
            internal static extern MediaVisionError Inference(IntPtr handle, IntPtr source);

            [DllImport(Libraries.MediaVisionFaceRecognition, EntryPoint = "mv_face_recognition_get_label")]
            internal static extern MediaVisionError GetLabel(IntPtr handle, out IntPtr label);
        }
    }
}
