using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace GameForTablet
{
    class Splash : Scene
    {
        SceneManager _sceneManager;
        SpriteLoader _preloader;
        Texture2D _texture;
        float _opacity = 0;
        bool _reverse = false;
        public Splash()
        {
           
            _preloader = SpriteLoader.GetInstance();
            _sceneManager = SceneManager.GetInstance();
            _texture = _preloader.Load("splash");
            
        }

        public override void Update()
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                _sceneManager.ChangeScene(SceneManager.Scenes.MENU);
            }
            if (!_reverse)
            {
                if (_opacity > 1)
                {
                    _reverse = true;
                }
                _opacity += 0.01f;
            }
            else
            {
                _opacity -= 0.01f;

                if (_opacity < 0)
                {
                    _sceneManager.ChangeScene(SceneManager.Scenes.MENU);
                }
            }

        }
      
        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(_texture, Vector2.Zero, null, Color.White * _opacity, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
           
        }
    }
}
