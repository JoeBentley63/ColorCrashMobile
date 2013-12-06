using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace GameForTablet //might want to change this, depending on your own projects namespace
{
    public class SpriteLoader
    {
        private static SpriteLoader _me; //make it a singleton so we only load our Texture2D's the once.
        public SpriteFont _spriteFont;
        Dictionary<String, Texture2D> _sprites = new Dictionary<String, Texture2D>(); //Dictionary to store our Texture2D's
        Dictionary<String, SoundEffect> _sounds = new Dictionary<String, SoundEffect>(); //Dictionary to store our Texture2D's
        Dictionary<String, Song> _songs = new Dictionary<String, Song>(); //Dictionary to store our Texture2D's
        SoundEffectInstance instance;
        SoundEffect bgEffect;
        private SpriteLoader()
        {
           
        }
        public void setContentManager(ContentManager _content)
        {
            LoadAll(_content);//on creation, load our assets
        }
        public static SpriteLoader GetInstance()// singleton
        {
            if (_me == null)
            {
                _me = new SpriteLoader();
            }
            return _me;
        }


        private void LoadAll(ContentManager _content)
        {
            _sprites.Add("splash", _content.Load<Texture2D>("Splash"));
            _sprites.Add("hudframe", _content.Load<Texture2D>("Frame"));
            _sprites.Add("background", _content.Load<Texture2D>("PuzzleBackground"));
            _sprites.Add("cursor", _content.Load<Texture2D>("cursor"));
            _sprites.Add("block", _content.Load<Texture2D>("Block"));
            _sprites.Add("eye", _content.Load<Texture2D>("Eye"));
            _sprites.Add("smile", _content.Load<Texture2D>("Smile"));
            _sprites.Add("normalmouth", _content.Load<Texture2D>("normalMouth"));
            _sprites.Add("selectedeye", _content.Load<Texture2D>("happyEye"));
            _sprites.Add("selectedmouth", _content.Load<Texture2D>("HappyMouth"));
            _sprites.Add("bomb", _content.Load<Texture2D>("Bomb"));
            _sprites.Add("clearall", _content.Load<Texture2D>("ClearAll"));
            _sprites.Add("bar",_content.Load<Texture2D>("Bar"));
            _sprites.Add("barpanel",_content.Load<Texture2D>("BarPanel"));
            _sprites.Add("capsule",_content.Load<Texture2D>("Capsule"));
            _sprites.Add("scorepanel", _content.Load<Texture2D>("ScorePanel"));
            _sprites.Add("stone", _content.Load<Texture2D>("HeavyBlock"));
            _sprites.Add("pausemenu", _content.Load<Texture2D>("pauseMenu"));
            _sprites.Add("scene", _content.Load<Texture2D>("Scenery"));
            _sprites.Add("title", _content.Load<Texture2D>("Title"));

            _sprites.Add("button", _content.Load<Texture2D>("Button"));
            _sprites.Add("smallbutton", _content.Load<Texture2D>("SmallButton"));
            _sprites.Add("page1", _content.Load<Texture2D>("TutorialPage1Colours"));
            _sprites.Add("page2", _content.Load<Texture2D>("TutorialPage2Colours"));
          
            
            _sounds.Add("selected",_content.Load<SoundEffect>("Sounds\\zap1"));
            _sounds.Add("win", _content.Load<SoundEffect>("Sounds\\Win"));
            _sounds.Add("clear", _content.Load<SoundEffect>("Sounds\\Clear"));
            _sounds.Add("mouseover", _content.Load<SoundEffect>("Sounds\\MouseOver"));
            _sounds.Add("song1", _content.Load<SoundEffect>("Sounds\\Loop1"));
            _sounds.Add("song2", _content.Load<SoundEffect>("Sounds\\Loop2"));
            _sounds.Add("song3", _content.Load<SoundEffect>("Sounds\\Loop3"));
            _sounds.Add("song4", _content.Load<SoundEffect>("Sounds\\Loop4"));
            _sounds.Add("song5", _content.Load<SoundEffect>("Sounds\\MenuMusic"));
            _spriteFont = _content.Load<SpriteFont>("Font");
        }
        public SoundEffect LoadEffect(String _string)
        {
            _string = _string.ToLower();
            SoundEffect _sound;
            _sounds.TryGetValue(_string, out _sound);//get the sprite from the dictionary and return it.
            return _sound;
        }
        public void StopMusic()
        {
            if (Menu._playingMusic == true)
            {
                if (instance != null)
                {
                    instance.Dispose();
                }
            }
        }
        public void PlayMusic(String _string)
        {
            if (Menu._playingMusic == true)
            {
                if (instance != null)
                {
                    instance.Dispose();
                }

                _sounds.TryGetValue(_string, out bgEffect);
                instance = bgEffect.CreateInstance();
                instance.IsLooped = true;
                instance.Volume = 0.5f;
                instance.Play();
            }
        }
        public Texture2D Load(String _string)//function that lets you refrence your sprites in a class after they have been loaded
        {
            _string = _string.ToLower();
            Texture2D _tex;
            _sprites.TryGetValue(_string, out _tex);//get the sprite from the dictionary and return it.
            return _tex;
        }
    }
}

