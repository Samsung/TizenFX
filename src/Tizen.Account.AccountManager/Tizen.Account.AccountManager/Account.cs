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

namespace Tizen.Account.AccountManager
{
    /// <summary>
    /// Represents the Account Information.
    /// </summary>
    public class Account : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        internal Account(IntPtr handle)
        {
            Handle = handle;
        }

        ~Account()
        {
            Dispose(false);
        }
        /// <summary>
        /// Creates a new Account instance.
        /// </summary>
        /// <returns>Account Instance.</returns>
        public static Account CreateAccount()
        {
            IntPtr handle;
            AccountError err = (AccountError)Interop.Account.Create(out handle);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to create new error.");
            }

            return new Account(handle);
        }

        /// <summary>
        /// Id of the Account.
        /// </summary>
        /// <remarks>Account Id shall be created only when account is added to the database.</remarks>
        public int AccountId
        {
            get
            {
                int id = 0;
                AccountError res = (AccountError)Interop.Account.GetAccountId(_handle, out id);
                if (res != AccountError.None)
                {
                    Log.Warn(AccountErrorFactory.LogTag, "Failed to get Id for the Account");
                }

                return id;
            }
        }

        /// <summary>
        /// UserName of the Account.
        /// </summary>
        /// <value>User Name of the Account.</value>
        public string UserName
        {
            get
            {
                string name = "";
                AccountError res = (AccountError)Interop.Account.GetAccountUserName(_handle, out name);
                if (res != AccountError.None)
                {
                    Log.Warn(AccountErrorFactory.LogTag, "Failed to get UserName for the Account");
                }

                return name;
            }

            set
            {
                AccountError res = (AccountError)Interop.Account.SetAccountUserName(_handle, value);
                if (res != AccountError.None)
                {
                    throw AccountErrorFactory.CreateException(res, "Failed to Set UserName for Account");
                }
            }
        }

        /// <summary>
        /// Display Name of the Account.
        /// </summary>
        /// <value>DisplayName of the  Account.</value>
        public string DisplayName
        {
            get
            {
                string name = "";
                AccountError res = (AccountError)Interop.Account.GetAccountDisplayName(_handle, out name);
                if (res != AccountError.None)
                {
                    Log.Warn(AccountErrorFactory.LogTag, "Failed to get DisplayName for the Account");
                }

                return name;
            }

            set
            {
                AccountError res = (AccountError)Interop.Account.SetAccountDisplayName(_handle, value);
                if (res != AccountError.None)
                {
                    throw AccountErrorFactory.CreateException(res, "Failed to Set DisplayName for Account");
                }
            }
        }

        /// <summary>
        /// Icon path of the Account.
        /// </summary>
        /// <value>Icon path of the Account.</value>
        public string IconPath
        {
            get
            {
                string path = "";
                AccountError res = (AccountError)Interop.Account.GetAccountIconPath(_handle, out path);
                if (res != AccountError.None)
                {
                    Log.Warn(AccountErrorFactory.LogTag, "Failed to get IconPath for the Account");
                }

                return path;
            }

            set
            {
                AccountError res = (AccountError)Interop.Account.SetAccountIconPath(_handle, value);
                if (res != AccountError.None)
                {
                    throw AccountErrorFactory.CreateException(res, "Failed to Set IconPath for Account");
                }
            }
        }

        /// <summary>
        /// Domain name of the Account.
        /// </summary>
        /// <value>Domain name of the Account.</value>
        public string DomainName
        {
            get
            {
                string name = "";
                AccountError res = (AccountError)Interop.Account.GetAccountDomainName(_handle, out name);
                if (res != AccountError.None)
                {
                    Log.Warn(AccountErrorFactory.LogTag, "Failed to get DomainName for the Account");
                }

                return name;
            }

            set
            {
                AccountError res = (AccountError)Interop.Account.SetAccountDomainName(_handle, value);
                if (res != AccountError.None)
                {
                    throw AccountErrorFactory.CreateException(res, "Failed to Set DomainName for Account");
                }
            }
        }

        /// <summary>
        /// Email Id of the Account.
        /// </summary>
        /// <value>Email Id of the Account.</value>
        public string EmailId
        {
            get
            {
                string email = "";
                AccountError res = (AccountError)Interop.Account.GetAccountEmail(_handle, out email);
                if (res != AccountError.None)
                {
                    Log.Warn(AccountErrorFactory.LogTag, "Failed to get email for the Account");
                }

                return email;
            }

            set
            {
                AccountError res = (AccountError)Interop.Account.SetAccountEmail(_handle, value);
                if (res != AccountError.None)
                {
                    throw AccountErrorFactory.CreateException(res, "Failed to Set email for Account");
                }
            }
        }

        /// <summary>
        /// Package Name of the Account.
        /// </summary>
        /// <value>Package Name.</value>
        public string PackageName
        {
            get
            {
                string name = "";
                AccountError res = (AccountError)Interop.Account.GetAccountPackageName(_handle, out name);
                if (res != AccountError.None)
                {
                    Log.Warn(AccountErrorFactory.LogTag, "Failed to get PacakageName for the Account");
                }

                return name;
            }

            set
            {
                AccountError res = (AccountError)Interop.Account.SetAccountPackageName(_handle, value);
                if (res != AccountError.None)
                {
                    throw AccountErrorFactory.CreateException(res, "Failed to Set PacakageName for Account");
                }
            }
        }

        /// <summary>
        /// Access Token of the Account.
        /// </summary>
        /// <value>Access Token.</value>
        public string AccessToken
        {
            get
            {
                string token = "";
                AccountError res = (AccountError)Interop.Account.GetAccountAccessToken(_handle, out token);
                if (res != AccountError.None)
                {
                    Log.Warn(AccountErrorFactory.LogTag, "Failed to get token for the Account");
                }

                return token;
            }

            set
            {
                AccountError res = (AccountError)Interop.Account.SetAccountAccessToken(_handle, value);
                if (res != AccountError.None)
                {
                    throw AccountErrorFactory.CreateException(res, "Failed to Set token for Account");
                }
            }
        }

        /// <summary>
        /// Authentication type of the Account.
        /// </summary>
        /// <value>Authentication type.</value>
        public AccountAuthType AuthType
        {
            get
            {
                int user;
                AccountError res = (AccountError)Interop.Account.GetAccountAuthType(_handle, out user);
                if (res != AccountError.None)
                {
                    Log.Warn(AccountErrorFactory.LogTag, "Failed to get AuthType for the Account");
                }

                return (AccountAuthType)user;
            }

            set
            {
                AccountError res = (AccountError)Interop.Account.SetAccountAuthType(_handle, (int)value);
                if (res != AccountError.None)
                {
                    throw AccountErrorFactory.CreateException(res, "Failed to Set AuthType for Account");
                }
            }
        }

        /// <summary>
        /// Secrecy State of the Account.
        /// </summary>
        /// <value>Secrecy State.</value>
        public AccountSecrecyState SecrecyState
        {
            get
            {
                int state;
                AccountError res = (AccountError)Interop.Account.GetAccountSercet(_handle, out state);
                if (res != AccountError.None)
                {
                    Log.Warn(AccountErrorFactory.LogTag, "Failed to get User Secret for the Account");
                }

                return (AccountSecrecyState)state;
            }

            set
            {
                AccountError res = (AccountError)Interop.Account.SetAccountSecret(_handle, (int)value);
                if (res != AccountError.None)
                {
                    throw AccountErrorFactory.CreateException(res, "Failed to Set User Secret for Account");
                }
            }
        }

        /// <summary>
        /// Sync State of the Account.
        /// </summary>
        /// <value>Sync State.</value>
        public AccountSyncState SyncState
        {
            get
            {
                int supported;
                AccountError res = (AccountError)Interop.Account.GetAccountSyncSupport(_handle, out supported);
                if (res != AccountError.None)
                {
                    Log.Warn(AccountErrorFactory.LogTag, "Failed to get AuthType for the Account");
                }

                return (AccountSyncState)supported;
            }

            set
            {
                AccountError res = (AccountError)Interop.Account.SetAccountSyncSupport(_handle, (int)value);
                if (res != AccountError.None)
                {
                    throw AccountErrorFactory.CreateException(res, "Failed to Set AuthType for Account");
                }
            }
        }

        /// <summary>
        /// Source of the Account .
        /// </summary>
        /// <value>Account Source.</value>
        public string Source
        {
            get
            {
                string text = "";
                AccountError res = (AccountError)Interop.Account.GetAccountSource(_handle, out text);
                if (res != AccountError.None)
                {
                    Log.Warn(AccountErrorFactory.LogTag, "Failed to get User Secret for the Account");
                }

                return text;
            }

            set
            {
                AccountError res = (AccountError)Interop.Account.SetAccountSource(_handle, value);
                if (res != AccountError.None)
                {
                    throw AccountErrorFactory.CreateException(res, "Failed to Set User Secret for Account");
                }
            }
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
        /// Sets the account capability.
        /// </summary>
        /// <param name="capabilityType"> The Account capability type</param>
        /// <param name="state">The Account capability state</param>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        public void SetCapability(string capabilityType, CapabilityState state)
        {
            AccountError ret = (AccountError)Interop.Account.SetAccountCapability(_handle, capabilityType, (int)state);
            if (ret != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(ret, "failed to set account capability");
            }
        }
        /// <summary>
        /// Gets all the capabilities of an account.
        /// </summary>
        /// <param name="capabilityType"> The capability type to get the capability value.</param>
        /// <returns>The capability value (on/off) of the specified CapabilityState .</returns>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        public CapabilityState GetCapability(string capabilityType)
        {
            int type;
            AccountError res = (AccountError)Interop.Account.GetAccountCapability(_handle, capabilityType, out type);
            if (res != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(res, "Failed to GetCapability for Account");
            }

            return (CapabilityState)type;
        }

        /// <summary>
        /// Gets all the capabilities of an account.
        /// </summary>
        /// <returns>List of Cpabailities as Dictionary</returns>
        public Dictionary<string, CapabilityState> GetAllCapabilities()
        {

            AccountError res = AccountError.None;
            Dictionary<string, CapabilityState> list = new Dictionary<string, CapabilityState>();
            Interop.Account.AccountCapabilityCallback capabilityCallback = (string type, int state, IntPtr data) =>
            {
                list.Add(type, (CapabilityState)state);
                return true;
            };

            res = (AccountError)Interop.Account.GetAllAccountCapabilities(_handle, capabilityCallback, IntPtr.Zero);
            if (res != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(res, "Failed to get account capabilities");
            }

            return list;
        }

        /// <summary>
        /// Sets the Custom Value to the Account.
        /// </summary>
        /// <param name="key">key to be added to the Account.</param>
        /// <param name="value">value to be updated for respective key for the Account.</param>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        public void SetCustomValue(string key, string value)
        {
            AccountError err = (AccountError)Interop.Account.SetAccountCustomValue(_handle, key, value);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to set the value for : " + key);
            }
        }

        /// <summary>
        /// Gets the user specific custom text of an account key.
        /// </summary>
        /// <param name="key">The key to retrieve custom text .</param>
        /// <returns>The text of the given key</returns>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        /// <exception cref="InvalidOperationException">If there is no given capability type in the account </exception>
        public string GetCustomValue(string key)
        {
            string result = "";
            AccountError err = (AccountError)Interop.Account.GetAccountCustomValue(_handle, key, out result);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to get the value for : " + key);
            }

            return result;
        }

        /// <summary>
        /// Gets All the custome values.
        /// </summary>
        /// <returns>List of custom key, value pairs as Dictionary.</returns>
        public Dictionary<string, string> GetAllCustomValues()
        {
            AccountError res = AccountError.None;
            Dictionary<string, string> list = new Dictionary<string, string>();

            Interop.Account.AccountCustomCallback customCallback = (string key, string value, IntPtr data) =>
            {
                list.Add(key, value);
                return true;
            };

            res = (AccountError)Interop.Account.GetAllAccountCustomValues(_handle, customCallback, IntPtr.Zero);

            if (res != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(res, "Failed to get account capabilities");
            }

            return list;
        }

        /// <summary>
        /// Sets the user text.
        /// </summary>
        /// <param name="index">The index of the user text (must be in range from 0 to 4) </param>
        /// <param name="text">The text string to set as the user text</param>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        public void SetUserText(int index, string text)
        {
            AccountError err = (AccountError)Interop.Account.SetAccountUserText(_handle, index, text);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to get the value for : " + index);
            }
        }

        /// <summary>
        /// Gets the user text.
        /// </summary>
        /// <param name="index">The index of the user text (range: 0 ~ 4)</param>
        /// <returns>The user text of the given key</returns>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        /// <exception cref="OutOfMemoryException">In case of out of memory</exception>
        public string GetUserText(int index)
        {
            string result = "";
            AccountError err = (AccountError)Interop.Account.GetAccountUserText(_handle, index, out result);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to get the value for : " + index);
            }

            return result;
        }

        /// <summary>
        /// Gets the user int value.
        /// </summary>
        /// <param name="index">The index of the user int (range: 0 ~ 4)</param>
        /// <returns>The user int of the given key</returns>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        public int GetUserInt(int index)
        {
            int result = -1;
            AccountError err = (AccountError)Interop.Account.GetAccountUserInt(_handle, index, out result);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to get the value for : " + index);
            }

            return result;
        }

        /// <summary>
        /// Sets the user integer value.
        /// </summary>
        /// <param name="index">The index of the user integer (must be in range from 0 to 4) </param>
        /// <param name="value">The integer to set as the user integer</param>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        public void SetUserInt(int index, int value)
        {
            AccountError err = (AccountError)Interop.Account.SetAccountUserInt(_handle, index, value);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to get the value for : " + index);
            }
        }

        /// <summary>
        /// Overloaded Dispose API for destroying the Account Handle.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing)
            {
                if (_handle != IntPtr.Zero)
                {
                    Interop.Account.Destroy(_handle);
                    _handle = IntPtr.Zero;
                }
            }
        }
    }
}
