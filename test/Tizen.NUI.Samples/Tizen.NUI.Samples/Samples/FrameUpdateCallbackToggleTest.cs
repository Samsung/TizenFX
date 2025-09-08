using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class FrameUpdateCallbackToggleTest : IExample
    {
        private Window window;
        private View imageView;
        private TextLabel visibleLabel;
        private TextLabel ignoredLabel;
        private IgnoredToggler ignoredToggler;

        // FrameUpdateCallback to toggle the ignored state of an actor
        private class IgnoredToggler : FrameUpdateCallbackInterface
        {
            private const float IntervalSeconds = 2.0f;
            private float elapsedTime;
            private bool currentlyIgnored;
            private uint imageViewId;
            private uint visibleLabelId;
            private uint ignoredLabelId;

            public IgnoredToggler(uint imageViewId, uint visibleLabelId, uint ignoredLabelId)
                : base(1u) // Use version 1 of the callback to return a boolean
            {
                this.imageViewId = imageViewId;
                this.visibleLabelId = visibleLabelId;
                this.ignoredLabelId = ignoredLabelId;
                this.elapsedTime = 0.0f;
                this.currentlyIgnored = false;
            }

            public override bool OnUpdate(FrameUpdateCallbackInterface obj, float elapsedSeconds)
            {
                elapsedTime += elapsedSeconds;

                if (elapsedTime >= IntervalSeconds)
                {
                    currentlyIgnored = !currentlyIgnored;
                    SetIgnored(imageViewId, currentlyIgnored);
                    // Control label visibility using SetIgnored to ensure thread safety
                    SetIgnored(visibleLabelId, currentlyIgnored); // Hide "Visible" label when main actor is ignored
                    SetIgnored(ignoredLabelId, !currentlyIgnored); // Show "Ignored" label when main actor is ignored
                    elapsedTime = 0.0f; // Reset timer
                }

                return true; // Keep the callback alive
            }
        }

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            window.BackgroundColor = Color.White;
            window.KeyEvent += OnKeyEvent;

            // Create an ImageView to visually demonstrate the ignored state
            imageView = new View()
            {
                Size = new Size(200, 200),
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                BackgroundColor = Color.Red,
                Name = "demoImageView"
            };
            window.GetDefaultLayer().Add(imageView);

            // Create TextLabels to display the ignored state
            // "Visible" Label
            visibleLabel = new TextLabel("Visible")
            {
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                TextColor = Color.Black,
                HorizontalAlignment = HorizontalAlignment.Center,
                PointSize = 12
            };
            window.GetDefaultLayer().Add(visibleLabel); // Add to window directly

            // "Ignored" Label
            ignoredLabel = new TextLabel("Ignored")
            {
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                TextColor = Color.Red, // Use red to distinguish
                HorizontalAlignment = HorizontalAlignment.Center,
                PointSize = 12
            };
            window.GetDefaultLayer().Add(ignoredLabel); // Add to window directly

            // Set initial visibility for labels using SetIgnored for consistency
            // Initially, ignoredLabel should be in an 'ignored' state so it's not visible.
            // We call SetIgnored directly here as we are on the main thread.
            // Note: SetIgnored on an actor from the main thread sends a message to the update thread.
            // Use the Ignored property directly on the View if available.
            ignoredLabel.Ignored = true; // Initially ignored

            // Get the actor IDs for the FrameUpdateCallback
            uint imageViewId = imageView.ID;
            uint visibleLabelId = visibleLabel.ID;
            uint ignoredLabelId = ignoredLabel.ID;

            // Create and add the frame callback to toggle the ignored state every 2 seconds
            ignoredToggler = new IgnoredToggler(imageViewId, visibleLabelId, ignoredLabelId);
            // Pass null as the root view, as the callback doesn't need to be tied to a specific view's lifecycle
            // and Layer cannot be directly cast to View for this method.
            window.AddFrameUpdateCallback(ignoredToggler, null);
        }

        public void Deactivate()
        {
            if (ignoredToggler != null)
            {
                window.RemoveFrameUpdateCallback(ignoredToggler);
                ignoredToggler = null;
            }

            if (ignoredLabel != null)
            {
                ignoredLabel.Unparent();
                ignoredLabel.Dispose();
                ignoredLabel = null;
            }

            if (visibleLabel != null)
            {
                visibleLabel.Unparent();
                visibleLabel.Dispose();
                visibleLabel = null;
            }

            if (imageView != null)
            {
                imageView.Unparent();
                imageView.Dispose();
                imageView = null;
            }

            if (window != null)
            {
                window.KeyEvent -= OnKeyEvent;
                window = null;
            }
        }

        private void OnKeyEvent(object source, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Escape" || e.Key.KeyPressedName == "Back")
                {
                    Deactivate();
                }
            }
        }
    }
}
