using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour 
{
    // declare a variables to be used below
    public GameObject ball;
    public Transform pos;
    GameObject shot;
    public float force = 650f;
    public float speed = 5f;
    public float accel_decel = 1f;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float vert = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(new Vector3(horiz, vert, 0f));

        if ((Camera.main.transform.localEulerAngles.y > 40f && Camera.main.transform.localEulerAngles.y <= 60f))
        {
            force = 770f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 120f && Camera.main.transform.localEulerAngles.y <= 140f))
        {
            force = 770f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 220f && Camera.main.transform.localEulerAngles.y <= 240f))
        {
            force = 770f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 300f && Camera.main.transform.localEulerAngles.y <= 320f))
        {
            force = 770f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 60f && Camera.main.transform.localEulerAngles.y < 120f))
        {
            force = 825f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 240f && Camera.main.transform.localEulerAngles.y < 300f))
        {
            force = 825f;
        }
        else
        {
            force = 650f;
        }

        // check for a click to shoot by the user
        if (Input.GetMouseButtonDown(0))
        {
            // instantitate the ball and shoot it from the camera
            shot = Instantiate(ball);
            shot.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            // make it act as a rigidbody
            Rigidbody body = shot.GetComponent<Rigidbody>();
            // shoot it with the given direction, force, and speed
            body.AddForce((Camera.main.transform.forward + Camera.main.transform.up)/2f * force * accel_decel);
            Destroy(shot, 4f);
        }
    }
}
