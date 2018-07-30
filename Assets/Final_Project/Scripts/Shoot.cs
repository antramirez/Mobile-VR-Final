using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour 
{
    // declare a variables to be used below
    public GameObject ball;
    public Transform pos;
    GameObject shot;
    public float force = 850f;
    public float speed = 5f;
    public float accel_decel = 1f;

    // Use this for initialization
    void Start()
    {
        // load the Ball prefab that will be instantiated below
        //projectile = Resources.Load("Knicks Bball") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float vert = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(new Vector3(horiz, vert, 0f));

        // check for a click to shoot by the user
        if (Input.GetMouseButtonDown(0))
        {
            // instantitate the ball and shoot it from the camera
            shot = Instantiate(ball);
            shot.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
            // make it act as a rigidbody
            Rigidbody body = shot.GetComponent<Rigidbody>();
            // shoot it with the given direction, force, and speed
            body.AddForce(transform.forward * force * accel_decel);
            Destroy(shot, 2.5f);
        }
    }
}
