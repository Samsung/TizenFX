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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The ButtonAdapter class enables developers to write custom UI components in a Button and their behaviors on various states by override methods.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class ButtonAdapter
    {
        /// <summary>
        /// Called immediately after the Button creates the text part.
        /// </summary>
        /// <param name="button">The Button instance that the adapter currently applied to.</param>
        /// <param name="text">The created Button's text part.</param>
        /// <param name="style">The initial style that will be appled to Button's text part.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnCreateText(Button button, ref TextLabel text, TextLabelStyle style)
        {
        }

        /// <summary>
        /// Called immediately after the Button creates the icon part.
        /// </summary>
        /// <param name="button">The Button instance that the adapter currently applied to.</param>
        /// <param name="icon">The created Button's icon part.</param>
        /// <param name="style">The initial style that will be appled to Button's icon part.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnCreateIcon(Button button, ref ImageView icon, ImageViewStyle style)
        {
        }

        /// <summary>
        /// Called immediately after the Button creates the overlay image part.
        /// </summary>
        /// <param name="button">The Button instance that the adapter currently applied to.</param>
        /// <param name="overlayImage">The created Button's overlayImage part.</param>
        /// <param name="style">The initial style that will be appled to Button's overlay image part.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnCreateOverlayImage(Button button, ref ImageView overlayImage, ImageViewStyle style)
        {
        }

        /// <summary>
        /// Describes actions on Button's ControlStates changed.
        /// </summary>
        /// <param name="button">The Control instance that the adapter currently applied to.</param>
        /// <param name="previousState">The previous contol state of the Button.</param>
        /// <param name="currentState">The current control state of the Button.</param>
        /// <param name="byUI">True if the state has changed by user interaction. (e.g. touch, key)</param>
        /// <param name="touchInfo">The touch information in case the state has changed by touching.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnControlStateChanged(Button button, ControlStates previousState, ControlStates currentState, bool byUI, Touch touchInfo)
        {
        }

        /// <summary>
        /// Called when the Button is Clicked by a user
        /// </summary>
        /// <param name="button">The Button instance that the adapter currently applied to.</param>
        /// <param name="clickUp">The touch information on click upButton instance that the adapter currently applied to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnClick(Button button, Touch clickUp)
        {
        }

        /// <summary>
        /// Called after the size negotiation has been finished for the attached Control.
        /// </summary>
        /// <param name="button">The Button instance that the adapter currently applied to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnRelayout(Button button)
        {
        }

        /// <summary>
        /// Called when the attached Control is trying to disconnect the relation with the adapter.
        /// </summary>
        /// <param name="button">The Button instance that the adapter currently applied to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void OnDisconnect(Button button)
        {
        }
  }
}
