using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform; // La référence au Transform du joueur.
    private Vector3 offset; // La distance relative entre le joueur et la caméra.
    public float followSpeed = 10f; // La vitesse à laquelle la caméra rattrapera le joueur.

    private void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    private void Update()
    {
        Vector3 newPosition = playerTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position, newPosition, followSpeed * Time.deltaTime);
    }
}