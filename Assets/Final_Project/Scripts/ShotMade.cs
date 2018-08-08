using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ShotMade : NetworkBehaviour
{
    // declare gameobjects that will be used to detect for a successful shot
    // and create crowd noise when this happens
    public GameObject ball;
    public GameObject ballCollider;
    public GameObject explosion;
    public GameObject noise;
    GameObject explode;
    GameObject crowd;
    // get access to the player controller and game state scripts
    public PlayerController pc;
    public GameState gs;
    // use to distinguish players
    [SyncVar]
    public int pid;

    public void Start()
    {
        // gain the components of the player controller and game state scripts
        GameObject temp = GameObject.Find("PlayerController");

        while (temp != null)
        {
            pc = transform.parent.GetComponent<PlayerController>();
        }

        GameObject temp2 = GameObject.Find("GameState");
        if (temp2 != null)
            gs = temp2.GetComponent<GameState>();
    }

    public void OnCollisionEnter(Collision col)
    {
        // check to see if the shot hit the invisible ball collider placed in the net of each hoop
        if (col.gameObject.name == "BallCollider")
        {
            // create crowd noise for a successful shot
            // create an explosion for a successful shot
            // destroy the invisible ball collider, the explosion, and the hoop
            // before destroying the hoop make it red to show that it will be destroyed
            // shortly and is no longer makeable
            if (isServer)
            {
                crowd = Instantiate(noise);
                Destroy(crowd, 2);
                explode = Instantiate(explosion);
                explode.transform.position = new Vector3(col.transform.position.x, col.transform.position.y + .275f, col.transform.position.z + .5f);
                Destroy(col.gameObject);
                Destroy(explode, 2);
                col.transform.parent.gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
                Destroy(col.transform.parent.gameObject, 3);
                // update the player's score for the player that made the shot
                gs.UpdateScore(pid);
            }
            else
            {
                crowd = Instantiate(noise);
                Destroy(crowd, 2);
                explode = Instantiate(explosion);
                explode.transform.position = new Vector3(col.transform.position.x, col.transform.position.y + .275f, col.transform.position.z + .5f);
                Destroy(col.gameObject);
                Destroy(explode, 2);
                col.transform.parent.gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
                Destroy(col.transform.parent.gameObject, 3);
            }
        }
    }
}
