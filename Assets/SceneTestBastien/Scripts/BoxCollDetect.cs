using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollDetect : MonoBehaviour
{
    [SerializeField] private QuestManager _questManager;
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private String _pillarTag;
    [SerializeField] private Boolean _canVerif = false;
    private GameObject _ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_canVerif)
        {
            VerifGoodTag(_ball);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == _ballPrefab)
        {
            _questManager.AddBallQuantity(1);
            _ball = other.gameObject;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other == _ballPrefab)
        {
            _questManager.AddBallQuantity(-1);
        }
    }

    public void VerifGoodTag(GameObject objet)
    {
        if (_pillarTag == objet.tag)
        {
            _questManager.AddListBool(true);
        }
    }

    public void UpdateCanVerif(Boolean state)
    {
        _canVerif = state;
    }
}
