using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game : MonoBehaviour
{
    public static List<Piece> pieces = new List<Piece>();
    public GameObject ButtonPack;
    public GameObject Roi;
    public GameObject Dame;
    public GameObject Fou;
    public GameObject Tour;
    public GameObject Cavalier;
    public GameObject Pion;
    Vector3 v3 = new Vector3();
    ChessColor c3 = new ChessColor();
    public Piece roiblanc;
    public Piece roinoir;



    private Vector3 M_OFFSET = new Vector3(0.5f, 0.3f, 0.5f);
    public Vector3 OFFSET 
    {
        get
        {
            return M_OFFSET;
        }
    }



    public enum ChessColor
    {
        Blanc,
        Noir
    }

    public ChessColor m_turn;

    private Piece m_selectedPiece;
    public Piece selectedPiece 
    {
        get
        {
            return m_selectedPiece;
        }
        set
        {
            if (m_selectedPiece && m_selectedPiece.selected)
                m_selectedPiece.Deselect();
            m_selectedPiece = value;
        }
  
    }

    void initPiece(Piece p, ChessColor color, Vector3 position)
    {
        p.game = this;
        p.color = color;
        p.setPosition(position);
        Game.pieces.Add(p);
        if(Piece.getname(p)=="Roi(Clone)" && p.m_color == ChessColor.Blanc)
        {
            roiblanc = p;
        }
        else if (Piece.getname(p) == "Roi(Clone)" == Roi && p.m_color == ChessColor.Noir)
        {
            roinoir = p;
        }
    }

    void createPiece(GameObject model, Vector3 pos, ChessColor color)
    {
        GameObject holder = new GameObject("holder");
        holder.transform.position = pos;
        GameObject go = Instantiate(model, pos, Quaternion.Euler(90, 90, 0));
        Rigidbody r =go.AddComponent<Rigidbody>();
        r.isKinematic = true;
        r.useGravity = false;
        go.transform.parent = holder.transform;
        initPiece(go.AddComponent<Piece>(), color, go.transform.position);

        if (color == ChessColor.Noir)
        {
            if (m_turn == ChessColor.Blanc) 
            {
                holder.transform.position += (model == Pion) ? new Vector3(0, 0, 5) : new Vector3(0, 0, 7);
                holder.transform.forward = -holder.transform.forward;
            }
            
            go.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Black");
        }
    }
    public void initGame(ChessColor color)
    {
        createPiece(Roi,new Vector3(4.5f,0.3f,0.5f), color);
        createPiece(Dame, new Vector3(3.5f, 0.3f, 0.5f), color);
        createPiece(Tour, new Vector3(0.5f, 0.3f, 0.5f), color);
        createPiece(Tour, new Vector3(7.5f, 0.3f, 0.5f), color);
        createPiece(Fou, new Vector3(5.5f, 0.3f, 0.5f), color);
        createPiece(Fou, new Vector3(2.5f, 0.3f, 0.5f), color);
        createPiece(Cavalier, new Vector3(1.5f, 0.3f, 0.5f), color);
        createPiece(Cavalier, new Vector3(6.5f, 0.3f, 0.5f), color);
        createPiece(Pion, new Vector3(0.5f, 0.3f, 1.5f), color);
        createPiece(Pion, new Vector3(1.5f, 0.3f, 1.5f), color);
        createPiece(Pion, new Vector3(2.5f, 0.3f, 1.5f), color);
        createPiece(Pion, new Vector3(3.5f, 0.3f, 1.5f), color);
        createPiece(Pion, new Vector3(4.5f, 0.3f, 1.5f), color);
        createPiece(Pion, new Vector3(5.5f, 0.3f, 1.5f), color);
        createPiece(Pion, new Vector3(6.5f, 0.3f, 1.5f), color);
        createPiece(Pion, new Vector3(7.5f, 0.3f, 1.5f), color);
    }

    public IEnumerator waiter()
    {

        yield return new WaitForSeconds(0.3f);
        this.m_turn = (this.m_turn == ChessColor.Blanc) ? ChessColor.Noir : ChessColor.Blanc;
        if (this.m_turn == ChessColor.Noir)
        {
            foreach (Piece p in Game.pieces)
            {
                if (p.m_color == ChessColor.Noir)
                {
                    p.done2 = false;
                }
            }
        }
        if (this.m_turn == ChessColor.Blanc)
        {
            foreach (Piece p in Game.pieces)
            {
                if (p.m_color == ChessColor.Blanc)
                {
                    p.done2 = false;
                }
                    
            }
        }
    }







    // Start is called before the first frame update
    void Start()
    {
        initGame(ChessColor.Blanc);
        initGame(ChessColor.Noir);
        m_turn = ChessColor.Blanc;

        Debug.Log("Turn " + m_turn);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.pmb()==0 || this.pmn() == 0)
        {
            this.StopAllCoroutines();
        }

        if (m_turn == ChessColor.Blanc)
        {
            Camera.main.transform.position = new Vector3(4f, 6f, -2f);
            Camera.main.transform.rotation = new Quaternion(0.3826834f, 0, 0, 0.9238796f);
        }
        if (m_turn == ChessColor.Noir)
        {
            Camera.main.transform.position = new Vector3(4f, 6f, 10f);
            Camera.main.transform.rotation = new Quaternion(0, 180, -74.5f, 0);
        }
        foreach (Piece p in pieces)
        {
            if (p != null) //transfo pion
            {
                if (Piece.getname(p) == "Pion(Clone)")
                {
                    if (p.m_color == ChessColor.Blanc)
                    {
                        if (p.transform.parent.position.z == 7.5f)
                        {
                            Destroy(p.gameObject);
                            ButtonPack.SetActive(true);
                            v3 = p.transform.parent.position;
                            c3 = p.m_color;
                        }
                    }
                    if (p.m_color == ChessColor.Noir)
                    {
                        if (p.transform.parent.position.z == 0.5f)
                        {
                            Destroy(p.gameObject);
                            ButtonPack.SetActive(true);
                            v3 = p.transform.parent.position;
                            c3 = p.m_color;
                            
                        }
                    }
                }
            }
        }
        if (pawn_button.tt)
        {
            /*/createPiece(Dame, v3, c3);
            filou = false;*/
            ButtonPack.SetActive(false);
            pawn_button.tt = false;
            if (pawn_button.tonpere == "Dame")
            {
                createPiece(Dame, v3, c3);
                pawn_button.tonpere = "";
            }
            else if (pawn_button.tonpere == "Tour")
            {
                createPiece(Tour, v3, c3);
                pawn_button.tonpere = "";
            }
            else if (pawn_button.tonpere == "Fou")
            {
                createPiece(Fou, v3, c3);
                pawn_button.tonpere = "";
            }
            else if (pawn_button.tonpere == "Cavalier")
            {
                createPiece(Cavalier, v3, c3);
                pawn_button.tonpere = "";
            }
            StartCoroutine(waiter());
        }

    }
    public int pmb()
    {
        int n = 0;
        foreach (Piece p in Game.pieces)
        {
            if (p != null)
            {
                if (p.m_color == ChessColor.Blanc)
                {
                    if (p.Possible_moves(p.gameObject).Count > 0)
                    {
                        n++;
                    }
                }
            }
            
        }
        return n;
    }
    public int pmn()
    {
        int n = 0;
        foreach (Piece p in Game.pieces)
        {
            if (p.m_color == ChessColor.Noir)
            {
                if (p.Possible_moves(p.gameObject).Count > 0)
                {
                    n++;
                }
            }
        }
        return n;
    }

}
