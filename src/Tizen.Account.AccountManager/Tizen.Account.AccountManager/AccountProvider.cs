/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using Tizen.Internals.Errors;

namespace Tizen.Account.AccountManager
{
    /// <summary>
    /// The account ID.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class AccountProvider : IDisposable
    {
        internal IntPtr _handle;

        /// <summary>
        /// AccountProvider destructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="handle"> The account handle.</param>
        internal AccountProvider(IntPtr handle)
        {
            Handle = handle;
        }

        /// <summary>
        /// AccountProvider deconstructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        ~AccountProvider()
        {
            Dispose(false);
        }

        internal IntPtr Handle
        {
            get
            {
                return _handle;
            }

            set
            {
                _handle = value;
            }
        }
        /// <summary>
        /// The account ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string AppId
        {
            get
            {
                if (AccountErrorFactory.IsAccountFeatureSupported() == false)
                {
                    AccountErrorFactory.ThrowNotSupportedException(AccountError.NotSupported, "account feature not supported");
                }

                string id = "";
                AccountError res = (AccountError)Interop.AccountProvider.GetAppId(Handle, out id);
                if (res != AccountError.None)
                {
                    Log.Warn(AccountErrorFactory.LogTag, "Failed to get AppId for the AccountProvider");
                }

                return id;
            }
        }

        /// <summary>
        /// ServiceProvider ID of the account provider.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string ServiceProviderId
        {
            get
            {
                if (AccountErrorFactory.IsAccountFeatureSupported() == false)
                {
                    AccountErrorFactory.ThrowNotSupportedException(AccountError.NotSupported, "account feature not supported");
                }

                string id = "";
                AccountError res = (AccountError)Interop.AccountProvider.GetServiceProviderId(Handle, out id);
                if (res != AccountError.None)
                {
                    Log.Warn(AccountErrorFactory.LogTag, "Failed to get ServiceProviderId for the AccountProvider");
                }

                return id;
            }
        }

        /// <summary>
        /// Icon path of the account provider.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string IconPath
        {
            get
            {
                if (AccountErrorFactory.IsAccountFeatureSupported() == false)
                {
                    AccountErrorFactory.ThrowNotSupportedException(AccountError.NotSupported, "account feature not supported");
                }

                string path = "";
                AccountError res = (AccountError)Interop.AccountProvider.GetAccountProviderIconPath(Handle, out path);
                if (res != AccountError.None)
                {
                    Log.Warn(AccountErrorFactory.LogTag, "Failed to get IconPath for the AccountProvider");
                }

                return path;
            }
        }

        /// <summary>
        /// Small icon path of the account provider.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string SmallIconPath
        {
            get
            {
                if (AccountErrorFactory.IsAccountFeatureSupported() == false)
                {
                    AccountErrorFactory.ThrowNotSupportedException(AccountError.NotSupported, "account feature not supported");
                }

                string path = "";
                AccountError res = (AccountError)Interop.AccountProvider.GetAccountProviderSmallIconPath(Handle, out path);
                if (res != AccountError.None)
                {
                    Log.Warn(AccountErrorFactory.LogTag, "Failed to get SmallIconPath for the AccountProvider");
                }

                return path;
            }
        }

        /// <summary>
        /// Flag for the account provider if it supports multiple accounts.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool MultipleAccountSupport
        {
            get
            {
                if (AccountErrorFactory.IsAccountFeatureSupported() == false)
                {
                    AccountErrorFactory.ThrowNotSupportedException(AccountError.NotSupported, "account feature not supported");
                }

                int multiple = 0;
                AccountError res = (AccountError)Interop.AccountProvider.GetMultipleAccountSupport(Handle, out multiple);
                if (res != AccountError.None)
                {
                    Log.Warn(AccountErrorFactory.LogTag, "Failed to get SmallIconPath for the AccountProvider");
                }

                return (multiple == 0) ? false : true;
            }
        }

        /// <summary>
        /// Retrieves all the capability information of the account provider.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <feature>http://tizen.org/feature/account</feature>
        /// <returns>
        /// The list of capability information.
        /// </returns>
        /// <exception cref="InvalidOperationException">In case of any DB error.</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public IEnumerable<string> GetAllCapabilities()
        {
            if (AccountErrorFactory.IsAccountFeatureSupported() == false)
            {
                AccountErrorFactory.ThrowNotSupportedException(AccountError.NotSupported, "account feature not supported");
            }

            List<string> capabilities = new List<string>();
            AccountError res;
            Interop.AccountProvider.AccountProviderFeatureCallback callback = (string appId, string key, IntPtr data) =>
            {
                capabilities.Add(key);
                return true;
            };

            res = (AccountError)Interop.AccountProvider.GetAccountProviderFeatures(Handle, callback, IntPtr.Zero);
            if (res != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(res, "Failed to GetAllCapabilities for AccountProvider");
            }

            return capabilities;
        }

        /// <summary>
        /// Gets the specific label information detail of the account provider.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="locale">
        /// The locale is specified as an ISO 3166 alpha-2 two letter country-code followed by ISO 639-1 for the two-letter language code.
        /// For example, "ko_KR" or "ko-kr" for Korean, "en_US" or "en-us" for American English.
        /// </param>
        /// <returns>The label text given for the locale.</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <feature>http://tizen.org/feature/account</feature>
        /// <exception cref="InvalidOperationException">In case of any DB error or record not found for given locale.</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public string GetLabel(string locale)
        {
            if (AccountErrorFactory.IsAccountFeatureSupported() == false)
            {
                AccountErrorFactory.ThrowNotSupportedException(AccountError.NotSupported, "account feature not supported");
            }

            string label;
            AccountError res = (AccountError)Interop.AccountProvider.GetlabelbyLocale(Handle, locale, out label);
            if (res != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(res, "Failed to GetLabel for AccountProvider");
            }

            return label;
        }

        /// <summary>
        /// Gets the specific label information detail of the account provider.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="appId">
        /// The application ID to search.
        /// </param>
        /// <returns> All the labels information for the given application ID.</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <feature>http://tizen.org/feature/account</feature>
        /// <exception cref="InvalidOperationException">In case of any DB error or record not found for given the application ID.</exception>
        /// <exception cref="ArgumentException"> In case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public static Dictionary<string, string> GetLabelsByAppId(string appId)
        {
            if (AccountErrorFactory.IsAccountFeatureSupported() == false)
            {
                AccountErrorFactory.ThrowNotSupportedException(AccountError.NotSupported, "account feature not supported");
            }

            Dictionary<string, string> labels = new Dictionary<string, string>();
            Interop.AccountProvider.LabelCallback callback = (string applicationId, string label, string locale, IntPtr userData) =>
            {
                labels.Add(locale, label);
                return true;
            };

            AccountError err = (AccountError)Interop.AccountProvider.GetLablesByAppId(callback, appId, IntPtr.Zero);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to GetLablesByAppId");
            }

            return labels;
        }

