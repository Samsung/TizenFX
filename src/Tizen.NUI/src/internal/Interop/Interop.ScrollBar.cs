using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ScrollBar
        {
            static ScrollBar()
            {
                Tizen.Log.Error("NUI", "ScrollBar");
            }

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_Property_SCROLL_DIRECTION_get")]
            public static extern int ScrollBar_Property_SCROLL_DIRECTION_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_Property_INDICATOR_HEIGHT_POLICY_get")]
            public static extern int ScrollBar_Property_INDICATOR_HEIGHT_POLICY_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_Property_INDICATOR_FIXED_HEIGHT_get")]
            public static extern int ScrollBar_Property_INDICATOR_FIXED_HEIGHT_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_Property_INDICATOR_SHOW_DURATION_get")]
            public static extern int ScrollBar_Property_INDICATOR_SHOW_DURATION_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_Property_INDICATOR_HIDE_DURATION_get")]
            public static extern int ScrollBar_Property_INDICATOR_HIDE_DURATION_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_Property_SCROLL_POSITION_INTERVALS_get")]
            public static extern int ScrollBar_Property_SCROLL_POSITION_INTERVALS_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_Property_INDICATOR_MINIMUM_HEIGHT_get")]
            public static extern int ScrollBar_Property_INDICATOR_MINIMUM_HEIGHT_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_Property_INDICATOR_START_PADDING_get")]
            public static extern int ScrollBar_Property_INDICATOR_START_PADDING_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_Property_INDICATOR_END_PADDING_get")]
            public static extern int ScrollBar_Property_INDICATOR_END_PADDING_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_ScrollBar_Property")]
            public static extern global::System.IntPtr new_ScrollBar_Property();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_ScrollBar_Property")]
            public static extern void delete_ScrollBar_Property(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_ScrollBar__SWIG_0")]
            public static extern global::System.IntPtr new_ScrollBar__SWIG_0();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_ScrollBar__SWIG_1")]
            public static extern global::System.IntPtr new_ScrollBar__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_Assign")]
            public static extern global::System.IntPtr ScrollBar_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_ScrollBar")]
            public static extern void delete_ScrollBar(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_New__SWIG_0")]
            public static extern global::System.IntPtr ScrollBar_New__SWIG_0(int jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_New__SWIG_1")]
            public static extern global::System.IntPtr ScrollBar_New__SWIG_1();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_DownCast")]
            public static extern global::System.IntPtr ScrollBar_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_SetScrollPropertySource")]
            public static extern void ScrollBar_SetScrollPropertySource(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, int jarg4, int jarg5, int jarg6);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_SetScrollIndicator")]
            public static extern void ScrollBar_SetScrollIndicator(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_GetScrollIndicator")]
            public static extern global::System.IntPtr ScrollBar_GetScrollIndicator(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_SetScrollPositionIntervals")]
            public static extern void ScrollBar_SetScrollPositionIntervals(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_GetScrollPositionIntervals")]
            public static extern global::System.IntPtr ScrollBar_GetScrollPositionIntervals(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_SetScrollDirection")]
            public static extern void ScrollBar_SetScrollDirection(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_GetScrollDirection")]
            public static extern int ScrollBar_GetScrollDirection(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_SetIndicatorHeightPolicy")]
            public static extern void ScrollBar_SetIndicatorHeightPolicy(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_GetIndicatorHeightPolicy")]
            public static extern int ScrollBar_GetIndicatorHeightPolicy(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_SetIndicatorFixedHeight")]
            public static extern void ScrollBar_SetIndicatorFixedHeight(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_GetIndicatorFixedHeight")]
            public static extern float ScrollBar_GetIndicatorFixedHeight(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_SetIndicatorShowDuration")]
            public static extern void ScrollBar_SetIndicatorShowDuration(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_GetIndicatorShowDuration")]
            public static extern float ScrollBar_GetIndicatorShowDuration(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_SetIndicatorHideDuration")]
            public static extern void ScrollBar_SetIndicatorHideDuration(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_GetIndicatorHideDuration")]
            public static extern float ScrollBar_GetIndicatorHideDuration(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_ShowIndicator")]
            public static extern void ScrollBar_ShowIndicator(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_HideIndicator")]
            public static extern void ScrollBar_HideIndicator(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_PanFinishedSignal")]
            public static extern global::System.IntPtr ScrollBar_PanFinishedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_ScrollPositionIntervalReachedSignal")]
            public static extern global::System.IntPtr ScrollBar_ScrollPositionIntervalReachedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ScrollBar_SWIGUpcast")]
            public static extern global::System.IntPtr ScrollBar_SWIGUpcast(global::System.IntPtr jarg1);
        }
    }
}
