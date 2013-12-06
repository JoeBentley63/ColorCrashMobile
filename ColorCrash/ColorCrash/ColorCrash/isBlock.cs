using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameForTablet
{
    public class isBlock
    {
        protected Texture2D _texture;
        protected Texture2D _eyeTexture;
        protected Texture2D _mouthTexture;
        protected float _angle = 0;
        public Vector2 _pos;
        public Color _colour;
        protected SpriteLoader _preloader;
        protected Vector2 _mousePos = new Vector2(0, 0);
        protected float _fallSpeed = 3f;
        public bool _selected = false;
        public bool _shouldBeKilled = false;
        public bool _shouldFall = false;
        public float _fallAngle = 0;
        public float _fallScale = 1;
        public Rectangle _boundingBox
        {
            get
            {
                return new Rectangle((int)_pos.X - 32, (int)_pos.Y - 32, (int)_texture.Width, (int)_texture.Height);
            }
        }
        public virtual void Update()
        {


         
        }

        public virtual void Draw(SpriteBatch _spriteBatch)
        {

          

        }
    }
}
