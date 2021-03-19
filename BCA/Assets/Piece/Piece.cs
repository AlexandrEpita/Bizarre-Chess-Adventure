using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ChessColor = Game.ChessColor;

public class Piece : MonoBehaviour
{    
    public ChessColor m_color;
    public ChessColor color 
    {
        set
        {
            m_color = value;
        }
    }
    public (int, int) m_position;
    public (int, int) position
    {
        set
        {
            m_position = value;
        }
    }

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

    void Start()
    {
        m_selected = false;
    }

    public void setPosition(Vector3 position)
    {
        m_position = ((int)position.x, (int)position.y);
    }

    public void initGame()
    {
    }
    public void MoveTo((int, int) pos)
    {
        transform.position = new Vector3(pos.Item1, 0f, pos.Item2) + m_game.OFFSET;
        Deselect();
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
        Select();
    }


    // Update is called once per frame
    void Update()
    {
    }
}
