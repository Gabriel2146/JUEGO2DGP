using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class John_Movement : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D; //referencia al rigid body del personaje 
    private float Horizontal;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();//accede al rigidbody 
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal"); //obtiene input del teclado 
        
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal,Rigidbody2D.velocity.y); //si pulsamos a ira a la izq y si pulsamod d a la der
    }
}
