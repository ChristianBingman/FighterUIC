using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 6.0f;
    private Rigidbody rigidbody;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get horizontal input
        float horizontal = Input.GetAxis("Horizontal");

        // Get vertical input
        float vertical = Input.GetAxis("Vertical");

        // Create a new vector using horizontal and vertical movement
        moveDirection = new Vector3(horizontal, vertical);

        // Apply movement speed to the rigidbody
        rigidbody.AddForce(moveDirection * moveSpeed);

    }

}
