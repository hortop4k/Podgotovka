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
    float speed = 10.0f;
    public Vector3 firstMouse;
    public Vector3 lastMouse;
    public bool touch;

    GameObject ball;
    Vector3 Pos;

    Vector3 playerScale;

    private void Start()
    {
       
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        playerScale = transform.localEulerAngles;
        float y = playerScale.y;
        Debug.Log(y);

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
            //Debug.Log(lastMouse.x + " " + lastMouse.y);
            
            direction.z = Mathf.Sqrt(direction.y * direction.y);
            
           
            
            if (y > -90 && y < 49)
            {
                Pos = new Vector3(direction.x, direction.y, direction.z);
            }
            if (y > 90 || y < -90)
            {
                Pos = new Vector3(-direction.x, direction.y, -direction.z);
            }
            if (y > 50 && y < 130)
            {
                if (direction.x < 0)
                {
                    direction.z = -direction.x;
                }
                if ( direction.x > 0)
                {
                    direction.z = -direction.x;
                }
               
                direction.x = Mathf.Sqrt(direction.x * direction.x);
                
                Pos = new Vector3(direction.x, direction.y, direction.z);
            }
            Debug.Log(Pos.x + ", " + Pos.y + "," + Pos.z);
            




        }
        if (Input.GetMouseButtonUp(0) && touch)
        {
            Rigidbody ballBody = ball.GetComponent<Rigidbody>();    
            
            ballBody.AddForce((Pos.normalized) * speed, ForceMode.Impulse);
            touch = false;
        }
    }
}
