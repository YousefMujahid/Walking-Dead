using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float sensX;
    [SerializeField] float sensY; 
    [SerializeField] Transform orientation;
    [SerializeField] int degree;
    private float xRotation;
    private float yRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX; 
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY; 

        yRotation += mouseX;
        xRotation -= mouseY; 
        xRotation = Math.Clamp(xRotation, -degree, degree); 

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); 
        orientation.rotation = Quaternion.Euler(0, yRotation, 0); 
        

    }
}
