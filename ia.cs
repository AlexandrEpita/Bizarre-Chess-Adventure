using System;
using System.Collections.Generic;

namespace S2
{
    public class ia
    {
        public class mvt
        {
            public (int, int) départ;
            public (int, int) arrivé;
            public int score;

            public mvt((int, int) d, (int, int) a)
            {
                départ = d;
                arrivé = a;
                score = 0;
            }
        }

        public List<mvt> liste_ia;
        public List<mvt> liste_j;
        private int valeur_des_bests = 50;//

        public ia(List<Pieces> allié, List<Pieces> ennemi)
        {
            foreach (var p in allié)
            {
                
                foreach (var v in p.deplacement)
                {
                    liste_ia.Add(new mvt(p.Position, v) );
                }
            }
            foreach (var p in ennemi)
            {
                
                foreach (var v in p.deplacement)
                {
                    liste_j.Add(new mvt(p.Position, v) );
                }
            }
            
        }
        public mvt Get_maxmvt(int i)
        {
            mvt rep = null;
            int val = 0;
            switch (i)
            {
                case 0:
                    foreach (var m in liste_ia)
                    {
                        if (m.score>val)
                        {
                            val = m.score;
                            rep = m;
                        }
                    }
                    break;
                case 1:
                    foreach (var m in liste_j)
                    {
                        if (m.score>val)
                        {
                            val = m.score;
                            rep = m;
                        }
                    }
                    break;
            }
            
            return rep;
        }
        public List<mvt> Get_bestmoves(int i)
        {
            mvt rep = Get_maxmvt(i);
            int val = rep.score-valeur_des_bests;
            List<mvt> l=new List<mvt>();
            
            switch (i)
            {
                case 0:
                    foreach (var m in liste_ia)
                    {
                        if (m.score>val)
                        {
                            l.Add(m);
                        }
                    }
                    break;
                case 1:
                    foreach (var m in liste_j)
                    {
                        if (m.score>val)
                        {
                            l.Add(m);
                        }
                    }
                    break;
            }

            return l;
        }
        public mvt Choose_one(List<mvt> l)
        {
            Random r=new Random();
            return  l.ToArray()[r.Next(l.Count)];
        }

        /*
        // max part of algo minmax
        long val_max(uint depth)
        {
            long maximum = -10000;
            if (depth == 0 || stop() > 0)
                return eval();

            for (int i = 0; i < 9; i++)
            {
                if (board[i] == '_')
                {
                    board[i] = 'x';
                    long tmp = val_min(depth - 1);
                    if (tmp > maximum)
                    {
                        maximum = tmp;
                    }
                    board[i] = '_';
                }
            }
            return maximum;
        }

        // min part of algo minmax
        long val_min(uint depth)
        {
            long minimum = 10000;
            if (depth == 0 || stop() > 0)
                return eval();
            for (int i = 0; i < 9; i++)
            {
                if (board[i] == '_')
                {
                    board[i] = 'o';
                    long tmp = val_max( depth - 1);
                    if (tmp < minimum)
                    {
                        minimum = tmp;
                    }
                    board[i] = '_';
                }
            }
            return minimum;
        }

        // returns a number allowing to know the "weight of the box",
        // depending on whether there is a winner, or if a player is close to winning
        // It is this number which will make it possible to know on which square played
        public long eval()
        {
            int result = stop();
            if (result == 2)
                return 1000 - nb_move();

            if (result == 1)
                return -1000 + nb_move();

            if (result == 3)
                return 0;
            

            long score = 0;
            score += diagonal( new[] {0, 4, 8}, 2);
            score += diagonal( new[] {2, 4, 6}, 2);
            score += horizontal( 2);
            score += vertical( 2);

            return score;
        }

        // play the ai
        void play_ia()
        {
            long maximum = -10000;
            int pos = -1;
            for (int i = 0; i < 9; i++)
            {
                if (board[i] == '_')
                {
                    board[i] = 'x';
                    long tmp = val_min(depth_ - 1);
                    if (tmp > maximum)
                    {
                        maximum = tmp;
                        pos = i;
                    }
                    board[i] = '_';
                }
            }
            if (pos != -1)
                board[pos] = 'x';
        }*/

    }
}