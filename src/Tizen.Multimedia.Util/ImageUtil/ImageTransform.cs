/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static Interop.ImageUtil;
using static Interop.ImageUtil.Transform;

namespace Tizen.Multimedia.Util
{
    /// <summary>
    /// A base class for image transformations.
    /// </summary>
    public abstract class ImageTransform
    {
        internal async Task<MediaPacket> RunAsync(TransformHandle handle, MediaPacket source)
        {
            var tcs = new TaskCompletionSource<MediaPacket>();

            TransformCompletedCallback cb = (nativehandle, errorCode, _) =>
            {
                if (errorCode == ImageUtilError.None)
                {
                    try
                    {
                        tcs.TrySetResult(MediaPacket.From(Marshal.PtrToStructure<IntPtr>(nativehandle)));
                    }
                    catch (Exception e)
                    {
                        tcs.TrySetException(e);
                    }
                }
                else
                {
                    tcs.TrySetException(errorCode.ToException("Image transformation failed"));
                }
            };

            using (var cbKeeper = ObjectKeeper.Get(cb))
            {
                Run(handle, source.GetHandle(), cb).ThrowIfFailed("Failed to transform given packet with " + GetType());

                return await tcs.Task;
            }
        }

        internal static TransformHandle CreateHandle()
        {
            Create(out var handle).ThrowIfFailed("Failed to run ImageTransformer");
            Debug.Assert(handle != null);
            return handle;
        }

        internal abstract void Configure(TransformHandle handle);

        internal virtual Task<MediaPacket> ApplyAsync(MediaPacket source)
        {
            using (TransformHandle handle = CreateHandle())
            {
                Configure(handle);

                return RunAsync(handle, source);
            }
        }
    }

    /// <summary>
    /// Represents a collection of <see cref="ImageTransform"/> objects that can be individually accessed by index.
    /// </summary>
    public class ImageTransformCollection : IEnumerable<ImageTransform>, IList<ImageTransform>
    {
        private List<ImageTransform> _list = new List<ImageTransform>();

        /// <summary>
        /// Initializes a new instance of the ImageTransformCollection class.
        /// </summary>
        public ImageTransformCollection()
        {
        }

        /// <summary>
        /// Gets or sets the <see cref="ImageTransform"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the <see cref="ImageTransform"/> to get or set.</param>
        /// <value>The <see cref="ImageTransform"/> at the specified index.</value>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     index is less than 0.\n
        ///     - or -\n
        ///     index is equal to or greater than Count.
        /// </exception>
        public ImageTransform this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }

        /// <summary>
        /// Gets the number of items contained in the TransformCollection.
        /// </summary>
        public int Count => _list.Count;

        bool ICollection<ImageTransform>.IsReadOnly => false;

        /// <summary>
        /// Adds a <see cref="ImageTransform"/> to the end of the collection.
        /// </summary>
        /// <param name="item">The <see cref="ImageTransform"/> to add.</param>
        /// <remarks>
        /// <see cref="ImageTransformCollection"/> accepts null as a valid value for reference types and allows duplicate elements.
        /// </remarks>
        public void Add(ImageTransform item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _list.Add(item);
        }

        /// <summary>
        /// Removes all items.
        /// </summary>
        public void Clear() => _list.Clear();

        /// <summary>
        /// Determines whether the <see cref="ImageTransformCollection"/> contains the specified item.
        /// </summary>
        /// <param name="item">The <see cref="ImageTransform"/> to locate in the collection.</param>
        /// <returns>true if the <see cref="ImageTransform"/> is found in the collection; otherwise, false.</returns>
        public bool Contains(ImageTransform item) => _list.Contains(item);

