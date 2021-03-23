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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Types of the action button of AlertDialog.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum AlertDialogActionButtonType
    {
        /// <summary>
        /// Type of the positive action button.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Positive,

        /// <summary>
        /// Type of the negative action button.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Negative
    }

    /// <summary>
    /// AlertDialog class shows a dialog with title, message and action buttons.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AlertDialog : Dialog
    {
        private string title = null;
        private string message = null;

        private View popupTitle = null;
        private View popupContent = null;
        private View popupAction = null;

        private View defaultTitleContent = null;
        private View defaultContent = null;
        private View defaultActionContent = null;

        private Button positiveButton = null;
        private Button negativeButton = null;

        /// <summary>
        /// Creates a new instance of AlertDialog.
        /// </summary>
        /// <param name="title">The title of AlertDialog.</param>
        /// <param name="message">The message of AlertDialog.</param>
        /// <param name="positiveButtonText">The positive button text in the action content of AlertDialog.</param>
        /// <param name="positiveButtonClickedHandler">The clicked callback of the positive button in the action content of AlertDialog.</param>
        /// <param name="negativeButtonText">The negative button text in the action content of AlertDialog.</param>
        /// <param name="negativeButtonClickedHandler">The clicked callback of the negative button in the action content of AlertDialog.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AlertDialog(string title, string message, string positiveButtonText, EventHandler<ClickedEventArgs> positiveButtonClickedHandler, string negativeButtonText = null, EventHandler<ClickedEventArgs> negativeButtonClickedHandler = null) : base()
        {
            //Content is initialized to add TitleContent, BodyContent and ActionContent.
            //FIXME: Needs to separate GUI implementation codes to style cs file.
            InitContent();

            //Title setter calls TitleContent setter if TitleContent is null.
            Title = title;

            //Message setter calls BodyContent setter if BodyContent is null.
            Message = message;

            ActionContent = CreateActionContent(positiveButtonText, positiveButtonClickedHandler, negativeButtonText, negativeButtonClickedHandler);
        }

        /// <summary>
        /// Creates a new instance of AlertDialog.
        /// </summary>
        /// <param name="message">The message of AlertDialog.</param>
        /// <param name="positiveButtonText">The positive button text in the action content of AlertDialog.</param>
        /// <param name="positiveButtonClickedHandler">The clicked callback of the positive button in the action content of AlertDialog.</param>
        /// <param name="negativeButtonText">The negative button text in the action content of AlertDialog.</param>
        /// <param name="negativeButtonClickedHandler">The clicked callback of the negative button in the action content of AlertDialog.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AlertDialog(string message, string positiveButtonText, EventHandler<ClickedEventArgs> positiveButtonClickedHandler, string negativeButtonText = null, EventHandler<ClickedEventArgs> negativeButtonClickedHandler = null) : this(null, message, positiveButtonText, positiveButtonClickedHandler, negativeButtonText, negativeButtonClickedHandler)
        {
        }

        /// <summary>
        /// Creates a new instance of AlertDialog.
        /// </summary>
        /// <param name="title">The title of AlertDialog.</param>
        /// <param name="message">The message of AlertDialog.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AlertDialog(string title, string message) : this(title, message, null, null, null, null)
        {
        }

        /// <summary>
        /// Creates a new instance of AlertDialog.
        /// </summary>
        /// <param name="message">The message of AlertDialog.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AlertDialog(string message) : this(null, message)
        {
        }

        /// <summary>
        /// Creates a new instance of AlertDialog.
        /// </summary>
        /// <param name="titleContent">The title content of AlertDialog.</param>
        /// <param name="bodyContent">The content of AlertDialog.</param>
        /// <param name="actionContent">The action content of AlertDialog.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AlertDialog(View titleContent, View bodyContent, View actionContent) : base()
        {
            //Content is initialized to add TitleContent, BodyContent and ActionContent.
            //FIXME: Needs to separate GUI implementation codes to style cs file.
            InitContent();

            TitleContent = titleContent;

            BodyContent = bodyContent;

            ActionContent = actionContent;
        }

        /// <summary>
        /// Creates a new instance of AlertDialog.
        /// </summary>
        /// <param name="bodyContent">The content of AlertDialog.</param>
        /// <param name="actionContent">The action content of AlertDialog.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AlertDialog(View bodyContent, View actionContent) : this(null, bodyContent, actionContent)
        {
        }

        /// <summary>
        /// Creates a new instance of AlertDialog.
        /// </summary>
        /// <param name="bodyContent">The content of AlertDialog.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AlertDialog(View bodyContent = null) : this(bodyContent, null)
        {
        }

        private void InitContent()
        {
            var content = new Control();

            var linearLayout = new LinearLayout();
            linearLayout.LinearOrientation = LinearLayout.Orientation.Vertical;
            content.Layout = linearLayout;

            Content = content;
        }

        /// <summary>
        /// Title content of AlertDialog. TitleContent is added to Children automatically.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View TitleContent
        {
            get
            {
                return popupTitle;
            }
            set
            {
                if (popupTitle == value)
                {
                    return;
                }

                if (popupTitle != null)
                {
                    Remove(popupTitle);
                }

                popupTitle = value;
                if (popupTitle == null)
                {
                    return;
                }

                ResetContent();
            }
        }

        /// <summary>
        /// BodyContent of AlertDialog. BodyContent is added to Children automatically.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View BodyContent
        {
            get
            {
                return popupContent;
            }
            set
            {
                if (popupContent == value)
                {
                    return;
                }

                if (popupContent != null)
                {
                    Remove(popupContent);
                }

                popupContent = value;
                if (popupContent == null)
                {
                    return;
                }

                ResetContent();
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
                return popupAction;
            }
            set
            {
                if (popupAction == value)
                {
                    return;
                }

                if (popupAction != null)
                {
                    Remove(popupAction);
                }

                popupAction = value;
                if (popupAction == null)
                {
                    return;
                }

                ResetContent();
            }
        }

        private void ResetContent()
        {
            if (Content == null)
            {
                return;
            }

            //To keep the order of TitleContent, BodyContent and ActionContent,
            //the existing contents are removed and added again.
            if (popupTitle != null)
            {
                Content.Remove(popupTitle);
            }

            if (popupContent != null)
            {
                Content.Remove(popupContent);
            }

            if (popupAction != null)
            {
                Content.Remove(popupAction);
            }

            if (popupTitle != null)
            {
                Content.Add(popupTitle);
            }

            if (popupContent != null)
            {
                Content.Add(popupContent);
            }

            if (popupAction != null)
            {
                Content.Add(popupAction);
            }
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
                if (title == null)
                {
                    if (TitleContent != null)
                    {
                        //TitleContent setter calls Remove(popupTitle).
                        TitleContent = null;
                    }
                }
                else
                {
                    if (TitleContent == null)
                    {
                        TitleContent = CreateTitleContent(title);
                    }
                    else if (TitleContent == defaultTitleContent)
                    {
                        //Sets text if TitleContent is not set by user.
                        ((TextLabel)TitleContent).Text = title;
                    }
                }
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
                if (message == null)
                {
                    if (BodyContent != null)
                    {
                        //BodyContent setter calls Remove(popupContent).
                        BodyContent = null;
                    }
                }
                else
                {
                    if (BodyContent == null)
                    {
                        BodyContent = CreateContent(message);
                    }
                    else if (BodyContent == defaultContent)
                    {
                        //Sets text if BodyContent is not set by user.
                        ((TextLabel)BodyContent).Text = message;
                    }
                }
            }
        }

        /// <summary>
        /// Sets action button in the action content of AlertDialog.
        /// </summary>
        /// <param name="type">The type of action button.</param>
        /// <param name="text">The text of action button in the action content of AlertDialog.</param>
        /// <param name="clickedHandler">The clicked callback of the action button in the action content of AlertDialog.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetActionButton(AlertDialogActionButtonType type, string text, EventHandler<ClickedEventArgs> clickedHandler)
        {
            if (ActionContent == null)
            {
                if (type == AlertDialogActionButtonType.Positive)
                {
                    ActionContent = CreateActionContent(text, clickedHandler, null, null);
                }
                else
                {
                    ActionContent = CreateActionContent(null, null, text, clickedHandler);
                }
            }
            else if (ActionContent == defaultActionContent)
            {
                //To keep the order of negativeButton and positiveButton,
                //positiveButton is always removed.
                if (positiveButton != null)
                {
                    ActionContent.Remove(positiveButton);
                }

                if (type == AlertDialogActionButtonType.Negative)
                {
                    if (negativeButton != null)
                    {
                        ActionContent.Remove(negativeButton);
                    }

                    negativeButton = CreateActionButton(text, clickedHandler);
                    if (negativeButton != null)
                    {
                        ActionContent.Add(negativeButton);

                        if (positiveButton != null)
                        {
                            ActionContent.Add(positiveButton);
                        }
                    }
                }
                else
                {
                    positiveButton = CreateActionButton(text, clickedHandler);
                    if (positiveButton != null)
                    {
                        ActionContent.Add(positiveButton);
                    }
                }
            }
        }

        private TextLabel CreateTitleContent(string text)
        {
            if (text == null)
            {
                return null;
            }

            //FIXME: Needs to separate GUI implementation codes to style cs file.
            var titleContent = new TextLabel(text);
            titleContent.HorizontalAlignment = HorizontalAlignment.Center;
            titleContent.VerticalAlignment = VerticalAlignment.Center;
            titleContent.BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            titleContent.Size = new Size(360, 80);

            defaultTitleContent = titleContent;

            return titleContent;
        }

        private TextLabel CreateContent(string message)
        {
            if (message == null)
            {
                return null;
            }

            //FIXME: Needs to separate GUI implementation codes to style cs file.
            var messageContent = new TextLabel(message);
            messageContent.HorizontalAlignment = HorizontalAlignment.Center;
            messageContent.VerticalAlignment = VerticalAlignment.Center;
            messageContent.BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            messageContent.Size = new Size(360, 200);

            defaultContent = messageContent;

            return messageContent;
        }

        private Button CreateActionButton(string text, EventHandler<ClickedEventArgs> clickedHandler)
        {
            if (text == null)
            {
                return null;
            }

            //FIXME: Needs to separate GUI implementation codes to style cs file.
            var actionButton = new Button();
            actionButton.Text = text;
            actionButton.Size = new Size(120, 80);

            if (clickedHandler != null)
            {
                actionButton.Clicked += clickedHandler;
            }

            return actionButton;
        }

        private View CreateActionContent(string positiveButtonText, EventHandler<ClickedEventArgs> positiveButtonClickedHandler, string negativeButtonText, EventHandler<ClickedEventArgs> negativeButtonClickedHandler)
        {
            if ((negativeButtonText == null) && (positiveButtonText == null))
            {
                return null;
            }

            //FIXME: Needs to separate GUI implementation codes to style cs file.
            var actionContent = new Control();
            actionContent.BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            actionContent.Size = new Size(360, 80);

            //FIXME: Needs to separate GUI implementation codes to style cs file.
            var actionLayout = new LinearLayout();
            actionLayout.LinearOrientation = LinearLayout.Orientation.Horizontal;
            actionLayout.LinearAlignment = LinearLayout.Alignment.CenterHorizontal;
            actionLayout.CellPadding = new Size2D(10, 0);
            actionContent.Layout = actionLayout;

            negativeButton = CreateActionButton(negativeButtonText, negativeButtonClickedHandler);
            if (negativeButton != null)
            {
                actionContent.Add(negativeButton);
            }

            positiveButton = CreateActionButton(positiveButtonText, positiveButtonClickedHandler);
            if (positiveButton != null)
            {
                actionContent.Add(positiveButton);
            }

            defaultActionContent = actionContent;

            return actionContent;
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
                if (popupTitle != null)
                {
                    Utility.Dispose(popupTitle);
                }

                if (popupContent != null)
                {
                    Utility.Dispose(popupContent);
                }

                if (popupAction != null)
                {
                    if (positiveButton != null)
                    {
                        Utility.Dispose(positiveButton);
                    }

                    if (negativeButton != null)
                    {
                        Utility.Dispose(negativeButton);
                    }

                    Utility.Dispose(popupAction);
                }
            }

            base.Dispose(type);
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
    }
}
