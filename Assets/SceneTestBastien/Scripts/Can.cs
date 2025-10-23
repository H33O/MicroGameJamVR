using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    [SerializeField] private ScoreData scoreData;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Ground>() != null)
        {
            scoreData.score += 1;
            Destroy(gameObject);
        }
    }
}
