using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHoopsAndSeats : MonoBehaviour 
{
	public GameObject bball_hoops;
    public GameObject seats;
    public GameObject w_people;
    public GameObject w2_people;
    public GameObject b_people;
    public GameObject b2_people;
    GameObject bball_hoop;
    GameObject seat;
    GameObject w_person;
    GameObject w2_person;
    GameObject b_person;
    GameObject b2_person;
    float hoops_left = -5f;
    float hoops_right = -5f;
    float hoops_forward = -15f;
    float hoops_back = -15f;
    float seats_left = -22.1f;
    float seats_right = -22.1f;
    float seats_forward = -23.6f;
    float seats_back = -23.6f;
    float audience_pos_x = -17.3f;
    float audience_pos_y = -.3f;
    float audience_pos_z = -5.8f;
    int rand;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            hoops_left += 5;
            // instantiate the hoop prefab
            bball_hoop = Instantiate(bball_hoops);
            bball_hoop.transform.position = new Vector3(-13.9f, 0.95f, hoops_left);
            bball_hoop.transform.Rotate(0, 90, 0);
        }
        for (int i = 0; i < 3; i++)
        {
            hoops_right += 5;
            // instantiate the hoop prefab
            bball_hoop = Instantiate(bball_hoops);
            bball_hoop.transform.position = new Vector3(13.9f, 0.95f, hoops_right);
            bball_hoop.transform.Rotate(0, 270, 0);
        }
        for (int i = 0; i < 5; i++)
        {
            hoops_forward += 5;
            // instantiate the hoop prefab
            bball_hoop = Instantiate(bball_hoops);
            bball_hoop.transform.position = new Vector3(hoops_forward, 0.95f, 12.8f);
            bball_hoop.transform.Rotate(0, 180, 0);
        }
        for (int i = 0; i < 5; i++)
        {
            hoops_back += 5;
            // instantiate the hoop prefab
            bball_hoop = Instantiate(bball_hoops);
            bball_hoop.transform.position = new Vector3(hoops_back, 0.95f, -2.8f);
            bball_hoop.transform.Rotate(0, 0, 0);
        }

        for (int i = 0; i < 4; i++)
        {
            seats_left += 10.7f;
            // instantiate the seat prefab
            seat = Instantiate(seats);
            seat.transform.position = new Vector3(-22.0f, -1.0f, seats_left);
            seat.transform.Rotate(0, 90, 0);
        }
        for (int i = 0; i < 4; i++)
        {
            seats_right += 10.7f;
            // instantiate the seat prefab
            seat = Instantiate(seats);
            seat.transform.position = new Vector3(22.2f, -1.0f, seats_right);
            seat.transform.Rotate(0, 270, 0);
        }
        for (int i = 0; i < 3; i++)
        {
            seats_forward += 11.8f;
            // instantiate the seat prefab
            seat = Instantiate(seats);
            seat.transform.position = new Vector3(seats_forward, -1.0f, 19.5f);
            seat.transform.Rotate(0, 180, 0);
        }
        for (int i = 0; i < 3; i++)
        {
            seats_back += 11.8f;
            // instantiate the seat prefab
            seat = Instantiate(seats);
            seat.transform.position = new Vector3(seats_back, -1.0f, -9.5f);
            seat.transform.Rotate(0, 0, 0);
        }

        for (int i = 0; i < 15; i++)
        {
            audience_pos_x = -17.3f;
            audience_pos_y += 0.18f;
            audience_pos_z -= 0.5f;
            for (int j = 0; j < 43; j++)
            {
                rand = (Random.Range(0, 10));
                if (rand < 2.5f) 
                {
                    // instantiate the person prefab
                    w_person = Instantiate(w_people);
                    w_person.transform.position = new Vector3(audience_pos_x, audience_pos_y, audience_pos_z);
                    w_person.transform.Rotate(0, 0, 0);
                    audience_pos_x += 0.8f;   
                }
                else if (rand < 5)
                {
                    // instantiate the person prefab
                    w2_person = Instantiate(w2_people);
                    w2_person.transform.position = new Vector3(audience_pos_x, audience_pos_y, audience_pos_z);
                    w2_person.transform.Rotate(0, 0, 0);
                    audience_pos_x += 0.8f;
                }
                else if (rand < 7.5f)
                {
                    // instantiate the person prefab
                    b2_person = Instantiate(b2_people);
                    b2_person.transform.position = new Vector3(audience_pos_x, audience_pos_y, audience_pos_z);
                    b2_person.transform.Rotate(0, 0, 0);
                    audience_pos_x += 0.8f;
                }
                else 
                {
                    // instantiate the person prefab
                    b_person = Instantiate(b_people);
                    b_person.transform.position = new Vector3(audience_pos_x, audience_pos_y, audience_pos_z);
                    b_person.transform.Rotate(0, 0, 0);
                    audience_pos_x += 0.8f;
                }
            }
        }
        audience_pos_y = -.3f;
        audience_pos_z = 15.9f;
        for (int i = 0; i < 15; i++)
        {
            audience_pos_x = -16.5f;
            audience_pos_y += 0.18f;
            audience_pos_z += 0.5f;
            for (int j = 0; j < 43; j++)
            {
                rand = (Random.Range(0, 10));
                if (rand < 2.5)
                {
                    // instantiate the person prefab
                    w_person = Instantiate(w_people);
                    w_person.transform.position = new Vector3(audience_pos_x, audience_pos_y, audience_pos_z);
                    w_person.transform.Rotate(0, 180, 0);
                    audience_pos_x += 0.8f;
                }
                else if (rand < 5)
                {
                    // instantiate the person prefab
                    w2_person = Instantiate(w2_people);
                    w2_person.transform.position = new Vector3(audience_pos_x, audience_pos_y, audience_pos_z);
                    w2_person.transform.Rotate(0, 180, 0);
                    audience_pos_x += 0.8f;
                }
                else if (rand < 7.5f)
                {
                    // instantiate the person prefab
                    b2_person = Instantiate(b2_people);
                    b2_person.transform.position = new Vector3(audience_pos_x, audience_pos_y, audience_pos_z);
                    b2_person.transform.Rotate(0, 180, 0);
                    audience_pos_x += 0.8f;
                }
                else
                {
                    // instantiate the person prefab
                    b_person = Instantiate(b_people);
                    b_person.transform.position = new Vector3(audience_pos_x, audience_pos_y, audience_pos_z);
                    b_person.transform.Rotate(0, 180, 0);
                    audience_pos_x += 0.8f;
                }
            }
        }

        audience_pos_x = -18.4f;
        audience_pos_y = -.3f;
        for (int i = 0; i < 15; i++)
        {
            audience_pos_x -= .5f;
            audience_pos_y += 0.18f;
            audience_pos_z = -15.8f;
            for (int j = 0; j < 53; j++)
            {
                rand = (Random.Range(0, 10));
                if (rand < 2.5f)
                {
                    // instantiate the person prefab
                    w_person = Instantiate(w_people);
                    w_person.transform.position = new Vector3(audience_pos_x, audience_pos_y, audience_pos_z);
                    w_person.transform.Rotate(0, 90, 0);
                    audience_pos_z += 0.8f;
                }
                else if (rand < 5)
                {
                    // instantiate the person prefab
                    w2_person = Instantiate(w2_people);
                    w2_person.transform.position = new Vector3(audience_pos_x, audience_pos_y, audience_pos_z);
                    w2_person.transform.Rotate(0, 90, 0);
                    audience_pos_z += 0.8f;
                }
                else if (rand < 7.5f)
                {
                    // instantiate the person prefab
                    b2_person = Instantiate(b2_people);
                    b2_person.transform.position = new Vector3(audience_pos_x, audience_pos_y, audience_pos_z);
                    b2_person.transform.Rotate(0, 90, 0);
                    audience_pos_z += 0.8f;
                }
                else
                {
                    // instantiate the person prefab
                    b_person = Instantiate(b_people);
                    b_person.transform.position = new Vector3(audience_pos_x, audience_pos_y, audience_pos_z);
                    b_person.transform.Rotate(0, 90, 0);
                    audience_pos_z += 0.8f;
                }
            }
        }
        audience_pos_x = 18.7f;
        audience_pos_y = -.3f;
        for (int i = 0; i < 15; i++)
        {
            audience_pos_x += .5f;
            audience_pos_y += 0.18f;
            audience_pos_z = -16.5f;
            for (int j = 0; j < 53; j++)
            {
                rand = (Random.Range(0, 10));
                if (rand < 2.5f)
                {
                    // instantiate the person prefab
                    w_person = Instantiate(w_people);
                    w_person.transform.position = new Vector3(audience_pos_x, audience_pos_y, audience_pos_z);
                    w_person.transform.Rotate(0, 270, 0);
                    audience_pos_z += 0.8f;
                }
                else if (rand < 5)
                {
                    // instantiate the person prefab
                    w2_person = Instantiate(w2_people);
                    w2_person.transform.position = new Vector3(audience_pos_x, audience_pos_y, audience_pos_z);
                    w2_person.transform.Rotate(0, 270, 0);
                    audience_pos_z += 0.8f;
                }
                else if (rand < 7.5f)
                {
                    // instantiate the person prefab
                    b2_person = Instantiate(b2_people);
                    b2_person.transform.position = new Vector3(audience_pos_x, audience_pos_y, audience_pos_z);
                    b2_person.transform.Rotate(0, 270, 0);
                    audience_pos_z += 0.8f;
                }
                else
                {
                    // instantiate the person prefab
                    b_person = Instantiate(b_people);
                    b_person.transform.position = new Vector3(audience_pos_x, audience_pos_y, audience_pos_z);
                    b_person.transform.Rotate(0, 270, 0);
                    audience_pos_z += 0.8f;
                }
            }
        }
	}
}
