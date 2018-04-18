using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
    public float jumpSpeed = 8f;
    public float gravity = 20f;
    public float runSpeed = 50f;
    public float walkSpeed = 15f;
    public float rotateSpeed = 150f;
 
    private bool grounded = false;
    private Vector3 moveDirection = Vector3.zero;
    private bool isWalking = false;
    //private string moveStatus = "idle";
    //private bool jumping = false;
    //private float moveSpeed = 0f;
 
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("MoveX"), 0, Input.GetAxis("MoveZ"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= isWalking ? walkSpeed : runSpeed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
            
        

        // Allow turning at anytime. Keep the character facing in the same direction as the Camera if the right mouse button is down.
        if (Input.GetMouseButton(1))
        {
            transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        }
        else
        {
            //transform.Rotate(0, Input.GetAxis("MoveX") * rotateSpeed * Time.deltaTime, 0);
        }

        if (Input.GetMouseButton(1) || Input.GetMouseButton(0))
            Cursor.lockState = (CursorLockMode.Locked);
        else
            Cursor.lockState = (CursorLockMode.None);

        // Toggle walking/running with the shift key
        if (Input.GetAxis("Run") == 1)
            isWalking = !isWalking;
        
    }
}
