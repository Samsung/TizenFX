---
uid: Tizen.Security.TEEC
summary: The communication API for connecting Client Applications running in a rich operating environment
  with security related Trusted Applications running inside a Trusted Execution Environment (TEE).
remarks: *content
---
## Overview
A TEE provides an execution environment with security capabilities, which are either available to Trusted Applications
running inside the TEE or exposed externally to Client Applications.
The TEE Client API concentrates on the interface to enable efficient communications between
a Client Application and a Trusted Application running inside the TEE.
Higher level standards and protocol layers may be built on top of the foundation
provided by the TEE Client API – for example, to cover common tasks, such as secure storage,
cryptography, and run-time installation of new Trusted Applications.
The separation between the rich environment and the TEE is guaranted.

The key design principles of the TEE Client API are:
  * Client-side memory allocations
	Where possible the design of the TEE Client API has placed the responsibility for memory
	allocation on the calling Client Application code. This gives the Client developer choice of
	memory allocation locations, enabling simple optimizations, such as stack-based allocation
	or enhanced flexibility using placements in static global memory or thread-local storage.

	This design choice is evident in the API by the use of pointers to structures rather than
	opaque handles to represent any manipulated objects.
  * Aim for zero-copy data transfer
	The features of the TEE Client API are chosen to maximize the possibility of zero-copy
	data transfer between the Client Application and the Trusted Application.
	However, short messages can also be passed by copy, which avoids the overhead of
	sharing memory.
  * Support memory sharing by pointers
	The TEE Client API will be used to implement higher-level APIs, such as cryptography or
	secure storage, where the caller will often provide memory buffers for input or output data
	using simple C pointers. The TEE Client API must allow efficient sharing of this type of
	memory, and as such does not rely on the Client Application being able to use bulk
	memory buffers allocated by the TEE Client API.
  * Specify only communication mechanisms
	This API focuses on defining the underlying communications channel. It does not define
	the format of the messages which pass over the channel, or the protocols used by specific
	Trusted Applications.

## Example
The following example demonstrates how to invoke command on Trused Application.

```cs
Guid ta_uuid = new Guid("TA-guid-put-here");
Context ctx = new Context(null);
Session ses = ctx.OpenSession(ta_uuid);
Parameter[] p = { new Value(1,2,TEFValueType.In) };
ses.InvokeCommand(1, p);
ses.Close();
ctx.Dispose();
```
