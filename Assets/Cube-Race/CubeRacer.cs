using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRacer : MonoBehaviour
{
    public int type;
    private float speed = 50;

    // Update is called once per frame
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
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(new Vector3(0, 0, 50) * Time.deltaTime * speed);
    }

    public void Move3()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity += new Vector3(0, 0, 1) * Time.deltaTime * speed;
    }

    public void Move4()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(0, 0, 1) *  speed;
        Debug.Log(rigidbody.velocity);
    }



}
