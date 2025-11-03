using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public float openAngle = 60f;       // angle d’ouverture
    public float openSpeed = 2f;        // vitesse de rotation
    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;
    [SerializeField] private GameObject WinP;
    [SerializeField] private Vector3 spawnPosition;

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles + Vector3.up * openAngle);
    }

    public void DoorOpen()
    {
        if (!isOpen)
            StartCoroutine(OpenDoor());
            Instantiate(WinP);
            GameObject particle = Instantiate(WinP,spawnPosition, Quaternion.identity);
    }

    private System.Collections.IEnumerator OpenDoor()
    {
        isOpen = true;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * openSpeed;
            transform.rotation = Quaternion.Slerp(closedRotation, openRotation, t);
            yield return null;
        }
    }
}