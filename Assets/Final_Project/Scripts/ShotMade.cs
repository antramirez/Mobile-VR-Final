using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ShotMade : NetworkBehaviour
{
    public GameObject ball;
    public GameObject ballCollider;
    public GameObject explosion;
    public GameObject noise;
    GameObject explode;
    GameObject crowd;
    public PlayerController pc;
    public GameState gs;
    [SyncVar]
    public int pid;

    public void Start()
    {
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
        //if (isServer)
        //{
            if (col.gameObject.name == "BallCollider")
            {
                crowd = Instantiate(noise);
                Destroy(crowd, 2);
                explode = Instantiate(explosion);
                explode.transform.position = new Vector3(col.transform.position.x, col.transform.position.y + .275f, col.transform.position.z + .5f);
                //  Destroy(ball);
                Destroy(explode, 2);
                col.transform.parent.gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
                Destroy(col.transform.parent.gameObject, 3);
                print("player id that just shot: " + pid);
                gs.UpdateScore(pid);
            }   
        //}
    }
}
