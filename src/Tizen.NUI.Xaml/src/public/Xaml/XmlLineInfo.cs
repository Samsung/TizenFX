using System.Xml;

namespace Tizen.NUI.Xaml
{
    /// <summary>
    /// The class XmlLineInfo.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class XmlLineInfo : IXmlLineInfo
    {
        readonly bool _hasLineInfo;

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