using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;
using System.Xml;
using S2;

namespace S2
{
    public class Echiquier
    {
        int x, y;
        public static List<Case> cases;

        public Echiquier(Game g,int x,int y)
        {
            this.y = y;
            this.x = x;
            cases=new List<Case>();//0,1,...,47 pour les jeux normaux ont pourra changer si besoin le y
        }

        public static int Getposition(int x, int y)//(x,y) 
        {                               //(7,0)  (7,1)
            return y * 8 + x - 1;       //...    ...
        }                               //(1,0)  (1,1)   ...  (1,7)
                                        //(0,0)  (0,1)   ...  (0,7)
         public (int,int) Getxy(int pos)//position   exemple   
                                       //7   15
        {                              //... ...
            return (pos%8,pos/8);      //1   10
        }                              //0   9

         public static void Move(Pieces p,int x,int y)
         {
             int pos = Getposition(x, y);
             int xini = p.Position.x;
             int yini = p.Position.y;
             int posini = Getposition(xini,yini);
             if (cases[pos].occupant!=null)
             {
                 Destroy(cases[pos].occupant, x, y);
             }
             cases[posini].occupant = null;
             cases[pos].occupant = p;
         }

         public static void Destroy(Pieces p, int x, int y)
         {
             p=null;
         }
    }

    public class Case
    {
        //public Gameobject carré;
        public Pieces occupant;
        public bool occupé;
        public int team;
        public Case(bool occ,Pieces p,int t)
        {
            occupé = occ;
            occupant = p;
            team = t;
        }
    }
}