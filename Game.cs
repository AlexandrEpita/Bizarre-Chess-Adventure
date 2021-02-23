using System.Collections.Generic;
using System.Security.Principal;
using System.Threading;

namespace S2
{
    public class Game
    {
        public Echiquier echiquier;
        public List<Teams> equipe;
        public int fini()
        {
            int id=0;
            foreach (Teams x in equipe)
            {
                if (x.echecetmat)
                {
                    id = x.id;
                }
            }
            return id; //sera de 1 pour une equipe et -1 pour celle d'en face
        }
    }
    public class Teams
    {
        public List<Pièces> Pieces;
        public string Name;
        public int id;
        public bool echecetmat;
        public bool echec;
        public Teams(int id,string name)
        {
            this.id = id;
            Name = name;
        }
        
    }
}