﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* BASIC MOVEMENT SCRIPT ORIGINALLY FROM UNITY DOCUMENTATION */

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    public Animator anim;

    public float moveSpeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            anim.SetFloat("Vertical", 0);
            // We are grounded, so recalculate
            // move direction directly from axes         
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            moveDirection *= moveSpeed;
            anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                anim.SetFloat("Vertical", 1);
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }

}
