using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayControl : MonoBehaviour
{
    float speed = 6.0f;
    private Rigidbody rb;
    public Vector3 vec;
    public Vector3 firstMouse;
    public float timehold = 0f;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButton(0) && Physics.Raycast(ray, out hit, 1000) && hit.collider.tag == "Ball")
        {
            timehold += Time.deltaTime;
        }
        if (Input.GetMouseButtonUp(0) && Physics.Raycast(ray, out hit, 1000) && hit.collider.tag == "Ball")
        {
            rb.AddForce(speed * vec * timehold, ForceMode.Impulse);
            firstMouse = hit.transform.position;


        }
    }
}
