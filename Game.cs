using System.Collections.Generic;

namespace S2
{
    public class Game
    {
        public int etat;
    }
    public class Teams
    {
        public List<Pièces> Pieces;
        public string Name;
        public int id;

        public Teams(int id,string name)
        {
            this.id = id;
            Name = name;
        }
        
    }
}