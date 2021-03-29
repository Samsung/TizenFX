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

using System;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using System.Windows.Input;
using Tizen.System;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The control component is base class of tv nui components. It's abstract class, so can't instantiate and can only be inherited.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Control : VisualView
    {
        /// Internal used.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(Control), null, propertyChanged: (bo, o, n) => ((Control)bo).OnCommandChanged());

        /// Internal used.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(Button), null,
            propertyChanged: (bindable, oldvalue, newvalue) => ((Button)bindable).CommandCanExecuteChanged(bindable, EventArgs.Empty));

        private bool onThemeChangedEventOverrideChecker;

        private Feedback feedback = null;

        static Control()
        {
            ThemeManager.AddPackageTheme(DefaultThemeCreator.Instance);
        }

        /// <summary>
        /// This is used to improve theme performance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public void Preload()
        {
            DefaultThemeCreator.Preload();
        }

        /// <summary>
        /// Construct an empty Control.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Control() : this((ControlStyle)null)
        {
        }

        /// <summary>
        /// Construct with style.
        /// </summary>
        /// <param name="style">Create control with style.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Control(ControlStyle style) : base(style)
        {
        }

        /// <summary>
        /// Construct with style name
        /// </summary>
        /// <param name="styleName">The name of style in the current theme to be applied</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Control(string styleName) : this(new ControlStyle() /* Apply empty style */)
        {
            if (ThemeManager.GetStyle(styleName) == null)
            {
                throw new InvalidOperationException($"There is no style {styleName}");
            }

            StyleName = styleName;
        }

        /// <summary>
        /// Enable/Disable a sound feedback when tap gesture detected.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Feedback
        {
            get => feedback != null;
            set
            {
                if (value == (feedback != null))
                {
                    return;
                }

                if (value)
                {
                    feedback = new Feedback();
                    this.TouchEvent += OnTouchPlayFeedback;
                }
                else
                {
                    this.TouchEvent -= OnTouchPlayFeedback;
                    feedback = null;
                }
            }
        }

        private bool OnTouchPlayFeedback(object source, TouchEventArgs e)
        {
            if (Feedback && e?.Touch.GetState(0) == PointStateType.Down)
            {
                if (feedback != null && feedback.IsSupportedPattern(FeedbackType.Sound, "Tap"))
                {
                    feedback.Play(FeedbackType.Sound, "Tap");
                }
            }
            return false;
        }

        /// Internal used.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        /// Internal used.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        /// <summary>
        /// Whether focusable when touch
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        internal bool StateFocusableOnTouchMode { get; set; }

        internal bool IsFocused { get; set; } = false;

        internal void CommandCanExecuteChanged(object sender, EventArgs eventArgs)
        {
            ICommand cmd = Command;
            if (cmd != null)
                cmd.CanExecute(CommandParameter);
        }

        internal void OnCommandChanged()
        {
            if (Command != null)
            {
                Command.CanExecuteChanged += CommandCanExecuteChanged;
                CommandCanExecuteChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Dispose Control and all children on it.
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

            feedback = null;
            this.TouchEvent -= OnTouchPlayFeedback;

            if (type == DisposeTypes.Explicit)
            {
            }

            base.Dispose(type);
        }

        /// <inheritdoc/>
        public override void OnInitialize()
        {
            base.OnInitialize();

            LeaveRequired = true;
            StateFocusableOnTouchMode = false;
            EnableControlState = true;
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
            return false;
        }

        /// <summary>
        /// Called after the size negotiation has been finished for this control.<br />
        /// The control is expected to assign this given size to itself or its children.<br />
        /// Should be overridden by derived classes if they need to layout views differently after certain operations like add or remove views, resize, or after changing specific properties.<br />
        /// As this function is called from inside the size negotiation algorithm, you cannot call RequestRelayout (the call would just be ignored).<br />
        /// </summary>
        /// <param name="size">The allocated size.</param>
        /// <param name="container">The control should add views to this container that it is not able to allocate a size for.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            base.OnRelayout(size, container);
            OnUpdate();
        }

        /// <summary>
        /// Called when the control gain key input focus. Should be overridden by derived classes if they need to customize what happens when the focus is gained.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnFocusGained()
        {
            IsFocused = true;
        }

        /// <summary>
        /// Called when the control loses key input focus. Should be overridden by derived classes if they need to customize what happens when the focus is lost.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnFocusLost()
        {
            IsFocused = false;
        }

        /// <summary>
        /// Update by style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnUpdate()
        {
        }

        /// <summary>
        /// Theme change callback when theme is changed, this callback will be trigger.
        /// Note that it is deprecated API.Please use OnThemeChanged instead.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event data</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            onThemeChangedEventOverrideChecker = false;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle CreateViewStyle()
        {
            return new ControlStyle();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnThemeChanged(object sender, ThemeChangedEventArgs e)
        {
            // TODO Remove checker after update Tizen.FH.NUI.
            onThemeChangedEventOverrideChecker = true;

            OnThemeChangedEvent(sender, new StyleManager.ThemeChangeEventArgs { CurrentTheme = e.ThemeId });

            if (onThemeChangedEventOverrideChecker) return;

            // If the OnThemeChangedEvent is not implemented, ApplyStyle()
            base.OnThemeChanged(sender, e);
        }
    }
}
