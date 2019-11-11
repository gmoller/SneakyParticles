using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SneakyParticleSystem;
using SneakyParticleSystem.Actions;
using SneakyParticleSystem.Shapes;

namespace SneakyParticles
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private ParticleSystemRenderer _particleSystemRenderer;
        private Emitter _particleEmitter1;
        private Emitter _particleEmitter2;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            var actions = new List<IAction>
            {
                new MoveAction(),
                new ShrinkSizeAction(),
                new ChangeColorAction(new ColorRgba(255, 255, 0), new ColorRgba(0, 0, 255)),
                new FadeAction(255, 0)
            };

            var randomGenerator = new RandomWrapper();

            _particleEmitter1 = new Emitter(
                new EmitterConfig
                {
                    EmitterShape = new PointEmitter(new ThreeSixty(50, 100, randomGenerator)),
                    InitialColorCalculator = new Varied(new ColorRgba(255, 255, 0), new ColorRgba(20, 20, 20), randomGenerator),
                    FinalColorCalculator = new Varied(new ColorRgba(0, 0, 255), new ColorRgba(20, 20, 20), randomGenerator),
                    InitialSizeCalculator = new RandomBetweenXAndY(0.1f, 2.0f, randomGenerator),
                    EmissionRatePerSecond = 200,
                    MaximumNumberOfParticles = 1000,
                    Actions = actions
                });
            _particleEmitter1.Location = new SneakyParticleSystem.Vector2(100.0f, 100.0f);

            _particleEmitter2 = new Emitter(
                new EmitterConfig
                {
                    EmitterShape = new CircleEmitter(100.0f, new Normal(1, 100, randomGenerator), randomGenerator),
                    InitialColorCalculator = new Simple(new ColorRgba(255, 0, 0)),
                    FinalColorCalculator = new Simple(new ColorRgba(255, 255, 0)),
                    InitialSizeCalculator = new RandomBetweenXAndY(0.1f, 2.0f, randomGenerator),
                    EmissionRatePerSecond = 200,
                    MaximumNumberOfParticles = 1000,
                    Actions = actions
                });
            _particleEmitter2.Location = new SneakyParticleSystem.Vector2(400.0f, 300.0f);

            _particleSystemRenderer = new ParticleSystemRenderer();
            _particleSystemRenderer.LoadContent(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _particleEmitter1.Location = new SneakyParticleSystem.Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y);

            _particleEmitter1.Emit((float)gameTime.ElapsedGameTime.TotalSeconds);
            _particleEmitter1.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            _particleEmitter2.Emit((float)gameTime.ElapsedGameTime.TotalSeconds);
            _particleEmitter2.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);

            _particleSystemRenderer.Particles = _particleEmitter1.Particles;
            _particleSystemRenderer.ParticleCount = _particleEmitter1.ParticleCount;
            _particleSystemRenderer.Draw(spriteBatch);

            _particleSystemRenderer.Particles = _particleEmitter2.Particles;
            _particleSystemRenderer.ParticleCount = _particleEmitter2.ParticleCount;
            _particleSystemRenderer.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
