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
using System.Net;
using System.Threading.Tasks;

namespace Tizen.AIAvatar
{

    /// <summary>
    /// Represents the response from a REST API call, containing information such as status, content, and potential error messages.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RestResponse
    {
        /// <summary>
        /// Indicates whether the request was successful.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// The HTTP status code returned by the server, providing information about the response status.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// The content of the response as a string, typically containing the body of the HTTP response.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Content { get; set; }

        /// <summary>
        /// The raw bytes of the response, which can be useful for handling non-text data or binary responses.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte[] RawBytes { get; set; }

        /// <summary>
        /// The error message if the request failed, providing details about what went wrong.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ErrorMessage { get; set; }
    }

    /// <summary>
    /// Interface for making REST API calls, providing functionality to execute HTTP requests and receive responses.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRestClient : IDisposable
    {
        /// <summary>
        /// Executes a REST request asynchronously and returns the response from the server.
        /// </summary>
        /// <param name="request">The REST request to execute, containing information such as endpoint, headers, and parameters.</param>
        /// <returns>A task representing the asynchronous operation, which returns the REST response containing status, content, and any errors.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the request parameter is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<RestResponse> ExecuteAsync(RestRequest request);
    }
}