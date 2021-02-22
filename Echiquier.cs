using System.Collections.Generic;
using S2;

namespace S2
{
    public class Echiquier
    {
        int x, y;
        public Game partie;
        public List<Case> cases;

        public Echiquier(Game g,int x,int y)
        {
            this.y = y;
            this.x = x;
            partie = g;
            cases=new List<Case>();//0,1,...,47 pour les jeux normaux ont pourra changer si besoin le y
        }

        public int Getposition(int x, int y)//(x,y) 
        {                               //(7,0)  (7,1)
            return y * 8 + x - 1;       //...    ...
        }                               //(1,0)  (1,1)   ...  (1,7)
                                        //(0,0)  (0,1)   ...  (0,7)
         public (int,int) Getxy(int pos)//position   exemple   
                                       //7   15
        {                              //... ...
            return (pos%8,pos/8);      //1   10
        }                              //0   9

         protected static void Move(Pièces p,int x,int y)
         {
            
         }
    }

    public class Case
    {
        
        public Pièces occupant;
        public bool occupé;
        public int team;
        public Case(bool occ,Pièces p,int t)
        {
            occupé = occ;
            occupant = p;
            team = t;
        }
    }
}