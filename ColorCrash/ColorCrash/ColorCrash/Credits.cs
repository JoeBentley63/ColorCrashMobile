using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using Microsoft.Xna.Framework;

namespace GameForTablet
{
    class Credits : Scene
    {
        SceneManager _sceneManager;
        List<isBlock> _fallers = new List<isBlock>();
        private Texture2D _scenery;
        SpriteLoader _preloader;
        List<Button> _buttons = new List<Button>();
        public Credits()
        {
            _preloader = SpriteLoader.GetInstance();
            _sceneManager = SceneManager.GetInstance();
             _scenery = _preloader.Load("scene");


            _buttons.Add(new Button(new Vector2(150, 500), SceneManager.Scenes.MENU, "Back", true));
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
            _spriteBatch.Draw(_scenery,new Vector2(-10,0), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            _spriteBatch.DrawString(_preloader._spriteFont, " Art and Code by Joseph Bentley\n(SeppyB63) \n Follow me on Twitter @seppyb \n or find me on Newgrounds,\n Username : SeppyB63 \n\n Don't be shy, say hey!!", new Vector2(50, 100), Color.Black);
            foreach (Button item in _buttons)
            {
                item.Draw(_spriteBatch);
            }
        }
    }
}
