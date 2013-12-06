using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameForTablet
{
    class TutorialScreen : Scene
    {
        Texture2D _page1;
        Texture2D _page2;
        SpriteLoader _preloader;
        Button _backButton = new Button(new Vector2(150, 600), SceneManager.Scenes.MENU, "Back To Menu", true);
        SceneManager _sceneManager;
        //private Texture2D _cursor;
       
        public TutorialScreen()
        {
            _preloader = SpriteLoader.GetInstance();
            _page1 = _preloader.Load("page1");
            _page2 = _preloader.Load("page2");
            _sceneManager = SceneManager.GetInstance();
          //  _cursor = _preloader.Load("cursor");
           
        }
        public override void Update()
        {
           
            _backButton.Update();
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
          
                _spriteBatch.Draw(_page1, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);

            
           // _spriteBatch.Draw(_cursor, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            
          //  _spriteBatch.DrawString(_preloader._spriteFont, "Tap Screen to change page", Vector2.Zero, Color.Black);
            _backButton.Draw(_spriteBatch);
        }
    }
}
