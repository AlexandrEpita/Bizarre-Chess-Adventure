using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace S2
{
    public abstract class Pièces
    {
        protected int X;
        protected int Y;
        protected int Z;
        public (int x ,int y) Position;
        protected (int x, int y) départ;
        public Teams Team;
        protected abstract List<(int, int)> Possible_moves(Echiquier e);

        public static bool Canmove((int, int) position, List<(int, int)> liste)
        {
            foreach (var pos in liste)
            {
                if (pos==position)
                    return true;
            }
            return false;
        }

       
        protected static int ennemi_present( int posx,int posy,Teams allié,Echiquier e)
        {
            int pos = Echiquier.Getposition(posx,posy);
            Case c=Echiquier.cases[pos];
            if (c.occupé)
                if (c.team !=allié.id)
                    return 2;//ennemi en place
                else
                {
                    return 1;// allié en place
                }
            
            return 0;
        }
    }
    public abstract class Pawn:Pièces
    {
        protected override List<(int, int)> Possible_moves(Echiquier e)
        {
            List<(int, int)> liste = new List<(int, int)>();
            if (ennemi_present(Position.x, Position.y+1, Team, e)==0)
            {
                liste.Add((Position.x,Position.y+1) ) ;
                if (Position == départ)
                    if (ennemi_present(Position.x,Position.y+2,Team,e)==0)
                    {
                        liste.Add((Position.x,Position.y+2) ) ;
                    }
            }
            if (ennemi_present(Position.x+1,Position.y+1,Team,e)==2)
                liste.Add((Position.x+1,Position.y+1) );
            if (ennemi_present(Position.x+1,Position.y+1,Team,e)==2)
                liste.Add((Position.x+1,Position.y+1) );
            return liste;
        }
        
    }
    
}