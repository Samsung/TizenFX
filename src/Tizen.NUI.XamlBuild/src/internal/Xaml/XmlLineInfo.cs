using System.Xml;

namespace Tizen.NUI.Xaml
{
    internal class XmlLineInfo : IXmlLineInfo
    {
        readonly bool _hasLineInfo;
        private int v1;
        private int v2;

        public XmlLineInfo()
        {
        }

        public XmlLineInfo(int linenumber, int lineposition)
        {
            _hasLineInfo = true;
            LineNumber = linenumber;
            LinePosition = lineposition;
        }

        public bool HasLineInfo()
        {
            return _hasLineInfo;
        }

        public int LineNumber { get; }

        public int LinePosition { get; }
    }
}