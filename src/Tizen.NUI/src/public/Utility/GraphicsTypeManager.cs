/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.ComponentModel;
using System.Globalization;

namespace Tizen.NUI
{
    /// <summary>
    /// GraphicsTypeManager class to manage various types.
    /// </summary>
    /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class GraphicsTypeManager
    {
        private volatile static GraphicsTypeManager graphicsTypeManager;
        private DpTypeConverter dp;
        private SpTypeConverter sp;
        private PointTypeConverter pt;
        private float scalingFactor = 1.0f;
        private int baselineDpi = DensityMedium;

        /// <summary>
        /// Constant of low(120) density dpi.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const ushort DensityLow = 120;

        /// <summary>
        /// Constant of medium(160) density dpi. Baseline dpi.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const ushort DensityMedium = 160;

        /// <summary>
        /// Constant of high(240) density dpi.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const ushort DensityHigh = 240;

        /// <summary>
        /// Constant of extra high(320) density dpi.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const ushort DensityXHigh = 320;

        /// <summary>
        /// Constant of double extra high(480) density dpi.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const ushort DensityXXHigh = 480;

        /// <summary>
        /// Constant of triple extra high(640) density dpi.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const ushort DensityXXXHigh = 640;

        /// <summary>
        /// Custom scale factor of display metrics.
        /// ScalingFactor scale ScaledDpi on Dpi.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ScalingFactor
        {
            get => scalingFactor;
            internal set => scalingFactor = value;
        }

        /// <summary>
        /// Dot per Inch value from system.
        /// See Vector Dpi in <see cref="Tizen.NUI.Window" /> also.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Dpi
        {
            get
            {
               Vector2 screenDpi = NUIApplication.GetDefaultWindow().Dpi;

               // Currently Dpi.X and Dpi.Y is all same value from ecore_wl2_output_dpi_get
               // Also Diagonal Dpi should be same as X, Y Dpi in normal rectangle-pixels display
               // so for the convenience, we use Dpi.X
               return Convert.ToInt32(Math.Round(screenDpi.X));
            }
        }

        /// <summary>
        /// Scaled Dpi for GraphicsTypeManager.
        /// ScaledDpi is scaled from Dpi with custom ScalingFactor.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int ScaledDpi
        {
            get
            {
                return Convert.ToInt32(Math.Round(Dpi * ScalingFactor));
            }
        }

        /// <summary>
        /// Default baseline dpi. Medium(160) density dpi is origianlly provided.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int BaselineDpi
        {
            get => baselineDpi;
            internal set
            {
                baselineDpi = value;
            }
        }

        /// <summary>
        /// Density of display.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Density
        {
            get => ((float)Dpi / (float)BaselineDpi);
        }

        /// <summary>
        /// Scaled Density of display.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ScaledDensity
        {
            get => ((float)ScaledDpi / (float)BaselineDpi);
        }

        /// <summary>
        /// An unique Singleton Instance of GraphicsTypeManager
        /// </summary>
        /// <value>Singleton instance of GraphicsTypeManager</value>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static GraphicsTypeManager Instance
        {
            get
            {
                if (graphicsTypeManager == null)
                {
                    graphicsTypeManager = new GraphicsTypeManager();
                }

                return graphicsTypeManager;
            }
        }

        /// <summary>
        /// Default DpTypeConverter. use this Converter to convert Dp to/from other types.
        /// See <see cref="Tizen.NUI.DpTypeConverter" />.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DpTypeConverter Dp
        {
            get
            {
                return dp;
            }
            set
            {
                dp = value;
            }
        }


        /// <summary>
        /// Default SpTypeConverter. use this Converter to convert Sp to/from other types.
        /// See <see cref="Tizen.NUI.SpTypeConverter" />.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SpTypeConverter Sp
        {
            get
            {
                return sp;
            }
            set
            {
                sp = value;
            }
        }


        /// <summary>
        /// Default PointTypeConverter. use this Converter to convert Point to/from other types.
        /// See <see cref="Tizen.NUI.PointTypeConverter" />.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PointTypeConverter Point
        {
            get
            {
                return pt;
            }
            set
            {
                pt = value;
            }
        }

        /// <summary>
        /// Creates private GraphicsTypeManager object.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        private GraphicsTypeManager()
        {
            // Get default type converter
            dp = DpTypeConverter.Instance;
            sp = SpTypeConverter.Instance;
            pt = PointTypeConverter.Instance;

            // Get ScalingFactor.
            // FIXME: We need to get ScalingFactor from System.Information model-config firstly.
            var scaleEnv = System.Environment.GetEnvironmentVariable("NUI_SCALING_FACTOR");
            if (scaleEnv != null)
            {
                float scaled = 1.0f;
                if (float.TryParse(scaleEnv, NumberStyles.Any, CultureInfo.InvariantCulture, out scaled))
                {
                    ScalingFactor = scaled;
                }
            }
        }

        /// <summary>
        /// Converts script to pixel.
        /// </summary>
        /// <returns>Pixel value that is converted from input string</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ConvertScriptToPixel(string scriptValue)
        {
            float convertedValue = 0;
            if (scriptValue != null)
            {
                if (scriptValue.EndsWith("dp"))
                {
                    convertedValue = Dp.ConvertScriptToPixel(scriptValue);
                }
                else if (scriptValue.EndsWith("sp"))
                {
                    convertedValue = Sp.ConvertScriptToPixel(scriptValue);
                }
                else if (scriptValue.EndsWith("pt"))
                {
                    convertedValue = Point.ConvertScriptToPixel(scriptValue);
                }
                else if (scriptValue.EndsWith("px"))
                {
                    convertedValue = float.Parse(scriptValue.Substring(0, scriptValue.LastIndexOf("px")), CultureInfo.InvariantCulture);
                }
                else
                {
                    if (!float.TryParse(scriptValue, NumberStyles.Any, CultureInfo.InvariantCulture, out convertedValue))
                    {
                        NUILog.Error("Cannot convert the script {scriptValue}\n");
                        convertedValue = 0;
                    }
                }
            }
            return convertedValue;
        }


        internal void RegisterCustomConverterForDynamicResourceBinding(global::System.Type type, Tizen.NUI.Binding.TypeConverter userConverter)
        {
            if (Tizen.NUI.Binding.BindableProperty.UserCustomConvertTypes.ContainsKey(type) == false)
            {
                Tizen.NUI.Binding.BindableProperty.UserCustomConvertTypes.Add(type, userConverter);
            }
            //NUILog.Error($"user custom converter ditionary count={Tizen.NUI.Binding.BindableProperty.UserCustomConvertTypes.Count}");
        }
    }
}
