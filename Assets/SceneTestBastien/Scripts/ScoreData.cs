using UnityEngine;

// Permet de créer l'objet depuis le menu Unity
[CreateAssetMenu(fileName = "ScoreData", menuName = "Data/Score")]
public class ScoreData : ScriptableObject
{
    public int score;
}
