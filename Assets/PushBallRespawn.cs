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
        // R�cup�re la position de la premi�re PushBall trouv�e une seule fois au d�marrage
        GameObject existingBall = GameObject.FindWithTag(referenceTag);
        if (existingBall != null)
        {
            initialBallPosition = existingBall.transform.position;
            initialPositionCaptured = true;
        }
        else
        {
            Debug.LogWarning("Aucune PushBall trouv�e au d�marrage. Le spawn utilisera la position de ce GameObject si n�cessaire.");
        }
    }

    // Appel� quand le bouton est press�
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
            Debug.LogWarning("Position initiale non captur�e et aucune PushBall trouv�e. Spawn effectu� au-dessus de l'objet courant.");
        }
    }
}
