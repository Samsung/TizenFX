#pragma warning disable 1591

namespace efl {

/// <summary>
/// Define the name of the libraries to be passed to DllImport statements.
/// </summary>
public class Libs {
    public const string Efl = "libefl.so.1";
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

    public static Efl.Eo.NativeModule EflModule = new Efl.Eo.NativeModule(Efl);
    public static Efl.Eo.NativeModule CoreModule = new Efl.Eo.NativeModule(Ecore);
    public static Efl.Eo.NativeModule EinaModule = new Efl.Eo.NativeModule(Eina);
    public static Efl.Eo.NativeModule EoModule = new Efl.Eo.NativeModule(Eo);
    public static Efl.Eo.NativeModule EvasModule = new Efl.Eo.NativeModule(Evas);
    public static Efl.Eo.NativeModule EvilModule = new Efl.Eo.NativeModule(Evil);
    public static Efl.Eo.NativeModule EdjeModule = new Efl.Eo.NativeModule(Edje);
    public static Efl.Eo.NativeModule ElementaryModule = new Efl.Eo.NativeModule(Elementary);
    public static Efl.Eo.NativeModule EldbusModule = new Efl.Eo.NativeModule(Eldbus);
    public static Efl.Eo.NativeModule CustomExportsModule = new Efl.Eo.NativeModule(CustomExports);
    public static Efl.Eo.NativeModule LibdlModule = new Efl.Eo.NativeModule(Libdl);
    public static Efl.Eo.NativeModule Kernel32Module = new Efl.Eo.NativeModule(Kernel32);
}

}
