using System;
using System.Text.RegularExpressions;

namespace Tizen.Applications
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AppControlFilter : Attribute
    {
        private readonly string _operation;
        private readonly string _mime;
        private readonly string _uri;

        public string Operation { get { return _operation; } }
        public string Mime { get { return _mime; } }
        public string Uri { get { return _uri; } }

        public AppControlFilter(string operation, string mime = null, string uri = null)
        {
            _operation = operation;
            _mime = mime;
            _uri = uri;
        }

        public override bool Equals(object obj)
        {
            AppControlFilter f = obj as AppControlFilter;
            if (f == null) return false;

            return (_operation == f._operation) & (_mime == f._mime) & (_uri == f._uri);
        }

        public override int GetHashCode()
        {
            int hash = 0;
            if (_operation != null)
            {
                hash ^= _operation.GetHashCode();
            }
            if (_mime != null)
            {
                hash ^= _mime.GetHashCode();
            }
            if (_uri != null)
            {
                hash ^= _uri.GetHashCode();
            }
            return hash;
        }

        private bool IsMimeMatched(string mime)
        {
            if (_mime == "*" || _mime == "*/*")
            {
                return true;
            }
            if (String.IsNullOrEmpty(_mime))
            {
                return String.IsNullOrEmpty(mime);
            }
            Regex pat = new Regex(_mime.Replace("*", ".*"));
            return pat.IsMatch(mime);
        }

        private bool IsUriMatched(string uri)
        {
            if (_uri == "*")
            {
                return true;
            }
            if (String.IsNullOrEmpty(_uri))
            {
                return String.IsNullOrEmpty(uri);
            }
            string schema = _uri.Split(':')[0];
            if (schema == _uri || _uri.EndsWith("://") || _uri.EndsWith("://*"))
            {
                return schema == uri.Split(':')[0];
            }
            if (_uri.EndsWith("*"))
            {
                return uri.StartsWith(_uri.Substring(0, _uri.Length - 1));
            }
            return _uri == uri;
        }

        public bool IsMatch(AppControl e)
        {
            string mime = e.Mime;
            if (String.IsNullOrEmpty(mime) && !String.IsNullOrEmpty(e.Uri))
            {
                mime = Interop.Aul.GetMimeFromUri(e.Uri);
            }
            return _operation == e.Operation && IsMimeMatched(mime) && IsUriMatched(e.Uri);
        }
    }

}
