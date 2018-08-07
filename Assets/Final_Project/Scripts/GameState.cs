using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameState : NetworkBehaviour
{
    [SyncVar]
    public int lastPlayerId = 0;

    public SyncListInt players = new SyncListInt();

    [SyncVar]
    public int p1score;
    [SyncVar]
    public int p2score;

    public override void OnStartServer()
    {
        base.OnStartServer();
        p1score = 0;
        p2score = 0;
    }

    // this increments lastPlayerId and adds an entry in the scoreboard array
    // this is called from a Command by the player, so it runs as server
    public void AddNewPlayer()
    {
        lastPlayerId++;
        players.Add(0);
        Debug.Log("Added new player: " + lastPlayerId + " now players len = " + players.Count);
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
        print("player 1 score: " + p1score);
    }
}