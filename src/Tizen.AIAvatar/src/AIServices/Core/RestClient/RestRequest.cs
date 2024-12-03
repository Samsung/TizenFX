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

using System.Text.Json;
using System.Text;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel;

namespace Tizen.AIAvatar
{
    /// <summary>
    /// An enumeration representing various HTTP methods.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum Method
    {
        /// <summary>
        /// Represents the HTTP GET method.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Get,

        /// <summary>
        /// Represents the HTTP POST method.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Post,

        /// <summary>
        /// Represents the HTTP PUT method.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Put,

        /// <summary>
        /// Represents the HTTP DELETE method.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Delete,

        /// <summary>
        /// Represents the HTTP PATCH method.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Patch
    }

    /// <summary>
    /// Represents a RESTful API request.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RestRequest
    {
        /// <summary>
        /// Initializes a new instance of the RestRequest class with the specified HTTP method.
        /// </summary>
        /// <param name="method">The HTTP method to use for the request.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RestRequest(Method method)
        {
            Resource = string.Empty;
            Method = method;
            _headers = new Dictionary<string, string>();
        }

        /// <summary>
        /// Initializes a new instance of the RestRequest class with the specified resource and HTTP method.
        /// </summary>
        /// <param name="resource">The resource URI for the request.</param>
        /// <param name="method">The HTTP method to use for the request.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RestRequest(string resource, Method method)
        {
            Resource = resource;
            Method = method;
            _headers = new Dictionary<string, string>();
        }

        /// <summary>
        /// Adds a header to the request.
        /// </summary>
        /// <param name="name">The name of the header.</param>
        /// <param name="value">The value of the header.</param>
        /// <returns>The current instance of RestRequest.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RestRequest AddHeader(string name, string value)
        {
            _headers[name] = value;
            return this;
        }

        /// <summary>
        /// Adds a JSON body to the request.
        /// </summary>
        /// <param name="body">The object to serialize as JSON and include in the request body.</param>
        /// <returns>The current instance of RestRequest.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RestRequest AddJsonBody(object body)
        {
            _body = body;
            _jsonStringBody = null; // Clear json string if object body is set
            if (!_headers.ContainsKey("Content-Type"))
            {
                _headers["Content-Type"] = "application/json";
            }
            return this;
        }

        /// <summary>
        /// Adds a JSON string body to the request.
        /// </summary>
        /// <param name="jsonString">The JSON string to include in the request body.</param>
        /// <returns>The current instance of RestRequest.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RestRequest AddJsonStringBody(string jsonString)
        {
            _jsonStringBody = jsonString;
            _body = null; // Clear object body if json string is set
            if (!_headers.ContainsKey("Content-Type"))
            {
                _headers["Content-Type"] = "application/json";
            }
            return this;
        }

        /// <summary>
        /// The resource URI for the request.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Resource { get; }

        /// <summary>
        /// The HTTP method to use for the request.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Method Method { get; }

        /// <summary>
        /// Creates an HttpRequestMessage based on the current RestRequest instance.
        /// </summary>
        /// <param name="baseAddress">The base address to use when constructing the request URI.</param>
        /// <returns>A new HttpRequestMessage representing the current RestRequest.</returns>
        internal HttpRequestMessage CreateRequestMessage(Uri baseAddress)
        {
            // If Resource is empty, use only the baseAddress
            var requestUri = string.IsNullOrEmpty(Resource) ? baseAddress : new Uri(baseAddress, Resource);

            var request = new HttpRequestMessage(GetHttpMethod(), requestUri);

            foreach (var header in _headers)
            {
                request.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            if (_jsonStringBody != null)
            {
                request.Content = new StringContent(_jsonStringBody, Encoding.UTF8, "application/json");
            }
            else if (_body != null)
            {
                var jsonBody = JsonSerializer.Serialize(_body, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
                request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            }

            return request;
        }

        /// <summary>
        /// Gets the appropriate HttpMethod for the specified Method enumeration value.
        /// </summary>
        /// <returns>The corresponding HttpMethod.</returns>
        private HttpMethod GetHttpMethod()
        {
            return Method switch
            {
                Method.Get => HttpMethod.Get,
                Method.Post => HttpMethod.Post,
                Method.Put => HttpMethod.Put,
                Method.Delete => HttpMethod.Delete,
                Method.Patch => HttpMethod.Patch,
                _ => throw new ArgumentException($"Unsupported HTTP method: {Method}")
            };
        }

       

        /// <summary>
        /// A dictionary containing the headers for the request.
        /// </summary>
        private readonly Dictionary<string, string> _headers;

        /// <summary>
        /// The object to serialize as JSON and include in the request body.
        /// </summary>
        private object _body;

        /// <summary>
        /// The JSON string to include in the request body.
        /// </summary>
        private string _jsonStringBody;
    }
}