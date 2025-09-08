/*
 * Copyright (c) 2024 Samsung Electronics Co., Ltd All Rights Reserved
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

using Tizen;
using Tizen.Internals.Errors;

internal static partial class Interop
{
    internal static partial class LibTizenCore
    {
        internal enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            InvalidContext = -0x01100000 | 0x01,
        }

        internal enum Priority
        {
            High = -100,
            Default = 0,
            HighIdle = 100,
            DefaultIdle = 200,
            Low = 300,
        }

        internal enum PollEvent
        {
            In = 0x0001,
            Pri = 0x0002,
            Out = 0x0004,
            Err = 0x0008,
            Hup = 0x0010,
            Nval = 0x0020,
        }

        internal static partial class TizenCore
        {
            // typedef void (*tizen_core_channel_receive_cb)(tizen_core_channel_object_h object, void *user_data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void ChannelReceiveCallback(IntPtr channelObject, IntPtr userData);

            // typedef bool (*tizen_core_task_cb)(void *user_data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate bool TaskCallback(IntPtr userData);

            // typedef bool (*tizen_core_source_prepare_cb)(tizen_core_source_h source, int *timeout, void *user_data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate bool SourcePrepareCallback(IntPtr source, out int timeout, IntPtr userData);

            // typedef bool (*tizen_core_source_check_cb)(tizen_core_source_h source, void *user_data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate bool SourceCheckCallback(IntPtr source, IntPtr userData);

            // typedef bool (*tizen_core_source_dispatch_cb)(tizen_core_source_h source, void *user_data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate bool SourceDispatchCallback(IntPtr source, IntPtr userData);

            // typedef void (*tizen_core_source_finalize_cb)(tizen_core_source_h source, void *user_data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void SourceFinalizeCallback(IntPtr source, IntPtr userData);

            // void tizen_core_init(void);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_init")]
            internal static extern void Init();

            // void tizen_core_shutdown(void);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_shutdown")]
            internal static extern void Shutdown();

            // bool tizen_core_ready(void);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_ready")]
            internal static extern bool Ready();

            // int tizen_core_task_create(const char *name, bool use_thread, tizen_core_task_h task);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_task_create")]
            internal static extern ErrorCode TaskCreate(string name, bool useThread, out IntPtr handle);

            // int tizen_core_task_destroy(tizen_core_task_h task);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_task_destroy")]
            internal static extern ErrorCode TaskDestroy(IntPtr handle);

            // int tizen_core_task_run(tizen_core_task_h task);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_task_run")]
            internal static extern ErrorCode TaskRun(IntPtr handle);

            // int tizen_core_task_is_running(tizen_core_task_h task, bool *running);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_task_is_running")]
            internal static extern ErrorCode TaskIsRunning(IntPtr handle, out bool running);

            // int tizen_core_task_quit(tizen_core_task_h task);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_task_quit")]
            internal static extern ErrorCode TaskQuit(IntPtr handle);

            // int tizen_core_task_get_tizen_core(tizen_core_task_h task, tizen_core_h *core);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_task_get_tizen_core")]
            internal static extern ErrorCode TaskGetTizenCore(IntPtr handle, out IntPtr coreHandle);

            // int tizen_core_find(const char *name, tizen_core_h *core);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_find")]
            internal static extern ErrorCode Find(string name, out IntPtr handle);

            // int tizen_core_find_from_this_thread(tizen_core_h *core);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_find_from_this_thread")]
            internal static extern ErrorCode FindFromThisThread(out IntPtr handle);

            // int tizen_core_add_idle_job(tizen_core_h core, tizen_core_task_cb callback, void *user_data, tizen_core_source_h *source);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_add_idle_job")]
            internal static extern ErrorCode AddIdleJob(IntPtr handle, TaskCallback callback, IntPtr userData, out IntPtr source);

            // int tizen_core_add_timer(tizen_core_h core, unsigned int interval, tizen_core_task_cb callback, void *user_data, tizen_core_source_h *source);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_add_timer")]
            internal static extern ErrorCode AddTimer(IntPtr handle, uint interval, TaskCallback callback, IntPtr userData, out IntPtr source);

            // int tizen_core_add_channel(tizen_core_h core, tizen_core_channel_receiver_h receiver, tizen_core_channel_receive_cb callback, void *user_data, tizen_core_source_h *source);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_add_channel")]
            internal static extern ErrorCode AddChannel(IntPtr handle, IntPtr channel, ChannelReceiveCallback callback, IntPtr userData, out IntPtr source);

            // int tizen_core_add_event(tizen_core_h core, tizen_core_event_h event, tizen_core_source_h *source);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_add_event")]
            internal static extern ErrorCode AddEvent(IntPtr handle, IntPtr eventHandle, out IntPtr source);

            // int tizen_core_emit_event(tizen_core_h core, tizen_core_event_object_h object);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_emit_event")]
            internal static extern ErrorCode EmitEvent(IntPtr handle, IntPtr eventObject);

            // int tizen_core_add_source(tizen_core_h core, tizen_core_source_h source);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_add_source")]
            internal static extern ErrorCode AddSource(IntPtr handle, IntPtr source);

            // int tizen_core_remove_source(tizen_core_h core, tizen_core_source_h source);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_remove_source")]
            internal static extern ErrorCode RemoveSource(IntPtr handle, IntPtr source);

            // int tizen_core_source_create(tizen_core_source_h *source);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_source_create")]
            internal static extern ErrorCode SourceCreate(out IntPtr source);

            // int tizen_core_source_destroy(tizen_core_source_h source);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_source_destroy")]
            internal static extern ErrorCode SourceDestroy(IntPtr source);

            // int tizen_core_source_add_poll(tizen_core_source_h source, tizen_core_poll_fd_h poll_fd);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_source_add_poll")]
            internal static extern ErrorCode SourceAddPoll(IntPtr source, IntPtr pollFd);

            // int tizen_core_source_remove_poll(tizen_core_source_h source, tizen_core_poll_fd_h poll_fd);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_source_remove_poll")]
            internal static extern ErrorCode SourceRemovePoll(IntPtr source, IntPtr pollFd);

            // int tizen_core_source_set_prepare_cb(tizen_core_source_h source, tizen_core_source_prepare_cb callback, void *user_data);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_source_set_prepare_cb")]
            internal static extern ErrorCode SourceSetPrepareCallback(IntPtr source, SourcePrepareCallback callback, IntPtr userData);

            // int tizen_core_source_set_check_cb(tizen_core_source_h source, tizen_core_source_check_cb callback, void *user_data);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_source_set_check_cb")]
            internal static extern ErrorCode SourceSetCheckCallback(IntPtr source, SourceCheckCallback callback, IntPtr userData);

            // int tizen_core_source_set_dispatch_cb(tizen_core_source_h source, tizen_core_source_dispatch_cb callback, void *user_data);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_source_set_dispatch_cb")]
            internal static extern ErrorCode SourceSetDispatchCallback(IntPtr source, SourceDispatchCallback callback, IntPtr userData);

            // int tizen_core_source_set_finalize_cb(tizen_core_source_h source, tizen_core_source_finalize_cb callback, void *user_data);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_source_set_finalize_cb")]
            internal static extern ErrorCode SourceSetFinalizeCallback(IntPtr source, SourceFinalizeCallback callback, IntPtr userData);

            // int tizen_core_source_set_priority(tizen_core_source_h source, tizen_core_priority_e priority);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_source_set_priority")]
            internal static extern ErrorCode SourceSetPriority(IntPtr source, int priority);

            // int tizen_core_poll_fd_create(tizen_core_poll_fd_h *poll_fd);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_poll_fd_create")]
            internal static extern ErrorCode PollFdCreate(out IntPtr handle);

            // int tizen_core_poll_fd_destroy(tizen_core_poll_fd_h poll_fd);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_poll_fd_destroy")]
            internal static extern ErrorCode PollFdDestroy(IntPtr handle);

            // int tizen_core_poll_fd_set_fd(tizen_core_poll_fd_h poll_fd, int fd);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_poll_fd_set_fd")]
            internal static extern ErrorCode PollFdSetFd(IntPtr handle, int fd);

            // int tizen_core_poll_fd_get_fd(tizen_core_poll_fd_h poll_fd, int *fd);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_poll_fd_get_fd")]
            internal static extern ErrorCode PollFdGetFd(IntPtr handle, out int fd);

            // int tizen_core_poll_fd_set_events(tizen_core_poll_fd_h poll_fd, uint16_t events);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_poll_fd_set_events")]
            internal static extern ErrorCode PollFdSetEvents(IntPtr handle, UInt16 events);

            // int tizen_core_poll_fd_get_events(tizen_core_poll_fd_h poll_fd, uint16_t *events);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_poll_fd_get_events")]
            internal static extern ErrorCode PollFdGetEvents(IntPtr handle, out UInt16 events);

            // int tizen_core_poll_fd_set_returned_events(tizen_core_poll_fd_h poll_fd, uint16_t returned_events);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_poll_fd_set_returned_events")]
            internal static extern ErrorCode PollFdSetReturnedEvents(IntPtr handle, UInt16 returnedEvents);

            // int tizen_core_poll_fd_get_events(tizen_core_poll_fd_h poll_fd, uint16_t *returned_events);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_poll_fd_get_returned_events")]
            internal static extern ErrorCode PollFdGetReturnedEvents(IntPtr handle, out UInt16 returnedEvents);
        }

        internal static partial class TizenCoreChannel
        {
            // int tizen_core_channel_make_pair(tizen_core_channel_sender_h *sender, tizen_core_channel_receiver_h *receiver);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_channel_make_pair")]
            internal static extern ErrorCode MakePair(out IntPtr sender, out IntPtr receiver);

            // int tizen_core_channel_sender_send(tizen_core_channel_sender_h sender, tizen_core_channel_object_h object);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_channel_sender_send")]
            internal static extern ErrorCode SenderSend(IntPtr sender, IntPtr channelObject);

            // int tizen_core_channel_sender_destroy(tizen_core_channel_sender_h sender);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_channel_sender_destroy")]
            internal static extern ErrorCode SenderDestroy(IntPtr sender);

            // int tizen_core_channel_sender_clone(tizen_core_channel_sender_h sender, tizen_core_channel_sender_h *cloned_sender);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_channel_sender_clone")]
            internal static extern ErrorCode SenderClone(IntPtr sender, out IntPtr clonedHandle);

            // int tizen_core_channel_receiver_receive(tizen_core_channel_receiver_h receiver, tizen_core_channel_object_h *object);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_channel_receiver_receive")]
            internal static extern ErrorCode ReceiverReceive(IntPtr receiver, out IntPtr channelObject);

            // int tizen_core_channel_receiver_destroy(tizen_core_channel_receiver_h receiver);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_channel_receiver_destroy")]
            internal static extern ErrorCode ReceiverDestroy(IntPtr receiver);

            // int tizen_core_channel_object_create(tizen_core_channel_object_h *object);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_channel_object_create")]
            internal static extern ErrorCode ObjectCreate(out IntPtr handle);

            // int tizen_core_channel_object_destroy(tizen_core_channel_object_h object);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_channel_object_destroy")]
            internal static extern ErrorCode ObjectDestroy(IntPtr handle);

            // int tizen_core_channel_object_set_id(tizen_core_channel_object_h object, int id);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_channel_object_set_id")]
            internal static extern ErrorCode ObjectSetId(IntPtr handle, int id);

            // int tizen_core_channel_object_get_id(tizen_core_channel_object_h object, int *id);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_channel_object_get_id")]
            internal static extern ErrorCode ObjectGetId(IntPtr handle, out int id);

            // int tizen_core_channel_object_set_data(tizen_core_channel_object_h object, void *data);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_channel_object_set_data")]
            internal static extern ErrorCode ObjectSetData(IntPtr handle, IntPtr data);

            // int tizen_core_channel_object_get_data(tizen_core_channel_object_h object, void **data);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_channel_object_get_data")]
            internal static extern ErrorCode ObjectGetData(IntPtr handle, out IntPtr data);

            // int tizen_core_channel_object_get_sender_task_name(tizen_core_channel_object_h object, const char **task_name);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_channel_object_get_sender_task_name")]
            internal static extern ErrorCode ObjectGetSenderTaskName(IntPtr handle, out IntPtr taskName);
        }

        internal static partial class TizenCoreEvent
        {
            // typedef bool (*tizen_core_event_handler_cb)(tizen_core_event_object_h object, void *user_data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate bool EventHandlerCallback(IntPtr eventObject, IntPtr userData);

            // typedef void (*tizen_core_event_object_destroy_cb)(void *event_data, void *user_data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void EventObjectDestroyCallback(IntPtr eventData, IntPtr userData);

            // int tizen_core_event_create(tizen_core_event_h *event);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_event_create")]
            internal static extern ErrorCode Create(out IntPtr handle);

            // int tizen_core_event_destroy(tizen_core_event_h event);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_event_destroy")]
            internal static extern ErrorCode Destroy(IntPtr handle);

            // int tizen_core_event_add_handler(tizen_core_event_h event, tizen_core_event_handler_cb handler, void *user_data, tizen_core_event_handler_h *event_handler);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_event_add_handler")]
            internal static extern ErrorCode AddHandler(IntPtr handle, EventHandlerCallback callback, IntPtr userData, out IntPtr eventHandler);

            // int tizen_core_event_prepend_handler(tizen_core_event_h event, tizen_core_event_handler_cb handler, void *user_data, tizen_core_event_handler_h *event_handler);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_event_prepend_handler")]
            internal static extern ErrorCode PrependHandler(IntPtr handle, EventHandlerCallback callback, IntPtr userData, out IntPtr eventHandler);

            // int tizen_core_event_remove_handler(tizen_core_event_h event, tizen_core_event_handler_h event_handler);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_event_remove_handler")]
            internal static extern ErrorCode RemoveHandler(IntPtr handle, IntPtr eventHandler);

            // int tizen_core_event_emit(tizen_core_event_h event, tizen_core_event_object_h object);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_event_emit")]
            internal static extern ErrorCode Emit(IntPtr handle, IntPtr eventObject);

            // int tizen_core_event_object_create(tizen_core_event_object_h *object, int id, void *data);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_event_object_create")]
            internal static extern ErrorCode ObjectCreate(out IntPtr handle, int id, IntPtr data);

            // int tizen_core_event_object_destroy(tizen_core_event_object_h object);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_event_object_destroy")]
            internal static extern ErrorCode ObjectDestroy(IntPtr handle);

            // int tizen_core_event_object_set_destroy_cb(tizen_core_event_object_h object, tizen_core_event_object_destroy_cb callback, void *user_data);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_event_object_set_destroy_cb")]
            internal static extern ErrorCode ObjectSetDestroyCallback(IntPtr handle, EventObjectDestroyCallback callback, IntPtr userData);

            // int tizen_core_event_object_get_id(tizen_core_event_object_h object, int *id);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_event_object_get_id")]
            internal static extern ErrorCode ObjectGetId(IntPtr handle, out int id);

            // int tizen_core_event_object_get_data(tizen_core_event_object_h object, void *data);
            [DllImport(Libraries.TizenCore, EntryPoint = "tizen_core_event_object_get_data")]
            internal static extern ErrorCode ObjectGetData(IntPtr handle, out IntPtr data);
        }
    }
}
