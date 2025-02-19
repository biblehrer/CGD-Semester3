using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    private Node[,] fields;
    public int height;
    public int width;
    public GameObject tilePrefab;
    private List<Node> toBeChecked = new List<Node>();

    void Start()
    {
        // Generate Level
        fields = new Node[height, width];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                bool isWall  = (Random.value>0.6f);
                int modI = i % 2;
                int modJ = j % 2;
                if (modI == 0 && modJ == 0)
                {
                    isWall = false;
                }
                if (modI == 1 && modJ == 1)
                {
                    isWall = true;
                }

                Vector3 position = transform.position + Vector3.right * j + Vector3.up * i;
                GameObject obj = Instantiate(tilePrefab, position, Quaternion.identity, transform);
                Node node = obj.GetComponent<Node>();
                node.isWall = isWall;
                fields[i,j] = node;
                 
                // Add Neighbours
                if (i > 0)
                {
                    node.neighbours[0] = fields[i-1,j];
                    fields[i-1,j].neighbours[1] = node;
                }

                if (j > 0)
                {
                    node.neighbours[2] = fields[i,j-1];
                    fields[i,j-1].neighbours[3] = node;
                }                
            }
        }

        // Check Connections
        fields[0,0].isConnected = true;
        toBeChecked.Add(fields[0,0]);
        CheckConnection(fields[0,0]);

        // Create Path to Goal
        Vector2 goal = new Vector2(height-1 - (height-1)%2, width-1 - (width-1)%2);
        ConnectNode(goal);
        CheckConnection(fields[(int)goal.x, (int)goal.y]);

    }

    private void CheckConnection(Node node)
    {
        foreach (var neighbour in node.neighbours)
        {
            if (neighbour == null)
            {
                continue;
            }
            if (neighbour.isWall)
            {
                continue;
            }

            if (!neighbour.isConnected)
            {
                neighbour.isConnected = true;
                toBeChecked.Add(neighbour);
            }
        }

        // Recursion
        toBeChecked.Remove(node);
        if (toBeChecked.Count > 0)
        {
           CheckConnection(toBeChecked[0]);
        }
    }

    private void ConnectNode(Vector2 vector)
    {
        int x = (int)vector.x;
        int y = (int)vector.y;

        if (fields[x,y].isConnected)
        {
            return;
        }
        Vector2 checkNext = new Vector2(x,y);
        switch (Random.Range(0,3))
        {
            case 0:
                if (x-2 >= 0)
                {
                    fields[x-1, y].isWall = false;
                    checkNext = new Vector2(x-2,y);
                }
                break;
            case 1:
                if (x+2 < height)
                {
                    fields[x+1, y].isWall = false;
                    checkNext = new Vector2(x+2,y);
                }
                break;
            case 2:
                if (y-2 >= 0)
                {
                    fields[x, y-1].isWall = false;
                    checkNext = new Vector2(x,y-2);
                }
                break;
            case 3:
                if (y+2 < width)
                {
                    fields[x-1, y+1].isWall = false;
                    checkNext = new Vector2(x,y+2);
                }
                break;
        }
        ConnectNode(checkNext);
    }
}