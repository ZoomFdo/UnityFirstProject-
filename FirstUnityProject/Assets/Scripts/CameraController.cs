using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    
    float xRotation;
    public float mouseSensitivity = 10f;
    public Transform player;

    void Start()
    {
        Debug.Log("Hello Unity! It's me[CameraController]");
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = 0;// Now
        float mouseY = 0;

        if(Mouse.current != null) {
            mouseX = Mouse.current.delta.ReadValue().x;
            mouseY = Mouse.current.delta.ReadValue().y;
        }
        // if(Gamepad.current != null) {
        //     mouseX = Mouse.current.delta.ReadValue().x;
        //     mouseY = Mouse.current.delta.ReadValue().y;
        // }

        // mouseX = Input.GetAxis("Mouse X"); // Old
        // mouseY = Input.GetAxis("Mouse Y");

        mouseX *= mouseSensitivity;
        mouseY *= mouseSensitivity;

        xRotation -= mouseY * Time.deltaTime; // rotation camera
        xRotation = Mathf.Clamp(xRotation, -80, 80);// range camera
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        player.Rotate(Vector3.up * mouseX * Time.deltaTime);


    }
}
