using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{
    private float StartX, EndX=-19.0f, Speed=3;
    void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
        if (transform.position.x <= EndX)
        {
            Vector2 pos = new Vector2(Random.Range(20.00f, 160.00f), transform.position.y);
            transform.position = pos;
        }
    }
}