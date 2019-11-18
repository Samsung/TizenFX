using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        public class InputSelector : AbstractItem
        {
            IList<string> _contents;
            private const string LogTag = "Tizen.Applications.NotificationEx";
            public InputSelector(string id) : base(((Func<IntPtr>)(delegate ()
            {
                IntPtr handle;
                ErrorCode err = Interop.NotificationEx.InputSelectorCreate(out handle, id);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return handle;
            }))())
            {
            }

            internal InputSelector(IntPtr ptr) : base(ptr)
            {
            }

            internal override void Serialize()
            {
                base.Serialize();
                if (_contents != null)
                    Contents = _contents;
            }

            public IList<string> Contents
            {
                get
                {
                    if (_contents != null)
                        return _contents;

                    _contents = new List<string>();

                    IntPtr contents;
                    int count;
                    Interop.NotificationEx.InputSelectorGetContents(NativeHandle, out contents, out count);
                    if (count == 0)
                        return _contents;
                   
                    string[] arr = Util.IntPtrToStringArray(contents, count);
                    Interop.NotificationEx.ItemFreeStringList(contents, count);
                    Log.Error(LogTag, "Get Contents #" + count);
                    _contents = arr.ToList();
                    return _contents;
                }
                set
                {
                    if (value == null)
                        ErrorFactory.ThrowException(ErrorCode.InvalidParameter);

                    Interop.NotificationEx.InputSelectorSetContents(NativeHandle, value.ToArray(), value.Count);
                    Log.Error(LogTag, "Set Contents");
                    _contents = value;
                }
            }

            public void SetMultiLanguageContents(IList<MultiLanguage> contents)
            {
                if (contents == null)
                    Interop.NotificationEx.InputSelectorSetMultiLanguageContents(NativeHandle, IntPtr.Zero, 0);
                else
                    Interop.NotificationEx.InputSelectorSetMultiLanguageContents(NativeHandle, Util.ListToIntPtr(contents), contents.Count);
            }
        }
    }
}
