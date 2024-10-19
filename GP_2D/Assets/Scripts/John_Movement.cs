using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class John_Movement : MonoBehaviour
{
    public float JumpForce;
    public float Speed;

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

        //salto
        if(Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }

    }
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal,Rigidbody2D.velocity.y); //si pulsamos a ira a la izq y si pulsamod d a la der
    }
}
