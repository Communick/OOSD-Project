using UnityEngine;

public class OscillateRotation : MonoBehaviour
{
    public float angleAmplitude = 5f;  // Amplitude en degrés
    public float speed = 1f;            // Vitesse de l'oscillation

    private float initialAngleZ;

    void Start()
    {
        // Conserver l'angle Z initial pour référence
        initialAngleZ = transform.localEulerAngles.z;
    }

    void Update()
    {
        // Calculer l'angle oscillant avec fonction sinus
        float angleZ = initialAngleZ + angleAmplitude * Mathf.Sin(Time.time * speed * 2f * Mathf.PI);

        // Appliquer la rotation uniquement sur Z
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, angleZ);
    }
}
