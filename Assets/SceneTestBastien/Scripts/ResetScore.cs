using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour
{
    [SerializeField] private ScoreData scoreData;

    public void SetScoreZero()
    {
        scoreData.score = 0;
    }
}