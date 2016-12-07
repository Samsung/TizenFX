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
    /// The AccountManager APIs is separated into two major sections:
    /// 1. Registering an account provider while an application is installed. This information will be used for the Add account screen.
    /// 2. Adding an account information when an application signs in successfully to share the account information to the Tizen system. This information will be shown in the Tizen settings account menu.
    ///
    /// The APIs of both of the sections consist of the following functionality:
    /// <list>
    /// <item> Create an account or account provider </item>
    /// <item> Update an account or account provider(Only available for the creator) </item>
    /// <item> Delete an account or account provider(Only available for the creator) </item>
    /// <item> Read an account or account provider with some filter </item>
    /// </list>
    /// </summary>

    public static class AccountService
    {
        /// <summary>
        /// This is contact capability string.
        /// </summary>
        public static readonly string ContactCapability = "http://tizen.org/account/capability/contact";

        /// <summary>
        /// This is calendar capability string.
        /// </summary>
        public static readonly string CalendarCapability = "http://tizen.org/account/capability/calendar";

        /// <summary>
        /// This is email capability string.
        /// </summary>
        public static readonly string EmailCapability = "http://tizen.org/account/capability/email";

        /// <summary>
        /// This is photo capability string.
        /// </summary>
        public static readonly string PhotoCapability = "http://tizen.org/account/capability/photo";

        /// <summary>
        /// This is video capability string.
        /// </summary>
        public static readonly string VideoCapability = "http://tizen.org/account/capability/video";

        /// <summary>
        /// This is music capability string.
        /// </summary>
        public static readonly string MusicCapability = "http://tizen.org/account/capability/music";

        /// <summary>
        /// This is document capability string.
        /// </summary>
        public static readonly string DocumentCapability = "http://tizen.org/account/capability/document";

        /// <summary>
        /// This is message capability string.
        /// </summary>
        public static readonly string MessageCapability = "http://tizen.org/account/capability/message";

        /// <summary>
        /// This is game capability string.
        /// </summary>
        public static readonly string GameCapability = "http://tizen.org/account/capability/game";

        /// <summary>
        /// Retrieves all accounts details from the account database.
        /// </summary>
        /// <returns>List of Accounts</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <exception cref="InvalidOperationException">In case of any DB error. </exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        public static IEnumerable<Account> GetAccountsAsync()
        {
            List<Account> accounts = new List<Account>();
            List<int> values = new List<int>();
            Interop.Account.AccountCallback accountCallback = (IntPtr data, IntPtr userdata) =>
            {
                Account account = new Account(data);
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
        /// Retrieve an account with the account ID.
        /// </summary>
        /// <param name="accountId"> The account Id to be searched.</param>
        /// <returns>Account instance with reference to the given id.</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <exception cref="InvalidOperationException">In case of any DB error or record not found for given account id</exception>
        /// <exception cref="ArgumentException"> In case of invalid parameter</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        public static Account GetAccountById(int accountId)
        {
            Account account = Account.CreateAccount();
            IntPtr handle = account.Handle;
            AccountError res = (AccountError)Interop.AccountService.QueryAccountById(accountId, out handle);
            if (res != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(res, "Failed to get accounts from the database for account id: " + accountId);
            }

            account.Handle = handle;
            return account;
        }

        /// <summary>
        /// Retrieves all AccountProviders details from the account database.
        /// </summary>
        /// <returns>List of AccountProviders</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <exception cref="InvalidOperationException">In case of any DB error</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        public static IEnumerable<AccountProvider> GetAccountProviders()
        {
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
        /// Retrieves the account provider information with application Id.
        /// </summary>
        /// <param name="appId">Application Id.</param>
        /// <returns>The AccountProvider instance associated with the given application Id.</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <exception cref="InvalidOperationException">In case of any DB error or record not found for given appid</exception>
        /// <exception cref="ArgumentException"> In case of invalid parameter</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        public static AccountProvider GetAccountProviderByAppId(string appId)
        {
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
        /// <param name="feature">The capability value to search for account providers.</param>
        /// <returns>Retrieves AccountProviders information with the capability name.</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <exception cref="InvalidOperationException">In case of any DB error or record not found for given feature</exception>
        /// <exception cref="ArgumentException"> In case of invalid parameter</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        public static IEnumerable<AccountProvider> GetAccountProvidersByFeature(string feature)
        {
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
        /// Inserts into the Database with the new account Infomration.
        /// </summary>
        /// <param name="account">New Account instance to be added.</param>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <privilege>http://tizen.org/privilege/account.write </privilege>
        /// <exception cref="InvalidOperationException">In case of any DB error</exception>
        /// <exception cref="ArgumentException"> In case of invalid parameter</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="OutOfMemoryException"> In case of OutOfMemory error.</exception>
        public static int AddAccount(Account account)
        {
            if (account == null)
            {
                throw AccountErrorFactory.CreateException(AccountError.InvalidParameter, "Failed to AddAccount");
            }

            int id = -1;
            AccountError err = (AccountError)Interop.AccountService.AddAccount(account.Handle, out id);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to AddAccount");
            }

            return id;
        }

        /// <summary>
        /// Updates the account details to the account database.
        /// </summary>
        /// <param name="account">account instance to be updated.</param>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <privilege>http://tizen.org/privilege/account.write </privilege>
        /// <exception cref="InvalidOperationException">In case of any DB error </exception>
        /// <exception cref="ArgumentException"> In case of invalid parameter</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        /// <exception cref="OutOfMemoryException"> In case of OutOfMemory error.</exception>
        public static void UpdateAccount(Account account)
        {
            if (account == null)
            {
                throw AccountErrorFactory.CreateException(AccountError.InvalidParameter, "Failed to UpdateAccount");
            }

            AccountError err = (AccountError)Interop.AccountService.UpdateAccountToDBById(account.Handle, account.AccountId);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to UpdateAccount");
            }
        }

        /// <summary>
        /// Deletes the account information from the Database.
        /// </summary>
        /// <param name="account">Account instance to be deleted from the database.</param>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <privilege>http://tizen.org/privilege/account.write </privilege>
        /// <exception cref="InvalidOperationException">In case of any DB error </exception>
        /// <exception cref="ArgumentException"> In case of invalid parameter</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        public static void DeleteAccount(Account account)
        {
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
        /// Deletes an account from the account database by user name.
        /// </summary>
        /// <param name="userName">The user name of the account to delete.</param>
        /// <param name="packageName">The package name of the account to delete.</param>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <privilege>http://tizen.org/privilege/account.write </privilege>
        /// <exception cref="InvalidOperationException">In case of any DB error</exception>
        /// <exception cref="ArgumentException"> In case of invalid parameter</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        public static void DeleteAccount(string userName, string packageName)
        {
            AccountError err = (AccountError)Interop.AccountService.DeleteAccountByUser(userName, packageName);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to delete the account by userName: " + userName);
            }
        }

        /// <summary>
        /// Deletes an account from the account database by package name.
        /// </summary>
        /// <param name="packageName">The package name of the account to delete.</param>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <privilege>http://tizen.org/privilege/account.write </privilege>
        /// <exception cref="InvalidOperationException">In case of any DB error</exception>
        /// <exception cref="ArgumentException"> In case of invalid parameter</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        public static void DeleteAccount(string packageName)
        {
            AccountError err = (AccountError)Interop.AccountService.DeleteAccountByPackage(packageName);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to delete the account by package name: " + packageName);
            }

        }

        /// <summary>
        /// Retrieves all accounts with the given user name.
        /// </summary>
        /// <param name="userName">The user name to search .</param>
        /// <returns>Accounts list matched with the user name</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <exception cref="InvalidOperationException">In case of any DB error or record not found for given username</exception>
        /// <exception cref="ArgumentException"> In case of invalid parameter</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        public static IEnumerable<Account> GetAccountsByUserName(string userName)
        {
            List<Account> accounts = new List<Account>();
            List<int> values = new List<int>();
            Interop.Account.AccountCallback accountCallback = (IntPtr handle, IntPtr data) =>
            {
                Account account = new Account(handle);
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
        /// Retrieves all accounts with the given package name.
        /// </summary>
        /// <param name="packageName"> The package name to Search</param>
        /// <returns>Accounts list matched with the package name</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <exception cref="InvalidOperationException">In case of any DB error or record not found for given package name</exception>
        /// <exception cref="ArgumentException"> In case of invalid parameter</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        public static IEnumerable<Account> GetAccountsByPackageName(string packageName)
        {
            List<Account> accounts = new List<Account>();
            List<int> values = new List<int>();
            Interop.Account.AccountCallback accountCallback = (IntPtr handle, IntPtr data) =>
            {
                Account account = new Account(handle);
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
        /// Retrieves all accounts with the given cpability type.
        /// </summary>
        /// <param name="type"> Capability type</param>
        /// <returns>Accounts list matched with the capability type</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <exception cref="InvalidOperationException">In case of any DB error or record not found for given capability type</exception>
        /// <exception cref="ArgumentException"> In case of invalid parameter</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        public static IEnumerable<Account> GetAccountsByCapabilityType(string type)
        {
            List<Account> accounts = new List<Account>();
            List<int> values = new List<int>();
            Interop.Account.AccountCallback accountCallback = (IntPtr handle, IntPtr data) =>
            {
                Account account = new Account(handle);
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
        /// Retrieves all capabilities with the given account
        /// </summary>
        /// <param name="accountId">account instance</param>
        /// <returns>Capabilities list as Dictionary of Capability type and State.</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <exception cref="InvalidOperationException">In case of any DB error or record not found for given account id</exception>
        /// <exception cref="ArgumentException"> In case of invalid parameter</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        public static Dictionary<string, CapabilityState> GetCapabilitiesById(int accountId)
        {
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
        /// <returns>The number of accounts in the database</returns>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <exception cref="InvalidOperationException">In case of any DB error </exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        public static int GetAccountsCount()
        {
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
        /// <param name="account"> Account for which sync status needs to be updated</param>
        /// <param name="status">Sync State</param>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <privilege>http://tizen.org/privilege/account.write</privilege>
        /// <exception cref="InvalidOperationException">In case of any DB error </exception>
        /// <exception cref="ArgumentException"> In case of invalid parameter</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        public static void UpdateSyncStatusById(Account account, AccountSyncState status)
        {
            AccountError err = (AccountError)Interop.AccountService.UpdateAccountSyncStatusById(account.AccountId, (int)status);
            if (err != AccountError.None)
            {
                throw AccountErrorFactory.CreateException(err, "Failed to UpdateSyncStatusById");
            }
        }

        private static readonly Interop.AccountService.SubscribeCallback s_accountUpdatedCallback = (string eventType, int accountId, IntPtr userData) =>
        {
            AccountSucriberEventArgs eventArgs = new AccountSucriberEventArgs(eventType, accountId);
            s_accountUpdated?.Invoke(null, eventArgs);
            return true;
        };

        private static Interop.AccountService.SafeAccountSubscriberHandle s_subscriberHandle;

        private static event EventHandler<AccountSucriberEventArgs> s_accountUpdated;
        /// <summary>
        /// ContentUpdated event is triggered when the media item info from DB changes.
        /// </summary>
        /// <remarks>
        /// ContentUpdate event is triggered if the MediaInformaion updated/deleted or new Inforamtion is Inserted.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e">A ContentUpdatedEventArgs object that contains information about the update operation.</param>
        /// <privilege>http://tizen.org/privilege/account.read</privilege>
        /// <exception cref="InvalidOperationException">In case of any DB error </exception>
        /// <exception cref="ArgumentException"> In case of invalid parameter</exception>
        /// <exception cref="UnauthorizedAccessException"> In case of privilege not defined.</exception>
        public static event EventHandler<AccountSucriberEventArgs> AccountUpdated
        {
            add
            {
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
                s_accountUpdated -= value;
                if (s_accountUpdated == null)
                {
                    AccountError ret = (AccountError)Interop.AccountService.UnregisterSubscriber(s_subscriberHandle);
                    if (ret != AccountError.None)
                    {
                        throw AccountErrorFactory.CreateException(ret, "Error in callback handling");
                    }
                }
            }
        }

    }
}
