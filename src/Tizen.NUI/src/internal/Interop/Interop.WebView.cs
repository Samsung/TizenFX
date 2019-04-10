using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{

    internal static partial class Interop
    {
        internal static partial class WebView
        {

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WebView_New")]
            public static extern global::System.IntPtr WebView_New();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WebView_New_2")]
            public static extern global::System.IntPtr WebView_New_2(string jarg1, string jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_WebView__SWIG_1")]
            public static extern global::System.IntPtr new_WebView__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_WebView")]
            public static extern void delete_WebView(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WebView_Assign")]
            public static extern global::System.IntPtr WebView_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WebView_DownCast")]
            public static extern global::System.IntPtr WebView_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WebView_LoadUrl")]
            public static extern void WebView_LoadUrl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);



            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WebView_GetUrl")]
            public static extern string WebView_GetUrl(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WebView_LoadHTMLString")]
            public static extern void WebView_LoadHTMLString(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WebView_Reload")]
            public static extern void WebView_Reload(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WebView_StopLoading")]
            public static extern void WebView_StopLoading(global::System.Runtime.InteropServices.HandleRef jarg1);



            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WebView_GoBack")]
            public static extern void WebView_GoBack(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WebView_GoForward")]
            public static extern void WebView_GoForward(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WebView_CanGoBack")]
            public static extern bool WebView_CanGoBack(global::System.Runtime.InteropServices.HandleRef jarg1);



            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WebView_CanGoForward")]
            public static extern bool WebView_CanGoForward(global::System.Runtime.InteropServices.HandleRef jarg1);



            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WebView_EvaluateJavaScript")]
            public static extern void WebView_EvaluateJavaScript(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);



            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WebView_AddJavaScriptMessageHandler")]
            public static extern void WebView_AddJavaScriptMessageHandler(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);



            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WebView_ClearHistory")]
            public static extern void WebView_ClearHistory(global::System.Runtime.InteropServices.HandleRef jarg1);



            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WebView_ClearCache")]
            public static extern void WebView_ClearCache(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WebView_SWIGUpcast")]
            public static extern global::System.IntPtr WebView_SWIGUpcast(global::System.IntPtr jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_WebViewSignalProxy_PageLoadStarted")]
            public static extern global::System.IntPtr new_WebViewSignalProxy_PageLoadStarted(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_WebViewSignalProxy_PageLoadFinished")]
            public static extern global::System.IntPtr new_WebViewSignalProxy_PageLoadFinished(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_WebViewSignalProxy")]
            public static extern void delete_WebViewSignalProxy(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WebViewSignalProxy_Connect")]
            public static extern void WebViewSignalProxy_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WebViewSignalProxy_Disconnect")]
            public static extern void WebViewSignalProxy_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

        }
    }
}
