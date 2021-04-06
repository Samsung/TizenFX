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
                FontFamily = "BreezeSans",
                PixelSize = 32,
                TextColor = new Color(0.00f, 0.05f, 0.17f, 1),
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("light")),
            });

            // TextField style.
            theme.AddStyleWithoutClone("Tizen.NUI.BaseComponents.TextField", new TextFieldStyle()
            {
                FontFamily = "BreezeSans",
                PixelSize = 32,
                TextColor = new Color(0.00f, 0.05f, 0.17f, 1),
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("regular")),
                PrimaryCursorColor = new Vector4(0.08f, 0.45f, 0.90f, 1),
                SecondaryCursorColor = new Vector4(0.08f, 0.45f, 0.90f, 1),
                CursorWidth = 3,
                SelectionHighlightColor = new Vector4(0.17f, 0.37f, 0.72f, 0.20f),
                GrabHandleColor = new Color(0.08f, 0.45f, 0.90f, 1),
                GrabHandleImage = FrameworkInformation.ResourcePath + "IoT_handler_center_downW.png",
                SelectionHandleImageLeft = new PropertyMap().Add("filename", new PropertyValue(FrameworkInformation.ResourcePath + "IoT_handler_downleftW.png")),
                SelectionHandleImageRight = new PropertyMap().Add("filename", new PropertyValue(FrameworkInformation.ResourcePath + "IoT_handler_downrightW.png")),
            });

            // TextEditor style.
            theme.AddStyleWithoutClone("Tizen.NUI.BaseComponents.TextEditor", new TextEditorStyle()
            {
                FontFamily = "BreezeSans",
                PixelSize = 32,
                TextColor = new Color(0.00f, 0.05f, 0.17f, 1),
                FontStyle = new PropertyMap().Add("weight", new PropertyValue("regular")),
                PrimaryCursorColor = new Vector4(0.08f, 0.45f, 0.90f, 1),
                SecondaryCursorColor = new Vector4(0.08f, 0.45f, 0.90f, 1),
                CursorWidth = 3,
                SelectionHighlightColor = new Vector4(0.17f, 0.37f, 0.72f, 0.20f),
                GrabHandleColor = new Color(0.08f, 0.45f, 0.90f, 1),
                GrabHandleImage = FrameworkInformation.ResourcePath + "IoT_handler_center_downW.png",
                SelectionHandleImageLeft = new PropertyMap().Add("filename", new PropertyValue(FrameworkInformation.ResourcePath + "IoT_handler_downleftW.png")),
                SelectionHandleImageRight = new PropertyMap().Add("filename", new PropertyValue(FrameworkInformation.ResourcePath + "IoT_handler_downrightW.png")),
            });

            return theme;
        }
    }
}
#endif
