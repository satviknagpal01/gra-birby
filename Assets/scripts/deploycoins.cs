using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deploycoins : MonoBehaviour
{
    public GameObject coin;
    private Vector2 screenBounds;
    private Player player;
    private float timeBtwSpawn;
    public float starttimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 1f;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(coincall());
    }
    private void spawnCoin()
    {
        GameObject a = Instantiate(coin) as GameObject;
        timeBtwSpawn = starttimeBtwSpawn;
        if (starttimeBtwSpawn > minTime)
        {
            starttimeBtwSpawn -= decreaseTime;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
        a.transform.position = new Vector2(screenBounds.x * 1.3f, Random.Range(-4.5f, 4.5f));
    }

    // Update is called once per frame
    IEnumerator coincall()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBtwSpawn);
            spawnCoin();
        }
    }
}