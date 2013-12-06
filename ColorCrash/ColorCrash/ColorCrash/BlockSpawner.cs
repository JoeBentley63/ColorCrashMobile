using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace GameForTablet
{
    class BlockSpawner
    {
        SpriteLoader _preloader;
        public static Color _currentColour = Color.White;
        public static Random random1 = new Random();
        List<isBlock> _blocksRow1;
        List<isBlock> _blocksRow2;
        List<isBlock> _blocksRow3;
        List<isBlock> _blocksRow4;
        List<isBlock> _blocksRow5;
        List<isBlock> _blocksAll;
        List<isBlock> _fallingBlocks;
        isBlock _lastAdded = null;
        int i = 0;
        Point _mousePos = new Point(0, 0);
        bool _allowedToSelected = true;
        List<isBlock> _selectedBlocks = new List<isBlock>();
        Texture2D blank;
        SoundEffect _selectedSound;
        public static float _posController = 0;
      
        public BlockSpawner(GraphicsDevice _graphics)
        {
            _blocksRow1 = new List<isBlock>();
            _blocksRow2 = new List<isBlock>();
            _blocksRow3 = new List<isBlock>();
            _blocksRow4 = new List<isBlock>();
            _blocksRow5 = new List<isBlock>();
            _blocksAll = new List<isBlock>();
            _fallingBlocks = new List<isBlock>();
            blank = new Texture2D(_graphics, 1, 1, false, SurfaceFormat.Color);
            blank.SetData(new[] { Color.White });
            _preloader = SpriteLoader.GetInstance();

            _selectedSound = _preloader.LoadEffect("selected");
           
        }

        public bool checkSelected(Color _colour,Vector2 _pos)
        {
            
            if (_selectedBlocks.Count == 0)
            {
                return true;
            }
            if (_lastAdded == null)
            {
                return true;
            }
            if (Vector2.Distance(_pos, _lastAdded._pos) > 85)
            {
                return false;
            }
            bool _allSame = false;

            if (_colour == Color.White || _currentColour == Color.White)
            {
                return true;
            }
            if (_currentColour == _colour)
            {
                _allSame = true;
            }

            return _allSame;
        }

        public void Update()
        {
            HUD._combo = _selectedBlocks.Count;
            _mousePos.X = Mouse.GetState().X;
            _mousePos.Y = Mouse.GetState().Y;
            for(int j= 0; j < _fallingBlocks.Count; j ++)
            {
                ((isBlock)_fallingBlocks[j]).Update();
                if (((isBlock)_fallingBlocks[j])._shouldBeKilled == true)
                {
                    _fallingBlocks.Remove((isBlock)_fallingBlocks[j]);
                }
            }
            foreach (isBlock item in _blocksAll)
            {
                item.Update();
                if (_allowedToSelected)
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        if (item._boundingBox.Contains(_mousePos) && _selectedBlocks.Contains(item) == false)
                        {
                            if (checkSelected(item._colour,item._pos) && item is StoneBlock == false)
                            {
                                _selectedBlocks.Add(item);
                               
                                _currentColour = item._colour;
                                if (Menu._playingMusic == true)
                                {
                                    _selectedSound.Play();
                                }
                                _lastAdded = item;
                                item._selected = true;
                            }
                            else
                            {
                               // removeAll(false);
                               // _allowedToSelected = false;
                            }

                        }
                    }
                }
            }
            i++;

            CheckSpawns();
            CollisionDetection(_blocksRow1);
            CollisionDetection(_blocksRow2);
            CollisionDetection(_blocksRow3);
            CollisionDetection(_blocksRow4);
            CollisionDetection(_blocksRow5);

            if (Mouse.GetState().LeftButton == ButtonState.Released)
            {
                _allowedToSelected = true;
                if (_selectedBlocks.Count > 1)
                {
                    Console.Write("");
                }
                if (_selectedBlocks.Count >= 2)
                {
                    removeAll(true);

                }
                else
                {
                    removeAll(false);
                }
            }
        }

        public void CheckSpawns()
        {
            if (checkShouldSpawn(1))
            {
                float _controller = random1.Next(0, 100);
                if (_controller < 90)
                {
                    SpawnBlock(Color.Black, 1, 1);
                }
                if (_controller >= 90)
                {
                    //powerups
                    if (_controller > 90 && _controller < 93f)
                    {
                        SpawnBlock(Color.White, 1, 3);
                    }
                    if (_controller >= 93f && _controller < 96f)
                    {
                        SpawnBlock(Color.White, 1, 2);
                    }
                    if (_controller >= 96f && _controller <= 100f)
                    {
                        SpawnBlock(Color.White, 1, 4);
                    }
                }
            }
            if (checkShouldSpawn(2))
            {
                float _controller = random1.Next(0, 100);
                if (_controller < 90)
                {
                    SpawnBlock(Color.Black, 2, 1);
                }
                if (_controller >= 90)
                {
                    //powerups
                    if (_controller > 90 && _controller < 93f)
                    {
                        SpawnBlock(Color.White, 2, 3);
                    }
                    if (_controller >= 93f && _controller < 96f)
                    {
                        SpawnBlock(Color.White, 2, 2);
                    }
                    if (_controller >= 96f && _controller <= 100f)
                    {
                        SpawnBlock(Color.White, 2, 4);
                    }
                }
            }
            if (checkShouldSpawn(3))
            {
                float _controller = random1.Next(0, 100);
                if (_controller < 90)
                {
                    SpawnBlock(Color.Black, 3, 1);
                }
                if (_controller >= 90)
                {
                    //powerups
                    if (_controller > 90 && _controller < 93f)
                    {
                        SpawnBlock(Color.White, 3, 3);
                    }
                    if (_controller >= 93f && _controller < 96f)
                    {
                        SpawnBlock(Color.White, 3, 2);
                    }
                    if (_controller >= 96f && _controller <= 100f)
                    {
                        SpawnBlock(Color.White, 3, 4);
                    }
                }
            }
            if (checkShouldSpawn(4))
            {
                float _controller = random1.Next(0, 100);
                if (_controller < 90)
                {
                    SpawnBlock(Color.Black, 4, 1);
                }
                if (_controller >= 90)
                {
                    //powerups
                    if (_controller > 90 && _controller < 93f)
                    {
                        SpawnBlock(Color.White, 4, 3);
                    }
                    if (_controller >= 93f && _controller < 96f)
                    {
                        SpawnBlock(Color.White, 4, 2);
                    }
                    if (_controller >= 96f && _controller <= 100f)
                    {
                        SpawnBlock(Color.White, 4, 4);
                    }
                }
            }
            if (checkShouldSpawn(5))
            {
                float _controller = random1.Next(0, 100);
                if (_controller < 90)
                {
                    SpawnBlock(Color.Black, 5, 1);
                }
                if (_controller >= 90)
                {
                    //powerups
                    if (_controller > 90 && _controller < 93f)
                    {
                        SpawnBlock(Color.White, 5, 3);
                    }
                    if (_controller >= 93f && _controller < 96f)
                    {
                        SpawnBlock(Color.White, 5, 2);
                    }
                    if (_controller >= 96f && _controller <= 100f)
                    {
                        SpawnBlock(Color.White, 5, 4);
                    }
                }
            }
           
        }

        public bool checkShouldSpawn(int rowNumber)
        {
            switch (rowNumber)
            {
                case 1 :
                    if (_blocksRow1.Count < 8)
                    {
                        return true;
                    }
                    break;
                case 2:
                    if (_blocksRow2.Count < 8)
                    {
                        return true;
                    }
                    break;
                case 3:
                    if (_blocksRow3.Count < 8)
                    {
                        return true;
                    }
                    break;
                case 4:
                    if (_blocksRow4.Count < 8)
                    {
                        return true;
                    }
                    break;
                case 5:
                    if (_blocksRow5.Count < 8)
                    {
                        return true;
                    }
                    break;
                default :
                    
                    return false;
                    
                    
            }
            return false;
            
        }
        public void removeAll(bool _win)
        {
            if (_win)
            {
               SoundEffect _effect = _preloader.LoadEffect("clear");
               if (Menu._playingMusic == true)
               {
                   _effect.Play();
               }
            }
            foreach (isBlock item in _selectedBlocks)
            {
                item._selected = false;
            }
            int multi = 0;
            if(_selectedBlocks.Count >= 2)
            {
                for (int j = 0; j < _selectedBlocks.Count; j ++ )
                {
                    ((isBlock)_selectedBlocks[j])._selected = false;
                    if (_win)
                    {
                        ((isBlock)_selectedBlocks[j])._shouldFall = true;
                        if (((isBlock)_selectedBlocks[j]) is ExplodeBlock)
                        {
                            for (int i = 0; i < _blocksAll.Count; i++)
                            {
                                if (Vector2.Distance(((isBlock)_selectedBlocks[j])._pos, ((isBlock)_blocksAll[i])._pos) < 120 && _selectedBlocks.Contains(_blocksAll[i]) == false)
                                {
                                    _selectedBlocks.Add(_blocksAll[i]);
                                }
                            }
                        }
                        if (((isBlock)_selectedBlocks[j]) is ColorBurster)
                        {
                            List<Color> _colours = new List<Color>();
                            foreach (isBlock item in _selectedBlocks)
                            {
                                if (_colours.Contains(item._colour) == false && item._colour!=Color.White)
                                {
                                    _colours.Add(item._colour);
                                }
                            }
                            for (int i = 0; i < _blocksAll.Count; i++)
                            {
                                if(_colours.Contains(((isBlock)_blocksAll[i])._colour) && _selectedBlocks.Contains(_blocksAll[i]) == false)
                                {
                                    _selectedBlocks.Add(_blocksAll[i]);
                                }
                            }
                        }
                    }
                }
                for (int i = 0; i < _selectedBlocks.Count; i ++ )
                {
                    if (((isBlock)_selectedBlocks[i])._shouldFall == true)
                    {


                        int temp = (int)(((isBlock)_selectedBlocks[i])._pos.X +16) / 82;
                        switch (temp)
                        {
                            case 1:
                                _blocksRow1.Remove((_selectedBlocks[i]));
                                break;
                            case 2:
                                _blocksRow2.Remove((_selectedBlocks[i]));
                                break;
                            case 3:
                                _blocksRow3.Remove((_selectedBlocks[i]));
                                break;
                            case 4:
                                _blocksRow4.Remove((_selectedBlocks[i]));
                                break;
                            case 5:
                                _blocksRow5.Remove((_selectedBlocks[i]));
                                break;
                        }
                        _fallingBlocks.Add(_selectedBlocks[i]);
                        _blocksAll.Remove(((isBlock)_selectedBlocks[i]));
                        
                        multi++;
                    }
                }
            }
            HUD._score += (multi * 100);
            HUD._barAmount += multi;
            multi = 0;
            _selectedBlocks = new List<isBlock>();
            _currentColour = Color.White;
        }

        public void SpawnBlock(Color _colour, int _row,int _type)
        {
            isBlock _temp = null;
            switch (_type)
            {
                case 1 :
                    _temp = new Block(new Vector2(-16+ _row * 82, 0), _colour);
                    break;
                case 2 :
                    _temp = new ExplodeBlock(new Vector2(-16 + _row * 82, 0), _colour);
                   
                    break;
                case 3:
                    _temp = new ColorBurster(new Vector2(-16 + _row * 82, 0), _colour);

                    break;
                case 4 :
                    _temp = new StoneBlock(new Vector2(-16 + _row * 82, 0), _colour);

                    break;
                default :
                    _temp = new Block(new Vector2(-16 + _row * 82, 0), _colour);
                   
                    break;
            }
          
            switch (_row)
            {
                case 1: 
                    _blocksRow1.Add(_temp);
                    break;
                case 2:
                   _blocksRow2.Add(_temp);
                    break;
                case 3:
                    _blocksRow3.Add(_temp);
                    break;
                case 4:
                    _blocksRow4.Add(_temp);
                    break;
                case 5:
                    _blocksRow5.Add(_temp);
                    break;
                default:
                    _blocksRow1.Add(_temp);
                    break;
            }
            _blocksAll.Add(_temp);
        }
        public void CollisionDetection(List<isBlock> _blocks)
        {
            foreach (isBlock item in _blocks)
            {
                foreach (isBlock item2 in _blocks)
                {
                    if (item._boundingBox.Intersects(item2._boundingBox))
                    {
                        if (item._pos.Y < item2._pos.Y)
                        {
                            item._pos.Y = item2._pos.Y - 80;
                        }
                    }
                    if (item._pos.Y > (640 - 32))
                    {
                        item._pos.Y = (640 - 32);
                    }
                }
            }
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            foreach (isBlock item in _fallingBlocks)
            {
                item.Draw(_spriteBatch);
            }
            foreach (isBlock item in _blocksAll)
            {
                item.Draw(_spriteBatch);
            }
            for (int i = 1; i < _selectedBlocks.Count; i++)
            {
                DrawLine(_spriteBatch, 5, ((isBlock)_selectedBlocks[i])._pos, ((isBlock)_selectedBlocks[i - 1])._pos, 1);
               
            }

        }
        void DrawLine(SpriteBatch batch, float width, Vector2 point1, Vector2 point2,float _opacity)
        {
            float angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
            float length = Vector2.Distance(point1, point2);

            batch.Draw(blank, point1, null, Color.White * _opacity,
                       angle, Vector2.Zero, new Vector2(length, width),
                       SpriteEffects.None, 0);
        }
    }
}
