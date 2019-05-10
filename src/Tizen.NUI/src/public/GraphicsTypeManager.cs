/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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

        /// <summary>
        /// Creates private GraphicsTypeManager object.
        /// </summary>
        private GraphicsTypeManager()
        {
            _typeConverter = new GraphicsTypeConverter();
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
                if (_graphicsTypeManager == null)
                {
                    _graphicsTypeManager = new GraphicsTypeManager();
                }

                return _graphicsTypeManager;
            }

        }

        /// <summary>
        /// Sets the custom GraphicsTypeConverter.
        /// </summary>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTypeConverter(GraphicsTypeConverter typeConverter)
        {
            _typeConverter = typeConverter;
        }

        /// <summary>
        /// Converts script to px
        /// </summary>
        /// <returns>Pixel value that is converted from input string</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ConvertScriptToPixel(string scriptValue)
        {
            return _typeConverter.ConvertScriptToPixel(scriptValue);
        }

        /// <summary>
        /// Converts other type to px
        /// </summary>
        /// <returns>Pixel value that is converted by the the display matric</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual float ConvertToPixel(float value)
        {
            return _typeConverter.ConvertToPixel(value);
        }

        /// <summary>
        /// Converts px to other type
        /// </summary>
        /// <returns>An converted value from pixel</returns>
        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual float ConvertFromPixel(float value)
        {
            return _typeConverter.ConvertFromPixel(value);
        }

        internal void RegisterCustomConverterForDynamicResourceBinding(global::System.Type type, Tizen.NUI.Binding.TypeConverter userConverter)
        {
            if (Tizen.NUI.Binding.BindableProperty.UserCustomConvertTypes.ContainsKey(type) == false)
            {
                Tizen.NUI.Binding.BindableProperty.UserCustomConvertTypes.Add(type, userConverter);
            }
            //NUILog.Error($"user custom converter ditionary count={Tizen.NUI.Binding.BindableProperty.UserCustomConvertTypes.Count}");
        }

        private volatile static GraphicsTypeManager _graphicsTypeManager;
        private GraphicsTypeConverter _typeConverter;
    }

}