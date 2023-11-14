using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform; // La r�f�rence au Transform du joueur.
    private Vector3 offset; // La distance relative entre le joueur et la cam�ra.
    public float followSpeed = 10f; // La vitesse � laquelle la cam�ra rattrapera le joueur.

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