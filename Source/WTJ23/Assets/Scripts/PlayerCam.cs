using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float MouseSensitivityX = 100f;
    public float MouseSensitivityY = 100f;
    public Transform PlayerBody;
    public float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Turn off for editor cus it can get stuck?
        Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {
        //Mouse movement
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivityY * Time.deltaTime;

        //Clamping rotation to 90 degrees so he can't look behind himself
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f, 90f);

        //Rotate the player
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);

    }
}
