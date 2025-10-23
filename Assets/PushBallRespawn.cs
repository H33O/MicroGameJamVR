using UnityEngine;

public class SpawnPushBall : MonoBehaviour
{
    [SerializeField] private GameObject pushBallPrefab;  // Nouveau prefab pour la PushBall
    [SerializeField] private string referenceTag = "pushball";  // Tag de la PushBall
    [SerializeField] private float verticalOffset = 1f;

    // Appel� quand le bouton est press�
    public void SpawnBall()
    {
        // Trouver une PushBall existante
        GameObject existingBall = GameObject.FindWithTag(referenceTag);

        if (existingBall != null && pushBallPrefab != null)
        {
            // Position juste au-dessus de la PushBall existante
            Vector3 spawnPos = existingBall.transform.position + Vector3.up * verticalOffset;
            Instantiate(pushBallPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Aucune PushBall trouv�e ou prefab manquant !");
        }
    }
}
