using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameForTablet
{
    class HUD
    {
        private Texture2D _hudTexture;
        private Texture2D _scoreTexture;
        private Texture2D _barBackgroundTexture;
        private Texture2D _barTexture;
        private Texture2D _capsuleTexture;
        public static float _barAmount = 100;
        public static int _combo = 1;
        private Texture2D _background;
        private Texture2D _square;
        public static Color _colour = Color.White;
        SpriteLoader _preloader = SpriteLoader.GetInstance();
        public static int _score;
        private Vector2 _pos;
        private Vector2 _scorePos;
        public HUD()
        {
            _hudTexture = _preloader.Load("hudframe");
            _background = _preloader.Load("background");
            _scoreTexture = _preloader.Load("scorepanel");
            _square = _preloader.Load("block");
            _barBackgroundTexture = _preloader.Load("barpanel");
            _barTexture = _preloader.Load("bar");
            _capsuleTexture = _preloader.Load("capsule");
            _pos = new Vector2(5,0);
            _scorePos = new Vector2(180, 565);
            _score = 0;
            _barAmount = 100;
        }

        public void Update()
        {
            _barAmount -= 0.05f;
            if (_barAmount > 100)
            {
                _barAmount = 100;
            }
            if (_barAmount < 0)
            {
                _barAmount = 0;
            }

        }
        public void Draw(SpriteBatch _spriteBatch)
        {
           
            ///_spriteBatch.Draw(_barBackgroundTexture, new Vector2(0,0), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, .5f);
            _spriteBatch.Draw(_barTexture, new Rectangle(50, 635, _barTexture.Width / 2, (int)((_barTexture.Height * (_barAmount / 100)) * .66f)), null, Color.White, (3.1415f / 2), new Vector2(0, _barTexture.Height), SpriteEffects.None, 0.4f);
            _spriteBatch.Draw(_capsuleTexture, new Rectangle(40, 635, _capsuleTexture.Width / 2, (int)(_capsuleTexture.Height * .66)), null, Color.White, (3.1415f/2), new Vector2(0, _capsuleTexture.Height), SpriteEffects.None, 0.3f);
            
            //15, 50
            _spriteBatch.Draw(_hudTexture, _pos, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None,.5f);
            //_spriteBatch.Draw(_scoreTexture, _pos + new Vector2(500,0), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, .5f);
           // _spriteBatch.Draw(_square, _pos + new Vector2(585, 290), null, BlockSpawner._currentColour, 0f, Vector2.Zero, 1.25f, SpriteEffects.None, .4f);
           // _spriteBatch.DrawString(_preloader._spriteFont, "Current Colour : ", _pos + new Vector2(535, 240), Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);
           // _spriteBatch.DrawString(_preloader._spriteFont, "" + _colourName, _pos + new Vector2(585, 270), Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);
           
           // _spriteBatch.Draw(_cursor, new Vector2(Mouse.GetState().X,Mouse.GetState().Y), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            
            //_spriteBatch.Draw(_background, _pos, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, .9f);
            _spriteBatch.DrawString(_preloader._spriteFont, "Score : " + _score, _pos + new Vector2(55, 660), Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);

           // _spriteBatch.DrawString(_preloader._spriteFont, "Combo : X" + _combo , _pos + new Vector2(535, 500), Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);
           
        
        }
    }
}
