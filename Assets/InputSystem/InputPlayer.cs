using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputPlayer : MonoBehaviour
{
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(direction.x,0, direction.y) * Time.deltaTime * 3;
    }

    void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }
}
