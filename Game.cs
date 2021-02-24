using System.Collections.Generic;
using System.Security.Principal;
using System.Threading;

namespace S2
{
    public class Game
    {
        public Echiquier echiquier;
        public List<Teams> equipe;
        public List<Pieces> compo;
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
        public List<Pieces> Piecesliste;
        public string Name;
        public int id;
        public bool echecetmat;
        public bool echec;
        public Teams(int id,string name)
        {
            this.id = id;
            Name = name;
        }

        public bool est_echec(Teams ennemies)
        {
            Pieces p = Piecesliste[0];//c le roi
            foreach (Pieces ennemi in ennemies.Piecesliste)
            {
                foreach (var pos in ennemi.deplacement)
                {
                    if (pos == p.Position)
                        return true;
                }
            }
            return false;
        }

        public bool et_mat()
        {
            if (echec)
            {
                return Piecesliste[0].deplacement.Count == 0;
            }
            return false;
        }
    }
}