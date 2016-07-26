using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct CkmcPolicy
    {
        public CkmcPolicy(string password, bool extractable)
        {
            this.password = password;
            this.extractable = extractable;
        }
        [MarshalAs(UnmanagedType.LPTStr)]
        public readonly string password;
        [MarshalAs(UnmanagedType.Bool)]
        public readonly bool extractable;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CkmcKey
    {
        public CkmcKey(IntPtr binary, int keySize, int keyType, IntPtr password)
        {
            this.rawKey = binary;
            this.size = (uint)keySize;
            this.keyType = keyType;
            this.password = password;
        }
        public readonly IntPtr rawKey;
        public readonly uint size;
        public readonly int keyType;
        public readonly IntPtr password;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CkmcCert
    {
        public CkmcCert(IntPtr binary, int size, int dataFormat)
        {
            this.rawCert = binary;
            this.size = (uint)size;
            this.dataFormat = dataFormat;
        }
        public readonly IntPtr rawCert;
        public readonly uint size;
        public readonly int dataFormat;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CkmcRawBuffer
    {
        public CkmcRawBuffer(IntPtr binary, int size)
        {
            this.data = binary;
            this.size = (uint)size;
        }
        public readonly IntPtr data;
        public readonly uint size;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CkmcAliasList
    {
        public readonly IntPtr alias;
        public readonly IntPtr next;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CkmcCertList
    {
        public CkmcCertList(IntPtr cert, IntPtr next)
        {
            this.cert = cert;
            this.next = next;
        }
        public readonly IntPtr cert;
        public readonly IntPtr next;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CkmcPkcs12
    {
        public CkmcPkcs12(IntPtr privateKey, IntPtr certificate, IntPtr caChain)
        {
            this.privateKey = privateKey;
            this.certificate = certificate;
            this.caChain = caChain;
        }
        public readonly IntPtr privateKey;
        public readonly IntPtr certificate;
        public readonly IntPtr caChain;
    }


    static public string GetErrorMessage(int errorCode)
    {
        IntPtr errorPtr = CkmcTypes.GetErrorMessage(errorCode);
        return Marshal.PtrToStringAuto(errorPtr);
    }


    internal static partial class CkmcTypes
    {
        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_key_free", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CkmcKeyFree(IntPtr buffer);
        // void ckmc_key_free(ckmc_key_s *key);

        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_buffer_new", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CkmcBufferNew(byte[] data, uint size, out IntPtr buffer);
        // int ckmc_buffer_new(unsigned char *data, size_t size, ckmc_raw_buffer_s** ppbuffer);

        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_buffer_free", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CkmcBufferFree(IntPtr buffer);
        // void ckmc_buffer_free(ckmc_raw_buffer_s* buffer);

        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_cert_new", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CkmcCertNew(byte[] rawCert, uint size, int dataFormat, out IntPtr cert);
        // int ckmc_cert_new(unsigned char *raw_cert, size_t cert_size, ckmc_data_format_e data_format, ckmc_cert_s** ppcert);

        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_cert_free", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CkmcCertFree(IntPtr buffer);
        // void ckmc_cert_free(ckmc_cert_s *cert);

        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_load_cert_from_file", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CkmcLoadCertFromFile(string filePath, out IntPtr cert);
        // int ckmc_load_cert_from_file(const char *file_path, ckmc_cert_s **cert);

        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_pkcs12_new", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CkmcPkcs12New(string filePath, out IntPtr cert);
        // int ckmc_pkcs12_new(ckmc_key_s *private_key, ckmc_cert_s* cert, ckmc_cert_list_s *ca_cert_list, ckmc_pkcs12_s** pkcs12_bundle);

        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_load_from_pkcs12_file", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CkmcLoadFromPkcs12File(string filePath, string password, out IntPtr privateKey, out IntPtr cert, out IntPtr caCertList);
        // int ckmc_load_from_pkcs12_file(const char *file_path, const char* passphrase, ckmc_key_s **private_key, ckmc_cert_s** cert, ckmc_cert_list_s **ca_cert_list);

        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_pkcs12_load", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CkmcPkcs12Load(string filePath, string password, out IntPtr pkcs12);
        // int ckmc_pkcs12_load(const char *file_path, const char* passphrase, ckmc_pkcs12_s **pkcs12_bundle);

        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_pkcs12_free", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CkmcPkcs12Free(IntPtr pkcs12);
        // void ckmc_pkcs12_free(ckmc_pkcs12_s *pkcs12);

        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_alias_list_new", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CkmcAliasListNew(string alias, out IntPtr aliasList);
        // int ckmc_alias_list_new(char *alias, ckmc_alias_list_s **ppalias_list);

        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_alias_list_add", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CkmcAliasListAdd(IntPtr previous, string alias, out IntPtr aliasList);
        // int ckmc_alias_list_add(ckmc_alias_list_s *previous, char* alias, ckmc_alias_list_s **pplast);

        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_alias_list_free", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CkmcAliasListFree(IntPtr first);
        // void ckmc_alias_list_free(ckmc_alias_list_s* first);

        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_alias_list_all_free", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CkmcAliasListAllFree(IntPtr first);
        // void ckmc_alias_list_all_free(ckmc_alias_list_s* first);

        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_cert_list_new", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CkmcCertListNew(IntPtr cert, out IntPtr certList);
        // int ckmc_cert_list_new(ckmc_cert_s *cert, ckmc_cert_list_s **ppcert_list);

        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_cert_list_add", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CkmcCertListAdd(IntPtr previous, IntPtr cert, out IntPtr certList);
        // int ckmc_cert_list_add(ckmc_cert_list_s *previous, ckmc_cert_s *cert, ckmc_cert_list_s** pplast);

        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_cert_list_free", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CkmcCertListFree(IntPtr first);
        // void ckmc_cert_list_free(ckmc_cert_list_s *first);

        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_cert_list_all_free", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CkmcCertListAllFree(IntPtr first);
        // void ckmc_cert_list_all_free(ckmc_cert_list_s *first);

        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_param_list_new", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CkmcParamListNew(out IntPtr paramList);
        // int ckmc_param_list_new(ckmc_param_list_h *pparams);

        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_param_list_set_integer", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CkmcParamListSetInteger(IntPtr paramList, int name, long value);
        // int ckmc_param_list_set_integer(ckmc_param_list_h params, ckmc_param_name_e name, uint64_t value);

        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_param_list_set_buffer", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CkmcParamListSetBuffer(IntPtr paramList, int name, IntPtr buffer);
        // int ckmc_param_list_set_buffer(ckmc_param_list_h params, ckmc_param_name_e name, const ckmc_raw_buffer_s* buffer);

        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_param_list_get_integer", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CkmcParamListGetInteger(IntPtr paramList, int name, out long value);
        // int ckmc_param_list_get_integer(ckmc_param_list_h params, ckmc_param_name_e name, uint64_t *pvalue);

        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_param_list_get_buffer", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CkmcParamListGetBuffer(IntPtr paramList, int name, out IntPtr buffer);
        // int ckmc_param_list_get_buffer(ckmc_param_list_h params, ckmc_param_name_e name, ckmc_raw_buffer_s **ppbuffer);

        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_param_list_free", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CkmcParamListFree(IntPtr first);
        // void ckmc_param_list_free(ckmc_param_list_h params);

        [DllImport(Libraries.KeyManagerClient, EntryPoint = "ckmc_generate_new_params", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CkmcGenerateNewParam(int algoType, out IntPtr paramList);
        // int ckmc_generate_new_params(ckmc_algo_type_e type, ckmc_param_list_h *pparams);

        [DllImport(Libraries.TizenBaseCommon, EntryPoint = "get_error_message", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetErrorMessage(int err);
        // char *get_error_message(int err);

    }
}

