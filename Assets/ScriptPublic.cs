using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class ScriptPublic : MonoBehaviour
{
    [SerializeField] private ScoreData scoreData;
    [SerializeField] private float liftHeight = 1f; // hauteur du saut
    [SerializeField] private float liftDuration = 1f; // durée du mouvement total

    private int lastScore;
    private bool isMoving = false;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        if (scoreData != null)
            lastScore = scoreData.score;
    }

    void Update()
    {
        if (scoreData == null) return;

        // Vérifie si le score a changé
        if (scoreData.score != lastScore)
        {
            lastScore = scoreData.score;
            if (!isMoving)
                StartCoroutine(LiftCube());
        }
    }

    private System.Collections.IEnumerator LiftCube()
    {
        isMoving = true;

        Vector3 startPos = initialPosition;
        Vector3 liftedPos = initialPosition + Vector3.up * liftHeight;

        float halfDuration = liftDuration / 2f;
        float elapsed = 0f;

        // Monte
        while (elapsed < halfDuration)
        {
            transform.position = Vector3.Lerp(startPos, liftedPos, elapsed / halfDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = liftedPos;

        // Redescend
        elapsed = 0f;
        while (elapsed < halfDuration)
        {
            transform.position = Vector3.Lerp(liftedPos, startPos, elapsed / halfDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = startPos;
        isMoving = false;
    }
}
