using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GameForTablet
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private SpriteLoader _preloader;
        SceneManager _sceneManager;
        public static int _screenWidth;
        public static int _screenHeight;
        public Game1()
        {
          
            graphics = new GraphicsDeviceManager(this);
          // graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 480;
            graphics.PreferredBackBufferHeight = 800;
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            
            base.Initialize();
         

            _screenHeight = GraphicsDevice.Viewport.Height;
            _screenWidth = GraphicsDevice.Viewport.Width;

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _preloader = SpriteLoader.GetInstance();//load them sprites;
            _preloader.setContentManager(Content);
            _sceneManager = SceneManager.GetInstance();
            _sceneManager.SetGraphicsDevice(GraphicsDevice);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            _sceneManager.Update();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                PlayState._paused = true;
                Guide.BeginShowMessageBox("App Quit", "Do you want to quit this app?", new List<string> { "Yep!", "NO!!" }, 0, MessageBoxIcon.None,
             asyncResult =>
             {
                 int? returned = Guide.EndShowMessageBox(asyncResult);
                 if (returned == 0)
                 {
                     this.Exit();
                 }
                 else
                 {
                     PlayState._paused = false;
                 }
             }, null);
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed)
            {
                PlayState._paused = true;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            _sceneManager.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
