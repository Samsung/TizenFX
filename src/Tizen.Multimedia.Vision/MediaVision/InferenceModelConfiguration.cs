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
using System.Linq;
using System.IO;
using System.Collections.Generic;
using InteropInference = Interop.MediaVision.Inference;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Represents a configuration of <see cref="FaceDetector"/>, <see cref="FacialLandmarkDetector"/>,
    /// <see cref="ImageClassifier"/> and <see cref="ObjectDetector"/>.
    /// </summary>
    /// <remarks>
    /// 'Inference model' means pre-learned data, which is represented by <see cref="ConfigurationFilePath"/> and
    /// <see cref="WeightFilePath"/>, <see cref="CategoryFilePath"/>.<br/>
    /// If user want to use tizen default inference model and its related value,
    /// Please refer Tizen guide page(https://developer.tizen.org/development/guides/.net-application).
    /// </remarks>
    /// <feature>http://tizen.org/feature/vision.inference.face</feature>
    /// <feature>http://tizen.org/feature/vision.inference.image</feature>
    /// <since_tizen> 6 </since_tizen>
    public class InferenceModelConfiguration : EngineConfiguration
    {
        private IntPtr _inferenceHandle = IntPtr.Zero;

        private const string _keyModelConfigurationFilePath = "MV_INFERENCE_MODEL_CONFIGURATION_FILE_PATH";
        private const string _keyModelWeightFilePath = "MV_INFERENCE_MODEL_WEIGHT_FILE_PATH";
        private const string _keyModelUserFilePath = "MV_INFERENCE_MODEL_USER_FILE_PATH";
        private const string _keyMetadataFilePath = "MV_INFERENCE_MODEL_META_FILE_PATH";
        private const string _keyModelMeanValue = "MV_INFERENCE_MODEL_MEAN_VALUE"; // Deprecated
        private const string _keyModelStdValue = "MV_INFERENCE_MODEL_STD_VALUE"; // Deprecated
        private const string _keyBackendType = "MV_INFERENCE_BACKEND_TYPE";
        private const string _keyTargetType = "MV_INFERENCE_TARGET_TYPE";
        private const string _keyTargetDeviceType = "MV_INFERENCE_TARGET_DEVICE_TYPE";
        private const string _keyInputTensorWidth = "MV_INFERENCE_INPUT_TENSOR_WIDTH"; // Deprecated
        private const string _keyInputTensorHeight = "MV_INFERENCE_INPUT_TENSOR_HEIGHT"; // Deprecated
        private const string _keyInputTensorChannels = "MV_INFERENCE_INPUT_TENSOR_CHANNELS"; // Deprecated
        private const string _keyDataType = "MV_INFERENCE_INPUT_DATA_TYPE"; // Deprecated
        private const string _keyInputNodeName = "MV_INFERENCE_INPUT_NODE_NAME"; // Deprecated
        private const string _keyOutputNodeNames = "MV_INFERENCE_OUTPUT_NODE_NAMES"; // Deprecated
        private const string _keyOutputMaxNumber = "MV_INFERENCE_OUTPUT_MAX_NUMBER"; // Deprecated
        private const string _keyConfidenceThreshold = "MV_INFERENCE_CONFIDENCE_THRESHOLD"; // Deprecated

        // The following strings are fixed in native and will not be changed.
        private const string _backendTypeOpenCV = "opencv";
        private const string _backendTypeTFLite = "tflite";
        private const string _backendTypeArmNN = "armnn";
        private const string _backendTypeMLApi = "mlapi";
        private const string _backendTypeOne = "one";

        /// <summary>
        /// Initializes a new instance of the <see cref="InferenceModelConfiguration"/> class.
        /// </summary>
        /// <feature>http://tizen.org/feature/vision.inference.face</feature>
        /// <feature>http://tizen.org/feature/vision.inference.image</feature>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <since_tizen> 6 </since_tizen>
        public InferenceModelConfiguration() : base("inference")
        {
            InteropInference.Create(out _inferenceHandle).Validate("Failed to create inference configuration");
        }

        /// <summary>
        /// Loads inference model data and its related attributes.
        /// </summary>
        /// <remarks>
        /// Before calling this method, user should set all properties which is required by each inference model.<br/>
        /// The properties set after calling this method will not be affected in the result.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage</privilege>
        /// <feature>http://tizen.org/feature/vision.inference.face</feature>
        /// <feature>http://tizen.org/feature/vision.inference.image</feature>
        /// <exception cref="FileNotFoundException">
        /// <see cref="ConfigurationFilePath"/>, <see cref="WeightFilePath"/> or <see cref="CategoryFilePath"/> have invalid path.
        /// </exception>
        /// <exception cref="FileFormatException">Invalid data type is used in inference model data.</exception>
        /// <exception cref="InvalidDataException">
        /// Inference model data contains unsupported operations in current backend version.
        /// -or-<br/>
        /// Invalid data type is used in inference model data.<br/>
        /// </exception>
        /// <exception cref="InvalidOperationException">Internal operation error.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller has no required privilege.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void LoadInferenceModel()
        {
            InteropInference.Configure(_inferenceHandle, GetHandle(this)).
                Validate("Failed to configure inference model.");

            var ret = InteropInference.Load(_inferenceHandle);
            if (ret == MediaVisionError.InvalidData)
            {
                throw new InvalidDataException("Inference model data contains unsupported operations in current backend version.");
            }
            else if (ret == MediaVisionError.NotSupportedFormat)
            {
                throw new FileFormatException("Invalid data type is used in inference model data.");
            }
            ret.Validate("Failed to load inference model.");
        }

        internal IntPtr GetHandle()
        {
            return _inferenceHandle;
        }

        private IEnumerable<InferenceBackendType> _supportedBackend;

        /// <summary>
        /// Gets the list of inference backend engine which is supported in the current device.
        /// </summary>
        /// <returns>If there's no supported backend, empty collection will be returned.</returns>
        /// <since_tizen> 6 </since_tizen>
        public IEnumerable<InferenceBackendType> SupportedBackend
        {
            get
            {
                if (_supportedBackend == null)
                {
                    GetSupportedBackend();
                }

                return _supportedBackend.Any() ? _supportedBackend : Enumerable.Empty<InferenceBackendType>();
            }
        }

        private void GetSupportedBackend()
        {
            var supportedBackend = new List<InferenceBackendType>();

            InteropInference.SupportedBackendCallback cb = (backend, isSupported, _) =>
            {
                if (isSupported && backend != null)
                {
                    switch (backend)
                    {
                        case _backendTypeOpenCV:
                            supportedBackend.Add(InferenceBackendType.OpenCV);
                            break;
                        case _backendTypeTFLite:
                            supportedBackend.Add(InferenceBackendType.TFLite);
                            break;
                        case _backendTypeArmNN:
                            supportedBackend.Add(InferenceBackendType.ArmNN);
                            break;
                        case _backendTypeMLApi:
                            supportedBackend.Add(InferenceBackendType.MLApi);
                            break;
                        case _backendTypeOne:
                            supportedBackend.Add(InferenceBackendType.One);
                            break;
                    }
                }

                return true;
            };

            InteropInference.ForeachSupportedBackend(_inferenceHandle, cb, IntPtr.Zero).
                Validate("Failed to get supported backend");

            _supportedBackend = supportedBackend;
        }

        /// <summary>
        /// Gets or sets the path of inference model's configuration data file.
        /// </summary>
        /// <exception cref="ArgumentNullException">Input file path is null.</exception>
        /// <since_tizen> 6 </since_tizen>
        public string ConfigurationFilePath
        {
            get
            {
                return GetString(_keyModelConfigurationFilePath);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "File path is null.");
                }

                Set(_keyModelConfigurationFilePath, value);
            }
        }

        /// <summary>
        /// Gets or sets the path of inference model's weight file.
        /// </summary>
        /// <exception cref="ArgumentNullException">Input file path is null.</exception>
        /// <since_tizen> 6 </since_tizen>
        public string WeightFilePath
        {
            get
            {
                return GetString(_keyModelWeightFilePath);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "File path is null.");
                }

                Set(_keyModelWeightFilePath, value);
            }
        }

        /// <summary>
        /// Gets or sets the path of inference model's category file.
        /// </summary>
        /// <remarks>
        /// This value should be set to use <see cref="ImageClassifier"/> or <see cref="ObjectDetector"/>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Input file path is null.</exception>
        /// <since_tizen> 6 </since_tizen>
        public string CategoryFilePath
        {
            get
            {
                return GetString(_keyModelUserFilePath);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "File path is null.");
                }

                Set(_keyModelUserFilePath, value);
            }
        }

        /// <summary>
        /// Gets or sets the path of inference model's metadata file.
        /// </summary>
        /// <remarks>
        /// This value should be set to use <see cref="ImageClassifier"/> or <see cref="ObjectDetector"/>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Metadata file path is null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public string MetadataFilePath
        {
            get
            {
                return GetString(_keyMetadataFilePath);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "File path is null.");
                }

                Set(_keyMetadataFilePath, value);
            }
        }

        /// <summary>
        /// Gets or sets the inference model's mean value.
        /// </summary>
        /// <remarks>It should be greater than or equal to 0.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">The value is invalid.</exception>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated since API9; Will be removed in API11. Please use MetadataFilePath instead.")]
        public double MeanValue
        {
            get
            {
                return GetDouble(_keyModelMeanValue);
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        $"Value should be greater than or equal to 0");
                }

                Set(_keyModelMeanValue, value);
            }
        }

        /// <summary>
        /// Gets or sets the inference model's STD(Standard deviation) value.
        /// </summary>
        /// <remarks>It should be greater than or equal to 0.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">The value is invalid.</exception>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated since API9; Will be removed in API11. Please use MetadataFilePath instead.")]
        public double StdValue
        {
            get
            {
                return GetDouble(_keyModelStdValue);
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        $"Value should be greater than or equal to 0");
                }

                Set(_keyModelStdValue, value);
            }
        }

        /// <summary>
        /// Gets or sets the inference model's backend engine.
        /// </summary>
        /// <remarks>The default backend type is <see cref="InferenceBackendType.OpenCV"/></remarks>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not valid.</exception>
        /// <exception cref="NotSupportedException">The engine type is not supported.</exception>
        /// <seealso cref="SupportedBackend"/>
        /// <since_tizen> 6 </since_tizen>
        public InferenceBackendType Backend
        {
            get
            {
                return (InferenceBackendType)GetInt(_keyBackendType);
            }
            set
            {
                ValidationUtil.ValidateEnum(typeof(InferenceBackendType), value, nameof(Backend));

                if (!SupportedBackend.Contains(value))
                {
                    throw new NotSupportedException("Not supported engine type. " +
                        "Please check supported engine using 'SupportedBackendType'.");
                }

                Set(_keyBackendType, (int)value);
            }
        }

        /// <summary>
        /// Gets or sets the inference model's target.
        /// </summary>
        /// <remarks>
        /// The default target is <see cref="InferenceTargetType.CPU"/>.<br/>
        /// If target doesn't support <see cref="InferenceTargetType.GPU"/> and <see cref="InferenceTargetType.Custom"/>,
        /// <see cref="InferenceTargetType.CPU"/> will be used internally, despite the user's choice.
        /// </remarks>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not valid.</exception>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated since API8; Will be removed in API10. Please use Device instead.")]
        public InferenceTargetType Target
        {
            get
            {
                return (InferenceTargetType)GetInt(_keyTargetType);
            }
            set
            {
                ValidationUtil.ValidateEnum(typeof(InferenceTargetType), value, nameof(Target));

                Set(_keyTargetType, (int)value);
            }
        }

        /// <summary>
        /// Gets or sets the processor type for inference models.
        /// </summary>
        /// <remarks>
        /// The default device is <see cref="InferenceTargetDevice.CPU"/>.<br/>
        /// If a device doesn't support <see cref="InferenceTargetDevice.GPU"/> and <see cref="InferenceTargetDevice.Custom"/>,
        /// <see cref="InferenceTargetDevice.CPU"/> will be used internally, despite the user's choice.
        /// </remarks>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not valid.</exception>
        /// <since_tizen> 8 </since_tizen>
        public InferenceTargetDevice Device
        {
            get
            {
                return (InferenceTargetDevice)GetInt(_keyTargetDeviceType);
            }
            set
            {
                ValidationUtil.ValidateEnum(typeof(InferenceTargetDevice), value, nameof(Device));

                Set(_keyTargetDeviceType, (int)value);
            }
        }

        /// <summary>
        /// Gets or sets the size of inference model's tensor.
        /// </summary>
        /// <remarks>
        /// Both width and height of tensor should be greater than 0.<br/>
        /// 'Size(-1, -1) is allowed when the intention is to use original image source size as TensorSize.
        /// </remarks>
        /// <exception cref="ArgumentException">
        /// Only one of <paramref name="value.Width"/> or <paramref name="value.Height"/> have -1.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The value is invalid.</exception>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated since API9; Will be removed in API11. Please use MetadataFilePath instead.")]
        public Size TensorSize
        {
            get
            {
                var width = GetInt(_keyInputTensorWidth);
                var height = GetInt(_keyInputTensorHeight);

                return new Size(width, height);
            }
            set
            {
                if ((value.Width == -1 && value.Height != -1) || (value.Height == -1 && value.Width != -1))
                {
                    throw new ArgumentException("Both width and height must be set to -1, or greater than 0.");
                }

                if (value.Width == 0 || value.Width <= -2)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        "Both width and height must be set to -1, or greater than 0.");
                }

                if (value.Height == 0 || value.Height <= -2)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        "Both width and height must be set to -1, or greater than 0.");
                }

                Set(_keyInputTensorWidth, value.Width);
                Set(_keyInputTensorHeight, value.Height);
            }
        }

        /// <summary>
        /// Gets or sets the number of inference model's tensor channel.
        /// </summary>
        /// <remarks>
        /// For example, for RGB colorspace this value should be set to 3<br/>
        /// It should be greater than 0.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">The value is invalid.</exception>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated since API9; Will be removed in API11. Please use MetadataFilePath instead.")]
        public int TensorChannels
        {
            get
            {
                return GetInt(_keyInputTensorChannels);
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Tensor channel should be greater than 0.");
                }

                Set(_keyInputTensorChannels, value);
            }
        }

        /// <summary>
        /// Gets or sets the type of data used for inference model.
        /// </summary>
        /// <remarks>
        /// For example, this value should be set to <see cref="InferenceDataType.Float32"/> for a model data supporting float32.<br/>
        /// <see cref="InferenceDataType.Float32"/> will be used internally if a user doesn't set the value.
        /// </remarks>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not valid.</exception>
        /// <since_tizen> 8 </since_tizen>
        [Obsolete("Deprecated since API9; Will be removed in API11. Please use MetadataFilePath instead.")]
        public InferenceDataType DataType
        {
            get
            {
                return (InferenceDataType)GetInt(_keyDataType);
            }
            set
            {
                ValidationUtil.ValidateEnum(typeof(InferenceDataType), value, nameof(DataType));

                Set(_keyDataType, (int)value);
            }
        }

        /// <summary>
        /// Gets or sets the name of an input node
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated since API9; Will be removed in API11. Please use MetadataFilePath instead.")]
        public string InputNodeName
        {
            get
            {
                return GetString(_keyInputNodeName);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "InputNodeName can't be null.");
                }

                Set(_keyInputNodeName, value);
            }
        }

        /// <summary>
        /// Gets or sets the name of an output node
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated since API9; Will be removed in API11. Please use MetadataFilePath instead.")]
        public IList<string> OutputNodeName
        {
            get
            {
                return GetStringArray(_keyOutputNodeNames);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "OutputNodeName can't be null.");
                }

                var name = new string[value.Count];
                value.CopyTo(name, 0);
                Set(_keyOutputNodeNames, name);
            }
        }

        /// <summary>
        /// Gets or sets the maximum output number of detection or classification.
        /// </summary>
        /// <remarks>
        /// The input value over 10 will be set to 10 and the input value under 1 will be set to 1.<br/>
        /// This value can be used to decide the size of <see cref="Roi"/>, it's length should be the same.
        /// </remarks>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated since API9; Will be removed in API11. Please use MetadataFilePath instead.")]
        public int MaxOutputNumber
        {
            get
            {
                return GetInt(_keyOutputMaxNumber);
            }
            set
            {
                Set(_keyOutputMaxNumber, value > 10 ? 10 : value < 1 ? 1 : value);
            }
        }

        /// <summary>
        /// Gets or sets the threshold of confidence.
        /// </summary>
        /// <remarks>
        /// The vaild range is greater than or equal to 0.0 and less than or equal to 1.0.<br/>
        /// The value 1.0 means maximum accuracy.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/>is out of range.</exception>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated since API9; Will be removed in API11. Please use MetadataFilePath instead.")]
        public double ConfidenceThreshold
        {
            get
            {
                return GetDouble(_keyConfidenceThreshold);
            }
            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        "Confidence threshold should be greater than or equal to 0.0.");
                }
                if (value > 1.0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        "Confidence threshold should be less than or equal to 1.0.");
                }

                Set(_keyConfidenceThreshold, value);
            }
        }

        private Rectangle? _roi;

        /// <summary>
        /// Gets or sets the ROI(Region Of Interest) of <see cref="ImageClassifier"/> and <see cref="FacialLandmarkDetector"/>
        /// </summary>
        /// <remarks>
        /// Default value is null. If Roi is null, the entire region of <see cref="MediaVisionSource"/> will be analyzed.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The width of <paramref name="value"/> is less than or equal to zero.<br/>
        ///     -or-<br/>
        ///     The height of <paramref name="value"/> is less than or equal to zero.<br/>
        ///     -or-<br/>
        ///     The x position of <paramref name="value"/> is less than zero.<br/>
        ///     -or-<br/>
        ///     The y position of <paramref name="value"/> is less than zero.
        /// </exception>
        /// <seealso cref="MaxOutputNumber"/>
        /// <since_tizen> 6 </since_tizen>
        public Rectangle? Roi
        {
            get
            {
                return _roi;
            }
            set
            {
                if (value != null)
                {
                    ValidateRoi(value.Value);
                    _roi = value;
                }
            }
        }

        private static void ValidateRoi(Rectangle roi)
        {
            if (roi.Width <= 0)
            {
                throw new ArgumentOutOfRangeException("Roi.Width", roi.Width,
                    "The width of roi can't be less than or equal to zero.");
            }

            if (roi.Height <= 0)
            {
                throw new ArgumentOutOfRangeException("Roi.Height", roi.Height,
                    "The height of roi can't be less than or equal to zero.");
            }

            if (roi.X < 0)
            {
                throw new ArgumentOutOfRangeException("Roi.X", roi.X,
                    "The x position of roi can't be less than zero.");
            }

            if (roi.Y < 0)
            {
                throw new ArgumentOutOfRangeException("Roi.Y", roi.Y,
                    "The y position of roi can't be less than zero.");
            }
        }

        /// <summary>
        /// Releases the resources used by the <see cref="InferenceModelConfiguration"/> object.
        /// </summary>
        /// <param name="disposing">
        /// true to release both managed and unmanaged resources, otherwise false to release only unmanaged resources.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (_inferenceHandle != IntPtr.Zero)
            {
                InteropInference.Destroy(_inferenceHandle).Validate("Failed to destroy inference configuration");
                _inferenceHandle = IntPtr.Zero;
            }
        }
    }
}
