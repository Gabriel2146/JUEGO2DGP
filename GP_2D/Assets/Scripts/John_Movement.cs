using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class John_Movement : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public float Speed;
    public float JumpForce;

    private Rigidbody2D Rigidbody2D; //referencia al rigid body del personaje 
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private float LastShoot; //almacena tiempo del ultimo disparo
    private int health = 5; //vida  

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();//accede al rigidbody 
        Animator = GetComponent<Animator>(); //accede a animator 
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal"); //obtiene input del teclado 

        if (Horizontal < 0.0f) transform.localScale = new Vector3 (-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f); 

        Animator.SetBool("running", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;

        //salto
        if(Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            Jump();
        }

        //bala
        if (Input.GetKeyUp(KeyCode.P) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }


    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed ,Rigidbody2D.velocity.y); //si pulsamos a ira a la izq y si pulsamod d a la der
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        Vector3 direction;

        if (transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector2.left;

        GameObject bullet = Instantiate(bulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletControl>().SetDirection(direction);
    }

    public void Hit ()
    {
        health = health - 1;
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

}
