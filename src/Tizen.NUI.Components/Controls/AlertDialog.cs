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
    [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Creates a new instance of AlertDialog.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AlertDialog() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Dispose AlertDialog and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
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
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Title text of AlertDialog.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// Title content of AlertDialog. TitleContent is added to Children automatically.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// Content of AlertDialog. Content is added to Children automatically.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// Action views are added to ActionContent of AlertDialog.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// Action content of AlertDialog. ActionContent is added to Children automatically.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
            }
        }

        private TextLabel CreateDefaultTitleContent()
        {
            //FIXME: Needs to separate GUI implementation codes to style cs file.
            return new TextLabel()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 1.0f),
                Size = new Size(360, 80),
            };
        }

        private TextLabel CreateDefaultContent()
        {
            //FIXME: Needs to separate GUI implementation codes to style cs file.
            return new TextLabel()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 1.0f),
                Size = new Size(360, 200),
            };
        }

        private View CreateDefaultActionContent()
        {
            //FIXME: Needs to separate GUI implementation codes to style cs file.
            return new Control()
            {
                BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 1.0f),
                Size = new Size(360, 80),
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    LinearAlignment = LinearLayout.Alignment.CenterHorizontal,
                    CellPadding = new Size2D(10, 0),
                },
            };
        }

        private void OnRelayout(object sender, EventArgs e)
        {
            //FIXME: Needs to separate GUI implementation codes to style cs file.
            CalculatePosition();
        }

        private void CalculatePosition()
        {
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
    }
}
