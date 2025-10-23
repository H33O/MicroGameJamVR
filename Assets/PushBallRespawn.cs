using UnityEngine;

public class SpawnPushBall : MonoBehaviour
{
    [SerializeField] private GameObject pushBallPrefab;  // Nouveau prefab pour la PushBall
    [SerializeField] private string referenceTag = "pushball";  // Tag de la PushBall
    [SerializeField] private float verticalOffset = 1f;

    // Appelé quand le bouton est pressé
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
            Debug.LogWarning("Aucune PushBall trouvée ou prefab manquant !");
        }
    }
}
