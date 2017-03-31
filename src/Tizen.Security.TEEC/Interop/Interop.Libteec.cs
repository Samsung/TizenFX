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
        /// This function initializes a new TEE Context, forming a connection between this Client Application and the
        /// TEE identified by the string identifier name.
        /// The Client Application MAY pass name with a value of NULL, which means that the Implementation MUST
        /// select a default TEE to connect to. The supported name strings, the mapping of these names to a specific
        /// TEE, and the nature of the default TEE are implementation-defined.
        /// </summary>
        //TEEC_Result TEEC_InitializeContext(const char *name, TEEC_Context *context);
        [DllImport(Libraries.Libteec, EntryPoint = "TEEC_InitializeContext", CallingConvention = CallingConvention.Cdecl)]
        static public extern int InitializeContext(string name, ref TEEC_Context context);

        /// <summary>
        /// This function destroys an initialized TEE Context, closing the connection between the Client Application
        /// and the TEE. The Client Application MUST only call this function when all Sessions inside this TEE
        /// Context have been closed and all Shared Memory blocks have been released.
        /// The implementation of this function MUST NOT be able to fail; after this function returns the Client
        /// Application must be able to consider that the Context has been closed.
        /// The function implementation MUST do nothing if the value of the context pointer is NULL.
        /// </summary>
        //void TEEC_FinalizeContext(TEEC_Context *context);
        [DllImport(Libraries.Libteec, EntryPoint = "TEEC_FinalizeContext", CallingConvention = CallingConvention.Cdecl)]
        static public extern void FinalizeContext(ref TEEC_Context context);

        /// <summary>
        /// This function registers a block of existing Client Application memory as a block of Shared Memory within
        /// the scope of the specified TEE Context, in accordance with the parameters which have been set by the
        /// Client Application inside the sharedMem structure.
        /// The input context MUST point to an initialized TEE Context.
        /// The input sharedMem MUST point to the Shared Memory structure defining the memory region to register
        /// </summary>
        //EEC_Result TEEC_RegisterSharedMemory(TEEC_Context *context, TEEC_SharedMemory *sharedMem);
        [DllImport(Libraries.Libteec, EntryPoint = "TEEC_RegisterSharedMemory", CallingConvention = CallingConvention.Cdecl)]
        static public extern int RegisterSharedMemory(ref TEEC_Context context, ref TEEC_SharedMemory sharedMem);

        /// <summary>
        /// This function allocates a new block of memory as a block of Shared Memory within the scope of the
        /// specified TEE Context, in accordance with the parameters which have been set by the Client Application
        /// inside the sharedMem structure.
        /// The input context MUST point to an initialized TEE Context.
        /// The input sharedMem MUST point to the Shared Memory structure defining the region to allocate.
        /// </summary>
        //TEEC_Result TEEC_AllocateSharedMemory(TEEC_Context *context, TEEC_SharedMemory *sharedMem);
        [DllImport(Libraries.Libteec, EntryPoint = "TEEC_AllocateSharedMemory", CallingConvention = CallingConvention.Cdecl)]
        static public extern int AllocateSharedMemory(ref TEEC_Context context, ref TEEC_SharedMemory sharedMem);

        /// <summary>
        /// This function deregisters or deallocates a previously initialized block of Shared Memory.
        /// For a memory buffer allocated using AllocateSharedMemory the Implementation MUST free the
        /// underlying memory and the Client Application MUST NOT access this region after this function has been
        /// called. In this case the Implementation MUST set the buffer and size fields of the sharedMem
        /// structure to NULL and 0 respectively before returning.
        /// For memory registered using RegisterSharedMemory the implementation MUST deregister the
        /// underlying memory from the TEE, but the memory region will stay available to the Client Application for
        /// other purposes as the memory is owned by it.
        /// The implementation MUST do nothing if the value of the sharedMem parameter is NULL.
        /// </summary>
        //void TEEC_ReleaseSharedMemory(TEEC_SharedMemory *sharedMem);
        [DllImport(Libraries.Libteec, EntryPoint = "TEEC_ReleaseSharedMemory", CallingConvention = CallingConvention.Cdecl)]
        static public extern void ReleaseSharedMemory(ref TEEC_SharedMemory sharedMem);

        /// <summary>
        /// This function opens a new Session between the Client Application and the specified Trusted Application.
        /// The Implementation MUST assume that all fields of this session structure are in an undefined state.
        /// When this function returns TEEC_SUCCESS the Implementation MUST have populated this structure with
        /// any information necessary for subsequent operations within the Session.
        /// The target Trusted Application is identified by a UUID passed in the parameter destination.
        /// </summary>
        //TEEC_Result TEEC_OpenSession(TEEC_Context *context, TEEC_Session *session, const TEEC_UUID *destination, uint connectionMethod, const void *connectionData, TEEC_Operation *operation, uint *returnOrigin);
        [DllImport(Libraries.Libteec, EntryPoint = "TEEC_OpenSession", CallingConvention = CallingConvention.Cdecl)]
        static public extern int OpenSession(ref TEEC_Context context, ref TEEC_Session session, TEEC_UUID destination, uint connectionMethod, byte[] connectionData, ref TEEC_Operation operation, out uint returnOrigin);

        /// <summary>
        /// This function closes a Session which has been opened with a Trusted Application.
        /// All Commands within the Session MUST have completed before this function can be called.
        /// The Implementation MUST do nothing if the input session parameter is NULL.
        /// The implementation of this function MUST NOT be able to fail; after this function returns the Client
        /// Application must be able to consider that the Session has been closed.
        /// </summary>
        //void TEEC_CloseSession(TEEC_Session *session);
        [DllImport(Libraries.Libteec, EntryPoint = "TEEC_CloseSession", CallingConvention = CallingConvention.Cdecl)]
        static public extern void CloseSession(ref TEEC_Session session);

        /// <summary>
        /// This function invokes a Command within the specified Session.
        /// The parameter session MUST point to a valid open Session.
        /// The parameter commandID is an identifier that is used to indicate which of the exposed Trusted
        /// Application functions should be invoked. The supported command identifier values are defined by the
        /// Trusted Application‟s protocol.
        /// </summary>
        //TEEC_Result TEEC_InvokeCommand(TEEC_Session *session, uint commandID, TEEC_Operation *operation, uint *returnOrigin);
        [DllImport(Libraries.Libteec, EntryPoint = "TEEC_InvokeCommand", CallingConvention = CallingConvention.Cdecl)]
        static public extern int InvokeCommand(ref TEEC_Session session, uint commandID, ref TEEC_Operation operation, out uint returnOrigin);

        /// <summary>
        /// This function requests the cancellation of a pending open Session operation or a Command invocation
        /// operation. As this is a synchronous API, this function must be called from a thread other than the one
        /// executing the OpenSession or InvokeCommand function.
        /// This function just sends a cancellation signal to the TEE and returns immediately; the operation is not
        /// guaranteed to have been cancelled when this function returns. In addition, the cancellation request is just
        /// a hint; the TEE or the Trusted Application MAY ignore the cancellation request.
        /// </summary>
        //void TEEC_RequestCancellation(TEEC_Operation *operation);
        [DllImport(Libraries.Libteec, EntryPoint = "TEEC_RequestCancellation", CallingConvention = CallingConvention.Cdecl)]
        static public extern void RequestCancellation(ref TEEC_Operation operation);
    }
}
