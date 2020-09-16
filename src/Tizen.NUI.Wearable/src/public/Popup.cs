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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Wearable
{
    using L = Tizen.Log;

    /// <summary>
    /// Popup is an UI component to give a notification or message, which interaction with user simply.
    /// It is attached to Window directly so that it is shown on top of all UI components.
    /// Title(text) and Content(container) are initially formed and user can control them by setting properties or styles.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Popup : Control
    {
        const string tag = "NUI";

        /// <summary>
        /// Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Popup() : base()
        {
            initialize();
        }

        /// <summary>
        /// Constructor with style
        /// </summary>
        /// <param name="style">style</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Popup(PopupStyle style) : base(style)
        {
            initialize();
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <param name="type">Dispose type</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            timer.Dispose();

            foreach (var iter in buttonList.Values)
            {
                iter.Unparent();
                iter.Dispose();
            }
            buttonList.Clear();
            buttonList = null;

            foreach (var iter in scrollList.Values)
            {
                iter.Unparent();
                iter.Dispose();
            }
            scrollList.Clear();
            scrollList = null;

            title.Unparent();
            title.Dispose();

            scroll.Unparent();
            scroll.Dispose();

            TouchEvent -= Popup_TouchEvent;
            Unparent();
            instanceCnt--;

            if (window != null)
            {
                window.RemoveLayer(layer);
                layer.Dispose();
                layer = null;
            }
            window = null;

            base.Dispose(type);
        }


        /// <summary>
        /// Set postion of added button
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ButtonPosition
        {
            /// <summary>
            /// Left side on popup
            /// </summary>
            Left,
            /// <summary>
            /// Right side on popup
            /// </summary>
            Right,
            /// <summary>
            /// Lower sider on popup
            /// </summary>
            Bottom,
            /// <summary>
            /// User set the position on popup
            /// </summary>
            Custom,
            /// <summary>
            /// Position is set automatically
            /// </summary>
            Automatic,
        }

        /// <summary>
        /// ContentContainer
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View ContentContainer;

        /// <summary>
        /// Append Buttons on popup.
        /// </summary>
        /// <param name="index">Key to get a specific button by using GetButton</param>
        /// <param name="button">Button to be added</param>
        /// <param name="automaticPositioning">If set true, added button will be placed automatically</param>
        /// <param name="position">Specific postion set by user</param>
        public void AppendButton(string index, Button button, bool automaticPositioning = true, ButtonPosition position = ButtonPosition.Automatic)
        {
            if (button != null)
            {
                if (automaticPositioning)
                {
                    if (buttonList.Count >= 2)
                    {
                        throw new InvalidOperationException("Added button should not be added more than 2");
                    }
                    else if (buttonList.Count <= 0)
                    {
                        buttonList.Add(index, button);
                        // will be fixed later.
                        //buttonContainer.Layout = new FlexLayout()
                        //{
                        //    Direction = FlexLayout.FlexDirection.Row,
                        //    Justification = FlexLayout.FlexJustification.Center,
                        //    ItemsAlignment = FlexLayout.AlignmentType.FlexEnd,
                        //};
                        //buttonContainer.Layout = new LinearLayout()
                        //{
                        //    LinearAlignment = LinearLayout.Alignment.Center,
                        //    LinearOrientation = LinearLayout.Orientation.Horizontal,
                        //};
                        
                        buttonContainer.Add(button);
                        buttonContainer.RaiseToTop();

                        // will be removed later.
                        button.PositionUsesPivotPoint = true;
                        button.ParentOrigin = NUI.ParentOrigin.BottomCenter;
                        button.PivotPoint = NUI.PivotPoint.BottomCenter;
                        firstButtonIndex = index;
                    }
                    else
                    {
                        buttonList.Add(index, button);

                        // will be fixed later.
                        //buttonContainer.Layout = new FlexLayout()
                        //{
                        //    Direction = FlexLayout.FlexDirection.Column,
                        //    Justification = FlexLayout.FlexJustification.SpaceBetween,
                        //    ItemsAlignment = FlexLayout.AlignmentType.Center,
                        //};
                        //buttonContainer.Layout = new LinearLayout()
                        //{
                        //    LinearAlignment = LinearLayout.Alignment.Center,
                        //    LinearOrientation = LinearLayout.Orientation.Horizontal,
                        //};

                        buttonContainer.Add(button);
                        buttonContainer.RaiseToTop();

                        // will be removed later.
                        Button leftButton;
                        buttonList.TryGetValue(firstButtonIndex, out leftButton);
                        leftButton.PositionUsesPivotPoint = true;
                        leftButton.ParentOrigin = NUI.ParentOrigin.CenterLeft;
                        leftButton.PivotPoint = NUI.PivotPoint.CenterLeft;
                        leftButton.OverlayImage.SiblingOrder = 100;
                        button.PositionUsesPivotPoint = true;
                        button.ParentOrigin = NUI.ParentOrigin.CenterRight;
                        button.PivotPoint = NUI.PivotPoint.CenterRight;
                        button.OverlayImage.SiblingOrder = 100;
                    }
                }
                else
                {
                    L.Debug(tag, "AppendButton()");
                    buttonList.Add(index, button);
                    Add(button);
                    button.RaiseToTop();
                    button.OverlayImage.SiblingOrder = 100; //will be fixed.
                    if (position == ButtonPosition.Left)
                    {
                        button.PositionUsesPivotPoint = true;
                        button.ParentOrigin = NUI.ParentOrigin.CenterLeft;
                        button.PivotPoint = NUI.PivotPoint.CenterLeft;
                    }
                    else if (position == ButtonPosition.Right)
                    {
                        button.PositionUsesPivotPoint = true;
                        button.ParentOrigin = NUI.ParentOrigin.CenterRight;
                        button.PivotPoint = NUI.PivotPoint.CenterRight;
                    }
                    else if (position == ButtonPosition.Bottom)
                    {
                        button.PositionUsesPivotPoint = true;
                        button.ParentOrigin = NUI.ParentOrigin.BottomCenter;
                        button.PivotPoint = NUI.PivotPoint.BottomCenter;
                    }
                    else
                    {
                        //do nothing.
                    }
                }
            }
        }

        /// <summary>
        /// Get Button by index.
        /// </summary>
        /// <param name="index">Index(key) to be found</param>
        /// <returns>Button of Popup</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Button GetButton(string index)
        {
            L.Fatal(tag, "GetButton()");

            return buttonList[index];
        }

        /// <summary>
        /// Get Title.
        /// </summary>
        /// <returns>Title(TextLabel) of Popup</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabel GetTitle()
        {
            return title;
        }

        /// <summary>
        /// Append indexed content which is created by user.
        /// </summary>
        /// <param name="index">Index(key) of the content added</param>
        /// <param name="content">Content to be added in Popup's content</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AppendContent(string index, View content)
        {
            scrollList.Add(index, content);
            ContentContainer.Add(content);
        }

        /// <summary>
        /// Get indexed content.
        /// </summary>
        /// <param name="index">Index(key) to be found</param>
        /// <returns>Content in the Popup</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View GetContent(string index)
        {
            return scrollList[index];
        }

        /// <summary>
        /// Post on top of Window.
        /// </summary>
        /// <param name="targetWindow">Window where Popup is placed</param>
        /// <param name="animated">Posting animation</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Post(Window targetWindow, bool animated = true)
        {
            window = targetWindow;
            if (window != null)
            {
                if (animated)
                {
                    BeforePosting?.Invoke(this, null);
                    if (CustomAnimation == null)
                    {
                        defaultShowAnimation();
                    }
                    else
                    {
                        CustomAnimation.ShowAnimation(this);
                    }
                    window.AddLayer(layer);
                    layer.RaiseToTop();
                    AfterPosting?.Invoke(this, null);
                }
                else
                {
                    window.AddLayer(layer);
                    layer.RaiseToTop();
                }
            }
        }

        /// <summary>
        /// Dismiss Popup.
        /// </summary>
        /// <param name="animated">True when using Dismissing event</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dismiss(bool animated = true)
        {
            if (window != null)
            {
                BeforeDissmising?.Invoke(this, null);

                if (animated)
                {
                    if (CustomAnimation == null)
                    {
                        defaultHideAnimation();
                    }
                    else
                    {
                        CustomAnimation.HideAnimation(this);
                    }
                }
                else
                {
                    window.RemoveLayer(layer);
                }
                AfterDissmising?.Invoke(this, null);
            }
        }

        /// <summary>
        /// Set timeout milli-second
        /// </summary>
        /// <param name="milliSecond">Automatically dissmissed after milli-second</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTimeout(uint milliSecond)
        {
            if (timer == null)
            {
                timer = new Timer(milliSecond);
            }
            else
            {
                timer.Stop();
            }

            timer.Tick += (s, e) =>
            {
                Dismiss();
                return false;
            };
            timer.Start();
        }

        /// <summary>
        /// OnUpdate
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
        }

        /// <summary>
        /// CustomAnimation
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IPopupAnimation CustomAnimation;

        /// <summary>
        /// Event when outside of components(Button, Content, Title) is clicked.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler OutsideClicked;

        /// <summary>
        /// Event before popup is posted. Customized action such as animation can be added.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler BeforePosting;

        /// <summary>
        /// Event after popup is posted. Customized action such as animation can be added.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler AfterPosting;

        /// <summary>
        /// Event before popup is dismissed. Customized action such as animation can be added.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler BeforeDissmising;

        /// <summary>
        /// Event after popup is dismissed. Customized action such as animation can be added.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler AfterDissmising;

        /// <summary>
        /// Get Popup style.
        /// </summary>
        /// <returns>The default popup style.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle CreateViewStyle()
        {
            return new PopupStyle();
        }

        private void initialize()
        {
            popupStyle = ViewStyle as PopupStyle;
            if (popupStyle == null)
            {
                throw new Exception("Popup style is null.");
            }

            BackgroundColor = Color.Black;
            Size = new Size(POPUP_WIDTH, POPUP_HEIGHT);
            PositionUsesPivotPoint = true;
            ParentOrigin = NUI.ParentOrigin.Center;
            PivotPoint = NUI.PivotPoint.Center;
            Layout = new AbsoluteLayout();

            layer = new Layer()
            {
                Name = "PopupLayer",
            };
            layer.Add(this);

            buttonList = new Dictionary<string, Button>();

            buttonContainer = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            Add(buttonContainer);

            titleContentContainer = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };
            Add(titleContentContainer);
            
            //will be fixed later.
            //titleContentContainer.Layout = new LinearLayout()
            //{
            //    LinearOrientation = LinearLayout.Orientation.Vertical,
            //    LinearAlignment = LinearLayout.Alignment.Top,
            //};

            title = new TextLabel()
            {
                Name = "Title",
                Size = new Size(TITLE_WIDTH, TITLE_HEIGHT),
                PointSize = TEXT_POINT_SIZE,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                TextColor = Color.Cyan,

                //will be removed later.
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopCenter,
                PivotPoint = Tizen.NUI.PivotPoint.TopCenter,
                Position = new Position(0, TITLE_POSITION_Y),
            };
            titleContentContainer.Add(title);

            LinearLayout scrollLayout = new LinearLayout();
            scrollLayout.LinearOrientation = LinearLayout.Orientation.Vertical;

            ContentContainer = new View()
            {
                Layout = scrollLayout,
                
                //will be removed later.
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopCenter,
                PivotPoint = Tizen.NUI.PivotPoint.TopCenter,
            };

            scroll = new ScrollableBase()
            {
                Name = "Scroll",
                PositionUsesPivotPoint = true,
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                ScrollEnabled = true,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,

                //will be removed later.
                ParentOrigin = Tizen.NUI.ParentOrigin.TopCenter,
                PivotPoint = Tizen.NUI.PivotPoint.TopCenter,
                Position = new Position(0, CONTENT_POSITION_Y),
            };
            titleContentContainer.Add(scroll);
            scroll.Add(ContentContainer);

            scrollList = new Dictionary<string, View>();

            TouchEvent += Popup_TouchEvent;

            title.PropertyChanged += Title_PropertyChanged;
        }

        private void Title_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Size" || e.PropertyName == "Size2D")
            {
                scroll.Position = new Position(0, title.Size.Height);
            }
        }

        private static int instanceCnt;
        private Layer layer;
        private Dictionary<string, Button> buttonList;
        private Window window;
        private TextLabel title;
        private ScrollableBase scroll;
        private Dictionary<string, View> scrollList;
        private Timer timer;
        private PopupStyle popupStyle;
        private View buttonContainer;
        private string firstButtonIndex;
        private View titleContentContainer;
        
        private PointStateType previousState;
        private bool Popup_TouchEvent(object source, TouchEventArgs e)
        {
            if (previousState == PointStateType.Down && e.Touch.GetState(0) == PointStateType.Finished)
            {
                OutsideClicked?.Invoke(this, null);
            }
            previousState = e.Touch.GetState(0);
            return true;
        }

        //this will be changed as blur animation
        private void defaultShowAnimation()
        {
            Opacity = 0;
            Animation ani = new Animation(1000);
            ani.AnimateTo(this, "opacity", 1);
            ani.Finished += (s, e) =>
            {
                ani.Reset();
                ani.Dispose();
            };
            ani.Play();
        }

        //this will be changed as blur animation
        private void defaultHideAnimation()
        {
            Animation ani = new Animation(1000);
            ani.AnimateTo(this, "opacity", 0);
            ani.Finished += (s, e) =>
            {
                window.RemoveLayer(layer);
                ani.Reset();
                ani.Dispose();
            };
            ani.Play();
        }

        //the followings will be replaced by style
        private const int TITLE_WIDTH = 198;
        private const int TITLE_HEIGHT = 39;
        private const int TITLE_POSITION_Y = 46;
        private const int CONTENT_POSITION_Y = TITLE_POSITION_Y + TITLE_HEIGHT + 5;
        private const int POPUP_WIDTH = 360;
        private const int POPUP_HEIGHT = 360;
        private const int TEXT_POINT_SIZE = 7;
    }

    /// <summary>
    /// PopupAnimation interface
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IPopupAnimation
    {
        /// <summary>
        /// ShowAnimation
        /// </summary>
        /// <param name="popup"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void ShowAnimation(Popup popup);
        /// <summary>
        /// HideAnimation
        /// </summary>
        /// <param name="popup"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void HideAnimation(Popup popup);
    }

}
