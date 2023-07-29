using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody RB;
    public CharacterController PC;
    public float Speed = 12f;
    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    Vector3 MoveDirection;

    //public Vector2 CamForward;

    // Start is called before the first frame update
    void Start()
    {
        PC = GetComponent<CharacterController>();
        RB = GetComponent<Rigidbody>();
        RB.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = transform.right * x + transform.forward * z;    
        PC.Move(moveDirection * Speed * Time.deltaTime);
    }

    //private void FixedUpdate()
    //{
    //    MovePlayer();
    //}
    //private void MovePlayer()
    //{
    //    MoveDirection = orientation.forward *  verticalInput + orientation.right * horizontalInput;
    //    RB.AddForce(MoveDirection.normalized * Speed * 10f, ForceMode.Force);
    //}

    //private void myInput()
    //{
    //    horizontalInput = Input.GetAxis("Horizontal");
    //    verticalInput = Input.GetAxisRaw("Vertical");
    //}








    void Movement()
    {
        //if (Cam != null) { CamForward = Vector3.Scale(Cam.forward, new Vector3(1, 0, 1)).normalized; }
        //if (CanMove)
        //{
        //    if (JoyDir.magnitude > 0) moveDir = JoyDir.y * CamForward + JoyDir.x * Cam.right;
        //    else if (moveDir.magnitude > 0) moveDir = Vector3.zero;

        //    if (moveDir.magnitude > 0)
        //    {
        //        agent.Move(moveDir * Time.deltaTime * Speed);
        //        // if (moveDir != Vector3.zero)
        //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir, transform.up), Time.deltaTime * Speed);
        //    }
        //}
        //Basic Movement
        //Vector3 Direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //PC.SimpleMove(Direction * Speed);
    }

    void Jump()
    {
        //GroundCheck
        //grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f +0.2f, whatIsGround)

        //if (Input.GetKeyDown("space") && PC.isGrounded = grounded)
        //{
        //    JblazeTK
        // }
    }
}
