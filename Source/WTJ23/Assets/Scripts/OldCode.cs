using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    //Vector3 move = new Vector3(moveDirection.x, 0, 0);
	    //PC.Move(move * Time.deltaTime * Speed);


	    //if (grounded)
	    //{
	    //    velocity.y = 0;
	    //}
	    //else
	    //{
	    //    velocity.y += gravity * Time.deltaTime;
	    //}
	    //if (grounded && velocity.y < 0)
	    //{
	    //    velocity.y = -2f;
	    //}

	    //PC.Move(velocity * Time.deltaTime);

	    //if (grounded && jumping == false)
	    //{
	    //    velocity.y += gravity * Time.deltaTime;
	    //    jumping = false;
	    //}
	    //else if (!grounded && jumping)
	    //{
	    //    velocity.y = jumpHeight;
	    //}
	    //else
	    //{
	    //    velocity.y = 0;
	    //}
	    //PC.Move(velocity * Time.deltaTime);

	    //Groundcheck
	    //grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, IsGround);

	    ////Drag
	    //if(grounded)
	    //{
	    //    RB.drag = groundDrag;
	    //}
	    //else
	    //{
	    //    RB.drag = 0;
	    //}

  

	    //public void OnJump()
	    //{
	    //    RB.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
	    //}

	    //jumping = true;
	    // print("jump");
	    // if (grounded )
	    // {
	    //     velocity.y = jumpHeight;
	    // }  
	    // else
	    // {
	    // }
	    //// velocity.y += gravity ;
	    // print(velocity);
	    //private void SpeedControl()
	    //{
	    //    Vector3 flatVel = new Vector3(RB.velocity.x, 0f, RB.velocity.z);

	    //    //Limit velocity
	    //    if (flatVel.magnitude > Speed)
	    //    {
	    //        Vector3 limitedVel = flatVel.normalized * Speed;
	    //        RB.velocity = new Vector3(limitedVel.x, RB.velocity.y, limitedVel.z);
	    //    }
           
	    //}
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








	    //void Movement()
	    //{
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
	    //}

	    //void Jump()
	    //{
	    //    //GroundCheck
	    //    //grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f +0.2f, whatIsGround)

	    //    //if (Input.GetKeyDown("space") && PC.isGrounded = grounded)
	    //    //{
	    //    //    JblazeTK
	    //    // }
	    //}

	    //    using System.Collections;
	    //using System.Collections.Generic;
	    //using UnityEngine;

	    //public class player : MonoBehaviour
	    //{
	    //    PlayerControll playercontrol;
	    //    public int jumps;
	    //    public int jumpsleft;

	    //    private CharacterController controller;
	    //    public Vector3 playerVelocity;
	    //    private bool groundedPlayer;
	    //    public float playerSpeed = 2.0f;
	    //    public float jumpHeight = 1.0f;
	    //    private float gravityValue = -9.81f;

	    //    private void Awake()
	    //    {
	    //        playercontrol = new PlayerControll();
	    //        controller = GetComponent<CharacterController>();
	    //    }
	    //    private void Start()
	    //    {
	    //        // jumpsleft = jumps;
	    //    }
	    //    private void OnEnable()
	    //    {
	    //        playercontrol.Enable();
	    //    }
	    //    private void OnDisable()
	    //    {
	    //        playercontrol.Disable();
	    //    }
	    //    private void Update()
	    //    {

	    //        Vector2 direction = playercontrol.Player.Move.ReadValue<Vector2>(); Debug.Log(direction);

	    //        groundedPlayer = controller.isGrounded;
	    //        if (groundedPlayer && playerVelocity.y < 0)
	    //        {
	    //            playerVelocity.y = 0f;
	    //        }

	    //        Vector3 move = new Vector3(direction.x, 0, 0);
	    //        controller.Move(move * Time.deltaTime * playerSpeed);

	    //        if (move != Vector3.zero)
	    //        {
	    //            gameObject.transform.forward = move;
	    //        }

	    //        // Changes the height position of the player..
	    //        if (playercontrol.Player.Jump.triggered && groundedPlayer && jumpsleft > 0)
	    //        {
	    //            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
	    //            groundedPlayer = false;
	    //            jumpsleft = jumpsleft - 1;


	    //        }
	    //        else if (playercontrol.Player.Jump.triggered && jumpsleft > 0 && groundedPlayer == false)
	    //        {
	    //            playerVelocity.y += Mathf.Sqrt((Mathf.Abs(playerVelocity.y) + jumpHeight) * -3.0f * gravityValue);
	    //            groundedPlayer = false;
	    //            jumpsleft = jumpsleft - 1;
	    //        }


	    //        playerVelocity.y += gravityValue * Time.deltaTime;
	    //        controller.Move(playerVelocity * Time.deltaTime);


	    //    }

	    //    private void OnControllerColliderHit(ControllerColliderHit hit)
	    //    {
	    //        if (hit.gameObject.tag == "Floor")
	    //        {
	    //            groundedPlayer = true;
	    //            jumpsleft = jumps;
	    //        }
	    //    }
	    //}
	    //}

    }
}
