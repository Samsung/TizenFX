/* Copyright (c) 2020 Samsung Electronics Co., Ltd.
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
using System.Globalization;
using System.Linq;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI
{
    // Methods and Properties for calculation.
    public partial class RelativeLayout
    {
        readonly static Dictionary<View, Relative> HorizontalRelativeCache = new Dictionary<View, Relative>();
        readonly static Dictionary<View, Relative> VerticalRelativeCache = new Dictionary<View, Relative>();
        private static readonly RelativePropertyGetters RelativeHorizontalPropertyGetters = new RelativePropertyGetters
        {
            RelativeCache = HorizontalRelativeCache,
            GetTargetFrom = GetLeftTarget,
            GetTargetTo = GetRightTarget,
            GetRelativeOffsetFrom = GetLeftRelativeOffset,
            GetRelativeOffsetTo = GetRightRelativeOffset,
            GetAlignment = GetHorizontalAlignment,
            GetFill = GetFillHorizontal,
            GetMeasuredSize = (item) => item.MeasuredWidth.Size.AsDecimal() + item.Margin.Start + item.Margin.End
        };
        private static readonly RelativePropertyGetters RelativeVerticalPropertyGetters = new RelativePropertyGetters
        {
            RelativeCache = VerticalRelativeCache,
            GetTargetFrom = GetTopTarget,
            GetTargetTo = GetBottomTarget,
            GetRelativeOffsetFrom = GetTopRelativeOffset,
            GetRelativeOffsetTo = GetBottomRelativeOffset,
            GetAlignment = GetVerticalAlignment,
            GetFill = GetFillVertical,
            GetMeasuredSize = (item) => item.MeasuredHeight.Size.AsDecimal() + item.Margin.Top + item.Margin.Bottom
        };

        delegate Relative GetRelative(View view, in float layoutSize);

        private bool ValidateRelative(Relative relative, in float layoutSize, bool isFixedRelative)
        {
            float spaceSize = relative.spaceGeometry.Size;
            float viewPosition = relative.viewGeometry.Position;
            float viewSize = relative.viewGeometry.Size;
            (float start, float end) space = (relative.spaceGeometry.Position, relative.spaceGeometry.Position + spaceSize);

            if (spaceSize > float.Epsilon)
            {
                if (!isFixedRelative && spaceSize < viewSize)
                    return false;

                if (space.start < 0 && space.end <= layoutSize)
                {
                    if (viewPosition + viewSize > layoutSize)
                        return false;
                }
                else if (0 <= space.start && layoutSize < space.end)
                {
                    if (viewPosition < 0)
                        return false;
                }
                else if (viewPosition < 0 || viewPosition + viewSize > layoutSize)
                {
                    return false;
                }
            }
            else if (space.start == 0.0)
            {
                if (viewPosition + viewSize > layoutSize)
                    return false;
            }
            else if (space.start == layoutSize)
            {
                if (viewPosition < 0)
                    return false;
            }
            else if (viewPosition < 0 || viewPosition + viewSize > layoutSize)
            {
                return false;
            }
            return true;
        }

        private bool ValidateRelatives(in float layoutSize, HashSet<View> fixedRelativeSet, GetRelative GetRelative)
        {
            foreach (LayoutItem childLayout in LayoutChildren.Where(item => item?.Owner != null))
            {
                Relative relative = GetRelative(childLayout.Owner, layoutSize);
                if (!ValidateRelative(relative, layoutSize, fixedRelativeSet.Contains(childLayout.Owner)))
                    return false;
            }

            return true;
        }

        private HashSet<View> GetFixedRelativeSet(in float layoutSize, GetRelative GetRelative)
        {
            HashSet<View> ignoreSet = new HashSet<View>();

            foreach (LayoutItem childLayout in LayoutChildren.Where(item => item?.Owner != null))
            {
                Relative relative = GetRelative(childLayout.Owner, layoutSize);
                if (relative.spaceGeometry.Size > float.Epsilon
                    && relative.spaceGeometry.Size < relative.viewGeometry.Size)
                {
                    ignoreSet.Add(childLayout.Owner);
                }
            }

            return ignoreSet;
        }

        private Relative GetHorizontalRelative(View view, in float layoutSize) => CalculateRelative(view, layoutSize, 0, RelativeHorizontalPropertyGetters);

        private Relative GetVerticalRelative(View view, in float layoutSize) => CalculateRelative(view, layoutSize, 0, RelativeVerticalPropertyGetters);

        private Relative CalculateRelative(View view, in float layoutSize, int depth, RelativePropertyGetters propertyGetters)
        {
            if (propertyGetters.RelativeCache.TryGetValue(view, out Relative cache))
                return cache;

            depth++;
            if (depth > LayoutChildren.Count)
            {
                throw new InvalidOperationException("Circular dependency detected in RelativeLayout.");
            }
            Relative cacheFrom;
            Relative cacheTo;
            float RelativeOffsetFrom = propertyGetters.GetRelativeOffsetFrom(view);
            float RelativeOffsetTo = propertyGetters.GetRelativeOffsetTo(view);
            float viewSize = propertyGetters.GetMeasuredSize(view.Layout);

            if (propertyGetters.GetTargetFrom(view) is View targetFrom && targetFrom != Owner)
            {
                cacheFrom = CalculateRelative(targetFrom, layoutSize, depth, propertyGetters);
            }
            else
            {
                cacheFrom = new Relative() { viewGeometry = new Geometry(0, layoutSize) };
            }

            if (propertyGetters.GetTargetTo(view) is View targetTo && targetTo != Owner)
            {
                cacheTo = CalculateRelative(targetTo, layoutSize, depth, propertyGetters);
            }
            else
            {
                cacheTo = new Relative() { viewGeometry = new Geometry(0, layoutSize) };
            }

            float startPosition = cacheFrom.viewGeometry.Position + cacheFrom.viewGeometry.Size * RelativeOffsetFrom;
            float endPosition = cacheTo.viewGeometry.Position + cacheTo.viewGeometry.Size * RelativeOffsetTo;
            if (startPosition > endPosition)
                (startPosition, endPosition) = (endPosition, startPosition);

            float alignment = propertyGetters.GetAlignment(view).ToFloat();
            bool fill = propertyGetters.GetFill(view);

            Geometry viewGeometry = new Geometry(startPosition + ((endPosition - startPosition - viewSize) * alignment), viewSize);
            Geometry spaceGeometry = new Geometry(startPosition, Math.Abs(endPosition - startPosition));
            if (fill && spaceGeometry.Size > viewGeometry.Size)
            {
                viewGeometry = spaceGeometry;
            }

            Relative retCache = new Relative
            {
                viewGeometry = viewGeometry,
                spaceGeometry = spaceGeometry
            };
            propertyGetters.RelativeCache.Add(view, retCache);

            return retCache;
        }

        private (float, float) CalculateChildrenSize(float parentWidth, float parentHeight)
        {
            int horizontalPadding = Padding.Start + Padding.End;
            int verticalPadding = Padding.Top + Padding.Bottom;
            int minWidth = (int)SuggestedMinimumWidth.AsDecimal() - horizontalPadding;
            int maxWidth = (int)parentWidth - verticalPadding;
            int minHeight = (int)SuggestedMinimumHeight.AsDecimal() - verticalPadding;
            int maxHeight = (int)parentHeight - verticalPadding;

            if (minWidth < 0) minWidth = 0;
            if (maxWidth < 0) maxWidth = 0;
            if (minHeight < 0) minHeight = 0;
            if (maxHeight < 0) maxHeight = 0;

            // Find minimum size that satisfy all constraints
            float BinarySearch(int min, int max, Dictionary<View, Relative> Cache, GetRelative GetRelative)
            {
                int current = (min != 0) ? min : (min + max) / 2;

                HashSet<View> fixedRelativeSet = GetFixedRelativeSet(max, GetRelative);
                Cache.Clear();
                do
                {
                    if (ValidateRelatives(current, fixedRelativeSet, GetRelative))
                    {
                        max = current;
                    }
                    else
                    {
                        min = current + 1;
                    }
                    current = (min + max) / 2;
                    Cache.Clear();
                } while (min < max);

                return current;
            }

            float ChildrenWidth = BinarySearch(minWidth, maxWidth, HorizontalRelativeCache, GetHorizontalRelative) + horizontalPadding;
            float ChildrenHeight = BinarySearch(minHeight, maxHeight, VerticalRelativeCache, GetVerticalRelative) + verticalPadding;
            return (ChildrenWidth, ChildrenHeight);
        }

        private Geometry GetHorizontalLayout(View view) => GetHorizontalRelative(view, MeasuredWidth.Size.AsDecimal() - (Padding.Start + Padding.End)).viewGeometry;

        private Geometry GetVerticalLayout(View view) => GetVerticalRelative(view, MeasuredHeight.Size.AsDecimal() - (Padding.Top + Padding.Bottom)).viewGeometry;

        private struct Geometry
        {
            public float Position { get; }
            public float Size { get; }

            public Geometry(float position, float size)
            {
                Position = position;
                Size = size;
            }
        }

        private struct Relative
        {
            public Geometry viewGeometry;
            public Geometry spaceGeometry;
        }
        private struct RelativePropertyGetters
        {
            public Dictionary<View, Relative> RelativeCache;
            public Func<BindableObject, View> GetTargetFrom;
            public Func<BindableObject, View> GetTargetTo;
            public Func<View, float> GetRelativeOffsetFrom;
            public Func<View, float> GetRelativeOffsetTo;
            public Func<View, Alignment> GetAlignment;
            public Func<View, bool> GetFill;
            public Func<LayoutItem, float> GetMeasuredSize;
        }

        class RelativeTargetConverter : TypeConverter, IExtendedTypeConverter
        {
            object IExtendedTypeConverter.ConvertFromInvariantString(string value, IServiceProvider serviceProvider)
            {
                if (serviceProvider == null)
                    throw new ArgumentNullException(nameof(serviceProvider));

                object target = null;

                if (serviceProvider.GetService(typeof(IReferenceProvider)) is IReferenceProvider referenceProvider)
                    target = referenceProvider.FindByName(value);

                return target ?? throw new ArgumentException($"Can't resolve name '{value}' on Element", nameof(value));
            }

            public override object ConvertFromInvariantString(string value) => throw new NotImplementedException();

            public object ConvertFrom(CultureInfo culture, object value, IServiceProvider serviceProvider) => throw new NotImplementedException();
        }
    }
}
