using System;

namespace ElmSharp
{
    public class Label : Layout
    {
        Interop.SmartEvent _slideCompleted;

        public Label(EvasObject parent) : base(parent)
        {
            _slideCompleted = new Interop.SmartEvent(this, Handle, "slide,end");
            _slideCompleted.On += (s, e) =>
            {
                SlideCompleted?.Invoke(this, EventArgs.Empty);
            };
        }

        public event EventHandler SlideCompleted;

        public int LineWrapWidth
        {
            get
            {
                return Interop.Elementary.elm_label_wrap_width_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_label_wrap_width_set(Handle, value);
            }
        }

        public WrapType LineWrapType
        {
            get
            {
                return (WrapType)Interop.Elementary.elm_label_line_wrap_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_label_line_wrap_set(Handle, (int)value);
            }
        }

        public LabelSlideMode SlideMode
        {
            get
            {
                return (LabelSlideMode)Interop.Elementary.elm_label_slide_mode_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_label_slide_mode_set(Handle, (int)value);
            }
        }

        public double SlideDuration
        {
            get
            {
                return Interop.Elementary.elm_label_slide_duration_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_label_slide_duration_set(Handle, value);
            }
        }

        public bool IsEllipsis
        {
            get
            {
                return Interop.Elementary.elm_label_ellipsis_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_label_ellipsis_set(Handle, value);
            }
        }

        public void PlaySlide()
        {
            Interop.Elementary.elm_label_slide_go(Handle);
        }

        internal override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_label_add(parent.Handle);
        }
    }

    public enum LabelSlideMode
    {
        None = 0,
        Auto,
        Always
    }
}
