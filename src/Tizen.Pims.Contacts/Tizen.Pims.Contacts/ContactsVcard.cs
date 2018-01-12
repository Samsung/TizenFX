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

using System;

namespace Tizen.Pims.Contacts
{
    using ContactsViews;

    /// <summary>
    /// Delegates for getting a record parsed from a vCard file.
    /// </summary>
    /// <param name="record">The contacts record.</param>
    /// <returns>true to continue with the next iteration of the loop, otherwise false to break out of the loop.</returns>
    /// <since_tizen> 4 </since_tizen>
    public delegate bool ParseCallback(ContactsRecord record);

    /// <summary>
    /// A class for parsing and making the vCards.
    /// </summary>
    /// <remarks>
    /// It's based on the vCard v3.0 specification.
    /// </remarks>
    /// <since_tizen> 4 </since_tizen>
    public static class ContactsVcard
    {
        /// <summary>
        /// Retrieves the vCard stream from a contacts record.
        /// </summary>
        /// <param name="record">The contacts record.</param>
        /// <returns>
        /// The vCard stream.
        /// </returns>
        /// <privilege>http://tizen.org/privilege/contact.read</privilege>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public static string Compose(ContactsRecord record)
        {
            int error = 0;
            string stream = null;

            if (record.Uri.Equals(Person.Uri))
            {
                error = Interop.Vcard.ContactsVcardMakeFromPerson(record._recordHandle, out stream);
            }
            else if (record.Uri.Equals(Contact.Uri))
            {
                error = Interop.Vcard.ContactsVcardMakeFromContact(record._recordHandle, out stream);
            }
            else if (record.Uri.Equals(MyProfile.Uri))
            {
                error = Interop.Vcard.ContactsVcardMakeFromMyProfile(record._recordHandle, out stream);
            }
            else
            {
                throw new ArgumentException("Invalid Parameters Provided");
            }

            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "Compose Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }

            return stream;
        }

        /// <summary>
        /// Retrieves all the contacts with a contacts list from a vCard stream.
        /// </summary>
        /// <param name="stream">The vCard stream.</param>
        /// <returns>
        /// The contacts list.
        /// </returns>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public static ContactsList Parse(string stream)
        {
            IntPtr listHandle;

            int error = Interop.Vcard.ContactsVcardParseToContacts(stream, out listHandle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "Parse Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }

            return new ContactsList(listHandle);
        }

        /// <summary>
        /// Retrieves all the contacts with a record from a vCard file.
        /// </summary>
        /// <param name="path">The file path of a vCard stream file.</param>
        /// <param name="callback">The callback function to invoke.</param>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <since_tizen> 4 </since_tizen>
        public static void ParseForEach(string path, ParseCallback callback)
        {
            Interop.Vcard.ContactsVcardParseCallback cb = (IntPtr handle, IntPtr data) =>
            {
                return callback(new ContactsRecord(handle, true));
            };

            int error = Interop.Vcard.ContactsVcardParseToContactForeach(path, cb, IntPtr.Zero);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "ParseForEach Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }
    }
}
