using System;
using System.Threading;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.ParticleSystem;

namespace Tizen.NUI.ParticleSystem.Sample
{
    class SparkleEffectSource : ParticleSourceInterface
    {
        public override void Construct(params object[] list)
        {
            base.Construct(list);
            mRadius = new Vector2(list[0] as Vector2);
        }
        
        public override uint Update(ParticleList particleList, uint count)
        {
            if(mStreamBasePos == 0 || mStreamBaseAngle == 0) // streams must exist 
            {
                return 0u;
            }

            while(count > 0)
            {
                // Create new particle
                var particle = particleList.NewParticle(5.0f);
                if(particle == null)
                {
                    return 0u;
                }
                
                UpdateParticle(ref particle);
                
                count--;
            }
            return 0;
        }
        
        public override void Init()
        {
            
            // Add local stream of Vector3 type
            mStreamBasePos = Emitter.AddLocalStreamVector3(Vector3.Zero);
            
            // Add local stream of float type
            mStreamBaseAngle = Emitter.AddLocalStreamFloat(0.0f);
        }

        private static float a = 0;
        private Random mRandom = new Random();
        void UpdateParticle(ref Particle p)//ref Vector3 position, ref Vector3 basePosition, ref Vector4 color, ref Vector3 velocity, ref Vector3 scale, ref float angle)
        {
            //Console.ReadLine();
            float posRadians   = ((mRandom.Next() % 360) * (float)Math.PI) / 180.0f;

            var tmp = new Vector3(mRadius.X * (float)Math.Sin(posRadians), mRadius.Y * (float)Math.Cos(posRadians), 0.0f);
            p.Position = tmp;
            var tmp2 = p.Position;
            p.SetStreamValue(p.Position, mStreamBasePos);

            Vector3 baseTest = p.GetStreamValue(mStreamBasePos);

            //Console.ReadLine();
            p.Color = Vector4.One;
            Vector4 col = p.Color;
            p.SetStreamValue(a, mStreamBaseAngle);
            float baseAngle = p.GetStreamValue(mStreamBaseAngle);
            
            a = ((a+5)%360);
            float rad   = ((mRandom.Next() % 360) * (float)Math.PI) / 180.0f;
            float speed = ((mRandom.Next() % 5) + 5);
            
            tmp = new Vector3((float)Math.Sin(rad) * speed, (float)Math.Cos(rad) * speed, 0);
            p.Velocity = tmp;
            tmp2 = p.Velocity;
            
            // Random initial scale
            float initialScale = (float)(mRandom.Next() % 32) + 32;
            p.Scale = new Vector3(initialScale, initialScale, 1.0f);
            tmp = p.Scale;
        }
        
        public uint mStreamBasePos = 0;
        public uint mStreamBaseAngle = 0;
        private Vector2 mRadius;
    }

    class SparkleEffectModifier : ParticleModifierInterface
    {
        public override void Construct(params object[] list)
        {
            base.Construct(list);
            Console.WriteLine("yay!");
        }

        public override void Update(ParticleList particleList, uint first, uint count)
        {
            Console.WriteLine( "updating sparkles!");

            if (count == 0)
            {
                return;
            }

            if (mStreamBasePos == 0)
            {
                var source = Emitter.GetSource<SparkleEffectSource>().GetCallbackInterface() as SparkleEffectSource;
                mStreamBasePos = source.mStreamBasePos;
            }

            if (mStreamBaseAngle == 0)
            {
                var source = Emitter.GetSource<SparkleEffectSource>().GetCallbackInterface() as SparkleEffectSource;
                mStreamBaseAngle = source.mStreamBaseAngle;
            }

            if (mStreamBasePos == 0)
            {
                return;
            }

            for (uint i = 0; i < count; ++i)
            {
                var p = particleList.GetParticle(i);
                
                float angle = p.GetStreamValue(mStreamBaseAngle);
                Vector3 basePos = p.GetStreamValue(mStreamBaseAngle);
                float radians  = (float)((angle * Math.PI)/180.0f);
                float lifetime = p.Lifetime;
                Vector3 pos = p.Position;
                var vel = p.Velocity;
                p.Position = new Vector3(pos.X + vel.X * (float)Math.Cos(radians),pos.Y + vel.Y * (float)Math.Sin(radians),
                     pos.Z);

                p.Velocity = (vel * 0.990f);
                float normalizedTime = (lifetime / p.LifetimeBase);

                var color = p.Color;
                color.A = normalizedTime;
                p.Color = color;
                p.Scale = new Vector3(64.0f*(normalizedTime * normalizedTime * normalizedTime * normalizedTime), 64.0f*(normalizedTime * normalizedTime * normalizedTime * normalizedTime), 1.0f);
                 
            }
            Console.WriteLine("Modified");
            

        }

        private uint mStreamBasePos = 0;
        private uint mStreamBaseAngle = 0;
    }
    

    class ParticleSystemSample : NUIApplication
    {
        static string IMAGE_DIR = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "image/";

        private Window mWindow;

        private ParticleEmitter mEmitter;
        private ParticleSource<SparkleEffectSource> mSource;
        private ParticleModifier<SparkleEffectModifier> mModifier;
        private ParticleRenderer mRenderer;
        public void Activate()
        {
            /*
            for (int i = 0; i < 10; ++i)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);    
            }*/
            
            mWindow = Window.Instance;
            mWindow.BackgroundColor = Color.Black;

            var view = new View();
            view.BackgroundColor = Color.Wheat;
            view.Size = new Size(1, 1);
            view.PivotPoint = new Position(0, 0);
            view.Position2D = new Position2D(mWindow.Size.Width/2, mWindow.Size.Height/2);
            mWindow.Add(view);
            // Attach emitter to view
            mEmitter = new ParticleEmitter(view);
            
                //params.particleCount        = 10000;
                //params.emissionRate         = 500;
                //params.initialParticleCount = 0;
            mEmitter.SetParticleCount(10000);
            mEmitter.SetEmissionRate(500);
            mEmitter.SetInitialParticleCount(0);
            mSource = new ParticleSource<SparkleEffectSource>(new Vector2(50, 50));
            mModifier = new ParticleModifier<SparkleEffectModifier>(10);
            mRenderer = new ParticleRenderer();
            
            mEmitter.SetSource(mSource);
            mEmitter.AddModifier(mModifier);
            mEmitter.SetRenderer(mRenderer);
            var pixelBuffer = ImageLoader.LoadImageFromFile("/tmp/blue-part2.png");

            Texture tex = new Texture(TextureType.TEXTURE_2D, PixelFormat.RGBA8888, pixelBuffer.GetWidth(),
                pixelBuffer.GetHeight());
            tex.Upload(pixelBuffer.CreatePixelData());
            mRenderer.SetTexture(tex);
            mEmitter.Start();
        }

        private Texture mTexture;
        protected override void OnCreate()
        {
            Console.WriteLine("OnCreate!");
            // Up call to the Base class first
            base.OnCreate();
            Activate();
        }
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread] // Forces app to use one thread to access NUI
        static void Main(string[] args)
        {
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
            ParticleSystemSample example = new ParticleSystemSample();
            example.Run(args);
        }
    }
}
