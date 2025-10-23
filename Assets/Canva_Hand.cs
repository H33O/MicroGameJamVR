
using UnityEngine;

public class CanvasFollowHand : MonoBehaviour
{
    [Header("Références")]
    public Transform UniversalController; // Assigné dans l'inspecteur (ta main gauche du XR Rig)
    public Vector3 positionOffset = new Vector3(0.2f, 0f, 0f); // Décalage sur X
    public Vector3 rotationOffset = Vector3.zero; // Si tu veux tourner un peu le canvas

    void Update()
    {
        if (UniversalController == null) return;

        // Calcul de la position avec décalage relatif à la main
        Vector3 targetPosition = UniversalController.position + UniversalController.TransformDirection(positionOffset);

        // Appliquer position et rotation
        transform.position = targetPosition;
        transform.rotation = UniversalController.rotation * Quaternion.Euler(rotationOffset);
    }
}