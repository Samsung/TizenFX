/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Runtime.InteropServices;
using Tizen.Applications;
using Tizen.Multimedia.Remoting;

internal static partial class Interop
{
    internal static partial class MediaControllerPlaylist
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void MetadataUpdatedCallback(string serverName, IntPtr metadata, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PlaylistUpdatedCallback(string serverName, MediaControlPlaylistMode repeatMode, string playlist,
            IntPtr handle, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool PlaylistCallback(IntPtr handle, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool PlaylistItemCallback(string index, IntPtr handle, IntPtr userData);


        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_metadata_updated_cb")]
        internal static extern MediaControllerError SetMetadataUpdatedCb(MediaControllerClientHandle handle,
            MetadataUpdatedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_metadata_updated_cb")]
        internal static extern MediaControllerError UnsetMetadataUpdatedCb(MediaControllerClientHandle handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_playlist_updated_cb")]
        internal static extern MediaControllerError SetPlaylistModeUpdatedCb(MediaControllerClientHandle handle,
            PlaylistUpdatedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_playlist_updated_cb")]
        internal static extern MediaControllerError UnsetPlaylistModeUpdatedCb(MediaControllerClientHandle handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_metadata_get")]
        private static extern MediaControllerError GetMetadata(IntPtr metadata, MediaControllerNativeAttribute attribute,
            out IntPtr value);

        internal static string GetMetadata(IntPtr handle, MediaControllerNativeAttribute attr)
        {
            IntPtr valuePtr = IntPtr.Zero;

            try
            {
                GetMetadata(handle, attr, out valuePtr).ThrowIfError($"Failed to get value for {attr}.");
                return Marshal.PtrToStringAnsi(valuePtr);
            }
            finally
            {
                Tizen.Multimedia.LibcSupport.Free(valuePtr);
            }
        }

        [DllImport(Libraries.MediaController, EntryPoint = "mc_metadata_clone")]
        internal static extern MediaControllerError CloneMetadata();

        [DllImport(Libraries.MediaController, EntryPoint = "mc_metadata_destroy")]
        internal static extern MediaControllerError DestroyMetadata(IntPtr metadata);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_metadata")]
        internal static extern MediaControllerError GetServerMetadata(MediaControllerClientHandle handle,
            string serverName, out IntPtr metadata);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_metadata_encode_season")]
        internal static extern MediaControllerError EncodeSeason(int number, string title, out string encoded);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_metadata_encode_episode")]
        internal static extern MediaControllerError EncodeEpisode(int number, string title, out string encoded);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_metadata_encode_resolution")]
        internal static extern MediaControllerError EncodeResolution(uint width, uint height, out string encoded);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_metadata_decode_season")]
        internal static extern MediaControllerError DecodeSeason(string season, out int number, out string title);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_metadata_decode_episode")]
        internal static extern MediaControllerError DecodeEpisode(string episode, out int number, out string title);


        [DllImport(Libraries.MediaController, EntryPoint = "mc_metadata_decode_resolution")]
        internal static extern MediaControllerError DecodeResolution(string episode, out uint width, out uint height);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_playlist_create")]
        internal static extern MediaControllerError CreatePlaylist(string name, out IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_playlist_destroy")]
        internal static extern MediaControllerError DestroyPlaylist(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_playlist_get_playlist")]
        internal static extern MediaControllerError GetPlaylistHandle(string name, string playlistName, out IntPtr playlistHandle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_playlist_clone")]
        internal static extern MediaControllerError ClonePlaylist(IntPtr source, IntPtr destination);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_playlist_update_item")]
        internal static extern MediaControllerError UpdatePlaylist(IntPtr handle, string index,
            MediaControllerNativeAttribute attribute, string value);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_foreach_server_playlist")]
        internal static extern MediaControllerError ForeachServerPlaylist(MediaControllerClientHandle handle,
            string serverName, PlaylistCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_playlist_item_index")]
        private static extern MediaControllerError GetPlaylistIndex(IntPtr playbackHandle, out IntPtr index);

        [Obsolete("Please do not use! This will be deprecated. Please use GetPlaylistInfo instead.")]
        internal static string GetPlaylistIndex(IntPtr playbackHandle)
        {
            IntPtr valuePtr = IntPtr.Zero;

            try
            {
                GetPlaylistIndex(playbackHandle, out valuePtr).ThrowIfError($"Failed to get playlist.");
                return Marshal.PtrToStringAnsi(valuePtr);
            }
            finally
            {
                Tizen.Multimedia.LibcSupport.Free(valuePtr);
            }
        }

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_playlist_item_info")]
        internal static extern MediaControllerError GetPlaylistInfo(IntPtr playbackHandle, out IntPtr playlistName, out IntPtr index);

        internal static (string name, string index) GetPlaylistInfo(IntPtr playbackHandle)
        {
            IntPtr playlistName = IntPtr.Zero;
            IntPtr index = IntPtr.Zero;

            try
            {
                GetPlaylistInfo(playbackHandle, out playlistName, out index).ThrowIfError($"Failed to get playlist info.");

                return (Marshal.PtrToStringAnsi(playlistName), Marshal.PtrToStringAnsi(index));
            }
            finally
            {
                Tizen.Multimedia.LibcSupport.Free(playlistName);
                Tizen.Multimedia.LibcSupport.Free(index);
            }
        }

        [DllImport(Libraries.MediaController, EntryPoint = "mc_playlist_get_name")]
        private static extern MediaControllerError GetPlaylistName(IntPtr handle, out IntPtr name);

        // It will be added next commit. Native Fw is not ready yet.
        //[DllImport(Libraries.MediaController, EntryPoint = "mc_playlist_set_name")]
        //internal static extern MediaControllerError SetPlaylistName(IntPtr handle, string name);

        internal static string GetPlaylistName(IntPtr handle)
        {
            IntPtr valuePtr = IntPtr.Zero;

            try
            {
                GetPlaylistName(handle, out valuePtr).ThrowIfError($"Failed to get playlist name.");
                return Marshal.PtrToStringAnsi(valuePtr);
            }
            finally
            {
                Tizen.Multimedia.LibcSupport.Free(valuePtr);
            }
        }

        [DllImport(Libraries.MediaController, EntryPoint = "mc_playlist_foreach_item")]
        internal static extern MediaControllerError ForeachPlaylistItem(IntPtr handle,
            PlaylistItemCallback callback, IntPtr userData);
    }
}
