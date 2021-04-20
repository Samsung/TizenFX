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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// AlertDialogStyle is a class which saves AlertDialog's ux data.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AlertDialogStyle : ButtonStyle
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        static AlertDialogStyle() { }

        /// <summary>
        /// Creates a new instance of a AlertDialogStyle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AlertDialogStyle() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of a AlertDialogStyle with style.
        /// </summary>
        /// <param name="style">Create AlertDialogStyle by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AlertDialogStyle(AlertDialogStyle style) : base(style)
        {
        }

        /// <summary>
        /// Gets or sets the AlertDialog Title TextLabel style.
        /// This style is applied if AlertDialog TitleContent is a TextLabel.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabelStyle TitleTextLabel { get; set; } = new TextLabelStyle();

        /// <summary>
        /// Gets or sets the AlertDialog Message TextLabel style.
        /// This style is applied if AlertDialog Content is a TextLabel.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabelStyle MessageTextLabel { get; set; } = new TextLabelStyle();

        /// <summary>
        /// Gets or sets the AlertDialog ActionContent style.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewStyle ActionContent { get; set; } = new ViewStyle();

        /// <summary>
        /// Style's clone function.
        /// </summary>
        /// <param name="bindableObject">The style that need to copy.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            if (bindableObject is AlertDialogStyle alertDialogStyle)
            {
                TitleTextLabel.CopyFrom(alertDialogStyle.TitleTextLabel);
                MessageTextLabel.CopyFrom(alertDialogStyle.MessageTextLabel);
                ActionContent.CopyFrom(alertDialogStyle.ActionContent);
            }
        }
    }
}
