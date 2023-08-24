/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.LayoutSamples
{
    public partial class ObjectControlView : ScrollableBase, IObjectProperty<ObjectView>
    {
        private ObjectView controlView = null;

        public ObjectControlView()
        {
            InitializeComponent();
        }

        public ObjectView PropertyValue
        {
            get
            {
                return controlView;
            }

            set
            {
                SetView(controlView as IObjectView);
            }
        }

        public void SetView(IObjectView view)
        {
            if (!(view is View)) return;

            if (controlView == view as ObjectView) return;

            controlView = view as ObjectView;

            // WidthSpecification
            widthSpec.SetView(controlView);

            // HeightSpecification
            heightSpec.SetView(controlView);

            // Margin
            margin.SetView(controlView);

            // Padding
            padding.SetView(controlView);
        }
    }
}
