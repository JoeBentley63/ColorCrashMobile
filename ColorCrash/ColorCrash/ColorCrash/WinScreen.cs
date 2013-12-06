using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace GameForTablet
{
    class WinScreen : Scene
    {
        SceneManager _sceneManager;
        List<isBlock> _fallers = new List<isBlock>();
      //  private Texture2D _cursor;
        private Texture2D _scenery;
        SpriteLoader _preloader;
        List<Button> _buttons = new List<Button>();
        DAO _dao;
       // HighScoreList _highScoreList = new HighScoreList("MyScores"); 
        public WinScreen()
        {
            _preloader = SpriteLoader.GetInstance();
            _sceneManager = SceneManager.GetInstance();
          //  _cursor = _preloader.Load("cursor");
            _scenery = _preloader.Load("scene");
            _buttons.Add(new Button(new Vector2(150, 500), SceneManager.Scenes.MENU, "Back",true));
            _dao = DAO.GetInstance();
            _dao.AddHighscore(HUD._score);
            SoundEffect _effect =  _preloader.LoadEffect("win");
            if (Menu._playingMusic == true)
            {
                _effect.Play();
                _preloader.StopMusic();
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
                _fallers.Add(new Block(new Vector2(BlockSpawner.random1.Next(0, 840), -10), Color.White));
            }
            CollisionDetection();

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
        public override void Draw(SpriteBatch _spriteBatch)
        {
            foreach (Block item in _fallers)
            {
                item.Draw(_spriteBatch);
            }
         //   _spriteBatch.Draw(_cursor, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            _spriteBatch.Draw(_scenery, new Vector2(-10,0), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            _spriteBatch.DrawString(_preloader._spriteFont, "YAY!!! , you got a score of :  " + HUD._score, new Vector2(0, 100), Color.Black);
            foreach (Button item in _buttons)
            {
                item.Draw(_spriteBatch);
            }
        }
    }
}
