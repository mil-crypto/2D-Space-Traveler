using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSource : MonoBehaviour
{
    public GameObject asteroid;
    public float minDelay, maxDelay;


    float nextLaunch;//время запуска следующего астероди
    void Start()
    {
        
    }

    
    void Update()
    {
        if (!GameScore.isStart)
        {
            return;
        }
        if (Time.time > nextLaunch)
        {
            float halfWidth = transform.localScale.x / 2;
            float x = Random.Range(-halfWidth, halfWidth);
            float z = transform.position.z;
            Vector3 asteroidPosition = new Vector3(x,0,z);

            nextLaunch = Time.time + Random.Range(minDelay, maxDelay);
            Instantiate(asteroid, asteroidPosition, Quaternion.identity);
        }
    }
}
