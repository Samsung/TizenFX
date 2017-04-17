using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.Constants;
using System;

namespace FirstScreen
{
    public class FocusData
    {
        private string _name;                 // Name used for FocusData object (mainly to differentiate key frame animation )
        private string _imageName;            // Image File Name (to be loaded from disk) used for ImageView used in key frame animation
        private Position _parentOrigin;        // ParentOrigin applied to ImageView
        private Size _initSize;            // InitSize used for key frame animation
        private Size _targetSize;          // TargetSize used for key frame animation
        private float _keyFrameStart;         // KeyFrameStart used for key frame animation
        private float _keyFrameEnd;           // KeyFrameEnd used for key frame animation
        private Direction _direction;         // Direction used for key frame animation
        private ImageView _imageFocus;        // ImageView used in key frame animation

        // Initialize FocusData used for key frame animation
        public FocusData(string name, string imageName, Direction direction, Position parentOrigin, Size initSize,
                         Size targetSize, float keyFrameStart, float keyFrameEnd)
        {
            _name = name;
            _imageName = imageName;
            _parentOrigin = parentOrigin;
            _initSize = initSize;
            _targetSize = targetSize;
            _keyFrameStart = keyFrameStart;
            _keyFrameEnd = keyFrameEnd;
            _direction = direction;

            _imageFocus = new ImageView(Constants.ImageResourcePath + "/focuseffect/" + _imageName); // Target

            _imageFocus.ParentOrigin = _parentOrigin;
            _imageFocus.AnchorPoint = AnchorPoint.Center;
            _imageFocus.Name = _name;
        }

        public enum Direction
        {
            Horizontal,
            Vertical
        };

        public Direction FocusDirection
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string ImageName
        {
            get { return _imageName; }
            set { _imageName = value; }
        }

        public Position ParentOrigin
        {
            get
            {
                return _parentOrigin;
            }

            set
            {
                _parentOrigin = value;
                _imageFocus.ParentOrigin = _parentOrigin;
            }
        }

        public Size InitSize
        {
            get { return _initSize; }
            set { _initSize = value; }
        }

        public Size TargetSize
        {
            get { return _targetSize; }
            set { _targetSize = value; }
        }

        public float KeyFrameStart
        {
            get { return _keyFrameStart; }
            set { _keyFrameStart = value; }
        }

        public float KeyFrameEnd
        {
            get { return _keyFrameEnd; }
            set { _keyFrameEnd = value; }
        }

        public ImageView ImageItem
        {
            get { return _imageFocus; }
        }

    }
}
