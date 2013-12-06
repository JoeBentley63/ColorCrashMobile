using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameForTablet
{
    class PlayState : Scene
    {
        HUD _hud;
        BlockSpawner _spawner;
        public static bool _finished = false;
        private Texture2D _scenery;
        public static bool _paused;        
        SpriteLoader _preloader = SpriteLoader.GetInstance();
        Button _pauseButton;
        Button _unPauseButton;
        Button _quitButton;
        SceneManager _sceneManager;
        public PlayState(GraphicsDevice _graphicsDevice)
        {
            _hud = new HUD();
            _spawner = new BlockSpawner(_graphicsDevice);
            _preloader.PlayMusic(Menu._song);
            _scenery = _preloader.Load("scene");
            _pauseButton = new Button(new Vector2(150, 730), SceneManager.Scenes.PAUSED, "Pause", true);
            _unPauseButton = new Button(new Vector2(150, 200), SceneManager.Scenes.UNPAUSED, "Continue?", true);
            _quitButton = new Button(new Vector2(150, 300), SceneManager.Scenes.MENU, "Quit?", true);
            _sceneManager = SceneManager.GetInstance();
        }

        public override void Update()
        {
            if (!_paused)
            {
                _pauseButton.Update();
                if (HUD._barAmount < 1)
                {
                    _sceneManager.ChangeScene(SceneManager.Scenes.SCORE);
                }


                if (!_finished)
                {
                    _spawner.Update();
                    _hud.Update();
                }
            }
            else
            {
                _unPauseButton.Update();
                _quitButton.Update();
            }
           
        }
        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(_scenery, new Vector2(-10,0), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            if (!_paused)
            {
                _pauseButton.Draw(_spriteBatch);
            }
            else
            {
                _unPauseButton.Draw(_spriteBatch);
                _quitButton.Draw(_spriteBatch);
            }
            _hud.Draw(_spriteBatch);
            if (!_finished)
            {

                _spawner.Draw(_spriteBatch);
            }
        }
    
    }

}
