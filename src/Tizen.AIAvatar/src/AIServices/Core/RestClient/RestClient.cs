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
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;


namespace Tizen.AIAvatar
{
    /// <summary>
    /// A class that provides methods to execute REST requests and handle responses.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RestClient : IRestClient, IDisposable
    {
        private readonly HttpClient _httpClient;
        private bool _disposed = false;

        /// <summary>
        /// Initializes a new instance of the RestClient class with the specified HttpClient.
        /// </summary>
        /// <param name="httpClient">The HttpClient instance to use for sending HTTP requests.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RestClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Executes a REST request asynchronously and returns the response.
        /// </summary>
        /// <param name="request">The RestRequest object containing details of the request.</param>
        /// <returns>A RestResponse object representing the result of the request.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the request execution.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public async Task<RestResponse> ExecuteAsync(RestRequest request)
        {
            using var httpRequest = request?.CreateRequestMessage(_httpClient.BaseAddress);

            try
            {
                using var httpResponse = await _httpClient.SendAsync(httpRequest);
                var response = new RestResponse
                {
                    StatusCode = httpResponse.StatusCode,
                    IsSuccessful = httpResponse.IsSuccessStatusCode
                };

                if (httpResponse.Content != null)
                {
                    response.RawBytes = await httpResponse.Content.ReadAsByteArrayAsync();
                    response.Content = await httpResponse.Content.ReadAsStringAsync();
                }

                if (!httpResponse.IsSuccessStatusCode)

                {
                    response.ErrorMessage = $"HTTP {(int)httpResponse.StatusCode} - {httpResponse.ReasonPhrase}";
                }

                return response;
            }
            catch (Exception ex)
            {
                return new RestResponse
                {
                    IsSuccessful = false,
                    ErrorMessage = ex.Message
                };
            }
        }

        /// <summary>
        /// Disposes of the resources used by the RestClient.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes of the resources used by the RestClient.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _httpClient.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
