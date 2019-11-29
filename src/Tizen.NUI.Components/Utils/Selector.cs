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

namespace Tizen.NUI.BaseComponents
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
        public IntSelector Clone()
        {
            IntSelector selector = new IntSelector();
            selector.Clone(this);
            return selector;
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
        /// Float selector clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FloatSelector Clone()
        {
            FloatSelector selector = new FloatSelector();
            selector.Clone(this);
            return selector;
        }
    }
    /// <summary>
    /// Bool selector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    internal class BoolSelector : Selector<bool?>
    {
        /// <summary>
        /// Bool selector clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BoolSelector Clone()
        {
            BoolSelector selector = new BoolSelector();
            selector.Clone(this);
            return selector;
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
        /// String selector clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector Clone()
        {
            StringSelector selector = new StringSelector();
            selector.Clone(this);
            return selector; 
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
        /// Color selector clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorSelector Clone()
        {
            ColorSelector selector = new ColorSelector();
            selector.Clone(this);
            return selector;
        }
    }

    /// <summary>
    /// Size2D selector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    internal class Size2DSelector : Selector<Size2D>
    {
        /// <summary>
        /// Size2D selector clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2DSelector Clone()
        {
            Size2DSelector selector = new Size2DSelector();
            selector.Clone(this);
            return selector;
        }
    }
    /// <summary>
    /// Position2D selector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    internal class Position2DSelector : Selector<Position2D>
    {
        /// <summary>
        /// Position2D selector clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position2DSelector Clone()
        {
            Position2DSelector selector = new Position2DSelector();
            selector.Clone(this);
            return selector;
        }
    }

    /// <summary>
    /// Position selector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    internal class PositionSelector : Selector<Position>
    {
        /// <summary>
        /// Position selector clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PositionSelector Clone()
        {
            PositionSelector selector = new PositionSelector();
            selector.Clone(this);
            return selector;
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
        public Vector2Selector Clone()
        {
            Vector2Selector selector = new Vector2Selector();
            selector.Clone(this);
            return selector;
        }
    }

    /// <summary>
    /// Vector3 selector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    internal class Vector3Selector : Selector<Vector3>
    {
        /// <summary>
        /// Vector3 selector clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3Selector Clone()
        {
            Vector3Selector selector = new Vector3Selector();
            selector.Clone(this);
            return selector;
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
        public RectangleSelector Clone()
        {
            RectangleSelector selector = new RectangleSelector();
            selector.Clone(this);
            return selector;
        }
    }

    /// <summary>
    /// Horizontal alignment selector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    internal class HorizontalAlignmentSelector : Selector<HorizontalAlignment?>
    {
        /// <summary>
        /// Horizontal alignment selector clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HorizontalAlignmentSelector Clone()
        {
            HorizontalAlignmentSelector selector = new HorizontalAlignmentSelector();
            selector.Clone(this);
            return selector;
        }
    }
    /// <summary>
    /// Vertical alignment selector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    internal class VerticalAlignmentSelector : Selector<VerticalAlignment?>
    {
        /// <summary>
        /// Vertical alignment selector clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VerticalAlignmentSelector Clone()
        {
            VerticalAlignmentSelector selector = new VerticalAlignmentSelector();
            selector.Clone(this);
            return selector;
        }
    }

    /// <summary>
    /// AutoScrollStopMode selector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    internal class AutoScrollStopModeSelector : Selector<AutoScrollStopMode?>
    {
        /// <summary>
        /// AutoScrollStopMode selector clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AutoScrollStopModeSelector Clone()
        {
            AutoScrollStopModeSelector selector = new AutoScrollStopModeSelector();
            selector.Clone(this);
            return selector;
        }
    }

    /// <summary>
    /// ResizePolicyType selector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    internal class ResizePolicyTypeSelector : Selector<ResizePolicyType?>
    {
        /// <summary>
        /// ResizePolicyType selector clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResizePolicyTypeSelector Clone()
        {
            ResizePolicyTypeSelector selector = new ResizePolicyTypeSelector();
            selector.Clone(this);
            return selector;
        }
    }

}
