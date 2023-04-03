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
    /// <since_tizen> 11 </since_tizen>
    public class TransactionGuard : IDisposable
    {
        private Tdbc.Statement _stmt;
        private bool _commited;

        /// <summary>
        /// The boolean variable if the transact operation enabled.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public bool Enable { get; set; }

        /// <summary>
        /// The constructor of TransactionGuard class.
        /// </summary>
        /// <param name="stmt"></param>
        /// <param name="enable"></param>
        /// <since_tizen> 11 </since_tizen>
        public TransactionGuard(Tdbc.Statement stmt, bool enable = true)
        {
            _stmt = stmt;
            Enable = enable;
            if (!Enable)
                return;
            _stmt.Execute(new Sql("BEGIN DEFERRED"));
        }

        /// <summary>
        /// Dispose the object. Rollback the transaction.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public void Dispose()
        {
            if (!Enable)
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
            if (!Enable)
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
