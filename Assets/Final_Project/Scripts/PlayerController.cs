using System.Collections;
using System.Collections.Generic;
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

    public GameState gsState;
    //private Timer tScript;

    [SyncVar(hook = "OnPlayerIdChange")]
    public int playerId;

	void Start()
	{
        //tScript = GameObject.Find("Players").GetComponent<Timer>();
	}

	void OnPlayerIdChange(int id)
    {
        playerId = id;
        Debug.Log("Player id set on player " + playerId);
    }


    public override void OnStartServer()
    {
        base.OnStartServer();
        Debug.Log("Get GameManager on Server");

        // Wait until the Game Manager object spawns and then grab a handle to it
        while (gsState == null)
        {
            GameObject temp = GameObject.Find("GameState");
            if (temp != null)
                gsState = temp.GetComponent<GameState>();
        }

    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        Debug.Log("Client non-local player started with id: " + playerId);
        /*
        while (gsState == null)
        {
            GameObject temp = GameObject.Find("Game Manager");
            if (temp != null)
                gsState = temp.GetComponent<GameState>();
        }
        */
    }



    public override void OnStartLocalPlayer()
    {
        // position the camera just above the first person player
        Camera.main.transform.parent.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
        // allow the player to rotate left and right based on head movement
        transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
        // make the local player blue
        GetComponent<Renderer>().material.color = Color.blue;

        Debug.Log("Get GameState on Player");
        while (gsState == null)
        {
            GameObject temp = GameObject.Find("GameState");
            if (temp != null)
                gsState = temp.GetComponent<GameState>();
        }

        // Tell server a new player has started
        CmdIncrPlayerId();
    }


    // This Increments the player count on the server
    [Command]
    void CmdIncrPlayerId()
    {
        Debug.Log("New Player Joined");
        gsState.AddNewPlayer();   // this increments lastPlayerId and adds an entry in the scoreboard array

        // Here I am letting the server send the new value via the syncvar
        playerId = gsState.lastPlayerId;

        // Alternately I can call an Rpc method on the client and send it the player id
        //            RpcSetId(gameManager.lastPlayerId);
    }

    void Update()
    {
        ////print("There are currently " + gsScript.NumPlayers() + " players");
        //if (gsScript.NumPlayers() > 0 && gsScript.NumPlayers() < 2){
        //  //  print("YOU ARE PLAYER 1");
        //    host = true;
        //    client = false;
        //    print("You are host: " + host);
        //}
        //else if (gsScript.NumPlayers() > 1)
        //{
        //  //  print("YOU ARE PLAYER 2");
        //    host = false;
        //    client = true;
        //    print("You are client: " + client);
        //}
        ////if (netScript.PlayerNumIsSet())
        ////{
        ////    playerNumber = netScript.GetPLayerNumber();
        ////    print(playerNumber);
        ////}
        //// check to make sure the player is local
        if (!isLocalPlayer)
        {
            return;
        }
        if (gsState.lastPlayerId == 2)
        {
            float horiz = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            float vert = Input.GetAxis("Vertical") * Time.deltaTime * speed;

            transform.Translate(new Vector3(horiz, vert, 0f));
            print("Current id " + playerId);
            //if (playerId == 2)
            //{
            //    tScript.Starter(1);
            //}
            //else
            //{
            //    tScript.Starter(0);
            //}

            if (playerId == 1)
            {
                print("hello");
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
            }
            else if (playerId == 2)
            {
                print("hi");
                if ((Camera.main.transform.localEulerAngles.y > 5f && Camera.main.transform.localEulerAngles.y <= 35f))
                {
                    force = 610f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 35f && Camera.main.transform.localEulerAngles.y <= 55f))
                {
                    force = 710f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 55f && Camera.main.transform.localEulerAngles.y <= 80f))
                {
                    force = 760f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 80f && Camera.main.transform.localEulerAngles.y <= 100f))
                {
                    force = 750f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 100f && Camera.main.transform.localEulerAngles.y <= 120f))
                {
                    force = 760f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 120f && Camera.main.transform.localEulerAngles.y <= 140f))
                {
                    force = 710f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 140f && Camera.main.transform.localEulerAngles.y <= 170f))
                {
                    force = 610f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 170f && Camera.main.transform.localEulerAngles.y <= 205f))
                {
                    force = 610f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 205f && Camera.main.transform.localEulerAngles.y <= 230f))
                {
                    force = 670f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 230f && Camera.main.transform.localEulerAngles.y <= 245f))
                {
                    force = 780f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 245f && Camera.main.transform.localEulerAngles.y <= 260f))
                {
                    force = 830f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 260f && Camera.main.transform.localEulerAngles.y <= 280f))
                {
                    force = 815f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 280f && Camera.main.transform.localEulerAngles.y <= 295f))
                {
                    force = 830f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 295f && Camera.main.transform.localEulerAngles.y <= 310f))
                {
                    force = 780f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 310f && Camera.main.transform.localEulerAngles.y <= 335f))
                {
                    force = 670f;
                }
                else
                {
                    force = 610f;
                }
                print(force);
            }


            // position the camera just above the first person player
            Camera.main.transform.parent.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
            // allow the player to rotate left and right based on head movement
            transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
            transform.GetChild(1).position = new Vector3(transform.GetChild(1).position.x, -Camera.main.transform.rotation.x * 1.2f + 1, transform.GetChild(1).position.z);
            transform.GetChild(2).position = new Vector3(transform.GetChild(2).position.x, -Camera.main.transform.rotation.x * 1.2f + 1, transform.GetChild(2).position.z);
            // have the player moving forward at a constant slow speed so all they have to worry about is shooting
            //transform.position += transform.forward * 2f * Time.deltaTime;

            // fire the bullet when the trigger is pressed
            if (Input.GetMouseButtonDown(0))
            {
                CmdFire();
            }
        }

      
    }

    // This [Command] code is called on the Client …
    // … but it is run on the Server!
    [Command]
    void CmdFire()
    {
        //if (playerId == 2)
        //{
        // instantitate the ball and shoot it from the camera
        shot = Instantiate(ball, pos.position, pos.rotation);
        //shot.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        // make it act as a rigidbody
        Rigidbody body = shot.GetComponent<Rigidbody>();
        // shoot it with the given direction, force, and speed
        body.AddForce((transform.forward + transform.up) / 2f * force * accel_decel);
        NetworkServer.Spawn(shot);
        Destroy(shot, 4f);
        //}
    }
}