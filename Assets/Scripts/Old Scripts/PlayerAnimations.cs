using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class PlayerAnimations : MonoBehaviour {

    Animator anim;
    bool isWalking = false;
    const float WALK_SPEED = .25f;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Walking();
        Turning();
        Move();       
    }

    void Turning()
    {
        //anim.SetFloat("Turn", Input.GetAxis("Horizontal"));
    }

    void Walking()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            isWalking = !isWalking;
            anim.SetBool("Walk", isWalking);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isWalking = false;
            anim.SetBool("Walk", isWalking);
        }
    }

    void Move()
    {

        /* Walk Toggle - we will need to change this to account for the lerping
         * keep a toggle in Mecanism as well.
         */

         
        if (anim.GetBool("Walk"))
        {
            anim.SetFloat("MoveZ", Mathf.Clamp(Input.GetAxis("MoveZ"), -WALK_SPEED, WALK_SPEED));
            anim.SetFloat("MoveX", Mathf.Clamp(Input.GetAxis("MoveX"), -WALK_SPEED, WALK_SPEED));            

        }
        else
        {
            anim.SetFloat("MoveZ", Input.GetAxis("MoveZ"));
            anim.SetFloat("MoveX", Input.GetAxis("MoveX"));
        }
        
    }
}
