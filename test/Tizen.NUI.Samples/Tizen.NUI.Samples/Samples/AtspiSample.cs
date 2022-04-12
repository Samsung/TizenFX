
using System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class AtspiSample : IExample
    {
        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            window.BackgroundColor = Color.White;

            TextLabel text = new TextLabel("PASS");
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Center;
            text.TextColor = Color.Blue;
            text.PointSize = 12.0f;
            text.HeightResizePolicy = ResizePolicyType.FillToParent;
            text.WidthResizePolicy = ResizePolicyType.FillToParent;
            window.Add(text);

            if (text.IsAccessibilityEventSuppressed(AccessibilityEvent.MovedOut))
            {
                text.Text = "FAIL";
                Tizen.Log.Error("NUITEST", "Default value shoud be false\n");
                return;
            }

            text.SetAccessibilityEventSuppressed(AccessibilityEvent.MovedOut, true);
            if (!text.IsAccessibilityEventSuppressed(AccessibilityEvent.MovedOut))
            {
                text.Text = "FAIL";
                Tizen.Log.Error("NUITEST", "Cannot set to true\n");
                return;
            }

            text.SetAccessibilityEventSuppressed(AccessibilityEvent.MovedOut, false);
            if (text.IsAccessibilityEventSuppressed(AccessibilityEvent.MovedOut))
            {
                text.Text = "FAIL";
                Tizen.Log.Error("NUITEST", "Cannot set to false\n");
                return;
            }

            window.AccessibilityHighlight += OnWindowAccessibilityHighlight;
        }

        private void OnWindowAccessibilityHighlight(object sender, Window.AccessibilityHighlightEventArgs e)
        {
            Tizen.Log.Info("NUITEST", "Accessibility Highlight: " + e.AccessibilityHighlight + "\n");
        }

        public void Deactivate()
        {
        }
    }
}
