using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController PC;
    public float Speed = 12f;
    float horizontalInput;
    float verticalInput;
    public float playerHeight;
    Vector3 MoveDirection;

    //public Vector2 CamForward;

    // Start is called before the first frame update
    void Start()
    {
        PC = GetComponent<CharacterController>();
        // RB = GetComponent<Rigidbody>();
        // RB.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Get movement values
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        //Moving values
        Vector3 moveDirection = transform.right * x + transform.forward * z;
        PC.Move(moveDirection * Speed * Time.deltaTime);

    }
}
        