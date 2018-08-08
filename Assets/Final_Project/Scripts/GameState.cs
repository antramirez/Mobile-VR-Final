using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameState : NetworkBehaviour
{
    [SyncVar]
    public int lastPlayerId = 0;

    public SyncListInt players = new SyncListInt();

    [SyncVar]
    public int p1score;
    [SyncVar]
    public int p2score;

    [SyncVar]
    public int totalScore;
    public Text p1Text;
    public Text p2Text;
  
    public Text timerText;
    public float time = 90.1f;
    int count;
    string sec;

    public bool gameover = false;

    public override void OnStartServer()
    {
        base.OnStartServer();
        p1score = 0;
        p2score = 0;
        totalScore = p1score + p2score;
        p1Text.text = "Player 1: " + p1score.ToString();
        p2Text.text = "Player 2: " + p2score.ToString();
    }
	public void Start()
	{
        GameObject temp = GameObject.Find("Timer");
        if (temp == null)
        {
            timerText.text = "Time Left";
            timerText.color = Color.white;
            time = 90.1f;
        }
	}
	public void Update()
	{
        if (lastPlayerId == 2 && count == 0)
        {
            count++;
            InvokeRepeating("CountDown", .3f, .1f);
        }

        totalScore = p1score + p2score;
        p1Text.text = "Player 1: " + p1score.ToString();
        p2Text.text = "Player 2: " + p2score.ToString();

        // check if timer is up and if there is a winner or tie
        if (time <= .1f)
        {
            if (p1score == p2score)
            {
                p1Text.text = "Player 1: TIE GAME";
                p2Text.text = "Player 2: TIE GAME";
            }
            else
            {
                if (p1score > p2score)
                {
                    p1Text.text = "Player 1: YOU WIN";
                    p2Text.text = "Player 2: YOU LOSE";
                }
                else
                {
                    p1Text.text = "Player 1: YOU LOSE";
                    p2Text.text = "Player 2: YOU WIN";
                }
            }
        }

        // check if all the baskets were made and if there is a winner or if there is a tie
        if (totalScore >= 16)
        {
            if (p1score == 8 && p2score == 8)
            {
                p1Text.text = "Player 1: TIE GAME";
                p2Text.text = "Player 2: TIE GAME"; 
            }
            else
            {
                if (p1score > p2score)
                {
                    p1Text.text = "Player 1: YOU WIN";
                    p2Text.text = "Player 2: YOU LOSE";  
                }
                else
                {
                    p1Text.text = "Player 1: YOU LOSE";
                    p2Text.text = "Player 2: YOU WIN";
                }
            }
        }
	}

	// this increments lastPlayerId and adds an entry in the scoreboard array
	// this is called from a Command by the player, so it runs as server
	public void AddNewPlayer()
    {
        lastPlayerId++;
        players.Add(0);
    }

    public void UpdateScore(int id)
    {
        if (id == 1)
        {
            p1score += 1;
        }
        else if (id == 2)
        {
            p2score += 1;
        }
        else
        {
            print("who?");
        }
    }

    public void CountDown()
    {
        if (time <= .1f)
        {
            Finish();
        }
        if (gameover)
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
        gameover = true;
        timerText.color = Color.red;
        timerText.text = "Game Over";
        var baskets = GameObject.FindGameObjectsWithTag("hoop");
        foreach (var basket in baskets)
        {
            Destroy(basket);
        }
    }
}