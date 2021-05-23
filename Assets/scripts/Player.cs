using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float upspeed;
    public float downspeed;
    private Vector2 velocity;
    public Vector3 startrotation;
    private new Rigidbody2D rb;
    private SpriteRenderer spriterenderer;
    private Animator animator;
    public float speed;
    public int score;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        score = 0;
        transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(scoreincrease());
        var h = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, upspeed);
            transform.GetChild(0).gameObject.SetActive(true);
            //transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, -downspeed);
            transform.GetChild(0).gameObject.SetActive(true);
            //transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }
        else
        {
            StartCoroutine(jetpack());
        }
        Debug.Log(score);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            health -= 10;
            score -= 50;
            StartCoroutine(hurted());
            Destroy(collision.gameObject);
        }
    }
    IEnumerator jetpack()
    {
        yield return new WaitForSeconds(.3f);
        transform.GetChild(0).gameObject.SetActive(false);
    }
    IEnumerator hurted()
    {
        animator.Play("hurt");
        yield return new WaitForSeconds(.3f);
        animator.Play("idle");
    }
    IEnumerator scoreincrease()
    {
        yield return new WaitForSeconds(5f);
        score += 10;
    }
}
