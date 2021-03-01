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
using Tizen.NUI.Components;
using System.Collections.Generic;

namespace Tizen.NUI.Wearable
{
    /// <summary>
    /// [Draft] This class implements a fish eye layout
    /// </summary>
    internal class FishEyeLayoutManager : RecycleLayoutManager
    {
        public int CurrentFocusedIndex { get; set; } = 0;
        public int FocusedIndex { get; set; } = 0;
        public FishEyeLayoutManager()
        {
        }

        private float FindCandidatePosition(float startPosition, float scrollPosition, bool isBack)
        {
            // There are two ellipses which return how much scale needed.
            // We can find candidate position by intersection of ellipse and line.
            // Item size is always determined before calculation, so can get angle of it by height/width when orientation is vertical.
            // Y intercept is on previous item.

            double center = Math.Abs(scrollPosition);
            double result = isBack ? center + 180.0f : center - 180.0f;

            // double newFactor = Math.Pow(180,2) / CalculateXFactor(0);
            double angle = ItemSize.Height / ItemSize.Width;
            double intercept = (startPosition - center);
            double constant = Math.Sqrt(Math.Pow((180 * 333), 2) / (Math.Pow(333, 2) - Math.Pow(153, 2)));

            double semiMajorAxis = 333.0;
            double centerOfEllipse = -153.0;
            double centerOfEllipse2 = 153.0;

            // Find intersection using qurdratic formula.
            // We have two different equations because there are two different ellipse.
            double a = Math.Pow(semiMajorAxis, 2) + Math.Pow(angle * constant, 2);
            double b = -(intercept * Math.Pow(semiMajorAxis, 2) + centerOfEllipse * Math.Pow(angle * constant, 2));
            double c = Math.Pow(intercept * semiMajorAxis, 2) + Math.Pow(angle * constant * centerOfEllipse, 2) - Math.Pow(angle * constant * semiMajorAxis, 2);
            double b2 = -(intercept * Math.Pow(semiMajorAxis, 2) + centerOfEllipse2 * Math.Pow(angle * constant, 2));
            double c2 = Math.Pow(intercept * semiMajorAxis, 2) + Math.Pow(angle * constant * centerOfEllipse2, 2) - Math.Pow(angle * constant * semiMajorAxis, 2);

            double result1 = (-b + Math.Sqrt((Math.Pow(b, 2) - a * c))) / a;
            double result2 = (-b - Math.Sqrt((Math.Pow(b, 2) - a * c))) / a;
            double result3 = (-b2 + Math.Sqrt((Math.Pow(b2, 2) - a * c2))) / a;
            double result4 = (-b2 - Math.Sqrt((Math.Pow(b2, 2) - a * c2))) / a;

            result = isBack ? result1 : result4;
            return (float)(center + result);
        }


        public override float CalculateLayoutOrientationSize()
        {
            return StepSize * (DataCount-1);
        }

