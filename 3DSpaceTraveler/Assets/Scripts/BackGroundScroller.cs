using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroller : MonoBehaviour
{
    Vector3 startPosition;
    public float speed = 10;
    void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        float z=Mathf.Repeat(Time.time*speed,120);
        Vector3 offset=new Vector3(0,0,-z);

        transform.position = startPosition + offset;
    }
}
