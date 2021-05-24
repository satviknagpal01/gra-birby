using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthUpdater : MonoBehaviour
{
    public Slider slider;
    public static int temp = 100;
    void Start()
    {
        temp = DataBaseDDOL.healthDDOL;
        slider.maxValue = temp;
    }

    void Update()
    {
        if (Player.health != temp)
        {
            temp = Player.health;
            DataBaseDDOL.healthDDOL = temp;
            slider.value = DataBaseDDOL.healthDDOL;
        }
    }
}