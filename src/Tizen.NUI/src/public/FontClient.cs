/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
namespace Tizen.NUI
{
    /// <summary>
    /// FontClient provides access to font information and resources.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class FontClient : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal FontClient(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicManualPINVOKE.FontClient_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FontClient obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal static uint DefaultPointSize
        {
            get
            {
                uint ret = NDalicManualPINVOKE.FontClient_DEFAULT_POINT_SIZE_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal class GlyphBufferData : global::System.IDisposable
        {
            private global::System.Runtime.InteropServices.HandleRef swigCPtr;
            protected bool swigCMemOwn;

            internal GlyphBufferData(global::System.IntPtr cPtr, bool cMemoryOwn)
            {
                swigCMemOwn = cMemoryOwn;
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            }

            internal static global::System.Runtime.InteropServices.HandleRef getCPtr(GlyphBufferData obj)
            {
                return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
            }

            //A Flag to check who called Dispose(). (By User or DisposeQueue)
            private bool isDisposeQueued = false;
            /// <summary>
            /// A Flat to check if it is already disposed.
            /// </summary>
            protected bool disposed = false;

            ~GlyphBufferData()
            {
                if (!isDisposeQueued)
                {
                    isDisposeQueued = true;
                    DisposeQueue.Instance.Add(this);
                }
            }

            public void Dispose()
            {
                //Throw excpetion if Dispose() is called in separate thread.
                if (!Window.IsInstalled())
                {
                    throw new System.InvalidOperationException("This API called from separate thread. This API must be called from MainThread.");
                }

                if (isDisposeQueued)
                {
                    Dispose(DisposeTypes.Implicit);
                }
                else
                {
                    Dispose(DisposeTypes.Explicit);
                    System.GC.SuppressFinalize(this);
                }
            }

            protected virtual void Dispose(DisposeTypes type)
            {
                if (disposed)
                {
                    return;
                }

                if (type == DisposeTypes.Explicit)
                {
                    //Called by User
                    //Release your own managed resources here.
                    //You should release all of your own disposable objects here.
                }

                //Release your own unmanaged resources here.
                //You should not access any managed member here except static instance.
                //because the execution order of Finalizes is non-deterministic.

                if (swigCPtr.Handle != global::System.IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        NDalicManualPINVOKE.delete_FontClient_GlyphBufferData(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                disposed = true;
            }

            public GlyphBufferData() : this(NDalicManualPINVOKE.new_FontClient_GlyphBufferData(), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            /*public byte[] Buffer
            {
                set
                {
                    NDalicManualPINVOKE.FontClient_GlyphBufferData_buffer_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    global::System.IntPtr cPtr = NDalicManualPINVOKE.FontClient_GlyphBufferData_buffer_get(swigCPtr);
                    SWIGTYPE_p_unsigned_char ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_unsigned_char(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }*/

            public uint Width
            {
                set
                {
                    NDalicManualPINVOKE.FontClient_GlyphBufferData_width_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    uint ret = NDalicManualPINVOKE.FontClient_GlyphBufferData_width_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            public uint Height
            {
                set
                {
                    NDalicManualPINVOKE.FontClient_GlyphBufferData_height_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    uint ret = NDalicManualPINVOKE.FontClient_GlyphBufferData_height_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            public PixelFormat Format
            {
                set
                {
                    NDalicManualPINVOKE.FontClient_GlyphBufferData_format_set(swigCPtr, (int)value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    PixelFormat ret = (PixelFormat)NDalicManualPINVOKE.FontClient_GlyphBufferData_format_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

        }
        private static readonly FontClient instance = FontClient.Get();

        /// <summary>
        /// Gets the singleton of the FontClient object.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static FontClient Instance
        {
            get
            {
                return instance;
            }
        }

        internal static FontClient Get()
        {
            FontClient ret = new FontClient(NDalicManualPINVOKE.FontClient_Get(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal FontClient() : this(NDalicManualPINVOKE.new_FontClient__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal FontClient(FontClient handle) : this(NDalicManualPINVOKE.new_FontClient__SWIG_1(FontClient.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal FontClient Assign(FontClient handle)
        {
            FontClient ret = new FontClient(NDalicManualPINVOKE.FontClient_Assign(swigCPtr, FontClient.getCPtr(handle)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetDpi(uint horizontalDpi, uint verticalDpi)
        {
            NDalicManualPINVOKE.FontClient_SetDpi(swigCPtr, horizontalDpi, verticalDpi);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void GetDpi(SWIGTYPE_p_unsigned_int horizontalDpi, SWIGTYPE_p_unsigned_int verticalDpi)
        {
            NDalicManualPINVOKE.FontClient_GetDpi(swigCPtr, SWIGTYPE_p_unsigned_int.getCPtr(horizontalDpi), SWIGTYPE_p_unsigned_int.getCPtr(verticalDpi));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal int GetDefaultFontSize()
        {
            int ret = NDalicManualPINVOKE.FontClient_GetDefaultFontSize(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Called when the user changes the system defaults.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void ResetSystemDefaults()
        {
            NDalicManualPINVOKE.FontClient_ResetSystemDefaults(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void GetDefaultFonts(SWIGTYPE_p_std__vectorT_Dali__TextAbstraction__FontDescription_t defaultFonts)
        {
            NDalicManualPINVOKE.FontClient_GetDefaultFonts(swigCPtr, SWIGTYPE_p_std__vectorT_Dali__TextAbstraction__FontDescription_t.getCPtr(defaultFonts));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void GetDefaultPlatformFontDescription(FontDescription fontDescription)
        {
            NDalicManualPINVOKE.FontClient_GetDefaultPlatformFontDescription(swigCPtr, FontDescription.getCPtr(fontDescription));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void GetSystemFonts(SWIGTYPE_p_std__vectorT_Dali__TextAbstraction__FontDescription_t systemFonts)
        {
            NDalicManualPINVOKE.FontClient_GetSystemFonts(swigCPtr, SWIGTYPE_p_std__vectorT_Dali__TextAbstraction__FontDescription_t.getCPtr(systemFonts));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void GetDescription(uint id, FontDescription fontDescription)
        {
            NDalicManualPINVOKE.FontClient_GetDescription(swigCPtr, id, FontDescription.getCPtr(fontDescription));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves the font point size of a given font id.
        /// </summary>
        /// <param name="id">The font identifier.</param>
        /// <returns>The point size in 26.6 fractional points.</returns>
        /// <since_tizen> 5 </since_tizen>
        public uint GetPointSize(uint id)
        {
            uint ret = NDalicManualPINVOKE.FontClient_GetPointSize(swigCPtr, id);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Whether the given character is supported by the font.
        /// </summary>
        /// <param name="fontId">The id of the font.</param>
        /// <param name="character">The character.</param>
        /// <returns>True if the character is supported by the font.</returns>
        /// <since_tizen> 5 </since_tizen>
        public bool IsCharacterSupportedByFont(uint fontId, uint character)
        {
            bool ret = NDalicManualPINVOKE.FontClient_IsCharacterSupportedByFont(swigCPtr, fontId, character);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Find the default font for displaying a UTF-32 character.
        /// </summary>
        /// <param name="charcode">The character for which a font is needed.</param>
        /// <param name="requestedPointSize">The point size in 26.6 fractional points; the default point size is 12*64.</param>
        /// <param name="preferColor">True if a color font is preferred.</param>
        /// <returns>A valid font identifier, or zero if the font does not exist.</returns>
        /// <since_tizen> 5 </since_tizen>
        public uint FindDefaultFont(uint charcode, uint requestedPointSize, bool preferColor)
        {
            uint ret = NDalicManualPINVOKE.FontClient_FindDefaultFont__SWIG_0(swigCPtr, charcode, requestedPointSize, preferColor);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Find the default font for displaying a UTF-32 character.
        /// </summary>
        /// <param name="charcode">The character for which a font is needed.</param>
        /// <param name="requestedPointSize">The point size in 26.6 fractional points; the default point size is 12*64.</param>
        /// <returns>A valid font identifier, or zero if the font does not exist.</returns>
        /// <since_tizen> 5 </since_tizen>
        public uint FindDefaultFont(uint charcode, uint requestedPointSize)
        {
            uint ret = NDalicManualPINVOKE.FontClient_FindDefaultFont__SWIG_1(swigCPtr, charcode, requestedPointSize);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Find the default font for displaying a UTF-32 character.
        /// </summary>
        /// <param name="charcode">The character for which a font is needed.</param>
        /// <returns>A valid font identifier, or zero if the font does not exist.</returns>
        /// <since_tizen> 5 </since_tizen>
        public uint FindDefaultFont(uint charcode)
        {
            uint ret = NDalicManualPINVOKE.FontClient_FindDefaultFont__SWIG_2(swigCPtr, charcode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal uint FindFallbackFont(uint charcode, FontDescription preferredFontDescription, uint requestedPointSize, bool preferColor)
        {
            uint ret = NDalicManualPINVOKE.FontClient_FindFallbackFont__SWIG_0(swigCPtr, charcode, FontDescription.getCPtr(preferredFontDescription), requestedPointSize, preferColor);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal uint FindFallbackFont(uint charcode, FontDescription preferredFontDescription, uint requestedPointSize)
        {
            uint ret = NDalicManualPINVOKE.FontClient_FindFallbackFont__SWIG_1(swigCPtr, charcode, FontDescription.getCPtr(preferredFontDescription), requestedPointSize);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal uint FindFallbackFont(uint charcode, FontDescription preferredFontDescription)
        {
            uint ret = NDalicManualPINVOKE.FontClient_FindFallbackFont__SWIG_2(swigCPtr, charcode, FontDescription.getCPtr(preferredFontDescription));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieve the unique identifier for a font..
        /// </summary>
        /// <param name="path">The path to a font file.</param>
        /// <param name="requestedPointSize">The point size in 26.6 fractional points; the default point size is 12*64.</param>
        /// <param name="faceIndex">The index of the font face.</param>
        /// <returns>A valid font identifier, or zero if the font does not exist.</returns>
        /// <since_tizen> 5 </since_tizen>
        public uint GetFontId(string path, uint requestedPointSize, uint faceIndex)
        {
            uint ret = NDalicManualPINVOKE.FontClient_GetFontId__SWIG_0(swigCPtr, path, requestedPointSize, faceIndex);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieve the unique identifier for a font..
        /// </summary>
        /// <param name="path">The path to a font file.</param>
        /// <param name="requestedPointSize">The point size in 26.6 fractional points; the default point size is 12*64.</param>
        /// <returns>A valid font identifier, or zero if the font does not exist.</returns>
        /// <since_tizen> 5 </since_tizen>
        public uint GetFontId(string path, uint requestedPointSize)
        {
            uint ret = NDalicManualPINVOKE.FontClient_GetFontId__SWIG_1(swigCPtr, path, requestedPointSize);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieve the unique identifier for a font..
        /// </summary>
        /// <param name="path">The path to a font file.</param>
        /// <returns>A valid font identifier, or zero if the font does not exist.</returns>
        /// <since_tizen> 5 </since_tizen>
        public uint GetFontId(string path)
        {
            uint ret = NDalicManualPINVOKE.FontClient_GetFontId__SWIG_2(swigCPtr, path);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal uint GetFontId(FontDescription preferredFontDescription, uint requestedPointSize, uint faceIndex)
        {
            uint ret = NDalicManualPINVOKE.FontClient_GetFontId__SWIG_3(swigCPtr, FontDescription.getCPtr(preferredFontDescription), requestedPointSize, faceIndex);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal uint GetFontId(FontDescription preferredFontDescription, uint requestedPointSize)
        {
            uint ret = NDalicManualPINVOKE.FontClient_GetFontId__SWIG_4(swigCPtr, FontDescription.getCPtr(preferredFontDescription), requestedPointSize);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal uint GetFontId(FontDescription preferredFontDescription)
        {
            uint ret = NDalicManualPINVOKE.FontClient_GetFontId__SWIG_5(swigCPtr, FontDescription.getCPtr(preferredFontDescription));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Check to see if a font is scalable.
        /// </summary>
        /// <param name="path">Path The path to a font file.</param>
        /// <returns>True if scalable.</returns>
        /// <since_tizen> 5 </since_tizen>
        public bool IsScalable(string path)
        {
            bool ret = NDalicManualPINVOKE.FontClient_IsScalable__SWIG_0(swigCPtr, path);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal bool IsScalable(FontDescription fontDescription)
        {
            bool ret = NDalicManualPINVOKE.FontClient_IsScalable__SWIG_1(swigCPtr, FontDescription.getCPtr(fontDescription));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void GetFixedSizes(string path, SWIGTYPE_p_Dali__VectorT_uint32_t_TypeTraitsT_uint32_t_t__IS_TRIVIAL_TYPE__true_t sizes)
        {
            NDalicManualPINVOKE.FontClient_GetFixedSizes__SWIG_0(swigCPtr, path, SWIGTYPE_p_Dali__VectorT_uint32_t_TypeTraitsT_uint32_t_t__IS_TRIVIAL_TYPE__true_t.getCPtr(sizes));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void GetFixedSizes(FontDescription fontDescription, SWIGTYPE_p_Dali__VectorT_uint32_t_TypeTraitsT_uint32_t_t__IS_TRIVIAL_TYPE__true_t sizes)
        {
            NDalicManualPINVOKE.FontClient_GetFixedSizes__SWIG_1(swigCPtr, FontDescription.getCPtr(fontDescription), SWIGTYPE_p_Dali__VectorT_uint32_t_TypeTraitsT_uint32_t_t__IS_TRIVIAL_TYPE__true_t.getCPtr(sizes));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void GetFontMetrics(uint fontId, FontMetrics metrics)
        {
            NDalicManualPINVOKE.FontClient_GetFontMetrics(swigCPtr, fontId, FontMetrics.getCPtr(metrics));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal uint GetGlyphIndex(uint fontId, uint charcode)
        {
            uint ret = NDalicManualPINVOKE.FontClient_GetGlyphIndex(swigCPtr, fontId, charcode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal bool GetGlyphMetrics(GlyphInfo array, uint size, GlyphType type, bool horizontal)
        {
            bool ret = NDalicManualPINVOKE.FontClient_GetGlyphMetrics__SWIG_0(swigCPtr, GlyphInfo.getCPtr(array), size, (int)type, horizontal);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal bool GetGlyphMetrics(GlyphInfo array, uint size, GlyphType type)
        {
            bool ret = NDalicManualPINVOKE.FontClient_GetGlyphMetrics__SWIG_1(swigCPtr, GlyphInfo.getCPtr(array), size, (int)type);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void CreateBitmap(uint fontId, uint glyphIndex, FontClient.GlyphBufferData data, int outlineWidth)
        {
            NDalicManualPINVOKE.FontClient_CreateBitmap__SWIG_0(swigCPtr, fontId, glyphIndex, FontClient.GlyphBufferData.getCPtr(data), outlineWidth);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PixelData CreateBitmap(uint fontId, uint glyphIndex, int outlineWidth)
        {
            PixelData ret = new PixelData(NDalicManualPINVOKE.FontClient_CreateBitmap__SWIG_1(swigCPtr, fontId, glyphIndex, outlineWidth), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void CreateVectorBlob(uint fontId, uint glyphIndex, SWIGTYPE_p_p_Dali__TextAbstraction__VectorBlob blob, SWIGTYPE_p_unsigned_int blobLength, SWIGTYPE_p_unsigned_int nominalWidth, SWIGTYPE_p_unsigned_int nominalHeight)
        {
            NDalicManualPINVOKE.FontClient_CreateVectorBlob(swigCPtr, fontId, glyphIndex, SWIGTYPE_p_p_Dali__TextAbstraction__VectorBlob.getCPtr(blob), SWIGTYPE_p_unsigned_int.getCPtr(blobLength), SWIGTYPE_p_unsigned_int.getCPtr(nominalWidth), SWIGTYPE_p_unsigned_int.getCPtr(nominalHeight));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal GlyphInfo GetEllipsisGlyph(uint requestedPointSize)
        {
            GlyphInfo ret = new GlyphInfo(NDalicManualPINVOKE.FontClient_GetEllipsisGlyph(swigCPtr, requestedPointSize), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal bool IsColorGlyph(uint fontId, uint glyphIndex)
        {
            bool ret = NDalicManualPINVOKE.FontClient_IsColorGlyph(swigCPtr, fontId, glyphIndex);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Add custom fonts directory.
        /// </summary>
        /// <param name="path">Path to the fonts directory.</param>
        /// <returns>True if the fonts can be added.</returns>
        /// <since_tizen> 5 </since_tizen>
        public bool AddCustomFontDirectory(string path)
        {
            bool ret = NDalicManualPINVOKE.FontClient_AddCustomFontDirectory(swigCPtr, path);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
