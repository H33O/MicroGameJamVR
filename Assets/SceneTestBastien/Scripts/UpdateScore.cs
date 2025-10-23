using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textRef;
    [SerializeField] private ScoreData scoreData;

    // Update is called once per frame
    void Update()
    {
        textRef.text = scoreData.score.ToString();
    }
}
