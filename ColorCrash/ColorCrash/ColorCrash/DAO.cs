using System;
using System.Collections.Generic;


namespace GameForTablet
{
    class DAO
    {
        public List<Highscore> _highscores = new List<Highscore>();
        public enum platform
        {
            WIN7,
            WIN8,
            WINPHONE8
        }
        public platform _currentPlatform = platform.WIN7;
       
        private static DAO _me;

        public static DAO GetInstance()
        {
            if (_me == null)
            {
                _me = new DAO();
            }
            return _me;

        }

        private DAO()
        {

                    

        }
        public void AddHighscore(int _value)
        {
            _highscores.Add(new Highscore(_value));
            _highscores.Sort();
            if (_highscores.Count > 6)
            {
                _highscores.RemoveAt(_highscores.Count - 1);
            }
            Save();
        }
        public void Save()
        {
            switch (_currentPlatform)
            {
                case platform.WIN7:

                     //FileStream stream = File.Open(_path, FileMode.OpenOrCreate, FileAccess.Write);
                     //var serializer = new XmlSerializer(typeof(List<Highscore>));
                     //serializer.Serialize(stream, _highscores);
                     //stream.Close();
                    break;
            }
        }
        public void Load()
        {
            switch (_currentPlatform)
            {
                case platform.WIN7:

                    //FileStream stream = File.Open(_path, FileMode.Open, FileAccess.Read);
                    //var serializer = new XmlSerializer(typeof(List<Highscore>));
                    //_highscores = (List<Highscore>)serializer.Deserialize(stream);
                    //stream.Close();
                    break;
            }
        }
    }
}