        /// <summary>
        /// Copies the items of the collection to an array, starting at the specified array index.
        /// </summary>
        /// <param name="array">The one-dimensional array that is the destination of the items copied from the collection.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <exception cref="ArgumentNullException"><paramref name="array"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="arrayIndex"/> is less than 0.</exception>
        /// <exception cref="ArgumentException">
        /// The number of elements in the source collection is greater than the available space from arrayIndex to the end of the destination array.
        /// </exception>
        public void CopyTo(ImageTransform[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);

        /// <summary>
        /// Determines the index of the specified item in the collection.
        /// </summary>
        /// <param name="item">The <see cref="ImageTransform"/> to locate in the collection.</param>
        /// <returns>The index of value if found in the <see cref="ImageTransformCollection"/>; otherwise, -1.</returns>
        public int IndexOf(ImageTransform item) => _list.IndexOf(item);

        /// <summary>
        /// Inserts a <see cref="ImageTransform"/> into the collection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param>
        /// <param name="item">The <see cref="ImageTransform"/> to insert into the collection.</param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     index is less than 0.\n
        ///     -or-\n
        ///     index is greater than <see cref="Count"/>.
        /// </exception>
        public void Insert(int index, ImageTransform item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _list.Insert(index, item);
        }

        /// <summary>
        /// Removes the first occurrence of the specified <see cref="ImageTransform"/> from the collection.
        /// </summary>
        /// <param name="item">The <see cref="ImageTransform"/> to remove.</param>
        /// <returns>true if <paramref name="item"/> was removed from the collection; otherwise, false.</returns>
        public bool Remove(ImageTransform item) => _list.Remove(item);

        /// <summary>
        /// Removes the <see cref="ImageTransform"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     index is less than 0.\n
        ///     - or -\n
        ///     index is equal to or greater than <see cref="Count"/>.
        /// </exception>
        public void RemoveAt(int index) => _list.RemoveAt(index);

        /// <summary>
        /// Returns an enumerator that can iterate through the collection.
        /// </summary>
        /// <returns>A enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<ImageTransform> GetEnumerator() => _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();
    }

    // TODO need to improve performance
    /// <summary>
    /// Represents a <see cref="ImageTransform"/> that is a composite of the transforms.
    /// </summary>
    public class ImageTransformGroup : ImageTransform
    {
        /// <summary>
        /// Gets or sets the <see cref="ImageTransformCollection"/>.
        /// </summary>
        public ImageTransformCollection Children { get; set; }

        /// <summary>
        /// Initializes a new instance of the ImageTransformGroup class.
        /// </summary>
        public ImageTransformGroup()
        {
            Children = new ImageTransformCollection();
        }

        internal override void Configure(TransformHandle handle)
        {
            // intended blank
        }

        internal override async Task<MediaPacket> ApplyAsync(MediaPacket source)
        {
            if (Children.Count == 0)
            {
                return source;
            }

            var items = Children;

            MediaPacket curPacket = await items[0].ApplyAsync(source);

            for (int i = 1; i < items.Count; ++i)
            {
                var oldPacket = curPacket;
                try
                {
                    curPacket = await items[i].ApplyAsync(curPacket);
                }
                finally
                {
                    oldPacket.Dispose();
                }
            }

            return curPacket;
        }
    }

    /// <summary>
    /// Rotates or flips an image.
    /// </summary>
    /// <seealso cref="Rotation"/>
    public class RotateTransform : ImageTransform
    {
        private Rotation _rotation;

        /// <summary>
        /// Initialize a new instance of the <see cref="RotateTransform"/> class.
        /// </summary>
        /// <param name="rotation">The value how to rotate an image.</param>
        /// <exception cref="ArgumentException"><paramref name="rotation"/> is invalid.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="rotation"/> is <see cref="Rotation.Rotate90"/>.</exception>
        public RotateTransform(Rotation rotation)
        {
            Rotation = rotation;

        }

        /// <summary>
        /// Gets or sets the value how to rotate an image.
        /// </summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is invalid.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is <see cref="Rotation.Rotate90"/>.</exception>
        public Rotation Rotation
        {
            get { return _rotation; }
            set
            {
                ValidationUtil.ValidateEnum(typeof(Rotation), value, nameof(Rotation));

                if (value == Rotation.Rotate0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Rotation can't be Rotate0.");
                }

                _rotation = value;
            }
        }

