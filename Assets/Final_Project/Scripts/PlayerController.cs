using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public GameObject ball;
    public Transform pos;
    GameObject shot;
    public float force = 650f;
    public float speed = 5f;
    public float accel_decel = 1f;

	void Update()
    {
        // check to make sure the player is local
        if (!isLocalPlayer)
        {
            return;
        }

        float horiz = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float vert = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(new Vector3(horiz, vert, 0f));

        if ((Camera.main.transform.localEulerAngles.y > 15f && Camera.main.transform.localEulerAngles.y <= 40f))
        {
            force = 675f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 320f && Camera.main.transform.localEulerAngles.y <= 345f))
        {
            force = 675f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 300f && Camera.main.transform.localEulerAngles.y <= 320f))
        {
            force = 770f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 40f && Camera.main.transform.localEulerAngles.y <= 60f))
        {
            force = 770f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 60f && Camera.main.transform.localEulerAngles.y <= 75f))
        {
            force = 810f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 75f && Camera.main.transform.localEulerAngles.y <= 115f))
        {
            force = 790f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 115f && Camera.main.transform.localEulerAngles.y <= 130f))
        {
            force = 730f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 130f && Camera.main.transform.localEulerAngles.y <= 160f))
        {
            force = 610f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 200f && Camera.main.transform.localEulerAngles.y <= 230f))
        {
            force = 610f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 160f && Camera.main.transform.localEulerAngles.y <= 200f))
        {
            force = 570f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 230f && Camera.main.transform.localEulerAngles.y <= 245f))
        {
            force = 730f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 245f && Camera.main.transform.localEulerAngles.y <= 265f))
        {
            force = 790f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 265f && Camera.main.transform.localEulerAngles.y <= 285f))
        {
            force = 790f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 285f && Camera.main.transform.localEulerAngles.y <= 300f))
        {
            force = 810f;
        }
        else
        {
            force = 650f;
        }
        print(force);

        // position the camera just above the first person player
        Camera.main.transform.parent.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
        // allow the player to rotate left and right based on head movement
        transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
        transform.GetChild(1).position = new Vector3(transform.GetChild(1).position.x, -Camera.main.transform.rotation.x*1.2f+1, transform.GetChild(1).position.z);
        transform.GetChild(2).position = new Vector3(transform.GetChild(2).position.x, -Camera.main.transform.rotation.x*1.2f+1, transform.GetChild(2).position.z);
        // have the player moving forward at a constant slow speed so all they have to worry about is shooting
        //transform.position += transform.forward * 2f * Time.deltaTime;

        // fire the bullet when the trigger is pressed
        if (Input.GetMouseButtonDown(0))
        {
            CmdFire();
        }
    }

    // This [Command] code is called on the Client …
    // … but it is run on the Server!
    [Command]
    void CmdFire()
    {
        // instantitate the ball and shoot it from the camera
        shot = Instantiate(ball, pos.position, pos.rotation);
        //shot.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        // make it act as a rigidbody
        Rigidbody body = shot.GetComponent<Rigidbody>();
        // shoot it with the given direction, force, and speed
        body.AddForce((transform.forward + transform.up) / 2f * force * accel_decel);
        Destroy(shot, 4f);
    }

    public override void OnStartLocalPlayer()
    {
        // position the camera just above the first person player
        Camera.main.transform.parent.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
        // allow the player to rotate left and right based on head movement
        transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
        // make the local player blue
        GetComponent<Renderer>().material.color = Color.blue;
    }
}