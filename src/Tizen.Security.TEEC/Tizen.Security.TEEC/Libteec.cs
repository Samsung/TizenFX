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
using System.Threading;
using System.Threading.Tasks;

namespace Tizen.Security.TEEC
{
    /// <summary>
    /// This type denotes Session Login Method used in OpenSession
    /// </summary>
    public class LoginMethod
    {
        /// <summary>No login data is provided.</summary>
        public const uint Public      = 0x00000000;
        /// <summary>Login data about the user running the Client Application process is provided.</summary>
        public const uint User        = 0x00000001;
        /// <summary>Login data about the group running the Client Application process is provided.</summary>
        public const uint Group       = 0x00000002;
        /// <summary>Login data about the running Client Application itself is provided.</summary>
        public const uint Application = 0x00000003;
    }

    /// <summary>
    /// This type denotes Value parameter
    /// </summary>
    public enum TEFValueType : UInt32
    {
        /// <summary>The Parameter is a ValueType tagged as input.</summary>
        Input  = 0x00000001,
        /// <summary>The Parameter is a ValueType tagged as output.</summary>
        Output = 0x00000002,
        /// <summary>The Parameter is a ValueType tagged as both as input and output.</summary>
        InOut  = 0x00000003,
    }

    /// <summary>
    /// This type denotes TempMemoryReference parameter
    /// describing a region of memory which needs to be temporarily registered for the duration of the operation.
    /// </summary>
    public enum TEFTempMemoryType : UInt32
    {
        /// <summary>The Parameter is a TempMemoryType and is tagged as input.</summary>
        Input  = 0x00000005,
        /// <summary>Same as Input, but the Memory Reference is tagged as output.</summary>
        Output = 0x00000006,
        /// <summary>A Temporary Memory Reference tagged as both input and output.</summary>
        InOut  = 0x00000007,
    }

    /// <summary>
    /// This type denotes SharedMemoryReference parameter
    /// </summary>
    public enum TEFRegisteredMemoryType : UInt32
    {
        /// <summary>The Parameter is a Registered Memory Reference that refers to the entirety of its parent Shared Memory block.</summary>
        Whole         = 0x0000000C,
        /// <summary>A Registered Memory Reference structure that refers to a partial region of its parent Shared Memory block and is tagged as input.</summary>
        PartialInput  = 0x0000000D,
        /// <summary>A Registered Memory Reference structure that refers to a partial region of its parent Shared Memory block and is tagged as output.</summary>
        PartialOutput = 0x0000000E,
        /// <summary>A Registered Memory Reference structure that refers to a partial region of its parent Shared Memory block and is tagged as both input and output.</summary>
        PartialInOut  = 0x0000000F,
    }

    /// <summary>
    /// This type denotes SharedMemory access direction
    /// </summary>
    [Flags]
    public enum SharedMemoryFlags : UInt32
    {
        /// <summary>A flag indicates Shared Memory can be read.</summary>
        Input  = 0x00000001,
        /// <summary>A flag indicates Shared Memory can be written.</summary>
        Output = 0x00000002,
    }

    /// <summary>
    /// This type denotes a Shared Memory block which has either been registered
    /// with the implementation or allocated by it.
    /// </summary>
    public sealed class SharedMemory
    {
        internal Interop.TEEC_SharedMemory shm;
        internal SharedMemory(Interop.TEEC_SharedMemory shm)
        {
            this.shm=shm;
        }
        /// <summary>
        /// This property represents shared memory size in bytes.
        /// </summary>
        public UInt32 Size
        {
            get { return shm.size; }
        }
        /// <summary>
        /// This property represents start address of shared memory block.
        /// </summary>
        public IntPtr Address
        {
            get { return shm.buffer; }
        }

        /// <summary>
        /// This function makes a copy and is designed for convenient operations on small buffers.
        /// For large buffers direct address should be used.
        /// </summary>
        public void SetData(byte[] data, int dstOffs)
        {
            //TODO copy data into shared memory starting at given offset
        }
        /// <summary>
        /// This function makes a copy and is designed for convenient operations on small buffers.
        /// For large buffers direct address should be used.
        /// </summary>
        public void GetData(byte[] data, int srcOffs)
        {
            //TODO copy data from shared memory starting at given offset
        }
    };

    /// <summary>
    /// This type defines the payload of either an open Session operation or an invoke Command operation. It is
    /// also used for cancellation of operations, which may be desirable even if no payload is passed.
    /// Parameters are used to exchange data between CA and TA
    /// </summary>
    public abstract class Parameter
    {
        internal Parameter(uint t)
        {
            this.NativeType = t;
        }
        internal uint NativeType { get; }
    };

