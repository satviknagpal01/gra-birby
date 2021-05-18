using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpspeed;
    Vector2 velocity;
    private new Rigidbody2D rigidbody2D;
    private SpriteRenderer spriterenderer;
    private Animator animator;
    public int score;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score += 10;
        var h = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, h * jumpspeed);
        }
        if (score % 1000 == 0)
        {
            jumpspeed = jumpspeed + 0.1f;
        }

    }
}
