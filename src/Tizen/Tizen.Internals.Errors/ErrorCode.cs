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

namespace Tizen.Internals.Errors
{
    /// <summary>
    /// Error codes used inside Tizen .NET API implementation.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ErrorCode : int
    {
        /// <summary>
        /// Successful.
        /// </summary>
        None = 0, //  0

        /// <summary>
        /// Operation not permitted.
        /// </summary>
        NotPermitted = -1, //  -EPERM

        /// <summary>
        /// No such file or directory.
        /// </summary>
        NoSuchFile = -2, //  -ENOENT

        /// <summary>
        /// No such process.
        /// </summary>
        NoSuchProcess = -3, //  -ESRCH

        /// <summary>
        /// Interrupted system call.
        /// </summary>
        InterruptedSysCall = -4, //  -EINTR

        /// <summary>
        /// I/O error.
        /// </summary>
        IoError = -5, //  -EIO

        /// <summary>
        /// No such device or address.
        /// </summary>
        NoSuchDevice = -6, //  -ENXIO

        /// <summary>
        /// Argument list too long.
        /// </summary>
        ArgumentListTooLong = -7, //  -E2BIG

        /// <summary>
        /// Executable format error.
        /// </summary>
        ExecFormatError = -8, //  -ENOEXEC

        /// <summary>
        /// Bad file number.
        /// </summary>
        BadFileNumber = -9, //  -EBADF

        /// <summary>
        /// Try again.
        /// </summary>
        TryAgain = -11, //  -EAGAIN

        /// <summary>
        /// Out of memory.
        /// </summary>
        OutOfMemory = -12, //  -ENOMEM

        /// <summary>
        /// Permission denied.
        /// </summary>
        PermissionDenied = -13, //  -EACCES

        /// <summary>
        /// Bad address.
        /// </summary>
        BadAddress = -14, //  -EFAULT

        /// <summary>
        /// Block device required.
        /// </summary>
        BlockDeviceRequired = -15, //  -ENOTBLK

        /// <summary>
        /// Device or resource busy.
        /// </summary>
        ResourceBusy = -16, //  -EBUSY

        /// <summary>
        /// File exists.
        /// </summary>
        FileExists = -17, //  -EEXIST

        /// <summary>
        /// Cross-device link.
        /// </summary>
        CrossDeviceLink = -18, //  -EXDEV

        /// <summary>
        /// Not a directory.
        /// </summary>
        NotaDirectory = -20, //  -ENOTDIR

        /// <summary>
        /// Is a directory.
        /// </summary>
        IsADirectory = -21, //  -EISDIR

        /// <summary>
        /// Invalid function parameter.
        /// </summary>
        InvalidParameter = -22, //  -EINVAL

        /// <summary>
        /// File table overflow.
        /// </summary>
        FileTableOverflow = -23, //  -ENFILE

        /// <summary>
        /// Too many open files.
        /// </summary>
        TooManyOpenFiles = -24, //  -EMFILE

        /// <summary>
        /// Not a terminal.
        /// </summary>
        TooNotaTerminal = -25, //  -ENOTTY

        /// <summary>
        /// Too text file busy.
        /// </summary>
        TooTextFileBusy = -26, //  -ETXTBSY

        /// <summary>
        /// File too large.
        /// </summary>
        FileTooLarge = -27, //  -EFBIG

        /// <summary>
        /// No space left on device.
        /// </summary>
        FileNoSpaceOnDevice = -28, //  -ENOSPC

        /// <summary>
        /// Illegal seek.
        /// </summary>
        IllegalSeek = -29, //  -ESPIPE

        /// <summary>
        /// Read-only file system.
        /// </summary>
        ReadOnlyFilesystem = -30, //  -EROFS

        /// <summary>
        /// No data available.
        /// </summary>
        NoData = -61, //  -ENODATA

        /// <summary>
        /// Too many links.
        /// </summary>
        TooManyLinks = -31, //  -EMLINK

        /// <summary>
        /// Broken pipe.
        /// </summary>
        BrokenPipe = -32, //  -EPIPE

        /// <summary>
        /// Math argument out of domain of the function.
        /// </summary>
        ArgumentOutOfDomain = -33, //  -EDOM

        /// <summary>
        /// Math result not representable.
        /// </summary>
        ResultOutOfRange = -34, //  -ERANGE

        /// <summary>
        /// Resource deadlock would occur.
        /// </summary>
        WouldCauseDeadlock = -35, //  -EDEADLK

        /// <summary>
        /// File name too long.
        /// </summary>
        FileNameTooLong = -36, //  -ENAMETOOLONG

        /// <summary>
        /// No record locks available.
        /// </summary>
        FileNoLocksAvailable = -37, //  -ENOLCK

        /// <summary>
        /// Function not implemented.
        /// </summary>
        InvalidOperation = -38, //  -ENOSYS

        /// <summary>
        /// Directory not empty.
        /// </summary>
        DirNotEmpty = -39, //  -ENOTEMPTY

        /// <summary>
        /// Too many symbolic links encountered.
        /// </summary>
        TooManySymbolicLinks = -40, //  -ELOOP

        /// <summary>
        /// Operation would block.
        /// </summary>
        WouldBlock = -11, //  TryAgain (-EAGAIN)

        /// <summary>
        /// Accessing a corrupted shared library.
        /// </summary>
        CorruptedSharedLib = -80, //  -ELIBBAD

        /// <summary>
        /// .lib section in a.out corrupted.
        /// </summary>
        LibSectionCorrupted = -81, //  -ELIBSCN

        /// <summary>
        /// Attempting to link in too many shared libraries.
        /// </summary>
        LinkTooManySharedLib = -82, //  -ELIBMAX

        /// <summary>
        /// Cannot execute a shared library directly.
        /// </summary>
        SharedLibExec = -83, //  -ELIBEXEC

        /// <summary>
        /// Illegal byte sequence.
        /// </summary>
        IllegalByteSeq = -84, //  -EILSEQ

        /// <summary>
        /// Interrupted system call should be restarted.
        /// </summary>
        SystemCallRestart = -85, //  -ERESTART

        /// <summary>
        /// Streams pipe error.
        /// </summary>
        StreamsPipe = -86, //  -ESTRPIPE

        /// <summary>
        /// Too many users.
        /// </summary>
        TooManyUsers = -87, //  -EUSERS

        /// <summary>
        /// Socket operation on non-socket.
        /// </summary>
        NonSocket = -88, //  -ENOTSOCK

        /// <summary>
        /// Destination address required.
        /// </summary>
        NoDestAddress = -89, //  -EDESTADDRREQ

        /// <summary>
        /// Message too long.
        /// </summary>
        MsgTooLong = -90, //  -EMSGSIZE

        /// <summary>
        /// Protocol wrong type for socket.
        /// </summary>
        ProtocolWrongType = -91, //  -EPROTOTYPE

        /// <summary>
        /// Protocol not available.
        /// </summary>
        ProtocolNotAvaliable = -92, //  -ENOPROTOOPT

        /// <summary>
        /// Protocol not supported.
        /// </summary>
        ProtocolNotSupported = -93, //  -EPROTONOSUPPORT

        /// <summary>
        /// Socket type not supported.
        /// </summary>
        SocketTypeNotSupported = -94, //  -ESOCKTNOSUPPORT

        /// <summary>
        /// Operation not supported on the transport endpoint.
        /// </summary>
        EndpointOperatinNotSupported = -95, //  -EOPNOTSUPP

        /// <summary>
        /// Protocol family not supported.
        /// </summary>
        ProtocolFamilyNotSupported = -96, //  -EPFNOSUPPORT

        /// <summary>
        /// Address family not supported by protocol.
        /// </summary>
        AddressFamilyNotSupported = -97, //  -EAFNOSUPPORT

        /// <summary>
        /// Address already in use.
        /// </summary>
        AddresInUse = -98, //  -EADDRINUSE

        /// <summary>
        /// Cannot assign requested address.
        /// </summary>
        CannotAssignAddress = -99, //  -EADDRNOTAVAIL

        /// <summary>
        /// Network down.
        /// </summary>
        Networkdown = -100, //  -ENETDOWN

        /// <summary>
        /// Network unreachable.
        /// </summary>
        NetworkUnreachable = -101, //  -ENETUNREACH

        /// <summary>
        /// Network dropped the connection because of the reset.
        /// </summary>
        NetworkReset = -102, //  -ENETRESET

        /// <summary>
        /// Software caused the connection to abort.
        /// </summary>
        ConnectionAborted = -103, //  -ECONNABORTED

        /// <summary>
        /// Connection reset by the peer.
        /// </summary>
        ConnectionResetByPeer = -104, //  -ECONNRESET

        /// <summary>
        /// No buffer space available.
        /// </summary>
        BufferSpace = -105, //  -ENOBUFS

        /// <summary>
        /// Transport endpoint already connected.
        /// </summary>
        EndpointConnected = -106, //  -EISCONN

        /// <summary>
        /// Transport endpoint not connected.
        /// </summary>
        EndpointNotConnected = -107, //  -ENOTCONN

        /// <summary>
        /// Cannot send after the transport endpoint shutdown.
        /// </summary>
        EndpointShutdown = -108, //  -ESHUTDOWN

        /// <summary>
        /// Too many references: cannot splice.
        /// </summary>
        TooManyReferences = -109, //  -ETOOMANYREFS

        /// <summary>
        /// Connection timed out.
        /// </summary>
        ConnectionTimeout = -110, //  -ETIMEDOUT

        /// <summary>
        /// Connection refused.
        /// </summary>
        ConnectionRefused = -111, //  -ECONNREFUSED

        /// <summary>
        /// Host down.
        /// </summary>
        Hostdown = -112, //  -EHOSTDOWN

        /// <summary>
        /// No route to host.
        /// </summary>
        NoRouteToHost = -113, //  -EHOSTUNREACH

        /// <summary>
        /// Operation already in progress.
        /// </summary>
        AlreadyInProgress = -114, //  -EALREADY

        /// <summary>
        /// Operation now in progress.
        /// </summary>
        NowInProgress = -115, //  -EINPROGRESS

        /// <summary>
        /// Stale NFS file handle.
        /// </summary>
        StaleNfsFileHandle = -116, //  -ESTALE

        /// <summary>
        /// Structure needs cleaning.
        /// </summary>
        StructureUnclean = -117, //  -EUCLEAN

        /// <summary>
        /// Not a XENIX named type file.
        /// </summary>
        NotXenixNamedTypeFile = -118, //  -ENOTNAM

        /// <summary>
        /// No XENIX semaphores available.
        /// </summary>
        NoXenixSemaphoresAvailable = -119, //  -ENAVAIL

        /// <summary>
        /// Is a named type file.
        /// </summary>
        IsNamedTypeFile = -120, //  -EISNAM

        /// <summary>
        /// Remote I/O error.
        /// </summary>
        RemoteIo = -121, //  -EREMOTEIO

        /// <summary>
        /// Quota exceeded.
        /// </summary>
        QuotaExceeded = -122, //  -EDQUOT

        /// <summary>
        /// No medium found.
        /// </summary>
        NoMedium = -123, //  -ENOMEDIUM

        /// <summary>
        /// Wrong medium type.
        /// </summary>
        WrongMediumType = -124, //  -EMEDIUMTYPE

        /// <summary>
        /// Operation Canceled.
        /// </summary>
        Canceled = -125, //  -ECANCELED

        /// <summary>
        /// Required key not available.
        /// </summary>
        KeyNotAvailable = -126, //  -ENOKEY

        /// <summary>
        /// Key has expired.
        /// </summary>
        KeyExpired = -127, //  -EKEYEXPIRED

        /// <summary>
        /// Key has been revoked.
        /// </summary>
        KeyRevoked = -128, //  -EKEYREVOKED

        /// <summary>
        /// Key was rejected by the service.
        /// </summary>
        KeyRejected = -129, //  -EKEYREJECTED


        /// <summary>
        /// Owner died (for robust mutexes).
        /// </summary>
        OwnerDead = -130, //  -EOWNERDEAD

        /// <summary>
        /// Unknown error.
        /// </summary>
        Unknown = -1073741824, //  TIZEN_ERROR_MIN_PLATFORM_ERROR

        /// <summary>
        /// Timed out.
        /// </summary>
        TimedOut,

        /// <summary>
        /// Not supported.
        /// </summary>
        NotSupported,

        /// <summary>
        /// Not consented.
        /// </summary>
        UserNotConsented,

        /// <summary>
        /// The end of collection.
        /// </summary>
        EndofCollection
    }
}
