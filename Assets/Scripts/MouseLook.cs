using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseX = 1,
        MouseY = 2,
        MouseXandY = 0
    }
    public RotationAxes axes = RotationAxes.MouseXandY;
    public float SensevityHor = 9.0f;
    public float SensevityVert = -9.0f;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;
    private float verticalRot = 0;



    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //Горизонтальный
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * SensevityHor, 0);
        }
        //Вертикальный
        else if (axes == RotationAxes.MouseY)
        {
            verticalRot -= Input.GetAxis("Mouse Y") * SensevityVert;
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

        }
    }
}
