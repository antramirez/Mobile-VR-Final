using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    // declare variables for the ball object and position to be shot from
    public GameObject ball;
    public Transform pos;
    GameObject shot;
    // provide default forces for the ball when shot
    public float force = 560f;
    public float speed = 5f;
    public float accel_decel = 1f;

    // get access to the game state script
    public GameState gsState;

    // get a handle for the individual players
    [SyncVar(hook = "OnPlayerIdChange")]
    public int playerId;

    // assign the players their ids
	void OnPlayerIdChange(int id)
    {
        playerId = id;
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        // Wait until the Game State object spawns and then grab a handle to it
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
    }

    public override void OnStartLocalPlayer()
    {
        // position the camera just above the first person player
        Camera.main.transform.parent.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
        // allow the player to rotate left and right based on head movement
        transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
        // make the local player blue
        GetComponent<Renderer>().material.color = Color.blue;
        // Wait until the Game State object spawns and then grab a handle to it
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
        // this increments lastPlayerId and adds an entry in the scoreboard array
        gsState.AddNewPlayer();   
        // Here I am letting the server send the new value via the syncvar
        playerId = gsState.lastPlayerId;
    }

    void Update()
    {
        // return if the player is local
        if (!isLocalPlayer)
        {
            return;
        }

        // don't allow the players to shoot or move if 2 players aren't playing or the time is up
        if (gsState.lastPlayerId == 2 && gsState.time >= .1f)
        {
            // forces for player 1's shots based on their viewing angle
            if (playerId == 1)
            {
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
                    force = 560f;
                }
            }
            // forces for player 2's shots based on their viewing angle
            else if (playerId == 2)
            {
                if ((Camera.main.transform.localEulerAngles.y > 0f && Camera.main.transform.localEulerAngles.y <= 15f))
                {
                    force = 630f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 15f && Camera.main.transform.localEulerAngles.y <= 40f))
                {
                    force = 670f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 40f && Camera.main.transform.localEulerAngles.y <= 55f))
                {
                    force = 770f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 55f && Camera.main.transform.localEulerAngles.y <= 75f))
                {
                    force = 810f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 75f && Camera.main.transform.localEulerAngles.y <= 95f))
                {
                    force = 790f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 95f && Camera.main.transform.localEulerAngles.y <= 115f))
                {
                    force = 790f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 115f && Camera.main.transform.localEulerAngles.y <= 130f))
                {
                    force = 720f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 130f && Camera.main.transform.localEulerAngles.y <= 160f))
                {
                    force = 610f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 160f && Camera.main.transform.localEulerAngles.y <= 200f))
                {
                    force = 560f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 200f && Camera.main.transform.localEulerAngles.y <= 225f))
                {
                    force = 610f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 225f && Camera.main.transform.localEulerAngles.y <= 245f))
                {
                    force = 720f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 245f && Camera.main.transform.localEulerAngles.y <= 265f))
                {
                    force = 790f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 265f && Camera.main.transform.localEulerAngles.y <= 285f))
                {
                    force = 790f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 285f && Camera.main.transform.localEulerAngles.y <= 305f))
                {
                    force = 810f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 305f && Camera.main.transform.localEulerAngles.y <= 320f))
                {
                    force = 770f;
                }
                else if ((Camera.main.transform.localEulerAngles.y > 320f && Camera.main.transform.localEulerAngles.y <= 335f))
                {
                    force = 670f;
                }
                else
                {
                    force = 630f;
                }
            }

            // position the camera just above the first person player
            Camera.main.transform.parent.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
            // allow the player to rotate left and right based on head movement
            transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
            // move the gun and shooting spawn position based on player movement to allow a degree of variability to the shots
            transform.GetChild(1).position = new Vector3(transform.GetChild(1).position.x, -Camera.main.transform.rotation.x * 1.2f + 1, transform.GetChild(1).position.z);
            transform.GetChild(2).position = new Vector3(transform.GetChild(2).position.x, -Camera.main.transform.rotation.x * 1.2f + 1, transform.GetChild(2).position.z);

            // shoot the ball when the trigger is pressed
            if (Input.GetMouseButtonDown(0))
            {
                CmdFire(force, playerId);
            }
        }
    }

    // This [Command] code is called on the Client …
    // … but it is run on the Server!
    [Command]
    void CmdFire(float f, int id)
    {
        // add to the total shots attempted for the player that took the shot
        gsState.UpdateShotsAttempted(id);
        // instantiate the ball to be shot
        shot = Instantiate(ball, pos.position, pos.rotation);
        // make it act as a rigidbody
        Rigidbody body = shot.GetComponent<Rigidbody>();
        // shoot it with the given direction, force, and speed
        body.AddForce((transform.forward + transform.up) / 2f * f * accel_decel);
        // assign the components of the shot made script to the ball shot by the specific player
        shot.GetComponent<ShotMade>().pid = id;
        // spawn the shot on the network
        NetworkServer.Spawn(shot);
        // destroy the ball after 4 seconds
        Destroy(shot, 4f);
    }
}