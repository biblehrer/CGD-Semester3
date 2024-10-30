using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputPlayerComplex : MonoBehaviour
{
    private InputAction move;
    //public InputActionAsset asset;

    // Start is called before the first frame update
    void Start()
    {
        var map = new InputComplex().Main;

        move = map.Move;

        move.Enable();        
    }

    // Update is called once per frame
    void Update()
    {
        direction = move.ReadValue<Vector2>();

        transform.position += new Vector3(direction.x,0, direction.y) * Time.deltaTime * 3;
    }

    private Vector2 direction;
}
