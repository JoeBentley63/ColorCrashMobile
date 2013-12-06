using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameForTablet
{
    class ExplodeBlock : isBlock
    {

        public ExplodeBlock(Vector2 _pos, Color _colour)
        {
            this._pos = _pos;
            this._colour = _colour;
            _preloader = SpriteLoader.GetInstance();
            _texture = _preloader.Load("bomb");
            _eyeTexture = _preloader.Load("eye");
            _mouthTexture = _preloader.Load("smile");
        }

        public override void Update()
        {


            if (_shouldFall)
            {
                this._pos.Y += 2;
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
               // _angle = (float)Math.Atan2(_mousePos.Y - _pos.Y + 16, _mousePos.X - _pos.X + 16);
                if (_selected)
                {
                    _eyeTexture = _preloader.Load("selectedeye");
                    _mouthTexture = _preloader.Load("selectedmouth");
                }
                else
                {
                    _eyeTexture = _preloader.Load("eye");

                   // if (Vector2.Distance(_mousePos, _pos + new Vector2(16, 16)) < 100)
                   // {
                        _mouthTexture = _preloader.Load("smile");
                   // }
                   // else
                   // {
                   //     _mouthTexture = _preloader.Load("normalmouth");
                   // }
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
                    _spriteBatch.Draw(_eyeTexture, _pos + new Vector2(-10, BlockSpawner._posController - 5), null, Color.White, _angle + _fallAngle, new Vector2(12.5f, 12.5f), _fallScale + 0.2f, SpriteEffects.None, .6f);
                    _spriteBatch.Draw(_eyeTexture, _pos + new Vector2(25, BlockSpawner._posController - 5), null, Color.White, _angle + _fallAngle, new Vector2(12.5f, 12.5f), _fallScale + 0.2f, SpriteEffects.None, .6f);
                    //  _spriteBatch.Draw(_mouthTexture, _pos + new Vector2(-30, BlockSpawner._posController + 5), null, Color.White, _fallAngle, new Vector2(0, 0), _fallScale, SpriteEffects.None, .6f);
                }
            }
            else
            {
                _spriteBatch.Draw(_texture, _pos, null, _colour * _fallScale, _fallAngle, new Vector2(32, 32), _fallScale, SpriteEffects.None, .7f);

                if (!_shouldFall)
                {
                    _spriteBatch.Draw(_eyeTexture, _pos + new Vector2(-10, BlockSpawner._posController - 5), null, Color.White, _angle + _fallAngle, new Vector2(12.5f, 12.5f), _fallScale + 0.2f, SpriteEffects.None, .6f);
                    _spriteBatch.Draw(_eyeTexture, _pos + new Vector2(25, BlockSpawner._posController - 5), null, Color.White, _angle + _fallAngle, new Vector2(12.5f, 12.5f), _fallScale + 0.2f, SpriteEffects.None, .6f);
                    // _spriteBatch.Draw(_mouthTexture, _pos + new Vector2(0, BlockSpawner._posController + 5), null, Color.White, _fallAngle, new Vector2(19.5f, 12), _fallScale / 2, SpriteEffects.None, .6f);
                }
            }

        }
    }
}
