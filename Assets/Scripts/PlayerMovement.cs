﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public float jumpSpeed = 10.0f;
    public float gravity = 55.0f;
    public float walkSpeed = 90.0f;
    public float runSpeed = 70.0f;
    public float rotateSpeed = 150.0f;

    public bool grounded;
    private Vector3 moveDirection = Vector3.zero;
    private bool isWalking;
    private string moveStatus = "idle";

    public GameObject camera1;
    private CharacterController controller;
    public bool isJumping;
    private float myAng = 0.0f;
    public bool canJump = true;

    void Start()
    {

        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //force controller down slope. Disable jumping
        if (myAng > 50)        
            canJump = false;        
        else        
            canJump = true;
        

        if (grounded)
        {

            isJumping = false;

            if (camera1.transform.gameObject.transform.GetComponent<PlayerCamera>().inFirstPerson == true)
            {
                moveDirection = new Vector3((Input.GetMouseButton(0) ? Input.GetAxis("MoveX") : 0), 0, Input.GetAxis("MoveZ"));
            }
            moveDirection = new Vector3((Input.GetMouseButton(1) ? Input.GetAxis("MoveX") : 0), 0, Input.GetAxis("MoveZ"));

            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= isWalking ? walkSpeed : runSpeed;

            moveStatus = "idle";



            if (moveDirection != Vector3.zero)
                moveStatus = isWalking ? "walking" : "running";

            if (Input.GetKeyDown(KeyCode.Space) && canJump)
            {
                moveDirection.y = jumpSpeed;
                isJumping = true;
            }

        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isWalking = false;
            jumpSpeed = 15f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isWalking = true;
            jumpSpeed = 10f;
        }


        // Allow turning at anytime. Keep the character facing in the same direction as the Camera if the right mouse button is down.

        if (camera1.transform.gameObject.transform.GetComponent<PlayerCamera>().inFirstPerson == false)
        {
            if (Input.GetMouseButton(1))
            {
                transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
            }
            else
            {
                transform.Rotate(0, Input.GetAxis("MoveX") * rotateSpeed * Time.deltaTime, 0);

            }
        }
        else
        {
            if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
            {
                transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
            }

        }

        //Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;


        //Move controller
        CollisionFlags flags;
        if (isJumping)
        {
            flags = controller.Move(moveDirection * Time.deltaTime);
        }
        else
        {
            flags = controller.Move((moveDirection + new Vector3(0, -100, 0)) * Time.deltaTime);
        }

        grounded = (flags & CollisionFlags.Below) != 0;

        if (Input.GetMouseButton(1) || Input.GetMouseButton(0))
            Cursor.lockState = (CursorLockMode.Locked);
        else
            Cursor.lockState = (CursorLockMode.None);

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        myAng = Vector3.Angle(Vector3.up, hit.normal);
    }
}
