/**
<summary>
Secure Repository function is provided by key-manager module in Tizen. The key manager provides a secure repository for keys, certificates, and sensitive data related to users and their password-protected APPs. Additionally, it provides secure cryptographic operations for non-exportable keys without revealing the key values to clients.
</summary>

<remarks>
<h2>Overview</h2>
<para>
Secure Repository stores keys, certificates, and sensitive user data in a central secure repository. The central secure repository is protected by a password.
</para>

<para>
Data Store Policy
A client can specify simple access rules when storing data in the key manager:
	Extractable or non-extractable
	-	Only for data tagged as extractable, the key manager returns the raw value of the data.
	-	If data is tagged as non-extractable, the key manager does not return its raw value. In that case, the key manager provides secure cryptographic operations for non-exportable keys without revealing the key values to the clients.
 	Per key password
	-	All data in the key manager is protected by a user password.
	-	A client can encrypt its data using their own password additionally.
	-	If a client provides a password when storing data, the data is encrypted with the password. This password must be provided when getting the data from the key manager.
</para>

<para>
Data Access Control
 	By default, only the owner of a data can access to the data.
 	If the owner grants the access to other applications, those applications can read or delete the data from key-manager DB.
 	When an application is deleted, the data and access control information granted by the application are also removed.
</para>

<para>
Alias Format
 	The format of alias is "package_id name" and the name should not contain any white space characters.
 	If package_id is not provided by a client, the key-manager will add the package_id of the client to the name internally.
 	The client can specify only its own pacakge id in the alias when storing a key, certificate, or data.
 	A client should specify the pacakge id of the owner in the alias to retrieve a a key, certificate, or data shared by other applications.
 	Aliases are returned from the key-manager as the format of package_id name.
</para>
</remarks>
*/
namespace Tizen.Security.SecureRepository {}
