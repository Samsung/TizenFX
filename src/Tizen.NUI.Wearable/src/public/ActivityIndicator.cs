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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Wearable
{
    /// <summary>
    /// The ActivityIndicator informs users of the ongoing operation.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ActivityIndicator : Control
    {
        /// <summary>Bindable property of Thickness</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThicknessProperty = BindableProperty.Create(nameof(Thickness), typeof(float), typeof(ActivityIndicator), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = ((ActivityIndicator)bindable);
            var thickness = (float?)newValue;

            ((ActivityIndicatorStyle)instance.viewStyle).Thickness = thickness;
            instance.UpdateThickness(thickness ?? 0);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ActivityIndicatorStyle)((ActivityIndicator)bindable).viewStyle)?.Thickness ?? 0;
        });

        private static readonly PropertyValue alphaFunction = new PropertyValue(new Vector4(0.33f, 0f, 0.30f, 1.00f));
        private PropertyValue alphaFunctionStartAngle1;
        private PropertyValue alphaFunctionStartAngle2;
        private ArcVisual leftVisual;
        private ArcVisual rightVisual;
        private Animation animation;
        private uint interval;

        /// <summary>
        /// Create an ActivityIndicator.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ActivityIndicator(bool isFull = false) : this(new ActivityIndicatorStyle(), isFull)
        {
        }

        /// <summary>
        /// Create an ActivityIndicator with style instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ActivityIndicator(ActivityIndicatorStyle style, bool isFull = false) : base(style)
        {
            Initialize(isFull);
        }

        /// <summary>
        /// Static constructor to initialize bindable properties when loading.
        /// </summary>
        static ActivityIndicator()
        {
        }

        /// <summary>
        /// The thickness of the arcs.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Thickness
        {
            get => (float)GetValue(ThicknessProperty);
            set => SetValue(ThicknessProperty, value);
        }

        /// <summary>
        /// Play indicator animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsRunning()
        {
            return animation == null ? false : (animation.State == Animation.States.Playing);
        }

        /// <summary>
        /// Play indicator animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Run()
        {
            animation?.Stop();

            int duration = (int)(interval < 2000 ? 2000 : interval);

            AnimateVisualAdd(leftVisual, "SweepAngle", 180.0f, 0, 1000, alphaFunctionStartAngle1);
            AnimateVisualAdd(leftVisual, "SweepAngle", 75.0f, duration - 1000, duration, alphaFunctionStartAngle2);
            AnimateVisualAdd(leftVisual, "StartAngle", 2067.0f, 0, duration, alphaFunction);

            AnimateVisualAdd(rightVisual, "SweepAngle", 180.0f, 0, 1000, alphaFunctionStartAngle1);
            AnimateVisualAdd(rightVisual, "SweepAngle", 75.0f, duration - 1000, duration, alphaFunctionStartAngle2);
            AnimateVisualAdd(rightVisual, "StartAngle", 1887.0f, 0, duration, alphaFunction);

            animation = AnimateVisualAddFinish();
            animation.EndAction = Animation.EndActions.Discard;
            animation.Looping = true;
            animation.Play();
        }

        /// <summary>
        /// Stop indicator aniamtion.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Stop()
        {
            if (!IsRunning())
            {
                return;
            }

            animation.Stop();

            leftVisual.SweepAngle = 75;
            leftVisual.StartAngle = 267;

            rightVisual.SweepAngle = 75;
            rightVisual.StartAngle = 87;

            leftVisual.UpdateVisual(true);
            rightVisual.UpdateVisual(true);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnStageDisconnection()
        {
            Stop();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle GetViewStyle()
        {
            return new ActivityIndicatorStyle();
        }

        private void Initialize(bool isFull)
        {
            if (isFull)
            {
                Size = new Size(360, 360);

                // TODO interval = 4000;
            }

            interval = 3000;
            Vector4 leftCurve, tmp, rightCurve;
            SplitCubicBezier(0.333f, new Vector4(0.33f, 0f, 0.30f, 1.00f), out leftCurve, out tmp);
            SplitCubicBezier(0.667f, new Vector4(0.33f, 0f, 0.30f, 1.00f), out tmp, out rightCurve);
            alphaFunctionStartAngle1 = new PropertyValue(leftCurve);
            alphaFunctionStartAngle2 = new PropertyValue(rightCurve);

            leftVisual = new ArcVisual
            {
                SuppressUpdateVisual = true,
                Thickness = this.Thickness,
                Cap = ArcVisual.CapType.Round,
                MixColor = new Color("#05B586"),
                SweepAngle = 75,
                StartAngle = 267,
            };

            rightVisual = new ArcVisual
            {
                SuppressUpdateVisual = true,
                Thickness = this.Thickness,
                Cap = ArcVisual.CapType.Round,
                MixColor = new Color("#008CFF"),
                SweepAngle = 75,
                StartAngle = 87,
            };

            AddVisual("Left", leftVisual);
            AddVisual("Right", rightVisual);
        }

        private void UpdateThickness(float thickness)
        {
            if (leftVisual == null)
            {
                return;
            }

            leftVisual.Thickness = thickness;
            rightVisual.Thickness = thickness;

            leftVisual.UpdateVisual(true);
            rightVisual.UpdateVisual(true);
        }

        private static void SplitCubicBezier(float pivot, Vector4 curve, out Vector4 leftCurve, out Vector4 rightCurve)
        {
            if (pivot <= 0.0f || pivot >= 1.0f)
            {
                leftCurve = rightCurve = null;
                return;
            }

            var v = new Vector2(curve.X + (curve.Z - curve.X) * pivot, curve.Y + (curve.W - curve.Y) * pivot);

            // Left  Curve : (0, 0), l1, l2, l3
            // Right Curve : l3, r1, r2, r3
            var l1 = new Vector2(curve.X * pivot, curve.Y * pivot);
            var l2 = new Vector2(l1.X + (v.X - l1.X) * pivot, l1.Y + (v.Y - l1.Y) * pivot);
            var r2 = new Vector2(curve.Z + (1 - curve.Z) * pivot, curve.W + (1 - curve.W) * pivot);
            var r1 = new Vector2(v.X + (r2.X - v.X) * pivot, v.Y + (r2.Y - v.Y) * pivot);
            var l3 = new Vector2(l2.X + (r1.X - l2.X) * pivot, l2.Y + (r1.Y - l2.Y) * pivot);
            var r3 = new Vector2(1.0f, 1.0f);

            v = new Vector2(1.0f/l3.X, 1.0f/l3.Y);
            leftCurve = new Vector4(l1.X * v.X, l1.Y * v.Y, l2.X * v.X, l2.Y * v.Y);

            r1 -= l3;
            r2 -= l3;
            r3 -= l3;

            v = new Vector2(1.0f/r3.X, 1.0f/r3.Y);
            rightCurve = new Vector4(r1.X * v.X, r1.Y * v.Y, r2.X * v.X, r2.Y * v.Y);
        }
    }
}
