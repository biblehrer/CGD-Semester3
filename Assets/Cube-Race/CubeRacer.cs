using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CubeRacer : MonoBehaviour
{
    public int type;
    private float speed = 3;
    private Rigidbody rb;
    private NavMeshAgent agent;

    private NavMeshPath path;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (type == 5)
        {
            agent = GetComponent<NavMeshAgent>();

            path = new NavMeshPath();
            agent.CalculatePath(new Vector3(-3,0 , 3), path);
            StartCoroutine(WaitForStart());

        }        
    }

    IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(3);
        agent.SetPath(path);
    }

    void Update()
    {
       switch (type)
       {
            case 0:
                Move0();
                break; 
            case 1:
                Move1();
                break; 
            case 2:
                Move2();
                break; 
            case 3:
                Move3();
                break; 
            case 4:
                Move4();
                break; 
            case 5:
                //Move5();
                break; 
       }        
    }

    public void Move0()
    {
        transform.position += new Vector3(0, 0, 1) * Time.deltaTime * speed;
    }

    public void Move1()
    {
        transform.Translate( new Vector3(0, 0, 1) * Time.deltaTime * speed );
    }

    public void Move2()
    {
        rb.AddForce(new Vector3(0, 0, 50) * Time.deltaTime * speed);
    }

    public void Move3()
    {
        rb.velocity += new Vector3(0, 0, 1) * Time.deltaTime * speed;
    }

    public void Move4()
    {
        rb.velocity = new Vector3(0, 0, 1) *  speed;
    }



}
