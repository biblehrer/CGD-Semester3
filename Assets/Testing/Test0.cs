using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test0 : MonoBehaviour
{
    private NavMeshAgent agentN;

    // Start is called before the first frame update
    void Start()
    {
        agentN = GetComponent<NavMeshAgent>();
        agentN.SetDestination(Vector3.forward*100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
