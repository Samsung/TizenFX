/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.MarkdownRenderer
{
    /// <summary>
    /// Represents a base visual element for rendering text in a Markdown UI.
    /// </summary>
    internal class UIText : TextLabel
    {
        internal class UITextLayout : LayoutItem
        {
            private float lastWidth = 0;
            private float lastHeight = 0;

            public void OnAsyncTextRendered(object sender, AsyncTextRenderedEventArgs e)
            {
                if (sender is UIText uiText && uiText.ManualRendered)
                {
                    SetMeasuredDimensions(new LayoutLength(e.Width), new LayoutLength(e.Height));
                    RequestLayout();
                }
            }

            protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
            {
                float totalWidth = widthMeasureSpec.Size.AsDecimal();
                float totalHeight = heightMeasureSpec.Size.AsDecimal();

                if (Owner is UIText uiText && uiText.RenderMode == TextRenderMode.AsyncManual)
                {
                    uiText.AddAsyncTextRendered();

                    if (uiText.textChanged || (lastWidth != totalWidth) || (lastHeight != totalHeight))
                    {
                        lastWidth = totalWidth;
                        lastHeight = totalHeight;
                        uiText.textChanged = false;

                        if (widthMeasureSpec.Mode == MeasureSpecification.ModeType.Exactly)
                        {
                            if (heightMeasureSpec.Mode == MeasureSpecification.ModeType.Exactly)
                            {
                                uiText.RequestAsyncRenderWithFixedSize(totalWidth, totalHeight);
                            }
                            else
                            {
                                uiText.RequestAsyncRenderWithFixedWidth(totalWidth, totalHeight);
                            }
                        }
                        else
                        {
                            uiText.RequestAsyncRenderWithConstraint(totalWidth, totalHeight);
                        }

                        float width = uiText.SizeWidth;
                        float height = uiText.SizeHeight;
                        SetMeasuredDimensions(new LayoutLength(width), new LayoutLength(height));
                    }
                }
                else
                {
                    if (widthMeasureSpec.Mode == MeasureSpecification.ModeType.Exactly)
                    {
                        if (heightMeasureSpec.Mode != MeasureSpecification.ModeType.Exactly)
                        {
                            var padding = Owner.Padding;
                            totalHeight = Owner.GetHeightForWidth(totalWidth - (padding.Start + padding.End));
                            heightMeasureSpec = new MeasureSpecification(new LayoutLength(totalHeight), MeasureSpecification.ModeType.Exactly);
                        }
                    }
                    else
                    {
                        var minWidth = Owner.MinimumSize.Width;
                        var minHeight = Owner.MinimumSize.Height;
                        var maxWidth = Owner.MaximumSize.Width;
                        var maxHeight = Owner.MaximumSize.Height;
                        var naturalSize = Owner.NaturalSize;

                        if (heightMeasureSpec.Mode == MeasureSpecification.ModeType.Exactly)
                        {
                            // GetWidthForHeight is not implemented.
                            float width = naturalSize != null ? naturalSize.Width : 0;
                            // Since priority of MinimumSize is higher than MaximumSize in DALi, here follows it.
                            totalWidth = Math.Max(Math.Min(width, maxWidth < 0 ? Int32.MaxValue : maxWidth), minWidth);
                            widthMeasureSpec = new MeasureSpecification(new LayoutLength(totalWidth), MeasureSpecification.ModeType.Exactly);
                        }
                        else
                        {
                            float width = naturalSize?.Width ?? 0;
                            width = Math.Min(width, totalWidth);

                            // Since priority of MinimumSize is higher than MaximumSize in DALi, here follows it.
                            totalWidth = Math.Max(Math.Min(width, maxWidth < 0 ? Int32.MaxValue : maxWidth), minWidth);

                            var padding = Owner.Padding;
                            float height = Owner.GetHeightForWidth(totalWidth - (padding.Start + padding.End));
                            totalHeight = Math.Max(Math.Min(height, maxHeight < 0 ? Int32.MaxValue : maxHeight), minHeight);

                            heightMeasureSpec = new MeasureSpecification(new LayoutLength(totalHeight), MeasureSpecification.ModeType.Exactly);
                            widthMeasureSpec = new MeasureSpecification(new LayoutLength(totalWidth), MeasureSpecification.ModeType.Exactly);
                        }
                    }

                    MeasuredSize.StateType childWidthState = MeasuredSize.StateType.MeasuredSizeOK;
                    MeasuredSize.StateType childHeightState = MeasuredSize.StateType.MeasuredSizeOK;

                    SetMeasuredDimensions(ResolveSizeAndState(new LayoutLength(totalWidth), widthMeasureSpec, childWidthState),
                                          ResolveSizeAndState(new LayoutLength(totalHeight), heightMeasureSpec, childHeightState));
                }
            }

            /// <inheritdoc/>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override bool IsPaddingHandledByNative()
            {
                return true;
            }
        } // UITextLayout

        private bool hasAsyncTextRendered;
        public bool textChanged;

        public UIText() : base()
        {
            Layout = new UITextLayout();
            LayoutDirectionPolicy = TextLayoutDirectionPolicy.Inherit;
        }

        public new string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                textChanged = true;
                base.Text = value;
            }
        }

        private void AddAsyncTextRendered()
        {
            if (!hasAsyncTextRendered && Layout is UITextLayout layoutItem && layoutItem != null)
            {
                AsyncTextRendered += layoutItem.OnAsyncTextRendered;
                hasAsyncTextRendered = true;
            }
        }

        private void RemoveAsyncTextRendered()
        {
            if (hasAsyncTextRendered && Layout is UITextLayout layoutItem && layoutItem != null)
            {
                AsyncTextRendered -= layoutItem.OnAsyncTextRendered;
                hasAsyncTextRendered = false;
            }
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            RemoveAsyncTextRendered();
            base.Dispose(type);
        }
    }
}
