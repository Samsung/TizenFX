 /*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.ComponentModel;

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// This class represents a lite resource.
    /// It provides APIs to encapsulate resources.
    /// This class is accessed by using a constructor to create a new instance of this object.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API level 13")]
    public class LiteResource : Resource
    {
        /// <summary>
        /// The LiteResource constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// <para>Creates a lite resource, which can then be registered in server using <see cref="IoTConnectivityServerManager.RegisterResource(Resource)"/>.</para>
        /// <para>When client requests some operations, it sends a response to client automatically.</para>
        /// <para><paramref name="uri" /> length must be less than 128.</para>
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privlevel>public</privlevel>
        /// <param name="uri">The uri path of the lite resource.</param>
        /// <param name="types">The type of the resource.</param>
        /// <param name="policy">Policy of the resource.</param>
        /// <param name="attribs">Optional attributes of the resource.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <pre>
        /// IoTConnectivityServerManager.Initialize() should be called to initialize.
        /// </pre>
        /// <seealso cref="ResourceTypes"/>
        /// <seealso cref="ResourcePolicy"/>
        /// <seealso cref="Attributes"/>
        /// <example><code><![CDATA[
        /// List<string> list = new List<string>() { "org.tizen.light" };
        /// Attributes attributes = new Attributes() {
        ///     { "state", "ON" }
        /// };
        /// LiteResource res = new LiteResource("/light/1", new ResourceTypes(list), ResourcePolicy.Discoverable, attributes);
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public LiteResource(string uri, ResourceTypes types, ResourcePolicy policy, Attributes attribs = null)
            : base(uri, types, new ResourceInterfaces(new string[] { ResourceInterfaces.DefaultInterface }), policy)
        {
            Attributes = attribs;
        }

        /// <summary>
        /// Gets or sets the attributes of the lite resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The attributes of the lite resource.</value>
        /// <example><code><![CDATA[
        /// List<string> list = new List<string>() { "org.tizen.light" };
        /// LiteResource res = new LiteResource("/light/1", new ResourceTypes(list), ResourcePolicy.Discoverable);
        /// Attributes attributes = new Attributes() {
        ///     { "state", "ON" }
        /// };
        /// res.Attributes = newAttributes;
        /// foreach (KeyValuePair<string, object> pair in res.Attributes)
        /// {
        ///     Console.WriteLine("key : {0}, value : {1}", pair.Key, pair.Value);
        /// }
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public Attributes Attributes { get; set; }

        /// <summary>
        /// Decides whether to accept or reject a post request.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// Child classes of this class can override this method to accept or reject post request.
        /// </remarks>
        /// <param name="attribs">The new attributes of the lite resource.</param>
        /// <returns>true to accept post request, false to reject it.</returns>
        /// <example><code>
        /// public class MyLightResource : LiteResource
        /// {
        ///     protected override bool OnPost(Attributes attributes)
        ///     {
        ///         object newAttributes;
        ///         attributes.TryGetValue("LIGHT_ATTRIBUTE", out newAttributes);
        ///         if((int)newAttributes == 1)
        ///             return true;
        ///         return false;
        ///     }
        /// }
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        protected virtual bool OnPost(Attributes attribs)
        {
            return true;
        }

        /// <summary>
        /// This is called when the client performs get operation on this resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="request">A request from client.</param>
        /// <returns>A response having the representation and the result.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Deprecated since API level 13")]
        protected sealed override Response OnGet(Request request)
        {
            Representation representation = new Representation()
            {
                UriPath = UriPath,
                Interface = Interfaces,
                Type = Types,
                Attributes = Attributes
            };

            Response response = new Response()
            {
                Representation = representation,
                Result = ResponseCode.Ok
            };

            return response;
        }

        /// <summary>
        /// This is called when the client performs put operation on this resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="request">A request from client.</param>
        /// <returns>A response.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected sealed override Response OnPut(Request request)
        {
            Response response = new Response();
            response.Result = ResponseCode.Forbidden;
            return response;
        }

        /// <summary>
        /// This is called when the client performs post operation on this resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="request">A request from client.</param>
        /// <returns>A response having the representation and the result.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected sealed override Response OnPost(Request request)
        {
            if (OnPost(request.Representation.Attributes))
            {
                Attributes = request.Representation.Attributes;
                Representation representation = new Representation() {
                    UriPath = UriPath,
                    Interface = Interfaces,
                    Type = Types,
                    Attributes = Attributes
                };

                Response response = new Response() {
                    Representation = representation,
                    Result = ResponseCode.Ok
                };

                Notify(representation, QualityOfService.High);
                return response;
            }

            return new Response()
            {
                Result = ResponseCode.Error
            };
        }

        /// <summary>
        /// This is called when the client performs delete operation on this resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="request">A request from client.</param>
        /// <returns>A response.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected sealed override Response OnDelete(Request request)
        {
            Response response = new Response();
            response.Result = ResponseCode.Forbidden;
            return response;
        }

        /// <summary>
        /// Called on the observing event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="request">A request from client.</param>
        /// <param name="observeType">Observer type.</param>
        /// <param name="observeId">Observe identifier.</param>
        /// <returns>Returns true.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected sealed override bool OnObserving(Request request, ObserveType observeType, int observeId)
        {
            return true;
        }
    }
}
