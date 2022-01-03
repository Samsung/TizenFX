using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class SwipeViewTest1Page : ContentPage
    {
        private PanGestureDetector panGestureDetector;
        private Direction swipeDirection = Direction.Vertical;
        private Position initPosition;
        private int swipeCount;

        public enum Direction
        {
            Horizontal,
            Vertical
        }

        public SwipeViewTest1Page()
        {
            InitializeComponent();

            swipeCount = 0;

            imageView.Scale = imageView.Scale * new Vector3(1.2f, 1.2f, 1.0f);

            initPosition = imageView.Position;

            ContentView.Padding = new Extents(20, 20, 20, 20);

            panGestureDetector = new PanGestureDetector();
            panGestureDetector.Attach(imageView);
            panGestureDetector.Detected += (obj, e) =>
            {
                Vector2 velocity = e.PanGesture.Velocity;
                if (e.PanGesture.State == Gesture.StateType.Started)
                {
                    if (velocity.X != 0 )
                    {
                        swipeDirection = Direction.Horizontal;
                        if (velocity.X > 0) {
                            image1.Size = new Size(100, 100);
                        }
                        else
                        {
                            image2.Size = new Size(100, 100);
                        }
                    }
                    else if (velocity.Y != 0)
                    {
                        swipeDirection = Direction.Vertical;

                        swipeCount++;
                        if ((swipeCount % 2) > 0)
                        {
                            imageView.BorderlineWidth = 5f;
                            imageView.BorderlineColor = Color.Green;
                        }
                        else
                        {
                            imageView.BorderlineWidth = 0f;
                        }

                        text2.Text = "Item";
                        text3.Text = "Item";

                    }
                }
                else if (e.PanGesture.State == Gesture.StateType.Continuing)
                {
                    if (swipeDirection == Direction.Vertical && imageView.Position.Y < 70 && imageView.Position.Y > -70)
                    {
                        imageView.Position += new Position(0, e.PanGesture.ScreenDisplacement.Y, 0);
                    }
                    else if (swipeDirection == Direction.Horizontal && imageView.Position.X < 70 && imageView.Position.X > -70)
                    {
                        imageView.Position += new Position(e.PanGesture.ScreenDisplacement.X, 0, 0);
                    }
                }
                else if (e.PanGesture.State == Gesture.StateType.Finished || e.PanGesture.State == Gesture.StateType.Cancelled)
                {
                    imageView.Position = initPosition;

                    image1.Size = new Size(0, 0);
                    image2.Size = new Size(0, 0);

                    text2.Text = "";
                    text3.Text = "";
                }

            };

        }
    }
}
