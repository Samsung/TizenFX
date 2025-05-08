/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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

using System.ComponentModel;

/// <summary>
/// Enumeration for predefined spring animation types.
/// This presets are based on typical spring behavior tuned for different motion effects.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public enum AlphaFunctionSpringType
{
    /// <summary>
    /// Gentle spring. slower and smoother motion with less oscillation.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    Gentle,

    /// <summary>
    /// Quick spring, Fast settling animation with minimal overshoot.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    Quick,

    /// <summary>
    /// Bouncy spring. Highly elastic and oscillatory animation.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    Bouncy,

    /// <summary>
    /// Slow spring. Smooth and relaxed motion with longer settling.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    Slow
}