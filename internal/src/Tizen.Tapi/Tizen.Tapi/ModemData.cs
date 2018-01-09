using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Tapi
{
    /// <summary>
    /// A class containing information about mobile equipment version.
    /// </summary>
    public class MiscVersionInformation
    {
        internal byte Version;
        internal string SwVers;
        internal string HwVers;
        internal string CalcDate;
        internal string ProdCode;
        internal string Model;
        internal byte PrlNamNum;
        internal string PrlVers;
        internal byte EriNamNum;
        internal string EriVers;
        internal MiscVersionInformation()
        {
        }

        /// <summary>
        /// Version mask.
        /// </summary>
        public byte VersionMask
        {
            get
            {
                return Version;
            }
        }

        /// <summary>
        /// Software version.
        /// </summary>
        public string SwVersion
        {
            get
            {
                return SwVers;
            }
        }

        /// <summary>
        /// Hardware version.
        /// </summary>
        public string HwVersion
        {
            get
            {
                return HwVers;
            }
        }

        /// <summary>
        /// Calculation date.
        /// </summary>
        public string CalculationDate
        {
            get
            {
                return CalcDate;
            }
        }

        /// <summary>
        /// Product code.
        /// </summary>
        public string ProductCode
        {
            get
            {
                return ProdCode;
            }
        }

        /// <summary>
        /// Model id.
        /// </summary>
        public string ModelId
        {
            get
            {
                return Model;
            }
        }

        /// <summary>
        /// Number of prl nam fields.
        /// </summary>
        public byte PrlNam
        {
            get
            {
                return PrlNamNum;
            }
        }

        /// <summary>
        /// Prl version (only for CDMA).
        /// </summary>
        public string PrlVersion
        {
            get
            {
                return PrlVers;
            }
        }

        /// <summary>
        /// Number of Eri nam fields.
        /// </summary>
        public byte EriNam
        {
            get
            {
                return EriNamNum;
            }
        }

        /// <summary>
        /// Eri version.
        /// </summary>
        public string EriVersion
        {
            get
            {
                return EriVers;
            }
        }
    }

    /// <summary>
    /// A class containing information about mobile serial number.
    /// </summary>
    public class MiscSerialNumberInformation
    {
        internal string SzEsn;
        internal string SzMeid;
        internal string SzImei;
        internal string SzImeiSv;
        internal MiscSerialNumberInformation()
        {
        }

        /// <summary>
        /// Esn number.
        /// </summary>
        public string Esn
        {
            get
            {
                return SzEsn;
            }
        }

        /// <summary>
        /// Meid number.
        /// </summary>
        public string MeId
        {
            get
            {
                return SzMeid;
            }
        }

        /// <summary>
        /// Imei number.
        /// </summary>
        public string Imei
        {
            get
            {
                return SzImei;
            }
        }

        /// <summary>
        /// Imeisv number.
        /// </summary>
        public string ImeiSv
        {
            get
            {
                return SzImeiSv;
            }
        }
    }

    /// <summary>
    /// A class containing device information of cellular dongle.
    /// </summary>
    public class MiscDeviceInfo
    {
        internal string Vendor;
        internal string Device;
        internal MiscDeviceInfo()
        {
        }

        /// <summary>
        /// Vendor name.
        /// </summary>
        public string VendorName
        {
            get
            {
                return Vendor;
            }
        }

        /// <summary>
        /// Device name.
        /// </summary>
        public string DeviceName
        {
            get
            {
                return Device;
            }
        }
    }
}
