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

        /// <summary>
        /// Creates a new instance of TabContent.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public TabContent()
        {
            SelectedIndex = -1;
            views = new List<View>();
        }

        /// <summary>
        /// The index of the selected view.
        /// The indices of views in TabContent are basically the order of adding to TabContent by <see cref="TabView.AddTab"/>.
        /// So a view's index in TabContent can be changed whenever <see cref="TabView.AddTab"/> or <see cref="TabView.RemoveTab"/> is called.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected int SelectedIndex { get; set; }

        /// <summary>
        /// Gets the count of views.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public int ViewCount => views.Count;

        /// <summary>
        /// Adds a view to TabContent.
        /// </summary>
        /// <param name="view">A view to be added to TabContent.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument view is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal void AddView(View view)
        {
            if (view == null)
            {
                throw new ArgumentNullException(nameof(view), "view should not be null.");
            }

            views.Add(view);

            if (SelectedIndex == -1)
            {
                Select(0);
            }
        }

        /// <summary>
        /// Removes a view from TabContent.
        /// </summary>
        /// <param name="view">A view to be removed from TabContent.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument view is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the argument view does not exist in TabContent.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal void RemoveView(View view)
        {
            if (view == null)
            {
                throw new ArgumentNullException(nameof(view), "view should not be null.");
            }

            if (views.Contains(view) == false)
            {
                throw new ArgumentException("view does not exist in TabContent.", nameof(view));
            }

            int index = views.IndexOf(view);

            views.Remove(view);

            if (index == SelectedIndex)
            {
                if (views.Count == 0)
                {
                    Select(-1);
                }
                else if (SelectedIndex == views.Count)
                {
                    Select(SelectedIndex - 1);
                }
            }
        }

        /// <summary>
        /// Selects a view at the specified index of TabContent.
        /// The indices of views in TabContent are basically the order of adding to TabContent by <see cref="TabView.AddTab"/>.
        /// So a view's index in TabContent can be changed whenever <see cref="TabView.AddTab"/> or <see cref="TabView.RemoveTab"/> is called.
        /// </summary>
        /// <param name="index">The index of a view in TabContent where the view will be selected.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the index is less than -1, or greater than or equal to the number of views.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal void Select(int index)
        {
            if ((index < -1) || (index >= views.Count))
            {
                throw new ArgumentOutOfRangeException(nameof(index), "index should not be greater than or equal to -1, and less than the number of views.");
            }

            if (SelectedIndex != -1)
            {
                Remove(views[SelectedIndex]);
            }

            if (index != -1)
            {
                Add(views[index]);
            }

            SelectedIndex = index;
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
            if ((index < 0) || (index >= views.Count))
            {
                throw new ArgumentOutOfRangeException(nameof(index), "index should not be greater than or equal to 0, and less than the number of views.");
            }

            return views[index];
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
                if (views != null)
                {
                    foreach (View view in views)
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
