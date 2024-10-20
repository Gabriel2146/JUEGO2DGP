using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject John;
    public GameObject bulletPrefab;

    private float LastShoot;
    private int health = 3;

    // Update is called once per frame
    void Update()
    {
        if (John == null)
        {  return; }

        Vector3 direction = John.transform.position - transform.position; //mira al jugador siempre 
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);



        float distance = Mathf.Abs(John.transform.position.x - transform.position.x);

        if (distance < 1.0f && Time.time > LastShoot +0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }

    }

    private void Shoot()
    {
        Vector3 direction;

        if (transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector2.left;

        GameObject bullet = Instantiate(bulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletControl>().SetDirection(direction);


    }

    public void Hit()
    {
        health = health - 1;
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

}
