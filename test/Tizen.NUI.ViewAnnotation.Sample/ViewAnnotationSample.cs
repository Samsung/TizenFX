/* Copyright (c) 2026 Samsung Electronics Co., Ltd.
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
 */

using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.ViewAnnotationSample
{
    /// <summary>
    /// Exercises the Core Actor annotation APIs on scrollable Label, ImageView, and Button actors.
    /// </summary>
    class Program : NUIApplication
    {
        private const string AppId = "org.tizen.example.NUIViewAnnotationSample";
        private const string EntityType = "Tizen.Entity.App";

        private TextLabel statusLabel;
        private int clearRestoreCount;

        protected override void OnCreate()
        {
            base.OnCreate();
            CreateView();
        }

        private void CreateView()
        {
            // Window.Instance.WindowSize = new Size(720, 1280);
            Window.Instance.BackgroundColor = Color.White;

            var scrollView = new ScrollableBase
            {
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                HideScrollbar = false,
                BackgroundColor = Color.White,
            };
            scrollView.ContentContainer.Layout = new AbsoluteLayout();
            scrollView.ContentContainer.WidthSpecification = LayoutParamPolicies.MatchParent;
            scrollView.ContentContainer.SizeHeight = 2200;
            Window.Instance.GetDefaultLayer().Add(scrollView);

            statusLabel = CreateLabel("Tap an annotated button to read its annotation.", 640, 80, 24.0f);
            statusLabel.Position = new Position(40, 30);
            statusLabel.Focusable = true;
            Annotate(statusLabel, "sample.status", "Status Label", "status");
            scrollView.ContentContainer.Add(statusLabel);

            var title = CreateLabel("View Annotation sample", 640, 90, 34.0f);
            title.Position = new Position(40, 130);
            title.HorizontalAlignment = HorizontalAlignment.Center;
            Annotate(title, "sample.title", "Sample Title", "title");
            scrollView.ContentContainer.Add(title);

            for (var index = 0; index < 4; ++index)
            {
                CreateAnnotatedCard(scrollView.ContentContainer, index, 250 + index * 440);
            }

            FocusManager.Instance.SetCurrentFocusView(statusLabel);
        }

        private void CreateAnnotatedCard(View parent, int index, int top)
        {
            var label = CreateLabel($"Label #{index + 1}: annotated scroll item", 600, 55, 24.0f);
            label.Position = new Position(60, top);
            Annotate(label, $"sample.label.{index + 1}", $"Scroll Label {index + 1}", $"label;row={index + 1}");
            parent.Add(label);

            // An ImageView is used as an image tile; its background makes the tile visible without an external asset.
            var image = new ImageView
            {
                SizeWidth = 260,
                SizeHeight = 170,
                BackgroundColor = index % 2 == 0 ? new Color(0.25f, 0.65f, 0.95f, 1.0f) : new Color(0.30f, 0.80f, 0.55f, 1.0f),
            };
            image.Position = new Position(60, top + 75);
            Annotate(image, $"sample.image.{index + 1}", $"Image Tile {index + 1}", $"image;row={index + 1}");
            parent.Add(image);

            var inspectButton = new Button
            {
                Text = $"Read Image #{index + 1} annotation",
                PointSize = 20.0f,
                SizeWidth = 320,
                SizeHeight = 75,
                BackgroundColor = new Color(0.85f, 0.90f, 1.0f, 1.0f),
            };
            inspectButton.Position = new Position(340, top + 75);
            Annotate(inspectButton, $"sample.button.inspect.{index + 1}", $"Inspect Button {index + 1}", $"button;row={index + 1}");
            inspectButton.Clicked += (sender, e) => ShowAnnotation(image, $"Image #{index + 1}");
            parent.Add(inspectButton);

            var clearRestoreButton = new Button
            {
                Text = $"Clear / restore Label #{index + 1}",
                PointSize = 20.0f,
                SizeWidth = 320,
                SizeHeight = 75,
                BackgroundColor = new Color(1.0f, 0.90f, 0.65f, 1.0f),
            };
            clearRestoreButton.Position = new Position(340, top + 170);
            Annotate(clearRestoreButton, $"sample.button.clear.{index + 1}", $"Clear/Restore Button {index + 1}", $"button;row={index + 1}");
            clearRestoreButton.Clicked += (sender, e) => ClearAndRestore(label, index + 1);
            parent.Add(clearRestoreButton);
        }

        private TextLabel CreateLabel(string text, int width, int height, float pointSize)
        {
            return new TextLabel
            {
                Text = text,
                PointSize = pointSize,
                MultiLine = true,
                SizeWidth = width,
                SizeHeight = height,
                TextColor = Color.Black,
                BackgroundColor = new Color(0.94f, 0.94f, 0.94f, 1.0f),
                BorderlineWidth = 1.0f,
            };
        }

        /// <summary>
        /// Builds the entity info carried by an annotation.
        ///
        /// The payload is the JSON of a Tizen.Entity.App produced by the actionc
        /// generated entity class (gen/ImplApp.cs), so it always matches the
        /// current schema instead of an ad-hoc string.
        /// </summary>
        private static string MakeAppEntityInfo(string entityId, string name, string role)
        {
            var entity = new RPCPort.ImplApp.TizenEntityApp
            {
                Id = entityId,
                Extra = $"role={role}",
                AppId = AppId,
                Name = name,
                DeepLink = $"nui-view-annotation://view/{entityId}",
                Params = $"view={entityId}&action=focus",
            };
            return entity.ToJson();
        }

        private void Annotate(View view, string annotationId, string name, string role)
        {
            view.SetAnnotation(annotationId, EntityType, MakeAppEntityInfo(annotationId, name, role));
        }

        private void ShowAnnotation(View view, string name)
        {
            if (view.GetAnnotation(out string annotationId, out string annotationType, out string annotationInfo))
            {
                statusLabel.Text = string.IsNullOrEmpty(annotationInfo)
                    ? string.Format("{0}: {1} ({2})", name, annotationId, annotationType)
                    : string.Format("{0}: {1} ({2}) [{3}]", name, annotationId, annotationType, annotationInfo);
            }
            else
            {
                statusLabel.Text = string.Format("{0}: annotation not found", name);
            }
        }

        private void ClearAndRestore(View target, int index)
        {
            target.ClearAnnotation();
            var removed = !target.GetAnnotation(out _, out _, out _);
            Annotate(target, $"sample.label.{index}", $"Scroll Label {index}", $"label;row={index};restored={clearRestoreCount + 1}");
            ++clearRestoreCount;
            statusLabel.Text = removed
                ? $"Label #{index}: ClearAnnotation and SetAnnotation completed ({clearRestoreCount})"
                : $"Label #{index}: annotation was not cleared";
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
