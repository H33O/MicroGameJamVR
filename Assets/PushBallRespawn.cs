using UnityEngine;

public class SpawnPushBall : MonoBehaviour
{
    [SerializeField] private GameObject pushBallPrefab;  // Prefab pour la PushBall
    [SerializeField] private Transform spawnSource;      // Optionnel : le bouton (ou autre) au-dessus duquel spawner
    [SerializeField] private float verticalOffset = 1f;

    // Appel� quand le bouton est press�
    public void SpawnBall()
    {
        if (pushBallPrefab == null)
        {
            Debug.LogWarning("Prefab manquant !");
            return;
        }

        // Si aucun spawnSource n'est assign�, on utilise l'objet courant (le bouton)
        Transform source = spawnSource != null ? spawnSource : transform;
        Vector3 spawnPos = source.position + Vector3.up * verticalOffset;
        Instantiate(pushBallPrefab, spawnPos, Quaternion.identity);
    }
}
