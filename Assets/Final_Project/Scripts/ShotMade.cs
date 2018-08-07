﻿using System.Collections;
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
    [SyncVar]
    public bool shotgood = false;
    public int score;

    public GameState gsState;

    public override void OnStartLocalPlayer()
    {
        while (gsState == null)
        {
            GameObject temp = GameObject.Find("GameState");
            if (temp != null)
                gsState = temp.GetComponent<GameState>();
        }
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "BallCollider")
        {
            crowd = Instantiate(noise);
            Destroy(crowd, 2);
            shotgood = true;
            explode = Instantiate(explosion);
            explode.transform.position = new Vector3(col.transform.position.x, col.transform.position.y+.275f, col.transform.position.z+.5f);
          //  Destroy(ball);
            Destroy(explode, 2);
            col.transform.parent.gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
            Destroy(col.transform.parent.gameObject, 3);
            //gsState.players[0] = gsState.p1score + 1;
            //print("BUCKETS");
        }
    }
}
