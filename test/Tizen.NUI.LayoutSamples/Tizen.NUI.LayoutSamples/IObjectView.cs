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
    public class WidthSpecificationChangedEventArgs : EventArgs
    {
        private int widthSpecification;

        public WidthSpecificationChangedEventArgs(int changedValue)
        {
            widthSpecification = changedValue;
        }

        public int WidthSpecification
        {
            get
            {
                return widthSpecification;
            }
        }
    }

    public class HeightSpecificationChangedEventArgs : EventArgs
    {
        private int heightSpecification;

        public HeightSpecificationChangedEventArgs(int changedValue)
        {
            heightSpecification = changedValue;
        }

        public int HeightSpecification
        {
            get
            {
                return heightSpecification;
            }
        }
    }

    public class MarginChangedEventArgs : EventArgs
    {
        private Extents margin;

        public MarginChangedEventArgs(Extents changedValue)
        {
            margin = new Extents(changedValue);
        }

        public Extents Margin
        {
            get
            {
                return margin;
            }
        }
    }

    public class PaddingChangedEventArgs : EventArgs
    {
        private Extents padding;

        public PaddingChangedEventArgs(Extents changedValue)
        {
            padding = new Extents(changedValue);
        }

        public Extents Padding
        {
            get
            {
                return padding;
            }
        }
    }

    public interface IObjectView
    {
        public int WidthSpecification { get; set; }
        public int HeightSpecification { get; set; }
        public Extents Margin { get; set; }
        public Extents Padding { get; set; }

        public event EventHandler<WidthSpecificationChangedEventArgs> WidthSpecificationChanged;
        public event EventHandler<HeightSpecificationChangedEventArgs> HeightSpecificationChanged;
        public event EventHandler<MarginChangedEventArgs> MarginChanged;
        public event EventHandler<PaddingChangedEventArgs> PaddingChanged;
    }
}
