using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class touchBall : MonoBehaviour
{
    // -----------
    Rigidbody body;
    Vector3 direction;

    //-------------swipe
    float speed = 10;
    public Vector3 firstMouse;
    public Vector3 lastMouse;
    public bool touch;

    GameObject ball;



    private void Start()
    {
       
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.collider.tag == "Ball")
            {
                firstMouse = Input.mousePosition;
                touch = true;
                ball = hit.collider.gameObject;    

               // Destroy(hit.collider.gameObject);
            }
        }
        if (Input.GetMouseButton(0) && touch)
        {
            lastMouse = Input.mousePosition;
            direction = lastMouse - firstMouse;
            direction.z = direction.magnitude;
            
            

        }
        if (Input.GetMouseButtonUp(0) && touch)
        {
            Rigidbody ballBody = ball.GetComponent<Rigidbody>();    
            
            ballBody.AddForce((direction.normalized) * speed, ForceMode.Impulse);
            touch = false;
        }
    }
}
