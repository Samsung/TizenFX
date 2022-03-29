using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Events;
using System.Collections.Generic;

namespace Tizen.NUI.Samples
{
    public class FocusManagerEventTest : IExample
    {
        private const int TestWidth = 100, TestHeight = 100;
        private Window window;
        private View rootView, left, center, right;
        private View childUpper, childLower;
        private Animation focusOut, focusIn;

        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();

            rootView = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,

                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size2D(20, 20),
                },
                Name = "rootView",
                BackgroundColor = Color.Gray,
                Focusable = true,
            };
            window.Add(rootView);

            left = new View()
            {
                Name = "left",
                WidthSpecification = TestWidth,
                HeightSpecification = TestHeight,
                BackgroundColor = Color.Red,
                Focusable = true,
            };
            rootView.Add(left);

            center = new View()
            {
                Name = "center",
                WidthSpecification = TestWidth,
                HeightSpecification = TestHeight,
                BackgroundColor = Color.Blue,
                Focusable = true,
            };
            rootView.Add(center);

            right = new View()
            {
                Name = "right",
                WidthSpecification = TestWidth * 2,
                HeightSpecification = TestHeight * 3,
                BackgroundColor = Color.Green,
                Focusable = true,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size2D(10, 10),
                },
            };
            rootView.Add(right);

            childUpper = new View()
            {
                Name = "childUpper",
                WidthSpecification = TestWidth,
                HeightSpecification = TestHeight,
                BackgroundColor = Color.Yellow,
                Focusable = true,
            };
            right.Add(childUpper);

            childLower = new View()
            {
                Name = "childLower",
                WidthSpecification = TestWidth,
                HeightSpecification = TestHeight,
                BackgroundColor = Color.Pink,
                Focusable = true,
            };
            right.Add(childLower);

            FocusManager.Instance.FocusChanging += onFocusChanging;
            FocusManager.Instance.FocusChanged += onFocusChanged;
            FocusManager.Instance.SetCurrentFocusView(center);
        }

        public void Deactivate()
        {
            rootView.Unparent();
            left.Unparent();
            center.Unparent();
            right.Unparent();
            childUpper.Unparent();
            childLower.Unparent();
            rootView.Dispose();
            left.Dispose();
            center.Dispose();
            right.Dispose();
            childUpper.Dispose();
            childLower.Dispose();
        }

        private void onFocusChanging(object sender, FocusChangingEventArgs e)
        {
            if (e.Current)
            {
                Tizen.Log.Debug("NUITEST", $"e.Current.Name={e.Current.Name}");
            }

            if (e.Proposed)
            {
                Tizen.Log.Debug("NUITEST", $"e.Proposed.Name={e.Proposed.Name}");
            }

            Tizen.Log.Debug("NUITEST", $"e.Direction.Name={e.Direction}");

            if (e.Current == left)
            {
                if (e.Direction == View.FocusDirection.Right)
                {
                    e.Proposed = center;
                }
                else
                {
                    e.Proposed = rootView;
                }
            }
            else if (e.Current == center)
            {
                if (e.Direction == View.FocusDirection.Right)
                {
                    e.Proposed = right;
                }
                else if (e.Direction == View.FocusDirection.Left)
                {
                    e.Proposed = left;
                }
                else
                {
                    e.Proposed = rootView;
                }
            }
            else if (e.Current == right)
            {
                if (e.Direction == View.FocusDirection.Left)
                {
                    e.Proposed = center;
                }
                else if (e.Direction == View.FocusDirection.Forward || e.Direction == View.FocusDirection.Backward)
                {
                    //for FocusGroup
                    e.Proposed = rootView;
                }
                else if (e.Direction == View.FocusDirection.Down)
                {
                    e.Proposed = childUpper;
                }
            }
            else if (e.Current == rootView)
            {
                if (e.Direction == View.FocusDirection.Down || e.Direction == View.FocusDirection.Right)
                {
                    e.Proposed = left;
                }
                else if (e.Direction == View.FocusDirection.Forward || e.Direction == View.FocusDirection.Backward)
                {
                    //for FocusGroup
                    e.Proposed = right;
                }
            }
            else if (e.Current == childUpper)
            {
                if (e.Direction == View.FocusDirection.Down)
                {
                    e.Proposed = childLower;
                }
                else if (e.Direction == View.FocusDirection.Up)
                {
                    e.Proposed = right;
                }
            }
            else if (e.Current == childLower)
            {
                if (e.Direction == View.FocusDirection.Down)
                {
                    e.Proposed = right;
                }
                else if (e.Direction == View.FocusDirection.Up)
                {
                    e.Proposed = childUpper;
                }
            }
            else if (e.Current == null)
            {
                e.Proposed = center;
            }
        }

        private void onFocusChanged(object sender, NUI.FocusManager.FocusChangedEventArgs e)
        {
            if (e.Previous)
            {
                Tizen.Log.Debug("NUITEST", $"e.Previous.Name={e.Previous.Name}");
                if (e.Previous != rootView && e.Previous != right)
                {
                    focusOut = new Animation(500);
                    focusOut.AnimateTo(e.Previous, "size", new Size(TestWidth * 0.7f, TestWidth * 0.7f, 0));
                    focusOut.Play();
                }
            }

            if (e.Current)
            {
                Tizen.Log.Debug("NUITEST", $"e.Current.Name={e.Current.Name}");
                if (e.Current != rootView && e.Current != right)
                {
                    focusIn = new Animation(500);
                    focusIn.AnimateTo(e.Current, "size", new Size(TestWidth, TestWidth, 0));
                    focusIn.Play();
                }
            }
        }

    }
}
