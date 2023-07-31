using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerInput))]
public class PlayerControls : BaseActor
{
    Vector3 MoveDirection;
    Vector2 moveJoy, joyAim;
    bool grounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask GroundMask;
    bool isChupa=false, jumped=false;
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
        // MoveDirection = transform.right * moveJoy.x + transform.forward * moveJoy.y;
        MoveDirection = moveJoy.y * Vector3.Scale(Camera.main.transform.forward, new Vector3(1,0,1)).normalized + moveJoy.x * Camera.main.transform.right;
        base.animator.SetFloat("Moving",moveJoy.magnitude);
        if (moveJoy.magnitude > 0.1f)
        {
            float FinalizedSpeed = Mathf.Lerp(Speed, RunSpeed, moveJoy.magnitude);
            transform.position = Vector3.MoveTowards(transform.position, transform.position + MoveDirection, Time.deltaTime * FinalizedSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(MoveDirection, transform.up), Time.deltaTime * FinalizedSpeed);
        }
    }

    public void OnMove(InputValue val)
    {
        moveJoy = val.Get<Vector2>();
    }

    public void OnJump()
    {
            print("Jump ngh1");
        if (GroundCheck())
        {
            print("Jump ngh");
            // ToggleNavMeshRigid();
            RB.AddForce((Vector3.up+(isChupa?transform.forward:Vector3.zero)) * 10, ForceMode.VelocityChange);
            animator.SetTrigger("Jump");
            // jumped=true;
        }
    }
    
    private void OnCollisionEnter(Collision other) {
        if(other.transform.tag=="Machete") RecieveDamage(8);
        // if (GroundCheck() && jumped)
        // {
            // ToggleNavMeshRigid();
            // jumped = false;
        // }
    }
    bool GroundCheck()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, GroundMask);
    }

}
