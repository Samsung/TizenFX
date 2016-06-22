/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System.Collections.Generic;

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// Class represnets a lite resource.
    /// </summary>
    public class LiteResource : Resource
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="uri">The uri path of the lite resource</param>
        /// <param name="types">Resource type</param>
        /// <param name="policy">Policy of the resource</param>
        /// <param name="attribs">Optional attributes of the resource</param>
        public LiteResource(string uri, ResourceTypes types, ResourcePolicy policy, Attributes attribs = null)
            : base(uri, types, new ResourceInterfaces(new string[] { ResourceInterfaces.DefaultInterface }), policy)
        {
            Attributes = attribs;
        }

        /// <summary>
        /// The attributes of the lite resource
        /// </summary>
        public Attributes Attributes { get; set; }

        /// <summary>
        /// The method to accept post request
        /// </summary>
        /// <param name="attribs">The new attributes of the lite resource</param>
        /// <returns>true to accept post request, false to reject it</returns>
        protected virtual bool OnPost(Attributes attribs)
        {
            return true;
        }

        /// <summary>
        /// Called on the get event.
        /// </summary>
        /// <param name="request">Request.</param>
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
        /// Called on the put event.
        /// </summary>
        /// <param name="request">Request.</param>
        protected sealed override Response OnPut(Request request)
        {
            Response response = new Response();
            response.Result = ResponseCode.Forbidden;
            return response;
        }

        /// <summary>
        /// Called on the post event.
        /// </summary>
        /// <param name="request">Request.</param>
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
        /// Called on the delete event.
        /// </summary>
        /// <param name="request">Request.</param>
        protected sealed override Response OnDelete(Request request)
        {
            Response response = new Response();
            response.Result = ResponseCode.Forbidden;
            return response;
        }

        /// <summary>
        /// Called on the observing event.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="observerType">Observer type</param>
        /// <param name="observeId">Observe identifier.</param>
        protected sealed override bool OnObserving(Request request, ObserveType observeType, int observeId)
        {
            return true;
        }
    }
}
