using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawn : MonoBehaviour
{
    public GameObject[] enemypattern;
    private float timeBtwSpawn;
    public float starttimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            int rand = Random.Range(0, enemypattern.Length);
            Instantiate(enemypattern[rand], transform.position, Quaternion.identity);
            timeBtwSpawn = starttimeBtwSpawn;
            if (starttimeBtwSpawn > minTime)
            {
                starttimeBtwSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
