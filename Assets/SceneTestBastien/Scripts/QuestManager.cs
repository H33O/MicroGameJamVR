using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestManager : MonoBehaviour
{
    private int _ballQuantity = 0;
    private List<bool> _pillarsBallVerif;
    [SerializeField] private BoxCollDetect _boxCollDetect;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_ballQuantity >= 4)
        {
            _boxCollDetect.UpdateCanVerif(true);
            VerifyWin();
        }
    }

    public void AddBallQuantity(int quantity)
    {
        _ballQuantity += quantity;
    }

    void VerifyWin()
    {
        if(_pillarsBallVerif.Count >= 4)
        {
            
        }
    }

    public void AddListBool(Boolean result)
    {
        _pillarsBallVerif.Add(result);
    }
    
    public void ClearList()
    {
        _pillarsBallVerif.Clear();
    }
}
