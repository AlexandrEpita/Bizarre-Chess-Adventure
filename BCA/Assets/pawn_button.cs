using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pawn_button : MonoBehaviour
{
    public static string tonpere;
    public static bool tt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chooseDame()
    {
        tonpere = "Dame";
        tt = true;      
        /*m_game.ButtonPack.SetActive(false);*/
    }

    public void chooseFou()
    {
        tonpere = "Fou";
        tt = true;
    }

    public void chooseTour()
    {
        tonpere = "Tour";
        tt = true;
    }

    public void chooseCavalier()
    {
        tonpere = "Cavalier";
        tt = true;
    }
}
