/*
 *  Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License
 */

using System;
using System.Runtime.InteropServices;
//using Interop.Liibteec.Types;

internal static partial class Interop
{
    internal static partial class Libteec
    {
        /// <summary>
        /// This function initializes a new TEE Context, forming a connection between this client application and the
        /// TEE identified by the string identifier name.
        /// The client application may pass a name with a value of null, which means that the implementation must
        /// select a default TEE to connect to. The supported name strings, the mapping of these names to a specific
        /// TEE, and the nature of the default TEE are implementation-defined.
        /// </summary>
        //TEEC_Result TEEC_InitializeContext(const char *name, TEEC_Context *context);
        [DllImport(Libraries.Libteec, EntryPoint = "TEEC_InitializeContext", CallingConvention = CallingConvention.Cdecl)]
        static public extern int InitializeContext(string name, IntPtr context);

        /// <summary>
        /// This function destroys an initialized TEE Context, closing the connection between the client application
        /// and the TEE. The client application must only call this function when all sessions inside this TEE
        /// context have been closed and all shared memory blocks have been released.
        /// The implementation of this function must not fail; after this function returns, the client
        /// application must be able to consider that the context has been closed.
        /// The function implementation must do nothing if the value of the context pointer is null.
        /// </summary>
        //void TEEC_FinalizeContext(TEEC_Context *context);
        [DllImport(Libraries.Libteec, EntryPoint = "TEEC_FinalizeContext", CallingConvention = CallingConvention.Cdecl)]
        static public extern void FinalizeContext(IntPtr context);

        /// <summary>
        /// This function registers a block of existing client application memory as a block of shared memory within
        /// the scope of the specified TEE Context, in accordance with the parameters which have been set by the
        /// client application inside the shared memory structure.
        /// The input context must point to an initialized TEE Context.
        /// The input shared Memory must point to the shared memory structure defining the memory region to register.
        /// </summary>
        //EEC_Result TEEC_RegisterSharedMemory(TEEC_Context *context, TEEC_SharedMemory *sharedMem);
        [DllImport(Libraries.Libteec, EntryPoint = "TEEC_RegisterSharedMemory", CallingConvention = CallingConvention.Cdecl)]
        static public extern int RegisterSharedMemory(IntPtr context, ref TEEC_SharedMemory sharedMem);

        /// <summary>
        /// This function allocates a new block of memory as a block of shared memory within the scope of the
        /// specified TEE Context, in accordance with the parameters which have been set by the client application
        /// inside the shared memory structure.
        /// The input context must point to an initialized TEE Context.
        /// The input shared memory must point to the shared memory structure defining the region to allocate.
        /// </summary>
        //TEEC_Result TEEC_AllocateSharedMemory(TEEC_Context *context, TEEC_SharedMemory *sharedMem);
        [DllImport(Libraries.Libteec, EntryPoint = "TEEC_AllocateSharedMemory", CallingConvention = CallingConvention.Cdecl)]
        static public extern int AllocateSharedMemory(IntPtr context, ref TEEC_SharedMemory sharedMem);

        /// <summary>
        /// This function deregisters or deallocates a previously initialized block of the shared memory.
        /// For a memory buffer allocated using AllocateSharedMemory, the implementation must free the
        /// underlying memory and the client application must not access this region after this function has been
        /// called. In this case, the implementation must set the buffer and size fields of the shared memory
        /// structure to null and 0 respectively before returning.
        /// For memory registered using RegisterSharedMemory, the implementation must deregister the
        /// underlying memory from the TEE, but the memory region will stay available to the client application for
        /// other purposes as the memory is owned by it.
        /// The implementation must do nothing if the value of the shared memory parameter is null.
        /// </summary>
        //void TEEC_ReleaseSharedMemory(TEEC_SharedMemory *sharedMem);
        [DllImport(Libraries.Libteec, EntryPoint = "TEEC_ReleaseSharedMemory", CallingConvention = CallingConvention.Cdecl)]
        static public extern void ReleaseSharedMemory(ref TEEC_SharedMemory sharedMem);

        /// <summary>
        /// This function opens a new session between the client application and the specified trusted application.
        /// The implementation must assume that all fields of this session structure are in an undefined state.
        /// When this function returns TEEC_SUCCESS, the implementation must have populated this structure with
        /// any information necessary for subsequent operations within the session.
        /// The target trusted application is identified by the UUID passed in the parameter destination.
        /// </summary>
        //TEEC_Result TEEC_OpenSession(TEEC_Context *context, TEEC_Session *session, const TEEC_UUID *destination, uint connectionMethod, const void *connectionData, TEEC_Operation *operation, uint *returnOrigin);
        [DllImport(Libraries.Libteec, EntryPoint = "TEEC_OpenSession", CallingConvention = CallingConvention.Cdecl)]
        static public extern int OpenSession(IntPtr context, IntPtr session, ref TEEC_UUID destination, uint connectionMethod, byte[] connectionData, IntPtr operation, out uint returnOrigin);

        /// <summary>
        /// This function closes a session which has been opened with a trusted application.
        /// All commands within the session must have completed before this function can be called.
        /// The implementation must do nothing if the input session parameter is null.
        /// The implementation of this function must not fail; after this function returns, the Client
        /// Application must be able to consider that the session has been closed.
        /// </summary>
        //void TEEC_CloseSession(TEEC_Session *session);
        [DllImport(Libraries.Libteec, EntryPoint = "TEEC_CloseSession", CallingConvention = CallingConvention.Cdecl)]
        static public extern void CloseSession(IntPtr session);

        /// <summary>
        /// This function invokes a command within the specified session.
        /// The parameter session must point to a valid open session.
        /// The parameter commandID is an identifier that is used to indicate which of the exposed Trusted
        /// Application functions should be invoked. The supported command identifier values are defined by the
        /// trusted application's protocol.
        /// </summary>
        //TEEC_Result TEEC_InvokeCommand(TEEC_Session *session, uint commandID, TEEC_Operation *operation, uint *returnOrigin);
        [DllImport(Libraries.Libteec, EntryPoint = "TEEC_InvokeCommand", CallingConvention = CallingConvention.Cdecl)]
        static public extern int InvokeCommand(IntPtr session, uint commandID, IntPtr operation, out uint returnOrigin);

        /// <summary>
        /// This function requests the cancelation of a pending open session operation or a command invocation
        /// operation. As this is a synchronous API, this function must be called from a thread other than the one
        /// executing the OpenSession or InvokeCommand function.
        /// This function just sends a cancelation signal to the TEE and returns immediately; the operation is not
        /// guaranteed to have been canceled when this function returns. In addition, the cancelation request is just
        /// a hint; the TEE or the trusted application may ignore the cancelation request.
        /// </summary>
        //void TEEC_RequestCancellation(TEEC_Operation *operation);
        [DllImport(Libraries.Libteec, EntryPoint = "TEEC_RequestCancellation", CallingConvention = CallingConvention.Cdecl)]
        static public extern void RequestCancellation(IntPtr operation);
    }
}
