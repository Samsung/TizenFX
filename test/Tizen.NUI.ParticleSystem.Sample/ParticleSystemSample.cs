using System;
using System.Collections.Generic;
using System.Threading;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.ParticleSystem;

namespace Tizen.NUI.ParticleSystem.Sample
{
    // SparkleEffectSource spawns particle from the middle of the
    // window.
    class SparkleEffectSource : ParticleSourceInterface
    {
        public override void Construct(params object[] list)
        {
            base.Construct(list);
            mRadius = new Vector2(list[0] as Vector2);
        }

        public override uint Update(ParticleEmitterProxy emitterProxy, uint count)
        {
            if(mStreamBasePos == 0 || mStreamBaseAngle == 0) // streams must exist
            {
                return 0u;
            }

            while(count > 0)
            {
                // Create new particle (lifetime 5 seconds of each)
                var particle = emitterProxy.NewParticle(5.0f);
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

        void UpdateParticle(ref Particle p)
        {
            float posRadians   = ((mRandom.Next() % 360) * (float)Math.PI) / 180.0f;
            p.Position = new Vector3(mRadius.X * (float)Math.Sin(posRadians), mRadius.Y * (float)Math.Cos(posRadians), 0.0f);
            p.SetStreamValue(p.Position, mStreamBasePos);
            p.Color = Vector4.One;
            p.SetStreamValue(mAngle, mStreamBaseAngle);
            mAngle = ((mAngle+5)%360);
            float rad   = ((mRandom.Next() % 360) * (float)Math.PI) / 180.0f;
            float speed = ((mRandom.Next() % 5) + 5);
            p.Velocity = new Vector3((float)Math.Sin(rad) * speed, (float)Math.Cos(rad) * speed, 0);

            // Random initial scale
            float initialScale = (float)(mRandom.Next() % 32) + 32;
            p.Scale = new Vector3(initialScale, initialScale, 1.0f);
        }

        private static float mAngle = 0;
        private Random mRandom = new Random();
        public uint mStreamBasePos = 0;
        public uint mStreamBaseAngle = 0;
        private Vector2 mRadius;
    }

    // SparkleEffectModifier spawns particle from the middle of the
    // window.
    class SparkleEffectModifier : ParticleModifierInterface
    {
        public override void Construct(params object[] list)
        {
            base.Construct(list);
            mSource = list[0] as SparkleEffectSource;
        }

        public override void Update(ParticleEmitterProxy proxy, List<Particle> particles)
        {
            if (particles.Count == 0)
            {
                return;
            }

            if (mStreamBasePos == 0)
            {
                mStreamBasePos = mSource.mStreamBasePos;
            }

            if (mStreamBaseAngle == 0)
            {
                mStreamBaseAngle = mSource.mStreamBaseAngle;
            }

            if (mStreamBasePos == 0)
            {
                return;
            }

            for (uint i = 0; i < particles.Count; ++i)
            {
                var p = particles[(int)i];

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

                var color = new Vector4( 1, 1, 1, normalizedTime);
                p.Color = color;
                p.Scale = new Vector3(64.0f*(normalizedTime * normalizedTime * normalizedTime * normalizedTime), 64.0f*(normalizedTime * normalizedTime * normalizedTime * normalizedTime), 1.0f);

            }
        }

        private uint mStreamBasePos = 0;
        private uint mStreamBaseAngle = 0;
        private SparkleEffectSource mSource;

    }

    class ParticleSystemSample : NUIApplication
    {
        static string IMAGE_DIR = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "image/";

        private Window mWindow;

        private ParticleEmitter mEmitter;
        private ParticleSource<SparkleEffectSource> mSource;
        private ParticleModifier<SparkleEffectModifier> mModifier;

        public void Activate()
        {
            mWindow = Window.Instance;
            mWindow.BackgroundColor = Color.Black;

            var view = new View();
            view.BackgroundColor = Color.Wheat;
            view.Size = new Size(mWindow.Size.Width, mWindow.Size.Height);
            view.PivotPoint = PivotPoint.Center;
            view.ParentOrigin = ParentOrigin.TopLeft;
            view.Position2D = new Position2D(0, 0);
            mWindow.Add(view);
            // Attach emitter to view
            mEmitter = new ParticleEmitter(view)
            {
                ParticleCount = 10000,
                EmissionRate = 500,
                InitialParticleCount = 0,
                RendererBlendingMode = ParticleBlendingMode.Screen
            };

            mSource = new ParticleSource<SparkleEffectSource>(new Vector2(50, 50));
            mModifier = new ParticleModifier<SparkleEffectModifier>(mSource.Callback);

            mEmitter.SetSource(mSource);
            mEmitter.AddModifier(mModifier);

            // Load texture
            mEmitter.TextureResourceUrl = IMAGE_DIR + "/blue-part2.png";
            mEmitter.Start();
        }

        protected override void OnCreate()
        {
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
            ParticleSystemSample example = new ParticleSystemSample();
            example.Run(args);
        }
    }
}
