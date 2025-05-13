using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRButtonFeedback : MonoBehaviour
{
    public float moveDistance = 0.005f;
    public float speed = 10f;

    [Tooltip("Direcci�n local en la que se mover� el bot�n al presionarlo")]
    public Vector3 localDirection = new Vector3(0, -1, 1); // Y- (abajo) + Z+ (adelante)

    private Vector3 startPosition;
    private Vector3 pressedPosition;

    void Start()
    {
        startPosition = transform.localPosition;

        // Direcci�n convertida al espacio local normalizado
        Vector3 movement = localDirection.normalized * moveDistance;
        pressedPosition = startPosition + movement;
    }

    public void ShowFeedback()
    {
        StopAllCoroutines();
        StartCoroutine(ButtonAnimation());
    }

    private System.Collections.IEnumerator ButtonAnimation()
    {
        float t = 0;

        // Ir hacia la posici�n presionada
        while (t < 1)
        {
            t += Time.deltaTime * speed;
            transform.localPosition = Vector3.Lerp(startPosition, pressedPosition, t);
            yield return null;
        }

        t = 0;

        // Volver a la posici�n inicial
        while (t < 1)
        {
            t += Time.deltaTime * speed;
            transform.localPosition = Vector3.Lerp(pressedPosition, startPosition, t);
            yield return null;
        }
    }
}
