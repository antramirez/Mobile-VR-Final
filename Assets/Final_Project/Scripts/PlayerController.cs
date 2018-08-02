using UnityEngine;
using UnityEngine.Networking;

namespace A08dkg3
{
    public class PlayerController : NetworkBehaviour
    {
        public GameObject ball;
        public Transform pos;
        GameObject shot;
        public float force = 600f;
        public float speed = 5f;
        public float accel_decel = 1f;

		void Update()
        {
            // check to make sure the player is local
            if (!isLocalPlayer)
            {
                return;
            }

            float horiz = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            float vert = Input.GetAxis("Vertical") * Time.deltaTime * speed;

            transform.Translate(new Vector3(horiz, vert, 0f));

            if ((Camera.main.transform.localEulerAngles.y > 40f && Camera.main.transform.localEulerAngles.y <= 60f))
            {
                force = 725f;
            }
            else if ((Camera.main.transform.localEulerAngles.y > 120f && Camera.main.transform.localEulerAngles.y <= 140f))
            {
                force = 725f;
            }
            else if ((Camera.main.transform.localEulerAngles.y > 220f && Camera.main.transform.localEulerAngles.y <= 240f))
            {
                force = 725f;
            }
            else if ((Camera.main.transform.localEulerAngles.y > 300f && Camera.main.transform.localEulerAngles.y <= 320f))
            {
                force = 725f;
            }
            else if ((Camera.main.transform.localEulerAngles.y > 60f && Camera.main.transform.localEulerAngles.y < 120f))
            {
                force = 775f;
            }
            else if ((Camera.main.transform.localEulerAngles.y > 240f && Camera.main.transform.localEulerAngles.y < 300f))
            {
                force = 775f;
            }
            else
            {
                force = 600f;
            }

            // position the camera just above the first person player
            Camera.main.transform.parent.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
            // allow the player to rotate left and right based on head movement
            transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
            // have the player moving forward at a constant slow speed so all they have to worry about is shooting
            //transform.position += transform.forward * 2f * Time.deltaTime;

            // fire the bullet when the trigger is pressed
            if (Input.GetMouseButtonDown(0))
            {
                CmdFire();
            }
        }

        // This [Command] code is called on the Client …
        // … but it is run on the Server!
        [Command]
        void CmdFire()
        {
            // instantitate the ball and shoot it from the camera
            shot = Instantiate(ball, pos.position, pos.rotation);
            //shot.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            // make it act as a rigidbody
            Rigidbody body = shot.GetComponent<Rigidbody>();
            // shoot it with the given direction, force, and speed
            body.AddForce((transform.forward + transform.up) / 2f * force * accel_decel);
            Destroy(shot, 4f);
        }

        public override void OnStartLocalPlayer()
        {
            // position the camera just above the first person player
            Camera.main.transform.parent.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
            // allow the player to rotate left and right based on head movement
            transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
            // make the local player blue
            GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}