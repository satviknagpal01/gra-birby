using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 6f;
    public float jumpspeed = 9f;
    float i = 0, c=1, p=10, lambda=7, m;
    Vector2 velocity;
    private new Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(h * speed, rigidbody2D.velocity.y);
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpspeed);
            m = rigidbody2D.gravityScale * 2 + lambda - p;
            rigidbody2D.gravityScale = (lambda * c + m) % p;
        }
        
    }
}
