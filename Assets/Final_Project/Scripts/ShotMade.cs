using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ShotMade : NetworkBehaviour
{

    public GameObject ball;
    public GameObject ballCollider;
    public GameObject explosion;
    GameObject explode;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "BallCollider")
        {
            explode = Instantiate(explosion);
            explode.transform.position = new Vector3(col.transform.position.x, col.transform.position.y+.275f, col.transform.position.z+.5f);
            Destroy(ball);
            Destroy(explode, 2);
            col.transform.parent.gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
            Destroy(col.transform.parent.gameObject, 3);
        }
    }
}
