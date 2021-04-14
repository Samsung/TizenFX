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
using System.ComponentModel;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// AlertDialog class shows a dialog with title, message and action buttons.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class AlertDialog : Control
    {
        private string title = null;
        private string message = null;

        private View titleContent = null;
        private View content = null;
        private View actionContent = null;
        private IEnumerable<View> actionContentViews = null;

        private View defaultTitleContent = null;
        private View defaultContent = null;
        private View defaultActionContent = null;
        // FIXME: Now AlertDialog.Padding Top and Bottom increases AlertDialog size incorrectly.
        //        Until the bug is fixed, padding view is added after action content.
        private View defaultActionContentPadding = null;

        private AlertDialogStyle alertDialogStyle => ViewStyle as AlertDialogStyle;

        private bool styleApplied = false;

        /// <summary>
        /// Creates a new instance of AlertDialog.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public AlertDialog() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of AlertDialog.
        /// </summary>
        /// <param name="style">Creates AlertDialog by special style defined in UX.</param>
        /// <since_tizen> 9 </since_tizen>
        public AlertDialog(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of AlertDialog.
        /// </summary>
        /// <param name="alertDialogStyle">Creates AlertDialog by style customized by user.</param>
        /// <since_tizen> 9 </since_tizen>
        public AlertDialog(AlertDialogStyle alertDialogStyle) : base(alertDialogStyle)
        {
            Initialize();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (titleContent != null)
                {
                    Utility.Dispose(titleContent);
                }

                if (content != null)
                {
                    Utility.Dispose(content);
                }

                if (actionContent != null)
                {
                    Utility.Dispose(actionContent);
                }

                // FIXME: Now AlertDialog.Padding Top and Bottom increases AlertDialog size incorrectly.
                //        Until the bug is fixed, padding view is added after action content.
                if (defaultActionContentPadding != null)
                {
                    Utility.Dispose(defaultActionContentPadding);
                }
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Applies style to AlertDialog.
        /// </summary>
        /// <param name="viewStyle">The style to apply.</param>
        /// <since_tizen> 9 </since_tizen>
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            styleApplied = false;

            base.ApplyStyle(viewStyle);

            // Apply Title style.
            if ((alertDialogStyle?.TitleTextLabel != null) && (DefaultTitleContent is TextLabel))
            {
                ((TextLabel)DefaultTitleContent)?.ApplyStyle(alertDialogStyle.TitleTextLabel);
            }

            // Apply Message style.
            if ((alertDialogStyle?.MessageTextLabel != null) && (DefaultContent is TextLabel))
            {
                ((TextLabel)DefaultContent)?.ApplyStyle(alertDialogStyle.MessageTextLabel);
            }

            // Apply ActionContent style.
            if (alertDialogStyle?.ActionContent != null)
            {
                DefaultActionContent?.ApplyStyle(alertDialogStyle.ActionContent);
            }

            styleApplied = true;

            // Calculate dialog position and children's positions based on padding sizes.
            CalculatePosition();
        }

        /// <summary>
        /// Title text of AlertDialog.
        /// Title text is set to TitleContent's Text if TitleContent is TextLabel.
        /// If TitleContent's Text is set manually by user, then it is not guaranteed that TitleContent's Text is the same with Title text.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (title == value)
                {
                    return;
                }

                title = value;

                if (TitleContent is TextLabel textLabel)
                {
                    textLabel.Text = title;
                }
            }
        }

        /// <summary>
        /// Title content of AlertDialog.
        /// TitleContent is added as a child of AlertDialog automatically.
        /// Title text is set to TitleContent's Text if TitleContent is TextLabel.
        /// If TitleContent's Text is set manually by user, then it is not guaranteed that TitleContent's Text is the same with Title text.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public View TitleContent
        {
            get
            {
                return titleContent;
            }
            set
            {
                if (titleContent == value)
                {
                    return;
                }

                if (titleContent != null)
                {
                    Remove(titleContent);
                }

                titleContent = value;
                if (titleContent == null)
                {
                    return;
                }

                if (titleContent is TextLabel textLabel)
                {
                    textLabel.Text = Title;
                }

                ResetContent();
            }
        }

        /// <summary>
        /// Message text of AlertDialog.
        /// Message text is set to Content's Text if Content is TextLabel.
        /// If Content's Text is set manually by user, then it is not guaranteed that Content's Text is the same with Message text.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                if (message == value)
                {
                    return;
                }

                message = value;

                if (Content is TextLabel textLabel)
                {
                    textLabel.Text = message;
                }
            }
        }

        /// <summary>
        /// Content of AlertDialog.
        /// Content is added as a child of AlertDialog automatically.
        /// Message text is set to Content's Text if Content is TextLabel.
        /// If Content's Text is set manually by user, then it is not guaranteed that Content's Text is the same with Message text.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public View Content
        {
            get
            {
                return content;
            }
            set
            {
                if (content == value)
                {
                    return;
                }

                if (content != null)
                {
                    Remove(content);
                }

                content = value;
                if (content == null)
                {
                    return;
                }

                if (content is TextLabel textLabel)
                {
                    textLabel.Text = message;
                }

                ResetContent();
            }
        }

        /// <summary>
        /// Action views of AlertDialog.
        /// Action views are added as children of ActionContent.
        /// When Actions are set, previous Actions are removed from ActionContent.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public IEnumerable<View> Actions
        {
            get
            {
                return actionContentViews;
            }
            set
            {
                if (ActionContent == null)
                {
                    actionContentViews = value;
                    return;
                }

                if (actionContentViews != null)
                {
                    foreach (var oldAction in actionContentViews)
                    {
                        if (ActionContent.Children?.Contains(oldAction) == true)
                        {
                            ActionContent.Children.Remove(oldAction);
                        }
                    }
                }

                actionContentViews = value;

                if (actionContentViews == null)
                {
                    return;
                }

                foreach (var action in actionContentViews)
                {
                    ActionContent.Add(action);
                }
            }
        }

        /// <summary>
        /// Action content of AlertDialog.
        /// ActionContent is added as a child of AlertDialog automatically.
        /// Actions are added as children of ActionContent.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public View ActionContent
        {
             get
             {
                return actionContent;
             }
             set
             {
                if (actionContent == value)
                 {
                     return;
                 }

                var oldActionContent = actionContent;
                actionContent = value;

                // Add views first before remove previous action content
                // not to cause Garbage Collector collects views.
                if ((actionContent != null) && (Actions != null))
                {
                    foreach (var action in Actions)
                    {
                        actionContent.Add(action);
                    }
                }

                if (oldActionContent != null)
                {
                    Remove(oldActionContent);
                }

                if (actionContent == null)
                {
                    return;
                }

                ResetContent();
            }
        }

        /// <summary>
        /// AccessibilityGetName.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override string AccessibilityGetName()
        {
            if (!String.IsNullOrEmpty(Title))
            {
                return Title;
            }
            else
            {
                return Message;
            }
        }

        /// <summary>
        /// Default title content of AlertDialog.
        /// If Title is set, then default title content is automatically displayed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected View DefaultTitleContent
        {
            get
            {
                if (defaultTitleContent == null)
                {
                    defaultTitleContent = CreateDefaultTitleContent();
                }

                return defaultTitleContent;
            }
        }

        /// <summary>
        /// Default content of AlertDialog.
        /// If Message is set, then default content is automatically displayed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected View DefaultContent
        {
            get
            {
                if (defaultContent == null)
                {
                    defaultContent = CreateDefaultContent();
                }

                return defaultContent;
            }
        }

        /// <summary>
        /// Default action content of AlertDialog.
        /// If Actions are set, then default action content is automatically displayed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected View DefaultActionContent
        {
            get
            {
                if (defaultActionContent == null)
                {
                    defaultActionContent = CreateDefaultActionContent();
                }

                // FIXME: Now AlertDialog.Padding Top and Bottom increases AlertDialog size incorrectly.
                //        Until the bug is fixed, padding view is added after action content.
                if (defaultActionContentPadding == null)
                {
                    defaultActionContentPadding = CreateDefaultActionContentPadding();
                }

                return defaultActionContent;
            }
        }

        private void Initialize()
        {
            Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
            };

            this.Relayout += OnRelayout;

            TitleContent = DefaultTitleContent;

            Content = DefaultContent;

            ActionContent = DefaultActionContent;
        }

        private void ResetContent()
        {
            //To keep the order of TitleContent, Content and ActionContent,
            //the existing contents are removed and added again.
            if (titleContent != null)
            {
                Remove(titleContent);
            }

            if (content != null)
            {
                Remove(content);
            }

            if (actionContent != null)
            {
                Remove(actionContent);
            }

            if (titleContent != null)
            {
                Add(titleContent);
            }

            if (content != null)
            {
                Add(content);
            }

            if (actionContent != null)
            {
                Add(actionContent);

                // FIXME: Now AlertDialog.Padding Top and Bottom increases AlertDialog size incorrectly.
                //        Until the bug is fixed, padding view is added after action content.
                if (actionContent == defaultActionContent)
                {
                    if (defaultActionContentPadding != null)
                    {
                        Add(defaultActionContentPadding);
                    }
                }
            }
        }

        private TextLabel CreateDefaultTitleContent()
        {
            return new TextLabel();
        }

        private TextLabel CreateDefaultContent()
        {
            return new TextLabel();
        }

        private View CreateDefaultActionContent()
        {
            return new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                },
            };
        }

        // FIXME: Now AlertDialog.Padding Top and Bottom increases AlertDialog size incorrectly.
        //        Until the bug is fixed, padding view is added after action content.
        private View CreateDefaultActionContentPadding()
        {
            var layout = Layout as LinearLayout;

            if ((layout == null) || (defaultActionContent == null))
            {
                return null;
            }

            View paddingView = null;

            using (Size2D size = new Size2D(defaultActionContent.Size2D.Width, defaultActionContent.Size2D.Height))
            {
                if (layout.LinearOrientation == LinearLayout.Orientation.Horizontal)
                {
                    size.Width = 40;
                }
                else
                {
                    size.Height = 40;
                }

                paddingView = new View()
                {
                    Size2D = new Size2D(size.Width, size.Height),
                };
            }

            return paddingView;
        }

        private void OnRelayout(object sender, EventArgs e)
        {
            // Calculate dialog position and children's positions based on padding sizes.
            CalculatePosition();
        }

        // Calculate dialog position and children's positions based on padding sizes.
        private void CalculatePosition()
        {
            if (styleApplied == false)
            {
                return;
            }

            CalculateActionsCellPadding();

            var size = Size2D;
            var parent = GetParent();
            Size2D parentSize;

            if ((parent != null) && (parent is View))
            {
                parentSize = ((View)parent).Size;
            }
            else
            {
                parentSize = NUIApplication.GetDefaultWindow().Size;
            }

            Position2D = new Position2D((parentSize.Width - size.Width) / 2, (parentSize.Height - size.Height) / 2);
        }

        // Calculate CellPadding among Actions if ActionContent is LinearLayout.
        private void CalculateActionsCellPadding()
        {
            if ((ActionContent != DefaultActionContent) || (ActionContent.Layout is LinearLayout == false))
            {
                return;
            }

            if (Actions == null)
            {
                return;
            }

            var size = Size2D;
            var layout = ActionContent.Layout as LinearLayout;
            int count = 0;

            if (layout.LinearOrientation == LinearLayout.Orientation.Horizontal)
            {
                int actionsWidth = 0;

                foreach (var action in Actions)
                {
                    actionsWidth += ((View)action).Size2D.Width + ((((View)action).Margin?.Start + ((View)action).Margin?.End) ?? 0);
                    count++;
                }

                if (count > 1)
                {
                    actionsWidth += (Padding?.Start + Padding?.End) ?? 0;
                    var cellPaddingWidth = (size.Width - actionsWidth) / (count - 1);
                    layout.CellPadding = new Size2D(cellPaddingWidth , 0);
                }
            }
            else
            {
                int actionsHeight = 0;

                foreach (var action in Actions)
                {
                    actionsHeight += ((View)action).Size2D.Height + ((((View)action).Margin?.Top + ((View)action).Margin?.Bottom) ?? 0);
                    count++;
                }

                if (count > 1)
                {
                    actionsHeight += (Padding?.Top + Padding?.Bottom) ?? 0;
                    var cellPaddingHeight = (size.Height - actionsHeight) / (count - 1);
                    layout.CellPadding = new Size2D(0, cellPaddingHeight);
                }
            }
        }
    }
}
