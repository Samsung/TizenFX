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
#if !PROFILE_TV

using System.Diagnostics.CodeAnalysis;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    internal partial class DefaultThemeCreator
    {
        /// <summary>
        /// The base theme description.
        /// </summary>
        [SuppressMessage("Microsoft.Reliability", "CA2000: Dispose objects before losing scope", Justification = "The responsibility to dispose the object is transferred to the theme object.")]
        public Theme Create()
        {
            Theme theme = new Theme()
            {
                Id = DefaultId,
                Version = DefaultVersion,
            };

            // TextLabel style.
            theme.AddStyleWithoutClone("Tizen.NUI.BaseComponents.TextLabel", new TextLabelStyle()
            {
                FontFamily = "TizenSans",
                PixelSize = 24,
                TextColor = new Color(0.04f, 0.05f, 0.13f, 1),
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("regular")),
            });

            // TextField style.
            theme.AddStyleWithoutClone("Tizen.NUI.BaseComponents.TextField", new TextFieldStyle()
            {
                FontFamily = "TizenSans",
                PixelSize = 24,
                TextColor = new Color(0.04f, 0.05f, 0.13f, 1),
                PlaceholderTextColor = new Vector4(0.79f, 0.79f, 0.79f, 1),
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("regular")),
                PrimaryCursorColor = new Vector4(0.04f, 0.05f, 0.13f, 1),
                SecondaryCursorColor = new Vector4(0.04f, 0.05f, 0.13f, 1),
                CursorWidth = 2,
                SelectionHighlightColor = new Vector4(1.00f, 0.38f, 0.00f, 0.30f),
                GrabHandleColor = new Color(1.00f, 1.00f, 1.00f, 1),
                GrabHandleImage = FrameworkInformation.ResourcePath + "IoT_handler_center_downW.png",
                SelectionHandleImageLeft = new PropertyMap().Add("filename", new PropertyValue(FrameworkInformation.ResourcePath + "IoT_handler_downleftW.png")),
                SelectionHandleImageRight = new PropertyMap().Add("filename", new PropertyValue(FrameworkInformation.ResourcePath + "IoT_handler_downrightW.png")),
            });

            // TextEditor style.
            theme.AddStyleWithoutClone("Tizen.NUI.BaseComponents.TextEditor", new TextEditorStyle()
            {
                FontFamily = "TizenSans",
                PixelSize = 24,
                TextColor = new Color(0.04f, 0.05f, 0.13f, 1),
                PlaceholderTextColor = new Color(0.79f, 0.79f, 0.79f, 1),
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("regular")),
                PrimaryCursorColor = new Vector4(0.04f, 0.05f, 0.13f, 1),
                SecondaryCursorColor = new Vector4(0.04f, 0.05f, 0.13f, 1),
                CursorWidth = 2,
                SelectionHighlightColor = new Vector4(1.00f, 0.38f, 0.00f, 0.30f),
                GrabHandleColor = new Color(1.00f, 1.00f, 1.00f, 1),
                GrabHandleImage = FrameworkInformation.ResourcePath + "IoT_handler_center_downW.png",
                SelectionHandleImageLeft = new PropertyMap().Add("filename", new PropertyValue(FrameworkInformation.ResourcePath + "IoT_handler_downleftW.png")),
                SelectionHandleImageRight = new PropertyMap().Add("filename", new PropertyValue(FrameworkInformation.ResourcePath + "IoT_handler_downrightW.png")),
            });

            return theme;
        }
    }
}

#endif // !PROFILE_TV