        public override void Layout(float scrollPosition)
        {
            RecycleItem centerItem = Container.Children[FocusedIndex] as RecycleItem;
            if (centerItem == null)
            {
                return;
            }

            float centerItemPosition = LayoutOrientation == Orientation.Horizontal ? centerItem.Position.X : centerItem.Position.Y;

            Vector2 stepRange = new Vector2(-scrollPosition - StepSize + 1.0f, -scrollPosition + StepSize - 1.0f);
            Vector2 visibleRange = new Vector2(Math.Abs(scrollPosition) - 180, Math.Abs(scrollPosition) + 180);

            if (StepSize != 0 && centerItemPosition <= stepRange.X)
            {
                FocusedIndex = Math.Min(Container.Children.Count - 1, FocusedIndex + 1);
                centerItem = Container.Children[FocusedIndex] as RecycleItem;
                if (centerItem != null)
                {
                    centerItem.Position = new Position(0.0f, Math.Abs(StepSize * (centerItem.DataIndex)));
                    centerItem.Scale = new Vector3(1.0f, 1.0f, 1.0f);
                }
            }
            else if (StepSize != 0 && centerItemPosition >= stepRange.Y)
            {
                FocusedIndex = Math.Max(0, FocusedIndex - 1);
                centerItem = Container.Children[FocusedIndex] as RecycleItem;
                if (centerItem != null)
                {
                    centerItem.Position = new Position(0.0f, Math.Abs(StepSize * (centerItem.DataIndex)));
                    centerItem.Scale = new Vector3(1.0f, 1.0f, 1.0f);
                }
            }
            else
            {
                float centerItemScale = CalculateScaleFactor(centerItemPosition, scrollPosition);
                centerItem.Scale = new Vector3(centerItemScale, centerItemScale, 1.0f);
            }

            RecycleItem prevItem = centerItem;
            if (prevItem == null)
            {
                return;
            }

            // Front of center item
            for (int i = FocusedIndex - 1; i > -1; i--)
            {
                RecycleItem target = Container.Children[i] as RecycleItem;
                if (target == null)
                {
                    continue;
                }

                float prevItemPosition = LayoutOrientation == Orientation.Horizontal ? prevItem.Position.X : prevItem.Position.Y;
                float prevItemSize = (LayoutOrientation == Orientation.Horizontal ? prevItem.Size.Width : prevItem.Size.Height);
                float prevItemCurrentSize = (LayoutOrientation == Orientation.Horizontal ? prevItem.GetCurrentSizeFloat().Width : prevItem.GetCurrentSizeFloat().Height);
                prevItemSize = prevItemCurrentSize == 0 ? prevItemSize : prevItemCurrentSize;
                prevItemSize = prevItemSize * prevItem.Scale.X;

                float startPosition = prevItemPosition - prevItemSize / 2.0f;

                if (startPosition > visibleRange.X)
                {
                    float candidatePosition = visibleRange.X;
                    candidatePosition = FindCandidatePosition(startPosition, scrollPosition, false);
                    target.Position = LayoutOrientation == Orientation.Horizontal ?
                                new Position(candidatePosition, target.Position.Y) :
                                new Position(target.Position.X, candidatePosition);

                    float scaleFactor = CalculateScaleFactor(candidatePosition, scrollPosition);
                    target.Scale = new Vector3(scaleFactor, scaleFactor, 1.0f);

                    prevItem = target;
                }
                else
                {
                    target.Scale = new Vector3(0.0f, 0.0f, 1.0f);
                }
            }

            prevItem = centerItem;

            // Back of center item
            for (int i = FocusedIndex + 1; i < Container.Children.Count; i++)
            {
                RecycleItem target = Container.Children[i] as RecycleItem;
                if (target == null)
                {
                    continue;
                }

                float prevItemPosition = LayoutOrientation == Orientation.Horizontal ? prevItem.Position.X : prevItem.Position.Y;
                float prevItemSize = (LayoutOrientation == Orientation.Horizontal ? prevItem.Size.Width : prevItem.Size.Height);
                float prevItemCurrentSize = (LayoutOrientation == Orientation.Horizontal ? prevItem.GetCurrentSizeFloat().Width : prevItem.GetCurrentSizeFloat().Height);
                prevItemSize = prevItemCurrentSize == 0 ? prevItemSize : prevItemCurrentSize;
                prevItemSize = prevItemSize * prevItem.Scale.X;

                float startPosition = prevItemPosition + prevItemSize / 2.0f;

                if (startPosition < visibleRange.Y)
                {
                    float candidatePosition = visibleRange.Y;
                    candidatePosition = FindCandidatePosition(startPosition, scrollPosition, true);
                    target.Position = LayoutOrientation == Orientation.Horizontal ?
                                new Position(candidatePosition, target.Position.Y) :
                                new Position(target.Position.X, candidatePosition);

                    float scaleFactor = CalculateScaleFactor(candidatePosition, scrollPosition);
                    target.Scale = new Vector3(scaleFactor, scaleFactor, 1.0f);

                    prevItem = target;
                }
                else
                {
                    target.Scale = new Vector3(0.0f, 0.0f, 1.0f);
                }
            }

            if (StepSize == 0)
            {
                if (LayoutOrientation == Orientation.Horizontal)
                {
                    StepSize = Container.Children[0].Size.Width / 2.0f + Container.Children[1].Size.Width * Container.Children[1].Scale.X / 2.0f;
                }
                else
                {
                    StepSize = Container.Children[0].Size.Height / 2.0f + Container.Children[1].Size.Height * Container.Children[1].Scale.X / 2.0f;
                }

                StepSize = float.IsNaN(StepSize)?0:StepSize;
            }
        }

        public override List<RecycleItem> Recycle(float scrollPosition)
        {
            List<RecycleItem> result = new List<RecycleItem>();

            bool isBack = scrollPosition - PrevScrollPosition < 0;

            int previousFocusIndex = FocusedIndex;

            if (!isBack && FocusedIndex < 6)
            {
                RecycleItem target = Container.Children[Container.Children.Count - 1] as RecycleItem;
                if (target != null)
                {
                    int previousSiblingOrder = target.SiblingOrder;
                    target.SiblingOrder = 0;
                    target.DataIndex = target.DataIndex - Container.Children.Count;
                    target.Position = new Position(0, Math.Abs(scrollPosition) - 360);
                    target.Scale = new Vector3(0, 0, 0);

                    result.Add(target);

                    FocusedIndex++;
                }
            }
            else if (isBack && FocusedIndex > 8)
            {
                RecycleItem target = Container.Children[0] as RecycleItem;
                if (target != null)
                {
                    int previousSiblingOrder = target.SiblingOrder;
                    target.SiblingOrder = Container.Children.Count - 1;
                    target.DataIndex = target.DataIndex + Container.Children.Count;
                    target.Position = new Position(0, Math.Abs(scrollPosition) + 360);
                    target.Scale = new Vector3(0, 0, 0);

                    result.Add(target);

                    FocusedIndex--;
                }
            }

            PrevScrollPosition = scrollPosition;

            return result;
        }

        private double CalculateXFactor(double y)
        {
            double factor1 = Math.Pow(180, 2);
            double factor2 = Math.Pow(333, 2);
            double factor3 = Math.Pow((y + 153), 2);

            return Math.Sqrt(factor1 - (factor1 / factor2 * factor3));
        }

        private float CalculateScaleFactor(float position, float scrollPosition)
        {
            float origin = Math.Abs(scrollPosition);
            float diff = position - origin;

            diff = Math.Max(diff, -180);
            diff = Math.Min(diff, 180);
            diff = Math.Abs(diff);

            float result = (float)(CalculateXFactor(diff) / CalculateXFactor(0));
            return result;
        }

        public override float CalculateCandidateScrollPosition(float scrollPosition)
        {
            int value = (int)(Math.Abs(scrollPosition) / StepSize);
            float remain = Math.Abs(scrollPosition) % StepSize;

            int newValue = remain > StepSize / 2.0f ? value + 1 : value;

            CurrentFocusedIndex = newValue;
            return -newValue * StepSize;
        }
    }
}
