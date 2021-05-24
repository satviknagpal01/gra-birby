using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthUpdater : MonoBehaviour
{
    public static float temp = 1;
    Vector3 localscale;
    void Start()
    {
        temp = DataBaseDDOL.healthDDOL;
        localscale = transform.localScale;
    }

    void Update()
    {
        if (Player.health != temp)
        {
            temp = Player.health;
            DataBaseDDOL.healthDDOL = temp;
            localscale.x = DataBaseDDOL.healthDDOL;
            transform.localScale = localscale;
        }
    }
}