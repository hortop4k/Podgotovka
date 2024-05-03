using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    
    public enum RotationAxes
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
        
    }
    public RotationAxes axes = RotationAxes.MouseXandY;
    public float SensevityHor = 9.0f;
    public float SensevityVert = 9.0f;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;
    private float verticalRot = 0;



    void Start()
    {
        
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null )
        {
            rb.freezeRotation = true;
        }
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            SensevityHor = 0;
            SensevityVert = 0;
            Cursor.visible = true;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            SensevityHor = 9.0f;
            SensevityVert = 9.0f;
            Cursor.visible = false;
        }
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
            float horizontalRot = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
        //Комбинированный
        else
        {
            verticalRot -= Input.GetAxis("Mouse Y") * SensevityVert;
            verticalRot = Mathf.Clamp(verticalRot,minimumVert, maximumVert);
            float delta = Input.GetAxis("Mouse X") * SensevityHor;
            float horizontalRot = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
    }
}
