using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public bool isConnected = false;
    public bool isWall;

    public Node[] neighbours = new Node[4];

    // Start is called before the first frame update
    void Start()
    {
        if (isWall)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.25f,0);
        }
        if (isReachable())
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (isConnected)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }

    public bool isReachable()
    {
        bool reachable = false;
        foreach (Node node in neighbours)
        {
            if (node == null)
            {
                continue;
            }
            if (!node.isWall)
            {
                reachable = true;
            }
        }
        if (isWall)
        {
            reachable = false;
        }
        return reachable;
    }
}
