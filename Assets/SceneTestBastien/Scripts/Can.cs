using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    [SerializeField] private ScoreData scoreData;
    private Boolean isScored = false;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Ground>() != null)
        {
            if (isScored)
            {
                Destroy(gameObject);
            }
            else
            {
                scoreData.score += 1;
                isScored = true;
                Destroy(gameObject);
            }
        }
    }
}
