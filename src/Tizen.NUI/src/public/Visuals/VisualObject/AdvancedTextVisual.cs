// Copyright (c) 2024 Samsung Electronics Co., Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

extern alias TizenSystemSettings;
using TizenSystemSettings.Tizen.System;

using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace Tizen.NUI.Visuals
{
    /// <summary>
    /// The text visual with advanced options.
    /// </summary>
    /// <remarks>
    /// It will be used when we want to control TextVisual with more options.
    /// This visual allow to translated text with SID.
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AdvancedTextVisual : Visuals.TextVisual
    {
        #region Internal
        private string textLabelSid;

        private static Tizen.NUI.SystemLocaleLanguageChanged systemLocaleLanguageChanged = new Tizen.NUI.SystemLocaleLanguageChanged();
        private bool hasSystemLanguageChanged;
        #endregion

        #region Constructor
        public AdvancedTextVisual() : base()
        {
        }
        #endregion

        #region Visual Properties
        /// <summary>
        /// The TranslatableText property.<br />
        /// The text can set the SID value.<br />
        /// </summary>
        /// <exception cref='global::System.ArgumentNullException'>
        /// ResourceManager about multilingual is null.
        /// </exception>
        public string TranslatableText
        {
            get
            {
                return textLabelSid;
            }
            set
            {
                if (NUIApplication.MultilingualResourceManager == null)
                {
                    throw new global::System.ArgumentNullException(null, "ResourceManager about multilingual is null");
                }
                string translatableText = null;
                textLabelSid = value;
                translatableText = NUIApplication.MultilingualResourceManager?.GetString(textLabelSid, new global::System.Globalization.CultureInfo(SystemSettings.LocaleLanguage.Replace("_", "-")));

                if (translatableText != null)
                {
                    Text = translatableText;
                    if (hasSystemLanguageChanged == false)
                    {
                        systemLocaleLanguageChanged.Add(SystemSettingsLocaleLanguageChanged);
                        hasSystemLanguageChanged = true;
                    }
                }
                else
                {
                    Text = value;
                }
            }
        }
        #endregion

        #region Internal Method
        private void SystemSettingsLocaleLanguageChanged(object sender, LocaleLanguageChangedEventArgs e)
        {
            string translatableText = null;
            translatableText = NUIApplication.MultilingualResourceManager?.GetString(textLabelSid, new global::System.Globalization.CultureInfo(e.Value.Replace("_", "-")));
            if (translatableText != null)
            {
                Text = translatableText;
            }
            else
            {
                Tizen.Log.Error("NUI", $"Fail to get translated text : {textLabelSid};");
                Text = textLabelSid;
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (hasSystemLanguageChanged)
            {
                systemLocaleLanguageChanged.Remove(SystemSettingsLocaleLanguageChanged);
            }

            base.Dispose(type);
        }
        #endregion
    }
}