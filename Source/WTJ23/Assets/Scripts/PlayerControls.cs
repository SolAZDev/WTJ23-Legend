using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
[RequireComponent(typeof(PlayerInput))]
public class PlayerControls : BaseActor
{
    Vector3 MoveDirection;
    Vector2 moveJoy, joyAim;
    bool grounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask GroundMask;
    bool isChupa=false, jumped=false, canCheckForGround=true;
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
            // ToggleNavMeshRigid
            StartCoroutine(Jump());
        }
    }
    
    private void OnCollisionEnter(Collision other) {
        print(other.transform.name);
        if(other.transform.tag=="Machete") RecieveDamage(8);
        if (GroundCheck() && canCheckForGround) StartCoroutine(ResetJump());
    }
    bool GroundCheck()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, GroundMask);
    }


    IEnumerator Jump(){
        canCheckForGround = false;
        navMeshAgent.updatePosition = false;
        navMeshAgent.updateRotation = false;
        RB.isKinematic = false;
        RB.AddForce((Vector3.up+(isChupa?transform.forward:Vector3.zero)) * 10, ForceMode.Impulse);
        animator.SetTrigger("Jump");
        jumped=true;
        yield return new WaitForSeconds(.25f);
        canCheckForGround = true;
    }

    IEnumerator ResetJump(){
        yield return new WaitForSeconds(0.1f);
        navMeshAgent.Warp(transform.position);
        navMeshAgent.updatePosition = true;
        navMeshAgent.updateRotation = true;
        RB.isKinematic = true;
        // ToggleNavMeshRigid();
        jumped = false;
    }

}
