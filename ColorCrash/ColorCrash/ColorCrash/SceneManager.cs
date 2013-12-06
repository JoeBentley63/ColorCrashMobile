using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace GameForTablet
{
    class SceneManager
    {
        public enum Scenes
        {
            SPLASH,
            MENU,
            PLAYSTATE,
            CREDITS,
            SCORE,
            HOWTO,
            PAUSED,
            UNPAUSED,
            SONG1,
            SONG2,
            SONG3,
            SONG4,
            SONG5,
            MUSIC,
        };
        public Scene _currentScene = null;
        private static SceneManager _me;
        private GraphicsDevice _graphicsDevice = null;
        private SpriteLoader _preloader;

        public static SceneManager GetInstance()
        {
            if (_me == null)
            {
                _me = new SceneManager();
            }
            return _me;
        }


        public SceneManager()
        {

            _preloader = SpriteLoader.GetInstance();
            
        }
        public void Update()
        {
            _currentScene.Update();
        }
        public void SetGraphicsDevice(GraphicsDevice _graphicsDevice)
        {
            this._graphicsDevice = _graphicsDevice;
            _me._graphicsDevice = _graphicsDevice;
            _currentScene = new Splash();
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _currentScene.Draw(_spriteBatch);
        }
        public void ChangeScene(Scenes _scene)
        {
            PlayState._paused = false;
            switch (_scene)
            {
                case Scenes.SPLASH:

                    _currentScene = new Splash();
                   
                    break;
                case Scenes.MENU:

                    _currentScene = new Menu();

                    break;
                case Scenes.PLAYSTATE:

                    _currentScene = new PlayState(_graphicsDevice);

                    break;

                case Scenes.CREDITS:

                    _currentScene = new Credits();

                    break;

                case Scenes.HOWTO:

                    _currentScene = new TutorialScreen();

                    break;

                case Scenes.SCORE:
                    _currentScene = new WinScreen();
                    //();

                    break;
                case Scenes.PAUSED:
                    PlayState._paused = true;

                    break;

                case Scenes.UNPAUSED:
                    PlayState._paused = false;

                    break;

                case Scenes.SONG1:

                    Menu._song = "song1";
                    _preloader.PlayMusic( Menu._song);
                  
                    break;
                case Scenes.SONG2:
                    Menu._song = "song2";
                    _preloader.PlayMusic(Menu._song);

                    break;
                case Scenes.SONG3:
                    Menu._song = "song3";
                    _preloader.PlayMusic(Menu._song);

                    break;
                case Scenes.SONG4:
                    Menu._song = "song4";
                    _preloader.PlayMusic(Menu._song);

                    break;
                case Scenes.SONG5:
                    Menu._song = "song5";
                    _preloader.PlayMusic(Menu._song);

                    break;
                case Scenes.MUSIC:

                    Menu _tempMenu = _currentScene as Menu;
                    _tempMenu.DisplayMusicRequest(true);

                    break;
            }
        }
    }
}
