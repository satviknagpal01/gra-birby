﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveout : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.left * 3 * Time.deltaTime);
        Destroy(this.gameObject, 25f);
    }
}
