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
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Tizen.AIAvatar
{
    internal class RestClient : IRestClient, IDisposable
    {
        private readonly HttpClient client;

        internal RestClient(HttpClient httpClient)
        {
            client = httpClient;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public async Task<string> SendRequestAsync(HttpMethod method, string endpoint, string bearerToken = null, string jsonData = null)
        {
            AddBearerToken(bearerToken);

            HttpRequestMessage request = new HttpRequestMessage(method, endpoint);

            if (jsonData != null)
            {
                request.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            }

            HttpResponseMessage response = await client.SendAsync(request);
            request?.Dispose();
            return await HandleResponse(response);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            client.Dispose();
        }

        private void AddBearerToken(string bearerToken)
        {
            if (!string.IsNullOrEmpty(bearerToken))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            }
        }

        private async Task<string> HandleResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");
            }
        }
    }
}
