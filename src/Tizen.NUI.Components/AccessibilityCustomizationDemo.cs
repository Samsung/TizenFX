using System;
using System.Runtime.InteropServices;

using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Components.AccessibilityCustomizationDemo
{
    internal static class Common
    {
        internal static TextLabel CreateTextLabel(string text)
        {
            return new TextLabel
            {
                Text = text,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                AccessibilityHidden = true,
            };
        }

        internal static void ConfigureView(View view)
        {
            view.SizeWidth = 500;
            view.SizeHeight = 100;
            view.AccessibilityRole = Role.Label;
            view.AccessibilityHighlightable = true;
            view.BackgroundColor = Color.Orange;
            view.Layout = new LinearLayout
            {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                LinearAlignment = LinearLayout.Alignment.CenterVertical,
            };
        }

        internal const string CustomDescription = "This is a description";
        internal const string CustomAttributeKey = "x";
        internal const string CustomAttributeValue = "123";
    }

    // MyControl1's backend (implementation) is SwigDirector_ViewWrapperImpl.
    // SwigDirector_ViewWrapperImpl::CreateAccessibleObject() creates a NUIViewAccessible object.
    //
    // NUIViewAccessible::CalculateStates calls View.AccessibilityCalculateStates,
    // NUIViewAccessible::GetAttributes collects View.AccessibilityAttributes, etc.
    public class MyControl1 : Control
    {
        private readonly TextLabel _textLabel = Common.CreateTextLabel(nameof(MyControl1));

        public MyControl1() : base()
        {
            Common.ConfigureView(this);
            Add(_textLabel);

            AccessibilityAttributes[Common.CustomAttributeKey] = Common.CustomAttributeValue;
        }

        protected override string AccessibilityGetName()
        {
            return _textLabel.Text;
        }

        protected override string AccessibilityGetDescription()
        {
            return Common.CustomDescription;
        }

        protected override AccessibilityStates AccessibilityCalculateStates()
        {
            var states = base.AccessibilityCalculateStates();

            states[AccessibilityState.MultiLine] = true;
            states[AccessibilityState.ReadOnly] = true;

            return states;
        }
    }

    // MyControl2's backend (implementation) is SwigDirector_ViewWrapperImpl.
    // SwigDirector_ViewWrapperImpl::CreateAccessibleObject() creates a NUIViewAccessible object.
    //
    // NUIViewAccessible::CalculateStates calls View.AccessibilityCalculateStates,
    // NUIViewAccessible::GetAttributes collects View.AccessibilityAttributes, etc.
    //
    // A higher possible base class for MyControl2 could be CustomView or even ViewWrapper, but
    // this would probably require more code.
    public class MyControl2 : VisualView
    {
        private readonly TextLabel _textLabel = Common.CreateTextLabel(nameof(MyControl2));

        public MyControl2() : base()
        {
            Common.ConfigureView(this);
            Add(_textLabel);

            AccessibilityAttributes[Common.CustomAttributeKey] = Common.CustomAttributeValue;
        }

        protected override string AccessibilityGetName()
        {
            return _textLabel.Text;
        }

        protected override string AccessibilityGetDescription()
        {
            return Common.CustomDescription;
        }

        protected override AccessibilityStates AccessibilityCalculateStates()
        {
            var states = base.AccessibilityCalculateStates();

            states[AccessibilityState.MultiLine] = true;
            states[AccessibilityState.ReadOnly] = true;

            return states;
        }
    }

    // MyControl3's backend (implementation) is Toolkit::Internal::Control.
    // Toolkit::Internal::Control::CreateAccessibleObject() creates a Toolkit::DevelControl::ControlAccessible object.
    //
    // ControlAccessible::CalculateState does not (and cannot) call View.AccessibilityCalculateStates,
    // ControlAccessible::GetAttributes does not (and cannot) collect View.AccessibilityAttributes, etc.
    public class MyControl3 : View
    {
        private readonly TextLabel _textLabel = Common.CreateTextLabel(nameof(MyControl3));

        public MyControl3() : base()
        {
            Common.ConfigureView(this);
            Add(_textLabel);

            // This is dead code (won't be read)!
            AccessibilityAttributes[Common.CustomAttributeKey] = Common.CustomAttributeValue;
        }

        // This is dead code (won't be called)!
        protected override string AccessibilityGetName()
        {
            return _textLabel.Text;
        }

        // This is dead code (won't be called)!
        protected override string AccessibilityGetDescription()
        {
            return Common.CustomDescription;
        }

        // This is dead code (won't be called)!
        protected override AccessibilityStates AccessibilityCalculateStates()
        {
            var states = base.AccessibilityCalculateStates();

            states[AccessibilityState.MultiLine] = true;
            states[AccessibilityState.ReadOnly] = true;

            return states;
        }
    }

    // MyControl4's backend (implementation) is SwigDirector_ViewImpl.
    // SwigDirector_ViewImpl::CreateAccessibleObject() creates a NUIViewAccessible object.
    //
    // NUIViewAccessible::CalculateStates calls View.AccessibilityCalculateStates,
    // NUIViewAccessible::GetAttributes collects View.AccessibilityAttributes, etc.
    //
    // These two patches need to be applied:
    // https://review.tizen.org/gerrit/#/c/platform/core/uifw/dali-csharp-binder/+/277964/
    // https://review.tizen.org/gerrit/#/c/platform/core/uifw/dali-csharp-binder/+/278622/
    //
    // FIXME: MyControl4 doesn't fully work yet (but it does get a NUIViewAccessible, which is a success).
    public class MyControl4 : View
    {
        private readonly TextLabel _textLabel = Common.CreateTextLabel(nameof(MyControl4));

        [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ViewImpl2")]
        private static extern IntPtr NewViewImpl2();

        [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ViewImpl3")]
        private static extern IntPtr NewViewImpl3();

        public MyControl4() : base(new ViewImpl(NewViewImpl2(), true)) //base(NewViewImpl3(), true) // FIXME: neither option fully works
        {
            Common.ConfigureView(this);
            Add(_textLabel);

            AccessibilityAttributes[Common.CustomAttributeKey] = Common.CustomAttributeValue;
        }

        protected override string AccessibilityGetName()
        {
            return _textLabel.Text;
        }

        protected override string AccessibilityGetDescription()
        {
            return Common.CustomDescription;
        }

        protected override AccessibilityStates AccessibilityCalculateStates()
        {
            var states = base.AccessibilityCalculateStates();

            states[AccessibilityState.MultiLine] = true;
            states[AccessibilityState.ReadOnly] = true;

            return states;
        }
    }
}
