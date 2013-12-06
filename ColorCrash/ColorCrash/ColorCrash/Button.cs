using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace GameForTablet
{
    class Button
    {
        Texture2D _texture;
        Vector2 _pos;
        public SceneManager.Scenes _onClick;
        SceneManager _sceneManager;
        SpriteLoader _preloader;
        String _text;
        bool _big = false;
        bool _pressed = true;
        bool _mousedOver = false;
        public Rectangle _boundingBox
        {
            get
            {
                return new Rectangle((int)_pos.X - 32, (int)_pos.Y - 32, (int)_texture.Width, (int)_texture.Height);
            }
        }
        public Button(Vector2 _pos,SceneManager.Scenes _OnClick,String _text,bool _big)
        {
            this._big = _big;
            this._pos = _pos;
            this._text = _text;
            this._onClick = _OnClick;
            _sceneManager = SceneManager.GetInstance();
            _preloader = SpriteLoader.GetInstance();
            if (_big)
            {
                _texture = _preloader.Load("button");
            }
            else
            {
                _texture = _preloader.Load("smallbutton");
            }
        }
        public void Update()
        {
            if (_boundingBox.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)) && _mousedOver == false)
            {
                _mousedOver = true;
                if (Menu._playingMusic == true)
                {
                    SoundEffect _effect = _preloader.LoadEffect("mouseover");
                    _effect.Play();
                }
            }
            else if (!_boundingBox.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)) && _mousedOver == true)
            {
                _mousedOver = false;
            }
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && _pressed == false)
            {
                
                _pressed = true;
                if(_boundingBox.Contains(new Point(Mouse.GetState().X,Mouse.GetState().Y)))
                {
                    _sceneManager.ChangeScene(_onClick);
                }
            }
            else if (Mouse.GetState().LeftButton == ButtonState.Released && _pressed == true)
            {
                _pressed = false;
            }

        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(_texture, _pos, null, Color.White, 0f, new Vector2(32, 32), 1f, SpriteEffects.None, 0.2f);
            if (_big)
            {
                _spriteBatch.DrawString(_preloader._spriteFont, _text, _pos, Color.White);
            }
            else
            {
                _spriteBatch.DrawString(_preloader._spriteFont, _text, _pos - new Vector2(35,35), Color.White);
            }
        }
            
    }
}
