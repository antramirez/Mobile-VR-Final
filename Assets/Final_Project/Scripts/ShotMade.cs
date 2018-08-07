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
    [SyncVar]
    public bool shotgood = false;
    public int count;


    //private GameState gsScript;
    //public GameObject gsGO;

    //private PlayerController pcScript;
    //public GameObject pcGO;

    public void Start()
    {
        //gsScript = gsGO.GetComponent<GameState>();
        //pcScript = pcGO.GetComponent<PlayerController>();

  //      print("gsScript says you are host " + pcScript.GetHost());
    }
    public void Update()
    {
        //print("psScript says you are host " + pcScript.GetHost());
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
            //count++;
            //print("BUCKETS");

            //if (pcScript.GetHost())
            //{
            //    gsScript.UpdateP1Score();
            //}
            //else if (pcScript.GetClient())
            //{
            //    gsScript.UpdateP2Score();
            //}
            //else 
            //{
            //    print("FUCK");
            //}
        }
    }

    public bool ShotGood()
    {
        return shotgood;
    }
}
