using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject laserGun, laserShoot,explosionEffect;
    Rigidbody ship;
    public float speed=10,xMin,xMax,zMin,zMax,tilt,shootDelay;
    public static int hp;
    float timeToShoot;
    void Start()
    {
        ship = GetComponent<Rigidbody>();
        hp = 6;
    }

    void Update()
    {

        /*float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        */ship.velocity = new Vector3(Input.acceleration.x,0,Input.acceleration.y)*speed;

        float correctX = Mathf.Clamp(ship.position.x, xMin, xMax);
        float correctZ = Mathf.Clamp(ship.position.z, zMin, zMax);

        ship.position = new Vector3(correctX, 0, correctZ);

        ship.rotation = Quaternion.Euler(-ship.velocity.z*tilt, 0, -ship.velocity.x*tilt);

    }

    public void fire()
    {
        if (timeToShoot <= Time.time)
        {
            Instantiate(laserShoot, laserGun.transform.position, Quaternion.identity);
            timeToShoot = Time.time + shootDelay;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Laser"))
        {
            hp -= 1;
            if (hp <= 0)
            {
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