        internal override void Configure(TransformHandle handle)
        {
            SetRotation(handle, GetImageRotation());
        }

        private ImageRotation GetImageRotation()
        {
            switch (Rotation)
            {
                case Rotation.Rotate90: return ImageRotation.Rotate90;
                case Rotation.Rotate180: return ImageRotation.Rotate180;
                case Rotation.Rotate270: return ImageRotation.Rotate270;
            }

            Debug.Fail("Rotation is invalid value!");
            return ImageRotation.Rotate0;
        }
    }


    /// <summary>
    /// Rotates or flips an image.
    /// </summary>
    /// <seealso cref="Rotation"/>
    public class FlipTransform : ImageTransform
    {
        private Flips _flip;

        /// <summary>
        /// Initialize a new instance of the <see cref="RotateTransform"/> class.
        /// </summary>
        /// <param name="flip">The value how to flip an image.</param>
        /// <exception cref="ArgumentException"><paramref name="flip"/> is invalid.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="flip"/> is <see cref="Flip.None"/>.</exception>
        public FlipTransform(Flips flip)
        {
            Flip = flip;
        }

        /// <summary>
        /// Gets or sets the value how to rotate an image.
        /// </summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is invalid.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is <see cref="Flip.None"/>.</exception>
        public Flips Flip
        {
            get { return _flip; }
            set
            {
                ValidationUtil.ValidateFlagsEnum(value, Flips.Horizontal | Flips.Vertical, nameof(Flips));

                if (value == Flips.None)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Flip can't be None.");
                }

                _flip = value;
            }
        }

        internal override void Configure(TransformHandle handle)
        {
            // intended blank
        }

        private async Task<MediaPacket> ApplyAsync(TransformHandle handle, MediaPacket source,
            ImageRotation rotation)
        {
            SetRotation(handle, rotation);
            return await RunAsync(handle, source);
        }

