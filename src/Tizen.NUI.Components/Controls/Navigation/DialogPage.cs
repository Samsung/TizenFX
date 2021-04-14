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
using System.Diagnostics.CodeAnalysis;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The DialogPage class is a class which shows a dialog on the page.
    /// DialogPage contains dialog and dimmed scrim behind the dialog.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DialogPage : Page
    {
        private View content = null;
        private View scrim = null;
        private bool enableScrim = true;

        /// <summary>
        /// Creates a new instance of a DialogPage.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DialogPage() : base()
        {
            Layout = new AbsoluteLayout();

            // DialogPage fills to parent by default.
            WidthResizePolicy = ResizePolicyType.FillToParent;
            HeightResizePolicy = ResizePolicyType.FillToParent;

            Scrim = CreateDefaultScrim();
        }

        /// <summary>
        /// Dispose DialogPage and all children on it.
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
                if (content != null)
                {
                    Utility.Dispose(content);
                }

                if (scrim != null)
                {
                    Utility.Dispose(scrim);
                }
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Content of DialogPage. Content is added to Children automatically.
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

                Add(content);

                if (Scrim != null)
                {
                    content.RaiseAbove(Scrim);
                }
            }
        }

        /// <summary>
        /// Scrim of DialogPage. Scrim is added to Children automatically.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected View Scrim
        {
            get
            {
                return scrim;
            }
            set
            {
                if (scrim == value)
                {
                    return;
                }

                if (scrim != null)
                {
                    Remove(scrim);
                }

                scrim = value;
                if (scrim == null)
                {
                    return;
                }

                Add(scrim);

                if (Content != null)
                {
                    Content.RaiseAbove(scrim);
                }

                if (EnableScrim != Scrim.Visibility)
                {
                    if (EnableScrim == true)
                    {
                        scrim.Show();
                    }
                    else
                    {
                        scrim.Hide();
                    }
                }
            }
        }

        /// <summary>
        /// Indicates to show scrim behind dialog.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableScrim
        {
            get
            {
                return enableScrim;
            }
            set
            {
                if (enableScrim == value)
                {
                    return;
                }

                enableScrim = value;

                if ((Scrim != null) && (enableScrim != Scrim.Visibility))
                {
                    if (enableScrim == true)
                    {
                        Scrim.Show();
                    }
                    else
                    {
                        Scrim.Hide();
                    }
                }
            }
        }

        /// <summary>
        /// Indicates to dismiss dialog by touching on scrim.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableDismissOnScrim { get; set; }

        private View CreateDefaultScrim()
        {
            //FIXME: Needs to separate GUI implementation codes to style cs file.
            var scrim = new VisualView();
            scrim.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.5f);
            //FIXME: Needs to set proper size to Scrim.
            scrim.Size = NUIApplication.GetDefaultWindow().Size;
            scrim.TouchEvent += (object source, TouchEventArgs e) =>
            {
                if ((EnableDismissOnScrim == true) && (e.Touch.GetState(0) == PointStateType.Up))
                {
                    this.Navigator.Pop();
                }
                return true;
            };

            return scrim;
        }

        /// <summary>
        /// Shows a dialog by pushing a dialog page containing dialog to default navigator.
        /// </summary>
        /// <param name="content">The content of Dialog.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [SuppressMessage("Microsoft.Reliability",
                         "CA2000:DisposeObjectsBeforeLosingScope",
                         Justification = "The pushed views are added to NavigationPages and are disposed in Navigator.Dispose().")]
        public static void ShowDialog(View content)
        {
            var dialogPage = new DialogPage()
            {
                Content = new Dialog()
                {
                    Content = content,
                },
            };

            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(dialogPage);
        }

        /// <summary>
        /// Shows an alert dialog by pushing a page containing the alert dialog
        /// to default navigator.
        /// </summary>
        /// <param name="title">The title of AlertDialog.</param>
        /// <param name="message">The message of AlertDialog.</param>
        /// <param name="actions">The action views of AlertDialog.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [SuppressMessage("Microsoft.Reliability",
                         "CA2000:DisposeObjectsBeforeLosingScope",
                         Justification = "The pushed views are added to NavigationPages and are disposed in Navigator.Dispose().")]
        public static void ShowAlertDialog(string title, string message, params View[] actions)
        {
            var dialogPage = new DialogPage()
            {
                Content = new AlertDialog()
                {
                    Title = title,
                    Message = message,
                    Actions =  actions,
                },
            };

            NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(dialogPage);
        }
    }
}
