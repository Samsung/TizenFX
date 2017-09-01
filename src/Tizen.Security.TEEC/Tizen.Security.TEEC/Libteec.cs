/*
 *  Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Tizen.Security.TEEC
{
    /// <summary>
    /// This type denotes the Session Login Method used in OpenSession.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class LoginMethod
    {
        /// <summary>No login data is provided.</summary>
        public const uint Public      = 0x00000000;
        /// <summary>Login data about the user running the client application process is provided.</summary>
        public const uint User        = 0x00000001;
        /// <summary>Login data about the group running the client application process is provided.</summary>
        public const uint Group       = 0x00000002;
        /// <summary>Login data about the running client application itself is provided.</summary>
        public const uint Application = 0x00000003;
    }

    /// <summary>
    /// This type denotes the Value parameter.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum TEFValueType : UInt32
    {
        /// <summary>The parameter is a ValueType tagged as the input.</summary>
        Input  = 0x00000001,
        /// <summary>The parameter is a ValueType tagged as the output.</summary>
        Output = 0x00000002,
        /// <summary>The parameter is a ValueType tagged as both the input and the output.</summary>
        InOut  = 0x00000003,
    }

    /// <summary>
    /// This type denotes the TempMemoryReference parameter
    /// describing a region of memory which needs to be temporarily registered for the duration of the operation.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum TEFTempMemoryType : UInt32
    {
        /// <summary>The parameter is a TempMemoryType and is tagged as the input.</summary>
        Input  = 0x00000005,
        /// <summary>Same as the input, but the Memory Reference is tagged as the output.</summary>
        Output = 0x00000006,
        /// <summary>A Temporary Memory Reference tagged as both the input and the output.</summary>
        InOut  = 0x00000007,
    }

    /// <summary>
    /// This type denotes the SharedMemoryReference parameter.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum TEFRegisteredMemoryType : UInt32
    {
        /// <summary>The parameter is a registered memory reference that refers to the entirety of its parent shared memory block.</summary>
        Whole         = 0x0000000C,
        /// <summary>A registered memory reference structure that refers to a partial region of its parent shared mMemory block and is tagged as the input.</summary>
        PartialInput  = 0x0000000D,
        /// <summary>A registered memory reference structure that refers to a partial region of its parent shared memory block and is tagged as the output.</summary>
        PartialOutput = 0x0000000E,
        /// <summary>A registered memory reference structure that refers to a partial region of its parent shared memory block and is tagged as both the input and the output.</summary>
        PartialInOut  = 0x0000000F,
    }

    /// <summary>
    /// This type denotes the SharedMemory access direction.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Flags]
    public enum SharedMemoryFlags : UInt32
    {
        /// <summary>A flag indicates the shared memory can be read.</summary>
        Input  = 0x00000001,
        /// <summary>A flag indicates the shared memory can be written.</summary>
        Output = 0x00000002,
        /// <summary>A flag indicates the shared memory can be read and written.</summary>
        InOut = Input | Output,
    }

    /// <summary>
    /// This type denotes a shared memory block which has been either registered
    /// with the implementation or allocated by it.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class SharedMemory
    {
        internal Interop.TEEC_SharedMemory shm;
        internal SharedMemory(Interop.TEEC_SharedMemory shm)
        {
            this.shm=shm;
        }
        /// <summary>
        /// This property represents the shared memory size in bytes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public UInt32 Size
        {
            get { return shm.size; }
        }
        /// <summary>
        /// This property represents the start address of the shared memory block.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public IntPtr Address
        {
            get { return shm.buffer; }
        }

        /// <summary>
        /// This function makes a copy and is designed for convenient operations on small buffers.
        /// For large buffers, the direct address should be used.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="data">The source data buffer to copy data from.</param>
        /// <param name="dstOffs">The starting offset in the destination shared memory.</param>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        public void SetData(byte[] data, int dstOffs)
        {
            if ((shm.flags & (uint)SharedMemoryFlags.Output) == 0) throw new InvalidOperationException("No write access");
            Marshal.Copy(data, 0, shm.buffer + dstOffs, data.Length);
        }
        /// <summary>
        /// This function makes a copy and is designed for convenient operations on small buffers.
        /// For large buffers, the direct address should be used.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="data">The destination data buffer to copy data into.</param>
        /// <param name="srcOffs">The starting offset in the source shared memory.</param>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        public void GetData(byte[] data, int srcOffs)
        {
            if ((shm.flags & (uint)SharedMemoryFlags.Input) == 0) throw new InvalidOperationException("No read access");
            Marshal.Copy(shm.buffer + srcOffs, data, 0, data.Length);
        }
    };

    /// <summary>
    /// This type defines the payload of either an open session operation or an invoke command operation. It is
    /// also used for cancelation of operations, which may be desirable even if no payload is passed.
    /// Parameters are used to exchange data between CA and TA.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public abstract class Parameter
    {
        internal Parameter(uint t)
        {
            this.NativeType = t;
        }
        internal uint NativeType { get; }
    };

    /// <summary>
    /// This type defines a template for the parameter types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public abstract class BaseParameter<TEnum> : Parameter where TEnum : struct, IComparable, IFormattable, IConvertible // as close to Enum as possible
    {
        internal BaseParameter(TEnum t) : base((uint)(object)t)
        {
            Type = t;
        }

        /// <summary>
        /// This property represents the access type to this parameter.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public TEnum Type { get; }
    }

    /// <summary>
    /// This type defines a temporary memory reference.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class TempMemoryReference : BaseParameter<TEFTempMemoryType>
    {
        /// <summary>
        /// Constructs a parameter object which holds information about the temporary memory copied to or from TA.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="buffer">The address of the allocated memory buffer.</param>
        /// <param name="size">The size of the buffer.</param>
        /// <param name="type">The kind of access allowed for TA <see cref="TEFTempMemoryType"/>.</param>
        public TempMemoryReference(IntPtr buffer, uint size, TEFTempMemoryType type) :
                base(type)
        {
            this.Buffer = buffer;
            this.Size = size;
        }
        /// <summary>
        /// This property represents the memory address of the buffer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public IntPtr Buffer { get; }
        /// <summary>
        /// This property represents the size of the buffer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint Size { get; }
    };

    /// <summary>
    /// This type defines a memory reference that uses a pre-registered or pre-allocated shared memory block.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class RegisteredMemoryReference : BaseParameter<TEFRegisteredMemoryType>
    {
        /// <summary>
        /// Constructs a parameter object which holds information about the registered memory shared with TA.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="parent">The shared memory - registered or allocated.</param>
        /// <param name="size">The size of the buffer part.</param>
        /// <param name="offset">The offset of the buffer in the shared memory.</param>
        /// <param name="type">The kind of access allowed for TA <see cref="TEFRegisteredMemoryType"/>.</param>
        public RegisteredMemoryReference(SharedMemory parent, uint size, uint offset, TEFRegisteredMemoryType type) :
                base(type)
        {
            this.Parent = parent;
            this.Size = size;
            this.Offset = offset;
        }
        /// <summary>
        /// This property represents the shared memory that is referred to.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public SharedMemory Parent { get; }
        /// <summary>
        /// This property represents the size (in bytes) of the shared memory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint Size { get; }
        /// <summary>
        /// This property represents the offset (in bytes) from the start of the shared memory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint Offset { get; }
    };

    /// <summary>
    /// This type defines a parameter that is not referencing the shared memory, but carries instead small raw data
    /// passed by a value.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class Value : BaseParameter<TEFValueType>
    {
        /// <summary>
        /// Constructs a parameter object which holds information about integer values copied to or from TA.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="a">User paramter A.</param>
        /// <param name="b">User paramter B.</param>
        /// <param name="type">The kind of access allowed for TA <see cref="TEFValueType"/>.</param>
        public Value(uint a, uint b, TEFValueType type) :
                base(type)
        {
            this.A = a;
            this.B = b;
        }
        /// <summary>
        /// This property represents an unsigned integer A.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint A { get; }
        /// <summary>
        /// This property represents an unsigned integer B.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint B { get; }
    };


    /// <summary>
    /// This type denotes a TEE Session, the logical container linking a client application with a particular trusted application.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class Session
    {
        private Interop.TEEC_Context context;
        private Interop.TEEC_Session session;

        internal Session(Interop.TEEC_Context context) {
            this.context = context;
            this.session = new Interop.TEEC_Session();
        }

        ~Session()
        {
            Close();
        }

        internal void Open(Guid destination, uint loginMethod, byte[] connectionData, Parameter[] paramlist)
        {
            Interop.TEEC_UUID uuid = new Interop.TEEC_UUID();
            Interop.TEEC_Operation op = new Interop.TEEC_Operation();
            uint ro;

            int ret = Interop.Libteec.OpenSession(ref context, ref session, uuid, loginMethod, connectionData, ref op, out ro);
            //MAYBE map origin of return code to specyfic Exception
            Interop.CheckNThrowException(ret, string.Format("OpenSession('{0}')", destination));
        }

        /// <summary>
        /// This function closes a session which has been opened with a trusted application.
        /// All commands within the session must be completed before this function can be called.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <feature>http://tizen.org/feature/security.tee</feature>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        public void Close() {
            Interop.Libteec.CloseSession(ref session);
            //session = null;
        }

        /// <summary>
        /// This function invokes a command within the specified session.
        /// The parameter commandID is an identifier that is used to indicate which of the exposed trusted
        /// application functions should be invoked. The supported command identifier values are defined by the
        /// trusted application's protocol.
        /// There can be up to four parameter objects given in the <paramref name="paramlist"/> array.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="commandID">The command.</param>
        /// <param name="paramlist">The array of parameters.</param>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <feature>http://tizen.org/feature/security.tee</feature>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        /// <exception cref="ArgumentException">The argument <paramref name="paramlist"/> is wrong.</exception>
        public void InvokeCommand(uint commandID, Parameter[] paramlist)
        {
            Interop.TEEC_Operation op = new Interop.TEEC_Operation();
            op.started=0;
            op.paramTypes=0;

            for (int i=0; i < 4; ++i) {
                Parameter p = paramlist[i];
                //TODO fill TEEC_Operation struct
            }

            uint ro;
            int ret = Interop.Libteec.InvokeCommand(ref session, commandID, ref op, out ro);
            //MAYBE map origin of return code to specific Exception
            Interop.CheckNThrowException(ret, string.Format("InvokeCommand({0})", commandID));
        }

        /// <summary>
        /// The asynchronous version of the InvokeCommand.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="commandID">The command.</param>
        /// <param name="paramlist">The array of parameters.</param>
        /// <param name="token">The token for task manipulation.</param>
        /// <returns>Returns a task executing an invoke command in the background.</returns>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <feature>http://tizen.org/feature/security.tee</feature>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        /// <exception cref="ArgumentException">One of the arguments is wrong.</exception>
        public async Task InvokeCommandAsync(uint commandID, Parameter[] paramlist, CancellationToken token = default(CancellationToken))
        {
            await Task.Factory.StartNew(() => InvokeCommand(commandID, paramlist));
        }

    };

    /// <summary>
    /// This type denotes a TEE Context, the main logical container linking a Client Application with a particular TEE.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public sealed class Context : IDisposable
    {
        private Interop.TEEC_Context context;

        /// <summary>
        /// This function (constructor) initializes a new TEE Context, forming a connection between this client application and the
        /// TEE identified by the string identifier name (empty or null name denotes a default TEE).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="name">The TEE name.</param>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <feature>http://tizen.org/feature/security.tee</feature>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        public Context(string name)
        {
            context = new Interop.TEEC_Context();
            if (name != null && name.Length == 0)
                name = null;
            int ret = Interop.Libteec.InitializeContext(name, ref context);
            Interop.CheckNThrowException(ret, string.Format("InititalizeContext('{0}')", name));
        }

        ~Context()
        {
            Dispose();
        }

        /// <summary>
        /// This function implements the IDisposable interface.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <feature>http://tizen.org/feature/security.tee</feature>
        public void Dispose() {
            Interop.Libteec.FinalizeContext(ref context);
            //context.imp = null;
        }

        /// <summary>
        /// This function opens a new session between the client application and the specified trusted application.
        /// The target trusted application is identified by an UUID passed in the parameter destination.
        /// There can be up to four parameter objects given in the <paramref name="paramlist"/> array.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="destination">The UUID of the destination TA.</param>
        /// <param name="loginMethod">The authentication algorithm <see cref="LoginMethod" />.</param>
        /// <param name="connectionData">The data to be verified by a given login method.</param>
        /// <param name="paramlist">The parameters to be passed to TA open-session-callback.</param>
        /// <returns>Returns opened session.</returns>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <feature>http://tizen.org/feature/security.tee</feature>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        /// <exception cref="ArgumentException">One of the arguments is wrong.</exception>
        public Session OpenSession(Guid destination, uint loginMethod, byte[] connectionData, Parameter[] paramlist)
        {
            Session ses = new Session(context);
            ses.Open(destination, loginMethod, connectionData, paramlist);
            return ses;
        }
        /// <summary>
        /// @see OpenSession (Guid destination, uint connectionMethod, byte[] connectionData, Parameter[] paramlist, CancellationToken token).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="destination">The UUID of the destination TA.</param>
        /// <returns>Returns opened session.</returns>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <feature>http://tizen.org/feature/security.tee</feature>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        public Session OpenSession(Guid destination)
        {
            Session ses = new Session(context);
            ses.Open(destination, LoginMethod.Public, null, null);
            return ses;
        }

        /// <summary>
        /// The asynchronous version of the OpenSession.
        /// @see OpenSession (Guid destination, uint connectionMethod, byte[] connectionData, Parameter[] paramlist, CancellationToken token).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="destination">The UUID of the destination TA.</param>
        /// <param name="loginMethod">The authentication algorithm <see cref="LoginMethod" />.</param>
        /// <param name="connectionData">The data to be verified by a given login method.</param>
        /// <param name="paramlist">The parameters to be passed to the TA open-session-callback.</param>
        /// <param name="token">The token for the task manipulation.</param>
        /// <returns>Returns a Task executing the session open in the background.</returns>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <feature>http://tizen.org/feature/security.tee</feature>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        /// <exception cref="ArgumentException">One of the arguments is wrong.</exception>
        public async Task<Session> OpenSessionAsync(Guid destination, uint loginMethod, byte[] connectionData, Parameter[] paramlist, CancellationToken token = default(CancellationToken))
        {
            Task<Session> task = Task<Session>.Factory.StartNew(() =>
            {
                return OpenSession(destination, loginMethod, connectionData, paramlist);
            });
            return await task;
        }
        /// <summary>
        /// The asynchronous version of the OpenSession.
        /// @see OpenSession (Guid destination, uint connectionMethod, byte[] connectionData, Parameter[] paramlist, CancellationToken token).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="destination">The UUID of the destination TA.</param>
        /// <param name="token">The token for a task manipulation.</param>
        /// <returns>Returns a task executing session open in the background.</returns>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <feature>http://tizen.org/feature/security.tee</feature>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        public async Task<Session> OpenSessionAsync(Guid destination, CancellationToken token = default(CancellationToken))
        {
            Task<Session> task = Task<Session>.Factory.StartNew(() =>
            {
                return OpenSession(destination);
            });
            return await task;
        }

        /// <summary>
        /// This function registers a block of the existing client application memory as a block of shared memory within
        /// the scope of the specified context, in accordance with the parameters.
        /// The input <paramref name="memaddr"/> must point to the shared memory region to register.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="memaddr">The address of the shared memory.</param>
        /// <param name="size">The size of the shared memory.</param>
        /// <param name="flags">The flags describing the access modes (Input and/or Output).</param>
        /// <returns>Returns the SharedMemory handler.</returns>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <feature>http://tizen.org/feature/security.tee</feature>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        /// <exception cref="ArgumentException">The argument <paramref name="memaddr"/> is wrong.</exception>
        public SharedMemory RegisterSharedMemory(IntPtr memaddr, UInt32 size, SharedMemoryFlags flags)
        {
            Interop.TEEC_SharedMemory shm = new Interop.TEEC_SharedMemory();
            shm.buffer = memaddr;
            shm.size = size;
            shm.flags = (UInt32)flags;
            int ret = Interop.Libteec.RegisterSharedMemory(ref context, ref shm);
            Interop.CheckNThrowException(ret, "RegisterSharedMemory");
            return new SharedMemory(shm);
        }

        /// <summary>
        /// This function allocates a new block of memory as a block of shared memory within the scope of the
        /// specified context, in accordance with the parameters.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="size">The size of shared memory.</param>
        /// <param name="flags">The flags describing access modes (Input and/or Output).</param>
        /// <returns>Returns the Shared Memory handler.</returns>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <feature>http://tizen.org/feature/security.tee</feature>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        public SharedMemory AllocateSharedMemory(UInt32 size, SharedMemoryFlags flags)
        {
            Interop.TEEC_SharedMemory shm = new Interop.TEEC_SharedMemory();
            shm.size = size;
            shm.flags = (UInt32)flags;
            int ret = Interop.Libteec.AllocateSharedMemory(ref context, ref shm);
            Interop.CheckNThrowException(ret, "AllocateSharedMemory");
            return new SharedMemory(shm);
        }

        /// <summary>
        /// This function deregisters or deallocates a previously initialized block of the shared memory.
        /// </summary>
        /// <remarks>
        /// For a memory buffer allocated using AllocateSharedMemory, the implementation must free the
        /// underlying memory and the client application must not access this region after this function has been
        /// called. In this case, the implementation must clear the buffer and size fields of the shared memory
        /// structure before returning.
        /// For memory registered using RegisterSharedMemory, the implementation must deregister the
        /// underlying memory from the TEE, but the memory region will stay available to the client application for
        /// other purposes as the memory is owned by it.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="shm">The shared memory object returned by RegisterSharedMemory or AllocateSharedMemory.</param>
        /// <privilege>http://tizen.org/privilege/tee.client</privilege>
        /// <privlevel>partner</privlevel>
        /// <feature>http://tizen.org/feature/security.tee</feature>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The operation is invalid.</exception>
        /// <exception cref="ArgumentException">The argument is wrong.</exception>
        public void ReleaseSharedMemory(SharedMemory shm)
        {
            Interop.Libteec.ReleaseSharedMemory(ref shm.shm);
        }
    };
}