    /// <summary>
    /// This type defines a template for parameter types.
    /// </summary>
    public abstract class BaseParameter<TEnum> : Parameter where TEnum : struct, IComparable, IFormattable, IConvertible // as close to Enum as possible
    {
        internal BaseParameter(TEnum t) : base((uint)(object)t)
        {
            Type = t;
        }

        /// <summary>
        /// This property represents access type to this parameter.
        /// </summary>
        public TEnum Type { get; }
    }

    /// <summary>
    /// This type defines a temporary memory reference.
    /// </summary>
    public sealed class TempMemoryReference : BaseParameter<TEFTempMemoryType>
    {
        public TempMemoryReference(IntPtr buffer, uint size, TEFTempMemoryType type) :
                base(type)
        {
            this.Buffer = buffer;
            this.Size = size;
        }
        /// <summary>
        /// This property represents memory address of buffer.
        /// </summary>
        public IntPtr Buffer { get; }
        /// <summary>
        /// This property represents size of buffer.
        /// </summary>
        public uint Size { get; }
    };

    /// <summary>
    /// This type defines a memory reference that uses a pre-registered or pre-allocated Shared Memory block.
    /// </summary>
    public sealed class RegisteredMemoryReference : BaseParameter<TEFRegisteredMemoryType>
    {
        public RegisteredMemoryReference(SharedMemory parent, uint size, uint offset, TEFRegisteredMemoryType type) :
                base(type)
        {
            this.Parent = parent;
            this.Size = size;
            this.Offset = offset;
        }
        /// <summary>
        /// This property represents SharedMemory that is referred to.
        /// </summary>
        public SharedMemory Parent { get; }
        /// <summary>
        /// This property represents size (in bytes) of SharedMemory.
        /// </summary>
        public uint Size { get; }
        /// <summary>
        /// This property represents offset (in bytes) from the begin of SharedMemory.
        /// </summary>
        public uint Offset { get; }
    };

    /// <summary>
    /// This type defines a parameter that is not referencing shared memory, but carries instead small raw data
    /// passed by value.
    /// </summary>
    public sealed class Value : BaseParameter<TEFValueType>
    {
        public Value(uint a, uint b, TEFValueType type) :
                base(type)
        {
            this.A = a;
            this.B = b;
        }
        /// <summary>
        /// This property represents unsigned integer A.
        /// </summary>
        public uint A { get; }
        /// <summary>
        /// This property represents unsigned integer B.
        /// </summary>
        public uint B { get; }
    };


    /// <summary>
    /// This type denotes a TEE Session, the logical container linking a Client Application with a particular Trusted Application.
    /// </summary>
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
        /// This function closes a Session which has been opened with a Trusted Application.
        /// All Commands within the Session MUST have completed before this function can be called.
        /// </summary>
        public void Close() {
            Interop.Libteec.CloseSession(ref session);
            //session = null;
        }

