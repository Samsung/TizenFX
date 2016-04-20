// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

namespace Tizen.Internals.Errors
{
    internal enum ErrorCode : int
    {
        None = 0, //  0, /**< Successful */
        NotPermitted = -1, //  -EPERM, /**< Operation not permitted */
        NoSuchFile = -2, //  -ENOENT, /**< No such file or directory */
        NoSuchProcess = -3, //  -ESRCH, /**< No such process */
        InterruptedSysCall = -4, //  -EINTR, /**< Interrupted system call */
        IoError = -5, //  -EIO, /**< I/O error */
        NoSuchDevice = -6, //  -ENXIO, /**< No such device or address */
        ArgumentListTooLong = -7, //  -E2BIG, /**< Argument list too long */
        ExecFormatError = -8, //  -ENOEXEC, /**< Exec format error */
        BadFileNumber = -9, //  -EBADF, /**< Bad file number */
        TryAgain = -11, //  -EAGAIN, /**< Try again */
        OutOfMemory = -12, //  -ENOMEM, /**< Out of memory */
        PermissionDenied = -13, //  -EACCES, /**< Permission denied */
        BadAddress = -14, //  -EFAULT, /**< Bad address */
        BlockDeviceRequired = -15, //  -ENOTBLK, /**< Block device required */
        ResourceBusy = -16, //  -EBUSY, /**< Device or resource busy */
        FileExists = -17, //  -EEXIST, /**< File exists */
        CrossDeviceLink = -18, //  -EXDEV, /**< Cross-device link */
        NotaDirectory = -20, //  -ENOTDIR, /**< Not a directory */
        IsADirectory = -21, //  -EISDIR, /**< Is a directory */
        InvalidParameter = -22, //  -EINVAL, /**< Invalid function parameter */
        FileTableOverflow = -23, //  -ENFILE, /**< File table overflow */
        TooManyOpenFiles = -24, //  -EMFILE, /**< Too many open files */
        TooNotaTerminal = -25, //  -ENOTTY, /**< Not a terminal */
        TooTextFileBusy = -26, //  -ETXTBSY, /**< Not a terminal */
        FileTooLarge = -27, //  -EFBIG, /**< File too large */
        FileNoSpaceOnDevice = -28, //  -ENOSPC, /**< No space left on device */
        IllegalSeek = -29, //  -ESPIPE, /**< Illegal seek */
        ReadOnlyFilesystem = -30, //  -EROFS, /**< Read-only file system */
        NoData = -61, //  -ENODATA, /**< No data available */
        TooManyLinks = -31, //  -EMLINK, /**< Too many links */
        BrokenPipe = -32, //  -EPIPE, /**< Broken pipe */
        ArgumentOutOfDomain = -33, //  -EDOM, /**< Math argument out of domain of func */
        ResultOutOfRange = -34, //  -ERANGE, /**< Math result not representable */
        WouldCauseDeadlock = -35, //  -EDEADLK, /**< Resource deadlock would occur */
        FileNameTooLong = -36, //  -ENAMETOOLONG,/**< File name too long */
        FileNoLocksAvailable = -37, //  -ENOLCK, /**< No record locks available */
        InvalidOperation = -38, //  -ENOSYS, /**< Function not implemented */
        DirNotEmpty = -39, //  -ENOTEMPTY, /**< Directory not empty */
        TooManySymbolicLinks = -40, //  -ELOOP, /**< Too many symbolic links encountered */
        WouldBlock = -11, //  TryAgain (-EAGAIN), /**< Operation would block */
        CorruptedSharedLib = -80, //  -ELIBBAD, /**< Accessing a corrupted shared library */
        LibSectionCorrupted = -81, //  -ELIBSCN, /**< .lib section in a.out corrupted */
        LinkTooManySharedLib = -82, //  -ELIBMAX, /**< Attempting to link in too many shared libraries */
        SharedLibExec = -83, //  -ELIBEXEC, /**< Cannot exec a shared library directly */
        IllegalByteSeq = -84, //  -EILSEQ, /**< Illegal byte sequence */
        SystemCallRestart = -85, //  -ERESTART, /**< Interrupted system call should be restarted */
        StreamsPipe = -86, //  -ESTRPIPE, /**< Streams pipe error */
        TooManyUsers = -87, //  -EUSERS, /**< Too many users */
        NonSocket = -88, //  -ENOTSOCK, /**< Socket operation on non-socket */
        NoDestAddress = -89, //  -EDESTADDRREQ, /**< Destination address required */
        MsgTooLong = -90, //  -EMSGSIZE, /**< Message too long */
        ProtocolWrongType = -91, //  -EPROTOTYPE, /**< Protocol wrong type for socket */
        ProtocolNotAvaliable = -92, //  -ENOPROTOOPT, /**< Protocol not available */
        ProtocolNotSupported = -93, //  -EPROTONOSUPPORT, /**< Protocol not supported */
        SocketTypeNotSupported = -94, //  -ESOCKTNOSUPPORT, /**< Socket type not supported */
        EndpointOperatinNotSupported = -95, //  -EOPNOTSUPP, /**< Operation not supported on transport endpoint */
        ProtocolFamilyNotSupported = -96, //  -EPFNOSUPPORT, /**< Protocol family not supported */
        AddressFamilyNotSupported = -97, //  -EAFNOSUPPORT, /**< Address family not supported by protocol */
        AddresInUse = -98, //  -EADDRINUSE, /**< Address already in use */
        CannotAssignAddress = -99, //  -EADDRNOTAVAIL, /**< Cannot assign requested address */
        Networkdown = -100, //  -ENETDOWN, /**< Network is down */
        NetworkUnreachable = -101, //  -ENETUNREACH, /**< Network is unreachable */
        NetworkReset = -102, //  -ENETRESET, /**< Network dropped connection because of reset */
        ConnectionAborted = -103, //  -ECONNABORTED, /**< Software caused connection abort */
        ConnectionResetByPeer = -104, //  -ECONNRESET, /**< Connection reset by peer */
        BufferSpace = -105, //  -ENOBUFS, /**< No buffer space available */
        EndpointConnected = -106, //  -EISCONN, /**< Transport endpoint is already connected */
        EndpointNotConnected = -107, //  -ENOTCONN, /**< Transport endpoint is not connected */
        EndpointShutdown = -108, //  -ESHUTDOWN, /**< Cannot send after transport endpoint shutdown */
        TooManyReferences = -109, //  -ETOOMANYREFS, /**< Too many references: cannot splice */
        ConnectionTimeout = -110, //  -ETIMEDOUT, /**< Connection timed out */
        ConnectionRefused = -111, //  -ECONNREFUSED, /**< Connection refused */
        Hostdown = -112, //  -EHOSTDOWN, /**< Host is down */
        NoRouteToHost = -113, //  -EHOSTUNREACH, /**< No route to host */
        AlreadyInProgress = -114, //  -EALREADY, /**< Operation already in progress */
        NowInProgress = -115, //  -EINPROGRESS, /**< Operation now in progress */
        StaleNfsFileHandle = -116, //  -ESTALE, /**< Stale NFS file handle */
        StructureUnclean = -117, //  -EUCLEAN, /**< Structure needs cleaning */
        NotXenixNamedTypeFile = -118, //  -ENOTNAM, /**< Not a XENIX named type file */
        NoXenixSemaphoresAvailable = -119, //  -ENAVAIL, /**< No XENIX semaphores available */
        IsNamedTypeFile = -120, //  -EISNAM, /**< Is a named type file */
        RemoteIo = -121, //  -EREMOTEIO, /**< Remote I/O error */
        QuotaExceeded = -122, //  -EDQUOT, /**< Quota exceeded */
        NoMedium = -123, //  -ENOMEDIUM, /**< No medium found */
        WrongMediumType = -124, //  -EMEDIUMTYPE, /**< Wrong medium type */
        Canceled = -125, //  -ECANCELED, /**< Operation Canceled */
        KeyNotAvailable = -126, //  -ENOKEY, /**< Required key not available */
        KeyExpired = -127, //  -EKEYEXPIRED, /**< Key has expired */
        KeyRevoked = -128, //  -EKEYREVOKED, /**< Key has been revoked */
        KeyRejected = -129, //  -EKEYREJECTED, /**< Key was rejected by service */

        OwnerDead = -130, //  -EOWNERDEAD, /**< Owner died (for robust mutexes) */

        Unknown = -1073741824, //  TIZEN_ERROR_MIN_PLATFORM_ERROR, /**< Unknown error */

        TimedOut,   // /**< Time out */
        NotSupported, // /**< Not Supported */
        UserNotConsented,//  /**< Not Consented */
        EndofCollection  //
    }
}
