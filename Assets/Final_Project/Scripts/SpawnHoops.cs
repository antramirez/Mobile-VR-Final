using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHoops : MonoBehaviour 
{
	public GameObject bball_hoops;
    GameObject bball_hoop;
    float count_left = -5f;
    float count_right = -5f;
    float count_forward = -15f;
    float count_back = -15f;

    // Use this for initialization
    void Start()
    {
        // populate 50 randomly placed trees
        for (int i = 0; i < 3; i++)
        {
            count_left += 5;
            // instantiate the hoop prefab
            bball_hoop = Instantiate(bball_hoops);
            bball_hoop.transform.position = new Vector3(-13.9f, 0.95f, count_left);
            bball_hoop.transform.Rotate(0, 90, 0);
        }
        for (int i = 0; i < 3; i++)
        {
            count_right += 5;
            // instantiate the hoop prefab
            bball_hoop = Instantiate(bball_hoops);
            bball_hoop.transform.position = new Vector3(13.9f, 0.95f, count_right);
            bball_hoop.transform.Rotate(0, 270, 0);
        }
        for (int i = 0; i < 5; i++)
        {
            count_forward += 5;
            // instantiate the hoop prefab
            bball_hoop = Instantiate(bball_hoops);
            bball_hoop.transform.position = new Vector3(count_forward, 0.95f, 12.8f);
            bball_hoop.transform.Rotate(0, 180, 0);
        }
        for (int i = 0; i < 5; i++)
        {
            count_back += 5;
            // instantiate the hoop prefab
            bball_hoop = Instantiate(bball_hoops);
            bball_hoop.transform.position = new Vector3(count_back, 0.95f, -2.8f);
            bball_hoop.transform.Rotate(0, 0, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
