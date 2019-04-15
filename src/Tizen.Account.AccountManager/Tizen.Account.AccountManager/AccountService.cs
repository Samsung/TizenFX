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
    /// The AccountManager APIs are separated into two major sections:
    /// 1. Registering an account provider while an application is installed. This information will be used for the Add account screen.
    /// 2. Adding an account information when an application signs in successfully to share the account information to the Tizen system. This information will be shown in the Tizen settings account menu.
    ///
    /// The APIs of both of the sections consist of the following functionality:
    /// <list type="bullet">
    /// <item><description>Create an account or account provider.</description></item>
    /// <item><description>Update an account or account provider (Only available for the creator).</description></item>
    /// <item><description>Delete an account or account provider (Only available for the creator).</description></item>
    /// <item><description>Read an account or account provider with some filter.</description></item>
    /// </list>
    /// </summary>
    /// <since_tizen> 3 </since_tizen>

    public static class AccountService
    {
        /// <summary>
        /// This is the contact capability string.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly string ContactCapability = "http://tizen.org/account/capability/contact";

        /// <summary>
        /// This is the calendar capability string.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly string CalendarCapability = "http://tizen.org/account/capability/calendar";

        /// <summary>
        /// This is the email capability string.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly string EmailCapability = "http://tizen.org/account/capability/email";

        /// <summary>
        /// This is the photo capability string.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly string PhotoCapability = "http://tizen.org/account/capability/photo";

        /// <summary>
        /// This is the video capability string.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly string VideoCapability = "http://tizen.org/account/capability/video";

        /// <summary>
        /// This is the music capability string.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly string MusicCapability = "http://tizen.org/account/capability/music";

        /// <summary>
        /// This is the document capability string.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly string DocumentCapability = "http://tizen.org/account/capability/document";

        /// <summary>
        /// This is the message capability string.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly string MessageCapability = "http://tizen.org/account/capability/message";

        /// <summary>
        /// This is the game capability string.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly string GameCapability = "http://tizen.org/account/capability/game";

        /// <summary>
        /// Retrieves all the accounts details from the account database.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>List of accounts.</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <feature>http://tizen.org/feature/account</feature>
        /// <exception cref="InvalidOperationException">In case of any DB error.</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public static IEnumerable<Account> GetAccountsAsync()
        {
            AccountErrorFactory.CheckAccountFeature();

            List<Account> accounts = new List<Account>();
            List<int> values = new List<int>();
            Interop.Account.AccountCallback accountCallback = (IntPtr data, IntPtr userdata) =>
            {
                Account account = new Account(new SafeAccountHandle(data, false));
                values.Add(account.AccountId);
                account.Dispose();
                return true;
            };

            AccountError res = (AccountError)Interop.AccountService.AccountForeachAccountFromDb(accountCallback, IntPtr.Zero);
            if (res != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(res, "Failed to AccountForeachAccountFromDb");
            }

            foreach (int i in values)
            {
                Account account = AccountService.GetAccountById(i);
                accounts.Add(account);
            }

            return accounts;
        }

        /// <summary>
        /// Retrieves the account with the account ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="accountId"> The account ID to be searched.</param>
        /// <returns>Account instance with reference to the given ID.</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <feature>http://tizen.org/feature/account</feature>
        /// <exception cref="InvalidOperationException">In case of any DB error or record not found for given account ID.</exception>
        /// <exception cref="ArgumentException"> In case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public static Account GetAccountById(int accountId)
        {
            AccountErrorFactory.CheckAccountFeature();

            AccountError err = (AccountError)Interop.Account.CreateUnmanagedHandle(out IntPtr handle);
            if (err != AccountError.None)
            {
                Log.Warn(AccountErrorFactory.LogTag, "Failed to create handle");
                throw AccountErrorFactory.CreateException(err, "Failed to create unmanaged handle");
            }

            SafeAccountHandle accountHandle = new SafeAccountHandle(handle, false);

            AccountError res = (AccountError)Interop.AccountService.QueryAccountById(accountId, ref accountHandle);
            if (res != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(res, "Failed to get accounts from the database for account id: " + accountId);
            }

            Account ref_account = new Account(accountHandle);

            return ref_account;
        }

        /// <summary>
        /// Retrieves all the AccountProviders details from the account database.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>List of AccountProviders.</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <feature>http://tizen.org/feature/account</feature>
        /// <exception cref="InvalidOperationException">In case of any DB error.</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public static IEnumerable<AccountProvider> GetAccountProviders()
        {
            AccountErrorFactory.CheckAccountFeature();

            List<string> values = new List<string>();
            List<AccountProvider> providers = new List<AccountProvider>();
            Interop.AccountProvider.AccountProviderCallback accountCallback = (IntPtr handle, IntPtr data) =>
            {
                AccountProvider provider = new AccountProvider(handle);
                values.Add(provider.AppId);
                provider.Dispose();
                return true;
            };

            AccountError res = (AccountError)Interop.AccountService.GetAllAccountproviders(accountCallback, IntPtr.Zero);
            if (res != AccountError.None)
            {
                Log.Warn(AccountErrorFactory.LogTag, "Failed to get account providers from the database");
                throw AccountErrorFactory.CreateException(res, "Failed to get account providers from the database");
            }

            foreach (string val in values)
            {
                AccountProvider provider = GetAccountProviderByAppId(val);
                providers.Add(provider);
            }

            return providers;
        }

        /// <summary>
        /// Retrieves the account provider information with the application ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="appId">The application ID.</param>
        /// <returns>The AccountProvider instance associated with the given application ID.</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <feature>http://tizen.org/feature/account</feature>
        /// <exception cref="InvalidOperationException">In case of any DB error or record not found for given appId.</exception>
        /// <exception cref="ArgumentException"> In case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public static AccountProvider GetAccountProviderByAppId(string appId)
        {
            AccountErrorFactory.CheckAccountFeature();

            IntPtr handle;
            Interop.AccountProvider.Create(out handle);
            AccountError err = (AccountError)Interop.AccountService.GetAccountProviderByAppId(appId, out handle);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to GetAccountProviderByAppId");
            }

            AccountProvider provider = new AccountProvider(handle);
            return provider;
        }

        /// <summary>
        /// Retrieves all the account providers information with feature.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="feature">The capability value to search for account providers.</param>
        /// <returns>Retrieves the AccountProviders information with the capability name.</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <feature>http://tizen.org/feature/account</feature>
        /// <exception cref="InvalidOperationException">In case of any DB error or record not found for given feature.</exception>
        /// <exception cref="ArgumentException"> In case of invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public static IEnumerable<AccountProvider> GetAccountProvidersByFeature(string feature)
        {
            AccountErrorFactory.CheckAccountFeature();

            List<string> values = new List<string>();
            List<AccountProvider> providers = new List<AccountProvider>();
            Interop.AccountProvider.AccountProviderCallback providerCallback = (IntPtr handle, IntPtr data) =>
            {
                AccountProvider provider = new AccountProvider(handle);
                values.Add(provider.AppId);
                provider.Dispose();
                return true;
            };

            AccountError err = (AccountError)Interop.AccountService.GetAccountProviderByFeature(providerCallback, feature, IntPtr.Zero);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to GetAccountProviderByFeature");
            }

            foreach (string val in values)
            {
                AccountProvider provider = GetAccountProviderByAppId(val);
                providers.Add(provider);
            }

            return providers;
        }

        /// <summary>
        /// Inserts into the Database with the new account Information.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="account">New Account instance to be added.</param>
        /// <returns>The account ID of the account instance.</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <privilege>http://tizen.org/privilege/account.write </privilege>
        /// <feature>http://tizen.org/feature/account</feature>
        /// <exception cref="InvalidOperationException">In case of any DB error.</exception>
        /// <exception cref="ArgumentException"> In case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="OutOfMemoryException"> In case of OutOfMemory error.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public static int AddAccount(Account account)
        {
            AccountErrorFactory.CheckAccountFeature();

            if (account == null)
            {
                throw AccountErrorFactory.CreateException(AccountError.InvalidParameter, "Failed to AddAccount");
            }

            int id = -1;
            AccountError err = (AccountError)Interop.AccountService.AddAccount(account.SafeAccountHandle, out id);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to AddAccount");
            }

            return id;
        }

        /// <summary>
        /// Updates the account details to the account database.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="account">Account instance to be updated.</param>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <privilege>http://tizen.org/privilege/account.write </privilege>
        /// <feature>http://tizen.org/feature/account</feature>
        /// <exception cref="InvalidOperationException">In case of any DB error.</exception>
        /// <exception cref="ArgumentException"> In case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="OutOfMemoryException"> In case of OutOfMemory error.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public static void UpdateAccount(Account account)
        {
            AccountErrorFactory.CheckAccountFeature();

            if (account == null)
            {
                throw AccountErrorFactory.CreateException(AccountError.InvalidParameter, "Failed to UpdateAccount");
            }

            AccountError err = (AccountError)Interop.AccountService.UpdateAccountToDBById(account.SafeAccountHandle, account.AccountId);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to UpdateAccount");
            }
        }

        /// <summary>
        /// Deletes the account information from the database.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="account">Account instance to be deleted from the database.</param>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <privilege>http://tizen.org/privilege/account.write</privilege>
        /// <feature>http://tizen.org/feature/account</feature>
        /// <exception cref="InvalidOperationException">In case of any DB error.</exception>
        /// <exception cref="ArgumentException"> In case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public static void DeleteAccount(Account account)
        {
            AccountErrorFactory.CheckAccountFeature();

            if (account == null)
            {
                throw AccountErrorFactory.CreateException(AccountError.InvalidParameter, "Failed to DeleteAccount");
            }

            AccountError err = (AccountError)Interop.AccountService.DeleteAccountById(account.AccountId);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to delete the account by Id: " + account.AccountId);
            }
        }

        /// <summary>
        /// Deletes the account from the account database by user name.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="userName">The user name of the account to delete.</param>
        /// <param name="packageName">The package name of the account to delete.</param>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <privilege>http://tizen.org/privilege/account.write</privilege>
        /// <feature>http://tizen.org/feature/account</feature>
        /// <exception cref="InvalidOperationException">In case of any DB error.</exception>
        /// <exception cref="ArgumentException"> In case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public static void DeleteAccount(string userName, string packageName)
        {
            AccountErrorFactory.CheckAccountFeature();

            AccountError err = (AccountError)Interop.AccountService.DeleteAccountByUser(userName, packageName);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to delete the account by userName: " + userName);
            }
        }

        /// <summary>
        /// Deletes the account from the account database by package name.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="packageName">The package name of the account to delete.</param>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <privilege>http://tizen.org/privilege/account.write</privilege>
        /// <feature>http://tizen.org/feature/account</feature>
        /// <exception cref="InvalidOperationException">In case of any DB error.</exception>
        /// <exception cref="ArgumentException"> In case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public static void DeleteAccount(string packageName)
        {
            AccountErrorFactory.CheckAccountFeature();

            AccountError err = (AccountError)Interop.AccountService.DeleteAccountByPackage(packageName);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to delete the account by package name: " + packageName);
            }

        }

        /// <summary>
        /// Retrieves all the accounts with the given user name.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="userName">The user name to search.</param>
        /// <returns>Accounts list matched with the user name.</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <feature>http://tizen.org/feature/account</feature>
        /// <exception cref="InvalidOperationException">In case of any DB error or record not found for given username.</exception>
        /// <exception cref="ArgumentException"> In case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public static IEnumerable<Account> GetAccountsByUserName(string userName)
        {
            AccountErrorFactory.CheckAccountFeature();

            List<Account> accounts = new List<Account>();
            List<int> values = new List<int>();
            Interop.Account.AccountCallback accountCallback = (IntPtr handle, IntPtr data) =>
            {
                Account account = new Account(new SafeAccountHandle(handle, false));
                values.Add(account.AccountId);
                account.Dispose();
                return true;
            };

            AccountError err = (AccountError)Interop.AccountService.QueryAccountByUserName(accountCallback, userName, IntPtr.Zero);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to GetAccountByUserName");
            }

            foreach (int i in values)
            {
                Account account = AccountService.GetAccountById(i);
                accounts.Add(account);
            }

            return accounts;
        }

        /// <summary>
        /// Retrieves all the accounts with the given package name.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="packageName"> The package name to search.</param>
        /// <returns>Accounts list matched with the package name.</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <feature>http://tizen.org/feature/account</feature>
        /// <exception cref="InvalidOperationException">In case of any DB error or record not found for given package name.</exception>
        /// <exception cref="ArgumentException"> In case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public static IEnumerable<Account> GetAccountsByPackageName(string packageName)
        {
            AccountErrorFactory.CheckAccountFeature();

            List<Account> accounts = new List<Account>();
            List<int> values = new List<int>();
            Interop.Account.AccountCallback accountCallback = (IntPtr handle, IntPtr data) =>
            {
                Account account = new Account(new SafeAccountHandle(handle, false));
                values.Add(account.AccountId);
                account.Dispose();
                return true;
            };

            AccountError err = (AccountError)Interop.AccountService.QueryAccountByPackageName(accountCallback, packageName, IntPtr.Zero);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to GetAccountByPackageName");
            }

            foreach (int i in values)
            {
                Account account = AccountService.GetAccountById(i);
                accounts.Add(account);
            }

            return accounts;
        }

        /// <summary>
        /// Retrieves all accounts with the given capability type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="type"> Capability type.</param>
        /// <returns>Accounts list matched with the capability type.</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <feature>http://tizen.org/feature/account</feature>
        /// <exception cref="InvalidOperationException">In case of any DB error or record not found for the given capability type.</exception>
        /// <exception cref="ArgumentException"> In case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public static IEnumerable<Account> GetAccountsByCapabilityType(string type)
        {
            AccountErrorFactory.CheckAccountFeature();

            List<Account> accounts = new List<Account>();
            List<int> values = new List<int>();
            Interop.Account.AccountCallback accountCallback = (IntPtr handle, IntPtr data) =>
            {
                Account account = new Account(new SafeAccountHandle(handle, false));
                values.Add(account.AccountId);
                account.Dispose();
                return true;
            };

            AccountError err = (AccountError)Interop.AccountService.GetAccountByCapabilityType(accountCallback, type, IntPtr.Zero);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to GetAccountByCapabilityType");
            }

            foreach (int i in values)
            {
                Account account = AccountService.GetAccountById(i);
                accounts.Add(account);
            }

            return accounts;
        }

        /// <summary>
        /// Retrieves all the capabilities with the given account.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="accountId">Account instance.</param>
        /// <returns>Capabilities list as dictionary of the capability type and state.</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <feature>http://tizen.org/feature/account</feature>
        /// <exception cref="InvalidOperationException">In case of any DB error or record not found for given account ID.</exception>
        /// <exception cref="ArgumentException"> In case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public static Dictionary<string, CapabilityState> GetCapabilitiesById(int accountId)
        {
            AccountErrorFactory.CheckAccountFeature();

            Dictionary<string, CapabilityState> capabilities = new Dictionary<string, CapabilityState>();
            Interop.Account.AccountCapabilityCallback capabilityCallback = (string type, int capabilityState, IntPtr data) =>
            {
                capabilities.Add(type, (CapabilityState)capabilityState);
                return true;
            };

            AccountError err = (AccountError)Interop.AccountService.QueryAccountCapabilityById(capabilityCallback, accountId, IntPtr.Zero);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to GetAllCapabilitiesById");
            }

            return capabilities;
        }

        /// <summary>
        /// Gets the count of accounts in the account database.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>The number of accounts in the database.</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <feature>http://tizen.org/feature/account</feature>
        /// <exception cref="InvalidOperationException">In case of any DB error.</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public static int GetAccountsCount()
        {
            AccountErrorFactory.CheckAccountFeature();

            int count = 0;
            AccountError err = (AccountError)Interop.AccountService.GetAccountCount(out count);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to GetAccountCount");
            }

            return count;
        }

        /// <summary>
        /// Updates the sync status of the given account.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="account"> Account for which the sync status needs to be updated.</param>
        /// <param name="status">Sync State</param>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <privilege>http://tizen.org/privilege/account.write</privilege>
        /// <feature>http://tizen.org/feature/account</feature>
        /// <exception cref="InvalidOperationException">In case of any DB error.</exception>
        /// <exception cref="ArgumentException"> In case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public static void UpdateSyncStatusById(Account account, AccountSyncState status)
        {
            AccountErrorFactory.CheckAccountFeature();

            AccountError err = (AccountError)Interop.AccountService.UpdateAccountSyncStatusById(account.AccountId, (int)status);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to UpdateSyncStatusById");
            }
        }

        private static readonly Interop.AccountService.SubscribeCallback s_accountUpdatedCallback = (string eventType, int accountId, IntPtr userData) =>
        {
            AccountErrorFactory.CheckAccountFeature();

            AccountSubscriberEventArgs eventArgs = new AccountSubscriberEventArgs(eventType, accountId);
            s_accountUpdated?.Invoke(null, eventArgs);
            return true;
        };

        private static Interop.AccountService.SafeAccountSubscriberHandle s_subscriberHandle;

        private static event EventHandler<AccountSubscriberEventArgs> s_accountUpdated;
        /// <summary>
        /// ContentUpdated event is triggered when the media item info from DB changes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// ContentUpdate event is triggered if the MediaInformation updated/deleted or new information is inserted.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <feature>http://tizen.org/feature/account</feature>
        /// <exception cref="InvalidOperationException">In case of any DB error.</exception>
        /// <exception cref="ArgumentException"> In case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public static event EventHandler<AccountSubscriberEventArgs> AccountUpdated
        {
            add
            {
                AccountErrorFactory.CheckAccountFeature();

                if (s_accountUpdated == null)
                {
                    if (s_subscriberHandle == null)
                    {
                        Interop.AccountService.CreateAccountSubscriber(out s_subscriberHandle);
                    }

                    AccountError ret = (AccountError)Interop.AccountService.RegisterSubscriber(s_subscriberHandle, s_accountUpdatedCallback, IntPtr.Zero);

                    if (ret != AccountError.None)
                    {
                        throw AccountErrorFactory.CreateException(ret, "Error in callback handling");
                    }
                }

                s_accountUpdated += value;
            }

            remove
            {
                AccountErrorFactory.CheckAccountFeature();

                s_accountUpdated -= value;
                if (s_accountUpdated == null)
                {
                    AccountError ret = (AccountError)Interop.AccountService.UnregisterSubscriber(s_subscriberHandle);
                    if (ret != AccountError.None)
                    {
                        throw AccountErrorFactory.CreateException(ret, "Error in callback handling");
                    }
                    s_subscriberHandle = null;
                }
            }
        }

    }
}
