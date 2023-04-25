using System;
using System.Collections.Specialized;
using System.Web;

namespace Tizen.Data.Tdbc
{
    /// <summary>
    /// Provides a simple way to create and manage the contents of connection uri used by the Connection class.
    /// </summary>
    /// <since_tizen> 11 </since_tizen>
    public class ConnectionUriBuilder : NameValueCollection
    {
        private UriBuilder _uriBuilder = new UriBuilder();

        /// <summary>
        /// The constructor of ConnectionUriBuilder class.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public ConnectionUriBuilder()
        {
            _uriBuilder.Scheme = "tdbc";
        }

        /// <summary>
        /// Gets the Uri object.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public Uri Uri
        {
            get
            {
                var query = HttpUtility.ParseQueryString(String.Empty);
                foreach (string key in this)
                {
                    string value = this[key];
                    query.Add(key, value);
                }
                _uriBuilder.Query = query.ToString();
                return _uriBuilder.Uri;
            }
        }

        /// <summary>
        /// Gets or sets the host name or IP address of a database server.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public string Host
        {
            get => _uriBuilder.Host;
            set => _uriBuilder.Host = value;
        }

        /// <summary>
        /// Gets or sets port number of database server.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The port number is out of range.</exception>
        /// <since_tizen> 11 </since_tizen>
        public int Port
        {
            get => _uriBuilder.Port;
            set => _uriBuilder.Port = value;
        }

        /// <summary>
        /// Gets or sets name of the driver.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public string Driver
        {
            get => _uriBuilder.Path;
            set => _uriBuilder.Path = value;
        }

        /// <summary>
        /// Gets or sets the name of the user that accesses the database.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public string UserName
        {
            get => _uriBuilder.UserName;
            set => _uriBuilder.UserName = value;
        }

        /// <summary>
        /// Gets or sets the name of the password of the user.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public string Password
        {
            get => _uriBuilder.Password;
            set => _uriBuilder.Password = value;
        }

        /// <summary>
        /// Gets or sets value of key.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public new string this[string key]
        {
            get => base.Get(key);
            set => base.Set(key, value);
        }
    }
}