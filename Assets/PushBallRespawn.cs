using UnityEngine;

public class SpawnPushBall : MonoBehaviour
{
    [SerializeField] private GameObject pushBallPrefab;  // Prefab pour la PushBall
    [SerializeField] private Transform spawnSource;      // Optionnel : le bouton (ou autre) au-dessus duquel spawner
    [SerializeField] private float verticalOffset = 1f;

    // Appelé quand le bouton est pressé
    public void SpawnBall()
    {
        if (pushBallPrefab == null)
        {
            Debug.LogWarning("Prefab manquant !");
            return;
        }

        // Si aucun spawnSource n'est assigné, on utilise l'objet courant (le bouton)
        Transform source = spawnSource != null ? spawnSource : transform;
        Vector3 spawnPos = source.position + Vector3.up * verticalOffset;
        Instantiate(pushBallPrefab, spawnPos, Quaternion.identity);
    }
}
