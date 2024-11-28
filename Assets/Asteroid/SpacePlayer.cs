using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePlayer : MonoBehaviour
{
    public GameObject prefab;
    public GameObject soundEffectPrefab;

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3();
        if (Input.GetKey("w"))
        {
            movement += Vector3.up;
        }
        if (Input.GetKey("s"))
        {
            movement += Vector3.down;
        }
        if (Input.GetKey("a"))
        {
            movement += Vector3.left;
        }
        if (Input.GetKey("d"))
        {
            movement += Vector3.right;
        }
        transform.position += movement*Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab,transform.position,Quaternion.identity);
            Instantiate(soundEffectPrefab, transform.position,Quaternion.identity);
            //SoundManager.soundManager.PlaySound(0);
        }
    }
}
