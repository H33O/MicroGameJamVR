using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(Rigidbody), typeof(XRGrabInteractable))]
public class ThrowOnRelease : MonoBehaviour
{
    public float throwForce = 5f; // Ajuste la puissance du lancer

    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        // On s’abonne à l’événement "relâché"
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        // Récupère la direction de la main / contrôleur
        Transform handTransform = args.interactorObject.transform;
        Vector3 forward = handTransform.forward;

        // Applique une force en avant quand l’objet est lâché
        rb.isKinematic = false;
        rb.AddForce(forward * throwForce, ForceMode.VelocityChange);
    }
}
