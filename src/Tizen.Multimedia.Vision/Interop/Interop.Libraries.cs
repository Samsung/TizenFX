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

internal static partial class Interop
{
    internal static partial class Libraries
    {
        public const string MediaVisionCommon = "libmv_common.so";
        public const string MediaVisionFace = "libmv_face.so";
        public const string MediaVisionImage = "libmv_image.so";
        public const string MediaVisionSurveillance = "libmv_surveillance.so";
        public const string MediaVisionBarcodeDetector = "libmv_barcode_detector.so";
        public const string MediaVisionBarcodeGenerator = "libmv_barcode_generator.so";
        public const string MediaVisionRoiTracker = "libmv_roi_tracker.so";
        public const string MediaVisionFaceRecognition = "libmv_face_recognition.so"; // It's based on machine learning
        public const string MediaVisionInference = "libmv_inference.so";
        public const string MediaVisionInferenceImageClassification = "libmv_image_classification.so"; // Inference image classification
        public const string MediaVisionInferenceObjectDetection = "libmv_object_detection.so";
        public const string MediaVisionInferenceFaceDetection = MediaVisionInferenceObjectDetection; // Inference object detection and face detection
        public const string MediaVisionInferenceFacialLandmarkDetection = "libmv_landmark_detection.so";
        public const string MediaVisionInferencePoseLandmarkDetection = "libmv_landmark_detection.so"; // Inference facial landmark detection and pose landmark detection
    }
}
