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
    /// AppBarStyle is a class which saves AppBar's ux data.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class AppBarStyle : ControlStyle
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        static AppBarStyle() { }

        /// <summary>
        /// Creates a new instance of an AppBarStyle.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public AppBarStyle() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of an AppBarStyle with style.
        /// The given style is copied to the new instance.
        /// </summary>
        /// <param name="style">Creates AppBarStyle by style customized by user.</param>
        /// <since_tizen> 9 </since_tizen>
        public AppBarStyle(AppBarStyle style) : base(style)
        {
        }

        /// <summary>
        /// Gets or sets the AppBar Back Button style.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public ButtonStyle BackButton { get; set; } = new ButtonStyle();

        /// <summary>
        /// Gets or sets the AppBar Title TextLabel style.
        /// This style is applied if AppBar Title is a TextLabel.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public TextLabelStyle TitleTextLabel { get; set; } = new TextLabelStyle();

        /// <summary>
        /// Gets or sets the AppBar Action View style.
        /// This style is applied if AppBar ActionContent's child is a View.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public ViewStyle ActionView { get; set; } = new ViewStyle();

        /// <summary>
        /// Gets or sets the AppBar Action Button style.
        /// This style is applied if AppBar ActionContent's child is a Button.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public ButtonStyle ActionButton { get; set; } = new ButtonStyle();

        /// <summary>
        /// Navigation padding in AppBar.
        /// This works only when NavigationContent is visible.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents NavigationPadding { get; set; } = new Extents();

        /// <summary>
        /// Action padding in AppBar.
        /// This works only when ActionContent is visible.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents ActionPadding { get; set; } = new Extents();

        /// <summary>
        /// Cell padding among Actions in AppBar.
        /// This works only when ActionContent is visible.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D ActionCellPadding { get; set; } = new Size2D();

        /// <inheritdoc/>
        /// <since_tizen> 9 </since_tizen>
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            if (bindableObject is AppBarStyle appBarStyle)
            {
                BackButton.CopyFrom(appBarStyle.BackButton);
                TitleTextLabel.CopyFrom(appBarStyle.TitleTextLabel);
                ActionView.CopyFrom(appBarStyle.ActionView);
                ActionButton.CopyFrom(appBarStyle.ActionButton);
                NavigationPadding = (appBarStyle.NavigationPadding == null) ? new Extents() : new Extents(appBarStyle.NavigationPadding);
                ActionPadding = (appBarStyle.ActionPadding == null) ? new Extents() : new Extents(appBarStyle.ActionPadding);
                ActionCellPadding = (appBarStyle.ActionCellPadding == null) ? new Size2D() : new Size2D(appBarStyle.ActionCellPadding.Width, appBarStyle.ActionCellPadding.Height);
            }
        }
    }
}
