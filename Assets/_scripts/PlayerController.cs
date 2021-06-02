using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed = 15;
    public float tilt = 10;

    public Boundary boundary;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            rb.position.y,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );

        rb.rotation = Quaternion.Euler(-0.5f * tilt * rb.velocity.z, 0, -tilt * rb.velocity.x);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
