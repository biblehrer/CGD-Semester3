using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnim : MonoBehaviour
{
    public Sprite[] sprites;

    public Image reference;
    public float frameRate = 1f;


    private float timer = 1f;
    private int i = 0;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = frameRate;
            reference.sprite = sprites[i];
            i++;
            if (i == sprites.Length)
            {
                i=0;
            }
        }
    }


}
