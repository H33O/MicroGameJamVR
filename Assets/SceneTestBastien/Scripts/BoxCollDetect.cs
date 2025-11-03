using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollDetect : MonoBehaviour
{
    [SerializeField] private QuestManager _questManager;
    [SerializeField] private String _pillarTag;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BallColored>() != null)
        {
            VerifGoodTag(other.gameObject);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<BallColored>() != null)
        {
            _questManager.AddBallQuantity(-1);
        }
    }

    public void VerifGoodTag(GameObject objet)
    {
        if (_pillarTag == objet.tag)
        {
            _questManager.AddBallQuantity(1);
        }
    }
}
