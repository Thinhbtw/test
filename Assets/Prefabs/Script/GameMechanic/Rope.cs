using UnityEngine;

public class Rope : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody2D hook;
    [SerializeField] GameObject linkPrefabs;
    [SerializeField] Bomb bomb;

    public int links = 7;

    void Start()
    {
        GenerateRope();
    }
    
    void GenerateRope()
    {
        Rigidbody2D previousHook = hook;
        for(int i = 0; i < links; i++)
        {
            GameObject link = Instantiate(linkPrefabs, transform);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousHook;

            if(i < links - 1)
            {
                previousHook = link.GetComponent<Rigidbody2D>(); 
            }
            else
            {
                bomb.ConnectRopeEnd(link.GetComponent<Rigidbody2D>());
            }

        }
    }


}
