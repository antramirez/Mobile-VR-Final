using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnHoops : NetworkBehaviour 
{
    // declare objects and positions for the hoops to be spawned
	public GameObject bball_hoops;
    GameObject bball_hoop;
    float hoops_left = -5f;
    float hoops_right = -5f;
    float hoops_forward = -15f;
    float hoops_back = -15f;

    // Use this for initialization
    void Start()
    {
        // left three hoops
        for (int i = 0; i < 3; i++)
        {
            hoops_left += 5;
            // instantiate the hoop prefab
            bball_hoop = Instantiate(bball_hoops);
            bball_hoop.transform.position = new Vector3(-13.9f, 0.95f, hoops_left);
            bball_hoop.transform.Rotate(0, 90, 0);
        }
        // right three hoops
        for (int i = 0; i < 3; i++)
        {
            hoops_right += 5;
            // instantiate the hoop prefab
            bball_hoop = Instantiate(bball_hoops);
            bball_hoop.transform.position = new Vector3(13.9f, 0.95f, hoops_right);
            bball_hoop.transform.Rotate(0, 270, 0);
        }
        // front three hoops
        for (int i = 0; i < 5; i++)
        {
            hoops_forward += 5;
            // instantiate the hoop prefab
            bball_hoop = Instantiate(bball_hoops);
            bball_hoop.transform.position = new Vector3(hoops_forward, 0.95f, 12.8f);
            bball_hoop.transform.Rotate(0, 180, 0);
        }
        // back three hoops
        for (int i = 0; i < 5; i++)
        {
            hoops_back += 5;
            // instantiate the hoop prefab
            bball_hoop = Instantiate(bball_hoops);
            bball_hoop.transform.position = new Vector3(hoops_back, 0.95f, -2.8f);
            bball_hoop.transform.Rotate(0, 0, 0);
        }
	}
}
