using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
    public(float, float) pos;
    public Piece occupant;
    public Game.ChessColor chessColor;
    public bool occupe;
    
    public Case((float,float)pos)//pos de la case relative au tableau
    {
        this.pos = pos;
    }
    public static (float,float) getPos(Case cas)
    {
        return cas.pos;
    }
   

    public static bool find((float, float)n, List<(float,float)> v)
    {
        foreach ((float,float)g in v)
        {
            if (n==g)
            {
                return true;
            }
        }
        return false;
    }
   
    public void OnMouseDown()
    {
        foreach(Piece p in Game.pieces)
        {
            if (p != null)
            {
                if (p.m_selected && find((this.pos.Item1, this.pos.Item2), p.Possible_moves(p.gameObject)))
                {
                    p.MoveTo(this.pos);
                    foreach (Piece p2 in Game.pieces)
                    {
                        if (p2 != null)
                        {
                            if (p2.m_color != p.m_color && p2.gameObject.transform.parent.position.z - 0.5f == this.pos.Item1 && p2.gameObject.transform.parent.position.x - 0.5f == this.pos.Item2)
                            {
                                Destroy(p2.gameObject);
                            }
                        }

                    }
                }
            }
        }

    }
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
