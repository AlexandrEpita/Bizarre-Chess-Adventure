using UnityEngine;

public class Echequier : MonoBehaviour
{
    Case[] cases;
    // Start is called before the first frame update
    void Start()
    {
        cases = new Case[64];
        float x_wd = 0.5f;
        float z_wd = 0.5f;
        for(int x = 0; x < 8; x++)
        {
            for(int y = 0; y < 8; y++)
            {
                GameObject go = new GameObject("case");
                go.transform.position = new Vector3(x_wd,0,z_wd);
                Case c = go.AddComponent<Case>();
                c.pos = (x, y);
                cases[x * 8 + y] = c;
                BoxCollider b=go.AddComponent<BoxCollider>();
                b.size = (new Vector3(1f, 0.5f, 1f));
                b.center = (Vector3.zero);
                x_wd += 1f;
            }
            x_wd= 0.5f;
            z_wd += 1f;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
    }
}