        internal override async Task<MediaPacket> ApplyAsync(MediaPacket source)
        {
            using (TransformHandle handle = CreateHandle())
            {
                if (Flip.HasFlag(Flips.Vertical | Flips.Horizontal))
                {
                    var flipped = await ApplyAsync(handle, source, ImageRotation.FlipHorizontal);
                    try
                    {
                        return await ApplyAsync(handle, flipped, ImageRotation.FlipVertical);
                    }
                    finally
                    {
                        flipped.Dispose();
                    }
                }

                return await ApplyAsync(handle, source, Flip.HasFlag(Flips.Horizontal) ?
                    ImageRotation.FlipHorizontal : ImageRotation.FlipVertical);
            }
        }
    }

    /// <summary>
    /// Changes colorspace of image.
    /// </summary>
    /// <seealso cref="ColorSpace"/>
    public class ColorSpaceTransform : ImageTransform
    {
        private ImageColorSpace _imageColorSpace;

        /// <summary>
        /// Initialize a new instance of the <see cref="ColorSpaceTransform"/> class.
        /// </summary>
        /// <param name="colorSpace">The colorspace of output image.</param>
        /// <exception cref="ArgumentException"><paramref name="colorSpace"/> is invalid.</exception>
        /// <exception cref="NotSupportedException"><paramref name="colorSpace"/> is not supported.</exception>
        /// <seealso cref="SupportedColorSpaces"/>
        public ColorSpaceTransform(ColorSpace colorSpace)
        {
            ColorSpace = colorSpace;
        }

        /// <summary>
        /// Gets or sets the colorspace of the result image.
        /// </summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is invalid.</exception>
        /// <exception cref="NotSupportedException"><paramref name="value"/> is not supported.</exception>
        /// <seealso cref="SupportedColorSpaces"/>
        public ColorSpace ColorSpace
        {
            get { return _imageColorSpace.ToCommonColorSpace(); }
            set
            {
                ValidationUtil.ValidateEnum(typeof(ColorSpace), value, nameof(ColorSpace));

                _imageColorSpace = value.ToImageColorSpace();
            }
        }

        internal override void Configure(TransformHandle handle)
        {
            SetColorspace(handle, _imageColorSpace);
        }

        /// <summary>
        /// Gets the supported colorspaces for <see cref="ColorSpaceTransform"/>.
        /// </summary>
        public static IEnumerable<ColorSpace> SupportedColorSpaces
        {
            get
            {
                foreach (ImageColorSpace value in Enum.GetValues(typeof(ImageColorSpace)))
                {
                    yield return value.ToCommonColorSpace();
                }
            }
        }
    }

    /// <summary>
    /// Crops an image.
    /// </summary>
    public class CropTransform : ImageTransform
    {
        private Rectangle _region;

        /// <summary>
        /// Initialize a new instance of the <see cref="CropTransform"/> class.
        /// </summary>
        /// <param name="region">The crop region.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The X-position of <paramref name="region"/> is less than zero.\n
        ///     - or -\n
        ///     The Y-position of <paramref name="region"/> is less than zero.\n
        ///     - or -\n
        ///     The width of <paramref name="region"/> is less than or equal to zero.\n
        ///     - or -\n
        ///     The height of <paramref name="region"/> is less than or equal to zero.
        /// </exception>
        public CropTransform(Rectangle region)
        {
            Region = region;
        }

        /// <summary>
        /// Gets or sets the crop region.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The X-position of <paramref name="value"/> is less than zero.\n
        ///     - or -\n
        ///     The Y-position of <paramref name="value"/> is less than zero.\n
        ///     - or -\n
        ///     The width of <paramref name="value"/> is less than or equal to zero.\n
        ///     - or -\n
        ///     The height of <paramref name="value"/> is less than or equal to zero.
        /// </exception>
        public Rectangle Region
        {
            get { return _region; }
            set
            {

                if (value.X < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Region), value,
                        "X position of the region can't be less than zero.");
                }

                if (value.Y < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Region), value,
                        "Y position of the region can't be less than zero.");
                }

                if (value.Width <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Region), value,
                        "Width of the region can't be less than or equal zero.");
                }

                if (value.Height < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Region), value,
                        "Height of the region can't be less than or equal to zero.");
                }

                _region = value;
            }
        }

        internal override void Configure(TransformHandle handle)
        {
            SetCropArea(handle, Region.Left, Region.Top, Region.Right, Region.Bottom);
        }
    }

    /// <summary>
    /// Resizes an image.
    /// </summary>
    public class ResizeTransform : ImageTransform
    {
        private Size _size;

        /// <summary>
        /// Initialize a new instance of the <see cref="ResizeTransform"/> class.
        /// </summary>
        /// <param name="size">The size that an image is resized to.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The width of <paramref name="size"/> is less than or equal to zero.\n
        ///     - or -\n
        ///     The height of <paramref name="size"/> is less than or equal to zero.
        /// </exception>
        public ResizeTransform(Size size)
        {
            Size = size;
        }

        /// <summary>
        /// Gets or sets the size that an image is resized to.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     The width of <paramref name="value"/> is less than or equal to zero.\n
        ///     - or -\n
        ///     The height of <paramref name="value"/> is less than or equal to zero.
        /// </exception>
        public Size Size
        {
            get { return _size; }
            set
            {
                if (value.Width <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Size), value,
                        "Width of the size can't be less than or equal to zero.");
                }

                if (value.Height <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Size), value,
                        "Height of the size can't be less than or equal to zero.");
                }

                _size = value;
            }
        }

        internal override void Configure(TransformHandle handle)
        {
            SetResolution(handle, (uint)Size.Width, (uint)Size.Height);
        }
    }
}
