using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Tizen.NUI.StyleSheets
{
    /// <summary>
    /// The class CssReader.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class CssReader : TextReader
    {
        readonly TextReader _reader;

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CssReader(TextReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            _reader = reader;
        }

        readonly Queue<char> _cache = new Queue<char>();

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int Peek()
        {
            if (_cache.Count > 0)
                return _cache.Peek();

            int p = _reader.Peek();
            if (p <= 0)
                return p;
            if (unchecked((char)p) != '/')
                return p;

            _cache.Enqueue(unchecked((char)_reader.Read()));
            p = _reader.Peek();
            if (p <= 0)
                return _cache.Peek();
            if (unchecked((char)p) != '*')
                return _cache.Peek();

            _cache.Clear();
            _reader.Read(); //consume the '*'

            bool hasStar = false;
            while (true) {
                var next = _reader.Read();
                if (next <= 0)
                    return next;
                if (unchecked((char)next) == '*')
                    hasStar = true;
                else if (hasStar && unchecked((char)next) == '/')
                    return Peek(); //recursively call self for comments following comments
                else
                    hasStar = false;
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int Read()
        {
            if (_cache.Count > 0)
                return _cache.Dequeue();

            int p = _reader.Read();
            if (p <= 0)
                return p;
            var c = unchecked((char)p);
            if (c != '/')
                return p;

            _cache.Enqueue(c);
            p = _reader.Read();
            if (p <= 0)
                return _cache.Dequeue();
            c = unchecked((char)p);
            if (c != '*')
                return _cache.Dequeue();

            _cache.Clear();
            _reader.Read(); //consume the '*'

            bool hasStar = false;
            while (true) {
                var next = _reader.Read();
                if (next <= 0)
                    return next;
                if (unchecked((char)next) == '*')
                    hasStar = true;
                else if (hasStar && unchecked((char)next) == '/')
                    return Read(); //recursively call self for comments following comments
                else
                    hasStar = false;
            }
        }
    }
}