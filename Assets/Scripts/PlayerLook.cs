using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    Camera cam;

    float mouseX;
    float mouseY;

    float multiplier = 0.01f;

    float xRotation;
    float yRotation;

    private void Start()
    {
        // get component in child *obvious
        cam = GetComponentInChildren<Camera>();

        // lock cursor and make invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // read first
        MyInput();

        // local rotation as camera is a child of player and we only want to look up and down with the camera so pass in xRotation
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        // only want to look left and right so pass in yRotation
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void MyInput()
    {
        // get mouse input (already framrate independent)
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        // multiplier to reduce sensitivity
        yRotation += mouseX * sensX * multiplier;       //  add to yRotation as we want to rotate on the Y axis to look horizontally
        xRotation -= mouseY * sensY * multiplier;       //  subtracting, otherwise it is inverted

        // clamping rotation 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }
}
