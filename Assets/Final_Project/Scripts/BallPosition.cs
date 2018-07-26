using UnityEngine;
using System.Collections;

public class BallPosition : MonoBehaviour
{
    // this script is attached to the healthbar canvas so it faces the main camera

    void Update()
    {
        // keep the healthbar canvas looking at the camera at all times
        transform.LookAt(Camera.main.transform);
    }
}