using UnityEngine;

public class SpawnThrowingBall : MonoBehaviour
{
    [SerializeField] private GameObject throwingBallPrefab;
    [SerializeField] private string referenceTag = "throwingball";
    [SerializeField] private float verticalOffset = 1f;

    // Appel� quand le bouton est press�
    public void SpawnBall()
    {
        // Trouver une balle existante
        GameObject existingBall = GameObject.FindWithTag(referenceTag);

        if (existingBall != null && throwingBallPrefab != null)
        {
            // Position juste au-dessus
            Vector3 spawnPos = existingBall.transform.position + Vector3.up * verticalOffset;
            Instantiate(throwingBallPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Aucune balle trouv�e ou prefab manquant !");
        }
    }
}
