using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace S2
{
    public abstract class Pieces
    {
        protected int X;
        protected int Y;
        protected int Z;
        public (int x ,int y) Position;
        protected (int x, int y) départ;
        public Teams team;
        public List<(int, int)> deplacement;
        protected abstract List<(int, int)> Possible_moves(Teams ennemi);

        public static bool Canmove((int, int) position, List<(int, int)> liste)
        {
            foreach (var pos in liste)
            {
                if (pos==position)
                    return true;
            }
            return false;
        }

        protected static int ennemi_present( int posx,int posy,Teams allié)
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

        public void Update(Game g)
        {
            deplacement = Possible_moves( g.equipes[1-team.id]);
        }
    }
    public abstract class Pawn:Pieces
    {
        protected override List<(int, int)> Possible_moves(Teams ennemi)
        {
            List<(int, int)> liste = new List<(int, int)>();
            if (ennemi_present(Position.x, Position.y+1, team)==0)
            {
                liste.Add((Position.x,Position.y+1) ) ;
                if (Position == this.départ)
                    if (ennemi_present(Position.x,Position.y+2,team)==0)
                    {
                        liste.Add((Position.x,Position.y+2) ) ;
                    }
            }
            if (ennemi_present(Position.x+1,Position.y+1,team)==2)
                liste.Add((Position.x+1,Position.y+1) );
            if (ennemi_present(Position.x+1,Position.y+1,team)==2)
                liste.Add((Position.x+1,Position.y+1) );
            return liste;
        }
        
    }
    public abstract class King:Pieces
    {
        protected override List<(int, int)> Possible_moves(Teams ennemi)
        {
            List<(int, int)> liste = new List<(int, int)>();
            int x = this.Position.x;
            int y = this.Position.y;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    liste.Add( (x+i,y+j) );//on initialise le carré
                }
            }
            liste.Remove(this.Position);
            
            foreach (Pieces adverse in ennemi.Piecesliste)
            {
                foreach (var pos in adverse.deplacement)
                {
                    foreach (var mv in deplacement)
                    {
                        if (mv == pos)
                        {
                            liste.Remove(mv);
                            break;
                        }
                    }
                }
            }
            
            return liste;
        }
        
    }
}