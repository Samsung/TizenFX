/*
 * Copyright (c) 2023 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Data.Tdbc
{
    /// <summary>
    /// This class helps the operation of the statement in a transacted way.
    /// </summary>
    /// <remarks>To finish the transaction, either call Commit() to apply database operations or Dispose() to rollback the transaction.</remarks>
    /// <example>Usage:
    /// <code>
    /// using (var transaction = new TransationGuard(statement)) {
    ///     ...
    ///     transaction.Commit();
    /// }
    /// </code>
    /// </example>
    /// <since_tizen> 11 </since_tizen>
    public class TransactionGuard : IDisposable
    {
        private IStatement _stmt;
        private bool _commited;

        /// <summary>
        /// The flag representing whether the TransactionGuard is enabled.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// The constructor of TransactionGuard class.
        /// </summary>
        /// <param name="statement"></param>
        /// <param name="isEnabled"></param>
        /// <since_tizen> 11 </since_tizen>
        public TransactionGuard(IStatement statement, bool isEnabled = true)
        {
            _stmt = statement;
            IsEnabled = isEnabled;
            if (!IsEnabled)
                return;
            _stmt.Execute(new Sql("BEGIN DEFERRED"));
        }

        /// <summary>
        /// Dispose the object. Rollback the transaction.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public void Dispose()
        {
            if (!IsEnabled)
                return;
            if (_commited)
                return;
            _stmt.Execute(new Sql("ROLLBACK"));
        }

        /// <summary>
        /// Commit the transaction.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public void Commit()
        {
            if (!IsEnabled)
                return;
            if (_commited)
                return;
            if (!_stmt.Execute(new Sql("COMMIT")))
            {
                _stmt.Execute(new Sql("ROLLBACK"));
            }
            _commited = true;
        }
    }
}
