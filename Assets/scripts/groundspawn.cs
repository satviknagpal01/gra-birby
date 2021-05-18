using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundspawn : MonoBehaviour
{
    public GameObject ground;
    private float timeBtwSpawn;
    public float starttimeBtwSpawn;
    public float increaseTime;
    public float maxTime = 65f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            Instantiate(ground, transform.position, Quaternion.identity);
            timeBtwSpawn = starttimeBtwSpawn;
            if (starttimeBtwSpawn < maxTime)
            {
                starttimeBtwSpawn += increaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
