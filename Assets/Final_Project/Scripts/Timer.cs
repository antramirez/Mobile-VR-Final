using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    private float timeLeft;
    private bool gameOver = false;
    float time;

	// Use this for initialization
	void Start () {
        time = 10f;
        timeLeft = Time.time + 10f;
        timerText.color = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
        if (time <= 0f)
        {
            Finish();
        }
        if (gameOver)
        {
            return;
        }
        time = timeLeft - Time.time;
        string sec = (time % 11).ToString("f1");
        timerText.text = sec;
	}

    public void Finish()
    {
        gameOver = true;
        timerText.color = Color.red;
        timerText.text = "Game Over";
    }
}
