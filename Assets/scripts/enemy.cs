using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private int health;
    private Player player;
    public GameObject effect;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = this.GetComponent<Player>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        health = Random.Range(3, 8);
    }
    private void Update()
    {
        if(transform.position.x < screenBounds.x * -1.3)
        {
            Destroy(this.gameObject);
        }
        if (health <= 0)
        {

            Player.score += 50;
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            //change this.
            Instantiate(effect, transform.position, Quaternion.identity);
            health--;
        }
    }
}
