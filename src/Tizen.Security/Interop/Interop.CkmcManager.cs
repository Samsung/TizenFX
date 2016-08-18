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

internal static partial class Interop
{
    internal static partial class CkmcManager
    {
        [DllImport(Libraries.KeyManager, EntryPoint = "ckmc_save_key", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SaveKey(string alias, CkmcKey key, CkmcPolicy policy);
        // int ckmc_save_key(const char *alias, const ckmc_key_s key, const ckmc_policy_s policy);

        [DllImport(Libraries.KeyManager, EntryPoint = "ckmc_get_key", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetKey(string alias, string password, out IntPtr key);
        // int ckmc_get_key(const char *alias, const char *password, ckmc_key_s **ppkey);

        [DllImport(Libraries.KeyManager, EntryPoint = "ckmc_get_key_alias_list", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetKeyAliasList(out IntPtr aliases);
        // int ckmc_get_key_alias_list(ckmc_alias_list_s **ppalias_list);


        [DllImport(Libraries.KeyManager, EntryPoint = "ckmc_save_cert", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SaveCert(string alias, CkmcCert cert, CkmcPolicy policy);
        // int ckmc_save_cert(const char *alias, const ckmc_cert_s cert, const ckmc_policy_s policy);

        [DllImport(Libraries.KeyManager, EntryPoint = "ckmc_get_cert", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetCert(string alias, string password, out IntPtr data);
        // int ckmc_get_cert(const char *alias, const char *password, ckmc_cert_s** ppcert);

        [DllImport(Libraries.KeyManager, EntryPoint = "ckmc_get_cert_alias_list", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetCertAliasList(out IntPtr aliases);
        // int ckmc_get_cert_alias_list(ckmc_alias_list_s **ppalias_list);


        [DllImport(Libraries.KeyManager, EntryPoint = "ckmc_save_data", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SaveData(string alias, CkmcRawBuffer data, CkmcPolicy policy);
        // int ckmc_save_data(const char *alias, ckmc_raw_buffer_s data, const ckmc_policy_s policy);

        [DllImport(Libraries.KeyManager, EntryPoint = "ckmc_get_data", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetData(string alias, string password, out IntPtr data);
        // int ckmc_get_data(const char* alias, const char* password, ckmc_raw_buffer_s **ppdata);

        [DllImport(Libraries.KeyManager, EntryPoint = "ckmc_get_data_alias_list", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetDataAliasList(out IntPtr aliases);
        // int ckmc_get_data_alias_list(ckmc_alias_list_s **ppalias_list);


        [DllImport(Libraries.KeyManager, EntryPoint = "ckmc_remove_alias", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RemoveAlias(string alias);
        // int ckmc_remove_alias(const char *alias);


        [DllImport(Libraries.KeyManager, EntryPoint = "ckmc_save_pkcs12", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SavePkcs12(string alias, IntPtr p12, CkmcPolicy keyPolicy, CkmcPolicy certPolicy);
        // int ckmc_save_pkcs12(const char *alias, const ckmc_pkcs12_s* pkcs, const ckmc_policy_s key_policy, const ckmc_policy_s cert_policy);

        [DllImport(Libraries.KeyManager, EntryPoint = "ckmc_get_pkcs12", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetPkcs12(string alias, string keyPassword, string certPassword, out IntPtr pkcs12);
        // int ckmc_get_pkcs12(const char *alias, const char *key_password, const char* cert_password, ckmc_pkcs12_s **pkcs12);

        [DllImport(Libraries.KeyManager, EntryPoint = "ckmc_set_permission", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetPermission(string alias, string accessor, int permissions);
        // int ckmc_set_permission(const char *alias, const char *accessor, int permissions);


        [DllImport(Libraries.KeyManager, EntryPoint = "ckmc_create_key_pair_rsa", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CreateKeyPairRsa(int size, string privateKeyAlias, string publicKeyAlias,
                                                  CkmcPolicy privateKeyPolicy, CkmcPolicy publicKeyPolicy);
        // int ckmc_create_key_pair_rsa(const size_t size, const char* private_key_alias, const char* public_key_alias,
        //                              const ckmc_policy_s policy_private_key, const ckmc_policy_s policy_public_key);

        [DllImport(Libraries.KeyManager, EntryPoint = "ckmc_create_key_pair_dsa", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CreateKeyPairDsa(int size, string privateKeyAlias, string publicKeyAlias,
                                                  CkmcPolicy privateKeyPolicy, CkmcPolicy publicKeyPolicy);
        // int ckmc_create_key_pair_dsa(const size_t size, const char* private_key_alias, const char* public_key_alias,
        //                              const ckmc_policy_s policy_private_key, const ckmc_policy_s policy_public_key);

        [DllImport(Libraries.KeyManager, EntryPoint = "ckmc_create_key_pair_ecdsa", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CreateKeyPairEcdsa(int ecType, string privateKeyAlias, string publicKeyAlias,
                                                        CkmcPolicy privateKeyPolicy, CkmcPolicy publicKeyPolicy);
        // int ckmc_create_key_pair_ecdsa(const size_t size, const char* private_key_alias, const char* public_key_alias,
        //                                const ckmc_policy_s policy_private_key, const ckmc_policy_s policy_public_key);

        [DllImport(Libraries.KeyManager, EntryPoint = "ckmc_create_key_aes", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CreateKeyAes(int size, string ceyAlias, CkmcPolicy keyPolicy);
        // int ckmc_create_key_aes(size_t size, const char* key_alias, ckmc_policy_s key_policy);

        [DllImport(Libraries.KeyManager, EntryPoint = "ckmc_create_signature", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CreateSignature(string privateKeyAlias, string password, CkmcRawBuffer message,
                                                 int hashAlgorithm, int paddingAlgorithm, out IntPtr signature);
        // int ckmc_create_signature(const char *private_key_alias, const char* password, const ckmc_raw_buffer_s message,
        //                           const ckmc_hash_algo_e hash, const ckmc_rsa_padding_algo_e padding, ckmc_raw_buffer_s **ppsignature);

        [DllImport(Libraries.KeyManager, EntryPoint = "ckmc_verify_signature", CallingConvention = CallingConvention.Cdecl)]
        public static extern int VerifySignature(string publicKeyAlias, string password, CkmcRawBuffer message,
                                                 CkmcRawBuffer signature, int hashAlgorithm, int paddingAlgorithm);
        // int ckmc_verify_signature(const char *public_key_alias, const char* password, const ckmc_raw_buffer_s message,
        //           const ckmc_raw_buffer_s signature, const ckmc_hash_algo_e hash, const ckmc_rsa_padding_algo_e padding);

        [DllImport(Libraries.KeyManager, EntryPoint = "ckmc_encrypt_data", CallingConvention = CallingConvention.Cdecl)]
        public static extern int EncryptData(IntPtr parameters, string keyAlias, string password, CkmcRawBuffer plainText, out IntPtr cipherText);
        // int ckmc_encrypt_data(ckmc_param_list_h params, const char* key_alias, const char* password,
        //                       const ckmc_raw_buffer_s decrypted, ckmc_raw_buffer_s **ppencrypted);

        [DllImport(Libraries.KeyManager, EntryPoint = "ckmc_decrypt_data", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DecryptData(IntPtr parameters, string keyAlias, string password, CkmcRawBuffer cipherText, out IntPtr plainText);
        // int ckmc_decrypt_data(ckmc_param_list_h params, const char* key_alias, const char* password,
        //                       const ckmc_raw_buffer_s encrypted, ckmc_raw_buffer_s **ppdecrypted);


        [DllImport(Libraries.KeyManager, EntryPoint = "ckmc_get_cert_chain", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetCertChain(IntPtr cert, IntPtr untrustedCerts, out IntPtr certChain);
        // int ckmc_get_cert_chain(const ckmc_cert_s *cert, const ckmc_cert_list_s* untrustedcerts, ckmc_cert_list_s **ppcert_chain_list);

        [DllImport(Libraries.KeyManager, EntryPoint = "ckmc_get_cert_chain_with_trustedcert", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetCertChainWithTrustedCerts(IntPtr cert, IntPtr untrustedCerts, IntPtr trustedCerts,
                                                                    bool useTrustedSystemCerts, out IntPtr certChain);
        // int ckmc_get_cert_chain_with_trustedcert(const ckmc_cert_s *cert, const ckmc_cert_list_s* untrustedcerts,
        //       const ckmc_cert_list_s* trustedcerts, const bool use_trustedsystemcerts, ckmc_cert_list_s **ppcert_chain_list);

        [DllImport(Libraries.KeyManager, EntryPoint = "ckmc_ocsp_check", CallingConvention = CallingConvention.Cdecl)]
        public static extern int OcspCheck(IntPtr certChain, ref int ocspStatus);
        // int ckmc_ocsp_check(const ckmc_cert_list_s *pcert_chain_list, ckmc_ocsp_status_e* ocsp_status);
    }
}
