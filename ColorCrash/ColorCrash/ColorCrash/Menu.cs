using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.GamerServices;

namespace GameForTablet
{
    class Menu : Scene
    {
        public static bool _playingMusic = false;
        SceneManager _sceneManager ;
        public static String _song = "song1";
        List<isBlock> _fallers = new List<isBlock>();
        //private Texture2D _cursor;
        private Texture2D _scenery;
        private Texture2D _title;
        private Vector2 _titlePos = new Vector2(20,-100);
        SpriteLoader _preloader;
        List<Button> _buttons = new List<Button>();
        DAO _dao = DAO.GetInstance();
        string _highScores;
        public static bool _once = false;
        public Menu()
        {
            if (_once == false)
            {
                _once = true;
                DisplayMusicRequest(true);
            }
           
            _dao.Load();
            _preloader = SpriteLoader.GetInstance();
            _sceneManager = SceneManager.GetInstance();
           // _cursor = _preloader.Load("cursor");
            _scenery = _preloader.Load("scene");
            _title = _preloader.Load("title");
            _buttons.Add(new Button(new Vector2(260, 300), SceneManager.Scenes.PLAYSTATE, "Play", true));
            _buttons.Add(new Button(new Vector2(260, 400), SceneManager.Scenes.CREDITS, "Credits", true));
            _buttons.Add(new Button(new Vector2(260, 500), SceneManager.Scenes.HOWTO, "How To", true));
            _buttons.Add(new Button(new Vector2(20, 700), SceneManager.Scenes.SONG1, "Track 1",false));
            _buttons.Add(new Button(new Vector2(115, 700), SceneManager.Scenes.SONG2, "Track 2", false));
            _buttons.Add(new Button(new Vector2(215, 700), SceneManager.Scenes.SONG3, "Track 3", false));
            _buttons.Add(new Button(new Vector2(315, 700), SceneManager.Scenes.SONG4, "Track 4", false));
            _buttons.Add(new Button(new Vector2(415, 700), SceneManager.Scenes.SONG5, "Track 5", false));
            _buttons.Add(new Button(new Vector2(50,50), SceneManager.Scenes.MUSIC, "Music", false));


            _highScores = "HIGHSCORES:--- \n ";
            for (int i = 0; i < _dao._highscores.Count; i++)
            {
                _highScores += i + 1 + ": " + _dao._highscores[i]._highscore + "\n";
            }
            if (Menu._playingMusic == true)
            {
                _preloader.PlayMusic("song1");
            }
        }

        public override void Update()
        {
           
            foreach (Block item in _fallers)
            {
                item.Update();
            }
            if (System.Environment.TickCount % 50 == 0)
            {
                _fallers.Add(new Block(new Vector2(BlockSpawner.random1.Next(0,840),-10),Color.White));
            }
            CollisionDetection();
            if (_titlePos.Y < 200)
            {
                _titlePos.Y -= (_titlePos.Y - 200) / 50; 
            }

            foreach (Button item in _buttons)
            {
                item.Update();
            }

        }
        public void CollisionDetection()
        {
            for (int i = 0; i < _fallers.Count; i++)
            {
                if (((Block)_fallers[i])._pos.Y > 800)
                {
                    _fallers.RemoveAt(i);
                }
            }
        }

        public void DisplayMusicRequest(bool _ingame)
        {
            Guide.BeginShowMessageBox("SOUND","Would you like to play with sound?", new List<string> { "Yes!!", "NO!!" }, 0, MessageBoxIcon.None,
            asyncResult =>
            {
                int? returned = Guide.EndShowMessageBox(asyncResult);
                if (returned == 0)
                {
                    _playingMusic = true;
                    _preloader.PlayMusic(_song);
                }
                else
                {
                    if (_ingame)
                    {
                        _preloader.StopMusic();
                    }
                    _playingMusic = false;
                }
            }, null);
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            foreach (Block item in _fallers)
            {
                item.Draw(_spriteBatch) ;
            }
            //_spriteBatch.Draw(_cursor, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            _spriteBatch.Draw(_scenery,  new Vector2(-10,0), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            _spriteBatch.Draw(_title,_titlePos, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
           // _spriteBatch.DrawString(_preloader._spriteFont, _highScores, new Vector2(0, 300), Color.Black);
            _spriteBatch.DrawString(_preloader._spriteFont, "Current Music : " + _song, new Vector2(20, 640), Color.Black);
            _spriteBatch.DrawString(_preloader._spriteFont, "Music by Isak Martinsson", new Vector2(20, 720), Color.Black);
          
            foreach (Button item in _buttons)
            {
                item.Draw(_spriteBatch);
            }
        }
    }
}
