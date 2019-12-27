/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
namespace CoreUI {
    /// <summary>This type is a alias for struct tm. It is intended to be a standard way to reference it in .eo files.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct Time : IEquatable<Time>
    {
        
        private int tmSec;
        
        private int tmMin;
        
        private int tmHour;
        
        private int tmMday;
        
        private int tmMon;
        
        private int tmYear;
        
        private int tmWday;
        
        private int tmYday;
        
        private int tmIsdst;

        /// <summary>Seconds.	[0-60] (1 leap second)</summary>
        /// <since_tizen> 6 </since_tizen>
        public int TmSec { get => tmSec; }
        /// <summary>Minutes.	[0-59]</summary>
        /// <since_tizen> 6 </since_tizen>
        public int TmMin { get => tmMin; }
        /// <summary>Hours.	[0-23]</summary>
        /// <since_tizen> 6 </since_tizen>
        public int TmHour { get => tmHour; }
        /// <summary>Day.		[1-31]</summary>
        /// <since_tizen> 6 </since_tizen>
        public int TmMday { get => tmMday; }
        /// <summary>Month.	[0-11]</summary>
        /// <since_tizen> 6 </since_tizen>
        public int TmMon { get => tmMon; }
        /// <summary>Year	- 1900.</summary>
        /// <since_tizen> 6 </since_tizen>
        public int TmYear { get => tmYear; }
        /// <summary>Day of week.	[0-6]</summary>
        /// <since_tizen> 6 </since_tizen>
        public int TmWday { get => tmWday; }
        /// <summary>Days in year.[0-365]</summary>
        /// <since_tizen> 6 </since_tizen>
        public int TmYday { get => tmYday; }
        /// <summary>DST. [-1/0/1]</summary>
        /// <since_tizen> 6 </since_tizen>
        public int TmIsdst { get => tmIsdst; }
        /// <summary>Constructor for Time.
        /// </summary>
        /// <param name="tmSec">Seconds.	[0-60] (1 leap second)</param>
        /// <param name="tmMin">Minutes.	[0-59]</param>
        /// <param name="tmHour">Hours.	[0-23]</param>
        /// <param name="tmMday">Day.		[1-31]</param>
        /// <param name="tmMon">Month.	[0-11]</param>
        /// <param name="tmYear">Year	- 1900.</param>
        /// <param name="tmWday">Day of week.	[0-6]</param>
        /// <param name="tmYday">Days in year.[0-365]</param>
        /// <param name="tmIsdst">DST. [-1/0/1]</param>
        /// <since_tizen> 6 </since_tizen>
        public Time(
            int tmSec = default(int),
            int tmMin = default(int),
            int tmHour = default(int),
            int tmMday = default(int),
            int tmMon = default(int),
            int tmYear = default(int),
            int tmWday = default(int),
            int tmYday = default(int),
            int tmIsdst = default(int))
        {
            this.tmSec = tmSec;
            this.tmMin = tmMin;
            this.tmHour = tmHour;
            this.tmMday = tmMday;
            this.tmMon = tmMon;
            this.tmYear = tmYear;
            this.tmWday = tmWday;
            this.tmYday = tmYday;
            this.tmIsdst = tmIsdst;
        }

        /// <summary>Unpacks Time into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out int tmSec,
            out int tmMin,
            out int tmHour,
            out int tmMday,
            out int tmMon,
            out int tmYear,
            out int tmWday,
            out int tmYday,
            out int tmIsdst
        )
        {
            tmSec = this.TmSec;
            tmMin = this.TmMin;
            tmHour = this.TmHour;
            tmMday = this.TmMday;
            tmMon = this.TmMon;
            tmYear = this.TmYear;
            tmWday = this.TmWday;
            tmYday = this.TmYday;
            tmIsdst = this.TmIsdst;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + TmSec.GetHashCode();
            hash = hash * 23 + TmMin.GetHashCode();
            hash = hash * 23 + TmHour.GetHashCode();
            hash = hash * 23 + TmMday.GetHashCode();
            hash = hash * 23 + TmMon.GetHashCode();
            hash = hash * 23 + TmYear.GetHashCode();
            hash = hash * 23 + TmWday.GetHashCode();
            hash = hash * 23 + TmYday.GetHashCode();
            hash = hash * 23 + TmIsdst.GetHashCode();
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(Time other)
        {
            return TmSec == other.TmSec && TmMin == other.TmMin && TmHour == other.TmHour && TmMday == other.TmMday && TmMon == other.TmMon && TmYear == other.TmYear && TmWday == other.TmWday && TmYday == other.TmYday && TmIsdst == other.TmIsdst;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is Time) ? Equals((Time)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(Time lhs, Time rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(Time lhs, Time rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator Time(IntPtr ptr)
        {
            return (Time)Marshal.PtrToStructure(ptr, typeof(Time));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static Time FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

namespace CoreUI {
    /// <summary>This type describes the version of EFL with an optional variant.
    /// 
    /// This may be used to query the current running version of EFL. Or it can be passed by applications at startup time to inform EFL of the version a certain application was built for.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct Version : IEquatable<Version>
    {
        
        private int major;
        
        private int minor;
        
        private int micro;
        
        private int revision;
        /// <summary>Internal wrapper for field flavor</summary>
        private System.IntPtr flavor;
        /// <summary>Internal wrapper for field buildId</summary>
        private System.IntPtr buildId;

        /// <summary>Major component of the version (&gt;= 1).</summary>
        /// <since_tizen> 6 </since_tizen>
        public int Major { get => major; }
        /// <summary>Minor component of the version (&gt;= 0).</summary>
        /// <since_tizen> 6 </since_tizen>
        public int Minor { get => minor; }
        /// <summary>Micro component of the version (&gt;= 0).</summary>
        /// <since_tizen> 6 </since_tizen>
        public int Micro { get => micro; }
        /// <summary>Revision component of the version (&gt;= 0).</summary>
        /// <since_tizen> 6 </since_tizen>
        public int Revision { get => revision; }
        /// <summary>Special version string for this build of EFL, <c>null</c> for vanilla (upstream) EFL. Contains <c>EFL_VERSION_FLAVOR</c>.</summary>
        /// <since_tizen> 6 </since_tizen>
        public System.String Flavor { get => CoreUI.DataTypes.StringConversion.NativeUtf8ToManagedString(flavor); }
        /// <summary>Contains <c>EFL_BUILD_ID</c>.</summary>
        /// <since_tizen> 6 </since_tizen>
        public System.String BuildId { get => CoreUI.DataTypes.StringConversion.NativeUtf8ToManagedString(buildId); }
        /// <summary>Constructor for Version.
        /// </summary>
        /// <param name="major">Major component of the version (&gt;= 1).</param>
        /// <param name="minor">Minor component of the version (&gt;= 0).</param>
        /// <param name="micro">Micro component of the version (&gt;= 0).</param>
        /// <param name="revision">Revision component of the version (&gt;= 0).</param>
        /// <param name="flavor">Special version string for this build of EFL, <c>null</c> for vanilla (upstream) EFL. Contains <c>EFL_VERSION_FLAVOR</c>.</param>
        /// <param name="buildId">Contains <c>EFL_BUILD_ID</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public Version(
            int major = default(int),
            int minor = default(int),
            int micro = default(int),
            int revision = default(int),
            System.String flavor = default(System.String),
            System.String buildId = default(System.String))
        {
            this.major = major;
            this.minor = minor;
            this.micro = micro;
            this.revision = revision;
            this.flavor = CoreUI.DataTypes.MemoryNative.StrDup(flavor);
            this.buildId = CoreUI.DataTypes.MemoryNative.StrDup(buildId);
        }

        /// <summary>Unpacks Version into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out int major,
            out int minor,
            out int micro,
            out int revision,
            out System.String flavor,
            out System.String buildId
        )
        {
            major = this.Major;
            minor = this.Minor;
            micro = this.Micro;
            revision = this.Revision;
            flavor = this.Flavor;
            buildId = this.BuildId;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Major.GetHashCode();
            hash = hash * 23 + Minor.GetHashCode();
            hash = hash * 23 + Micro.GetHashCode();
            hash = hash * 23 + Revision.GetHashCode();
            hash = hash * 23 + Flavor.GetHashCode(StringComparison.Ordinal);
            hash = hash * 23 + BuildId.GetHashCode(StringComparison.Ordinal);
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(Version other)
        {
            return Major == other.Major && Minor == other.Minor && Micro == other.Micro && Revision == other.Revision && Flavor == other.Flavor && BuildId == other.BuildId;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is Version) ? Equals((Version)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(Version lhs, Version rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(Version lhs, Version rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator Version(IntPtr ptr)
        {
            return (Version)Marshal.PtrToStructure(ptr, typeof(Version));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static Version FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

