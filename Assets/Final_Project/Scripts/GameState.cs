using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameState : NetworkBehaviour
{
    // last player to enter the game
    [SyncVar]
    public int lastPlayerId = 0;

    // array of players in the game
    public SyncListInt players = new SyncListInt();

    // player one and two's scores
    [SyncVar]
    public int p1score;
    [SyncVar]
    public int p2score;
    // player one and two's total shot attempts
    [SyncVar]
    public int p1shots;
    [SyncVar]
    public int p2shots;

    // total score between the two players
    [SyncVar]
    public int totalScore;
    // text fields for the shots of each player and their total scores
    // that will be displayed on four scoreboards
    public Text p1Text;
    public Text p2Text;
    public Text p1Shots;
    public Text p2Shots;

    public Text p1TextS2;
    public Text p2TextS2;
    public Text p1ShotsS2;
    public Text p2ShotsS2;

    public Text p1TextS3;
    public Text p2TextS3;
    public Text p1ShotsS3;
    public Text p2ShotsS3;

    public Text p1TextS4;
    public Text p2TextS4;
    public Text p1ShotsS4;
    public Text p2ShotsS4;
  
    public Text timerText;
    public Text timerText2;
    public Text timerText3;
    public Text timerText4;
    // start time
    public float time = 90.1f;
    int count;
    string sec;

    // game is initially not over
    public bool gameover = false;

    public override void OnStartServer()
    {
        base.OnStartServer();
        // initalize player's score, total score, and text for the scoreboard
        p1score = 0;
        p2score = 0;
        p1shots = 0;
        p2shots = 0;
        totalScore = p1score + p2score;
        p1Text.text = "Player 1: " + p1score.ToString();
        p2Text.text = "Player 2: " + p2score.ToString();
        p1Shots.text = "Shots Made: " + p1score.ToString() + "/" + p1shots.ToString();
        p2Shots.text = "Shots Made: " + p2score.ToString() + "/" + p2shots.ToString();
        p1TextS2.text = "Player 1: " + p1score.ToString();
        p2TextS2.text = "Player 2: " + p2score.ToString();
        p1ShotsS2.text = "Shots Made: " + p1score.ToString() + "/" + p1shots.ToString();
        p2ShotsS2.text = "Shots Made: " + p2score.ToString() + "/" + p2shots.ToString();
        p1TextS3.text = "Player 1: " + p1score.ToString();
        p2TextS3.text = "Player 2: " + p2score.ToString();
        p1ShotsS3.text = "Shots Made: " + p1score.ToString() + "/" + p1shots.ToString();
        p2ShotsS3.text = "Shots Made: " + p2score.ToString() + "/" + p2shots.ToString();
        p1TextS4.text = "Player 1: " + p1score.ToString();
        p2TextS4.text = "Player 2: " + p2score.ToString();
        p1ShotsS4.text = "Shots Made: " + p1score.ToString() + "/" + p1shots.ToString();
        p2ShotsS4.text = "Shots Made: " + p2score.ToString() + "/" + p2shots.ToString();
    }
	public void Start()
	{
        // start the time remaining text as white and saying "Time Left"
        GameObject temp = GameObject.Find("Timer");
        if (temp == null)
        {
            timerText.text = "Time Left";
            timerText.color = Color.white;
            timerText2.text = "Time Left";
            timerText2.color = Color.white;
            timerText3.text = "Time Left";
            timerText3.color = Color.white;
            timerText4.text = "Time Left";
            timerText4.color = Color.white;
            time = 90.1f;
        }
	}
	public void Update()
	{
        // when the game start call count down repeatedly to decrement the game clock
        if (lastPlayerId == 2 && count == 0)
        {
            count++;
            InvokeRepeating("CountDown", .3f, .1f);
        }

        // update the total score between the players and update the scoreboard for shots attempted and made
        totalScore = p1score + p2score;
        p1Text.text = "Player 1: " + p1score.ToString();
        p2Text.text = "Player 2: " + p2score.ToString();
        p1Shots.text = "Shots Made: " + p1score.ToString() + "/" + p1shots.ToString();
        p2Shots.text = "Shots Made: " + p2score.ToString() + "/" + p2shots.ToString();
        p1TextS2.text = "Player 1: " + p1score.ToString();
        p2TextS2.text = "Player 2: " + p2score.ToString();
        p1ShotsS2.text = "Shots Made: " + p1score.ToString() + "/" + p1shots.ToString();
        p2ShotsS2.text = "Shots Made: " + p2score.ToString() + "/" + p2shots.ToString();
        p1TextS3.text = "Player 1: " + p1score.ToString();
        p2TextS3.text = "Player 2: " + p2score.ToString();
        p1ShotsS3.text = "Shots Made: " + p1score.ToString() + "/" + p1shots.ToString();
        p2ShotsS3.text = "Shots Made: " + p2score.ToString() + "/" + p2shots.ToString();
        p1TextS4.text = "Player 1: " + p1score.ToString();
        p2TextS4.text = "Player 2: " + p2score.ToString();
        p1ShotsS4.text = "Shots Made: " + p1score.ToString() + "/" + p1shots.ToString();
        p2ShotsS4.text = "Shots Made: " + p2score.ToString() + "/" + p2shots.ToString();

        // check if timer is up and if there is a winner or tie
        if (time <= .1f)
        {
            // tie
            if (p1score == p2score)
            {
                // tie
                if (p1shots == 0 && p2shots == 0)
                {
                    p1Text.text = "Player 1: TIE GAME";
                    p2Text.text = "Player 2: TIE GAME";
                    p1TextS2.text = "Player 1: TIE GAME";
                    p2TextS2.text = "Player 2: TIE GAME";
                    p1TextS3.text = "Player 1: TIE GAME";
                    p2TextS3.text = "Player 2: TIE GAME";
                    p1TextS4.text = "Player 1: TIE GAME";
                    p2TextS4.text = "Player 2: TIE GAME";
                }
                // tiebreaker based on better shooting percentage
                else if (p1shots == 0)
                {
                    if (p2score > 0)
                    {
                        p1Text.text = "Player 1: YOU LOSE";
                        p2Text.text = "Player 2: YOU WIN";
                        p1TextS2.text = "Player 1: YOU LOSE";
                        p2TextS2.text = "Player 2: YOU WIN"; 
                        p1TextS3.text = "Player 1: YOU LOSE";
                        p2TextS3.text = "Player 2: YOU WIN"; 
                        p1TextS4.text = "Player 1: YOU LOSE";
                        p2TextS4.text = "Player 2: YOU WIN"; 
                    }
                    else
                    {
                        p1Text.text = "Player 1: YOU WIN";
                        p2Text.text = "Player 2: YOU LOSE";
                        p1TextS2.text = "Player 1: YOU WIN";
                        p2TextS2.text = "Player 2: YOU LOSE";
                        p1TextS3.text = "Player 1: YOU WIN";
                        p2TextS3.text = "Player 2: YOU LOSE";
                        p1TextS4.text = "Player 1: YOU WIN";
                        p2TextS4.text = "Player 2: YOU LOSE";
                    }
                }
                // tiebreaker based on better shooting percentage
                else if (p2shots == 0)
                {
                    if (p1score > 0)
                    {
                        p1Text.text = "Player 1: YOU WIN";
                        p2Text.text = "Player 2: YOU LOSE";
                        p1TextS2.text = "Player 1: YOU WIN";
                        p2TextS2.text = "Player 2: YOU LOSE";
                        p1TextS3.text = "Player 1: YOU WIN";
                        p2TextS3.text = "Player 2: YOU LOSE";
                        p1TextS4.text = "Player 1: YOU WIN";
                        p2TextS4.text = "Player 2: YOU LOSE";
                    }
                    else
                    {
                        p1Text.text = "Player 1: YOU LOSE";
                        p2Text.text = "Player 2: YOU WIN";
                        p1TextS2.text = "Player 1: YOU LOSE";
                        p2TextS2.text = "Player 2: YOU WIN"; 
                        p1TextS3.text = "Player 1: YOU LOSE";
                        p2TextS3.text = "Player 2: YOU WIN"; 
                        p1TextS4.text = "Player 1: YOU LOSE";
                        p2TextS4.text = "Player 2: YOU WIN"; 
                    }
                }
                // tiebreaker based on better shooting percentage
                else if (p1shots < p2shots)
                {
                    p1Text.text = "Player 1: YOU WIN";
                    p2Text.text = "Player 2: YOU LOSE";
                    p1TextS2.text = "Player 1: YOU WIN";
                    p2TextS2.text = "Player 2: YOU LOSE";
                    p1TextS3.text = "Player 1: YOU WIN";
                    p2TextS3.text = "Player 2: YOU LOSE";
                    p1TextS4.text = "Player 1: YOU WIN";
                    p2TextS4.text = "Player 2: YOU LOSE";
                }
                else
                {
                    // tiebreaker based on better shooting percentage
                    if (p1shots > p2shots)
                    {
                        p1Text.text = "Player 1: YOU LOSE";
                        p2Text.text = "Player 2: YOU WIN";
                        p1TextS2.text = "Player 1: YOU LOSE";
                        p2TextS2.text = "Player 2: YOU WIN"; 
                        p1TextS3.text = "Player 1: YOU LOSE";
                        p2TextS3.text = "Player 2: YOU WIN"; 
                        p1TextS4.text = "Player 1: YOU LOSE";
                        p2TextS4.text = "Player 2: YOU WIN"; 
                    }
                    // ends in tie if equal shooting percentage
                    else
                    {
                        p1Text.text = "Player 1: TIE GAME";
                        p2Text.text = "Player 2: TIE GAME";
                        p1TextS2.text = "Player 1: TIE GAME";
                        p2TextS2.text = "Player 2: TIE GAME";
                        p1TextS3.text = "Player 1: TIE GAME";
                        p2TextS3.text = "Player 2: TIE GAME";
                        p1TextS4.text = "Player 1: TIE GAME";
                        p2TextS4.text = "Player 2: TIE GAME";
                    }
                }
            }
            else
            {
                // player 1 wins
                if (p1score > p2score)
                {
                    p1Text.text = "Player 1: YOU WIN";
                    p2Text.text = "Player 2: YOU LOSE";
                    p1TextS2.text = "Player 1: YOU WIN";
                    p2TextS2.text = "Player 2: YOU LOSE";
                    p1TextS3.text = "Player 1: YOU WIN";
                    p2TextS3.text = "Player 2: YOU LOSE";
                    p1TextS4.text = "Player 1: YOU WIN";
                    p2TextS4.text = "Player 2: YOU LOSE";
                }
                // player 2 wins
                else
                {
                    p1Text.text = "Player 1: YOU LOSE";
                    p2Text.text = "Player 2: YOU WIN";
                    p1TextS2.text = "Player 1: YOU LOSE";
                    p2TextS2.text = "Player 2: YOU WIN";
                    p1TextS3.text = "Player 1: YOU LOSE";
                    p2TextS3.text = "Player 2: YOU WIN";
                    p1TextS4.text = "Player 1: YOU LOSE";
                    p2TextS4.text = "Player 2: YOU WIN";
                }
            }
        }

        // check if all the baskets were made and if there is a winner or if there is a tie
        if (totalScore >= 16)
        {
            // end game when baskets are made
            Finish();
            // tie
            if (p1score == 8 && p2score == 8)
            {
                // tiebreaker based on better shooting percentage
                if (p1shots < p2shots)
                {
                    p1Text.text = "Player 1: YOU WIN";
                    p2Text.text = "Player 2: YOU LOSE";
                    p1TextS2.text = "Player 1: YOU WIN";
                    p2TextS2.text = "Player 2: YOU LOSE";
                    p1TextS3.text = "Player 1: YOU WIN";
                    p2TextS3.text = "Player 2: YOU LOSE";
                    p1TextS4.text = "Player 1: YOU WIN";
                    p2TextS4.text = "Player 2: YOU LOSE";
                }
                else
                {
                    // tiebreaker based on better shooting percentage
                    if (p1shots > p2shots)
                    {
                        p1Text.text = "Player 1: YOU LOSE";
                        p2Text.text = "Player 2: YOU WIN";
                        p1TextS2.text = "Player 1: YOU LOSE";
                        p2TextS2.text = "Player 2: YOU WIN";
                        p1TextS3.text = "Player 1: YOU LOSE";
                        p2TextS3.text = "Player 2: YOU WIN";
                        p1TextS4.text = "Player 1: YOU LOSE";
                        p2TextS4.text = "Player 2: YOU WIN";
                    }
                    // ends in tie if equal shooting percentage
                    else
                    {
                        p1Text.text = "Player 1: TIE GAME";
                        p2Text.text = "Player 2: TIE GAME";
                        p1TextS2.text = "Player 1: TIE GAME";
                        p2TextS2.text = "Player 2: TIE GAME";
                        p1TextS3.text = "Player 1: TIE GAME";
                        p2TextS3.text = "Player 2: TIE GAME";
                        p1TextS4.text = "Player 1: TIE GAME";
                        p2TextS4.text = "Player 2: TIE GAME";
                    }
                }
            }
            else
            {
                // player 1 wins
                if (p1score > p2score)
                {
                    p1Text.text = "Player 1: YOU WIN";
                    p2Text.text = "Player 2: YOU LOSE"; 
                    p1TextS2.text = "Player 1: YOU WIN";
                    p2TextS2.text = "Player 2: YOU LOSE";
                    p1TextS3.text = "Player 1: YOU WIN";
                    p2TextS3.text = "Player 2: YOU LOSE";
                    p1TextS4.text = "Player 1: YOU WIN";
                    p2TextS4.text = "Player 2: YOU LOSE";
                }
                // player 2 wins
                else
                {
                    p1Text.text = "Player 1: YOU LOSE";
                    p2Text.text = "Player 2: YOU WIN";
                    p1TextS2.text = "Player 1: YOU LOSE";
                    p2TextS2.text = "Player 2: YOU WIN";
                    p1TextS3.text = "Player 1: YOU LOSE";
                    p2TextS3.text = "Player 2: YOU WIN";
                    p1TextS4.text = "Player 1: YOU LOSE";
                    p2TextS4.text = "Player 2: YOU WIN";
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
        // add to the player's score if they made a shot
        if (id == 1)
        {
            p1score += 1;
        }
        else if (id == 2)
        {
            p2score += 1;
        }
    }

    public void UpdateShotsAttempted(int id)
    {
        // add to the player's total shots if they attempted a shot
        if (id == 1)
        {
            p1shots += 1;
        }
        else if (id == 2)
        {
            p2shots += 1;
        }
    }

    public void CountDown()
    {
        // countdown the shot clock until the game is over
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
        // the updated time remaining
        timerText.text = sec;
        timerText2.text = sec;
        timerText3.text = sec;
        timerText4.text = sec;
    }

    public void Finish()
    {
        // change the shot clock color to red and say game over
        gameover = true;
        timerText.color = Color.red;
        timerText.text = "Game Over";
        timerText2.color = Color.red;
        timerText2.text = "Game Over";
        timerText3.color = Color.red;
        timerText3.text = "Game Over";
        timerText4.color = Color.red;
        timerText4.text = "Game Over";
        // destroy all the remaining hoops
        var baskets = GameObject.FindGameObjectsWithTag("hoop");
        foreach (var basket in baskets)
        {
            Destroy(basket);
        }
    }
}