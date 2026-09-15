using System;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    // Demonstrates GestureDeviceSelector: the same PanGestureDetector and TapGestureDetector give a
    // mouse different recognition behaviour than a touchscreen, without the application inspecting
    // the device on every event. Two layers are configured once, in Activate():
    //
    //   - Detector-local Options (PanGestureDetector.Options / TapGestureDetector.Options, via
    //     SetDeviceOptions()): the mouse profile restricts panning to roughly horizontal drags and
    //     allows a double-click.
    //   - Application-wide recognition thresholds (GestureOptions.Instance.Set*Thresholds()): the
    //     mouse profile needs a longer drag before a pan starts, and a faster second click before
    //     it counts as a double-click, than the touch defaults.
    //
    // Drag the block with the mouse: a mostly-horizontal drag moves it; a mostly-vertical drag does
    // nothing, because the pan never starts (the angle added via AddDirection() is only checked when
    // the gesture starts - once started, it can move freely). On a touchscreen the block follows a
    // drag started in any direction. Click (or tap) the button once or twice to see the per-device
    // tap count and timing in the log.
    //
    // Gesture.Source only distinguishes Mouse/Touch (it is a legacy, lossy view of the full device
    // class); that is exactly what this sample needs to label its log, so it is used here instead of
    // decoding the full Device::Class::Type.
    public class DeviceGestureOptionsSample : IExample
    {
        private const float TrackX = 30.0f, TrackY = 220.0f, TrackWidth = 840.0f, TrackHeight = 170.0f;
        private const float HandleSize = 90.0f;

        private const float TapButtonX = 30.0f, TapButtonY = 510.0f, TapButtonWidth = 220.0f, TapButtonHeight = 90.0f;

        // The mouse needs to drag further before a pan starts, and a click needs to repeat sooner to
        // count as a double-click, than the touch defaults (GestureOptions.Instance.GetDefault*Thresholds()).
        private const int MouseMinimumPanDistance = 40;
        private const uint MouseMaximumMultiTapIntervalMs = 250u;
        private const uint TouchMaximumMultiTapIntervalMs = 450u;

        private const int MaxTapLogLines = 6;

        private View root;
        private View track;
        private View handle;
        private TextLabel panStatusLabel;

        private View tapButton;
        private TextLabel tapStatusLabel;
        private readonly Queue<string> tapLog = new Queue<string>();

        private PanGestureDetector panDetector;
        private TapGestureDetector tapDetector;

        private uint mousePanCount;
        private uint touchPanCount;
        private uint mouseTapCount;
        private uint touchTapCount;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            window.BackgroundColor = new Color(0x11 / 255.0f, 0x18 / 255.0f, 0x20 / 255.0f, 1.0f);

            root = new View
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };
            window.Add(root);

            root.Add(MakeLabel("Device Gesture Options: Mouse vs Touch", 24, new Position(30, 16), new Size(840, 40),
                                new Color(1, 1, 1, 1)));
            root.Add(MakeLabel(
                "One PanGestureDetector and one TapGestureDetector; only their per-device Options and " +
                "recognition thresholds differ. Mouse and touch see different recognition behaviour below.",
                14, new Position(30, 64), new Size(840, 60), new Color(0xB9 / 255.0f, 0xC9 / 255.0f, 0xDA / 255.0f, 1.0f)));

            SetupPanZone();
            SetupTapZone();

            var legend = MakeLabel(
                "Configured per device (registered once in Activate(), resolved from the device that pressed down):\n" +
                $"  MOUSE  pan: horizontal-only, min distance {MouseMinimumPanDistance}px   |   tap: up to 2 taps, multi-tap interval {MouseMaximumMultiTapIntervalMs}ms\n" +
                $"  TOUCH  pan: any direction, min distance {GestureOptions.Instance.GetDefaultPanThresholds().MinimumDistance}px (default)   |   " +
                $"tap: up to 2 taps, multi-tap interval {TouchMaximumMultiTapIntervalMs}ms",
                13, new Position(30, 660), new Size(840, 100), new Color(0x8F / 255.0f, 0xA3 / 255.0f, 0xB8 / 255.0f, 1.0f));
            legend.BackgroundColor = new Color(0x1A / 255.0f, 0x25 / 255.0f, 0x31 / 255.0f, 1.0f);
            root.Add(legend);
        }

        private void SetupPanZone()
        {
            root.Add(MakeLabel("PAN ZONE  —  drag the block", 16, new Position(30, 190), new Size(400, 26),
                                new Color(0xE7 / 255.0f, 0xEE / 255.0f, 0xF5 / 255.0f, 1.0f)));

            track = new View
            {
                Position = new Position(TrackX, TrackY),
                Size = new Size(TrackWidth, TrackHeight),
                BackgroundColor = new Color(0x1A / 255.0f, 0x25 / 255.0f, 0x31 / 255.0f, 1.0f),
                Sensitive = false,
            };
            root.Add(track);

            handle = new View
            {
                Position = new Position(TrackX + (TrackWidth - HandleSize) / 2.0f, TrackY + (TrackHeight - HandleSize) / 2.0f),
                Size = new Size(HandleSize, HandleSize),
                BackgroundColor = new Color(0x4D / 255.0f, 0x8F / 255.0f, 0xE8 / 255.0f, 1.0f),
            };
            root.Add(handle);

            panDetector = new PanGestureDetector();

            // Touch keeps the built-in defaults (any direction, GestureOptions.Instance.GetDefaultPanThresholds());
            // registering them explicitly here just makes that intent visible in the code.
            panDetector.SetDeviceOptions(GestureDeviceSelector.ByDeviceClass(DeviceClassType.Touch), panDetector.GetDefaultOptions());
            GestureOptions.Instance.SetPanThresholds(GestureDeviceSelector.ByDeviceClass(DeviceClassType.Touch),
                                                      GestureOptions.Instance.GetDefaultPanThresholds());

            // Mouse: only start the pan for a roughly horizontal drag, and require a longer drag first.
            PanGestureDetector.Options mouseOptions = panDetector.GetDefaultOptions();
            mouseOptions.AddDirection(PanGestureDetector.DirectionHorizontal);
            panDetector.SetDeviceOptions(GestureDeviceSelector.ByDeviceClass(DeviceClassType.Mouse), mouseOptions);

            PanThresholds mouseThresholds = GestureOptions.Instance.GetDefaultPanThresholds();
            mouseThresholds.MinimumDistance = MouseMinimumPanDistance;
            GestureOptions.Instance.SetPanThresholds(GestureDeviceSelector.ByDeviceClass(DeviceClassType.Mouse), mouseThresholds);

            panDetector.Attach(handle);
            panDetector.Detected += OnPan;

            panStatusLabel = MakeLabel("Pan: waiting for the first drag.", 14, new Position(30, 400), new Size(840, 70),
                                        new Color(0xE7 / 255.0f, 0xEE / 255.0f, 0xF5 / 255.0f, 1.0f));
            panStatusLabel.BackgroundColor = new Color(0x1A / 255.0f, 0x25 / 255.0f, 0x31 / 255.0f, 1.0f);
            root.Add(panStatusLabel);
        }

        private void SetupTapZone()
        {
            root.Add(MakeLabel("TAP ZONE  —  click or tap once or twice", 16, new Position(30, 480), new Size(400, 26),
                                new Color(0xE7 / 255.0f, 0xEE / 255.0f, 0xF5 / 255.0f, 1.0f)));

            tapButton = new View
            {
                Position = new Position(TapButtonX, TapButtonY),
                Size = new Size(TapButtonWidth, TapButtonHeight),
                BackgroundColor = new Color(0x39 / 255.0f, 0x72 / 255.0f, 0x5B / 255.0f, 1.0f),
            };
            tapButton.Add(MakeLabel("tap me", 16, new Position(0, 0), new Size(TapButtonWidth, TapButtonHeight), new Color(1, 1, 1, 1)));
            root.Add(tapButton);

            tapDetector = new TapGestureDetector();

            // Both devices allow up to a double tap; only the multi-tap interval differs.
            TapGestureDetector.Options doubleTapOptions = tapDetector.GetDefaultOptions();
            doubleTapOptions.MaximumTapsRequired = 2;
            tapDetector.SetDeviceOptions(GestureDeviceSelector.ByDeviceClass(DeviceClassType.Mouse), doubleTapOptions);
            tapDetector.SetDeviceOptions(GestureDeviceSelector.ByDeviceClass(DeviceClassType.Touch), doubleTapOptions);

            TapThresholds mouseTapThresholds = GestureOptions.Instance.GetDefaultTapThresholds();
            mouseTapThresholds.MaximumMultiTapInterval = MouseMaximumMultiTapIntervalMs;
            GestureOptions.Instance.SetTapThresholds(GestureDeviceSelector.ByDeviceClass(DeviceClassType.Mouse), mouseTapThresholds);

            TapThresholds touchTapThresholds = GestureOptions.Instance.GetDefaultTapThresholds();
            touchTapThresholds.MaximumMultiTapInterval = TouchMaximumMultiTapIntervalMs;
            GestureOptions.Instance.SetTapThresholds(GestureDeviceSelector.ByDeviceClass(DeviceClassType.Touch), touchTapThresholds);

            tapDetector.Attach(tapButton);
            tapDetector.Detected += OnTap;

            tapStatusLabel = MakeLabel("Tap log:\n(nothing yet)", 13, new Position(270, 510), new Size(600, 140),
                                        new Color(0xE7 / 255.0f, 0xEE / 255.0f, 0xF5 / 255.0f, 1.0f));
            tapStatusLabel.BackgroundColor = new Color(0x1A / 255.0f, 0x25 / 255.0f, 0x31 / 255.0f, 1.0f);
            root.Add(tapStatusLabel);
        }

        private void OnPan(object source, PanGestureDetector.DetectedEventArgs e)
        {
            bool isMouse = e.PanGesture.Source == Gesture.SourceType.Mouse;
            bool isTouch = e.PanGesture.Source == Gesture.SourceType.Touch;
            if (isMouse)
            {
                mousePanCount++;
            }
            else if (isTouch)
            {
                touchPanCount++;
            }

            if (e.PanGesture.State == Gesture.StateType.Started || e.PanGesture.State == Gesture.StateType.Continuing)
            {
                Position current = handle.Position;
                Vector2 displacement = e.PanGesture.Displacement;
                float newX = Math.Min(Math.Max(current.X + displacement.X, TrackX), TrackX + TrackWidth - HandleSize);
                float newY = Math.Min(Math.Max(current.Y + displacement.Y, TrackY), TrackY + TrackHeight - HandleSize);
                handle.Position = new Position(newX, newY);
            }

            string deviceName = isMouse ? "MOUSE" : (isTouch ? "TOUCH" : "OTHER");
            panStatusLabel.Text =
                $"Pan {deviceName}: started {mousePanCount} (mouse) / {touchPanCount} (touch) times so far.\n" +
                "A mouse drag only starts within 45 degrees of horizontal; a touch drag starts in any direction.";
        }

        private void OnTap(object source, TapGestureDetector.DetectedEventArgs e)
        {
            bool isMouse = e.TapGesture.Source == Gesture.SourceType.Mouse;
            bool isTouch = e.TapGesture.Source == Gesture.SourceType.Touch;
            if (isMouse)
            {
                mouseTapCount++;
            }
            else if (isTouch)
            {
                touchTapCount++;
            }

            string deviceName = isMouse ? "MOUSE" : (isTouch ? "TOUCH" : "OTHER");
            tapLog.Enqueue($"{deviceName}: {e.TapGesture.NumberOfTaps} tap(s)");
            while (tapLog.Count > MaxTapLogLines)
            {
                tapLog.Dequeue();
            }

            tapStatusLabel.Text = $"Tap log (mouse {mouseTapCount} / touch {touchTapCount}):\n" + string.Join("\n", tapLog);
        }

        private static TextLabel MakeLabel(string text, float pointSize, Position position, Size size, Color color)
        {
            return new TextLabel
            {
                Text = text,
                PointSize = pointSize,
                Position = position,
                Size = size,
                TextColor = color,
                MultiLine = true,
            };
        }

        public void Deactivate()
        {
            if (panDetector != null)
            {
                panDetector.Detected -= OnPan;
                panDetector.Dispose();
                panDetector = null;
            }

            if (tapDetector != null)
            {
                tapDetector.Detected -= OnTap;
                tapDetector.Dispose();
                tapDetector = null;
            }

            if (root != null)
            {
                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
                root = null;
            }
        }
    }
}
