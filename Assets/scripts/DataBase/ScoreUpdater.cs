using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    public static int temp = 0;
    void Start()
    {
        //temp = 0;
        temp = DataBaseDDOL.scoreDDOL;
        this.gameObject.GetComponent<Text>().text = ("SCORE: " + DataBaseDDOL.scoreDDOL);
    }

    void Update()
    {
        if (Player.score != temp)
        {
            temp = Player.score;
            DataBaseDDOL.scoreDDOL = temp;
            this.gameObject.GetComponent<Text>().text = ("SCORE: " + Player.score);
        }
    }
}