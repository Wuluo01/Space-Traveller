using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovPlayer : MonoBehaviour//para mover al jugador
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
       Quaternion rot = transform.rotation;  
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime; 
        rot = Quaternion.Euler(0, 0, z);    
        transform.rotation = rot;
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        pos += rot * velocity;      
        transform.position = pos;
    }
}
