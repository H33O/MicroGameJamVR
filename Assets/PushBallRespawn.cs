using UnityEngine;

public class SpawnPushBall : MonoBehaviour
{
    [SerializeField] private GameObject pushBallPrefab;  // Nouveau prefab pour la PushBall
    [SerializeField] private string referenceTag = "pushball";  // Tag de la PushBall
    [SerializeField] private float verticalOffset = 1f;

    private Vector3 initialBallPosition;
    private bool initialPositionCaptured = false;

    private void Start()
    {
        // Récupère la position de la première PushBall trouvée une seule fois au démarrage
        GameObject existingBall = GameObject.FindWithTag(referenceTag);
        if (existingBall != null)
        {
            initialBallPosition = existingBall.transform.position;
            initialPositionCaptured = true;
        }
        else
        {
            Debug.LogWarning("Aucune PushBall trouvée au démarrage. Le spawn utilisera la position de ce GameObject si nécessaire.");
        }
    }

    // Appelé quand le bouton est pressé
    public void SpawnBall()
    {
        if (pushBallPrefab == null)
        {
            Debug.LogWarning("Prefab manquant !");
            return;
        }

        if (initialPositionCaptured)
        {
            Vector3 spawnPos = initialBallPosition + Vector3.up * verticalOffset;
            Instantiate(pushBallPrefab, spawnPos, Quaternion.identity);
            return;
        }

        else
        {
            // Dernier recours : spawner au-dessus de ce GameObject
            Vector3 spawnPos = transform.position + Vector3.up * verticalOffset;
            Instantiate(pushBallPrefab, spawnPos, Quaternion.identity);
            Debug.LogWarning("Position initiale non capturée et aucune PushBall trouvée. Spawn effectué au-dessus de l'objet courant.");
        }
    }
}
