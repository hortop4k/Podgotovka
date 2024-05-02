using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Swipes : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 direction;
    private bool directionChosen;
    //private bool isMoving;
    private Rigidbody rb;

    private void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 20))
        {
            if (hit.collider.tag == "Ball")
            {
                startPos = Input.mousePosition;
                directionChosen = false;
            }
            
        }
        else if (Input.GetMouseButton(0) && !directionChosen)
        {
            Vector3 currentPos = Input.mousePosition;
            direction = currentPos - startPos;
            direction.z = direction.magnitude;
        }
        else if (Input.GetMouseButtonUp(0) && !directionChosen)
        {
            float forceMagnitude = Mathf.Clamp(direction.magnitude, 0.0f, 15.0f);
            rb.AddForce(Camera.main.transform.TransformDirection(direction.normalized) * forceMagnitude, ForceMode.Impulse);
            
        }

    }
   
    

}
