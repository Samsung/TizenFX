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

            // // TODO Add a TextLabelStyle style to the theme if need.
            // // This is an example of text label style.
            // theme.AddStyleWithoutClone("Tizen.NUI.BaseComponents.TextLabel", new TextLabelStyle()
            // {
            //     PixelSize = 10,
            //     TextColor = Color.Red,
            // });

            // // TODO Add a TextFieldStyle to the theme if need.
            // // This is an example of text filed style.
            // theme.AddStyleWithoutClone("Tizen.NUI.BaseComponents.TextField", new TextFieldStyle()
            // {
            //     //...
            // });

            // // TODO Add a TextEditorStyle to the theme if need.
            // // This is an example of text filed style.
            // theme.AddStyleWithoutClone("Tizen.NUI.BaseComponents.TextEditor", new TextEditorStyle()
            // {
            //     //...
            // });

            return theme;
        }
    }
}
#endif
