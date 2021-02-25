using System.Collections.Generic;
using System.Security.Principal;
using System.Threading;
using System.Collections;
namespace S2
{
    public class Game
    {
        public Echiquier echiquier;
        public List<Teams> equipes;
        internal List<Pieces> compo;
        public Game(List<Teams> equipe)
        {
            this.equipes = equipe;
        }
        public void Init_Partie(){}
        public void Partie_lance()
        {
            bool findugame = true;
            int fin;
            Init_Partie();
            Teams winner = null;
            int j = 0;
            while (findugame)
            {
                Orenoturn( equipes[j],  equipes[1 - j]);//faudra peut etre mettre en ref les arguments
                fin = fini();
                if (fin!=-1)
                {
                    findugame = false;
                    winner = equipes[fin];//retourne le gagnant
                }
                foreach (var team in equipes)
                {
                    team.Update(this);
                }
                j++;
                if (j > 1)
                    j = 0;
            }
            finish(winner);
        }
        public void Orenoturn( Teams allié, Teams ennnemi)//execute le tour de l'equipe allié
        {
            
        }
        public int fini()
        {
            int id=-1;
            foreach (Teams x in equipes)
            {
                if (x.echecetmat)
                {
                    id = x.id;
                }
            }
            return id; //sera de 1 pour une equipe et 0 pour celle d'en face
        }

        public void finish(Teams winners){}//animation de fin pas obligé de le faire pour la premiere
    }
    public class Teams
    {
        public List<Pieces> Piecesliste;
        public string Name;
        public int id;//de 0 pour l'équipe qui joue en premier (1 pour l'autre) represente leur place dans la liste
        //ainsi 1-id represente l'équipe ennemi
        public bool echecetmat;
        public bool echec;
        public Teams(int id,string name,Game g)
        {
            this.id = id;
            Name = name;
            Piecesliste = g.compo;
        }

        public void Update( Game g)
        {
            echec = est_echec(g.equipes[1-id]);
            echecetmat = et_mat();
            foreach (var p in Piecesliste)
            {
                p.Update(g);
            }
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