using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NM_annoy : MonoBehaviour
{
    private float timer = 3f;
    private float direction = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime * Vector3.forward;
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction *= -1;
            timer = 3;
        }

    }
}
