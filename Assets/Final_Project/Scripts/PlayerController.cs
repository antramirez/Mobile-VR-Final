using UnityEngine;
using UnityEngine.Networking;


public class PlayerController : NetworkBehaviour
{
    public GameObject ball;
    public Transform pos;
    GameObject shot;
    public float force = 570f;
    public float speed = 5f;
    public float accel_decel = 1f;

    public int score = 0;
    private ShotMade snScript;


    private CustomNetworkDiscovery netScript;
    public GameObject networkGameObj;
    public float playerNumber;

	private void Start()
	{
        snScript = ball.GetComponent<ShotMade>();
        score = snScript.count;

        netScript = networkGameObj.GetComponent<CustomNetworkDiscovery>();

	}
	void Update()
    {

        if (netScript.PlayerNumIsSet())
        {
            playerNumber = netScript.GetPLayerNumber();
            print(playerNumber);
        }
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
            force = 610f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 40f && Camera.main.transform.localEulerAngles.y <= 60f))
        {
            force = 720f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 60f && Camera.main.transform.localEulerAngles.y <= 75f))
        {
            force = 790f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 75f && Camera.main.transform.localEulerAngles.y <= 110f))
        {
            force = 790f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 110f && Camera.main.transform.localEulerAngles.y <= 125f))
        {
            force = 810f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 125f && Camera.main.transform.localEulerAngles.y <= 140f))
        {
            force = 770f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 140f && Camera.main.transform.localEulerAngles.y <= 160f))
        {
            force = 675f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 160f && Camera.main.transform.localEulerAngles.y <= 200f))
        {
            force = 650f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 200f && Camera.main.transform.localEulerAngles.y <= 220f))
        {
            force = 675f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 220f && Camera.main.transform.localEulerAngles.y <= 240f))
        {
            force = 770f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 240f && Camera.main.transform.localEulerAngles.y <= 255f))
        {
            force = 810f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 255f && Camera.main.transform.localEulerAngles.y <= 290f))
        {
            force = 790f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 290f && Camera.main.transform.localEulerAngles.y <= 310f))
        {
            force = 720f;
        }
        else if ((Camera.main.transform.localEulerAngles.y > 310f && Camera.main.transform.localEulerAngles.y <= 345f))
        {
            force = 610f;
        }
        else
        {
            force = 570f;
        }
        //print(force);

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



        if(snScript.shotgood)
        {

            if(isServer) {
                // update score object


            }



            print(score);
            Destroy(ball);
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
        NetworkServer.Spawn(shot);
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