using System;
using System.Collections.Generic;

namespace Tizen.Security.SecureRepository
{
    /// <summary>
    /// This class provides the methods storing and retrieving data.
    /// </summary>
    public class DataManager : Manager
    {
        /// <summary>
        /// Gets data from secure repository.
        /// </summary>
        /// <param name="alias">The name of a certificate to retrieve.</param>
        /// <param name="password">The password used in decrypting a data value.
        /// If password of policy is provided in SaveData(), the same password should be provided
        /// </param>
        /// <returns>data specified by alias.</returns>
        static public byte[] GetData(string alias, string password)
        {
            IntPtr ptr = new IntPtr();

            int ret = Interop.CkmcManager.CkmcGetData(alias, password, out ptr);
            Interop.KeyManagerExceptionFactory.CheckNThrowException(ret, "Failed to get certificate. alias=" + alias);

            return new SafeRawBufferHandle(ptr).Data;
        }

        /// <summary>
        /// Gets all alias of data which the client can access.
        /// </summary>
        /// <returns>all alias of data which the client can access.</returns>
        static public IEnumerable<string> GetDataAliases()
        {
            IntPtr ptr = new IntPtr();
            int ret = Interop.CkmcManager.CkmcGetDataAliasList(out ptr);
            Interop.KeyManagerExceptionFactory.CheckNThrowException(ret, "Failed to get data aliases");

            return new SafeAliasListHandle(ptr).Aliases;
        }

        /// <summary>
        /// Stores data inside secure repository based on the provided policy.
        /// </summary>
        /// <param name="alias">The name of data to be stored.</param>
        /// <param name="data">The binary value to be stored.</param>
        /// <param name="policy">The policy about how to store data securely.</param>
        static public void SaveData(string alias, byte[] data, Policy policy)
        {
            Interop.CkmcRawBuffer rawBuff = new Interop.CkmcRawBuffer(new PinnedObject(data), data.Length);

            int ret = Interop.CkmcManager.CkmcSaveData(alias, rawBuff, policy.ToCkmcPolicy());
            Interop.KeyManagerExceptionFactory.CheckNThrowException(ret, "Failed to save data. alias=" + alias);
        }
    }
}
