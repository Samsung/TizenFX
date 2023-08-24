/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Int selector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class IntSelector : Selector<int?>
    {
        /// <summary>
        /// Int selector clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new IntSelector Clone()
        {
            return (IntSelector)base.Clone();
        }
    }

    /// <summary>
    /// Float selector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class FloatSelector : Selector<float?>
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FloatSelector() : base()
        {
        }

        /// <summary>
        /// Constructor with base class object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FloatSelector(Selector<float?> selector) : base(selector)
        {
        }

        /// <summary>
        /// Float selector clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new FloatSelector Clone()
        {
            return (FloatSelector)base.Clone();
        }
    }
    /// <summary>
    /// Bool selector.
    /// </summary>
    internal class BoolSelector : Selector<bool?>
    {
        /// <summary>
        /// Bool selector clone function.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new BoolSelector Clone()
        {
            return (BoolSelector)base.Clone();
        }
    }
    /// <summary>
    /// String selector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class StringSelector : Selector<string>
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector() : base()
        {
        }

        /// <summary>
        /// Constructor with base class object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector(Selector<string> selector) : base(selector)
        {
        }

        /// <summary>
        /// String selector clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new StringSelector Clone()
        {
            return (StringSelector)base.Clone();
        }
    }

    /// <summary>
    /// Color selector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ColorSelector : Selector<Color>
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorSelector() : base()
        {
        }

        /// <summary>
        /// Constructor with base class object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorSelector(Selector<Color> selector) : base(selector)
        {
        }

        /// <summary>
        /// Color selector clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ColorSelector Clone()
        {
            return (ColorSelector)base.Clone();
        }
    }

    /// <summary>
    /// Size2D selector.
    /// </summary>
    internal class Size2DSelector : Selector<Size2D>
    {
        /// <summary>
        /// Size2D selector clone function.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Size2DSelector Clone()
        {
            return (Size2DSelector)base.Clone();
        }
    }
    /// <summary>
    /// Position2D selector.
    /// </summary>
    internal class Position2DSelector : Selector<Position2D>
    {
        /// <summary>
        /// Position2D selector clone function.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Position2DSelector Clone()
        {
            return (Position2DSelector)base.Clone();
        }
    }

    /// <summary>
    /// Position selector.
    /// </summary>
    internal class PositionSelector : Selector<Position>
    {
        /// <summary>
        /// Position selector clone function.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new PositionSelector Clone()
        {
            return (PositionSelector)base.Clone();
        }
    }

    /// <summary>
    /// Vector2 selector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Vector2Selector : Selector<Vector2>
    {
        /// <summary>
        /// Vector selector clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Vector2Selector Clone()
        {
            return (Vector2Selector)base.Clone();
        }
    }

    /// <summary>
    /// Vector3 selector.
    /// </summary>
    internal class Vector3Selector : Selector<Vector3>
    {
        /// <summary>
        /// Vector3 selector clone function.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Vector3Selector Clone()
        {
            return (Vector3Selector)base.Clone();
        }
    }

    /// <summary>
    /// Rectangle selector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RectangleSelector : Selector<Rectangle>
    {
        /// <summary>
        /// Rectangle selector clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new RectangleSelector Clone()
        {
            return (RectangleSelector)base.Clone();
        }
    }

    /// <summary>
    /// Horizontal alignment selector.
    /// </summary>
    internal class HorizontalAlignmentSelector : Selector<HorizontalAlignment?>
    {
        /// <summary>
        /// Horizontal alignment selector clone function.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new HorizontalAlignmentSelector Clone()
        {
            return (HorizontalAlignmentSelector)base.Clone();
        }
    }
    /// <summary>
    /// Vertical alignment selector.
    /// </summary>
    internal class VerticalAlignmentSelector : Selector<VerticalAlignment?>
    {
        /// <summary>
        /// Vertical alignment selector clone function.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new VerticalAlignmentSelector Clone()
        {
            return (VerticalAlignmentSelector)base.Clone();
        }
    }

    /// <summary>
    /// AutoScrollStopMode selector.
    /// </summary>
    internal class AutoScrollStopModeSelector : Selector<AutoScrollStopMode?>
    {
        /// <summary>
        /// AutoScrollStopMode selector clone function.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new AutoScrollStopModeSelector Clone()
        {
            return (AutoScrollStopModeSelector)base.Clone();
        }
    }

    /// <summary>
    /// ResizePolicyType selector.
    /// </summary>
    internal class ResizePolicyTypeSelector : Selector<ResizePolicyType?>
    {
        /// <summary>
        /// ResizePolicyType selector clone function.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ResizePolicyTypeSelector Clone()
        {
            return (ResizePolicyTypeSelector)base.Clone();
        }
    }

}
