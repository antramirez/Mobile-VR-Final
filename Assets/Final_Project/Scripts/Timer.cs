using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    private float timeLeft;

	// Use this for initialization
	void Start () {
        timeLeft = Time.time + 90f;
	}
	
	// Update is called once per frame
	void Update () {
        float time = timeLeft - Time.time;
        string sec = (time % 91).ToString("f1");
        timerText.text = sec;
	}
}
