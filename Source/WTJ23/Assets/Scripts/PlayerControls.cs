using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerInput))]
public class PlayerControls : BaseActor
{
    public Rigidbody RB;
    Vector3 MoveDirection;
    Vector2 moveJoy, joyAim;
    bool grounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask GroundMask;

    bool isChupa=false;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        RB = GetComponent<Rigidbody>();
        isChupa=gameObject.tag=="Chupa";
    }

    // Update is called once per frame
    void Update()
    {
        //Get movement values
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        MoveDirection = transform.right * moveJoy.x + transform.forward * moveJoy.y;
        base.animator.SetFloat("Moving",moveJoy.magnitude);
        if (moveJoy.magnitude > 0.1f)
        {
            float FinalizedSpeed = Mathf.Lerp(Speed, RunSpeed, moveJoy.magnitude);
            transform.position = Vector3.MoveTowards(transform.position, transform.position + MoveDirection, Time.deltaTime * FinalizedSpeed);
        }
    }

    public void OnMove(InputValue val)
    {
        moveJoy = val.Get<Vector2>();
    }

    public void OnJump()
    {
        if (GroundCheck())
        {
            RB.AddForce((Vector3.up+(isChupa?transform.forward:Vector3.zero)) * 10, ForceMode.VelocityChange);
        }
    }
    bool GroundCheck()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, GroundMask);
    }
}
