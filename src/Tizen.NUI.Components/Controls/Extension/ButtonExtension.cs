/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.Components.Extension
{
    /// <summary>
    /// The ButtonExtension class allows developers to access the Button's components and extend their behavior in various states.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class ButtonExtension
    {
        /// <summary>
        /// The Touch info to get current touch position.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Touch TouchInfo { get; private set; }

        /// <summary>
        /// Called immediately after the Button creates the text part.
        /// </summary>
        /// <param name="button">The Button instance that the extension currently applied to.</param>
        /// <param name="text">The created Button's text part.</param>
        /// <return>The refined button text.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TextLabel OnCreateText(Button button, TextLabel text)
        {
            return text;
        }

        /// <summary>
        /// Called immediately after the Button creates the icon part.
        /// </summary>
        /// <param name="button">The Button instance that the extension currently applied to.</param>
        /// <param name="icon">The created Button's icon part.</param>
        /// <return>The refined button icon.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageView OnCreateIcon(Button button, ImageView icon)
        {
            return icon;
        }

        /// <summary>
        /// Called immediately after the Button creates the overlay image part.
        /// </summary>
        /// <param name="button">The Button instance that the extension currently applied to.</param>
        /// <param name="overlayImage">The created Button's overlayImage part.</param>
        /// <return>The refined button overlayImage.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ImageView OnCreateOverlayImage(Button button, ImageView overlayImage)
        {
            return overlayImage;
        }

        /// <summary>
        /// Describes actions on Button's ControlStates changed.
        /// </summary>
        /// <param name="button">The Button instance that the extension currently applied to.</param>
        /// <param name="args">The control state changed information.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnControlStateChanged(Button button, View.ControlStateChangedEventArgs args)
        {
        }

        /// <summary>
        /// Called when the Button is Clicked by a user
        /// </summary>
        /// <param name="button">The Button instance that the extension currently applied to.</param>
        /// <param name="eventArgs">The click event information.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnClicked(Button button, ClickedEventArgs eventArgs)
        {
        }

        /// <summary>
        /// Called after the size negotiation has been finished for the attached Control.
        /// </summary>
        /// <param name="button">The Button instance that the extension currently applied to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnRelayout(Button button)
        {
        }

        /// <summary>
        /// Called when the attached Button is explicitly disposing.
        /// </summary>
        /// <param name="button">The Button instance that the extension currently applied to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnDispose(Button button)
        {
        }

        /// <summary>
        /// Set the Touch Info.
        /// </summary>
        /// <param name="touch">The Touch Info.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTouchInfo(Touch touch) => TouchInfo = touch;
    }
}
