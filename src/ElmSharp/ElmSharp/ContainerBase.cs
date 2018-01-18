using System;
using System.Collections.Generic;
using System.Text;

namespace ElmSharp
{
    /// <summary>
    /// It inherits <see cref="Container"/>.
    /// The ContainerBase is a base class for user defined layouts and containers.
    /// OnLayout is served for layout time.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public abstract class ContainerBase : Container
    {
        Interop.Elementary.BoxLayoutCallback _layoutCallback;
        EvasObject _background;
        Color _bgColor;
        Rectangle _clipper;

        /// <summary>
        /// Creates and initializes a new instance of the class.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public ContainerBase() : base()
        {
        }

        /// <summary>
        /// Creates and initializes a new instance of the class.
        /// </summary>
        /// <param name="parent">The parent is a given object, which will be attached by the ContainerBase
        /// as a child. It's <see cref="EvasObject"/> type.</param>
        /// <since_tizen> preview </since_tizen>
        public ContainerBase(EvasObject parent) : base(parent)
        {
        }

        /// <summary>
        /// Sets or gets the background color of the Container.
        /// </summary>
        /// <remarks>It could be overridden by special child class.</remarks>
        /// <since_tizen> preview </since_tizen>
        public override Color BackgroundColor
        {
            get => GetBackgroundColor();
            set => SetBackgroundColor(value);
        }

        /// <summary>
        /// Sets or gets the opacity of the widget.
        /// </summary>
        /// <remarks>It could be overridden by special child class.</remarks>
        /// <since_tizen> preview </since_tizen>
        public override int Opacity
        {
            get
            {
                //var clipper = Interop.Evas.evas_object_smart_clipped_clipper_get(Handle);
                Interop.Evas.evas_object_color_get(_clipper, out int r, out int g, out int b, out int a);
                return a;
            }
            set
            {
                //var clipper = Interop.Evas.evas_object_smart_clipped_clipper_get(Handle);
                Interop.Evas.evas_object_color_set(_clipper, 0xff, 0xff, 0xff, value);
            }
        }

        /// <summary>
        /// Adds an object to the Container.
        /// </summary>
        /// <param name="child">The oject to be added.</param>
        /// <since_tizen> preview </since_tizen>
        public void Add(EvasObject child)
        {
            AddChild(child);
        }

        /// <summary>
        /// Removes an object from the Container.
        /// </summary>
        /// <param name="child">The oject to be removed.</param>
        /// <since_tizen> preview </since_tizen>
        public void Remove(EvasObject child)
        {
            RemoveChild(child);
        }

        /// <summary>
        /// The Container listener that is invoked when a child is added.
        /// </summary>
        /// <param name="child">The oject to be added</param>
        protected override void OnChildAdded(EvasObject child)
        {
            base.OnChildAdded(child);
            Interop.Elementary.elm_box_pack_end(Handle, child.Handle);
            child.SetClip(_clipper);
        }

        /// <summary>
        /// The Container listener that is invoked when a child is removed.
        /// </summary>
        /// <param name="child">The object to be removed</param>
        protected override void OnChildRemoved(EvasObject child)
        {
            base.OnChildRemoved(child);
            Interop.Elementary.elm_box_unpack(Handle, child);
            Interop.Evas.evas_object_clip_unset(child);
        }

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject</param>
        /// <returns>Handle IntPtr</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr handle = Interop.Elementary.elm_box_add(parent);
            _layoutCallback = OnLayoutInternal;
            Interop.Elementary.elm_box_layout_set(handle, _layoutCallback, IntPtr.Zero, null);
            return handle;
        }

        /// <summary>
        /// The callback of the Realized Event.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected override void OnRealized()
        {
            base.OnRealized();
            _background = OnCreateBackground();
            _background.Show();
            Interop.Elementary.elm_box_pack_start(Handle, _background);
            _clipper = new Rectangle(this);
            _clipper.Show();
            Interop.Elementary.elm_box_pack_start(Handle, _clipper);
            _background.SetClip(_clipper);
        }

        /// <summary>
        /// Creates a Background object for the Container.
        /// </summary>
        /// <returns>The object to be set to the background of the Container.</returns>
        /// <since_tizen> preview </since_tizen>
        protected virtual EvasObject OnCreateBackground()
        {
            return new Rectangle(this);
        }

        /// <summary>
        /// Get Background Color from the Container.
        /// </summary>
        /// <returns>The color object of background</returns>
        /// <since_tizen> preview </since_tizen>
        protected virtual Color GetBackgroundColor()
        {
            return _bgColor;
        }

        /// <summary>
        /// Set Background Color to the Container.
        /// </summary>
        /// <param name="color">The color object to be set to the background color of the Container.</param>
        /// <since_tizen> preview </since_tizen>
        protected virtual void SetBackgroundColor(Color color)
        {
            if (color == _bgColor) return;
            if (_background != null)
            {
                _background.Color = color;
            }
            _bgColor = color;
        }

        /// <summary>
        /// The listener that is invoked on background object is located on layout time.
        /// </summary>
        /// <param name="geometry">The geometry values of the Container.</param>
        /// <param name="background">The background object to be located.</param>
        /// <seealso cref="OnCreateBackground"/>
        /// <since_tizen> preview </since_tizen>
        protected virtual void OnBackgroundLayout(Rect geometry, EvasObject background)
        {
            background.Geometry = geometry;
        }

        /// <summary>
        /// The callback function that is used for layout of the Container.
        /// It will be invoked after OnBackgroundLayout is called.
        /// </summary>
        /// <param name="geometry">The Geometry values of the Container.</param>
        /// <since_tizen> preview </since_tizen>
        protected abstract void OnLayout(Rect geometry);

        void OnLayoutInternal(IntPtr obj, IntPtr priv, IntPtr userData)
        {
            var rect = Geometry;
            _clipper.Geometry = rect;
            OnBackgroundLayout(rect, _background);
            OnLayout(rect);
        }
    }
}
