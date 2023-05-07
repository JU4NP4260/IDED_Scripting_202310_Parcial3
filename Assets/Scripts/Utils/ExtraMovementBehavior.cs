using UnityEngine;

public class ExtraMovementBehavior : MonoBehaviour
{
    public float range = 3f; // Rango en el eje X
    public float speed = 20f; // Velocidad de movimiento

    private void Update()
    {
        // Calcula la posición X dentro del rango utilizando Mathf.PingPong
        float newPositionX = Mathf.PingPong(Time.time * speed, range * 2f) - range;

        // Limita la posición X dentro del rango de -3 a 3
        newPositionX = Mathf.Clamp(newPositionX, -range, range);

        // Actualiza la posición del GameObject solo en el eje X
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
