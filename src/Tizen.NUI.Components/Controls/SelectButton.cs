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
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// SelectButton is base class of CheckBox and RadioButton.
    /// It can be used as selector and add into group for single-choice or multiple-choice .
    /// User can handle Navigation by adding/inserting/deleting NavigationItem.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SelectButton : Button
    {
        private SelectGroup itemGroup = null;

        private bool invokeSelectedChanged = false;

        /// <summary>
        /// Item group which is used to manager all SelectButton in it.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected SelectGroup ItemGroup { get => itemGroup; set => itemGroup = value; }

        static SelectButton() { }

        /// <summary>
        /// Creates a new instance of a SelectButton.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SelectButton() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of a SelectButton with style.
        /// </summary>
        /// <param name="style">Create SelectButton by special style defined in UX.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SelectButton(string style) : base(style)
        {
        }

        /// <summary>
        /// Creates a new instance of a SelectButton with style.
        /// </summary>
        /// <param name="buttonStyle">Create SelectButton by style customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SelectButton(ButtonStyle buttonStyle) : base(buttonStyle)
        {
        }

        /// <summary>
        /// An event for the item selected signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<SelectedChangedEventArgs> SelectedChanged;

        /// <summary>
        /// Index of selection in selection group. If selection is not in the group, return -1;
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Index
        {
            get
            {
                if (ItemGroup != null)
                {
                    return ItemGroup.GetIndex(this);
                }

                return -1;
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();
            IsSelectable = true;
        }

        /// <summary>
        /// Dispose SelectButton and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Called after a key event is received by the view that has had its focus set.
        /// </summary>
        /// <param name="key">The key event.</param>
        /// <returns>True if the key event should be consumed.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool OnKey(Key key)
        {
            if ((IsEnabled == false) || (key == null))
            {
                return false;
            }

            if (key.State == Key.StateType.Up)
            {
                if (key.KeyPressedName == "Return")
                {
                    invokeSelectedChanged = true;
                }
            }
            else
            {
                invokeSelectedChanged = false;
            }

            return base.OnKey(key);
        }

        /// <summary>
        /// Called after a touch event is received by the owning view.<br />
        /// CustomViewBehaviour.REQUIRES_TOUCH_EVENTS must be enabled during construction. See CustomView(ViewWrapperImpl.CustomViewBehaviour behaviour).<br />
        /// </summary>
        /// <param name="touch">The touch event.</param>
        /// <returns>True if the event should be consumed.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool OnTouch(Touch touch)
        {
            return base.OnTouch(touch);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override bool HandleControlStateOnTouch(Touch touch)
        {
            if ((IsEnabled == false) || (touch == null))
            {
                return false;
            }

            PointStateType state = touch.GetState(0);
            switch (state)
            {
                case PointStateType.Up:
                    invokeSelectedChanged = true;
                    break;
                default:
                    invokeSelectedChanged = false;
                    break;
            }

            return base.HandleControlStateOnTouch(touch);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior after pressing return key by user.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnSelectedChanged()
        {
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnControlStateChanged(ControlStateChangedEventArgs info)
        {
            if (info.PreviousState.Contains(ControlState.Selected) != info.CurrentState.Contains(ControlState.Selected))
            {
                if (IsHighlighted)
                {
                    EmitAccessibilityStateChangedEvent(AccessibilityState.Checked, info.CurrentState.Contains(ControlState.Selected));
                }

                // SelectedChanged is invoked when button or key is unpressed.
                if (invokeSelectedChanged == false)
                {
                    return;
                }

                OnSelectedChanged();

                if (SelectedChanged != null)
                {
                    SelectedChangedEventArgs eventArgs = new SelectedChangedEventArgs();
                    eventArgs.IsSelected = IsSelected;
                    SelectedChanged(this, eventArgs);
                }
            }
        }
    }
}
