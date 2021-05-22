using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployenemy : MonoBehaviour
{
    public GameObject snowman;
    private Vector2 screenBounds;
    private Player player;
    private float timeBtwSpawn;
    public float starttimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(enemycall());
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(snowman) as GameObject;
        timeBtwSpawn = starttimeBtwSpawn;
        if (starttimeBtwSpawn > minTime)
        {
            starttimeBtwSpawn -= decreaseTime;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
        a.transform.position = new Vector2(screenBounds.x * 1.3f, Random.Range(-4f, 6.2f));
        
    }

    // Update is called once per frame
    IEnumerator enemycall()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBtwSpawn);
            spawnEnemy();
        }
    }
}
