using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameState : NetworkBehaviour {
    //public ArrayList players = new ArrayList();
    //public float[] players= new float[4];


    // public int[] players = new int[] {-1, -1, -1, -1};

    public SyncListInt players = new SyncListInt();

    [SyncVar]
    public int currPlayers;


    //[SyncVar]
    public  int maxPlayers = 4;
    [SyncVar]
    public int winner;

    private CustomNetworkDiscovery netScript;
    public GameObject netGameObj;


    bool p1set;
    bool p2set;


	// Use this for initialization
	void Start () {
        netScript = netGameObj.GetComponent<CustomNetworkDiscovery>();
        p1set = netScript.Player1Set();
        p2set = netScript.Player2Set();
        //currPlayers = players.Count;
	}
	
	// Update is called once per frame
	void Update () {
        currPlayers = players.Count;
        if (p1set)
        {
            AddPlayer(0);
            print("player 1 added");
            print("Count after adding player 1 " + players.Count);
            p1set = false;

        }
        if (p2set)
        {
            AddPlayer(0);
            print("player 2 added");
            foreach (int score in players)
            {
                print(score);
            }
            p2set = false;
        }
        print("currPlayers: " + currPlayers);

	}

    //public void AddPlayer(int index, int num) {
    //    players[index] = num;
    //    if (index == 0)
    //        print("Player 1 added to game");
        
    //    else if (index == 1)
    //        print("Player 2 added to game");
    //}

    public void AddPlayer(int num){
        players.Add(num);
    }

    public int NumPlayers() {
        return currPlayers;

    } 




    //public bool DoneCheckingPlayer1()
    //{
    //    if (netScript.Player1Set())
    //    {
    //        return false;
    //    }
    //    return true;
    //}
}
