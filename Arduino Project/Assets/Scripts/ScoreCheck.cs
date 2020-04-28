using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCheck : MonoBehaviour
{
    public int score;
    private float lightTimer;

    void Update()
    {
        if (score < 25)
        {
            lightTimer = 20f;
            return;
        }
        if (score >= 25)
        {
            lightTimer = 15f;
            return;
        }
        if (score >= 50)
        {
            lightTimer = 5f;
            return;
        }
        if (score >= 100)
        {
            lightTimer = 1f;
            return;
        }

    }
}
