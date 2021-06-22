using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ChessColor = Game.ChessColor;

public class Piece : MonoBehaviour
{
    
    public ChessColor m_color;
    public List<Piece> wechequeur = new List<Piece>();
    public List<Piece> bechequeur = new List<Piece>();
    public bool moved;
    public bool done2;
    public bool echec;
    public bool rl;
    public bool rr;
    public ChessColor color 
    {
        set
        {
            m_color = value;
        }
    }

    public (float, float) m_position;
    public (float, float) position
    {
        set
        {
            m_position = value;
        }
    }
    
   
    public (float,float) depart;


    public Game m_game;
    public Game game 
    {
        set
        {
            m_game = value;
        }
    }


    public bool m_selected;
    public bool selected 
    {
        get
        {
            return m_selected;
        }
    }

    public bool Isin(Piece p, List<Piece> pl)
    {
        foreach (Piece p1 in pl)
        {
            if (p = p1)
            {
                return true;
            }
        }
        return false;
    }
    
    public List<(float, float)> Getsim(List<(float, float)> f1, List<(float, float)> f2)
    {
        List<(float, float)> f3 = new List<(float, float)>();
        foreach((float,float) ff in f1)
        {
            if (Case.find(ff, f2))
            {
                f3.Add(ff);
            }
        }
        return f3;
    }
    public static int ennemi_present((float, float) pos, ChessColor allie)
    {
        foreach(Piece p in Game.pieces)
        {
            if (p != null)
            {
                if (p.gameObject.transform.parent.position.z - 0.5f == pos.Item1 && p.gameObject.transform.parent.position.x - 0.5f == pos.Item2 && p.m_color != allie)
                {
                    return 2;
                }
                else if (p.gameObject.transform.parent.position.z - 0.5f == pos.Item1 && p.gameObject.transform.parent.position.x - 0.5f == pos.Item2 && p.m_color == allie)
                {
                    return 1;
                }
            }
            
        }
        return 0;
    }
    public Piece Whichennemi((float, float) f)
    {
        foreach (Piece p in Game.pieces)
        {
            if (p != null)
            {
                if ((p.transform.parent.position.z - 0.5f, p.transform.parent.position.x - 0.5f) == f)
                {
                    return p;
                }
            }
        }
        return null;
    }
    bool isechec()
    {
        foreach(Piece p in Game.pieces)
        {
            if (this.gameObject.name=="Roi(Clone)" && Case.find((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x - 0.5f), p.Possible_moves(p.gameObject)))
            {
                return true;
            }
        }
        return false;
        
    }
    public Piece Getroi(ChessColor c)
    {
        foreach(Piece p in Game.pieces)
        {
            if(p.m_color== c && p.gameObject.name=="Roi(Clone)" && p.m_color == c)
            {
                return p;
            }
        }
        return null;
    }
    public List<(float, float)> Possible_moves(GameObject model)
    {
        List<(float, float)> liste = new List<(float, float)>();

        if (model.name == "Pion(Clone)")
        {
            if (m_color == ChessColor.Blanc)
            {
                if (ennemi_present((this.transform.parent.position.z + 0.5f, this.transform.parent.position.x - 0.5f), this.m_color) == 0)
                {
                    liste.Add((this.transform.parent.position.z +0.5f, this.transform.parent.position.x - 0.5f));
                    if (!this.moved)
                        if (ennemi_present((this.transform.parent.position.z + 2 - 0.5f, this.transform.parent.position.x - 0.5f), this.m_color) == 0)
                        {
                            liste.Add((this.transform.parent.position.z + 2 - 0.5f, this.transform.parent.position.x - 0.5f));
                        }
                }
                if (ennemi_present((this.transform.parent.position.z +0.5f, this.transform.parent.position.x +0.5f), this.m_color) == 2)
                    liste.Add((this.transform.parent.position.z + 0.5f, this.transform.parent.position.x +0.5f));
                if (ennemi_present((this.transform.parent.position.z +0.5f, this.transform.parent.position.x -1.5f), this.m_color) == 2)
                    liste.Add((this.transform.parent.position.z +0.5f, this.transform.parent.position.x -1.5f));


                if (ennemi_present((transform.parent.position.z - 0.5f, transform.parent.position.x + 0.5f), m_color) == 2 && Whichennemi((transform.parent.position.z - 0.5f, transform.parent.position.x + 0.5f)).gameObject.name == "Pion(Clone)" && Whichennemi((transform.parent.position.z - 0.5f, transform.parent.position.x + 0.5f)).done2)
                    liste.Add((this.transform.parent.position.z + 0.5f, this.transform.parent.position.x + 0.5f));
                if (ennemi_present((transform.parent.position.z - 0.5f, transform.parent.position.x - 1.5f), m_color) == 2 && Whichennemi((transform.parent.position.z - 0.5f, transform.parent.position.x - 1.5f)).gameObject.name == "Pion(Clone)" && Whichennemi((transform.parent.position.z - 0.5f, transform.parent.position.x - 1.5f)).done2)
                    liste.Add((this.transform.parent.position.z + 0.5f, this.transform.parent.position.x - 1.5f));

                if (m_position.Item2 == 7.5)
                {
                    liste.Clear();
                }
            }
            if (m_color == ChessColor.Noir)
            {
                if (ennemi_present((this.transform.parent.position.z - 1.5f , this.transform.parent.position.x - 0.5f), this.m_color) == 0)
                {
                    liste.Add((this.transform.parent.position.z - 1.5f, this.transform.parent.position.x - 0.5f));
                    if (!moved)
                        if (ennemi_present((this.transform.parent.position.z - 2.5f, this.transform.parent.position.x - 0.5f), this.m_color) == 0)
                        {
                            liste.Add((this.transform.parent.position.z - 2 - 0.5f, this.transform.parent.position.x - 0.5f));
                        }
                }
                if (ennemi_present((this.transform.parent.position.z -1.5f, this.transform.parent.position.x - 1.5f), this.m_color) == 2)
                    liste.Add((this.transform.parent.position.z - 1.5f, this.transform.parent.position.x - 1.5f));
                if (ennemi_present((this.transform.parent.position.z - 1.5f, this.transform.parent.position.x + 0.5f), this.m_color) == 2)
                    liste.Add((this.transform.parent.position.z - 1.5f, this.transform.parent.position.x + 0.5f));

                if (ennemi_present((transform.parent.position.z - 0.5f, transform.parent.position.x + 0.5f), m_color) == 2 && Whichennemi((transform.parent.position.z - 0.5f, transform.parent.position.x + 0.5f)).gameObject.name == "Pion(Clone)" && Whichennemi((transform.parent.position.z - 0.5f, transform.parent.position.x + 0.5f)).done2)
                    liste.Add((this.transform.parent.position.z - 1.5f, this.transform.parent.position.x + 0.5f));
                if (ennemi_present((transform.parent.position.z - 0.5f, transform.parent.position.x - 1.5f), m_color) == 2 && Whichennemi((transform.parent.position.z - 0.5f, transform.parent.position.x - 1.5f)).gameObject.name == "Pion(Clone)" && Whichennemi((transform.parent.position.z - 0.5f, transform.parent.position.x - 1.5f)).done2)
                    liste.Add((this.transform.parent.position.z - 1.5f, this.transform.parent.position.x - 1.5f));


                if (m_position.Item2 == 0.5)
                {
                    liste.Clear();
                }
            }
        }

        if (model.name == "Tour(Clone)")
        {
            int i = 0;
            while (ennemi_present((this.transform.parent.position.z + i+ 0.5f, this.transform.parent.position.x - 0.5f), this.m_color) !=1 && this.transform.position.z+i+0.5f<8)
            {
                liste.Add((this.transform.parent.position.z +i+0.5f, this.transform.parent.position.x - 0.5f));
                if(ennemi_present((this.transform.parent.position.z +i+ 0.5f, this.transform.parent.position.x - 0.5f), this.m_color)== 2)
                {
                    break;
                }
                i++;
            }
            i = 0;
            while (ennemi_present((this.transform.parent.position.z + i - 1.5f, this.transform.parent.position.x - 0.5f), this.m_color) !=1 && this.transform.position.z + i - 0.5f > 0)  
            {
                liste.Add((this.transform.parent.position.z + i - 1.5f, this.transform.parent.position.x - 0.5f));
                if (ennemi_present((this.transform.parent.position.z + i - 1.5f, this.transform.parent.position.x - 0.5f), this.m_color) == 2)
                {
                    break;
                }
                i--;
            }
            i = 0;

            while (ennemi_present((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x+i +0.5f), this.m_color) != 1 && this.transform.position.x + i + 0.5f < 8)  
            {
                liste.Add((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x + i + 0.5f));
                if (ennemi_present((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x + i + 0.5f), this.m_color) == 2)
                {
                    break;
                }
                i++;
            }
            i = 0;
            while (ennemi_present((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x + i -1.5f), this.m_color) != 1 && this.transform.position.x + i - 0.5f > -1)
            {
                liste.Add((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x + i - 1.5f));
                if (ennemi_present((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x + i - 1.5f), this.m_color) == 2)
                {
                    break;
                }
                i--;
            }
            
        }
        if (model.name == "Cavalier(Clone)")
        {
            float x = this.transform.parent.position.z-0.5f;
            float y = this.transform.parent.position.x-0.5f;
            if (ennemi_present((x + 1, y + 2), m_color) != 1 && x+1<8 && y+2<8)
            {
                liste.Add((x + 1, y + 2));
            }
            if (ennemi_present((x - 1, y + 2), m_color) != 1 /*&& x - 1>0 && y + 2 < 8*/)
            {
                liste.Add((x - 1, y + 2));
            }
            if (ennemi_present((x + 1, y - 2), m_color) != 1 /*&& x + 1 < 8 && y - 2 >0*/)
            {
                liste.Add((x + 1, y - 2));
            }
            if (ennemi_present((x - 1, y - 2), m_color) != 1 /*&& x - 1 >0 && y - 2 >0*/)
            {
                liste.Add((x - 1, y - 2));
            }
            if (ennemi_present((x + 2, y + 1), m_color) != 1 /*&& x + 2 < 8 && y + 1 < 8*/)
            {
                liste.Add((x + 2, y + 1));
            }
            if (ennemi_present((x + 2, y -1), m_color) != 1 /*&& x + 2 < 8 && y - 1 >0*/)
            {
                liste.Add((x + 2, y - 1));
            }
            if (ennemi_present((x -2, y + 1), m_color) != 1 /*&& x -2 >0 && y + 1 < 8*/)
            {
                liste.Add((x-2, y + 1));
            }
            if (ennemi_present((x - 2, y - 1), m_color) != 1 /*&& x - 2 > 0 && y - 1 >0*/)
            {
                liste.Add((x - 2, y - 1));
            }
        }
        if (model.name == "Fou(Clone)")
        {
            int i = 0;
            while (ennemi_present((this.transform.parent.position.z+i+0.5f, this.transform.parent.position.x+i+0.5f), this.m_color) != 1 && this.transform.parent.position.z + i + 0.5f < 8 && this.transform.parent.position.x + i + 0.5f < 8)
            {
                liste.Add((this.transform.parent.position.z +i+ 0.5f, this.transform.parent.position.x+i+0.5f));
                if (ennemi_present((this.transform.parent.position.z+i+ 0.5f, this.transform.parent.position.x+i+ 0.5f), this.m_color) == 2)
                {
                    break;
                }
                i++;
            }

            i = 0;
            while (ennemi_present((this.transform.parent.position.z + i + 0.5f, this.transform.parent.position.x - i - 1.5f), this.m_color) != 1 && this.transform.parent.position.z + i + 0.5f < 8 && this.transform.parent.position.x - i - 1.5f > -1)
            {
                liste.Add((this.transform.parent.position.z + i + 0.5f, this.transform.parent.position.x - i - 1.5f));
                if (ennemi_present((this.transform.parent.position.z + i + 0.5f, this.transform.parent.position.x - i - 1.5f), this.m_color) == 2)
                {
                    break;
                }
                i++;
            }

            i = 0;
            while (ennemi_present((this.transform.parent.position.z - i -1.5f, this.transform.parent.position.x + i + 0.5f), this.m_color) != 1 && this.transform.parent.position.z -i-1.5f>-1 && this.transform.parent.position.x + i + 0.5f < 8)
            {
                liste.Add((this.transform.parent.position.z -i-1.5f, this.transform.parent.position.x + i + 0.5f));
                if (ennemi_present((this.transform.parent.position.z -i-1.5f, this.transform.parent.position.x + i + 0.5f), this.m_color) == 2)
                {
                    break;
                }
                i++;
            }
            i = 0;
            while (ennemi_present((this.transform.parent.position.z - i - 1.5f, this.transform.parent.position.x - i - 1.5f), this.m_color) != 1 && this.transform.parent.position.z - i - 1.5f > -1 && this.transform.parent.position.x - i - 1.5f >-1)
            {
                liste.Add((this.transform.parent.position.z - i - 1.5f, this.transform.parent.position.x -i-1.5f));
                if (ennemi_present((this.transform.parent.position.z - i - 1.5f, this.transform.parent.position.x - i -1.5f), this.m_color) == 2)
                {
                    break;
                }
                i++;
            }
        }
        if (model.name == "Dame(Clone)")
        {
            int i = 0;
            while (ennemi_present((this.transform.parent.position.z + i + 0.5f, this.transform.parent.position.x + i + 0.5f), this.m_color) != 1 && this.transform.parent.position.z + i + 0.5f < 8 && this.transform.parent.position.x + i + 0.5f < 8)
            {
                liste.Add((this.transform.parent.position.z + i + 0.5f, this.transform.parent.position.x + i + 0.5f));
                if (ennemi_present((this.transform.parent.position.z + i + 0.5f, this.transform.parent.position.x + i + 0.5f), this.m_color) == 2)
                {
                    break;
                }
                i++;
            }

            i = 0;
            while (ennemi_present((this.transform.parent.position.z + i + 0.5f, this.transform.parent.position.x - i - 1.5f), this.m_color) != 1 && this.transform.parent.position.z + i + 0.5f < 8 && this.transform.parent.position.x - i - 1.5f > -1)
            {
                liste.Add((this.transform.parent.position.z + i + 0.5f, this.transform.parent.position.x - i - 1.5f));
                if (ennemi_present((this.transform.parent.position.z + i + 0.5f, this.transform.parent.position.x - i - 1.5f), this.m_color) == 2)
                {
                    break;
                }
                i++;
            }

            i = 0;
            while (ennemi_present((this.transform.parent.position.z - i - 1.5f, this.transform.parent.position.x + i + 0.5f), this.m_color) != 1 && this.transform.parent.position.z - i - 1.5f > -1 && this.transform.parent.position.x + i + 0.5f < 8)
            {
                liste.Add((this.transform.parent.position.z - i - 1.5f, this.transform.parent.position.x + i + 0.5f));
                if (ennemi_present((this.transform.parent.position.z - i - 1.5f, this.transform.parent.position.x + i + 0.5f), this.m_color) == 2)
                {
                    break;
                }
                i++;
            }
            i = 0;
            while (ennemi_present((this.transform.parent.position.z - i - 1.5f, this.transform.parent.position.x - i - 1.5f), this.m_color) != 1 && this.transform.parent.position.z - i - 1.5f > -1 && this.transform.parent.position.x - i - 1.5f > -1)
            {
                liste.Add((this.transform.parent.position.z - i - 1.5f, this.transform.parent.position.x - i - 1.5f));
                if (ennemi_present((this.transform.parent.position.z - i - 1.5f, this.transform.parent.position.x - i - 1.5f), this.m_color) == 2)
                {
                    break;
                }
                i++;
            }
            i = 0;
            while (ennemi_present((this.transform.parent.position.z + i + 0.5f, this.transform.parent.position.x - 0.5f), this.m_color) != 1 && this.transform.position.z + i + 0.5f < 8)
            {
                liste.Add((this.transform.parent.position.z + i + 0.5f, this.transform.parent.position.x - 0.5f));
                if (ennemi_present((this.transform.parent.position.z + i + 0.5f, this.transform.parent.position.x - 0.5f), this.m_color) == 2)
                {
                    break;
                }
                i++;
            }
            i = 0;
            while (ennemi_present((this.transform.parent.position.z + i - 1.5f, this.transform.parent.position.x - 0.5f), this.m_color) != 1 && this.transform.position.z + i - 0.5f > 0)
            {
                liste.Add((this.transform.parent.position.z + i - 1.5f, this.transform.parent.position.x - 0.5f));
                if (ennemi_present((this.transform.parent.position.z + i - 1.5f, this.transform.parent.position.x - 0.5f), this.m_color) == 2)
                {
                    break;
                }
                i--;
            }
            i = 0;

            while (ennemi_present((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x + i + 0.5f), this.m_color) != 1 && this.transform.position.x + i + 0.5f < 8)
            {
                liste.Add((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x + i + 0.5f));
                if (ennemi_present((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x + i + 0.5f), this.m_color) == 2)
                {
                    break;
                }
                i++;
            }
            i = 0;
            while (ennemi_present((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x + i - 1.5f), this.m_color) != 1 && this.transform.position.x + i - 0.5f > -1)
            {
                liste.Add((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x + i - 1.5f));
                if (ennemi_present((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x + i - 1.5f), this.m_color) == 2)
                {
                    break;
                }
                i--;
            }

        }

        if (model.name == "Roi(Clone)")
        {
            float x = this.transform.parent.position.z;
            float y = this.transform.parent.position.x;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    liste.Add((x-0.5f + i, y-0.5f + j));
                }
            }
            List<(float, float)> secc = new List<(float, float)>();
            foreach (Piece p in Game.pieces)
            {
                if (p != null)
                {

                    if (p.m_color != this.m_color && p.gameObject.name == "Pion(Clone)")
                    {
                        foreach ((float, float) g in liste)
                        {
                            if (p.m_color == ChessColor.Blanc)
                            {
                                if (g.Item1 == p.gameObject.transform.parent.position.z + 0.5f && g.Item2 == p.gameObject.transform.parent.position.x -1.5f)
                                {
                                    secc.Add(g);
                                }
                                if (g.Item1 == p.gameObject.transform.parent.position.z + 0.5f && g.Item2 == p.gameObject.transform.parent.position.x + 0.5f)
                                {
                                    secc.Add(g);
                                }
                            }
                            if (p.m_color == ChessColor.Noir)
                            {
                                if (g.Item1 == p.gameObject.transform.parent.position.z -1.5f && g.Item2 == p.gameObject.transform.parent.position.x -1.5f)
                                {
                                    secc.Add(g);
                                }
                                if (g.Item1 == p.gameObject.transform.parent.position.z -1.5f && g.Item2 == p.gameObject.transform.parent.position.x + 0.5f)
                                {
                                    secc.Add(g);
                                }
                            }

                        }
                    }
                    if (p.m_color != this.m_color && (p.gameObject.name == "Roi(Clone)"))
                    {
                        
                        
                        float a = p.transform.parent.position.z;
                        float b = p.transform.parent.position.x;
                        for (int i = -1; i < 2; i++)
                        {
                            for (int j = -1; j < 2; j++)
                            {
                                foreach ((float, float) g in liste)
                                {
                                    if(g== (a - 0.5f + i, b - 0.5f + j))
                                    {
                                        if (i != 0 || j != 0)
                                        {
                                            secc.Add((a - 0.5f + i, b - 0.5f + j));
                                        }
                                    }
                                }  
                            }
                        }
                    }
                    if (p.m_color != this.m_color && (p.gameObject.name == "Cavalier(Clone)"))
                    {
                        float c = p.transform.parent.position.z-0.5f;
                        float d = p.transform.parent.position.x-0.5f;
                        foreach ((float, float) g in liste)
                        {
                            if (g == (c + 1, d + 2) || g == (c - 1, d + 2) || g == (c + 1, d - 2) || g == (c - 1, d - 2) || g == (c + 2, d + 1) || g == (c + 2, d -1) || g == (c - 2, d + 1) || g == (c - 2, d - 1))
                            {
                                secc.Add(g);
                            }
                        }

                    }
                    if (p.m_color != this.m_color && (p.gameObject.name == "Fou(Clone)"))
                    {
                        List<(float, float)> foupot = new List<(float, float)>();
                        int i = 0;
                        while (p.transform.parent.position.z + i + 0.5f < 8 && p.transform.parent.position.x + i + 0.5f < 8)
                        {
                            foupot.Add((p.transform.parent.position.z + i + 0.5f, p.transform.parent.position.x + i + 0.5f));
                            if (ennemi_present((p.transform.parent.position.z + i + 0.5f, p.transform.parent.position.x + i + 0.5f), p.m_color) == 2)
                            {
                                break;
                            }
                            if(ennemi_present((p.transform.parent.position.z + i + 0.5f, p.transform.parent.position.x + i + 0.5f), p.m_color) == 1)
                            {
                                break;
                            }
                            i++;
                        }
                        i = 0;
                        while (p.transform.parent.position.z + i + 0.5f < 8 && p.transform.parent.position.x - i -1.5f >-1)
                        {
                            foupot.Add((p.transform.parent.position.z + i + 0.5f, p.transform.parent.position.x - i -1.5f));
                            if (ennemi_present((p.transform.parent.position.z + i + 0.5f, p.transform.parent.position.x - i -1.5f), p.m_color) == 2)
                            {
                                break;
                            }
                            if (ennemi_present((p.transform.parent.position.z + i + 0.5f, p.transform.parent.position.x - i -1.5f), p.m_color) == 1)
                            {
                                break;
                            }
                            i++;
                        }
                        i = 0;
                        while (p.transform.parent.position.z - i - 1.5f >-1 && p.transform.parent.position.x + i + 0.5f <8)
                        {
                            foupot.Add((p.transform.parent.position.z - i - 1.5f, p.transform.parent.position.x + i + 0.5f));
                            if (ennemi_present((p.transform.parent.position.z - i -1.5f, p.transform.parent.position.x + i +0.5f), p.m_color) == 2)
                            {
                                break;
                            }
                            if (ennemi_present((p.transform.parent.position.z - i -1.5f, p.transform.parent.position.x + i + 0.5f), p.m_color) == 1)
                            {
                                break;
                            }
                            i++;
                        }
                        i = 0;
                        while (p.transform.parent.position.z - i - 1.5f >-1 && p.transform.parent.position.x - i -1.5f >-1)
                        {
                            foupot.Add((p.transform.parent.position.z - i - 1.5f, p.transform.parent.position.x - i -1.5f));
                            if (ennemi_present((p.transform.parent.position.z - i - 1.5f, p.transform.parent.position.x - i -1.5f), p.m_color) == 2)
                            {
                                break;
                            }
                            if (ennemi_present((p.transform.parent.position.z - i - 1.5f, p.transform.parent.position.x - i -1.5f), p.m_color) == 1)
                            {
                                break;
                            }
                            i++;
                        }

                        foreach ((float, float) g in liste)
                        {
                            if (Case.find(g, foupot))
                            {
                                secc.Add(g);
                            }
                        }

                    }
                    if (p.m_color != this.m_color && (p.gameObject.name == "Tour(Clone)"))
                    {
                        List<(float, float)> tourpot = new List<(float, float)>();
                        int i = 0;
                        while (p.transform.position.z + i + 0.5f < 8)
                        {
                            tourpot.Add((p.transform.parent.position.z + i + 0.5f, p.transform.parent.position.x - 0.5f));
                            if (ennemi_present((p.transform.parent.position.z + i + 0.5f, p.transform.parent.position.x - 0.5f), p.m_color) == 2)
                            {
                                break;
                            }
                            if (ennemi_present((p.transform.parent.position.z + i + 0.5f, p.transform.parent.position.x - 0.5f), p.m_color) == 1)
                            {
                                break;
                            }
                            i++;
                        }
                        i = 0;
                        while (p.transform.position.z - i -1.5f >-1)
                        {
                            tourpot.Add((p.transform.parent.position.z - i - 1.5f, p.transform.parent.position.x - 0.5f));
                            if (ennemi_present((p.transform.parent.position.z -i -1.5f, p.transform.parent.position.x - 0.5f), p.m_color) == 2)
                            {
                                break;
                            }
                            if (ennemi_present((p.transform.parent.position.z - i -1.5f, p.transform.parent.position.x - 0.5f), p.m_color) == 1)
                            {
                                break;
                            }
                            i++;
                        }
                        i = 0;
                        while (p.transform.position.x - i - 1.5f > -1)
                        {
                            tourpot.Add((p.transform.parent.position.z - 0.5f, p.transform.parent.position.x -i- 1.5f));
                            if (ennemi_present((p.transform.parent.position.z - 0.5f, p.transform.parent.position.x -i- 1.5f), p.m_color) == 2)
                            {
                                break;
                            }
                            if (ennemi_present((p.transform.parent.position.z - 0.5f, p.transform.parent.position.x - i - 1.5f), p.m_color) == 1)
                            {
                                break;
                            }
                            i++;
                        }
                        i = 0;
                        while (p.transform.position.x + i + 0.5f <8)
                        {
                            tourpot.Add((p.transform.parent.position.z - 0.5f, p.transform.parent.position.x + i +0.5f));
                            if (ennemi_present((p.transform.parent.position.z - 0.5f, p.transform.parent.position.x + i + 0.5f), p.m_color) == 2)
                            {
                                break;
                            }
                            if (ennemi_present((p.transform.parent.position.z - 0.5f, p.transform.parent.position.x + i + 0.5f), p.m_color) == 1)
                            {
                                break;
                            }
                            i++;
                        }

                        foreach ((float, float) g in liste)
                        {
                            if (Case.find(g, tourpot))
                            {
                                secc.Add(g);
                            }
                        }
                    }
                    if (p.m_color != this.m_color && (p.gameObject.name == "Dame(Clone)"))
                    {
                        List<(float, float)> damepot = new List<(float, float)>();
                        int i = 0;
                        while (p.transform.parent.position.z + i + 0.5f < 8 && p.transform.parent.position.x + i + 0.5f < 8)
                        {
                            damepot.Add((p.transform.parent.position.z + i + 0.5f, p.transform.parent.position.x + i + 0.5f));
                            if (ennemi_present((p.transform.parent.position.z + i + 0.5f, p.transform.parent.position.x + i + 0.5f), p.m_color) == 2)
                            {
                                break;
                            }
                            if (ennemi_present((p.transform.parent.position.z + i + 0.5f, p.transform.parent.position.x + i + 0.5f), p.m_color) == 1)
                            {
                                break;
                            }
                            i++;
                        }
                        i = 0;
                        while (p.transform.parent.position.z + i + 0.5f < 8 && p.transform.parent.position.x - i - 1.5f > -1)
                        {
                            damepot.Add((p.transform.parent.position.z + i + 0.5f, p.transform.parent.position.x - i - 1.5f));
                            if (ennemi_present((p.transform.parent.position.z + i + 0.5f, p.transform.parent.position.x - i - 1.5f), p.m_color) == 2)
                            {
                                break;
                            }
                            if (ennemi_present((p.transform.parent.position.z + i + 0.5f, p.transform.parent.position.x - i - 1.5f), p.m_color) == 1)
                            {
                                break;
                            }
                            i++;
                        }
                        i = 0;
                        while (p.transform.parent.position.z - i - 1.5f > -1 && p.transform.parent.position.x + i + 0.5f < 8)
                        {
                            damepot.Add((p.transform.parent.position.z - i - 1.5f, p.transform.parent.position.x + i + 0.5f));
                            if (ennemi_present((p.transform.parent.position.z - i - 1.5f, p.transform.parent.position.x + i + 0.5f), p.m_color) == 2)
                            {
                                break;
                            }
                            if (ennemi_present((p.transform.parent.position.z - i - 1.5f, p.transform.parent.position.x + i + 0.5f), p.m_color) == 1)
                            {
                                break;
                            }
                            i++;
                        }
                        i = 0;
                        while (p.transform.parent.position.z - i - 1.5f > -1 && p.transform.parent.position.x - i - 1.5f > -1)
                        {
                            damepot.Add((p.transform.parent.position.z - i - 1.5f, p.transform.parent.position.x - i - 1.5f));
                            if (ennemi_present((p.transform.parent.position.z - i - 1.5f, p.transform.parent.position.x - i - 1.5f), p.m_color) == 2)
                            {
                                break;
                            }
                            if (ennemi_present((p.transform.parent.position.z - i - 1.5f, p.transform.parent.position.x - i - 1.5f), p.m_color) == 1)
                            {
                                break;
                            }
                            i++;
                        }
                        i = 0;
                        while (p.transform.position.z + i + 0.5f < 8)
                        {
                            damepot.Add((p.transform.parent.position.z + i + 0.5f, p.transform.parent.position.x - 0.5f));
                            if (ennemi_present((p.transform.parent.position.z + i + 0.5f, p.transform.parent.position.x - 0.5f), p.m_color) == 2)
                            {
                                break;
                            }
                            if (ennemi_present((p.transform.parent.position.z + i + 0.5f, p.transform.parent.position.x - 0.5f), p.m_color) == 1)
                            {
                                break;
                            }
                            i++;
                        }
                        i = 0;
                        while (p.transform.position.z - i - 1.5f > -1)
                        {
                            damepot.Add((p.transform.parent.position.z - i - 1.5f, p.transform.parent.position.x - 0.5f));
                            if (ennemi_present((p.transform.parent.position.z - i - 1.5f, p.transform.parent.position.x - 0.5f), p.m_color) == 2)
                            {
                                break;
                            }
                            if (ennemi_present((p.transform.parent.position.z - i - 1.5f, p.transform.parent.position.x - 0.5f), p.m_color) == 1)
                            {
                                break;
                            }
                            i++;
                        }
                        i = 0;
                        while (p.transform.position.x - i - 1.5f > -1)
                        {
                            damepot.Add((p.transform.parent.position.z - 0.5f, p.transform.parent.position.x - i - 1.5f));
                            if (ennemi_present((p.transform.parent.position.z - 0.5f, p.transform.parent.position.x - i - 1.5f), p.m_color) == 2)
                            {
                                break;
                            }
                            if (ennemi_present((p.transform.parent.position.z - 0.5f, p.transform.parent.position.x - i - 1.5f), p.m_color) == 1)
                            {
                                break;
                            }
                            i++;
                        }
                        i = 0;
                        while (p.transform.position.x + i + 0.5f < 8)
                        {
                            damepot.Add((p.transform.parent.position.z - 0.5f, p.transform.parent.position.x + i + 0.5f));
                            if (ennemi_present((p.transform.parent.position.z - 0.5f, p.transform.parent.position.x + i + 0.5f), p.m_color) == 2)
                            {
                                break;
                            }
                            if (ennemi_present((p.transform.parent.position.z - 0.5f, p.transform.parent.position.x + i + 0.5f), p.m_color) == 1)
                            {
                                break;
                            }
                            i++;
                        }


                        foreach ((float, float) g in liste)
                        {
                            if (Case.find(g, damepot))
                            {
                                secc.Add(g);
                            }
                        }

                    }
                    
                }
            }
            foreach ((float, float) f in secc)
            {
                liste.Remove(f);
            }


