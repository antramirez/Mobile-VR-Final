using UnityEngine;
using System.Collections;

namespace A08dkg3
{
    public class Billboard : MonoBehaviour
    {
        // this script is attached to the healthbar canvas so it faces the main camera

        void Update()
        {
            // keep the healthbar canvas looking at the camera at all times
            transform.LookAt(Camera.main.transform);
        }
    }
}