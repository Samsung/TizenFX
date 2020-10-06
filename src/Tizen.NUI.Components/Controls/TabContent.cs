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
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// TabContent is a class which contains a set of Views
    /// and has one of them selected.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TabContent : Control
    {
        /// <summary>
        /// The list which contains the Views in the TabContent.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private IList<View> viewList;

        private View frameView;

        /// <summary>
        /// The index of the selected View.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected int selectedIndex { get; set; }

        /// <summary>
        /// Creates a new instance of TabContent.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabContent()
        {
            selectedIndex = -1;
            viewList = new List<View>();

            frameView = new View();
            frameView.WidthSpecification = LayoutParamPolicies.MatchParent;
            frameView.HeightSpecification = LayoutParamPolicies.MatchParent;
            Add(frameView);
        }

        /// <summary>
        /// Add a View to the TabContent.
        /// </summary>
        /// <param name="view">A View to add</param>
        /// <exception cref="ArgumentNullException">view is null</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void AddView(View view)
        {
            if (view == null)
            {
                throw new ArgumentNullException(nameof(view));
            }

            viewList.Add(view);

            if (selectedIndex == -1)
            {
                Select(0);
            }

            view.WidthSpecification = LayoutParamPolicies.MatchParent;
            view.HeightSpecification = LayoutParamPolicies.MatchParent;
        }

        /// <summary>
        /// Remove a View from the TabContent.
        /// </summary>
        /// <param name="view">A View to remove</param>
        /// <exception cref="ArgumentNullException">view is null</exception>
        /// <exception cref="ArgumentException">view is not in the TabContent</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void RemoveView(View view)
        {
            if (view == null)
            {
                throw new ArgumentNullException(nameof(view));
            }
            if (!viewList.Contains(view))
            {
                throw new ArgumentException("This TabContent doesn't contain ", nameof(view));
            }

            int index = viewList.IndexOf(view);

            viewList.Remove(view);

            if (index == selectedIndex)
            {
                if (viewList.Count == 0)
                {
                    Select(-1);
                }
                else if (selectedIndex == viewList.Count)
                {
                    Select(selectedIndex - 1);
                }
            }
        }

        /// <summary>
        /// Select one object from the Views.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void Select(int index)
        {
            if (index >= viewList.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "is out of range");
            }

            if (selectedIndex != -1)
            {
                frameView.Remove(viewList[selectedIndex]);
            }
            if (index != -1)
            {
                frameView.Add(viewList[index]);
            }

            selectedIndex = index;
        }
    }
}
