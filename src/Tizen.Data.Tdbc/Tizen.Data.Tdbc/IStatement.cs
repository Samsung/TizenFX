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
using System.Threading.Tasks;

namespace Tizen.Data.Tdbc
{
    /// <summary>
    /// TDBC interface for representing statement.
    /// </summary>
    /// <since_tizen> 11 </since_tizen>
    public interface IStatement : IDisposable
    {
        /// <summary>
        /// Executes the given Sql.
        /// </summary>
        /// <param name="sql">The sql to execute.</param>
        /// <returns>The ResultSet object that includes the result of the query.</returns>
        /// <since_tizen> 11 </since_tizen>
        IResultSet ExecuteQuery(Sql sql);

        /// <summary>
        /// Executes the given Sql.
        /// </summary>
        /// <param name="sql">The sql to execute.</param>
        /// <returns>The number of rows updated.</returns>
        /// <since_tizen> 11 </since_tizen>
        int ExecuteUpdate(Sql sql);

        /// <summary>
        /// Executes the given Sql.
        /// </summary>
        /// <param name="sql">The sql to execute.</param>
        /// <returns>True if the execution was success, otherwise false.</returns>
        /// <since_tizen> 11 </since_tizen>
        bool Execute(Sql sql);

        /// <summary>
        /// Executes the given Sql asynchronously.
        /// </summary>
        /// <param name="sql">The sql to execute.</param>
        /// <returns>The ResultSet object that includes the result of the query.</returns>
        /// <since_tizen> 11 </since_tizen>
        Task<IResultSet> ExecuteQueryAsync(Sql sql);

        /// <summary>
        /// Executes the given Sql asynchronously.
        /// </summary>
        /// <param name="sql">The sql to execute.</param>
        /// <returns>The number of rows updated.</returns>
        /// <since_tizen> 11 </since_tizen>
        Task<int> ExecuteUpdateAsync(Sql sql);

        /// <summary>
        /// Executes the given Sql asynchronously.
        /// </summary>
        /// <param name="sql">The sql to execute.</param>
        /// <returns>True if the execution was success, otherwise false.</returns>
        /// <since_tizen> 11 </since_tizen>
        Task<bool> ExecuteAsync(Sql sql);
    }
}
