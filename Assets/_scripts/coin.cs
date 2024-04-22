using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private Player player;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = this.GetComponent<Player>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    private void Update()
    {
        if (transform.position.x < screenBounds.x * -1.3)
        {
            Destroy(this.gameObject);
        }
    }
}