        /// <summary>
        /// This function invokes a Command within the specified Session.
        /// The parameter commandID is an identifier that is used to indicate which of the exposed Trusted
        /// Application functions should be invoked. The supported command identifier values are defined by the
        /// Trusted Application‟s protocol.
        /// There can be up to four Parameter objects given in the {paramlist} array
        /// </summary>
        /// <param name="commandID">The command</param>
        /// <param name="paramlist">The array of parameters</param>
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
        /// Asynchronous version of InvokeCommand
        /// </summary>
        /// <param name="commandID">The command</param>
        /// <param name="paramlist">The array of parameters</param>
        /// <param name="token">The token for task manipulation</param>
        public async Task InvokeCommandAsync(uint commandID, Parameter[] paramlist, CancellationToken token = default(CancellationToken))
        {
            await Task.Factory.StartNew(() => InvokeCommand(commandID, paramlist));
        }

    };

    /// <summary>
    /// This type denotes a TEE Context, the main logical container linking a Client Application with a particular TEE.
    /// </summary>
    public sealed class Context : IDisposable
    {
        private Interop.TEEC_Context context;

        /// <summary>
        /// This function (constructor) initializes a new TEE Context, forming a connection between this Client Application and the
        /// TEE identified by the string identifier name (empty name denotes default TEE).
        /// </summary>
        /// <param name="name">The TEE name</param>
        public Context(string name)
        {
            context = new Interop.TEEC_Context();
            int ret = Interop.Libteec.InitializeContext(name, ref context);
            Interop.CheckNThrowException(ret, string.Format("InititalizeContext('{0}')", name));
        }

        ~Context()
        {
            Dispose();
        }

        /// <summary>
        /// This function implements IDisposable interface
        /// </summary>
        public void Dispose() {
            Interop.Libteec.FinalizeContext(ref context);
            //context.imp = null;
        }

        /// <summary>
        /// This function opens a new Session between the Client Application and the specified Trusted Application.
        /// The target Trusted Application is identified by a UUID passed in the parameter destination.
        /// There can be up to four Parameter objects given in the {paramlist} array
        /// </summary>
        /// <param name="destination">The UUID of destination TA</param>
        /// <param name="loginMethod">The authentication algorithm <see cref="LoginMethod" /></param>
        /// <param name="connectionData">The data to be verified by given login method</param>
        /// <param name="paramlist">The parameters to be passed to TA open-session-callback</param>
        public Session OpenSession(Guid destination, uint loginMethod, byte[] connectionData, Parameter[] paramlist)
        {
            Session ses = new Session(context);
            ses.Open(destination, loginMethod, connectionData, paramlist);
            return ses;
        }
        /// <summary>
        /// @see OpenSession(Guid destination, uint connectionMethod, byte[] connectionData, Parameter[] paramlist, CancellationToken token)
        /// </summary>
        /// <param name="destination">The UUID of destination TA</param>
        public Session OpenSession(Guid destination)
        {
            Session ses = new Session(context);
            ses.Open(destination, LoginMethod.Public, null, null);
            return ses;
        }

        /// <summary>
        /// Asynchronous version of OpenSession
        /// @see OpenSession(Guid destination, uint connectionMethod, byte[] connectionData, Parameter[] paramlist, CancellationToken token)
        /// </summary>
        /// <param name="destination">The UUID of destination TA</param>
        /// <param name="loginMethod">The authentication algorithm <see cref="LoginMethod" /></param>
        /// <param name="connectionData">The data to be verified by given login method</param>
        /// <param name="paramlist">The parameters to be passed to TA open-session-callback</param>
        /// <param name="token">The token for task manipulation</param>
        public async Task<Session> OpenSessionAsync(Guid destination, uint loginMethod, byte[] connectionData, Parameter[] paramlist, CancellationToken token = default(CancellationToken))
        {
            Task<Session> task = Task<Session>.Factory.StartNew(() =>
            {
                return OpenSession(destination, loginMethod, connectionData, paramlist);
            });
            return await task;
        }
        /// <summary>
        /// Asynchronous version of OpenSession
        /// @see OpenSession(Guid destination, uint connectionMethod, byte[] connectionData, Parameter[] paramlist, CancellationToken token)
        /// </summary>
        /// <param name="destination">The UUID of destination TA</param>
        /// <param name="token">The token for task manipulation</param>
        public async Task<Session> OpenSessionAsync(Guid destination, CancellationToken token = default(CancellationToken))
        {
            Task<Session> task = Task<Session>.Factory.StartNew(() =>
            {
                return OpenSession(destination);
            });
            return await task;
        }

        /// <summary>
        /// This function registers a block of existing Client Application memory as a block of Shared Memory within
        /// the scope of the specified Context, in accordance with the parameters.
        /// The input <paramref name="memaddr"/> MUST point to the shared memory region to register
        /// </summary>
        /// <param name="memaddr">The address of shared memory</param>
        /// <param name="size">The size of shared memory</param>
        /// <param name="flags">The flags describing access modes (Input and/or Output)</param>
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
        /// This function allocates a new block of memory as a block of Shared Memory within the scope of the
        /// specified Context, in accordance with the parameters.
        /// </summary>
        /// <param name="size">The size of shared memory</param>
        /// <param name="flags">The flags describing access modes (Input and/or Output)</param>
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
        /// This function deregisters or deallocates a previously initialized block of Shared Memory.
        /// For a memory buffer allocated using AllocateSharedMemory the Implementation MUST free the
        /// underlying memory and the Client Application MUST NOT access this region after this function has been
        /// called. In this case the Implementation MUST clear the buffer and size fields of the sharedMem
        /// structure before returning.
        /// For memory registered using RegisterSharedMemory the implementation MUST deregister the
        /// underlying memory from the TEE, but the memory region will stay available to the Client Application for
        /// other purposes as the memory is owned by it.
        /// </summary>
        /// <param name="shm">The shared memory object returned by RegisterSharedMemory or AllocateSharedMemory</param>
        public void ReleaseSharedMemory(SharedMemory shm)
        {
            Interop.Libteec.ReleaseSharedMemory(ref shm.shm);
        }
    };
}
