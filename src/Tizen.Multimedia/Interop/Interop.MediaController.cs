using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
	internal static partial class MediaControllerClient
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void ServerUpdatedCallback(string serverName, int serverState, IntPtr userData);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void PlaybackUpdatedCallback(string serverName, IntPtr playback, IntPtr userData);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void MetadataUpdatedCallback(string serverName, IntPtr metadata, IntPtr userData);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void ShuffleModeUpdatedCallback(string serverName, int shuffleMode, IntPtr userData);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RepeatModeUpdatedCallback(string serverName, int repeatMode, IntPtr userData);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void CommandReplyRecievedCallback(string serverName, int result, IntPtr bundleData, IntPtr userData);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate bool SubscribedServerCallback(string serverName, IntPtr userData);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate bool ActivatedServerCallback(string serverName, IntPtr userData);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_create")]
		internal static extern int Create(out IntPtr handle);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_destroy")]
		internal static extern int Destroy(IntPtr handle);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_server_update_cb")]
		internal static extern int SetServerUpdatedCb(IntPtr handle, ServerUpdatedCallback callback, IntPtr userData);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_server_update_cb")]
		internal static extern int UnsetServerUpdatedCb(IntPtr handle);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_playback_update_cb")]
		internal static extern int SetPlaybackUpdatedCb(IntPtr handle, PlaybackUpdatedCallback callback, IntPtr userData);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_playback_update_cb")]
		internal static extern int UnsetPlaybackUpdatedCb(IntPtr handle);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_metadata_update_cb")]
		internal static extern int SetMetadataUpdatedCb(IntPtr handle, MetadataUpdatedCallback callback, IntPtr userData);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_metadata_update_cb")]
		internal static extern int UnsetMetadataUpdatedCb(IntPtr handle);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_shuffle_mode_update_cb")]
		internal static extern int SetShuffleModeUpdatedCb(IntPtr handle, ShuffleModeUpdatedCallback callback, IntPtr userData);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_shuffle_mode_update_cb")]
		internal static extern int UnsetShuffleModeUpdatedCb(IntPtr handle);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_repeat_mode_update_cb")]
		internal static extern int SetRepeatModeUpdatedCb(IntPtr handle, RepeatModeUpdatedCallback callback, IntPtr userData);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_repeat_mode_update_cb")]
		internal static extern int UnsetRepeatModeUpdatedCb(IntPtr handle);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_subscribe")]
		internal static extern int Subscribe(IntPtr handle, int subscriptionType, string serverName);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_unsubscribe")]
		internal static extern int Unsubscribe(IntPtr handle, int subscriptionType, string serverName);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_playback_state")]
		internal static extern int GetPlaybackState(IntPtr playback, out int state);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_playback_position")]
		internal static extern int GetPlaybackPosition(IntPtr playback, out ulong position);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_destroy_playback")]
		internal static extern int DestroyPlayback(IntPtr playback);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_metadata")]
		internal static extern int GetMetadata(IntPtr metadata, int attribute, out string value);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_destroy_metadata")]
		internal static extern int DestroyMetadata(IntPtr metadata);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_latest_server_info")]
		internal static extern int GetLatestServer(IntPtr handle, out string serverName, out int serverState);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_playback_info")]
		internal static extern int GetServerPlayback(IntPtr handle, string serverName, out IntPtr playback);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_metadata")]
		internal static extern int GetServerMetadata(IntPtr handle, string serverName, out IntPtr metadata);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_shuffle_mode")]
		internal static extern int GetServerShuffleMode(IntPtr handle, string serverName, out int mode);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_repeat_mode")]
		internal static extern int GetServerRepeatMode(IntPtr handle, string serverName, out int mode);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_playback_state_command")]
		internal static extern int SendPlaybackStateCommand(IntPtr handle, string serverName, int state);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_custom_command")]
		internal static extern int SendCustomCommand(IntPtr handle, string serverName, string command, IntPtr bundle, CommandReplyRecievedCallback callback, IntPtr userData);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_foreach_server_subscribed")]
		internal static extern int ForeachSubscribedServer(IntPtr handle, int subscriptionType, SubscribedServerCallback callback, IntPtr userData);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_client_foreach_server")]
		internal static extern int ForeachActivatedServer(IntPtr handle, ActivatedServerCallback callback, IntPtr userData);
	}

	internal static partial class MediaControllerServer
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void PlaybackStateCommandRecievedCallback(string clientName, int state, IntPtr userData);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void CustomCommandRecievedCallback(string clientName, string command, IntPtr bundleData, IntPtr userData);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_server_create")]
		internal static extern int Create(out IntPtr handle);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_server_destroy")]
		internal static extern int Destroy(IntPtr handle);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_playback_state")]
		internal static extern int SetPlaybackState(IntPtr handle, int state);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_playback_position")]
		internal static extern int SetPlaybackPosition(IntPtr handle, ulong position);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_server_update_playback_info")]
		internal static extern int UpdatePlayback(IntPtr handle);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_metadata")]
		internal static extern int SetMetadata(IntPtr handle, int attribute, string value);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_server_update_metadata")]
		internal static extern int UpdateMetadata(IntPtr handle);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_server_update_shuffle_mode")]
		internal static extern int UpdateShuffleMode(IntPtr handle, int mode);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_server_update_repeat_mode")]
		internal static extern int UpdateRepeatMode(IntPtr handle, int mode);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_playback_state_command_received_cb")]
		internal static extern int SetPlaybackStateCmdRecvCb(IntPtr handle, PlaybackStateCommandRecievedCallback callback, IntPtr userData);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_server_unset_playback_state_command_received_cb")]
		internal static extern int UnsetPlaybackStateCmdRecvCb(IntPtr handle);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_custom_command_received_cb ")]
		internal static extern int SetCustomCmdRecvCb(IntPtr handle, CustomCommandRecievedCallback callback, IntPtr userData);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_server_unset_custom_command_received_cb ")]
		internal static extern int UnsetCustomCmdRecvCb(IntPtr handle);

		[DllImport(Libraries.MediaController, EntryPoint = "mc_server_send_command_reply ")]
		internal static extern int SendCommandReply(IntPtr handle, string clientName, int result, IntPtr bundleData);
	}
}
