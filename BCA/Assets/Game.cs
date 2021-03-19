using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject Roi;
    public GameObject Dame;
    public GameObject Fou;
    public GameObject Tour;
    public GameObject Cavalier;
    public GameObject Pion;

    private Vector3 M_OFFSET = new Vector3(0.5f, 0.3f, 0.5f);
    public Vector3 OFFSET 
    {
        get
        {
            return M_OFFSET;
        }
    }
    
    /*public List<(int, int)> Possible_moves(GameObject model)
    {
        if (model == Pion)
        {

        }
    }*/

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
    }

    void createPiece(GameObject model, Vector3 pos, ChessColor color)
    {
        GameObject holder = new GameObject("holder");
        holder.transform.position = pos;
        GameObject go = Instantiate(model, pos, Quaternion.Euler(90, 90, 0));
        go.transform.parent = holder.transform;
        initPiece(go.AddComponent<Piece>(), color, go.transform.position);

        if (color == ChessColor.Noir)
        {
            holder.transform.position += (model == Pion) ? new Vector3(0, 0, 5) : new Vector3(0, 0, 7);
            holder.transform.forward = -holder.transform.forward;
            go.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Black");
        }
    }
    public void initGame(ChessColor color)
    {
        createPiece(Roi,new Vector3(4.5f,0.3f,0.5f), color);
        createPiece(Dame, new Vector3(3.5f, 0.3f, 0.5f), color);
        createPiece(Tour, new Vector3(0.5f, 0.3f, 0.5f), color);
        createPiece(Tour, new Vector3(7.5f, 0.3f, 0.5f), color);
        createPiece(Fou, new Vector3(6.5f, 0.3f, 0.5f), color);
        createPiece(Fou, new Vector3(2.5f, 0.3f, 0.5f), color);
        createPiece(Cavalier, new Vector3(1.5f, 0.3f, 0.5f), color);
        createPiece(Cavalier, new Vector3(5.5f, 0.3f, 0.5f), color);
        createPiece(Pion, new Vector3(0.5f, 0.3f, 1.5f), color);
        createPiece(Pion, new Vector3(1.5f, 0.3f, 1.5f), color);
        createPiece(Pion, new Vector3(2.5f, 0.3f, 1.5f), color);
        createPiece(Pion, new Vector3(3.5f, 0.3f, 1.5f), color);
        createPiece(Pion, new Vector3(4.5f, 0.3f, 1.5f), color);
        createPiece(Pion, new Vector3(5.5f, 0.3f, 1.5f), color);
        createPiece(Pion, new Vector3(6.5f, 0.3f, 1.5f), color);
        createPiece(Pion, new Vector3(7.5f, 0.3f, 1.5f), color);
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_turn = (m_turn == ChessColor.Blanc) ? ChessColor.Noir : ChessColor.Blanc;
            Debug.Log("Turn " + m_turn);
        }
        if (m_turn == ChessColor.Blanc)
        {
            Camera.main.transform.position = new Vector3(4f, 6f, -2f);
            Camera.main.transform.rotation = new Quaternion(0.3826834f, 0,0, 0.9238796f);
        }
        if (m_turn == ChessColor.Noir)
        {
            Camera.main.transform.position = new Vector3(4f, 6f, 10f);
            Camera.main.transform.rotation = new Quaternion(0, 180, -74.5f, 0);
        }
    }
}
