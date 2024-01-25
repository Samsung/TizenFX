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
using System.Collections.Generic;

namespace Tizen.Data.Tdbc
{
    /// <summary>
    /// Represents a SQL query string.
    /// </summary>
    /// <since_tizen> 11 </since_tizen>
    public class Sql
    {
        private string _sql;
        private Dictionary<string, Object> _bindings = new Dictionary<string, Object>();

        /// <summary>
        /// The SQL command string.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public string Command
        {
            get => _sql;
        }

        /// <summary>
        /// The bindings as a name to value Dictionary.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public IReadOnlyDictionary<string, Object> Bindings
        {
            get => _bindings;
        }

        /// <summary>
        /// The constructor of Sql class.
        /// </summary>
        /// <param name="sql">The string of the query.</param>
        /// <since_tizen> 11 </since_tizen>
        public Sql(string sql)
        {
            _sql = sql;
        }

        /// <summary>
        /// Binds the variable to the parameter.
        /// </summary>
        /// <param name="key">The key of the parameter.</param>
        /// <param name="val">The string type value to bind.</param>
        /// <returns>The sql object itself.</returns>
        /// <since_tizen> 11 </since_tizen>
        public Sql Bind(string key, string val)
        {
            _bindings.Add(key, val);
            return this;
        }

        /// <summary>
        /// Binds the variable to the parameter.
        /// </summary>
        /// <param name="key">The key of the parameter.</param>
        /// <param name="val">The integer type value to bind.</param>
        /// <returns>The sql object itself.</returns>
        /// <since_tizen> 11 </since_tizen>
        public Sql Bind(string key, int val)
        {
            _bindings.Add(key, val);
            return this;
        }

        /// <summary>
        /// Binds the variable to the parameter.
        /// </summary>
        /// <param name="key">The key of the parameter.</param>
        /// <param name="val">The double type value to bind.</param>
        /// <returns>The sql object itself.</returns>
        /// <since_tizen> 11 </since_tizen>
        public Sql Bind(string key, double val)
        {
            _bindings.Add(key, val);
            return this;
        }

        /// <summary>
        /// Binds the variable to the parameter.
        /// </summary>
        /// <param name="key">The key of the parameter.</param>
        /// <param name="val">The boolean type value to bind.</param>
        /// <returns>The sql object itself.</returns>
        /// <since_tizen> 11 </since_tizen>
        public Sql Bind(string key, bool val)
        {
            _bindings.Add(key, val);
            return this;
        }

        /// <summary>
        /// Binds the variable to the parameter.
        /// </summary>
        /// <param name="key">The key of the parameter.</param>
        /// <param name="val">The byte type value to bind.</param>
        /// <returns>The sql object itself.</returns>
        /// <since_tizen> 11 </since_tizen>
        public Sql Bind(string key, byte[] val)
        {
            _bindings.Add(key, val);
            return this;
        }
    }
}
