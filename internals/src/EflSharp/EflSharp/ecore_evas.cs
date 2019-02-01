#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;
using System.Threading;

public class EcoreEvas
{
    [DllImport(efl.Libs.EcoreEvas)] static extern void ecore_evas_init();
    // [DllImport(efl.Libs.EcoreEvas)] static extern IntPtr ecore_evas_new([MarshalAs(UnmanagedType.LPStr)] String engine_name, int x, int y, int w, int h
    //                                                               , [MarshalAs(UnmanagedType.LPStr)] String extra_options);
    [DllImport(efl.Libs.EcoreEvas)] static extern IntPtr ecore_evas_new(IntPtr engine_name, int x, int y, int w, int h
                                                                  , IntPtr extra_options);
    [DllImport(efl.Libs.EcoreEvas)] static extern IntPtr ecore_evas_get(IntPtr ecore_evas);
    [DllImport(efl.Libs.EcoreEvas)] static extern IntPtr ecore_evas_show(IntPtr ecore_evas);

    IntPtr handle;
    public EcoreEvas()
    {
#if WIN32 // Not a native define, we define it in our build system
        // Ecore_Win32 uses OleInitialize, which requires single thread apartments
        if (Thread.CurrentThread.GetApartmentState() != ApartmentState.STA)
            throw new InvalidOperationException("UI Applications require STAThreadAttribute in Main()");
#endif
        ecore_evas_init();
        handle = ecore_evas_new(IntPtr.Zero, 0, 0, 640, 480, IntPtr.Zero);
        if(handle == IntPtr.Zero)
            System.Console.WriteLine("Couldn't create a ecore evas");
        ecore_evas_show(handle);
    }

    public Efl.Canvas.Object canvas
    {
        get { return new Efl.Canvas.Object(ecore_evas_get(handle)); }
    }
    
}

