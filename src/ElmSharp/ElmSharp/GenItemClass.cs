using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ElmSharp
{
    public class GenItemClass : IDisposable
    {
        public delegate string GetTextDelegate(object data, string part);
        public delegate EvasObject GetContentDelegate(object data, string part);
        public delegate void DeleteDelegate(object data);

        private ItemClass _itemClass;
        private IntPtr _unmanagedPtr = IntPtr.Zero;
        private string _style;

        public GenItemClass(string style)
        {
            _style = style;
            _itemClass = new ItemClass()
            {
                refCount = 1,
                deleteMe = 0,
                itemStyle = style,
                textCallback = GetTextCallback,
                contentCallback = GetContentCallback,
                stateCallback = null,
                delCallback = DelCallback,
            };
        }

        ~GenItemClass()
        {
            Dispose(false);
        }

        public string ItemStyle { get { return _style; } }
        public GetTextDelegate GetTextHandler { get; set; }
        public GetContentDelegate GetContentHandler { get; set; }
        public DeleteDelegate DeleteHandler { get; set; }

        internal IntPtr UnmanagedPtr
        {
            get
            {
                if (_unmanagedPtr == IntPtr.Zero)
                {
                    _unmanagedPtr = Marshal.AllocHGlobal(Marshal.SizeOf(_itemClass));
                    Marshal.StructureToPtr(_itemClass, _unmanagedPtr, false);
                }
                return _unmanagedPtr;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_unmanagedPtr != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_unmanagedPtr);
                _unmanagedPtr = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Releases all resources used by the class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private string GetTextCallback(IntPtr data, IntPtr obj, IntPtr part)
        {
            GenItem item = ItemObject.GetItemById((int)data) as GenItem;
            return GetTextHandler?.Invoke(item?.Data, Marshal.PtrToStringAnsi(part));
        }
        private IntPtr GetContentCallback(IntPtr data, IntPtr obj, IntPtr part)
        {
            GenItem item = ItemObject.GetItemById((int)data) as GenItem;
            return GetContentHandler?.Invoke(item?.Data, Marshal.PtrToStringAnsi(part));
        }
        private void DelCallback(IntPtr data, IntPtr obj)
        {
            GenItem item = ItemObject.GetItemById((int)data) as GenItem;
            DeleteHandler?.Invoke(item?.Data);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal class ItemClass
    {
        public delegate string GetTextCallback(IntPtr data, IntPtr obj, IntPtr part);
        public delegate IntPtr GetContentCallback(IntPtr data, IntPtr obj, IntPtr part);
        public delegate int GetStateCallback(IntPtr data, IntPtr obj, IntPtr part);
        public delegate void DelCallback(IntPtr data, IntPtr obj);
        public delegate int FilterCallback(IntPtr data, IntPtr obj, IntPtr key);

        public readonly int version;
        public uint refCount;
        public int deleteMe;
        public string itemStyle;
        public readonly string decorateItemStyle;
        public readonly string decorateAllItemStyle;
        public GetTextCallback textCallback;
        public GetContentCallback contentCallback;
        public GetStateCallback stateCallback;
        public DelCallback delCallback;
        public FilterCallback filterCallback;
    }

}
