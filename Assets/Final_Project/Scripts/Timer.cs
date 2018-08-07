using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Timer : NetworkBehaviour 
{
    public Text timerText;
    private float timeLeft;
    private bool gameOver = false;
    float time;
    int count;
    string sec;

    public GameState gsState;

	// Use this for initialization
	void Start () 
    {
        timerText.text = "Time Left";
        time = 90.1f;
        timeLeft = 90.1f;
        timerText.color = Color.white;
        if (gsState.lastPlayerId == 2)
        {
            InvokeRepeating("CountDown", .3f, .1f);   
        }
	}

    public override void OnStartLocalPlayer()
    {
        while (gsState == null)
        {
            GameObject temp = GameObject.Find("GameState");
            if (temp != null)
                gsState = temp.GetComponent<GameState>();
        }
    }
	
	//// Update is called once per frame
	//void Update () 
 //   {
 //       if (gsState.lastPlayerId == 2 && count == 0)
 //       {
 //           count++;
 //           InvokeRepeating("CountDown", .3f, .1f);
 //       }
	//}

    public void CountDown()
    {
        if (time <= .1f)
        {
            Finish();
        }
        if (gameOver)
        {
            return;
        }
        time = time - .1f;
        if (time > 10f)
        {
            sec = (time % 91).ToString("f0");    
        }
        else
        {
            sec = (time % 91).ToString("f1");   
        }
        timerText.text = sec;
    }

    public void Finish()
    {
        gameOver = true;
        timerText.color = Color.red;
        timerText.text = "Game Over";
    }
}
