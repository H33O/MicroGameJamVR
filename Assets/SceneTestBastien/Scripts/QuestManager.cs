using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestManager : MonoBehaviour
{
    private int _ballQuantity = 0;
    [SerializeField] private DoorOpening _DoorManager;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        VerifyWin();
    }

    public void AddBallQuantity(int quantity)
    {
        _ballQuantity += quantity;
    }

    void VerifyWin()
    {
        if (_ballQuantity >= 4)
        {
            _DoorManager.DoorOpen();
            
        }
    }
}