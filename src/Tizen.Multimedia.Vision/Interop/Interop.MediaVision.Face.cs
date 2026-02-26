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
        /// Interop for Face APIs.
        /// </summary>
        internal static partial class Face
        {
            [LibraryImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_detect", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError Detect(IntPtr source, IntPtr engineCfg,
                DetectedCallback detectedCb, IntPtr userData = default(IntPtr)); // Deprecated in API 12

            [LibraryImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognize", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError Recognize(IntPtr source, IntPtr recognitionModel, IntPtr engineCfg,
                IntPtr faceLocation, RecognizedCallback recognizedCb, IntPtr userData = default(IntPtr)); // Deprecated in API 12

            [LibraryImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognize", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError Recognize(IntPtr source, IntPtr recognitionModel, IntPtr engineCfg,
                ref Rectangle faceLocation, RecognizedCallback recognizedCb, IntPtr userData = default(IntPtr)); // Deprecated in API 12

            [LibraryImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_track", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError Track(IntPtr source, IntPtr trackingModel, IntPtr engineCfg,
                TrackedCallback trackedCb, [MarshalAs(UnmanagedType.U1)] bool doLearn, IntPtr userData = default(IntPtr)); // Deprecated in API 12

            [LibraryImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_eye_condition_recognize", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError RecognizeEyeCondition(IntPtr source, IntPtr engineCfg,
                Rectangle faceLocation, EyeConditionRecognizedCallback eyeConditionRecognizedCb, IntPtr userData = default(IntPtr)); // Deprecated in API 12

            [LibraryImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_facial_expression_recognize", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError RecognizeFacialExpression(IntPtr source, IntPtr engineCfg,
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
            [LibraryImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognition_model_create", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError Create(out IntPtr handle); // Deprecated in API 12

            [LibraryImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognition_model_destroy", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int Destroy(IntPtr handle); // Deprecated in API 12

            [LibraryImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognition_model_clone", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int Clone(IntPtr src, out IntPtr dst); // Deprecated in API 12

            [LibraryImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognition_model_save", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError Save(string fileName, IntPtr handle); // Deprecated in API 12

            [LibraryImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognition_model_load", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError Load(string fileName, out IntPtr handle); // Deprecated in API 12

            [LibraryImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognition_model_add", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError Add(IntPtr source, IntPtr recognitionModel,
                ref Rectangle exampleLocation, int faceLabel); // Deprecated in API 12

            [LibraryImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognition_model_add", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError Add(IntPtr source, IntPtr recognitionModel,
                IntPtr exampleLocation, int faceLabel); // Deprecated in API 12

            [LibraryImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognition_model_reset", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError Reset(IntPtr recognitionModel, IntPtr faceLabel = default(IntPtr)); // Deprecated in API 12

            [LibraryImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognition_model_reset", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError Remove(IntPtr recognitionModel, ref int faceLabel); // Deprecated in API 12

            [LibraryImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognition_model_learn", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError Learn(IntPtr engineCfg, IntPtr handle); // Deprecated in API 12

            [LibraryImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_recognition_model_query_labels", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError QueryLabels(IntPtr handle, out IntPtr labels, out uint numberOfLabels); // Deprecated in API 12
        }

        /// <summary>
        /// Interop for FaceTrackingModel APIs.
        /// </summary>
        internal static partial class FaceTrackingModel
        {
            [LibraryImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_tracking_model_create", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError Create(out IntPtr handle); // Deprecated in API 12

            [LibraryImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_tracking_model_destroy", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int Destroy(IntPtr handle); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_tracking_model_prepare")]
            internal static extern MediaVisionError Prepare(IntPtr trackingModel, IntPtr engineCfg,
                IntPtr source, ref Quadrangle location); // Deprecated in API 12

            [DllImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_tracking_model_prepare")]
            internal static extern MediaVisionError Prepare(IntPtr trackingModel, IntPtr engineCfg,
                IntPtr source, IntPtr location); // Deprecated in API 12

            [LibraryImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_tracking_model_clone", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int Clone(IntPtr src, out IntPtr dst); // Deprecated in API 12

            [LibraryImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_tracking_model_save", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError Save(string fileName, IntPtr handle); // Deprecated in API 12

            [LibraryImport(Libraries.MediaVisionFace, EntryPoint = "mv_face_tracking_model_load", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError Load(string fileName, out IntPtr handle); // Deprecated in API 12
        }

        /// <summary>
        /// Interop for FaceRecognition APIs.
        /// </summary>
        internal static partial class FaceRecognition
        {
            [LibraryImport(Libraries.MediaVisionFaceRecognition, EntryPoint = "mv_face_recognition_create", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError Create(out IntPtr handle);

            [LibraryImport(Libraries.MediaVisionFaceRecognition, EntryPoint = "mv_face_recognition_destroy", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError Destroy(IntPtr handle);

            [LibraryImport(Libraries.MediaVisionFaceRecognition, EntryPoint = "mv_face_recognition_prepare", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError Prepare(IntPtr handle);

            [LibraryImport(Libraries.MediaVisionFaceRecognition, EntryPoint = "mv_face_recognition_register", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError Register(IntPtr handle, IntPtr source, string label);

            [LibraryImport(Libraries.MediaVisionFaceRecognition, EntryPoint = "mv_face_recognition_unregister", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError Unregister(IntPtr handle, string label);

            [LibraryImport(Libraries.MediaVisionFaceRecognition, EntryPoint = "mv_face_recognition_inference", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError Inference(IntPtr handle, IntPtr source);

            [LibraryImport(Libraries.MediaVisionFaceRecognition, EntryPoint = "mv_face_recognition_get_label", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial MediaVisionError GetLabel(IntPtr handle, out IntPtr label);
        }
    }
}
