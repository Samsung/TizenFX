using System;

namespace Tizen.Application
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AppControlFilter : Attribute
    {
        private readonly string _operation;
        private readonly string _mime;
        private readonly string _scheme;

        public string Operation { get { return _operation; } }
        public string Mime { get { return _mime; } }
        public string Scheme { get { return _scheme; } }

        public AppControlFilter(string operation, string mime = null, string scheme = null)
        {
            _operation = operation;
            _mime = mime;
            _scheme = scheme;
        }

        public override bool Equals(object obj)
        {
            AppControlFilter f = obj as AppControlFilter;
            if (f == null) return false;

            return (_operation == f._operation) & (_mime == f._mime) & (_scheme == f._scheme);
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
            if (_scheme != null)
            {
                hash ^= _scheme.GetHashCode();
            }
            return hash;
        }

        public bool IsMatched(AppControl e)
        {
            throw new NotImplementedException();            
        }
    }

}
