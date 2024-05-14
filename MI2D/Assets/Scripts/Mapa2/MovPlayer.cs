using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float rotSpeed = 180f;

    private Rigidbody2D rb;
    public float drag;
 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = drag;
    }

    void Update()
    {

        // ROTATE the ship.

        // Grab our rotation quaternion
        Quaternion rot = transform.rotation;

        // Grab the Z euler angle
        float z = rot.eulerAngles.z;

        // Change the Z angle based on input
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

        // Recreate the quaternion
        rot = Quaternion.Euler(0, 0, z);

        // Feed the quaternion into our rotation
        transform.rotation = rot;

        // MOVE the ship.
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);

        pos += rot * velocity;

        // Finally, update our position!!
        transform.position = pos;
    }
}
