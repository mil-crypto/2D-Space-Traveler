using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float angualarSpeed,speed,hp;
    public GameObject asteroidExpiosion;
    Rigidbody asteroid;

    float size;
    void Start()
    {
        size = Random.Range(0.5f,2f);
        asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere*angualarSpeed;
        asteroid.velocity = new Vector3(0, 0,-speed)/size;
        asteroid.transform.localScale *= size;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid"))
        {
            Debug.Log("СТОЛКНОВЕНИЕ АСТЕРОИДОВ!!!");
            return;
        }
        else if ((other.CompareTag("Laser")) || other.CompareTag("Player"))
        {

            GameObject explosion = Instantiate(asteroidExpiosion, transform.position, Quaternion.identity);
            explosion.transform.localScale /= hp;
            hp -= 1;
            if (hp <= 0)
            {
                GameScore.score += 10;
                Destroy(gameObject);

            }
        }
    
    }


}
