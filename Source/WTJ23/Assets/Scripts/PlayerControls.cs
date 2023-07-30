using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControls : MonoBehaviour
{
    public Rigidbody RB;
    Vector3 MoveDirection;
    public float Speed = 12f;
    Vector2 moveJoy, joyAim;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get movement values
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        MoveDirection = transform.right * moveJoy.x + transform.forward * moveJoy.y;
        if (moveJoy.magnitude > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + MoveDirection, Time.deltaTime * Speed);
        }
    }

    public void OnMove(InputValue val)
    {
        moveJoy = val.Get<Vector2>();
    }

    public void OnJump()
    {
        RB.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
    }
}