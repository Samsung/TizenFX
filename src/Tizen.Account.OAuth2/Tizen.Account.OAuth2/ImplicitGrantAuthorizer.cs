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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Tizen.Account.OAuth2
{
    /// <summary>
    /// The ImplicitGrantAuthorizer is used to obtain access tokens using Implicit Grant flow as described at https://tools.ietf.org/html/rfc6749#section-4.2
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ImplicitGrantAuthorizer : Authorizer
    {
        /// <summary>
        /// The constructor
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ImplicitGrantAuthorizer()
        {

        }

        /// <summary>
        /// Access token can be retreived implicitly using <see cref="AuthorizeAsync"/> in this flow.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">Thrown when the operation is not supported</exception>
        public Task<TokenResponse> GetAccessTokenAsync(TokenRequest request)
        {
            Log.Error(ErrorFactory.LogTag, "Obtain token directly from authorization grant ");
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Refreshing access token is not supported in this flow.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="InvalidOperationException">Thrown when the operation is not supported</exception>
        public override Task<TokenResponse> RefreshAccessTokenAsync(RefreshTokenRequest request)
        {
            Log.Error(ErrorFactory.LogTag, "Refesh token is not supported in Implicit Grant flow");
            throw new InvalidOperationException();
        }

        private TokenResponse GetAuthorizationResponse(IntPtr requestHandle)
        {
            IntPtr error = IntPtr.Zero;
            TokenResponse response = null;
            int ret = (int)OAuth2Error.None;
            Interop.Manager.Oauth2AuthGrantCallback authGrantCb = (IntPtr responseHandle, IntPtr usrData) =>
            {
                if (responseHandle == IntPtr.Zero)
                {
                    Log.Error(ErrorFactory.LogTag, "Error occured");
                    throw (new ArgumentNullException());
                }

                Interop.Response.GetError(responseHandle, out error);
                if (error != IntPtr.Zero)
                {
                    Log.Error(ErrorFactory.LogTag, "Server Error occured");
                }
                else
                {
                    IntPtr accessToken;
                    ret = Interop.Response.GetAccessToken(responseHandle, out accessToken);
                    if (ret != (int)OAuth2Error.None)
                    {
                        Log.Error(ErrorFactory.LogTag, "Interop failed");
                        throw ErrorFactory.GetException(ret);
                    }

                    IntPtr tokenType;
                    ret = Interop.Response.GetTokenType(responseHandle, out tokenType);
                    if (ret != (int)OAuth2Error.None)
                    {
                        Log.Error(ErrorFactory.LogTag, "Interop failed");
                        throw ErrorFactory.GetException(ret);
                    }

                    long expiresIn;
                    ret = Interop.Response.GetExpiresIn(responseHandle, out expiresIn);
                    if (ret != (int)OAuth2Error.None)
                    {
                        Log.Error(ErrorFactory.LogTag, "Interop failed");
                        throw ErrorFactory.GetException(ret);
                    }

                    IntPtr scope;
                    ret = Interop.Response.GetScope(responseHandle, out scope);
                    if (ret != (int)OAuth2Error.None)
                    {
                        Log.Error(ErrorFactory.LogTag, "Interop failed");
                        throw ErrorFactory.GetException(ret);
                    }

                    IntPtr state;
                    ret = Interop.Response.GetState(responseHandle, out state);
                    if (ret != (int)OAuth2Error.None)
                    {
                        Log.Error(ErrorFactory.LogTag, "Interop failed");
                        throw ErrorFactory.GetException(ret);
                    }

                    IEnumerable<string> scopes = (scope == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(scope)?.Split(' ');

                    var token = new AccessToken() { Token = Marshal.PtrToStringAnsi(accessToken), ExpiresIn = expiresIn, Scope = scopes, TokenType = Marshal.PtrToStringAnsi(tokenType) };
                    response = new TokenResponse(responseHandle) { AccessToken = token, State = Marshal.PtrToStringAnsi(state), RefreshToken = null };
                }
            };

            ret = Interop.Manager.RequestAuthorizationGrant(_managerHandle, requestHandle, authGrantCb, IntPtr.Zero);
            Interop.Request.Destroy(requestHandle);
            if (ret != (int)OAuth2Error.None || error != IntPtr.Zero)
            {
                if (error != IntPtr.Zero)
                {
                    throw ErrorFactory.GetException(error);
                }
                else
                {
                    Log.Error(ErrorFactory.LogTag, "Interop failed");
                    throw ErrorFactory.GetException(ret);
                }
            }

            return response;
        }

        // Fill device request handle for Authorization code grant
        private IntPtr GetRequestHandle(ImplicitGrantAuthorizationRequest request)
        {
            if (request == null)
            {
                Log.Error(ErrorFactory.LogTag, "Invalid request or request is null");
                throw ErrorFactory.GetException((int)OAuth2Error.InvalidParameter);
            }

            IntPtr requestHandle;
            int ret = Interop.Request.Create(out requestHandle);
            if (ret != (int)OAuth2Error.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop failed");
                throw ErrorFactory.GetException(ret);
            }

            ret = Interop.Request.SetAuthEndPointUrl(requestHandle, request.AuthorizationEndpoint.ToString());
            if (ret != (int)OAuth2Error.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop failed");
                throw ErrorFactory.GetException(ret);
            }

            ret = Interop.Request.SetResponseType(requestHandle, Interop.ResponseType.Token);
            if (ret != (int)OAuth2Error.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop failed");
                throw ErrorFactory.GetException(ret);
            }

            ret = Interop.Request.SetClientId(requestHandle, request.ClientSecrets.Id);
            if (ret != (int)OAuth2Error.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop failed");
                throw ErrorFactory.GetException(ret);
            }

            if (request.RedirectionEndPoint != null)
            {
                ret = Interop.Request.SetRedirectionUrl(requestHandle, request.RedirectionEndPoint.ToString());
                if (ret != (int)OAuth2Error.None)
                {
                    Log.Error(ErrorFactory.LogTag, "Interop failed");
                    throw ErrorFactory.GetException(ret);
                }
            }

            if (request.Scopes != null)
            {
                string scope = string.Join(" ", request.Scopes);
                ret = Interop.Request.SetScope(requestHandle, scope);
                if (ret != (int)OAuth2Error.None)
                {
                    Log.Error(ErrorFactory.LogTag, "Interop failed");
                    throw ErrorFactory.GetException(ret);
                }
            }

            if (request.State != null)
            {
                ret = Interop.Request.SetState(requestHandle, request.State);
                if (ret != (int)OAuth2Error.None)
                {
                    Log.Error(ErrorFactory.LogTag, "Interop failed");
                    throw ErrorFactory.GetException(ret);
                }
            }

            if (request.CustomData != null)
            {
                foreach (var item in request.CustomData)
                {
                    ret = Interop.Request.AddCustomData(requestHandle, item.Key, item.Value);
                    if (ret != (int)OAuth2Error.None)
                    {
                        Log.Error(ErrorFactory.LogTag, "Interop failed");
                        throw ErrorFactory.GetException(ret);
                    }
                }
            }

            return requestHandle;
        }
    }
}
