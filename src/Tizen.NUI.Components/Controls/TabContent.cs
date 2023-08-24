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
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// TabContent is a class which contains a set of Views and has one of them selected.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class TabContent : Control
    {
        private IList<View> views;

        private void Initialize()
        {
            SelectedIndex = -1;
            views = new List<View>();
        }

        /// <summary>
        /// Creates a new instance of TabContent.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public TabContent()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of TabContent with style.
        /// </summary>
        /// <param name="style">Creates TabContent by special style defined in UX.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabContent(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a TabContent with style.
        /// </summary>
        /// <param name="style">A style applied to the newly created TabContent.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabContent(ControlStyle style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// The index of the selected view.
        /// The indices of views in TabContent are basically the order of adding to TabContent by <see cref="TabView.AddTab"/>.
        /// So a view's index in TabContent can be changed whenever <see cref="TabView.AddTab"/> or <see cref="TabView.RemoveTab"/> is called.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected int SelectedIndex { get; set; }

        /// <summary>
        /// A list of content views.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected IList<View> Views
        {
            get
            {
                return views;
            }
        }

        /// <summary>
        /// Gets the count of views.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public int ViewCount => Views.Count;

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();

            AccessibilityRole = Role.PageTabList;
        }

        /// <summary>
        /// Adds a view to TabContent.
        /// </summary>
        /// <param name="view">A view to be added to TabContent.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument view is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void AddView(View view)
        {
            if (view == null)
            {
                throw new ArgumentNullException(nameof(view), "view should not be null.");
            }

            Views.Add(view);

            if (SelectedIndex == -1)
            {
                SelectView(0);
            }
        }

        /// <summary>
        /// Adds a view to TabContent.
        /// </summary>
        /// <param name="view">A view to be added to TabContent.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument view is null.</exception>
        internal void AddContentView(View view)
        {
            AddView(view);
        }

        /// <summary>
        /// Removes a view from TabContent.
        /// </summary>
        /// <param name="view">A view to be removed from TabContent.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument view is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the argument view does not exist in TabContent.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void RemoveView(View view)
        {
            if (view == null)
            {
                throw new ArgumentNullException(nameof(view), "view should not be null.");
            }

            if (Views.Contains(view) == false)
            {
                throw new ArgumentException("view does not exist in TabContent.", nameof(view));
            }

            int index = Views.IndexOf(view);

            Views.Remove(view);

            if (index == SelectedIndex)
            {
                if (Views.Count == 0)
                {
                    SelectView(-1);
                }
                else if (SelectedIndex == Views.Count)
                {
                    SelectView(SelectedIndex - 1);
                }
            }
        }

        /// <summary>
        /// Removes a view from TabContent.
        /// </summary>
        /// <param name="view">A view to be removed from TabContent.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument view is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the argument view does not exist in TabContent.</exception>
        internal void RemoveContentView(View view)
        {
            RemoveView(view);
        }

        /// <summary>
        /// Selects a view at the specified index of TabContent.
        /// The indices of views in TabContent are basically the order of adding to TabContent by <see cref="TabView.AddTab"/>.
        /// So a view's index in TabContent can be changed whenever <see cref="TabView.AddTab"/> or <see cref="TabView.RemoveTab"/> is called.
        /// </summary>
        /// <param name="index">The index of a view in TabContent where the view will be selected.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is less than -1, or greater than or equal to the number of views.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void SelectView(int index)
        {
            if ((index < -1) || (index >= Views.Count))
            {
                throw new ArgumentOutOfRangeException(nameof(index), "index should not be greater than or equal to -1, and less than the number of views.");
            }

            if (SelectedIndex != -1)
            {
                Remove(Views[SelectedIndex]);
            }

            if (index != -1)
            {
                Add(Views[index]);
            }

            SelectedIndex = index;
        }

        /// <summary>
        /// Selects a view at the specified index of TabContent.
        /// The indices of views in TabContent are basically the order of adding to TabContent by <see cref="TabView.AddTab"/>.
        /// So a view's index in TabContent can be changed whenever <see cref="TabView.AddTab"/> or <see cref="TabView.RemoveTab"/> is called.
        /// </summary>
        /// <param name="index">The index of a view in TabContent where the view will be selected.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is less than -1, or greater than or equal to the number of views.</exception>
        internal void SelectContentView(int index)
        {
            SelectView(index);
        }

        /// <summary>
        /// Gets the view at the specified index of TabContent.
        /// The indices of views in TabContent are basically the order of adding to TabContent by <see cref="TabView.AddTab"/>.
        /// So a view's index in TabContent can be changed whenever <see cref="TabView.AddTab"/> or <see cref="TabView.RemoveTab"/> is called.
        /// </summary>
        /// <param name="index">The index of a view in TabContent where the specified view exists.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is less than 0, or greater than or equal to the number of views.</exception>
        /// <since_tizen> 9 </since_tizen>
        public View GetView(int index)
        {
            if ((index < 0) || (index >= Views.Count))
            {
                throw new ArgumentOutOfRangeException(nameof(index), "index should not be greater than or equal to 0, and less than the number of views.");
            }

            return Views[index];
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
                if (Views != null)
                {
                    foreach (View view in Views)
                    {
                        Utility.Dispose(view);
                    }

                    views = null;
                }
            }

            base.Dispose(type);
        }
    }
}
