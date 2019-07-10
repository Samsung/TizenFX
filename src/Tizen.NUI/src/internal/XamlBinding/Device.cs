using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Binding
{
    internal static class Device
    {
        public const string iOS = "iOS";
        public const string Android = "Android";
        public const string UWP = "UWP";
        public const string macOS = "macOS";
        public const string GTK = "GTK";
        public const string Tizen = "Tizen";
        public const string WPF = "WPF";

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DeviceInfo info;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetIdiom(TargetIdiom value) => Idiom = value;
        public static TargetIdiom Idiom { get; internal set; }

        //TODO: Why are there two of these? This is never used...?
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetTargetIdiom(TargetIdiom value) => Idiom = value;

        [Obsolete("TargetPlatform is obsolete as of version 2.3.4. Please use RuntimePlatform instead.")]
#pragma warning disable 0618
        public static TargetPlatform OS
        {
            get
            {
                TargetPlatform platform;
                if (Enum.TryParse(RuntimePlatform, out platform))
                    return platform;

                // In the old TargetPlatform, there was no distinction between WinRT/UWP
                if (RuntimePlatform == UWP)
                {
                    return TargetPlatform.Windows;
                }

                return TargetPlatform.Other;
            }
        }
#pragma warning restore 0618

        public static string RuntimePlatform => null;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DeviceInfo Info
        {
            get
            {
                // if (info == null)
                // 	throw new InvalidOperationException("You MUST call Tizen.NUI.Xaml.Init(); prior to using it.");
                return info;
            }
            set { info = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetFlowDirection(FlowDirection value) => FlowDirection = value;
        public static FlowDirection FlowDirection { get; internal set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IReadOnlyList<string> Flags { get; private set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetFlags(IReadOnlyList<string> flags)
        {
            Flags = flags;
        }

        public static void BeginInvokeOnMainThread(Action action)
        {
            action();
            Console.WriteLine("Device BeginInvokeOnMainThread action called");
        }

        // public static double GetNamedSize(NamedSize size, Element targetElement)
        // {
        //     return GetNamedSize(size, targetElement.GetType());
        // }

        // public static double GetNamedSize(NamedSize size, Type targetElementType)
        // {
        //     return GetNamedSize(size, targetElementType, false);
        // }

        [Obsolete("OnPlatform<> (generic) is obsolete as of version 2.3.4. Please use switch(RuntimePlatform) instead.")]
        public static T OnPlatform<T>(T iOS, T Android, T WinPhone)
        {
            switch (OS)
            {
                case TargetPlatform.iOS:
                    return iOS;
                case TargetPlatform.Android:
                    return Android;
                case TargetPlatform.Windows:
                case TargetPlatform.WinPhone:
                    return WinPhone;
            }

            return iOS;
        }

        public static void OpenUri(Uri uri)
        {
            // PlatformServices?.OpenUriAction(uri);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Assembly[] GetAssemblies()
        {
            return null;
        }

        // [EditorBrowsable(EditorBrowsableState.Never)]
        // public static double GetNamedSize(NamedSize size, Type targetElementType, bool useOldSizes)
        // {
        //     return PlatformServices.GetNamedSize(size, targetElementType, useOldSizes);
        // }

        public static class Styles
        {
            public static readonly string TitleStyleKey = "TitleStyle";

            public static readonly string SubtitleStyleKey = "SubtitleStyle";

            public static readonly string BodyStyleKey = "BodyStyle";

            public static readonly string ListItemTextStyleKey = "ListItemTextStyle";

            public static readonly string ListItemDetailTextStyleKey = "ListItemDetailTextStyle";

            public static readonly string CaptionStyleKey = "CaptionStyle";

            public static readonly Style TitleStyle = new Style(typeof(Tizen.NUI.BaseComponents.TextLabel)) { BaseResourceKey = TitleStyleKey };

            public static readonly Style SubtitleStyle = new Style(typeof(Tizen.NUI.BaseComponents.TextLabel)) { BaseResourceKey = SubtitleStyleKey };

            public static readonly Style BodyStyle = new Style(typeof(Tizen.NUI.BaseComponents.TextLabel)) { BaseResourceKey = BodyStyleKey };

            public static readonly Style ListItemTextStyle = new Style(typeof(Tizen.NUI.BaseComponents.TextLabel)) { BaseResourceKey = ListItemTextStyleKey };

            public static readonly Style ListItemDetailTextStyle = new Style(typeof(Tizen.NUI.BaseComponents.TextLabel)) { BaseResourceKey = ListItemDetailTextStyleKey };

            public static readonly Style CaptionStyle = new Style(typeof(Tizen.NUI.BaseComponents.TextLabel)) { BaseResourceKey = CaptionStyleKey };
        }
    }
}