            List<(float, float)> sec = new List<(float, float)>();
            foreach((float,float)n in liste)
            {
                if(ennemi_present((n.Item1,n.Item2), this.m_color) == 1)
                {
                    sec.Add(n);
                }
            }
            foreach((float,float)f in sec)
            {
                liste.Remove(f);
            }

            int m = 0;
            //Rock
            if (this.m_color == ChessColor.Blanc && !this.moved && Whichennemi((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x - 1.5f)) == null && Whichennemi((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x - 2.5f)) == null && Whichennemi((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x - 3.5f)) == null && getname(Whichennemi((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x - 4.5f))) == "Tour(Clone)" && Whichennemi((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x - 4.5f)).moved == false && !this.echec)
            {
                foreach (Piece p in Game.pieces)
                {
                    if (p != null)
                    {
                        if (p.m_color != this.m_color && getname(p) != "Roi(Clone)")
                        {
                            if (Case.find((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x - 1.5f), p.Possible_moves(p.gameObject)) || Case.find((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x - 2.5f), p.Possible_moves(p.gameObject)) || Case.find((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x - 3.5f), p.Possible_moves(p.gameObject)))
                            {
                                m++;
                            }
                        }
                    }
                    
                }
                if (m == 0) 
                {
                    liste.Add((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x - 2.5f));
                }
                
            }
            int o = 0;
            if (this.m_color == ChessColor.Blanc && !this.moved && Whichennemi((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x +0.5f)) == null && Whichennemi((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x +1.5f)) == null  && getname(Whichennemi((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x +2.5f))) == "Tour(Clone)" && Whichennemi((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x +2.5f)).moved == false && !this.echec)
            {
                foreach (Piece p in Game.pieces)
                {
                    if (p != null)
                    {
                        if (p.m_color != this.m_color)
                        {
                            if (Case.find((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x + 0.5f), p.Possible_moves(p.gameObject)) || Case.find((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x + 1.5f), p.Possible_moves(p.gameObject)))
                            {
                                o++;
                            }
                        }
                    }

                }
                if (o == 0)
                {
                    liste.Add((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x +1.5f));
                }

            }
            m = 0;
            if (this.m_color == ChessColor.Noir && !this.moved && Whichennemi((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x - 1.5f)) == null && Whichennemi((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x - 2.5f)) == null && Whichennemi((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x - 3.5f)) == null && getname(Whichennemi((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x - 4.5f))) == "Tour(Clone)" && Whichennemi((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x - 4.5f)).moved == false && !this.echec)
            {
                foreach (Piece p in Game.pieces)
                {
                    if (p != null)
                    {
                        if (p.m_color != this.m_color)
                        {
                            if (Case.find((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x - 1.5f), p.Possible_moves(p.gameObject)) || Case.find((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x - 2.5f), p.Possible_moves(p.gameObject)) || Case.find((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x - 3.5f), p.Possible_moves(p.gameObject)))
                            {
                                m++;
                            }
                        }
                    }
                    

                }
                if (m == 0)
                {
                    liste.Add((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x - 2.5f));
                }

            }
            o = 0;
            if (this.m_color == ChessColor.Noir && !this.moved && Whichennemi((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x + 0.5f)) == null && Whichennemi((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x + 1.5f)) == null && getname(Whichennemi((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x + 2.5f))) == "Tour(Clone)" && Whichennemi((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x + 2.5f)).moved == false && !this.echec)
            {
                foreach (Piece p in Game.pieces)
                {
                    if (p != null)
                    {
                        if (p.m_color != this.m_color && getname(p)!="Roi(Clone)")
                        {
                            if (Case.find((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x + 0.5f), p.Possible_moves(p.gameObject)) || Case.find((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x + 1.5f), p.Possible_moves(p.gameObject)))
                            {
                                o++;
                            }
                        }
                    }

                }
                if (o == 0)
                {
                    liste.Add((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x + 1.5f));
                }

            }
        }
        List<(float, float)> f1 = new List<(float, float)>();
        List<(float, float)> f2 = new List<(float, float)>();


        if (wechequeur.Count == 1)
        {
            if (m_game.m_turn == ChessColor.Blanc)
            {
                foreach (Piece p in wechequeur)
                {
                    if (p != null)
                    {
                        if (getname(p) == "Pion(Clone)" || getname(p) == "Cavalier(Clone)")
                        {
                            f1.Add((p.transform.parent.position.z - 0.5f, p.transform.parent.position.x - 0.5f));
                        }
                        if (getname(p) == "Tour(Clone)")
                        {
                            if (p.transform.parent.position.z - 0.5f > m_game.roiblanc.transform.parent.position.z - 0.5f)
                            {

                                float i = p.transform.parent.position.z - 0.5f;
                                while (i > m_game.roiblanc.transform.parent.position.z - 0.5f)
                                {
                                    f1.Add((i, p.transform.parent.position.x - 0.5f));
                                    i--;
                                }
                            }
                            else if (p.transform.parent.position.z - 0.5f < m_game.roiblanc.transform.parent.position.z - 0.5f)
                            {

                                float i = p.transform.parent.position.z - 0.5f;
                                while (i < m_game.roiblanc.transform.parent.position.z - 0.5f)
                                {
                                    f1.Add((i, p.transform.parent.position.x - 0.5f));
                                    i++;
                                }
                            }
                            else if (p.transform.parent.position.x - 0.5f > m_game.roiblanc.transform.parent.position.x - 0.5f)
                            {

                                float i = p.transform.parent.position.x - 0.5f;
                                while (i > m_game.roiblanc.transform.parent.position.x - 0.5f)
                                {
                                    f1.Add((p.transform.parent.position.z - 0.5f, i));
                                    i--;
                                }
                            }
                            else if (p.transform.parent.position.x - 0.5f < m_game.roiblanc.transform.parent.position.x - 0.5f)
                            {

                                float i = p.transform.parent.position.x - 0.5f;
                                while (i < m_game.roiblanc.transform.parent.position.x - 0.5f)
                                {
                                    f1.Add((p.transform.parent.position.z - 0.5f, i));
                                    i++;
                                }
                            }
                        }
                        if (getname(p) == "Fou(Clone)")
                        {
                            if (p.transform.parent.position.z - 0.5f > m_game.roiblanc.transform.parent.position.z - 0.5f && p.transform.parent.position.x - 0.5f > m_game.roiblanc.transform.parent.position.x - 0.5f)
                            {
                                float i = p.transform.parent.position.z - 0.5f;
                                float j = p.transform.parent.position.x - 0.5f;
                                while (i > m_game.roiblanc.transform.parent.position.z - 0.5f)
                                {

                                    f1.Add((i, j));
                                    i--;
                                    j--;
                                }
                            }

                            if (p.transform.parent.position.z - 0.5f < m_game.roiblanc.transform.parent.position.z - 0.5f && p.transform.parent.position.x - 0.5f < m_game.roiblanc.transform.parent.position.x - 0.5f)
                            {
                                float i = p.transform.parent.position.z - 0.5f;
                                float j = p.transform.parent.position.x - 0.5f;
                                while (i < m_game.roiblanc.transform.parent.position.z - 0.5f)
                                {
                                    f1.Add((i, j));
                                    i++;
                                    j++;
                                }
                            }

                            if (p.transform.parent.position.z - 0.5f < m_game.roiblanc.transform.parent.position.z - 0.5f && p.transform.parent.position.x - 0.5f > m_game.roiblanc.transform.parent.position.x - 0.5f)
                            {

                                float i = p.transform.parent.position.z - 0.5f;
                                float j = p.transform.parent.position.x - 0.5f;
                                while (i < m_game.roiblanc.transform.parent.position.z - 0.5f)
                                {
                                    f1.Add((i, j));
                                    i++;
                                    j--;
                                }
                            }

                            if (p.transform.parent.position.z - 0.5f > m_game.roiblanc.transform.parent.position.z - 0.5f && p.transform.parent.position.x - 0.5f < m_game.roiblanc.transform.parent.position.x - 0.5f)
                            {
                                float i = p.transform.parent.position.z - 0.5f;
                                float j = p.transform.parent.position.x - 0.5f;
                                while (i > m_game.roiblanc.transform.parent.position.z - 0.5f)
                                {
                                    f1.Add((i, j));
                                    i--;
                                    j++;
                                }
                            }
                        }
                        if (getname(p) == "Dame(Clone)")
                        {
                            if (p.transform.parent.position.z - 0.5f > m_game.roiblanc.transform.parent.position.z - 0.5f)
                            {

                                float i = p.transform.parent.position.z - 0.5f;
                                while (i > m_game.roiblanc.transform.parent.position.z - 0.5f)
                                {
                                    f1.Add((i, p.transform.parent.position.x - 0.5f));
                                    i--;
                                }
                            }
                            else if (p.transform.parent.position.z - 0.5f < m_game.roiblanc.transform.parent.position.z - 0.5f)
                            {

                                float i = p.transform.parent.position.z - 0.5f;
                                while (i < m_game.roiblanc.transform.parent.position.z - 0.5f)
                                {
                                    f1.Add((i, p.transform.parent.position.x - 0.5f));
                                    i++;
                                }
                            }
                            else if (p.transform.parent.position.x - 0.5f > m_game.roiblanc.transform.parent.position.x - 0.5f)
                            {

                                float i = p.transform.parent.position.x - 0.5f;
                                while (i > m_game.roiblanc.transform.parent.position.x - 0.5f)
                                {
                                    f1.Add((p.transform.parent.position.z - 0.5f, i));
                                    i--;
                                }
                            }
                            else if (p.transform.parent.position.x - 0.5f < m_game.roiblanc.transform.parent.position.x - 0.5f)
                            {

                                float i = p.transform.parent.position.x - 0.5f;
                                while (i < m_game.roiblanc.transform.parent.position.x - 0.5f)
                                {
                                    f1.Add((p.transform.parent.position.z - 0.5f, i));
                                    i++;
                                }
                            }
                            if (p.transform.parent.position.z - 0.5f > m_game.roiblanc.transform.parent.position.z - 0.5f && p.transform.parent.position.x - 0.5f > m_game.roiblanc.transform.parent.position.x - 0.5f)
                            {
                                float i = p.transform.parent.position.z - 0.5f;
                                float j = p.transform.parent.position.x - 0.5f;
                                while (i > m_game.roiblanc.transform.parent.position.z - 0.5f)
                                {

                                    f1.Add((i, j));
                                    i--;
                                    j--;
                                }
                            }

                            if (p.transform.parent.position.z - 0.5f < m_game.roiblanc.transform.parent.position.z - 0.5f && p.transform.parent.position.x - 0.5f < m_game.roiblanc.transform.parent.position.x - 0.5f)
                            {
                                float i = p.transform.parent.position.z - 0.5f;
                                float j = p.transform.parent.position.x - 0.5f;
                                while (i < m_game.roiblanc.transform.parent.position.z - 0.5f)
                                {
                                    f1.Add((i, j));
                                    i++;
                                    j++;
                                }
                            }

                            if (p.transform.parent.position.z - 0.5f < m_game.roiblanc.transform.parent.position.z - 0.5f && p.transform.parent.position.x - 0.5f > m_game.roiblanc.transform.parent.position.x - 0.5f)
                            {

                                float i = p.transform.parent.position.z - 0.5f;
                                float j = p.transform.parent.position.x - 0.5f;
                                while (i < m_game.roiblanc.transform.parent.position.z - 0.5f)
                                {
                                    f1.Add((i, j));
                                    i++;
                                    j--;
                                }
                            }

                            if (p.transform.parent.position.z - 0.5f > m_game.roiblanc.transform.parent.position.z - 0.5f && p.transform.parent.position.x - 0.5f < m_game.roiblanc.transform.parent.position.x - 0.5f)
                            {
                                float i = p.transform.parent.position.z - 0.5f;
                                float j = p.transform.parent.position.x - 0.5f;
                                while (i > m_game.roiblanc.transform.parent.position.z - 0.5f)
                                {
                                    f1.Add((i, j));
                                    i--;
                                    j++;
                                }
                            }
                        }
                    }

                }
                f2 = Getsim(f1, liste);
                liste.Clear();
                liste = f2;
                /*wechequeur.Clear();*/
            }
            if (bechequeur.Count == 1)
            {
                if (m_game.m_turn == ChessColor.Noir)
                {
                    foreach (Piece p in bechequeur)
                    {
                        if (p != null)
                        {
                            if (getname(p) == "Pion(Clone)" || getname(p) == "Cavalier(Clone)")
                            {
                                f1.Add((p.transform.parent.position.z - 0.5f, p.transform.parent.position.x - 0.5f));
                            }
                            if (getname(p) == "Tour(Clone)")
                            {
                                if (p.transform.parent.position.z - 0.5f > m_game.roinoir.transform.parent.position.z - 0.5f)
                                {

                                    float i = p.transform.parent.position.z - 0.5f;
                                    while (i > m_game.roinoir.transform.parent.position.z - 0.5f)
                                    {
                                        f1.Add((i, p.transform.parent.position.x - 0.5f));
                                        i--;
                                    }
                                }
                                else if (p.transform.parent.position.z - 0.5f < m_game.roinoir.transform.parent.position.z - 0.5f)
                                {

                                    float i = p.transform.parent.position.z - 0.5f;
                                    while (i < m_game.roinoir.transform.parent.position.z - 0.5f)
                                    {
                                        f1.Add((i, p.transform.parent.position.x - 0.5f));
                                        i++;
                                    }
                                }
                                else if (p.transform.parent.position.x - 0.5f > m_game.roinoir.transform.parent.position.x - 0.5f)
                                {

                                    float i = p.transform.parent.position.x - 0.5f;
                                    while (i > m_game.roinoir.transform.parent.position.x - 0.5f)
                                    {
                                        f1.Add((p.transform.parent.position.z - 0.5f, i));
                                        i--;
                                    }
                                }
                                else if (p.transform.parent.position.x - 0.5f < m_game.roinoir.transform.parent.position.x - 0.5f)
                                {

                                    float i = p.transform.parent.position.x - 0.5f;
                                    while (i < m_game.roinoir.transform.parent.position.x - 0.5f)
                                    {
                                        f1.Add((p.transform.parent.position.z - 0.5f, i));
                                        i++;
                                    }
                                }
                            }
                            if (getname(p) == "Fou(Clone)")
                            {
                                if (p.transform.parent.position.z - 0.5f > m_game.roinoir.transform.parent.position.z - 0.5f && p.transform.parent.position.x - 0.5f > m_game.roinoir.transform.parent.position.x - 0.5f)
                                {
                                    float i = p.transform.parent.position.z - 0.5f;
                                    float j = p.transform.parent.position.x - 0.5f;
                                    while (i > m_game.roinoir.transform.parent.position.z - 0.5f)
                                    {

                                        f1.Add((i, j));
                                        i--;
                                        j--;
                                    }
                                }

                                if (p.transform.parent.position.z - 0.5f < m_game.roinoir.transform.parent.position.z - 0.5f && p.transform.parent.position.x - 0.5f < m_game.roinoir.transform.parent.position.x - 0.5f)
                                {
                                    float i = p.transform.parent.position.z - 0.5f;
                                    float j = p.transform.parent.position.x - 0.5f;
                                    while (i < m_game.roinoir.transform.parent.position.z - 0.5f)
                                    {
                                        f1.Add((i, j));
                                        i++;
                                        j++;
                                    }
                                }

                                if (p.transform.parent.position.z - 0.5f < m_game.roinoir.transform.parent.position.z - 0.5f && p.transform.parent.position.x - 0.5f > m_game.roinoir.transform.parent.position.x - 0.5f)
                                {

                                    float i = p.transform.parent.position.z - 0.5f;
                                    float j = p.transform.parent.position.x - 0.5f;
                                    while (i < m_game.roinoir.transform.parent.position.z - 0.5f)
                                    {
                                        f1.Add((i, j));
                                        i++;
                                        j--;
                                    }
                                }

                                if (p.transform.parent.position.z - 0.5f > m_game.roinoir.transform.parent.position.z - 0.5f && p.transform.parent.position.x - 0.5f < m_game.roinoir.transform.parent.position.x - 0.5f)
                                {
                                    float i = p.transform.parent.position.z - 0.5f;
                                    float j = p.transform.parent.position.x - 0.5f;
                                    while (i > m_game.roinoir.transform.parent.position.z - 0.5f)
                                    {
                                        f1.Add((i, j));
                                        i--;
                                        j++;
                                    }
                                }
                            }
                            if (getname(p) == "Dame(Clone)")
                            {
                                if (p.transform.parent.position.z - 0.5f > m_game.roinoir.transform.parent.position.z - 0.5f)
                                {

                                    float i = p.transform.parent.position.z - 0.5f;
                                    while (i > m_game.roinoir.transform.parent.position.z - 0.5f)
                                    {
                                        f1.Add((i, p.transform.parent.position.x - 0.5f));
                                        i--;
                                    }
                                }
                                else if (p.transform.parent.position.z - 0.5f < m_game.roinoir.transform.parent.position.z - 0.5f)
                                {

                                    float i = p.transform.parent.position.z - 0.5f;
                                    while (i < m_game.roinoir.transform.parent.position.z - 0.5f)
                                    {
                                        f1.Add((i, p.transform.parent.position.x - 0.5f));
                                        i++;
                                    }
                                }
                                else if (p.transform.parent.position.x - 0.5f > m_game.roinoir.transform.parent.position.x - 0.5f)
                                {

                                    float i = p.transform.parent.position.x - 0.5f;
                                    while (i > m_game.roinoir.transform.parent.position.x - 0.5f)
                                    {
                                        f1.Add((p.transform.parent.position.z - 0.5f, i));
                                        i--;
                                    }
                                }
                                else if (p.transform.parent.position.x - 0.5f < m_game.roinoir.transform.parent.position.x - 0.5f)
                                {

                                    float i = p.transform.parent.position.x - 0.5f;
                                    while (i < m_game.roinoir.transform.parent.position.x - 0.5f)
                                    {
                                        f1.Add((p.transform.parent.position.z - 0.5f, i));
                                        i++;
                                    }
                                }
                                if (p.transform.parent.position.z - 0.5f > m_game.roinoir.transform.parent.position.z - 0.5f && p.transform.parent.position.x - 0.5f > m_game.roinoir.transform.parent.position.x - 0.5f)
                                {
                                    float i = p.transform.parent.position.z - 0.5f;
                                    float j = p.transform.parent.position.x - 0.5f;
                                    while (i > m_game.roinoir.transform.parent.position.z - 0.5f)
                                    {

                                        f1.Add((i, j));
                                        i--;
                                        j--;
                                    }
                                }

                                if (p.transform.parent.position.z - 0.5f < m_game.roinoir.transform.parent.position.z - 0.5f && p.transform.parent.position.x - 0.5f < m_game.roinoir.transform.parent.position.x - 0.5f)
                                {
                                    float i = p.transform.parent.position.z - 0.5f;
                                    float j = p.transform.parent.position.x - 0.5f;
                                    while (i < m_game.roinoir.transform.parent.position.z - 0.5f)
                                    {
                                        f1.Add((i, j));
                                        i++;
                                        j++;
                                    }
                                }

                                if (p.transform.parent.position.z - 0.5f < m_game.roinoir.transform.parent.position.z - 0.5f && p.transform.parent.position.x - 0.5f > m_game.roinoir.transform.parent.position.x - 0.5f)
                                {

                                    float i = p.transform.parent.position.z - 0.5f;
                                    float j = p.transform.parent.position.x - 0.5f;
                                    while (i < m_game.roinoir.transform.parent.position.z - 0.5f)
                                    {
                                        f1.Add((i, j));
                                        i++;
                                        j--;
                                    }
                                }

                                if (p.transform.parent.position.z - 0.5f > m_game.roinoir.transform.parent.position.z - 0.5f && p.transform.parent.position.x - 0.5f < m_game.roinoir.transform.parent.position.x - 0.5f)
                                {
                                    float i = p.transform.parent.position.z - 0.5f;
                                    float j = p.transform.parent.position.x - 0.5f;
                                    while (i > m_game.roinoir.transform.parent.position.z - 0.5f)
                                    {
                                        f1.Add((i, j));
                                        i--;
                                        j++;
                                    }
                                }
                            }
                        }

                    }
                    f2 = Getsim(f1, liste);
                    liste.Clear();
                    liste = f2;
                    /*wechequeur.Clear();*/
                }
            }
        }
        if (wechequeur.Count == 2)
        {
            liste.Clear();
        }
        if (bechequeur.Count == 2)
        {
            liste.Clear();
        }
        /*
        if (Getroi(m_game.m_turn).isechec())
        {
            
        }*/
       
        return liste; 
    }

    
    public void setPosition(Vector3 position)
    {
        m_position = ((float)position.x, (float)position.y);
    }

    public void initGame()
    {
    }
    IEnumerator waiter()
    {

        yield return new WaitForSeconds(0.15f);
        bechequeur.Clear();
        wechequeur.Clear();
        /*foreach (Piece p in Game.pieces)
        {
            if (p != null)
            {

                if (getname(p) == "Roi(Clone)")
                {
                    foreach (Piece p0 in Game.pieces)
                    {
                        if (p != null && p0 != null)
                        {
                            if (p0 != p)
                            {
                                if (Case.find((p.transform.parent.position.z - 0.5f, p.transform.parent.position.x - 0.5f), p0.Possible_moves(p0.gameObject)))
                                {
                                    if (p0.m_color == ChessColor.Blanc)
                                    {
                                        if (!Isin(p0, bechequeur))
                                        {
                                            bechequeur.Add(p0);
                                        }
                                    }
                                    else
                                    {
                                        if (!Isin(p0, wechequeur))
                                        {
                                            wechequeur.Add(p0);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }*/

        m_game.m_turn = (m_game.m_turn == ChessColor.Blanc) ? ChessColor.Noir : ChessColor.Blanc;
        if (m_game.m_turn == ChessColor.Noir)
        {
            foreach(Piece p in Game.pieces)
            {
                if (p.m_color == ChessColor.Noir && getname(p)=="Roi(Clone)")
                {
                    /*p.echec = false;*/
                    p.done2 = false;
                }
            }
        }
        if (m_game.m_turn == ChessColor.Blanc)
        {
            foreach (Piece p in Game.pieces)
            {
                if (p.m_color == ChessColor.Blanc && getname(p) == "Roi(Clone)")
                {
                    /*p.echec = false;*/
                    p.done2 = false;
                }
            }
        }
    }
    public static string getname(Piece piece)
    {
        if (piece != null)
        {
            return piece.gameObject.name;
        }
        else
        {
            return "";
        }
    }
    public void MoveTo((float, float) pos)
    {
        if (gameObject.name == "Pion(Clone)")
        {
            if (pos == (this.transform.parent.position.z + 0.5f, this.transform.parent.position.x + 0.5f) && m_game.m_turn == ChessColor.Blanc && getname(Whichennemi((transform.parent.position.z - 0.5f, transform.parent.position.x + 0.5f))) == "Pion(Clone)" && Whichennemi((transform.parent.position.z + 0.5f, transform.parent.position.x + 0.5f)) == null) //pour en passant (pep)
            {
                Destroy(Whichennemi((transform.parent.position.z - 0.5f, transform.parent.position.x + 0.5f)).gameObject);
            }
            if (pos == (this.transform.parent.position.z + 0.5f, this.transform.parent.position.x - 1.5f) &&  m_game.m_turn == ChessColor.Blanc && getname(Whichennemi((transform.parent.position.z - 0.5f, transform.parent.position.x - 1.5f)))== "Pion(Clone)" && Whichennemi((transform.parent.position.z + 0.5f, transform.parent.position.x - 1.5f)) == null) //pour en passant (pep)
            {
                Destroy(Whichennemi((transform.parent.position.z - 0.5f, transform.parent.position.x - 1.5f)).gameObject);
            }
            if (pos == (this.transform.parent.position.z - 1.5f, this.transform.parent.position.x + 0.5f) &&  m_game.m_turn == ChessColor.Noir && getname(Whichennemi((transform.parent.position.z - 0.5f, transform.parent.position.x + 0.5f))) == "Pion(Clone)" && Whichennemi((transform.parent.position.z - 1.5f, transform.parent.position.x + 0.5f)) == null) //pour en passant (pep)
            {
                Destroy(Whichennemi((transform.parent.position.z - 0.5f, transform.parent.position.x + 0.5f)).gameObject);
            }
            if (pos == (this.transform.parent.position.z - 1.5f, this.transform.parent.position.x - 1.5f) &&  m_game.m_turn == ChessColor.Noir && getname(Whichennemi((transform.parent.position.z - 0.5f, transform.parent.position.x - 1.5f))) == "Pion(Clone)" && Whichennemi((transform.parent.position.z - 1.5f, transform.parent.position.x - 1.5f)) == null) //pour en passant (pep)
            {
                Destroy(Whichennemi((transform.parent.position.z - 0.5f, transform.parent.position.x - 1.5f)).gameObject);
            }
        }

        if (gameObject.name == "Roi(Clone)")
        {
            if (this.m_color == ChessColor.Blanc)
            {
                if (pos == (this.transform.parent.position.z - 0.5f, this.transform.parent.position.x - 2.5f))
                {
                    Whichennemi((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x - 4.5f)).transform.parent.position = new Vector3(3.5f, 0.3f, 0.5f);
                }
                if (pos == (this.transform.parent.position.z - 0.5f, this.transform.parent.position.x +1.5f))
                {
                    Whichennemi((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x +2.5f)).transform.parent.position = new Vector3(5.5f, 0.3f, 0.5f);
                }
            }
            if (this.m_color == ChessColor.Noir)
            {
                if (pos == (this.transform.parent.position.z - 0.5f, this.transform.parent.position.x - 2.5f))
                {
                    Whichennemi((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x - 4.5f)).transform.parent.position = new Vector3(3.5f, 0.3f, 7.5f);
                }
                if (pos == (this.transform.parent.position.z - 0.5f, this.transform.parent.position.x +1.5f))
                {
                    Whichennemi((this.transform.parent.position.z - 0.5f, this.transform.parent.position.x + 2.5f)).transform.parent.position = new Vector3(5.5f, 0.3f, 7.5f);
                }
            }

        }

        if (pos == (this.transform.parent.position.z + 1.5f, this.transform.parent.position.x - 0.5f) && this.gameObject.name=="Pion(Clone)" && m_game.m_turn==ChessColor.Blanc) //pour en passant (pep)
        {
            this.done2 = true;
        }
        else if (pos == (this.transform.parent.position.z - 2.5f, this.transform.parent.position.x - 0.5f) && this.gameObject.name == "Pion(Clone)" && m_game.m_turn == ChessColor.Noir) // pep
        {
            this.done2 = true;
        }
        this.position = (pos.Item1, pos.Item2);
        transform.parent.position = new Vector3(pos.Item2, 0f, pos.Item1)+m_game.OFFSET;
        Deselect();
        moved = true;
        StartCoroutine(waiter());
    }

   
    public void Select()
    {
        if (m_game == null)
            Debug.Log("Game is null");

        if (m_color == m_game.m_turn)
        {
            if (m_selected)
            {
                Deselect();
            }
            else
            {
                transform.position += Vector3.up;
                m_game.selectedPiece = this;
                m_selected = true;
            }
        }
    }
    public void Deselect()
    {
        transform.position -= Vector3.up;
        //m_game.selectedPiece = null;
        m_selected = false;
    }

    public void OnMouseDown()
    {
        {
            Select();
        }
    }

    void Start()
    {
        m_selected = false;
        depart = (m_position.Item1,m_position.Item2);
    }


    // Update is called once per frame
    void Update()
    {
        foreach (Piece p in Game.pieces)
        {
            if (p != null)
            {

                if (getname(p) == "Roi(Clone)")
                {
                    foreach (Piece p0 in Game.pieces)
                    {
                        if (p != null && p0 != null)
                        {
                            if (p0 != p)
                            {
                                if (Case.find((p.transform.parent.position.z - 0.5f, p.transform.parent.position.x - 0.5f), p0.Possible_moves(p0.gameObject)))
                                {
                                    if (p0.m_color == ChessColor.Blanc)
                                    {
                                        if (!Isin(p0, bechequeur))
                                        {
                                            bechequeur.Add(p0);
                                        }
                                    }
                                    else
                                    {
                                        if (!Isin(p0, wechequeur))
                                        {
                                            wechequeur.Add(p0);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }




        if (this.m_position != depart)
        {
            moved = true;
        }

        foreach (Piece p in Game.pieces)
        {
            if (p != null)
            {
                
                if (getname(p) == "Roi(Clone)")
                {
                    List<(float, float)> tt = new List<(float, float)>();
                    foreach (Piece p0 in Game.pieces)
                    {
                        if (p != null && p0!=null)
                        {
                            if (p0 != p)
                            {
                                
                                if (Case.find((p.transform.parent.position.z - 0.5f, p.transform.parent.position.x - 0.5f), p0.Possible_moves(p0.gameObject)))
                                {
                                    tt.Add((p.transform.parent.position.z - 0.5f, p.transform.parent.position.x - 0.5f));
                                    
                                }

                                
                            }
                            
                        }
                    }
                    
                    if (tt.Count == 0)
                    {
                        p.echec = false;
                    }
                    else
                    {
                        p.echec = true;
                    }
                }

            }
            
        }

    }
}
