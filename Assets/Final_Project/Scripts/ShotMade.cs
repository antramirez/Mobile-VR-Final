using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMade : MonoBehaviour
{

    public GameObject ball;
    public GameObject ballCollider;

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
            Destroy(ball);
        }
    }
}
