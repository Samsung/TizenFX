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


namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// This class represents a lite resource.
    /// It provides APIs to encapsulate resources.
    /// This class is accessed by using a constructor to create a new instance of this object.
    /// </summary>
    public class LiteResource : Resource
    {
        /// <summary>
        /// The LiteResource constructor
        /// </summary>
        /// <remarks>
        /// Creates a lite resource which can then be registered in server using <see cref="IoTConnectivityServerManager.RegisterResource()"/>.\n
        /// When client requests some operations, it send a response to client, automatically.\n
        /// @a uri length must be less than 128.
        /// </remarks>
        /// <privilege>
        /// http://tizen.org/privilege/internet
        /// </privilege>
        /// <param name="uri">The uri path of the lite resource</param>
        /// <param name="types">The type of the resource</param>
        /// <param name="policy">Policy of the resource</param>
        /// <param name="attribs">Optional attributes of the resource</param>
        /// <pre>
        /// IoTConnectivityServerManager.Initialize() should be called to initialize
        /// </pre>
        /// <seealso cref="ResourceTypes"/>
        /// <seealso cref="ResourcePolicy"/>
        /// <seealso cref="Attributes"/>
        /// <code>
        /// List<string> list = new List<string>() { "org.tizen.light" };
        /// Attributes attributes = new Attributes() {
        ///     { "state", "ON" }
        /// };
        /// LiteResource res = new LiteResource("/light/1", new ResourceTypes(list), ResourcePolicy.Discoverable, attributes);
        /// </code>
        public LiteResource(string uri, ResourceTypes types, ResourcePolicy policy, Attributes attribs = null)
            : base(uri, types, new ResourceInterfaces(new string[] { ResourceInterfaces.DefaultInterface }), policy)
        {
            Attributes = attribs;
        }

        /// <summary>
        /// Gets or sets the attributes of the lite resource
        /// </summary>
        /// <code>
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
        /// </code>
        public Attributes Attributes { get; set; }

        /// <summary>
        /// Decides whether to accept or reject a post request.
        /// </summary>
        /// <remarks>
        /// Child classes of this class can override this method to accept or reject post request.
        /// </remarks>
        /// <param name="attribs">The new attributes of the lite resource</param>
        /// <returns>true to accept post request, false to reject it</returns>
        /// <code>
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
        /// </code>
        protected virtual bool OnPost(Attributes attribs)
        {
            return true;
        }

        // The code block untill @endcond should not appear in doxygen spec.
        /// @cond
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

        protected sealed override Response OnPut(Request request)
        {
            Response response = new Response();
            response.Result = ResponseCode.Forbidden;
            return response;
        }

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

        protected sealed override Response OnDelete(Request request)
        {
            Response response = new Response();
            response.Result = ResponseCode.Forbidden;
            return response;
        }

        protected sealed override bool OnObserving(Request request, ObserveType observeType, int observeId)
        {
            return true;
        }
        /// @endcond
    }
}
