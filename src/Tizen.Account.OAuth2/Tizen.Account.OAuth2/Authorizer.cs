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
    /// An abstract class to represent various OAuth 2.0 authorization code flows.
    /// Refer to http://tools.ietf.org/html/rfc6749 about OAuth 2.0 protocols.
    /// Also service provider document needs to be referred for using end points and additional parameters.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public abstract class Authorizer : IDisposable
    {

        internal IntPtr _managerHandle;
        private bool _disposed = false;

        /// <summary>
        /// Constructor for Authoirzer instances
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Authorizer()
        {
            int ret = Interop.Manager.Create(out _managerHandle);
            if (ret != (int)OAuth2Error.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop failed");
                throw ErrorFactory.GetException(ret);
            }
        }

        /// <summary>
        /// Destructor of the Authorizer class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        ~Authorizer()
        {
            Dispose(false);
        }

        /// <summary>
        /// Indicates if the current instance is already handling an authorization request
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsRequestInProgress
        {
            get
            {
                return Interop.Manager.IsRequestInProgress(_managerHandle);
            }
        }


        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Retrieves access token using a refresh token.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="request">Request containing refresh token</param>
        /// <returns>The response containing access token.</returns>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <exception cref="ArgumentException">Thrown when method failed due to invalid argumets</exception>
        /// <exception cref="OAuth2Exception">Thrown when method fails due to server error</exception>
        public virtual async Task<TokenResponse> RefreshAccessTokenAsync(RefreshTokenRequest request)
        {
            IntPtr requestHandle = GetRequestHandle(request);
            return await Task.Run(() => GetRefreshToken(requestHandle));
        }

        private TokenResponse GetRefreshToken(IntPtr requestHandle)
        {
            int ret = (int)OAuth2Error.None;
            IntPtr error = IntPtr.Zero;
            TokenResponse response = null;
            Interop.Manager.Oauth2RefreshTokenCallback accessTokenCb = (IntPtr responseHandle, IntPtr usrData) =>
            {
                Interop.Response.GetError(responseHandle, out error);
                if (error != IntPtr.Zero)
                {
                    Log.Error(ErrorFactory.LogTag, "Error occured");
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
                        Log.Error(ErrorFactory.LogTag, "Failed to get token type");
                    }

                    long expiresIn;
                    ret = Interop.Response.GetExpiresIn(responseHandle, out expiresIn);
                    if (ret != (int)OAuth2Error.None)
                    {
                        Log.Error(ErrorFactory.LogTag, "Failed to get expires in");
                    }

                    IntPtr refreshToken;
                    ret = Interop.Response.GetRefreshToken(responseHandle, out refreshToken);
                    if (ret != (int)OAuth2Error.None)
                    {
                        Log.Error(ErrorFactory.LogTag, "Interop failed");
                        throw ErrorFactory.GetException(ret);
                    }

                    IntPtr scope;
                    ret = Interop.Response.GetScope(responseHandle, out scope);
                    if (ret != (int)OAuth2Error.None)
                    {
                        Log.Error(ErrorFactory.LogTag, "Failed to get scope");
                    }

                    IEnumerable<string> scopes = (scope == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(scope)?.Split(' ');

                    var token = new AccessToken();
                    token.Token = (accessToken == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(accessToken);
                    token.TokenType = (tokenType == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(tokenType);
                    token.Scope = scopes;
                    token.ExpiresIn = expiresIn;

                    response = new TokenResponse(responseHandle);
                    response.AccessToken = token;
                    response.RefreshToken = (refreshToken == IntPtr.Zero) ? null : new RefreshToken() { Token = Marshal.PtrToStringAnsi(refreshToken) };
                }
            };

            ret = Interop.Manager.RefreshAccessToken(_managerHandle, requestHandle, accessTokenCb, IntPtr.Zero);
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

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free managed objects
            }

            Interop.Manager.Destroy(_managerHandle);
            _disposed = true;
        }

        // Fill device request handle for refreshing access token
        internal IntPtr GetRequestHandle(RefreshTokenRequest request)
        {
            IntPtr requestHandle;
            int ret = Interop.Request.Create(out requestHandle);
            if (ret != (int)OAuth2Error.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop failed");
                throw ErrorFactory.GetException(ret);
            }

            ret = Interop.Request.SetRefreshTokenUrl(requestHandle, request.TokenEndpoint.ToString());
            if (ret != (int)OAuth2Error.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop failed");
                throw ErrorFactory.GetException(ret);
            }

            ret = Interop.Request.SetGrantType(requestHandle, Interop.GrantType.Refresh);
            if (ret != (int)OAuth2Error.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop failed");
                throw ErrorFactory.GetException(ret);
            }

            ret = Interop.Request.SetRefreshToken(requestHandle, request.RefreshToken);
            if (ret != (int)OAuth2Error.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop failed");
                throw ErrorFactory.GetException(ret);
            }

            if (request.ClientSecrets.Id != null)
            {
                ret = Interop.Request.SetClientId(requestHandle, request.ClientSecrets.Id);
                if (ret != (int)OAuth2Error.None)
                {
                    Log.Error(ErrorFactory.LogTag, "Interop failed");
                    throw ErrorFactory.GetException(ret);
                }
            }

            if (request.ClientSecrets.Secret != null)
            {
                ret = Interop.Request.SetClientSecret(requestHandle, request.ClientSecrets.Secret);
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

            ret = Interop.Request.SetClientAuthenticationType(requestHandle, (int)request.AuthenticationScheme);
            if (ret != (int)OAuth2Error.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop failed");
                throw ErrorFactory.GetException(ret);
            }

            return requestHandle;
        }

        internal TokenResponse GetAccessToken(IntPtr requestHandle)
        {
            int ret = (int)OAuth2Error.None;
            IntPtr error = IntPtr.Zero;
            TokenResponse response = null;
            Interop.Manager.Oauth2TokenCallback accessTokenCb = (IntPtr responseHandle, IntPtr usrData) =>
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
                    IntPtr accessToken = IntPtr.Zero;
                    ret = Interop.Response.GetAccessToken(responseHandle, out accessToken);
                    if (ret != (int)OAuth2Error.None)
                    {
                        Log.Error(ErrorFactory.LogTag, "Failed to get access token");
                        throw ErrorFactory.GetException(ret);
                    }

                    IntPtr tokenType;
                    ret = Interop.Response.GetTokenType(responseHandle, out tokenType);
                    if (ret != (int)OAuth2Error.None)
                    {
                        Log.Debug(ErrorFactory.LogTag, "TokenType can't be found");
                    }

                    long expiresIn = -1;
                    ret = Interop.Response.GetExpiresIn(responseHandle, out expiresIn);
                    if (ret != (int)OAuth2Error.None)
                    {
                        Log.Debug(ErrorFactory.LogTag, "ExpiresIn can't be found");
                    }

                    IntPtr refreshToken;
                    ret = Interop.Response.GetRefreshToken(responseHandle, out refreshToken);
                    if (ret != (int)OAuth2Error.None)
                    {
                        Log.Debug(ErrorFactory.LogTag, "Refresh Token can't be found");
                    }

                    IntPtr scope;
                    ret = Interop.Response.GetScope(responseHandle, out scope);
                    if (ret != (int)OAuth2Error.None)
                    {
                        Log.Debug(ErrorFactory.LogTag, "Scope can't be found");
                    }

                    IntPtr state;
                    ret = Interop.Response.GetState(responseHandle, out state);
                    if (ret != (int)OAuth2Error.None)
                    {
                        Log.Debug(ErrorFactory.LogTag, "State can't be found");
                    }

                    IEnumerable<string> scopes = (scope == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(scope)?.Split(' ');

                    var token = new AccessToken();
                    token.Token = (accessToken == IntPtr.Zero)? null : Marshal.PtrToStringAnsi(accessToken);
                    token.TokenType = (tokenType == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(tokenType);
                    token.Scope = scopes;
                    token.ExpiresIn = expiresIn;

                    response = new TokenResponse(responseHandle);
                    response.AccessToken = token;
                    response.State = (state == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(state);
                    response.RefreshToken = (refreshToken == IntPtr.Zero) ? null : new RefreshToken() { Token = Marshal.PtrToStringAnsi(refreshToken) };
                }
            };

            ret = Interop.Manager.RequestToken(_managerHandle, requestHandle, accessTokenCb, IntPtr.Zero);
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

        internal TokenResponse GetAccessTokenByCode(IntPtr requestHandle)
        {
            int ret = (int)OAuth2Error.None;
            IntPtr error = IntPtr.Zero;
            TokenResponse response = null;
            Interop.Manager.Oauth2AccessTokenCallback accessTokenCb = (IntPtr responseHandle, IntPtr usrData) =>
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
                    IntPtr accessToken = IntPtr.Zero;
                    ret = Interop.Response.GetAccessToken(responseHandle, out accessToken);
                    if (ret != (int)OAuth2Error.None)
                    {
                        Log.Error(ErrorFactory.LogTag, "Failed to get access token");
                        throw ErrorFactory.GetException(ret);
                    }

                    IntPtr tokenType;
                    ret = Interop.Response.GetTokenType(responseHandle, out tokenType);
                    if (ret != (int)OAuth2Error.None)
                    {
                        Log.Debug(ErrorFactory.LogTag, "TokenType can't be found");
                    }

                    long expiresIn = -1;
                    ret = Interop.Response.GetExpiresIn(responseHandle, out expiresIn);
                    if (ret != (int)OAuth2Error.None)
                    {
                        Log.Debug(ErrorFactory.LogTag, "ExpiresIn can't be found");
                    }

                    IntPtr refreshToken;
                    ret = Interop.Response.GetRefreshToken(responseHandle, out refreshToken);
                    if (ret != (int)OAuth2Error.None)
                    {
                        Log.Debug(ErrorFactory.LogTag, "Refresh Token can't be found");
                    }

                    IntPtr scope;
                    ret = Interop.Response.GetScope(responseHandle, out scope);
                    if (ret != (int)OAuth2Error.None)
                    {
                        Log.Debug(ErrorFactory.LogTag, "Scope can't be found");
                    }

                    IntPtr state;
                    ret = Interop.Response.GetState(responseHandle, out state);
                    if (ret != (int)OAuth2Error.None)
                    {
                        Log.Debug(ErrorFactory.LogTag, "State can't be found");
                    }

                    IEnumerable<string> scopes = (scope == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(scope)?.Split(' ');

                    var token = new AccessToken();
                    token.Token = (accessToken == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(accessToken);
                    token.TokenType = (tokenType == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(tokenType);
                    token.Scope = scopes;
                    token.ExpiresIn = expiresIn;

                    response = new TokenResponse(responseHandle);
                    response.AccessToken = token;
                    response.State = (state == IntPtr.Zero) ? null : Marshal.PtrToStringAnsi(state);
                    response.RefreshToken = (refreshToken == IntPtr.Zero) ? null : new RefreshToken() { Token = Marshal.PtrToStringAnsi(refreshToken) };
                }
            };

            ret = Interop.Manager.RequestAccessToken(_managerHandle, requestHandle, accessTokenCb, IntPtr.Zero);
            Interop.Request.Destroy(requestHandle);
            if (ret != (int)OAuth2Error.None || error != IntPtr.Zero)
            {
                if (error != IntPtr.Zero)
                {
                    throw ErrorFactory.GetException(error);
                }
                else
                {
                    Log.Error(ErrorFactory.LogTag, "Interop failed : " + ret);
                    throw ErrorFactory.GetException(ret);
                }
            }

            return response;
        }
    }
}

