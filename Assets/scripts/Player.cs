using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float upspeed;
    public float downspeed;
    private Vector2 velocity;
    public Vector3 startrotation;
    private Rigidbody2D rb;
    private SpriteRenderer spriterenderer;
    private Animator animator;
    public float speed; 
    public static int score = 0;
    public static int coins = 0;
    public static float health = 1;
    private bool hurt = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        score = 0;
        transform.GetChild(0).gameObject.SetActive(false);
        StartCoroutine(scoreincrease());
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Vertical");
        if ((Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow) )&& !(hurt))
        {
            rb.velocity = new Vector2(rb.velocity.x, upspeed);
            transform.GetChild(0).gameObject.SetActive(true);
            //transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }
        else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))&& !(hurt))
        {
            rb.AddForce(transform.up *-1 *downspeed);
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
            health -= 0.1f;
            score -= 20;
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
        hurt = true;
        animator.Play("hurt");
        yield return new WaitForSeconds(.3f);
        animator.Play("idle");
        hurt = false;
    }
    IEnumerator scoreincrease()
    {
        yield return new WaitForSeconds(1f);
        score += 2;
        StartCoroutine(scoreincrease());
    }
}
