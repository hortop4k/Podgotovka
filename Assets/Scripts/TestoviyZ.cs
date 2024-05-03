using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestoviyZ : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
       rb = GetComponent<Rigidbody>(); 
    }
    void FixedUpdate()
    {
        Vector3 swipeDirection = GetSwipeDirection();
        rb.velocity = swipeDirection * speed;
    }

    private Vector3 GetSwipeDirection()
    {
        Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        direction.z = direction.y;
        direction.y = 0;
        return direction;
    }
}
