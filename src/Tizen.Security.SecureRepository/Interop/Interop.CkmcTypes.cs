/*
 *  Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License
 */

using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tizen.Internals;

internal static partial class Interop
{
    [NativeStruct("ckmc_policy_s", Include="ckmc/ckmc-type.h", PkgConfig="key-manager")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct CkmcPolicy
    {
        public CkmcPolicy(string password, [MarshalAs(UnmanagedType.U1)] bool extractable)
        {
            this.password = password;
            this.extractable = extractable;
        }
        [MarshalAs(UnmanagedType.LPStr)]
        public readonly string password;
        [MarshalAs(UnmanagedType.Bool)]
        public readonly bool extractable;
    }

    [NativeStruct("ckmc_key_s", Include="ckmc/ckmc-type.h", PkgConfig="key-manager")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct CkmcKey
    {
        public CkmcKey(IntPtr binary, int keySize, int keyType, string password)
        {
            this.rawKey = binary;
            this.size = (UIntPtr)keySize;
            this.keyType = keyType;
            this.password = password;
        }
        public readonly IntPtr rawKey;
        public readonly UIntPtr size;
        public readonly int keyType;
        [MarshalAs(UnmanagedType.LPStr)]
        public readonly string password;
    }

    [NativeStruct("ckmc_cert_s", Include="ckmc/ckmc-type.h", PkgConfig="key-manager")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct CkmcCert
    {
        public CkmcCert(IntPtr binary, int size, int dataFormat)
        {
            this.rawCert = binary;
            this.size = (UIntPtr)size;
            this.dataFormat = dataFormat;
        }
        public readonly IntPtr rawCert;
        public readonly UIntPtr size;
        public readonly int dataFormat;
    }

    [NativeStruct("ckmc_raw_buffer_s", Include="ckmc/ckmc-type.h", PkgConfig="key-manager")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct CkmcRawBuffer
    {
        public CkmcRawBuffer(IntPtr binary, int size)
        {
            this.data = binary;
            this.size = (UIntPtr)size;
        }
        public readonly IntPtr data;
        public readonly UIntPtr size;
    }

    [NativeStruct("ckmc_alias_list_s", Include="ckmc/ckmc-type.h", PkgConfig="key-manager")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct CkmcAliasList
    {
        public readonly IntPtr alias;
        public readonly IntPtr next;
    }

    [NativeStruct("ckmc_cert_list_s", Include="ckmc/ckmc-type.h", PkgConfig="key-manager")]
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

    [NativeStruct("ckmc_pkcs12_s", Include="ckmc/ckmc-type.h", PkgConfig="key-manager")]
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

    internal static partial class CkmcTypes
    {
        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_key_new", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int KeyNew(byte[] rawKey, UIntPtr size, int keyType, string password, out IntPtr cert);
        // int ckmc_key_new(unsigned char *raw_key, size_t key_size, ckmc_key_type_e key_type, char *password, ckmc_key_s **ppkey);
        //
        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_key_free", StringMarshalling = StringMarshalling.Utf8)]
        public static partial void KeyFree(IntPtr buffer);
        // void ckmc_key_free(ckmc_key_s *key);

        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_buffer_new", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int BufferNew(byte[] data, UIntPtr size, out IntPtr buffer);
        // int ckmc_buffer_new(unsigned char *data, size_t size, ckmc_raw_buffer_s** ppbuffer);

        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_buffer_free", StringMarshalling = StringMarshalling.Utf8)]
        public static partial void BufferFree(IntPtr buffer);
        // void ckmc_buffer_free(ckmc_raw_buffer_s* buffer);

        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_cert_new", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int CertNew(byte[] rawCert, UIntPtr size, int dataFormat, out IntPtr cert);
        // int ckmc_cert_new(unsigned char *raw_cert, size_t cert_size, ckmc_data_format_e data_format, ckmc_cert_s** ppcert);

        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_cert_free", StringMarshalling = StringMarshalling.Utf8)]
        public static partial void CertFree(IntPtr buffer);
        // void ckmc_cert_free(ckmc_cert_s *cert);

        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_load_cert_from_file", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int LoadCertFromFile(string filePath, out IntPtr cert);
        // int ckmc_load_cert_from_file(const char *file_path, ckmc_cert_s **cert);

        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_pkcs12_new", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int Pkcs12New(IntPtr key, IntPtr cert, IntPtr caCerts, out IntPtr p12_bundle);
        // int ckmc_pkcs12_new(ckmc_key_s *private_key, ckmc_cert_s* cert, ckmc_cert_list_s *ca_cert_list, ckmc_pkcs12_s** pkcs12_bundle);

        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_pkcs12_load", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int Pkcs12Load(string filePath, string password, out IntPtr pkcs12);
        // int ckmc_pkcs12_load(const char *file_path, const char* passphrase, ckmc_pkcs12_s **pkcs12_bundle);

        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_pkcs12_free", StringMarshalling = StringMarshalling.Utf8)]
        public static partial void Pkcs12Free(IntPtr pkcs12);
        // void ckmc_pkcs12_free(ckmc_pkcs12_s *pkcs12);

        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_alias_list_new", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int AliasListNew(string alias, out IntPtr aliasList);
        // int ckmc_alias_list_new(char *alias, ckmc_alias_list_s **ppalias_list);

        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_alias_list_add", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int AliasListAdd(IntPtr previous, string alias, out IntPtr aliasList);
        // int ckmc_alias_list_add(ckmc_alias_list_s *previous, char* alias, ckmc_alias_list_s **pplast);

        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_alias_list_free", StringMarshalling = StringMarshalling.Utf8)]
        public static partial void AliasListFree(IntPtr first);
        // void ckmc_alias_list_free(ckmc_alias_list_s* first);

        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_alias_list_all_free", StringMarshalling = StringMarshalling.Utf8)]
        public static partial void AliasListAllFree(IntPtr first);
        // void ckmc_alias_list_all_free(ckmc_alias_list_s* first);

        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_cert_list_new", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int CertListNew(IntPtr cert, out IntPtr certList);
        // int ckmc_cert_list_new(ckmc_cert_s *cert, ckmc_cert_list_s **ppcert_list);

        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_cert_list_add", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int CertListAdd(IntPtr previous, IntPtr cert, out IntPtr certList);
        // int ckmc_cert_list_add(ckmc_cert_list_s *previous, ckmc_cert_s *cert, ckmc_cert_list_s** pplast);

        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_cert_list_free", StringMarshalling = StringMarshalling.Utf8)]
        public static partial void CertListFree(IntPtr first);
        // void ckmc_cert_list_free(ckmc_cert_list_s *first);

        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_cert_list_all_free", StringMarshalling = StringMarshalling.Utf8)]
        public static partial void CertListAllFree(IntPtr first);
        // void ckmc_cert_list_all_free(ckmc_cert_list_s *first);

        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_param_list_new", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int ParamListNew(out IntPtr paramList);
        // int ckmc_param_list_new(ckmc_param_list_h *pparams);

        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_param_list_set_integer", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int ParamListSetInteger(IntPtr paramList, int name, long value);
        // int ckmc_param_list_set_integer(ckmc_param_list_h params, ckmc_param_name_e name, uint64_t value);

        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_param_list_set_buffer", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int ParamListSetBuffer(IntPtr paramList, int name, IntPtr buffer);
        // int ckmc_param_list_set_buffer(ckmc_param_list_h params, ckmc_param_name_e name, const ckmc_raw_buffer_s* buffer);

        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_param_list_get_integer", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int ParamListGetInteger(IntPtr paramList, int name, out long value);
        // int ckmc_param_list_get_integer(ckmc_param_list_h params, ckmc_param_name_e name, uint64_t *pvalue);

        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_param_list_get_buffer", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int ParamListGetBuffer(IntPtr paramList, int name, out IntPtr buffer);
        // int ckmc_param_list_get_buffer(ckmc_param_list_h params, ckmc_param_name_e name, ckmc_raw_buffer_s **ppbuffer);

        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_param_list_free", StringMarshalling = StringMarshalling.Utf8)]
        public static partial void ParamListFree(IntPtr first);
        // void ckmc_param_list_free(ckmc_param_list_h params);

        [LibraryImport(Libraries.KeyManager, EntryPoint = "ckmc_generate_new_params", StringMarshalling = StringMarshalling.Utf8)]
        public static partial int GenerateNewParam(int algoType, out IntPtr paramList);
        // int ckmc_generate_new_params(ckmc_algo_type_e type, ckmc_param_list_h *pparams);
    }
}




