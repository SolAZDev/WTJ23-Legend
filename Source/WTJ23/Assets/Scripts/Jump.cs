using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask GroundMask;
    public float jumpHeight = 3f;
    bool grounded;
    public Rigidbody RB;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ground Check
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, GroundMask);
    }
    public void OnJump()
    {
        RB.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
    }
}
