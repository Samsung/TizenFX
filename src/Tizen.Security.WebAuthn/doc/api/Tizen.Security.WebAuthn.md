---
uid: Tizen.Security.WebAuthn
summary: The Web Authentication module provides a C# API enabling the creation and use of
  strong, attested, scoped, public key-based credentials by web applications, for the
  purpose of strongly authenticating users
remarks: *content
---
## Overview
It provides an [Authenticator](xref:Tizen.Security.WebAuthn.Authenticator) class containing methods for creating public key-based credentials
([Authenticator.MakeCredential()](xref:Tizen.Security.WebAuthn.Authenticator.MakeCredential(Tizen.Security.WebAuthn.ClientData,Tizen.Security.WebAuthn.PubkeyCredCreationOptions,Tizen.Security.WebAuthn.MakeCredentialCallbacks))) and using them ([Authenticator.GetAssertion()](xref:Tizen.Security.WebAuthn.Authenticator.GetAssertion(Tizen.Security.WebAuthn.ClientData,Tizen.Security.WebAuthn.PubkeyCredRequestOptions,Tizen.Security.WebAuthn.GetAssertionCallbacks))). Both these operations are performed asynchronously. Callbacks passed as arguments are used to notify about the progress
or when user's interaction is necessary. Due to significant amount of time required to complete both
requests, cancelation is also possible with the help of Authenticator.Cancel(). The module also
provides a variety of data types based on W3C Web Authentication API (https://www.w3.org/TR/webauthn-3/) 
used to control the credential creation and assertion process.

## Related features
This module is related with the following features:
 * http://tizen.org/feature/security.webauthn
 * http://tizen.org/feature/network.bluetooth.le
 * and network connection features (http://tizen.org/feature/network.wifi, http://tizen.org/feature/network.ethernet, http://tizen.org/feature/network.telephony)

