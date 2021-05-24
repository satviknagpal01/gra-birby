using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseDDOL : MonoBehaviour
{
    public static int healthDDOL = 100;
    public static int scoreDDOL = 0;
    public static int coinsDDol = 0;
    public static DataBaseDDOL instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        Player.coins = coinsDDol;
        Player.health = healthDDOL;
    }
    public static void ResetDDOL()
    {
        scoreDDOL = 0;
        healthDDOL = 3;
        coinsDDol = 0;
    }
}