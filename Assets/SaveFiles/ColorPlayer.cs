using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPlayer : MonoBehaviour
{
    public bool isRed;
    private bool selected;

    void Start()
    {
        selected = isRed;
        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(1);
        if (isRed)
        {
            transform.position = SaveManager.saveFile.pos1;
        }
        else
        {
            transform.position = SaveManager.saveFile.pos2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            selected = !selected;
        }
        
        if (selected)
        {
            float y = Input.GetAxis("Vertical");
            float x = Input.GetAxis("Horizontal");
            transform.position += new Vector3(x, y, 0)*Time.deltaTime*3;
        }

        if (Input.GetKeyUp("o"))
        {
            if (isRed)
            {
                SaveManager.saveFile.pos1 =  transform.position;
            }
            else
            {
                SaveManager.saveFile.pos2 =  transform.position;
            }

            SaveManager.Save();
        }
    }
}
