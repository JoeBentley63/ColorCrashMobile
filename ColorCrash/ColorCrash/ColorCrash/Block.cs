using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameForTablet
{
    class Block : isBlock
    {
       
        public Block(Vector2 _pos,Color _colour)
        {
            this._pos = _pos;
           // System.Threading.Thread.Sleep(1);
            Random r1 = BlockSpawner.random1;
            float _temp = r1.Next(0, 10);
            this._colour = Color.Red;
            if (_temp < 2.5f)
            {
                this._colour = Color.Red;
            }
            else if (_temp >= 2.5f && _temp < 5.0f)
            {
                this._colour = Color.Blue;
            }
            else if (_temp >= 5.0f && _temp < 7.5f)
            {
                this._colour = Color.Green;
            }
            else if (_temp >= 7.5f && _temp < 10f)
            {
                this._colour = Color.Yellow;
            }
            _preloader = SpriteLoader.GetInstance();
            _texture = _preloader.Load("block");
            _eyeTexture = _preloader.Load("eye");
            _mouthTexture = _preloader.Load("smile");
        }

        public override void Update()
        {
           
            
            if (_shouldFall)
            {
                this._pos.Y+=2;
                this._fallAngle += .1f;
                this._fallScale -= 0.01f;
                if (this._fallScale < 0)
                {
                     _shouldBeKilled = true;
                }
            }
            else
            {
                _mousePos.X = Mouse.GetState().X;
                _mousePos.Y = Mouse.GetState().Y;

                this._pos.Y += _fallSpeed;
            //    _angle = (float)Math.Atan2(_mousePos.Y - _pos.Y + 16, _mousePos.X - _pos.X + 16);
                if (_selected)
                {
                    _eyeTexture = _preloader.Load("selectedeye");
                    _mouthTexture = _preloader.Load("selectedmouth");
                }
                else
                {
                    _eyeTexture = _preloader.Load("eye");

                  //  if (Vector2.Distance(_mousePos, _pos + new Vector2(16, 16)) < 100)
                   // {
                        _mouthTexture = _preloader.Load("smile");
                   // }
                   // else
                   // {
                     
                  //  }
                }
            }
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            
           if (_selected == false)
            {
                _spriteBatch.Draw(_texture, _pos, null, _colour * _fallScale, _fallAngle, new Vector2(32, 32), _fallScale, SpriteEffects.None, .7f);
            
                if (!_shouldFall)
                {
                    _spriteBatch.Draw(_eyeTexture, _pos + new Vector2(-10, BlockSpawner._posController - 5), null, Color.White, _angle + _fallAngle, new Vector2(12.5f, 12.5f), _fallScale+ 0.2f, SpriteEffects.None, .6f);
                    _spriteBatch.Draw(_eyeTexture, _pos + new Vector2(25, BlockSpawner._posController - 5), null, Color.White, _angle + _fallAngle, new Vector2(12.5f, 12.5f), _fallScale + 0.2f, SpriteEffects.None, .6f);
                    _spriteBatch.Draw(_mouthTexture, _pos + new Vector2(-28, BlockSpawner._posController + 12), null, Color.White, _fallAngle, new Vector2(0, 0), _fallScale + 0.2f, SpriteEffects.None, .6f);
                }
            }
            else
            {
                _spriteBatch.Draw(_texture, _pos, null, _colour * _fallScale, _fallAngle, new Vector2(32, 32), _fallScale, SpriteEffects.None, .7f);
            
                if (!_shouldFall)
                {
                    _spriteBatch.Draw(_eyeTexture, _pos + new Vector2(-10, BlockSpawner._posController - 5), null, Color.White, _fallAngle, new Vector2(12.5f, 6.5f), _fallScale, SpriteEffects.None, .6f);
                    _spriteBatch.Draw(_eyeTexture, _pos + new Vector2(20, BlockSpawner._posController - 5), null, Color.White, _fallAngle, new Vector2(12.5f, 6.5f), _fallScale, SpriteEffects.None, .6f);
                    _spriteBatch.Draw(_mouthTexture, _pos + new Vector2(5, BlockSpawner._posController + 10), null, Color.White, _fallAngle, new Vector2(19.5f, 12), _fallScale / 2, SpriteEffects.None, .6f);
                }
            }
            
        }
    }
}
