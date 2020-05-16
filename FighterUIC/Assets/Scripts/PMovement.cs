using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour
{
    public Animator anim;
    CharacterController characterController;
    public float height = 2.0f;

    // Called upon initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        if (Input.GetButton("Jump"))
        {
            anim.SetFloat("Vertical", height);
        }     

    }


    // Updates at a fixed interval independent of frames
    void FixedUpdate()
    {
        if (characterController.isGrounded)
        {
            anim.SetFloat("Vertical", 0.0f);
        }
    }

}


