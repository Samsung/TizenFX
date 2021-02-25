using System;

namespace Tizen.NUI.Xaml
{
    internal static class XmlnsHelper
    {
        public static string ParseNamespaceFromXmlns(string xmlns)
        {
            string typeName;
            string ns;
            string asm;

            ParseXmlns(xmlns, out typeName, out ns, out asm);
            return ns;
        }

        public static void ParseXmlns(string xmlns, out string typeName, out string ns, out string asm)
        {
            typeName = ns = asm = null;

            xmlns = xmlns.Trim();

            if (xmlns.StartsWith("using:", StringComparison.Ordinal))
            {
                ParseUsing(xmlns, out typeName, out ns, out asm);
                return;
            }
            ParseClrNamespace(xmlns, out typeName, out ns, out asm);
        }

        static void ParseClrNamespace(string xmlns, out string typeName, out string ns, out string asm)
        {
            typeName = ns = asm = null;

            foreach (var decl in xmlns.Split(';'))
            {
                if (decl.StartsWith("clr-namespace:", StringComparison.Ordinal))
                {
                    ns = decl.Substring(14, decl.Length - 14);
                    continue;
                }

                if (decl.StartsWith("assembly=", StringComparison.Ordinal))
                {
                    asm = decl.Substring(9, decl.Length - 9);
                    continue;
                }

                var nsind = decl.LastIndexOf(".", StringComparison.Ordinal);
                if (nsind > 0)
                {
                    ns = decl.Substring(0, nsind);
                    typeName = decl.Substring(nsind + 1, decl.Length - nsind - 1);
                }
                else
                    typeName = decl;
            }
        }

        static void ParseUsing(string xmlns, out string typeName, out string ns, out string asm)
        {
            typeName = ns = asm = null;

            foreach (var decl in xmlns.Split(';'))
            {
                if (decl.StartsWith("using:", StringComparison.Ordinal))
                {
                    ns = decl.Substring(6, decl.Length - 6);
                    continue;
                }
            }
        }
    }
}
