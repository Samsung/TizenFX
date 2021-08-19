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

extern alias TizenSystemInformation;
using TizenSystemInformation.Tizen.System;
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
        private float scaleFactor = 1.0f;
        private static int defaultDensityDpi = DensityMedium;

        /// <summary>
        /// Constant of low(120) density dpi.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const int DensityLow = 120;

        /// <summary>
        /// Constant of mkedium(160) density dpi. Default dpi.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const int DensityMedium = 160;

        /// <summary>
        /// Constant of high(240) density dpi.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const int DensityHigh = 240;

        /// <summary>
        /// Constant of extra high(320) density dpi.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const int DensityXHigh = 320;

        /// <summary>
        /// Constant of double extra high(480) density dpi.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const int DensityXXHigh = 480;

        /// <summary>
        /// Constant of triple extra high(640) density dpi.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const int DensityXXXHigh = 640;

        /// <summary>
        /// Custom scale factor of display metrics.
        /// ScaleFactor scale Dpi on DpiStable.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ScaleFactor
        {
            get => scaleFactor;
            internal set => scaleFactor = value;
        }

        /// <summary>
        /// Stable dpi value from system.
        /// See Vector Dpi in <see cref="Tizen.NUI.Window" /> also.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int DpiStable
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
        /// Dpi is scaled from DpiStable with custom ScaleFactor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int Dpi
        {
            get
            {
                return Convert.ToInt32(Math.Round(DpiStable * GraphicsTypeManager.Instance.ScaleFactor));
            }
        }

        /// <summary>
        /// Default dpi. Medium(160) density dpi is origianlly provided.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int DefaultDpi
        {
            get => defaultDensityDpi;
            internal set
            {
                defaultDensityDpi = value;
            }
        }

        /// <summary>
        /// Density of display.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float Density
        {
            get => ((float)DefaultDpi / (float)Dpi);
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
        /// Creates private GraphicsTypeManager object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private GraphicsTypeManager()
        {
            // Get default type converter
            typeConverter = new DpTypeConverter();
        }


        /// <summary>
        /// Sets the custom GraphicsTypeConverter.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTypeConverter(GraphicsTypeConverter typeConverter)
        {
            this.typeConverter = typeConverter;
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
