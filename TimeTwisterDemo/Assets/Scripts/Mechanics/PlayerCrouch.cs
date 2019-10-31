using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    public CharacterController controller;

    private bool isCrouching = false;

    private float originalHeight;

    private float crouchHeight;

    private void Start()
    {
        originalHeight = controller.height;
        crouchHeight = originalHeight / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            isCrouching = !isCrouching;

            CheckCrouching();
        }
    }

    private void CheckCrouching()
    {
        if (isCrouching == true)
        {
            controller.height = crouchHeight;
        } 
        else
        {
            controller.height = originalHeight;
        }
    }
}
