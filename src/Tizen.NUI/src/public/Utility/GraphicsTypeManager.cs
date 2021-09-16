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
        private GraphicsTypeConverter typeConverter;
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
        /// ScalingFactor scale Dpi on DpiStable.
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
        /// Dpi for GraphicsTypeManager.
        /// Dpi is scaled from Dpi with custom ScalingFactor.
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
        /// GraphicsTypeConverter that manager internally use for type converting.
        /// Default TypeConverter is DpTypeConverter.
        /// See <see cref="Tizen.NUI.GraphicsTypeConverter" /> and <see cref="Tizen.NUI.DpTypeConverter" />.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GraphicsTypeConverter TypeConverter
        {
            get
            {
                return typeConverter;
            }
            set
            {
                typeConverter = value;
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
            typeConverter = DpTypeConverter.Instance;
        }

        /// <summary>
        /// Converts script to px
        /// </summary>
        /// <returns>Pixel value that is converted from input string</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ConvertScriptToPixel(string scriptValue)
        {
            return typeConverter.ConvertScriptToPixel(scriptValue);
        }

        /// <summary>
        /// Converts other type to px
        /// </summary>
        /// <returns>Pixel value that is converted by the the display matric</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual float ConvertToPixel(float value)
        {
            return typeConverter.ConvertToPixel(value);
        }

        /// <summary>
        /// Converts px to other type
        /// </summary>
        /// <returns>An converted value from pixel</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual float ConvertFromPixel(float value)
        {
            return typeConverter.ConvertFromPixel(value);
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
