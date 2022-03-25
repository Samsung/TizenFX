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
using System;

namespace Tizen.NUI.LayoutSamples
{
    public class LinearOrientationChangedEventArgs : EventArgs
    {
        private LinearLayout.Orientation linearOrientation;

        public LinearOrientationChangedEventArgs(LinearLayout.Orientation changedValue)
        {
            linearOrientation = changedValue;
        }

        public LinearLayout.Orientation LinearOrientation
        {
            get
            {
                return linearOrientation;
            }
        }
    }

    public class CellPaddingChangedEventArgs : EventArgs
    {
        private Size2D cellPadding;

        public CellPaddingChangedEventArgs(Size2D changedValue)
        {
            cellPadding = new Size2D(changedValue.Width, changedValue.Height);
        }

        public Size2D CellPadding
        {
            get
            {
                return cellPadding;
            }
        }
    }

    public class HorizontalAlignmentChangedEventArgs : EventArgs
    {
        private HorizontalAlignment horizontalAlignment;

        public HorizontalAlignmentChangedEventArgs(HorizontalAlignment changedValue)
        {
            horizontalAlignment = changedValue;
        }

        public HorizontalAlignment HorizontalAlignment
        {
            get
            {
                return horizontalAlignment;
            }
        }
    }

    public class VerticalAlignmentChangedEventArgs : EventArgs
    {
        private VerticalAlignment verticalAlignment;

        public VerticalAlignmentChangedEventArgs(VerticalAlignment changedValue)
        {
            verticalAlignment = changedValue;
        }

        public VerticalAlignment VerticalAlignment
        {
            get
            {
                return verticalAlignment;
            }
        }
    }

    public class ObjectLinearLayout : LinearLayout, IObjectLayout
    {
        public new LinearLayout.Orientation LinearOrientation
        {
            get
            {
                return base.LinearOrientation;
            }

            set
            {
                if (base.LinearOrientation == value) return;

                base.LinearOrientation = value;
                LinearOrientationChanged?.Invoke(this, new LinearOrientationChangedEventArgs(base.LinearOrientation));
            }
        }

        public new Size2D CellPadding
        {
            get
            {
                return base.CellPadding;
            }

            set
            {
                if (base.CellPadding.EqualTo(value)) return;

                base.CellPadding = new Size2D(value.Width, value.Height);
                CellPaddingChanged?.Invoke(this, new CellPaddingChangedEventArgs(base.CellPadding));
            }
        }

        public new HorizontalAlignment HorizontalAlignment
        {
            get
            {
                return base.HorizontalAlignment;
            }

            set
            {
                if (base.HorizontalAlignment == value) return;

                base.HorizontalAlignment = value;
                HorizontalAlignmentChanged?.Invoke(this, new HorizontalAlignmentChangedEventArgs(base.HorizontalAlignment));
            }
        }

        public new VerticalAlignment VerticalAlignment
        {
            get
            {
                return base.VerticalAlignment;
            }

            set
            {
                if (base.VerticalAlignment == value) return;

                base.VerticalAlignment = value;
                VerticalAlignmentChanged?.Invoke(this, new VerticalAlignmentChangedEventArgs(base.VerticalAlignment));
            }
        }

        public event EventHandler<LinearOrientationChangedEventArgs> LinearOrientationChanged;
        public event EventHandler<CellPaddingChangedEventArgs> CellPaddingChanged;
        public event EventHandler<HorizontalAlignmentChangedEventArgs> HorizontalAlignmentChanged;
        public event EventHandler<VerticalAlignmentChangedEventArgs> VerticalAlignmentChanged;
    }
}
