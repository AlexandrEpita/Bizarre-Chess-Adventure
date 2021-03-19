using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
    public(int, int) pos;
    public Piece occupant;
    public Game.ChessColor chessColor;
    public bool occupe;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnMouseDown()
    {
        Destroy(gameObject);
    }
   
    // Update is called once per frame
    void Update()
    {
    }
}
