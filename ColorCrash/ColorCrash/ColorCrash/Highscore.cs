using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameForTablet
{
    public class Highscore : IComparable
    {
        public int _highscore;
        public Highscore()
        {
       
        }
        public Highscore(int _highscore)
        {
            this._highscore = _highscore;
        }

        public int CompareTo(object obj)
        {

            Highscore _highscore = obj as Highscore;

            return _highscore._highscore - this._highscore;
        }
    }
}
