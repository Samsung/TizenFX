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
using Tizen.Multimedia;

/// <summary>
/// Interop APIs
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// Interop for media vision APIs
    /// </summary>
    internal static partial class MediaVision
    {
        /// <summary>
        /// Interop for Face APIs
        /// </summary>
        internal static partial class Face
        {
            [DllImport(Libraries.MediaVision, EntryPoint = "mv_face_detect")]
            internal static extern int Detect(IntPtr /* mv_source_h */ source, IntPtr /* mv_engine_config_h */ engineCfg, MvFaceDetectedCallback detectedCb, IntPtr /* void */ userData);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_face_recognize")]
            internal static extern int Recognize(IntPtr /* mv_source_h */ source, IntPtr /* mv_face_recognition_model_h */ recognitionModel, IntPtr /* mv_engine_config_h */ engineCfg, IntPtr faceLocation, MvFaceRecognizedCallback recognizedCb, IntPtr /* void */ userData);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_face_track")]
            internal static extern int Track(IntPtr /* mv_source_h */ source, IntPtr /* mv_face_tracking_model_h */ trackingModel, IntPtr /* mv_engine_config_h */ engineCfg, MvFaceTrackedCallback trackedCb, bool doLearn, IntPtr /* void */ userData);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_face_eye_condition_recognize")]
            internal static extern int RecognizeEyeCondition(IntPtr /* mv_source_h */ source, IntPtr /* mv_engine_config_h */ engineCfg, Rectangle faceLocation, MvFaceEyeConditionRecognizedCallback eyeConditionRecognizedCb, IntPtr /* void */ userData);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_face_facial_expression_recognize")]
            internal static extern int RecognizeFacialExpression(IntPtr /* mv_source_h */ source, IntPtr /* mv_engine_config_h */ engineCfg, Rectangle faceLocation, MvFaceFacialExpressionRecognizedCallback expressionRecognizedCb, IntPtr /* void */ userData);

            [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
            internal delegate void MvFaceDetectedCallback(IntPtr /* mv_source_h */ source, IntPtr /* mv_engine_config_h */ engineCfg, IntPtr facesLocations, int numberOfFaces, IntPtr /* void */ userData);

            [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
            internal delegate void MvFaceRecognizedCallback(IntPtr /* mv_source_h */ source, IntPtr /* mv_face_recognition_model_h */ recognitionModel, IntPtr /* mv_engine_config_h */ engineCfg, IntPtr faceLocation, IntPtr faceLabel, double confidence, IntPtr /* void */ userData);

            [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
            internal delegate void MvFaceTrackedCallback(IntPtr /* mv_source_h */ source, IntPtr /* mv_face_tracking_model_h */ trackingModel, IntPtr /* mv_engine_config_h */ engineCfg, IntPtr location, double confidence, IntPtr /* void */ userData);

            [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
            internal delegate void MvFaceEyeConditionRecognizedCallback(IntPtr /* mv_source_h */ source, IntPtr /* mv_engine_config_h */ engineCfg, Rectangle faceLocation, EyeCondition /* mv_face_eye_condition_e */ eyeCondition, IntPtr /* void */ userData);

            [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
            internal delegate void MvFaceFacialExpressionRecognizedCallback(IntPtr /* mv_source_h */ source, IntPtr /* mv_engine_config_h */ engineCfg, Rectangle faceLocation, FacialExpression /* mv_face_facial_expression_e */ facialExpression, IntPtr /* void */ userData);
        }

        /// <summary>
        /// Interop for FaceRecognitionModel APIs
        /// </summary>
        internal static partial class FaceRecognitionModel
        {
            [DllImport(Libraries.MediaVision, EntryPoint = "mv_face_recognition_model_create")]
            internal static extern int Create(out IntPtr /* mv_face_recognition_model_h */ recognitionModel);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_face_recognition_model_destroy")]
            internal static extern int Destroy(IntPtr /* mv_face_recognition_model_h */ recognitionModel);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_face_recognition_model_clone")]
            internal static extern int Clone(IntPtr /* mv_face_recognition_model_h */ src, out IntPtr /* mv_face_recognition_model_h */ dst);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_face_recognition_model_save")]
            internal static extern int Save(string fileName, IntPtr /* mv_face_recognition_model_h */ recognitionModel);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_face_recognition_model_load")]
            internal static extern int Load(string fileName, out IntPtr /* mv_face_recognition_model_h */ recognitionModel);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_face_recognition_model_add")]
            internal static extern int Add(IntPtr /* mv_source_h */ source, IntPtr /* mv_face_recognition_model_h */ recognitionModel, IntPtr exampleLocation, int faceLabel);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_face_recognition_model_reset")]
            internal static extern int Reset(IntPtr /* mv_face_recognition_model_h */ recognitionModel, IntPtr faceLabel);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_face_recognition_model_reset")]
            internal static extern int Remove(IntPtr /* mv_face_recognition_model_h */ recognitionModel, ref int faceLabel);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_face_recognition_model_learn")]
            internal static extern int Learn(IntPtr /* mv_engine_config_h */ engineCfg, IntPtr /* mv_face_recognition_model_h */ recognitionModel);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_face_recognition_model_query_labels")]
            internal static extern int QueryLabels(IntPtr /* mv_face_recognition_model_h */ recognitionModel, out IntPtr labels, out uint numberOfLabels);
        }

        /// <summary>
        /// Interop for FaceTrackingModel APIs
        /// </summary>
        internal static partial class FaceTrackingModel
        {
            [DllImport(Libraries.MediaVision, EntryPoint = "mv_face_tracking_model_create")]
            internal static extern int Create(out IntPtr /* mv_face_tracking_model_h */ trackingModel);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_face_tracking_model_destroy")]
            internal static extern int Destroy(IntPtr /* mv_face_tracking_model_h */ trackingModel);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_face_tracking_model_prepare")]
            internal static extern int Prepare(IntPtr /* mv_face_tracking_model_h */ trackingModel, IntPtr /* mv_engine_config_h */ engineCfg, IntPtr /* mv_source_h */ source, IntPtr location);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_face_tracking_model_clone")]
            internal static extern int Clone(IntPtr /* mv_face_tracking_model_h */ src, out IntPtr /* mv_face_tracking_model_h */ dst);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_face_tracking_model_save")]
            internal static extern int Save(string fileName, IntPtr /* mv_face_tracking_model_h */ trackingModel);

            [DllImport(Libraries.MediaVision, EntryPoint = "mv_face_tracking_model_load")]
            internal static extern int Load(string fileName, out IntPtr /* mv_face_tracking_model_h */ trackingModel);
        }
    }
}
