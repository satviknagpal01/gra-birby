using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpspeed;
    private Vector2 velocity;
    public Vector3 startrotation;
    private new Rigidbody2D rb;
    private SpriteRenderer spriterenderer;
    private Animator animator;
    public float speed;
    public int score;
    public int health;
    public bool grounded = false , hurt = false, fly = false;
    //public GameObject jetpack;
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
        score += 100;
        var h = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))
        {
            fly = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
            transform.GetChild(0).gameObject.SetActive(true);
            //transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }
        else
        {
            StartCoroutine(ExampleCoroutine());
        }
        /*if (score % 10000 == 0)
        {
            jumpspeed = jumpspeed + 0.1f;
        }*/
        if (grounded)
        {
            animator.Play("walk");
        }
        if (fly)
        {
            transform.eulerAngles = new Vector3(0,0,-45);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    private void FixedUpdate()
    {
        
    }
    void moveCharacter(Vector2 direction)
    {
        rb.velocity = direction * jumpspeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="ground")
        {
            grounded = true;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = false;
            fly = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            health -= 10;
            animator.Play("hurt");
            StartCoroutine(ExampleCoroutine());
            Destroy(other.gameObject);
        }
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(.3f);
        transform.GetChild(0).gameObject.SetActive(false);
        fly = false;
    }
}
