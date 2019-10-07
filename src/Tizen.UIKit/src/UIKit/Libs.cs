#pragma warning disable 1591

namespace UIKit {

/// <summary>
/// Define the name of the libraries to be passed to DllImport statements.
/// </summary>
public class Libs {
    public const string UIKit = "libefl.so.1";
    public const string Ecore = "libecore.so.1";
    public const string Eina = "libeina.so.1";
    public const string Eo = "libeo.so.1";
    public const string Evas = "libevas.so.1";
    public const string Evil = "libdl.so.2";
    public const string Edje = "libedje.so.1";
    public const string Elementary = "libelementary.so.1";
    public const string Eldbus = "libeldbus.so.1";

    public const string CustomExports = "libeflcustomexportsmono.so.1";

    public const string Libdl = "libdl.so.2";
    public const string Kernel32 = "kernel32.dll";
    public const string Eext = "libefl-extension.so.0";

    public static UIKit.Wrapper.NativeModule UIKitModule = new UIKit.Wrapper.NativeModule(UIKit);
    public static UIKit.Wrapper.NativeModule CoreModule = new UIKit.Wrapper.NativeModule(Ecore);
    public static UIKit.Wrapper.NativeModule EinaModule = new UIKit.Wrapper.NativeModule(Eina);
    public static UIKit.Wrapper.NativeModule EoModule = new UIKit.Wrapper.NativeModule(Eo);
    public static UIKit.Wrapper.NativeModule EvasModule = new UIKit.Wrapper.NativeModule(Evas);
    public static UIKit.Wrapper.NativeModule EvilModule = new UIKit.Wrapper.NativeModule(Evil);
    public static UIKit.Wrapper.NativeModule EdjeModule = new UIKit.Wrapper.NativeModule(Edje);
    public static UIKit.Wrapper.NativeModule ElementaryModule = new UIKit.Wrapper.NativeModule(Elementary);
    public static UIKit.Wrapper.NativeModule EldbusModule = new UIKit.Wrapper.NativeModule(Eldbus);
    public static UIKit.Wrapper.NativeModule CustomExportsModule = new UIKit.Wrapper.NativeModule(CustomExports);
    public static UIKit.Wrapper.NativeModule LibdlModule = new UIKit.Wrapper.NativeModule(Libdl);
    public static UIKit.Wrapper.NativeModule Kernel32Module = new UIKit.Wrapper.NativeModule(Kernel32);
}

}
