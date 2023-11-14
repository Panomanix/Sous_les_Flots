using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsJoueur : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Transform cameraTransform; // Référence à la caméra
    public float turnSpeed = 5.0f;    // Vitesse de rotation du joueur

    private Vector3 direction;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleInput();
        Move();
        RotatePlayer();
    }

    void HandleInput()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(moveX, 0f, moveZ).normalized;

        if (moveDir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float moveDirMagnitude = moveDir.magnitude;
            moveDir.x = Mathf.Sin(targetAngle * Mathf.Deg2Rad);
            moveDir.z = Mathf.Cos(targetAngle * Mathf.Deg2Rad);
            moveDir *= moveDirMagnitude;
        }

        direction = moveDir;
    }

    void Move()
    {
        Vector3 moveDirection = new Vector3(direction.x, 0, direction.z) * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + moveDirection;
        rb.MovePosition(newPosition);
    }

    void RotatePlayer()
    {
        if (direction.magnitude >= 0.1f)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
        }
    }
}
