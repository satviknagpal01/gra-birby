using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float upspeed;
    public float downspeed;
    public Vector2 screenBounds;
    private Rigidbody2D rb;
    private Animator animator;
    public Camera came;
    public Animator cam;
    public float speed; 
    public static int score = 0;
    public static int coins = 0;
    public static int health = 100;
    private bool hurt = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        cam = camera.GetComponent<Animator>();
        score = 0;
        transform.GetChild(0).gameObject.SetActive(false);
        StartCoroutine(scoreincrease());
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
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
        if (health <= 0)
        {
            StartCoroutine(die());
            SceneManager.LoadScene("Score");
        }
    }
    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 , screenBounds.x);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1, screenBounds.y );
        transform.position = viewPos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            health -= 10;
            score -= 20;
            StartCoroutine(hurted());
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bounds"))
        {
            StartCoroutine(boundhurt());
        }
        if (other.gameObject.CompareTag("coin"))
        {
            coins++;
            score += 10;
            Destroy(other.gameObject);
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
    IEnumerator boundhurt()
    {
        animator.Play("hurt");
        yield return new WaitForSeconds(.4f);
        health--;
        animator.Play("idle");
    }
    IEnumerator scoreincrease()
    {
        yield return new WaitForSeconds(1f);
        score += 2;
        StartCoroutine(scoreincrease());
    }
    IEnumerator die()
    {
        hurt = true;
        animator.Play("hurt");
        yield return new WaitForSeconds(.6f);
        animator.Play("die");
        cam.Play("shake");
        yield return new WaitForSeconds(1f);
    }
}
