/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;

namespace Tizen.AIAvatar
{
    /// <summary>
    /// Manages REST clients for different endpoints based on the AI service configuration.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ServiceClientManager : IDisposable
    {
        private readonly Dictionary<string, IRestClient> _clients = new();
        private readonly AIServiceConfiguration _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceClientManager"/> class.
        /// </summary>
        /// <param name="config">The AI service configuration.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ServiceClientManager(AIServiceConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Retrieves or creates a REST client for the specified endpoint.
        /// </summary>
        /// <param name="endpoint">The base URI of the endpoint.</param>
        /// <returns>The REST client for the specified endpoint.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IRestClient GetClient(string endpoint)
        {
            if (!_clients.ContainsKey(endpoint))
            {
                var httpClient = new HttpClient { BaseAddress = new Uri(endpoint) };
                var client = new RestClient(httpClient);
                _clients[endpoint] = client;
            }
            return _clients[endpoint];
        }

        /// <summary>
        /// Releases all resources used by the <see cref="ServiceClientManager"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            foreach (var client in _clients.Values)
            {
                client?.Dispose();
            }
            _clients.Clear();
        }
    }
}