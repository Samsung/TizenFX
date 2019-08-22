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
using System.IO;
using System.Collections.Generic;
using InteropInference = Interop.MediaVision.Inference;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Represents a configuration of <see cref="InferenceModelConfiguration"/> instances.
    /// </summary>
    /// <remarks>
    /// 'Inference model' means pre-learned data, which represents by <see cref="ConfigurationFilePath"/> and
    /// <see cref="WeightFilePath"/>, <see cref="CategoryFilePath"/>.<br/>
    /// If user doesn't set any property, the default model and its related values will be used internally.<br/>
    /// But, if user set inference model, user should set proper value for the selected inference model.
    /// </remarks>
    /// <feature>http://tizen.org/feature/vision.inference</feature>
    /// <since_tizen> 6 </since_tizen>
    public class InferenceModelConfiguration : EngineConfiguration
    {
        private IntPtr _inferenceHandle = IntPtr.Zero;

        private const string _keyModelConfigurationFilePath = "MV_INFERENCE_MODEL_CONFIGURATION_FILE_PATH";
        private const string _keyModelWeightFilePath = "MV_INFERENCE_MODEL_WEIGHT_FILE_PATH";
        private const string _keyModelUserFilePath = "MV_INFERENCE_MODEL_USER_FILE_PATH";
        private const string _keyModelMeanValue = "MV_INFERENCE_MODEL_MEAN_VALUE";
        private const string _keyModelStdValue = "MV_INFERENCE_MODEL_STD_VALUE";
        private const string _keyBackendType = "MV_INFERENCE_BACKEND_TYPE";
        private const string _keyTargetType = "MV_INFERENCE_TARGET_TYPE";
        private const string _keyInputTensorWidth = "MV_INFERENCE_INPUT_TENSOR_WIDTH";
        private const string _keyInputTensorHeight = "MV_INFERENCE_INPUT_TENSOR_HEIGHT";
        private const string _keyInputTensorChannels = "MV_INFERENCE_INPUT_TENSOR_CHANNELS";
        private const string _keyInputNodeName = "MV_INFERENCE_INPUT_NODE_NAME";
        private const string _keyOutputNodeNames = "MV_INFERENCE_OUTPUT_NODE_NAMES";
        private const string _keyOutputMaxNumvers = "MV_INFERENCE_OUTPUT_MAX_NUMBERS";
        private const string _keyConfidenceThreshold = "MV_INFERENCE_CONFIDENCE_THRESHOLD";

        // The following strings are fixed in native and will not be changed.
        private const string _backendTypeOpenCV = "opencv";
        private const string _backendTypeTFLite = "tflite";

        /// <summary>
        /// Initializes a new instance of the <see cref="InferenceModelConfiguration"/> class.
        /// </summary>
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
        /// User should set all required properties of this class before calling this method.<br/>
        /// The properties set after calling this method will not be affected in the result.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage</privilege>
        /// <feature>http://tizen.org/feature/vision.inference</feature>
        /// <exception cref="FileNotFoundException">
        /// <see cref="ConfigurationFilePath"/>, <see cref="WeightFilePath"/> or <see cref="CategoryFilePath"/> have invalid path.
        /// </exception>
        /// <exception cref="FileFormatException">Inference model data is not valid</exception>
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
            var ret = InteropInference.Configure(_inferenceHandle, GetHandle(this));
            if (ret == MediaVisionError.NotSupportedFormat)
            {
                throw new FileFormatException("Inference model data is not valid.");
            }
            ret.Validate("Failed to configure inference model.");

            ret = InteropInference.Load(_inferenceHandle);
            if (ret == MediaVisionError.InvalidData)
            {
                throw new InvalidDataException("Inference model data contains unsupported operations in current backend version.");
            }
            else if (ret == MediaVisionError.NotSupportedFormat)
            {
                throw new InvalidDataException("Invalid data type is used in inference model data.");
            }
            ret.Validate("Failed to load inference model.");
        }

        internal IntPtr GetHandle()
        {
            return _inferenceHandle;
        }

        private IList<InferenceBackendType> _supportedBackend;

        /// <summary>
        /// Gets the list of inference backend engine which is supported in the current device.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public IList<InferenceBackendType> SupportedBackendType
        {
            get
            {
                if (_supportedBackend == null)
                {
                    GetSupportedBackend();
                }

                return _supportedBackend;
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
                    }
                }

                return true;
            };

            InteropInference.ForeachSupportedBackend(_inferenceHandle, cb, IntPtr.Zero).
                Validate("Failed to get supported backend");

            _supportedBackend = supportedBackend.AsReadOnly();
        }

        /// <summary>
        /// Gets or sets the path of inference model's configuration data file.
        /// </summary>
        /// <remarks>If user don't set this property, the default data will be used.</remarks>
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
        /// <remarks>If user don't set this property, the default data will be used.</remarks>
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
        /// If user don't set this property, the default data will be used.<br/>
        /// <br/>
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
        /// Gets or sets the inference model's mean value.
        /// </summary>
        /// <remarks>
        /// The default value is 127.5.<br/>
        /// It should be greater than 0.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">The value is invalid.</exception>
        /// <since_tizen> 6 </since_tizen>
        public double MeanValue
        {
            get
            {
                return GetDouble(_keyModelMeanValue);
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        $"Value should be greater than 0");
                }

                Set(_keyModelMeanValue, value);
            }
        }

        /// <summary>
        /// Gets or sets the inference model's STD(Standard deviation) value.
        /// </summary>
        /// <remarks>
        /// The default value is 1.0.<br/>
        /// It should be greater than 0.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">The value is invalid.</exception>
        /// <since_tizen> 6 </since_tizen>
        public double StdValue
        {
            get
            {
                return GetDouble(_keyModelStdValue);
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        $"Value can not be equal or less than 0");
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
        /// <seealso cref="SupportedBackendType"/>
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

                if (!SupportedBackendType.Contains(value))
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
        /// Even if user set <see cref="InferenceTargetType.GPU"/> or <see cref="InferenceTargetType.Custom"/>,<br/>
        /// if target doesn't support it, <see cref="InferenceTargetType.CPU"/> will be used internally.
        /// </remarks>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not valid.</exception>
        /// <since_tizen> 6 </since_tizen>
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
        /// Gets or sets the size of inference model's tensor.
        /// </summary>
        /// <remarks>Both width and height of tensor should be greater than 0.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">The value is invalid.</exception>
        /// <since_tizen> 6 </since_tizen>
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
                if (value.Width <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Width should be greater than 0.");
                }
                if (value.Height <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Height should be greater than 0.");
                }

                Set(_keyInputTensorWidth, value.Width);
                Set(_keyInputTensorHeight, value.Height);
            }
        }

        /// <summary>
        /// Gets or sets the number of inference model's tensor channel.
        /// </summary>
        /// <remarks>
        /// For example, in case of RGB colorspace, this value can be set by 3.<br/>
        /// It should be greater than 0.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">The value is invalid.</exception>
        /// <since_tizen> 6 </since_tizen>
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
        /// Gets or sets the name of input node
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <since_tizen> 6 </since_tizen>
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
        /// Gets or sets the name of output node
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <since_tizen> 6 </since_tizen>
        public string[] OutputNodeName
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

                Set(_keyOutputNodeNames, value);
            }
        }

        /// <summary>
        /// Gets or sets the maximum output number of detection or classification.
        /// </summary>
        /// <remarks>
        /// The default value is 5.<br/>
        /// The input value over 10 will be set to 10 and the input value under 1 will be set to 1.
        /// </remarks>
        /// <since_tizen> 6 </since_tizen>
        public int MaxOutputNumber
        {
            get
            {
                return GetInt(_keyOutputMaxNumvers);
            }
            set
            {
                Set(_keyOutputMaxNumvers, value);
            }
        }

        /// <summary>
        /// Gets or sets the threshold of confidence.
        /// </summary>
        /// <remarks>
        /// The default value is 0.6.<br/>
        /// The vaild range is greater than or equal to 0.0 and less than or equal to 1.0.<br/>
        /// The value 1.0 means maximum accuracy.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/>is out of range.</exception>
        /// <since_tizen> 6 </since_tizen>
        public double ConfidenceThreshold
        {
            get
            {
                return GetInt(_keyConfidenceThreshold);
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
