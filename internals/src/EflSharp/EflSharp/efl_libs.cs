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
    public const string EcoreEvas = "libecore_evas.so.1";
    public const string Edje = "libedje.so.1";
    public const string Elementary = "libelementary.so.1";
    public const string Eldbus = "libeldbus.so.1";

    public const string CustomExports = "libeflcustomexportsmono.so.1";

    public const string Eext = "libefl-extension.so.0";
}

}
