using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstgroundmoveout : MonoBehaviour
{
    public float Speed;
    private Vector2 screenBounds;
    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
        if (transform.position.x < screenBounds.x * -1.3)
        {
            Destroy(this.gameObject);
        }
    }
}
