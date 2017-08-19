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

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// Represents a playlist that is a group of media(usually songs).
    /// </summary>
    public class Playlist
    {
        internal Playlist(IntPtr handle)
        {
            Name = InteropHelper.GetString(handle, Interop.Playlist.GetName);
            ThumbnailPath = InteropHelper.GetString(handle, Interop.Playlist.GetThumbnailPath);

            Id = InteropHelper.GetValue<IntPtr, int>(handle, Interop.Playlist.GetId);
        }

        internal static Playlist FromHandle(IntPtr handle) => new Playlist(handle);

        /// <summary>
        /// Gets the ID of the playlist.
        /// </summary>
        /// <value>The unique id of the playlist.</value>
        public int Id { get; }

        /// <summary>
        /// Gets the name of the playlist.
        /// </summary>
        /// <value>The name of the playlist.</value>
        public string Name { get; }

        /// <summary>
        /// Gets the path to the thumbnail.
        /// </summary>
        /// <value>The path to the thumbnail.</value>
        public string ThumbnailPath { get; }

        /// <summary>
        /// Returns a string representation of the playlist.
        /// </summary>
        /// <returns>A string representation of the current playlist.</returns>
        public override string ToString() =>
            $"Id={Id}, Name={Name}, ThumbnailPath={ThumbnailPath}";
    }

    /// <summary>
    /// Provides means to set values used for the update command.
    /// </summary>
    /// <remarks>
    /// The values only set in the object will be affected to the update command.
    /// </remarks>
    /// <seealso cref="PlaylistCommand.Update(int, PlaylistUpdateValues)"/>
    public class PlaylistUpdateValues
    {
        /// <summary>
        /// Gets or sets the name of playlist for update.
        /// </summary>
        /// <remarks>If the value is null, the update operation will have no effect on the field.</remarks>
        /// <value>A string for name; the field will not be updated if null.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the thumbnail path of playlist for update.
        /// </summary>
        /// <remarks>If the value is null, the update operation will have no effect on the field.</remarks>
        /// <value>A string for thumbnail path; the field will not be updated if null.</value>
        public string ThumbnailPath { get; set; }
    }

    /// <summary>
    /// Represents an order of a member of a playlist.
    /// </summary>
    public class PlayOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Playlist"/> class with the specified member id and order value.
        /// </summary>
        /// <param name="memberId">The id of member.</param>
        /// <param name="orderValue">The order value.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="memberId"/> is less than or equal to zero.\n
        ///     -or-\n
        ///     <paramref name="orderValue"/> is less than zero.
        /// </exception>
        public PlayOrder(int memberId, int orderValue)
        {
            MemberId = memberId;
            Value = orderValue;
        }

        private int _memberId;

        /// <summary>
        /// Gets or sets the member id.
        /// </summary>
        /// <value>The member id.</value>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="value"/> is less than or equal to zero.
        /// </exception>
        public int MemberId
        {
            get => _memberId;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                    "Member id can't be less than or equal to zero.");
                }
                _memberId = value;
            }
        }

        private int _value;

        /// <summary>
        /// Gets or sets the value indicating the order of the member in a playlist.
        /// </summary>
        /// <value>A integer value indicating the order of the member in a playlist.</value>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="value"/> is less than zero.
        /// </exception>
        public int Value
        {
            get => _value;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        "Order can't be less than zero.");
                }
                _value = value;
            }
        }
    }
}
