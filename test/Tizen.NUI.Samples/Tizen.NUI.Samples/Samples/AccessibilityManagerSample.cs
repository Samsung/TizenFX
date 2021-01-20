
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Accessibility;

///////////////////////////////////////////////////////////////////////////////////////////////
///                      How to turn on and test Accessibility                              ///
/// There are two ways to turn on screen reader (TTS) in the target                         ///
///  1) Settings > Accessibility > Screen reader > On                                       ///
///  2) Open Terminal and use command :                                                     ///
///      # vconftool set -f -t bool db/setting/accessibility/tts 1                          ///
///    If you turn off screen reader, type and execute text based command below :           ///
///      # vconftool set -f -t bool db/setting/accessibility/tts 0                          ///
///////////////////////////////////////////////////////////////////////////////////////////////

namespace Tizen.NUI.Samples
{
    public class AccessibilityManagerSample : IExample
    {
        const string tag = "NUITEST";

        const int mRow = 3;
        const int mColumn = 3;
        const int mContents = mRow * mColumn;

        Size2D windowSize;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            window.BackgroundColor = Color.White;
            windowSize = window.Size;

            // Create Table
            TableView table = new TableView(mRow, mColumn)
            {
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.Center,
                ParentOrigin = ParentOrigin.Center,
                Size = new Size((float)(windowSize.Width * 0.8), (float)(windowSize.Height * 0.8)),
                BackgroundColor = new Color(0.2f, 0.5f, 0.5f, 1.0f),
                CellPadding = new Vector2(10, 10),
            };
            window.GetDefaultLayer().Add(table);

            uint exampleCount = 0;

            // Fill the contents in TableView
            for (uint row = 0; row < mRow; row++)
            {
                for (uint column = 0; column < mColumn; column++)
                {
                    TextLabel content = CreateText();
                    content.Name = "TextLabel" + exampleCount;
                    content.Text = "R" + row + " - C" + column;

                    ///////////////////////////////////////////////////////////////////////////////////////////////
                    ///                 How to set Accessibility attribute to components                        ///
                    /// 1. Create AccessibilityManager.                                                         ///
                    /// 2. Set the focus order of each view and the index of order should start 1 (one).        ///
                    /// 3. Set the information of each view's accessibility attribute.                          ///
                    ///    There are four attributes, which will be read by screen reader.                      ///
                    ///    And the order of reading is : Label -> Trait -> Value (Optional) -> Hint (Optional)  ///
                    ///////////////////////////////////////////////////////////////////////////////////////////////

                    AccessibilityManager manager = AccessibilityManager.Instance;
                    manager.SetFocusOrder(content, ++exampleCount);
                    manager.SetAccessibilityAttribute(content,
                                                    AccessibilityManager.AccessibilityAttribute.Label, content.Name);
                    manager.SetAccessibilityAttribute(content,
                                                    AccessibilityManager.AccessibilityAttribute.Trait, "Tile");
                    manager.SetAccessibilityAttribute(content,
                                                    AccessibilityManager.AccessibilityAttribute.Hint, "You can run this example");

                    table.AddChild(content, new TableView.CellPosition(row, column));
                }
            }

            // You can connect with various Accessibility action signals.
            // AccessibilityManager provides functionality of setting the focus and moving forward and backward.
            // All touch interactions for screen will work with one more finger and tap.

            AccessibilityManager.Instance.FocusedViewActivated += OnFocusedView;
        }

        TextLabel CreateText()
        {
            TextLabel label = new TextLabel();
            label.MultiLine = true;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Center;
            label.Focusable = true;
            return label;
        }

        // Do something with activated View, for example, launching another application.
        private void OnFocusedView(object source, AccessibilityManager.FocusedViewActivatedEventArgs args)
        {
            if (args.View)
            {
                // Here, in the sample, if one finger double tap, the following log will shows in terminal.
                Tizen.Log.Error(tag, "The current focused view is "+ args.View.Name +"\n");
            }
        }

        public void Deactivate()
        {
        }
    }
}