        /// <summary>
        /// Gets the label information detail of the account provider.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns> All the labels information for the given account provider.</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <feature>http://tizen.org/feature/account</feature>
        /// <exception cref="InvalidOperationException">In case of any DB error.</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public Dictionary<string, string> GetLabels()
        {
            if (AccountErrorFactory.IsAccountFeatureSupported() == false)
            {
                AccountErrorFactory.ThrowNotSupportedException(AccountError.NotSupported, "account feature not supported");
            }

            Dictionary<string, string> labels = new Dictionary<string, string>();
            Interop.AccountProvider.LabelCallback callback = (string applicationId, string label, string locale, IntPtr userData) =>
            {
                labels.Add(locale, label);
                return true;
            };

            AccountError err = (AccountError)Interop.AccountProvider.GetAccountProviderLabels(Handle, callback, IntPtr.Zero);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to GetAccountProviderLabels");
            }

            return labels;
        }

        /// <summary>
        /// Checks whether the given appId exists in the account provider DB.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="appId">The application ID to check.</param>
        /// <returns>returns true If App is supported </returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <feature>http://tizen.org/feature/account</feature>
        /// <exception cref="InvalidOperationException">In case of any DB error or record not found for the given application ID.</exception>
        /// <exception cref="ArgumentException"> In case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public bool IsAppSupported(string appId)
        {
            if (AccountErrorFactory.IsAccountFeatureSupported() == false)
            {
                AccountErrorFactory.ThrowNotSupportedException(AccountError.NotSupported, "account feature not supported");
            }

            bool isSupported = false;
            AccountError res = (AccountError)Interop.AccountProvider.GetAppIdExists(appId);

            if (res != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(res, "Failed to GetLabel for AccountProvider");
            }
            else
            {
                isSupported = true;
            }

            return isSupported;
        }

        /// <summary>
        /// Checks whether the given application ID supports the capability.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="appId">The application ID.</param>
        /// <param name="capability">The capability information.</param>
        /// <returns>
        /// TRUE if the application supports the given capability,
        /// otherwise FALSE if the application does not support the given capability
        /// </returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <feature>http://tizen.org/feature/account</feature>
        /// <exception cref="InvalidOperationException">In case of any DB error.</exception>
        /// <exception cref="ArgumentException"> In case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public static bool IsFeatureSupportedByApp(string appId, string capability)
        {
            if (AccountErrorFactory.IsAccountFeatureSupported() == false)
            {
                AccountErrorFactory.ThrowNotSupportedException(AccountError.NotSupported, "account feature not supported");
            }

            bool supported = Interop.AccountProvider.IsFeatureSupported(appId, capability);
            if (!supported)
            {
                //Get last result and validate error code.
                AccountError err = (AccountError)ErrorFacts.GetLastResult();
                if ((err != AccountError.None) && (err != AccountError.RecordNotFound))
                {
                    throw AccountErrorFactory.CreateException(err, "Failed to get IsFeatureSupported");
                }
            }

            return supported;
        }

        /// <summary>
        /// Retrieves capability information with the application ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="appId">The application ID.</param>
        /// <returns> Capability information list for the given appId.</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <feature>http://tizen.org/feature/account</feature>
        /// <exception cref="InvalidOperationException">In case of any DB error or record not found for the given application ID.</exception>
        /// <exception cref="ArgumentException"> In case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public static IEnumerable<string> GetFeaturesByAppId(string appId)
        {
            if (AccountErrorFactory.IsAccountFeatureSupported() == false)
            {
                AccountErrorFactory.ThrowNotSupportedException(AccountError.NotSupported, "account feature not supported");
            }

            List<string> features = new List<string>();
            Interop.AccountProvider.AccountProviderFeatureCallback callback = (string applicationId, string key, IntPtr userData) =>
            {
                features.Add(key);
                return true;
            };

            AccountError err = (AccountError)Interop.AccountProvider.GetAccountProviderFeaturesByAppId(callback, appId, IntPtr.Zero);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to GetAccountProviderFeaturesByAppId");
            }

            return (IEnumerable<string>)features;
        }

        /// <summary>
        /// Overloaded Dispose API for destroying the AccountProvider Handle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose API for destroying the AccountProvider handle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="disposing">The boolean value for destoying AccountProvider handle.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                if (_handle != IntPtr.Zero)
                {
                    Interop.AccountProvider.Destroy(_handle);
                    _handle = IntPtr.Zero;
                }
            }
        }
    }
}
